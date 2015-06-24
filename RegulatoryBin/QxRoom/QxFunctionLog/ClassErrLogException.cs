namespace QxRoom.QxFunctionLog
{
    using System;
    using System.Collections;

    [Serializable]
    public class ClassErrLogException : Exception
    {
        private string msg;

        public ClassErrLogException()
        {
            this.msg = null;
        }

        public ClassErrLogException(string vmsg) : base(vmsg)
        {
            this.msg = vmsg;
        }

        public ClassErrLogException(string vmsg, Exception vexcption) : base(vmsg, vexcption)
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

