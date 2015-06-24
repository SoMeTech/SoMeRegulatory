namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class TB_QUOTA_DETAIL_TMP
    {
        private int _auto_no;
        private string _company_code;
        private string _company_name;
        private string _file_name;
        private string _file_sysname;
        private string _file_type;
        private string _pd_quota_code;

        public int AUTO_NO
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
    }
}

