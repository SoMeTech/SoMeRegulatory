namespace SoMeTech.Menu
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class DataRowPowerModel
    {
        private string _codeandwhere;
        private string _columnname;
        private string _discription;
        private string _name;
        private string _pk;
        private string _powercode;
        private string _strwhere;
        private string _tablename;
        private string _tjtype;

        public virtual int Add(DB_OPT dbo)
        {
            return this.Add(dbo);
        }

        public virtual int Delete(DB_OPT dbo)
        {
            return this.Delete(dbo);
        }

        public virtual int Exists(DB_OPT dbo)
        {
            return this.Exists(dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual DataSet GetList(int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            return this.GetList(PageSize, PageIndex, strWhere, dbo);
        }

        public virtual DataSet GetMessage(DB_OPT dbo)
        {
            return this.GetMessage(dbo);
        }

        public virtual void GetModel(DB_OPT dbo)
        {
            this.GetModel(dbo);
        }

        public virtual DataRowPowerModel[] GetModels(DB_OPT dbo)
        {
            return this.GetModels(dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public string CodeAndWhere
        {
            get
            {
                return this._codeandwhere;
            }
            set
            {
                this._codeandwhere = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return this._columnname;
            }
            set
            {
                this._columnname = value;
            }
        }

        public string Discription
        {
            get
            {
                return this._discription;
            }
            set
            {
                this._discription = value;
            }
        }

        public string Name
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

        public string PK
        {
            get
            {
                return this._pk;
            }
            set
            {
                this._pk = value;
            }
        }

        public string PowerCode
        {
            get
            {
                return this._powercode;
            }
            set
            {
                this._powercode = value;
            }
        }

        public string strWhere
        {
            get
            {
                return this._strwhere;
            }
            set
            {
                this._strwhere = value;
            }
        }

        public string TableName
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

        public string TJType
        {
            get
            {
                return this._tjtype;
            }
            set
            {
                this._tjtype = value;
            }
        }
    }
}

