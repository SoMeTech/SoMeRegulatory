namespace QxRoom.QxExcel
{
    using System;
    using System.Collections;

    public class ExcelException : Exception
    {
        private string msg;

        public ExcelException()
        {
            this.msg = null;
        }

        public ExcelException(string vmsg) : base(vmsg)
        {
            this.msg = vmsg;
        }

        public ExcelException(string vmsg, Exception vexcption) : base(vmsg, vexcption)
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

