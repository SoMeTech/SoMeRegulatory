namespace SoMeTech.Dictionary.DataDic.DataColumn
{
    using System;

    public sealed class DataColumnModel
    {
        private string _columnname;
        private string _columnremark;
        private string _pk;
        private string _remark;
        private string _tablepk;

        public string COLUMNNAME
        {
            get
            {
                return this._columnname;
            }
            set
            {
                this._columnname = value;
            }
        }

        public string COLUMNREMARK
        {
            get
            {
                return this._columnremark;
            }
            set
            {
                this._columnremark = value;
            }
        }

        public string PK
        {
            get
            {
                return this._pk;
            }
            set
            {
                this._pk = value;
            }
        }

        public string REMARK
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        public string TABLEPK
        {
            get
            {
                return this._tablepk;
            }
            set
            {
                this._tablepk = value;
            }
        }
    }
}

