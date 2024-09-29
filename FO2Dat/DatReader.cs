using System.ComponentModel;
using System.Text;

namespace FO2Dat
{
    public class DatReader
    {
        //private readonly StringHelper stringHelper = new();

        public static DatFile? load(string file)
        {
            DatFile datFile = new() { fileName = file };
            try
            {
                using BinaryReader reader = new(File.Open(file, FileMode.Open));
                reader.BaseStream.Seek(-8, SeekOrigin.End);
                datFile.treeSize = reader.ReadUInt32();
                datFile.fileSize = reader.ReadUInt32();
                /*
                 *  Data Block min 1 byte
                 *  Files Total  4 bytes
                 *  FileNameLen 4 bytes
                 *  FileName 1 byte
                 *  Type 1 byte
                 *  RealSize 4 bytes
                 *  packed size 4 bytes
                 *  offset 4 bytes
                 *  treesize 4 bytes
                 *  filesize 4 bytes
                 *  
                 *  total 31 bytes minimum the file size should be
                 *  file size must be equals filesize value
                 *  tree size should be 22 bytes minimum
                 */
                if (datFile.fileSize < 31 ||
                    reader.BaseStream.Length != datFile.fileSize ||
                    datFile.treeSize < 22 ||
                    datFile.treeSize > datFile.fileSize - 9 ||
                    datFile.dataSize < 1) throw new Exception();
                reader.BaseStream.Seek(-(datFile.treeSize + 8), SeekOrigin.End);
                datFile.filesTotal = reader.ReadUInt32();
                if (datFile.filesTotal < 1) throw new Exception();
                readTree(datFile, reader);
            }
            catch (Exception)
            {
                return null;
            }
            return datFile;
        }

        private static void readTree(DatFile datFile, BinaryReader reader)
        {
            reader.BaseStream.Seek(-(datFile.treeSize + 4), SeekOrigin.End);
            for (int i = 0; i < datFile.filesTotal; i++)
            {
                DirEntry newEntry = readNextDirEntry(reader);
                if (newEntry.type > 1 ||
                    newEntry.offset < 0 ||
                    newEntry.offset > datFile.dataSize ||
                    newEntry.packedSize > datFile.dataSize ||
                    newEntry.realSize < newEntry.packedSize ||
                    newEntry.packedSize < 0 ||
                    newEntry.realSize < 0) throw new Exception();
                datFile.dirTree.Add(newEntry);
                datFile.realSize += newEntry.realSize;
            }
        }

        private static DirEntry readNextDirEntry(BinaryReader reader)
        {
            DirEntry dirEntry = new();
            int fileNameLength = reader.ReadInt32();
            if (fileNameLength < 1) throw new Exception();
            dirEntry.fileName = Encoding.UTF8.GetString(reader.ReadBytes(fileNameLength));
            dirEntry.type = reader.ReadByte();
            dirEntry.realSize = reader.ReadUInt32();
            dirEntry.packedSize = reader.ReadUInt32();
            dirEntry.offset = reader.ReadUInt32();
            return dirEntry;
        }

        public static void extractFile(string datFile, DirEntry entry, string destinationPath, string pathFilter = "")
        {
            //ZLibHelper zLib = new();
            destinationPath = StringHelper.addSlash(destinationPath);
            string file = createDirectoryStructureAndReturnFileName(destinationPath, entry.fileName, pathFilter);
            if (File.Exists(file)) File.Delete(file);
            using BinaryWriter writer = new(File.Create(file));
            byte[] fileBuff;
            using (BinaryReader reader = new(File.Open(datFile, FileMode.Open)))
            {
                reader.BaseStream.Seek(entry.offset, SeekOrigin.Begin);
                fileBuff = reader.ReadBytes((int)entry.packedSize);
            }
            byte[] writeBuff;
            if (entry.type == 1) writeBuff = ZLibHelper.uncompress(fileBuff, entry.realSize);
            else writeBuff = fileBuff;
            writer.Write(writeBuff);
        }

        private static string createDirectoryStructureAndReturnFileName(string destinationPath, string fileName, string pathFilter = "")
        {
            string parent = destinationPath;
            string file = StringHelper.removePath(fileName, pathFilter);
            if (file.Contains('\\'))
            {
                string[] path2 = StringHelper.splitPath(file);
                for (int i = 0; i < path2.Length - 1; i++)
                {
                    if (!Directory.Exists(parent + path2[i])) Directory.CreateDirectory(parent + path2[i]);
                    parent += path2[i] + "\\";
                }
                file = path2[^1];
            }
            return parent + file;
        }

        public static void extractAll(DatFile datFile, string destinationPath, List<DirEntry> dirEntries, BackgroundWorker worker, string pathFilter = "")
        {
            float count = 0;
            foreach (DirEntry entry in dirEntries)
            {
                count++;
                extractFile(datFile.fileName, entry, destinationPath, pathFilter);
                worker.ReportProgress((int)(count / dirEntries.Count * 100f));
            }
        }
    }
}
