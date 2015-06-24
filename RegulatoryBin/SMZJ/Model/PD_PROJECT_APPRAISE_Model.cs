namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_APPRAISE_Model
    {
        private int _auto_no = -1;
        private string _pd_project_app_company;
        private string _pd_project_app_company_list;
        private DateTime? _pd_project_app_date;
        private string _pd_project_app_man_list;
        private string _pd_project_appraise_fileno;
        private string _pd_project_code;

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

        public string PD_PROJECT_APP_COMPANY
        {
            get
            {
                return this._pd_project_app_company;
            }
            set
            {
                this._pd_project_app_company = value;
            }
        }

        public string PD_PROJECT_APP_COMPANY_LIST
        {
            get
            {
                return this._pd_project_app_company_list;
            }
            set
            {
                this._pd_project_app_company_list = value;
            }
        }

        public DateTime? PD_PROJECT_APP_DATE
        {
            get
            {
                return this._pd_project_app_date;
            }
            set
            {
                this._pd_project_app_date = value;
            }
        }

        public string PD_PROJECT_APP_MAN_LIST
        {
            get
            {
                return this._pd_project_app_man_list;
            }
            set
            {
                this._pd_project_app_man_list = value;
            }
        }

        public string PD_PROJECT_APPRAISE_FILENO
        {
            get
            {
                return this._pd_project_appraise_fileno;
            }
            set
            {
                this._pd_project_appraise_fileno = value;
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
    }
}

