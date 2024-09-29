using System.Runtime.InteropServices;

namespace FO2Dat
{
    public partial class ZLibHelper
    {
        const int Z_OK = 0;
        const int Z_STREAM_ERROR = (-2);
        const int Z_DATA_ERROR = (-3);
        const int Z_MEM_ERROR = (-4);
        const int Z_BUF_ERROR = (-5);
        const int Z_VERSION_ERROR = (-6);

        [LibraryImport("zlibwapi.dll")]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static partial int uncompress(byte[] destBuffer, ref uint destLen, byte[] sourceBuffer, uint sourceLen);

        [LibraryImport("zlibwapi.dll")]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static partial int compress2(byte[] destBuffer, ref uint destLen, byte[] sourceBuffer, uint sourceLen, int level);

        private static uint calcNewBufferSize(uint bufferSize) => (uint)(bufferSize + (bufferSize * 0.01d) + 12d);

        private static byte[] zLibRoutineCall(byte[] source, uint size = 0)
        {
            int lret;
            uint sourceLength = (uint)source.Length;
            uint destinationBufferLength = calcNewBufferSize((size == 0) ? sourceLength : size);
            byte[] destinationBuffer = new byte[destinationBufferLength];
            if (size == 0) lret = compress2(destinationBuffer, ref destinationBufferLength, source, sourceLength, 9);
            else lret = uncompress(destinationBuffer, ref destinationBufferLength, source, sourceLength);
            if (lret != Z_OK)
            {
                throw lret switch
                {
                    Z_STREAM_ERROR => new Exception("Level parameter is invalid!"),
                    Z_DATA_ERROR => new Exception("Input data was corrupted or incomplete!"),
                    Z_MEM_ERROR => new Exception("Not enough memory!"),
                    Z_BUF_ERROR => new Exception("Not enough room in the output buffer!"),
                    _ => new Exception("Unexpected error!"),
                };
            }
            Array.Resize(ref destinationBuffer, (int)destinationBufferLength);
            return destinationBuffer;
        }

        public static byte[] compress(byte[] source) => zLibRoutineCall(source);

        public static byte[] uncompress(byte[] compressed, uint realSize) => zLibRoutineCall(compressed, realSize);
    }
}
