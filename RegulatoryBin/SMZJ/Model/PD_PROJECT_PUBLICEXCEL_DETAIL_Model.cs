namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_PUBLICEXCEL_DETAIL_Model
    {
        private string _column_cname;
        private string _column_ename;
        private string _defaultdata;
        private string _getsysname;
        private decimal _id;
        private string _isdefaulttype;
        private string _isprimary = "0";
        private decimal? _pid;
        private string _table_cname;
        private string _table_ename;

        public string COLUMN_CNAME
        {
            get
            {
                return this._column_cname;
            }
            set
            {
                this._column_cname = value;
            }
        }

        public string COLUMN_ENAME
        {
            get
            {
                return this._column_ename;
            }
            set
            {
                this._column_ename = value;
            }
        }

        public string DEFAULTDATA
        {
            get
            {
                return this._defaultdata;
            }
            set
            {
                this._defaultdata = value;
            }
        }

        public string GETSYSNAME
        {
            get
            {
                return this._getsysname;
            }
            set
            {
                this._getsysname = value;
            }
        }

        public decimal ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string ISDEFAULTTYPE
        {
            get
            {
                return this._isdefaulttype;
            }
            set
            {
                this._isdefaulttype = value;
            }
        }

        public string ISPRIMARY
        {
            get
            {
                return this._isprimary;
            }
            set
            {
                this._isprimary = value;
            }
        }

        public decimal? PID
        {
            get
            {
                return this._pid;
            }
            set
            {
                this._pid = value;
            }
        }

        public string TABLE_CNAME
        {
            get
            {
                return this._table_cname;
            }
            set
            {
                this._table_cname = value;
            }
        }

        public string TABLE_ENAME
        {
            get
            {
                return this._table_ename;
            }
            set
            {
                this._table_ename = value;
            }
        }
    }
}

