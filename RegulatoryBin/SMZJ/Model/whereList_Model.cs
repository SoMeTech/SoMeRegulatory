namespace SMZJ.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class whereList_Model
    {
        private decimal _id;
        private decimal? _reportparampk = 0M;
        private string _columnname;
        private string _columntype;
        private decimal? _isbinddate = 0M;
        private string _datetype;
        private decimal? _isqujian = 0M;
        private decimal? _isprocparam = 0M;
        private decimal? _islike = 0M;
        private string _isshow;
        private decimal? _isgetdata = 0M;
        private string _showtablename;
        private string _showcolumn;

        public string columnName
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

        public string columnType
        {
            get
            {
                return this._columntype;
            }
            set
            {
                this._columntype = value;
            }
        }

        public string DateType
        {
            get
            {
                return this._datetype;
            }
            set
            {
                this._datetype = value;
            }
        }

        public decimal id
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

        public decimal? IsBindDate
        {
            get
            {
                return this._isbinddate;
            }
            set
            {
                this._isbinddate = value;
            }
        }

        public decimal? IsGetData
        {
            get
            {
                return this._isgetdata;
            }
            set
            {
                this._isgetdata = value;
            }
        }

        public decimal? IsLike
        {
            get
            {
                return this._islike;
            }
            set
            {
                this._islike = value;
            }
        }

        public decimal? IsProcParam
        {
            get
            {
                return this._isprocparam;
            }
            set
            {
                this._isprocparam = value;
            }
        }

        public decimal? IsQuJian
        {
            get
            {
                return this._isqujian;
            }
            set
            {
                this._isqujian = value;
            }
        }

        public string IsShow
        {
            get
            {
                return this._isshow;
            }
            set
            {
                this._isshow = value;
            }
        }

        public decimal? reportParamPK
        {
            get
            {
                return this._reportparampk;
            }
            set
            {
                this._reportparampk = value;
            }
        }

        public string ShowColumn
        {
            get
            {
                return this._showcolumn;
            }
            set
            {
                this._showcolumn = value;
            }
        }

        public string ShowTableName
        {
            get
            {
                return this._showtablename;
            }
            set
            {
                this._showtablename = value;
            }
        }

        public string ShowWhere { get; set; }
    }
}

