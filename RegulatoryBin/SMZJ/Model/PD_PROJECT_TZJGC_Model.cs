namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_TZJGC_Model
    {
        private string _id = "-1";
        private decimal? _pd_base_tzjgc;
        private string _pd_project_code;
        private decimal? _pd_project_money_cz_sj;
        private string _tb_quota_code;
        private string _tb_quota_zbwh;

        public string ID
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

        public decimal? PD_BASE_TZJGC
        {
            get
            {
                return this._pd_base_tzjgc;
            }
            set
            {
                this._pd_base_tzjgc = value;
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

        public decimal? PD_PROJECT_MONEY_CZ_SJ
        {
            get
            {
                return this._pd_project_money_cz_sj;
            }
            set
            {
                this._pd_project_money_cz_sj = value;
            }
        }

        public string TB_QUOTA_CODE
        {
            get
            {
                return this._tb_quota_code;
            }
            set
            {
                this._tb_quota_code = value;
            }
        }

        public string TB_QUOTA_ZBWH
        {
            get
            {
                return this._tb_quota_zbwh;
            }
            set
            {
                this._tb_quota_zbwh = value;
            }
        }
    }
}

