namespace SoMeTech.Dictionary.LDJGXZ
{
    using System;

    public sealed class LDJGModel
    {
        private decimal? _fzfdefvalue = 0;
        private decimal? _fzfmaxvalue = 0;
        private decimal? _fzfminvalue = 0;
        private string _ldmc;
        private string _ldpk;
        private string _pk;
        private string _QYFW;
        private string _tbh;
        private string _tname;
        private string _tpk;
        private string _Type;
        private decimal? _zfdefvalue = 0;
        private decimal? _zfmaxvalue = 0;
        private decimal? _zfminvalue = 0;
        private string tablename = "";

        public decimal? FZFDefValue
        {
            get
            {
                return this._fzfdefvalue;
            }
            set
            {
                this._fzfdefvalue = value;
            }
        }

        public decimal? FZFMaxValue
        {
            get
            {
                return this._fzfmaxvalue;
            }
            set
            {
                this._fzfmaxvalue = value;
            }
        }

        public decimal? FZFMinValue
        {
            get
            {
                return this._fzfminvalue;
            }
            set
            {
                this._fzfminvalue = value;
            }
        }

        public string LDMC
        {
            get
            {
                return this._ldmc;
            }
            set
            {
                this._ldmc = value;
            }
        }

        public string LDPK
        {
            get
            {
                return this._ldpk;
            }
            set
            {
                this._ldpk = value;
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

        public string QYFW
        {
            get
            {
                return this._QYFW;
            }
            set
            {
                this._QYFW = value;
            }
        }

        public string TableName
        {
            get
            {
                return this.tablename;
            }
            set
            {
                this.tablename = value;
            }
        }

        public string TBH
        {
            get
            {
                return this._tbh;
            }
            set
            {
                this._tbh = value;
            }
        }

        public string TNAME
        {
            get
            {
                return this._tname;
            }
            set
            {
                this._tname = value;
            }
        }

        public string TPK
        {
            get
            {
                return this._tpk;
            }
            set
            {
                this._tpk = value;
            }
        }

        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }

        public decimal? ZFDefValue
        {
            get
            {
                return this._zfdefvalue;
            }
            set
            {
                this._zfdefvalue = value;
            }
        }

        public decimal? ZFMaxValue
        {
            get
            {
                return this._zfmaxvalue;
            }
            set
            {
                this._zfmaxvalue = value;
            }
        }

        public decimal? ZFMinValue
        {
            get
            {
                return this._zfminvalue;
            }
            set
            {
                this._zfminvalue = value;
            }
        }
    }
}

