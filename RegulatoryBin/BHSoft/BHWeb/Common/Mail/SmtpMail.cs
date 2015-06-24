namespace BHSoft.BHWeb.Common.Mail
{
    using BHSoft.BHWeb.Common.CommonClasses;
    using System;

    public class SmtpMail
    {
        private static string _SmtpServer;

        public static bool Send(MailMessage mailMessage, string username, string password)
        {
            SmtpServerHelper helper = new SmtpServerHelper();
            return helper.SendEmail(_SmtpServer, 0x19, username, password, mailMessage);
        }

        public static bool Send(MailMessage mailMessage, int port, string username, string password)
        {
            SmtpServerHelper helper = new SmtpServerHelper();
            log.TraceLog("port: " + port.ToString());
            return helper.SendEmail(_SmtpServer, port, username, password, mailMessage);
        }

        public static string SmtpServer
        {
            get
            {
                return _SmtpServer;
            }
            set
            {
                _SmtpServer = value;
            }
        }
    }
}

