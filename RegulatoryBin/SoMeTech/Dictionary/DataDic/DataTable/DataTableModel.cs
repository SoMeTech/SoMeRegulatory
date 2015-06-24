namespace SoMeTech.Dictionary.DataDic.DataTable
{
    using System;

    public sealed class DataTableModel
    {
        private string _pk;
        private string _remark;
        private string _tablename;
        private string _tableremark;

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

        public string TABLENAME
        {
            get
            {
                return this._tablename;
            }
            set
            {
                this._tablename = value;
            }
        }

        public string TABLEREMARK
        {
            get
            {
                return this._tableremark;
            }
            set
            {
                this._tableremark = value;
            }
        }
    }
}

