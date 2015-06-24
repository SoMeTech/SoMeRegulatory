namespace BHSoft.BHWeb.Common.Mail
{
    using BHSoft.BHWeb.Common.CommonClasses;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;

    public class SmtpServerHelper
    {
        private string CRLF = "\r\n";
        private Hashtable ErrCodeHT = new Hashtable();
        private string errmsg;
        private string logs = "";
        private NetworkStream networkStream;
        private Hashtable RightCodeHT = new Hashtable();
        private TcpClient tcpClient;

        public SmtpServerHelper()
        {
            this.SMTPCodeAdd();
        }

        private string Base64Decode(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.Default.GetString(bytes);
        }

        private string Base64Encode(string str)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(str));
        }

        private bool Connect(string smtpServer, int port)
        {
            try
            {
                this.tcpClient = new TcpClient(smtpServer, port);
            }
            catch (Exception exception)
            {
                this.errmsg = exception.ToString();
                return false;
            }
            this.networkStream = this.tcpClient.GetStream();
            if (this.RightCodeHT[this.RecvResponse().Substring(0, 3)] == null)
            {
                this.errmsg = "网络连接失败";
                return false;
            }
            return true;
        }

        private bool Dialog(string str, string errstr)
        {
            if ((str == null) || (str.Trim() == string.Empty))
            {
                return true;
            }
            if (this.SendCommand(str))
            {
                string str2 = this.RecvResponse();
                if (str2 != "false")
                {
                    string str3 = str2.Substring(0, 3);
                    if (this.RightCodeHT[str3] != null)
                    {
                        return true;
                    }
                    if (this.ErrCodeHT[str3] != null)
                    {
                        this.errmsg = this.errmsg + str3 + this.ErrCodeHT[str3].ToString();
                        this.errmsg = this.errmsg + this.CRLF;
                    }
                    else
                    {
                        this.errmsg = this.errmsg + str2;
                    }
                    this.errmsg = this.errmsg + errstr;
                    log.TraceLog("提示信息: " + this.errmsg);
                }
            }
            return false;
        }

        private bool Dialog(string[] str, string errstr)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!this.Dialog(str[i], ""))
                {
                    this.errmsg = this.errmsg + this.CRLF;
                    this.errmsg = this.errmsg + errstr;
                    return false;
                }
            }
            return true;
        }

        ~SmtpServerHelper()
        {
            this.networkStream.Close();
            this.tcpClient.Close();
        }

        private string GetPriorityString(MailPriority mailPriority)
        {
            string str = "Normal";
            if (mailPriority == MailPriority.Low)
            {
                return "Low";
            }
            if (mailPriority == MailPriority.High)
            {
                str = "High";
            }
            return str;
        }

        private string GetStream(string FilePath)
        {
            FileStream stream = new FileStream(FilePath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            return Convert.ToBase64String(buffer);
        }

        private string RecvResponse()
        {
            int num;
            string str = string.Empty;
            byte[] buffer = new byte[0x400];
            try
            {
                num = this.networkStream.Read(buffer, 0, buffer.Length);
            }
            catch
            {
                this.errmsg = "网络连接错误";
                return "false";
            }
            if (num != 0)
            {
                str = Encoding.Default.GetString(buffer).Substring(0, num);
                this.logs = this.logs + str + this.CRLF;
            }
            return str;
        }

        private bool SendCommand(string str)
        {
            if ((str != null) && (str.Trim() != string.Empty))
            {
                this.logs = this.logs + str;
                byte[] bytes = Encoding.Default.GetBytes(str);
                try
                {
                    this.networkStream.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    this.errmsg = "网络连接错误";
                    return false;
                }
            }
            return true;
        }

        public bool SendEmail(string smtpServer, int port, MailMessage mailMessage)
        {
            return this.SendEmail(smtpServer, port, false, "", "", mailMessage);
        }

        public bool SendEmail(string smtpServer, int port, string username, string password, MailMessage mailMessage)
        {
            return this.SendEmail(smtpServer, port, true, username, password, mailMessage);
        }

        private bool SendEmail(string smtpServer, int port, bool ESmtp, string username, string password, MailMessage mailMessage)
        {
            string[] strArray;
            string str;
            int num;
            if (!this.Connect(smtpServer, port))
            {
                log.TraceLog("连接邮件服务器不成功,退出");
                return false;
            }
            log.TraceLog("连接邮件服务器成功");
            string priorityString = this.GetPriorityString(mailMessage.Priority);
            bool flag = mailMessage.BodyFormat == MailFormat.HTML;
            log.TraceLog(string.Concat(new object[] { "取得相关数据 priority=", priorityString, " BodyFormat=", mailMessage.BodyFormat }));
            if (ESmtp)
            {
                log.TraceLog("SMTP服务器开始认证状态");
                strArray = new string[] { "EHLO " + smtpServer + this.CRLF, "AUTH LOGIN" + this.CRLF, this.Base64Encode(username) + this.CRLF, this.Base64Encode(password) + this.CRLF };
                if (!this.Dialog(strArray, "SMTP服务器验证失败，请核对用户名和密码。"))
                {
                    log.TraceLog("SMTP服务器认证失败");
                    return false;
                }
            }
            else
            {
                log.TraceLog("SMTP服务器不需要身份认证状态");
                str = "HELO " + smtpServer + this.CRLF;
                if (!this.Dialog(str, ""))
                {
                    return false;
                }
            }
            str = "MAIL FROM:<" + mailMessage.From + ">" + this.CRLF;
            if (!this.Dialog(str, "发件人地址错误，或不能为空"))
            {
                return false;
            }
            strArray = new string[mailMessage.Recipients.Count];
            for (num = 0; num < mailMessage.Recipients.Count; num++)
            {
                strArray[num] = "RCPT TO:<" + ((string) mailMessage.Recipients[num]) + ">" + this.CRLF;
            }
            if (!this.Dialog(strArray, "收件人地址有误"))
            {
                return false;
            }
            str = "DATA" + this.CRLF;
            if (!this.Dialog(str, ""))
            {
                return false;
            }
            str = "From:" + mailMessage.FromName + "<" + mailMessage.From + ">" + this.CRLF;
            if (mailMessage.Recipients.Count == 0)
            {
                return false;
            }
            string str3 = str;
            str = str3 + "To:=?" + mailMessage.Charset.ToUpper() + "?B?" + this.Base64Encode((string) mailMessage.Recipients[0]) + "?=<" + ((string) mailMessage.Recipients[0]) + ">" + this.CRLF;
            str = str + (((mailMessage.Subject == string.Empty) || (mailMessage.Subject == null)) ? "Subject:" : ((mailMessage.Charset == "") ? ("Subject:" + mailMessage.Subject) : ("Subject:=?" + mailMessage.Charset.ToUpper() + "?B?" + this.Base64Encode(mailMessage.Subject) + "?="))) + this.CRLF + "X-Priority:" + priorityString + this.CRLF + "X-MSMail-Priority:" + priorityString + this.CRLF + "Importance:" + priorityString + this.CRLF + "X-Mailer: Lion.Web.Mail.SmtpMail Pubclass [cn]" + this.CRLF + "MIME-Version: 1.0" + this.CRLF;
            if (mailMessage.Attachments.Count != 0)
            {
                str3 = str + "Content-Type: multipart/mixed;" + this.CRLF;
                str = str3 + " boundary=\"=====" + (flag ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====\"" + this.CRLF + this.CRLF;
            }
            if (flag)
            {
                if (mailMessage.Attachments.Count == 0)
                {
                    str = str + "Content-Type: multipart/alternative;" + this.CRLF + " boundary=\"=====003_Dragon520636771063_=====\"" + this.CRLF + this.CRLF + "This is a multi-part message in MIME format." + this.CRLF + this.CRLF;
                }
                else
                {
                    str = str + "This is a multi-part message in MIME format." + this.CRLF + this.CRLF + "--=====001_Dragon520636771063_=====" + this.CRLF + "Content-Type: multipart/alternative;" + this.CRLF + " boundary=\"=====003_Dragon520636771063_=====\"" + this.CRLF + this.CRLF;
                }
                str = str + "--=====003_Dragon520636771063_=====" + this.CRLF + "Content-Type: text/plain;" + this.CRLF + ((mailMessage.Charset == "") ? " charset=\"iso-8859-1\"" : (" charset=\"" + mailMessage.Charset.ToLower() + "\"")) + this.CRLF + "Content-Transfer-Encoding: base64" + this.CRLF + this.CRLF + this.Base64Encode("邮件内容为HTML格式，请选择HTML方式查看") + this.CRLF + this.CRLF + "--=====003_Dragon520636771063_=====" + this.CRLF + "Content-Type: text/html;" + this.CRLF + ((mailMessage.Charset == "") ? " charset=\"iso-8859-1\"" : (" charset=\"" + mailMessage.Charset.ToLower() + "\"")) + this.CRLF + "Content-Transfer-Encoding: base64" + this.CRLF + this.CRLF + this.Base64Encode(mailMessage.Body) + this.CRLF + this.CRLF + "--=====003_Dragon520636771063_=====--" + this.CRLF;
            }
            else
            {
                if (mailMessage.Attachments.Count != 0)
                {
                    str = str + "--=====001_Dragon303406132050_=====" + this.CRLF;
                }
                str = str + "Content-Type: text/plain;" + this.CRLF + ((mailMessage.Charset == "") ? " charset=\"iso-8859-1\"" : (" charset=\"" + mailMessage.Charset.ToLower() + "\"")) + this.CRLF + "Content-Transfer-Encoding: base64" + this.CRLF + this.CRLF + this.Base64Encode(mailMessage.Body) + this.CRLF;
            }
            if (mailMessage.Attachments.Count != 0)
            {
                for (num = 0; num < mailMessage.Attachments.Count; num++)
                {
                    string filePath = mailMessage.Attachments[num];
                    str3 = str;
                    str3 = str3 + "--=====" + (flag ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====" + this.CRLF + "Content-Type: text/plain;" + this.CRLF;
                    str3 = str3 + " name=\"=?" + mailMessage.Charset.ToUpper() + "?B?" + this.Base64Encode(filePath.Substring(filePath.LastIndexOf(@"\") + 1)) + "?=\"" + this.CRLF + "Content-Transfer-Encoding: base64" + this.CRLF + "Content-Disposition: attachment;" + this.CRLF;
                    str = str3 + " filename=\"=?" + mailMessage.Charset.ToUpper() + "?B?" + this.Base64Encode(filePath.Substring(filePath.LastIndexOf(@"\") + 1)) + "?=\"" + this.CRLF + this.CRLF + this.GetStream(filePath) + this.CRLF + this.CRLF;
                }
                str3 = str;
                str = str3 + "--=====" + (flag ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====--" + this.CRLF + this.CRLF;
            }
            str = str + this.CRLF + "." + this.CRLF;
            if (!this.Dialog(str, "错误信件信息"))
            {
                return false;
            }
            str = "QUIT" + this.CRLF;
            if (!this.Dialog(str, "断开连接时错误"))
            {
                return false;
            }
            this.networkStream.Close();
            this.tcpClient.Close();
            return true;
        }

        private void SMTPCodeAdd()
        {
            this.ErrCodeHT.Add("421", "服务未就绪，关闭传输信道");
            this.ErrCodeHT.Add("432", "需要一个密码转换");
            this.ErrCodeHT.Add("450", "要求的邮件操作未完成，邮箱不可用（例如，邮箱忙）");
            this.ErrCodeHT.Add("451", "放弃要求的操作；处理过程中出错");
            this.ErrCodeHT.Add("452", "系统存储不足，要求的操作未执行");
            this.ErrCodeHT.Add("454", "临时认证失败");
            this.ErrCodeHT.Add("500", "邮箱地址错误");
            this.ErrCodeHT.Add("501", "参数格式错误");
            this.ErrCodeHT.Add("502", "命令不可实现");
            this.ErrCodeHT.Add("503", "服务器需要SMTP验证");
            this.ErrCodeHT.Add("504", "命令参数不可实现");
            this.ErrCodeHT.Add("530", "需要认证");
            this.ErrCodeHT.Add("534", "认证机制过于简单");
            this.ErrCodeHT.Add("538", "当前请求的认证机制需要加密");
            this.ErrCodeHT.Add("550", "要求的邮件操作未完成，邮箱不可用（例如，邮箱未找到，或不可访问）");
            this.ErrCodeHT.Add("551", "用户非本地，请尝试<forward-path>");
            this.ErrCodeHT.Add("552", "过量的存储分配，要求的操作未执行");
            this.ErrCodeHT.Add("553", "邮箱名不可用，要求的操作未执行（例如邮箱格式错误）");
            this.ErrCodeHT.Add("554", "传输失败");
            this.RightCodeHT.Add("220", "服务就绪");
            this.RightCodeHT.Add("221", "服务关闭传输信道");
            this.RightCodeHT.Add("235", "验证成功");
            this.RightCodeHT.Add("250", "要求的邮件操作完成");
            this.RightCodeHT.Add("251", "非本地用户，将转发向<forward-path>");
            this.RightCodeHT.Add("334", "服务器响应验证Base64字符串");
            this.RightCodeHT.Add("354", "开始邮件输入，以<CRLF>.<CRLF>结束");
        }
    }
}

