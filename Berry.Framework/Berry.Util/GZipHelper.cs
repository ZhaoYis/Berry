using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Berry.Util
{
    /// <summary>
    /// GZip压缩帮助类
    /// </summary>
    public sealed class GZipHelper
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="text">文本</param>
        public static string GZipCompress(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            byte[] buffer = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(GZipCompress(buffer));
        }

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] GZipCompress(Stream stream)
        {
            if (stream == null || stream.Length == 0)
                return null;
            return GZipCompress(StreamToBytes(stream));
        }

        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] GZipCompress(byte[] buffer)
        {
            if (buffer == null) return null;
            using (var ms = new MemoryStream())
            {
                using (var zip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    zip.Write(buffer, 0, buffer.Length);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deflate压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] DeflateCompress(byte[] buffer)
        {
            if (buffer == null) return null;
            using (var ms = new MemoryStream())
            {
                using (var deflate = new DeflateStream(ms, CompressionMode.Compress, true))
                {
                    deflate.Write(buffer, 0, buffer.Length);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="text">文本</param>
        public static string Decompress(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            byte[] buffer = Convert.FromBase64String(text);
            using (var ms = new MemoryStream(buffer))
            {
                using (var zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(zip))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] Decompress(byte[] buffer)
        {
            if (buffer == null)
                return null;
            return Decompress(new MemoryStream(buffer));
        }

        #region 私有方法

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="stream">流</param>
        private static byte[] Decompress(Stream stream)
        {
            if (stream == null || stream.Length == 0)
                return null;
            using (var zip = new GZipStream(stream, CompressionMode.Decompress))
            {
                using (var reader = new StreamReader(zip))
                {
                    return Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }
            }
        }
        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        private static byte[] StreamToBytes(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        #endregion
    }
}