namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_ZTB_Model
    {
        private string _auto_no;
        private string _pd_project_code = "";
        private string _pd_project_fcxmgcl = "";
        private string _pd_project_gczlqk = "";
        private string _pd_project_iscontract = "";
        private string _pd_project_xxjd = "";
        private string _pd_project_ztb_file = "";
        private string _pd_project_ztb_file_system = "";
        private int? _pd_project_ztb_if_ssfa = 0;
        private int? _pd_project_ztb_if_wcfb = 0;
        private int? _pd_project_ztb_if_ztb = 0;
        private string _pd_project_ztb_style = "";

        public string AUTO_NO
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

        public string PD_PROJECT_FCXMGCL
        {
            get
            {
                return this._pd_project_fcxmgcl;
            }
            set
            {
                this._pd_project_fcxmgcl = value;
            }
        }

        public string PD_PROJECT_GCZLQK
        {
            get
            {
                return this._pd_project_gczlqk;
            }
            set
            {
                this._pd_project_gczlqk = value;
            }
        }

        public string PD_PROJECT_ISCONTRACT
        {
            get
            {
                return this._pd_project_iscontract;
            }
            set
            {
                this._pd_project_iscontract = value;
            }
        }

        public string PD_PROJECT_XXJD
        {
            get
            {
                return this._pd_project_xxjd;
            }
            set
            {
                this._pd_project_xxjd = value;
            }
        }

        public string PD_PROJECT_ZTB_FILE
        {
            get
            {
                return this._pd_project_ztb_file;
            }
            set
            {
                this._pd_project_ztb_file = value;
            }
        }

        public string PD_PROJECT_ZTB_FILE_SYSTEM
        {
            get
            {
                return this._pd_project_ztb_file_system;
            }
            set
            {
                this._pd_project_ztb_file_system = value;
            }
        }

        public int? PD_PROJECT_ZTB_IF_SSFA
        {
            get
            {
                return this._pd_project_ztb_if_ssfa;
            }
            set
            {
                this._pd_project_ztb_if_ssfa = value;
            }
        }

        public int? PD_PROJECT_ZTB_IF_WCFB
        {
            get
            {
                return this._pd_project_ztb_if_wcfb;
            }
            set
            {
                this._pd_project_ztb_if_wcfb = value;
            }
        }

        public int? PD_PROJECT_ZTB_IF_ZTB
        {
            get
            {
                return this._pd_project_ztb_if_ztb;
            }
            set
            {
                this._pd_project_ztb_if_ztb = value;
            }
        }

        public string PD_PROJECT_ZTB_STYLE
        {
            get
            {
                return this._pd_project_ztb_style;
            }
            set
            {
                this._pd_project_ztb_style = value;
            }
        }
    }
}

