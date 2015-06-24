namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_KAOPING_Model
    {
        private int? _auto_id;
        private string _kh_type;
        private string _kp_companypk;
        private int? _kp_detailid;
        private int? _kp_score;
        private int? _kp_typeid;
        private string _kp_year;

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

        public string KH_TYPE
        {
            get
            {
                return this._kh_type;
            }
            set
            {
                this._kh_type = value;
            }
        }

        public string KP_COMPANYPK
        {
            get
            {
                return this._kp_companypk;
            }
            set
            {
                this._kp_companypk = value;
            }
        }

        public int? KP_DETAILID
        {
            get
            {
                return this._kp_detailid;
            }
            set
            {
                this._kp_detailid = value;
            }
        }

        public int? KP_SCORE
        {
            get
            {
                return this._kp_score;
            }
            set
            {
                this._kp_score = value;
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
    }
}

