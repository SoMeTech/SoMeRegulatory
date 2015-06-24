namespace QxRoom.Common
{
    using System;
    using System.Collections;

    public class CommonException : Exception
    {
        private string msg;

        public CommonException()
        {
            this.msg = null;
        }

        public CommonException(string vmsg) : base(vmsg)
        {
            this.msg = vmsg;
        }

        public CommonException(string vmsg, Exception vexcption) : base(vmsg, vexcption)
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

