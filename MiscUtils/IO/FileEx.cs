﻿using System.IO;
using System.Threading.Tasks;

namespace MiscUtils.IO
{
    public class FileEx
    {
        public static async Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            using (FileStream fs = File.OpenWrite(path))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        public static async Task<byte[]> ReadAllBytesAsync(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] result = new byte[fs.Length];

                await fs.ReadAsync(result, 0, result.Length);

                return result;
            }
        }

        #region Storage formats
        public static string FormatStorage(short bytesCount) => FormatStorage((float)bytesCount);
        public static string FormatStorage(ushort bytesCount) => FormatStorage((float)bytesCount);
        public static string FormatStorage(int bytesCount) => FormatStorage((float)bytesCount);
        public static string FormatStorage(uint bytesCount) => FormatStorage((float)bytesCount);
        public static string FormatStorage(long bytesCount) => FormatStorage((float)bytesCount);
        public static string FormatStorage(ulong bytesCount) => FormatStorage((float)bytesCount);
        public static string FormatStorage(float bytesCount)
        {
            string result;

            if (bytesCount < 1ul << 10)
            {
                result = $"{bytesCount} B";
            }
            else if (bytesCount < 1ul << 20)
            {
                result = $"{bytesCount / (1ul << 10):F3} KiB";
            }
            else if (bytesCount < 1ul << 30)
            {
                result = $"{bytesCount / (1ul << 20):F3} MiB";
            }
            else if (bytesCount < 1ul << 40)
            {
                result = $"{bytesCount / (1ul << 30):F3} GiB";
            }
            else
            {
                result = $"{bytesCount / (1ul << 40):F3} TiB";
            }

            return result;
        }

        public static string FormatStorageSpeed(short bytesCount) => FormatStorageSpeed((float)bytesCount);
        public static string FormatStorageSpeed(ushort bytesCount) => FormatStorageSpeed((float)bytesCount);
        public static string FormatStorageSpeed(int bytesCount) => FormatStorageSpeed((float)bytesCount);
        public static string FormatStorageSpeed(uint bytesCount) => FormatStorageSpeed((float)bytesCount);
        public static string FormatStorageSpeed(long bytesCount) => FormatStorageSpeed((float)bytesCount);
        public static string FormatStorageSpeed(ulong bytesCount) => FormatStorageSpeed((float)bytesCount);
        public static string FormatStorageSpeed(float bytesCount) => FormatStorage(bytesCount) + "/s";
        #endregion
    }
}
