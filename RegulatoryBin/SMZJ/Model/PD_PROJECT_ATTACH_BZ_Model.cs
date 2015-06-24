namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_ATTACH_BZ_Model
    {
        private string _auto_no;
        private string _pd_project_attach_name = "";
        private string _pd_project_attach_name_system = "";
        private string _pd_project_attach_type = "";
        private string _pd_project_code;

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

        public string PD_PROJECT_ATTACH_NAME
        {
            get
            {
                return this._pd_project_attach_name;
            }
            set
            {
                this._pd_project_attach_name = value;
            }
        }

        public string PD_PROJECT_ATTACH_NAME_SYSTEM
        {
            get
            {
                return this._pd_project_attach_name_system;
            }
            set
            {
                this._pd_project_attach_name_system = value;
            }
        }

        public string PD_PROJECT_ATTACH_TYPE
        {
            get
            {
                return this._pd_project_attach_type;
            }
            set
            {
                this._pd_project_attach_type = value;
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

