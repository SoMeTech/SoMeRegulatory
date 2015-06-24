namespace QxRoom.QxFunctionLog
{
    using System;
    using System.Collections;

    [Serializable]
    public class LogException : Exception
    {
        private string msg;

        public LogException()
        {
            this.msg = null;
        }

        public LogException(string vmsg) : base(vmsg)
        {
            this.msg = vmsg;
        }

        public LogException(string vmsg, Exception vexcption) : base(vmsg, vexcption)
        {
            this.msg = vmsg;
        }

        public override string ToString()
        {
            return this.msg;
        }

        public override IDictionary Data
        {
            get
            {
                return base.Data;
            }
        }
    }
}

