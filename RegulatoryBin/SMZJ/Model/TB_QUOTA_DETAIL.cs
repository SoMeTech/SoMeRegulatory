namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class TB_QUOTA_DETAIL
    {
        private decimal _auto_no;
        private string _company_code;
        private string _company_name;
        private string _file_name;
        private string _file_sysname;
        private string _file_type;
        private string _huizhi_man;
        private string _if_show = "1";
        private string _ishuizhi;
        private string _isreceive = "0";
        private string _pd_quota_code;
        private string _pd_quota_serverpk;
        private string _pd_up_money;
        private string _receive_man;

        public decimal AUTO_NO
        {
            get
            {
                return this._auto_no;
            }
            set
            {
                this._auto_no = value;
            }
        }

        public string COMPANY_CODE
        {
            get
            {
                return this._company_code;
            }
            set
            {
                this._company_code = value;
            }
        }

        public string COMPANY_NAME
        {
            get
            {
                return this._company_name;
            }
            set
            {
                this._company_name = value;
            }
        }

        public string FILE_NAME
        {
            get
            {
                return this._file_name;
            }
            set
            {
                this._file_name = value;
            }
        }

        public string FILE_SYSNAME
        {
            get
            {
                return this._file_sysname;
            }
            set
            {
                this._file_sysname = value;
            }
        }

        public string FILE_TYPE
        {
            get
            {
                return this._file_type;
            }
            set
            {
                this._file_type = value;
            }
        }

        public string HUIZHI_MAN
        {
            get
            {
                return this._huizhi_man;
            }
            set
            {
                this._huizhi_man = value;
            }
        }

        public string IF_SHOW
        {
            get
            {
                return this._if_show;
            }
            set
            {
                this._if_show = value;
            }
        }

        public string ISHUIZHI
        {
            get
            {
                return this._ishuizhi;
            }
            set
            {
                this._ishuizhi = value;
            }
        }

        public string ISRECEIVE
        {
            get
            {
                return this._isreceive;
            }
            set
            {
                this._isreceive = value;
            }
        }

        public string PD_QUOTA_CODE
        {
            get
            {
                return this._pd_quota_code;
            }
            set
            {
                this._pd_quota_code = value;
            }
        }

        public string PD_QUOTA_SERVERPK
        {
            get
            {
                return this._pd_quota_serverpk;
            }
            set
            {
                this._pd_quota_serverpk = value;
            }
        }

        public string PD_UP_MONEY
        {
            get
            {
                return this._pd_up_money;
            }
            set
            {
                this._pd_up_money = value;
            }
        }

        public string RECEIVE_MAN
        {
            get
            {
                return this._receive_man;
            }
            set
            {
                this._receive_man = value;
            }
        }
    }
}

