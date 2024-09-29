namespace FO2Dat
{
    public class DatFile
    {
        private string _fileName;

        public string fileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                fileTitle = _fileName[(_fileName.LastIndexOf('\\') + 1)..];
            }
        }
        public string fileTitle { get; private set; }
        public uint filesTotal { get; set; }
        public uint treeSize { get; set; }
        public uint fileSize { get; set; }
        public uint realSize { get; set; }
        public uint dataSize => fileSize - 8 - treeSize;
        public List<DirEntry> dirTree { get; set; }

        public DatFile()
        {
            dirTree = [];
            _fileName = "";
            fileTitle = "";
        }
    }
}
