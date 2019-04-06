#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.Util
* 项目描述 ：
* 类 名 称 ：DecryptDbConnectionHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.Util
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/7 14:25:40
* 更新时间 ：2019/3/7 14:25:40
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berry.Util
{
    /// <summary>
    /// 功能描述    ：解密数据库连接字符串  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/7 14:25:40 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/7 14:25:40 
    /// </summary>
    public class DecryptDbConnectionHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString = string.Empty;

        public DecryptDbConnectionHelper(string filePath)
        {
            ConnectionString = Decrypt(filePath);
        }

        /// <summary>
        /// 获取解密后的数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return ConnectionString;
        }

        /// <summary>
        /// 获取解密后的数据库连接字符串
        /// </summary>
        /// <returns></returns>
        private static string Decrypt(string filePath)
        {
            try
            {
                string datFileName = AppDomain.CurrentDomain.BaseDirectory + filePath;
                if (!File.Exists(datFileName)) return "";

                byte[] buffer;
                using (Stream stream = new FileStream(datFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                }
                int realLength = buffer.Length;
                for (int i = 0; i < buffer.Length; i++)
                {
                    byte b = buffer[i];
                    if (b == 13)
                    {
                        realLength = i;
                        break;
                    }
                }

                for (int i = 0; i < realLength; i++)
                {
                    byte b = buffer[i];
                    buffer[i] = (byte)(b ^ (byte)128); // 异或解密
                }
                string answer = Encoding.Default.GetString(buffer, 0, realLength);
                return answer.Replace("Provider=SQLOLEDB.1;", "");
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="destPath">输出文件路径</param>
        /// <param name="sDatabase">数据库名称</param>
        /// <param name="sServer">服务器地址</param>
        /// <param name="sUser">账号</param>
        /// <param name="sPwd">密码</param>
        /// <returns></returns>
        private bool Encrypt(string destPath, string sDatabase, string sServer, string sUser, string sPwd)
        {
            sDatabase = sDatabase ?? "master";
            try
            {
                string connectionString = this.BuildConnectionString(sServer, sDatabase, sUser, sPwd);
                connectionString = "Provider=SQLOLEDB.1;" + connectionString;

                byte[] buffer = Encoding.Default.GetBytes(connectionString);
                for (int i = 0; i < buffer.Length; i++)
                {
                    byte b = buffer[i];
                    buffer[i] = (byte)(b ^ (byte)128); // 异或加密
                }

                using (Stream stream = new FileStream(destPath, FileMode.Create))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 构造连接字符串
        /// </summary>
        /// <param name="server">服务器实例名</param>
        /// <param name="initialCatalog">数据库名</param>
        /// <param name="userId">用户名默认为空</param>
        /// <param name="pwd">密码, 默认为空</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private string BuildConnectionString(string server, string initialCatalog, string userId, string pwd, int timeout = 0)
        {
            // 用户名不能为空
            if (userId == "") return string.Empty;
            SqlConnectionStringBuilder conStrBuider = new SqlConnectionStringBuilder
            {
                InitialCatalog = initialCatalog,
                DataSource = server,
                UserID = userId,
                Password = pwd,
                IntegratedSecurity = false
            };
            if (timeout != 0) conStrBuider.ConnectTimeout = timeout;

            return conStrBuider.ConnectionString;
            // return @" Password=" + sPwd + ";Persist Security Info=True;User ID=" + sUserName + ";Initial Catalog=" + sCatalog + ";Data Source=" + sLocalServer;
        }
    }
}
