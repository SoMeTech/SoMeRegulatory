namespace BHSoft.BHWeb.Common
{
    using BHSoft.BHWeb.Common.Mail;
    using System;

    public class mySendMail
    {
        public static bool mySendMailc1(string SmtpServer, string FromEmail, string FromUserName, string ToEmail, string Subject, string BodyFormat, string BodyContent, string AttachmentFilePath, string Password)
        {
            SmtpMail.SmtpServer = SmtpServer;
            MailMessage mailMessage = new MailMessage {
                From = FromEmail,
                FromName = FromUserName
            };
            mailMessage.AddRecipients(ToEmail);
            mailMessage.Subject = Subject;
            if (BodyFormat == "Text")
            {
                mailMessage.BodyFormat = MailFormat.Text;
            }
            else
            {
                mailMessage.BodyFormat = MailFormat.HTML;
            }
            mailMessage.Body = BodyContent;
            if ((AttachmentFilePath != "") && (AttachmentFilePath != null))
            {
                mailMessage.Attachments.Add(AttachmentFilePath);
            }
            return SmtpMail.Send(mailMessage, FromEmail.Substring(0, FromEmail.LastIndexOf("@")), Password);
        }
    }
}

