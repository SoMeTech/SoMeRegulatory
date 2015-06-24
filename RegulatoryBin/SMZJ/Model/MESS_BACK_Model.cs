namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class MESS_BACK_Model
    {
        private string _mes_company;
        private DateTime? _mes_date;
        private string _mes_dept;
        private string _mes_flag;
        private string _mes_id;
        private string _mes_jianyi;
        private string _mes_kunan;
        private string _mes_man;
        private string _mes_pz;
        private string _mes_shcompany;
        private DateTime? _mes_shdate;
        private string _mes_shdept;
        private string _mes_shman;
        private string _mes_title;
        private string _mes_xzyj;
        private string _pd_now_serverpk;
        private string _pd_project_code;
        private string _pd_project_name;
        private string _pd_quota_depart;
        private string _pd_year;

        public string MES_COMPANY
        {
            get
            {
                return this._mes_company;
            }
            set
            {
                this._mes_company = value;
            }
        }

        public string MES_COMPANY_NAME { get; set; }

        public DateTime? MES_DATE
        {
            get
            {
                return this._mes_date;
            }
            set
            {
                this._mes_date = value;
            }
        }

        public string MES_DEPT
        {
            get
            {
                return this._mes_dept;
            }
            set
            {
                this._mes_dept = value;
            }
        }

        public string MES_FLAG
        {
            get
            {
                return this._mes_flag;
            }
            set
            {
                this._mes_flag = value;
            }
        }

        public string MES_ID
        {
            get
            {
                return this._mes_id;
            }
            set
            {
                this._mes_id = value;
            }
        }

        public string MES_JIANYI
        {
            get
            {
                return this._mes_jianyi;
            }
            set
            {
                this._mes_jianyi = value;
            }
        }

        public string MES_KUNAN
        {
            get
            {
                return this._mes_kunan;
            }
            set
            {
                this._mes_kunan = value;
            }
        }

        public string MES_MAN
        {
            get
            {
                return this._mes_man;
            }
            set
            {
                this._mes_man = value;
            }
        }

        public string MES_PZ
        {
            get
            {
                return this._mes_pz;
            }
            set
            {
                this._mes_pz = value;
            }
        }

        public string MES_SHCOMPANY
        {
            get
            {
                return this._mes_shcompany;
            }
            set
            {
                this._mes_shcompany = value;
            }
        }

        public DateTime? MES_SHDATE
        {
            get
            {
                return this._mes_shdate;
            }
            set
            {
                this._mes_shdate = value;
            }
        }

        public string MES_SHDEPT
        {
            get
            {
                return this._mes_shdept;
            }
            set
            {
                this._mes_shdept = value;
            }
        }

        public string MES_SHMAN
        {
            get
            {
                return this._mes_shman;
            }
            set
            {
                this._mes_shman = value;
            }
        }

        public string MES_TITLE
        {
            get
            {
                return this._mes_title;
            }
            set
            {
                this._mes_title = value;
            }
        }

        public string MES_XCJYJ { get; set; }

        public string MES_XZYJ
        {
            get
            {
                return this._mes_xzyj;
            }
            set
            {
                this._mes_xzyj = value;
            }
        }

        public string MES_YWGSYJ { get; set; }

        public string PD_BASE_FKLX { get; set; }

        public string PD_NOW_SERVERPK
        {
            get
            {
                return this._pd_now_serverpk;
            }
            set
            {
                this._pd_now_serverpk = value;
            }
        }

        public string PD_PROJECT_CODE
        {
            get
            {
                return this._pd_project_code;
            }
            set
            {
                this._pd_project_code = value;
            }
        }

        public string PD_PROJECT_NAME
        {
            get
            {
                return this._pd_project_name;
            }
            set
            {
                this._pd_project_name = value;
            }
        }

        public string PD_QUOTA_DEPART
        {
            get
            {
                return this._pd_quota_depart;
            }
            set
            {
                this._pd_quota_depart = value;
            }
        }

        public string PD_YEAR
        {
            get
            {
                return this._pd_year;
            }
            set
            {
                this._pd_year = value;
            }
        }
    }

}