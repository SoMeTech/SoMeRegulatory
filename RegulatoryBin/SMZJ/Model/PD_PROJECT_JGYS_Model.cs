namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_JGYS_Model
    {
        private int _auto_no;
        private string _pd_project_code;
        private DateTime? _pd_project_complete_date;
        private string _pd_project_ys_company;
        private string _pd_project_ys_condition;
        private DateTime? _pd_project_ys_date;
        private string _pd_project_ys_name;
        private string _pd_project_ys_result;
        private string _pd_project_ys_suggest;
        private string _pd_project_ys_zrr;
        private DateTime? _pd_project_yssq_date;

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

        public DateTime? PD_PROJECT_COMPLETE_DATE
        {
            get
            {
                return this._pd_project_complete_date;
            }
            set
            {
                this._pd_project_complete_date = value;
            }
        }

        public string PD_PROJECT_YS_COMPANY
        {
            get
            {
                return this._pd_project_ys_company;
            }
            set
            {
                this._pd_project_ys_company = value;
            }
        }

        public string PD_PROJECT_YS_CONDITION
        {
            get
            {
                return this._pd_project_ys_condition;
            }
            set
            {
                this._pd_project_ys_condition = value;
            }
        }

        public DateTime? PD_PROJECT_YS_DATE
        {
            get
            {
                return this._pd_project_ys_date;
            }
            set
            {
                this._pd_project_ys_date = value;
            }
        }

        public string PD_PROJECT_YS_NAME
        {
            get
            {
                return this._pd_project_ys_name;
            }
            set
            {
                this._pd_project_ys_name = value;
            }
        }

        public string PD_PROJECT_YS_RESULT
        {
            get
            {
                return this._pd_project_ys_result;
            }
            set
            {
                this._pd_project_ys_result = value;
            }
        }

        public string PD_PROJECT_YS_SUGGEST
        {
            get
            {
                return this._pd_project_ys_suggest;
            }
            set
            {
                this._pd_project_ys_suggest = value;
            }
        }

        public string PD_PROJECT_YS_ZRR
        {
            get
            {
                return this._pd_project_ys_zrr;
            }
            set
            {
                this._pd_project_ys_zrr = value;
            }
        }

        public DateTime? PD_PROJECT_YSSQ_DATE
        {
            get
            {
                return this._pd_project_yssq_date;
            }
            set
            {
                this._pd_project_yssq_date = value;
            }
        }
    }
}

