namespace QxRoom.QxFunctionLog
{
    using System;

    public sealed class QxClassErrLog : IDisposable
    {
        private string errclass;
        private string errcontent;
        private string methodname;

        public QxClassErrLog()
        {
            this.MethodName = "";
            this.ErrContent = "";
            this.ErrClass = "";
        }

        public void Dispose()
        {
        }

        ~QxClassErrLog()
        {
            this.Dispose();
        }

        public void WriteLog()
        {
        }

        public string ErrClass
        {
            get
            {
                return this.errclass;
            }
            set
            {
                this.errclass = value;
            }
        }

        public string ErrContent
        {
            get
            {
                return this.errcontent;
            }
            set
            {
                this.errcontent = value;
            }
        }

        public string MethodName
        {
            get
            {
                return this.methodname;
            }
            set
            {
                this.methodname = value;
            }
        }
    }
}

