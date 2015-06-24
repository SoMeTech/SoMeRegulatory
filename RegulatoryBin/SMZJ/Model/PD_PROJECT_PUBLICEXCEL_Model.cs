namespace SMZJ.Model
{
    using System;

    [Serializable]
    public class PD_PROJECT_PUBLICEXCEL_Model
    {
        private decimal _auto_id;
        private string _branchid;
        private string _companyid;
        private string _name;
        private string _pd_project_serverpk;
        private string _tablename;

        public decimal AUTO_ID
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

        public string BRANCHID
        {
            get
            {
                return this._branchid;
            }
            set
            {
                this._branchid = value;
            }
        }

        public string COMPANYID
        {
            get
            {
                return this._companyid;
            }
            set
            {
                this._companyid = value;
            }
        }

        public string NAME
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string PD_PROJECT_SERVERPK
        {
            get
            {
                return this._pd_project_serverpk;
            }
            set
            {
                this._pd_project_serverpk = value;
            }
        }

        public string TABLENAME
        {
            get
            {
                return this._tablename;
            }
            set
            {
                this._tablename = value;
            }
        }
    }
}

