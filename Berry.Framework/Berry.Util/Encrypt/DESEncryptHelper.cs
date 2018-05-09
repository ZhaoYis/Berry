using System;
using System.Security.Cryptography;
using System.Text;

namespace Berry.Util
{
    /// <summary>
    /// 加密、解密帮助类，对称加密
    /// </summary>
    public class DESEncryptHelper
    {
        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            return Encrypt(text, "1qaz0okm~!@%__###***");
        }

        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(text);

            des.Key = Encoding.ASCII.GetBytes(Md5Helper.Md5(sKey).Substring(0, 8));
            des.IV = Encoding.ASCII.GetBytes(Md5Helper.Md5(sKey).Substring(0, 8));

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion ========加密========

        #region ========解密========

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Decrypt(text, "1qaz0okm~!@%__###***");
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len = text.Length / 2;
            byte[] inputByteArray = new byte[len];

            for (int x = 0; x < len; x++)
            {
                int i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            des.Key = Encoding.ASCII.GetBytes(Md5Helper.Md5(sKey).Substring(0, 8));
            des.IV = Encoding.ASCII.GetBytes(Md5Helper.Md5(sKey).Substring(0, 8));

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion ========解密========
    }
}