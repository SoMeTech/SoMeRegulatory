namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class GOV_TC_DB_COMPANYDATADZ_Model
    {
        private string _columnname = "";
        private string _companybh = "";
        private string _companyname = "";
        private string _dataname = "";
        private string _ip = ".";
        private long _pk;
        private string _pwd = "";
        private string _showname = "";
        private string _tablename = "";
        private string _userid = "";

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

        public string COMPANYBH
        {
            get
            {
                return this._companybh;
            }
            set
            {
                this._companybh = value;
            }
        }

        public string COMPANYNAME
        {
            get
            {
                return this._companyname;
            }
            set
            {
                this._companyname = value;
            }
        }

        public string DATANAME
        {
            get
            {
                return this._dataname;
            }
            set
            {
                this._dataname = value;
            }
        }

        public string IP
        {
            get
            {
                return this._ip;
            }
            set
            {
                this._ip = value;
            }
        }

        public long PK
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

        public string PWD
        {
            get
            {
                return this._pwd;
            }
            set
            {
                this._pwd = value;
            }
        }

        public string SHOWNAME
        {
            get
            {
                return this._showname;
            }
            set
            {
                this._showname = value;
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

        public string USERID
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }
    }
}

