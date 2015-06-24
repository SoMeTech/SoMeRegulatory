namespace SMZJ.Model
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class PD_PROJECT_GKGS_Model
    {
        private int _auto_no;
        private string _pd_gs_addr;
        private DateTime? _pd_gs_date;
        private string _pd_gs_detail;
        private string _pd_gs_filename;
        private string _pd_gs_filename_system;
        private string _pd_gs_style;
        private int? _pd_gs_type;
        private string _pd_gs_zhuti;
        private string _pd_project_code;
        private int? _pd_project_type;

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

        public string PD_GS_ADDR
        {
            get
            {
                return this._pd_gs_addr;
            }
            set
            {
                this._pd_gs_addr = value;
            }
        }

        public DateTime? PD_GS_DATE
        {
            get
            {
                return this._pd_gs_date;
            }
            set
            {
                this._pd_gs_date = value;
            }
        }

        public DateTime? PD_GS_DATE_END { get; set; }

        public string PD_GS_DETAIL
        {
            get
            {
                return this._pd_gs_detail;
            }
            set
            {
                this._pd_gs_detail = value;
            }
        }

        public string PD_GS_FILENAME
        {
            get
            {
                return this._pd_gs_filename;
            }
            set
            {
                this._pd_gs_filename = value;
            }
        }

        public string PD_GS_FILENAME_SYSTEM
        {
            get
            {
                return this._pd_gs_filename_system;
            }
            set
            {
                this._pd_gs_filename_system = value;
            }
        }

        public string PD_GS_STYLE
        {
            get
            {
                return this._pd_gs_style;
            }
            set
            {
                this._pd_gs_style = value;
            }
        }

        public int? PD_GS_TYPE
        {
            get
            {
                return this._pd_gs_type;
            }
            set
            {
                this._pd_gs_type = value;
            }
        }

        public string PD_GS_ZHUTI
        {
            get
            {
                return this._pd_gs_zhuti;
            }
            set
            {
                this._pd_gs_zhuti = value;
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

        public int? PD_PROJECT_TYPE
        {
            get
            {
                return this._pd_project_type;
            }
            set
            {
                this._pd_project_type = value;
            }
        }
    }
}

