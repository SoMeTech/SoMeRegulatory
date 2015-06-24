namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_BASE_KAOPINGTYPEDETAIL_Model
    {
        private int? _auto_id;
        private string _iscomfirm;
        private int? _kp_basecode;
        private string _kp_biaozhun;
        private string _kp_content;
        private int? _kp_typeid;
        private string _kp_year;
        private string _typename;

        public int? AUTO_ID
        {
            get
            {
                return this._auto_id;
            }
            set
            {
                this._auto_id = value;
            }
        }

        public string ISCOMFIRM
        {
            get
            {
                return this._iscomfirm;
            }
            set
            {
                this._iscomfirm = value;
            }
        }

        public int? KP_BASECODE
        {
            get
            {
                return this._kp_basecode;
            }
            set
            {
                this._kp_basecode = value;
            }
        }

        public string KP_BIAOZHUN
        {
            get
            {
                return this._kp_biaozhun;
            }
            set
            {
                this._kp_biaozhun = value;
            }
        }

        public string KP_CONTENT
        {
            get
            {
                return this._kp_content;
            }
            set
            {
                this._kp_content = value;
            }
        }

        public int? KP_TYPEID
        {
            get
            {
                return this._kp_typeid;
            }
            set
            {
                this._kp_typeid = value;
            }
        }

        public string KP_YEAR
        {
            get
            {
                return this._kp_year;
            }
            set
            {
                this._kp_year = value;
            }
        }

        public string typename
        {
            get
            {
                return this._typename;
            }
            set
            {
                this._typename = value;
            }
        }
    }
}

