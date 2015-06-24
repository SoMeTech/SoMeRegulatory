namespace SoMeTech.ServicesClass.Operation
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    public class OperationModel
    {
        private string _operationpk;
        private string _pk;
        private string _serverpks;

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

        public virtual OperationModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual OperationModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            return this.GetModel(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public string OperationPK
        {
            get
            {
                return this._operationpk;
            }
            set
            {
                this._operationpk = value;
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

        public string ServerPKs
        {
            get
            {
                return this._serverpks;
            }
            set
            {
                this._serverpks = value;
            }
        }
    }
}

