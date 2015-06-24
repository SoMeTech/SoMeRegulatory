namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_REGULATE_DETAIL_Model
    {
        private long _auto_no;
        private string _filename;
        private string _filesysname;
        private string _filetype = "0";
        private string _pd_project_code;

        public long AUTO_NO
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

        public string FILENAME
        {
            get
            {
                return this._filename;
            }
            set
            {
                this._filename = value;
            }
        }

        public string FILESYSNAME
        {
            get
            {
                return this._filesysname;
            }
            set
            {
                this._filesysname = value;
            }
        }

        public string FILETYPE
        {
            get
            {
                return this._filetype;
            }
            set
            {
                this._filetype = value;
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

