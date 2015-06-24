namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_LOG_Model
    {
        private string _autoid;
        private string _bm;
        private string _company;
        private string _exe_cz;
        private string _exe_dtime;
        private string _exe_jg;
        private string _exe_txt;
        private string _free1;
        private string _free2;
        private string _free3;
        private string _man;
        private string _pd_project_code;
        private string _pd_project_type = "0";

        public string AUTOID
        {
            get
            {
                return this._autoid;
            }
            set
            {
                this._autoid = value;
            }
        }

        public string BM
        {
            get
            {
                return this._bm;
            }
            set
            {
                this._bm = value;
            }
        }

        public string COMPANY
        {
            get
            {
                return this._company;
            }
            set
            {
                this._company = value;
            }
        }

        public string EXE_CZ
        {
            get
            {
                return this._exe_cz;
            }
            set
            {
                this._exe_cz = value;
            }
        }

        public string EXE_DTIME
        {
            get
            {
                return this._exe_dtime;
            }
            set
            {
                this._exe_dtime = value;
            }
        }

        public string EXE_JG
        {
            get
            {
                return this._exe_jg;
            }
            set
            {
                this._exe_jg = value;
            }
        }

        public string EXE_TXT
        {
            get
            {
                return this._exe_txt;
            }
            set
            {
                this._exe_txt = value;
            }
        }

        public string FREE1
        {
            get
            {
                return this._free1;
            }
            set
            {
                this._free1 = value;
            }
        }

        public string FREE2
        {
            get
            {
                return this._free2;
            }
            set
            {
                this._free2 = value;
            }
        }

        public string FREE3
        {
            get
            {
                return this._free3;
            }
            set
            {
                this._free3 = value;
            }
        }

        public string MAN
        {
            get
            {
                return this._man;
            }
            set
            {
                this._man = value;
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

        public string PD_PROJECT_TYPE
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

