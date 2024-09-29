using System.ComponentModel;
using System.Text;

namespace FO2Dat
{
    public class DatWriter
    {
        //readonly StringHelper stringHelper = new();

        public static void createDatHeader(DatFile datFile, DirectoryInfo path, string root = "", BinaryWriter? writer = null, uint total = 0, BackgroundWorker? worker = null)
        {
            ZLibHelper zLib = new();
            root = (root == "") ? path.FullName : root;
            FileInfo[] files = Array.FindAll(path.GetFiles(), x => (x.Attributes & FileAttributes.Hidden) == 0);
            DirectoryInfo[] folders = Array.FindAll(path.GetDirectories(), x => (x.Attributes & FileAttributes.Hidden) == 0);
            foreach (FileInfo file in files)
            {
                if (file.Length > 0x7EBB_906C) throw new Exception();
                DirEntry dirEntry = new()
                {
                    fileName = file.FullName.Replace(StringHelper.addSlash(root), ""),
                    realSize = (uint)file.Length
                };
                datFile.realSize += dirEntry.realSize;
                datFile.filesTotal++;
                datFile.dirTree.Add(dirEntry);
                if (writer != null && worker != null)
                {
                    dirEntry.offset = (uint)writer.BaseStream.Position;
                    using BinaryReader reader = new(File.Open(file.FullName, FileMode.Open));
                    byte[] readBuff = new byte[dirEntry.realSize];
                    readBuff = reader.ReadBytes(readBuff.Length);
                    byte[] compressed = ZLibHelper.compress(readBuff);
                    if (compressed.Length < readBuff.Length) dirEntry.type = 1;
                    else compressed = readBuff;
                    dirEntry.packedSize = (uint)compressed.Length;
                    writer.Write(compressed);
                    worker.ReportProgress((int)(datFile.realSize * 100f / total));
                }
            }
            foreach (DirectoryInfo folder in folders) createDatHeader(datFile, folder, root, writer, total, worker);
        }

        public static void createDatFile(DatFile datFile, string file, BackgroundWorker worker)
        {
            if (File.Exists(file)) File.Delete(file);
            string path = StringHelper.left(datFile.fileName, datFile.fileName.LastIndexOf('\\'));
            uint total = datFile.realSize;
            datFile = new DatFile
            {
                fileName = file
            };
            using BinaryWriter writer = new(File.Create(file));
            createDatHeader(datFile, new DirectoryInfo(path), "", writer, total, worker);
            writer.Write(datFile.filesTotal);
            long currentSize = writer.BaseStream.Position;
            uint count = 0;
            foreach (DirEntry dirEntry in datFile.dirTree)
            {
                byte[] nameBytes = Encoding.UTF8.GetBytes(dirEntry.fileName);
                writer.Write(nameBytes.Length);
                writer.Write(nameBytes);
                writer.Write(dirEntry.type);
                writer.Write(dirEntry.realSize);
                writer.Write(dirEntry.packedSize);
                writer.Write(dirEntry.offset);
                count++;
                worker.ReportProgress((int)(count * 100f / datFile.filesTotal));
            }
            datFile.treeSize = (uint)(writer.BaseStream.Position - currentSize + 4);
            writer.Write(datFile.treeSize);
            datFile.fileSize = (uint)(writer.BaseStream.Position + 4);
            writer.Write(datFile.fileSize);
        }
    }
}
