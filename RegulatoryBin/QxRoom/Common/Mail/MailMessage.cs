namespace QxRoom.Common.Mail
{
    using System;
    using System.Collections;

    public class MailMessage
    {
        private MailAttachments _Attachments = new MailAttachments();
        private string _Body;
        private MailFormat _BodyFormat;
        private string _Charset = "GB2312";
        private string _From;
        private string _FromName;
        private MailPriority _Priority = MailPriority.Normal;
        private IList _Recipients = new ArrayList();
        private string _Subject;
        private const int MaxRecipientNum = 10;

        public MailMessage()
        {
            this._Charset = "UTF-8";
        }

        public void AddRecipients(string recipient)
        {
            if (this._Recipients.Count < 10)
            {
                this._Recipients.Add(recipient);
            }
        }

        public void AddRecipients(params string[] recipient)
        {
            if (recipient == null)
            {
                throw new ArgumentException("收件人不能为空.");
            }
            for (int i = 0; i < recipient.Length; i++)
            {
                this.AddRecipients(recipient[i]);
            }
        }

        public MailAttachments Attachments
        {
            get
            {
                return this._Attachments;
            }
            set
            {
                this._Attachments = value;
            }
        }

        public string Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this._Body = value;
            }
        }

        public MailFormat BodyFormat
        {
            get
            {
                return this._BodyFormat;
            }
            set
            {
                this._BodyFormat = value;
            }
        }

        public string Charset
        {
            get
            {
                return this._Charset;
            }
            set
            {
                this._Charset = value;
            }
        }

        public string From
        {
            get
            {
                return this._From;
            }
            set
            {
                this._From = value;
            }
        }

        public string FromName
        {
            get
            {
                return this._FromName;
            }
            set
            {
                this._FromName = value;
            }
        }

        public MailPriority Priority
        {
            get
            {
                return this._Priority;
            }
            set
            {
                this._Priority = value;
            }
        }

        public IList Recipients
        {
            get
            {
                return this._Recipients;
            }
        }

        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }
    }
}

