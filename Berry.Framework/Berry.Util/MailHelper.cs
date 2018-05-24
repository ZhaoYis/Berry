using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace Berry.Util
{
    /// <summary>
    /// 邮件帮助类
    /// </summary>
    public sealed class MailHelper
    {
        /// <summary>
        /// 读取页面数据流
        /// </summary>
        private static StreamReader _sr = null;

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        private static readonly string MailServer = ConfigHelper.GetValue("ErrorReportMailHost");
        /// <summary>
        /// 用户名
        /// </summary>
        private static readonly string MailUserName = ConfigHelper.GetValue("ErrorReportMailUserName");
        /// <summary>
        /// 密码
        /// </summary>
        private static readonly string MailPassword = ConfigHelper.GetValue("ErrorReportMailPassword");
        /// <summary>
        /// 邮件名称
        /// </summary>
        private static readonly string MailName = ConfigHelper.GetValue("ErrorReportMailName");

        private static readonly string TemplateString;
        static MailHelper()
        {
            string templatePath = "Template\\eamil_template.html";

            //保存静态文件的路径
            string realPath = DirFileHelper.MapPath(templatePath);

            //模板文件内容
            TemplateString = ReadTemplateFile(realPath, "UTF-8");
        }

        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <param name="to">收件人邮箱地址，多个收件人用;隔开</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码</param>
        /// <param name="isBodyHtml">是否Html</param>
        /// <param name="enableSsl">是否SSL加密连接</param>
        /// <returns>是否成功</returns>
        public static bool Send(string to, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                if (string.IsNullOrEmpty(to))
                    return false;

                MailMessage message = new MailMessage();
                string[] toArr = to.Split(";".ToArray());
                // 接收人邮箱地址
                foreach (string address in toArr)
                {
                    message.To.Add(new MailAddress(address));
                }

                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = GetEmailTemplate(subject, body);
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;
                message.Priority = MailPriority.Normal;//优先级

                SmtpClient smtpclient = new SmtpClient(MailServer, 25)
                {
                    EnableSsl = enableSsl,//是否SSL连接
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,//指定电子邮件发送方式   
                    Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword),
                };

                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 异步发送邮件 独立线程
        /// </summary>
        /// <param name="to">收件人邮箱地址，多个收件人用;隔开，最后一个不加</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码</param>
        /// <param name="isBodyHtml">是否Html</param>
        /// <param name="enableSsl">是否SSL加密连接</param>
        /// <returns>是否成功</returns>
        public static void SendByThread(string to, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            new Thread(new ThreadStart(delegate ()
            {
                try
                {
                    string[] toArr = to.Split(";".ToArray());
                    MailMessage message = new MailMessage();
                    // 接收人邮箱地址
                    foreach (string address in toArr)
                    {
                        message.To.Add(new MailAddress(address));
                    }

                    message.From = new MailAddress(MailUserName, MailName);
                    message.BodyEncoding = Encoding.GetEncoding(encoding);
                    message.Body = GetEmailTemplate(subject, body);
                    //GB2312
                    message.SubjectEncoding = Encoding.GetEncoding(encoding);
                    message.Subject = subject;
                    message.IsBodyHtml = isBodyHtml;
                    message.Priority = MailPriority.Normal;//优先级

                    SmtpClient smtpclient = new SmtpClient(MailServer, 25)
                    {
                        EnableSsl = enableSsl,//是否SSL连接
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,//指定电子邮件发送方式   
                        Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword),
                    };

                    //发送
                    smtpclient.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            })).Start();
        }

        /// <summary>
        /// 组装邮件模板
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private static string GetEmailTemplate(string subject, string body)
        {
            Dictionary<string, string> source = new Dictionary<string, string>
                {
                    { "$$EmailHead$$", subject },
                    { "$$EmailBody$$", body }
                };

            return ReplaceTemplateTag(source, TemplateString);
        }

        /// <summary>
        /// 读取文件字节流
        /// </summary>
        /// <param name="templatePath">模板相对路径</param>
        /// <param name="encode">页面编码</param>
        /// <returns>template静态模板的html字符串</returns>
        private static string ReadTemplateFile(string templatePath, string encode)
        {
            try
            {
                Encoding code = Encoding.GetEncoding(encode);
                if (DirFileHelper.IsExistFile(templatePath))
                {
                    //读取
                    using (_sr = new StreamReader(templatePath, code))
                    {
                        return _sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                if (_sr != null) _sr.Close();
            }
            return "";
        }

        /// <summary>
        /// 替换特征字符串
        /// </summary>
        /// <param name="source">特征字符串-待填充的数据</param>
        /// <param name="streamstr">template静态模板的html字符串</param>
        /// <returns></returns>
        private static string ReplaceTemplateTag(Dictionary<string, string> source, string streamstr)
        {
            if (source != null && source.Count > 0)
            {
                streamstr = source.Aggregate(streamstr, (current, data) => current.Replace(data.Key, data.Value));
            }

            return streamstr;
        }
    }
}