namespace FO2Dat
{
    public class StringHelper
    {
        public static string[] splitPath(string fullPath) => fullPath.Split('\\');

        public static string addSlash(string path) => path + ((path[^1..] != "\\") ? "\\" : "");

        public static string left(string source, int length) => source[..length];

        public static string removePath(string source, string path) => string.IsNullOrEmpty(path) ? source : source.Replace(path, "");

        public static string formatSizeString(uint size)
        {
            float kbytes = size / 1024f;
            float mbytes = kbytes / 1024f;
            float gbytes = mbytes / 1024f;
            float value = gbytes > 1 ? gbytes : mbytes > 1 ? mbytes : kbytes;
            string text = gbytes > 1 ? "GB" : mbytes > 1 ? "MB" : "KB";
            return value.ToString("#,##0.00 " + text);
        }
    }
}
