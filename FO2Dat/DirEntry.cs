namespace FO2Dat
{
    public class DirEntry
    {
        public DirEntry()
        {
            fileName = "";
        }

        public string fileName { get; set; }
        public byte type { get; set; }
        public uint realSize { get; set; }
        public uint packedSize { get; set; }
        public uint offset { get; set; }
    }
}
