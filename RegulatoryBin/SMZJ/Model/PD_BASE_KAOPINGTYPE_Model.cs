namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_BASE_KAOPINGTYPE_Model
    {
        private int? _auto_id = 0;
        private string _iscomfirm;
        private string _khtypename;
        private int? _khtypeper = 0;
        private string _khyear;
        private int? _orderid = 0;
        private string _remark;

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

        public string KHTYPENAME
        {
            get
            {
                return this._khtypename;
            }
            set
            {
                this._khtypename = value;
            }
        }

        public int? KHTYPEPER
        {
            get
            {
                return this._khtypeper;
            }
            set
            {
                this._khtypeper = value;
            }
        }

        public string KHYEAR
        {
            get
            {
                return this._khyear;
            }
            set
            {
                this._khyear = value;
            }
        }

        public int? ORDERID
        {
            get
            {
                return this._orderid;
            }
            set
            {
                this._orderid = value;
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
    }
}

