using System.Configuration;

namespace BHSoft.BHWeb.Common.Mail
{
    using BHSoft.BHWeb.Common;
    using BHSoft.BHWeb.Common.CommonClasses;
    using jmail;
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Threading;

    public class SendMail
    {
        private static Hashtable Cmn_Message;
        private static ArrayList mailArray = new ArrayList();
        private static string mailServer = "";
        private static string strEMailPath = ConfigurationManager.AppSettings["EMailFilePath"];
        private static readonly object syncRoot = new object();

        private static string GetEMailBody(string fileName)
        {
            string str = "";
            try
            {
                StreamReader reader = null;
                if (Cmn_Message == null)
                {
                    Cmn_Message = new Hashtable();
                    reader = new StreamReader(CommonUtil.GetWebPath() + strEMailPath + "EMail_Cmn_Fooder.emp", Encoding.GetEncoding("GB2312"));
                    Cmn_Message.Add("EMail_Cmn_Fooder", reader.ReadToEnd());
                    reader.Close();
                    reader = new StreamReader(CommonUtil.GetWebPath() + strEMailPath + "EMail_Cmn_Header.emp", Encoding.GetEncoding("GB2312"));
                    Cmn_Message.Add("EMail_Cmn_Header", reader.ReadToEnd());
                    reader.Close();
                    reader = new StreamReader(CommonUtil.GetWebPath() + strEMailPath + "EMail_Cmn_In_Fooder.emp", Encoding.GetEncoding("GB2312"));
                    Cmn_Message.Add("EMail_Cmn_In_Fooder", reader.ReadToEnd());
                    reader.Close();
                    reader = new StreamReader(CommonUtil.GetWebPath() + strEMailPath + "EMail_Cmn_In_Header.emp", Encoding.GetEncoding("GB2312"));
                    Cmn_Message.Add("EMail_Cmn_In_Header", reader.ReadToEnd());
                    reader.Close();
                }
                reader = new StreamReader(CommonUtil.GetWebPath() + strEMailPath + fileName, Encoding.GetEncoding("GB2312"));
                str = reader.ReadToEnd();
                reader.Close();
                str = str.Replace("<$EMail_Cmn_Fooder>", Cmn_Message["EMail_Cmn_Fooder"].ToString());
                str = str.Replace("<$EMail_Cmn_Header>", Cmn_Message["EMail_Cmn_Header"].ToString());
                str = str.Replace("<$EMail_Cmn_In_Fooder>", Cmn_Message["EMail_Cmn_In_Fooder"].ToString());
                str = str.Replace("<$EMail_Cmn_In_Header>", Cmn_Message["EMail_Cmn_In_Header"].ToString());
            }
            catch (Exception exception)
            {
                log.ErrorLog(exception);
            }
            return str;
        }

        private static MessageClass GetMailClass()
        {
            MessageClass class2 = new MessageClass {
                Logging = false,
                Silent = false,
                Charset = "GB2312",
                ContentType = "text/html",
                Encoding = "base64",
                ContentTransferEncoding = "base64",
                Priority = 3,
                FromName = "栀子花开鲜花礼品网"
            };
            class2.AddNativeHeader("Message-ID", Guid.NewGuid().ToString());
            class2.AddHeader("Originating-IP", "222.77.178.219");
            class2.AddHeader("Mailer", "Jmail send of Hailsoft Inc.");
            class2.AddHeader("Company", "Hailsoft.Inc.");
            return class2;
        }

        private static void Run()
        {
            new Thread(new ThreadStart(SendMail.Send)).Start();
        }

        private static void Send()
        {
            lock (syncRoot)
            {
                int num = 0;
                log.DebugLog("================ Mail Send Start ==================");
                while (mailArray.Count != 0)
                {
                    Exception exception;
                    bool flag = false;
                    MessageClass class2 = (MessageClass) mailArray[0];
                    try
                    {
                        log.DebugLog("直接发送Email.邮件地址：" + class2.Recipients[0].EMail.ToString() + "邮件标题：" + class2.Subject);
                        flag = class2.Send(null, false);
                        log.DebugLog("邮件发送完成。邮件地址：" + class2.Recipients[0].EMail.ToString() + "邮件标题：" + class2.Subject);
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        log.ErrorLog(exception);
                        flag = false;
                    }
                    try
                    {
                        try
                        {
                            if (!flag)
                            {
                                log.DebugLog("使用SMTP服务发送Email." + mailServer);
                                flag = class2.Send(mailServer, false);
                            }
                        }
                        catch (Exception exception3)
                        {
                            exception = exception3;
                            log.ErrorLog(exception);
                            flag = false;
                        }
                        continue;
                    }
                    finally
                    {
                        if (flag || (num > 5))
                        {
                            class2.Close();
                            mailArray.RemoveAt(0);
                            num = 0;
                        }
                        else
                        {
                            num++;
                            Thread.Sleep(0x2710);
                        }
                    }
                }
                log.DebugLog("================ Mail Send End ==================");
                Thread.CurrentThread.Abort();
            }
        }

        public static bool Send(string mail, string strTitle, string strMessage, string strFileName)
        {
            try
            {
                MessageClass mailClass = GetMailClass();
                mailClass.Subject = "[栀子花开]" + strTitle;
                mailClass.HTMLBody = strMessage + "\n冰软科技有限公司邮件自动发送, 版权所有。";
                mailClass.AddRecipient(mail, mail, null);
                mailClass.AddAttachment(strFileName, true, "image/jpg");
                mailArray.Add(mailClass);
                Run();
                return true;
            }
            catch (Exception exception)
            {
                log.ErrorLog(exception.Message);
                return false;
            }
        }
    }
}

