namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    public class ServicesConnectionModel
    {
        private string _branchpk;
        private string _companypk;
        private string _connectionpath;
        private string _connectiontypepk;
        private string _fatherpk;
        private int _grade;
        private string _iffee;
        private string _iflast;
        private string _iftax;
        private string _ishasbaby;
        private string _memo;
        private string _name;
        private string _operationpk;
        private string _pk;
        private string _servicepk;
        private int _servicestep;
        private string _toplevelconnectionpk;

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

        public virtual ServicesConnectionModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual ServicesConnectionModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            return this.GetModel(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public string BranchPK
        {
            get
            {
                return this._branchpk;
            }
            set
            {
                this._branchpk = value;
            }
        }

        public string CompanyPK
        {
            get
            {
                return this._companypk;
            }
            set
            {
                this._companypk = value;
            }
        }

        public string ConnectionPath
        {
            get
            {
                return this._connectionpath;
            }
            set
            {
                this._connectionpath = value;
            }
        }

        public string ConnectionTypePK
        {
            get
            {
                return this._connectiontypepk;
            }
            set
            {
                this._connectiontypepk = value;
            }
        }

        public string FatherPK
        {
            get
            {
                return this._fatherpk;
            }
            set
            {
                this._fatherpk = value;
            }
        }

        public int Grade
        {
            get
            {
                return this._grade;
            }
            set
            {
                this._grade = value;
            }
        }

        public string IfFee
        {
            get
            {
                return this._iffee;
            }
            set
            {
                this._iffee = value;
            }
        }

        public string IfLast
        {
            get
            {
                return this._iflast;
            }
            set
            {
                this._iflast = value;
            }
        }

        public string IfTax
        {
            get
            {
                return this._iftax;
            }
            set
            {
                this._iftax = value;
            }
        }

        public string IsHasBaby
        {
            get
            {
                return this._ishasbaby;
            }
            set
            {
                this._ishasbaby = value;
            }
        }

        public string Memo
        {
            get
            {
                return this._memo;
            }
            set
            {
                this._memo = value;
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

        public string ServicePK
        {
            get
            {
                return this._servicepk;
            }
            set
            {
                this._servicepk = value;
            }
        }

        public int ServiceStep
        {
            get
            {
                return this._servicestep;
            }
            set
            {
                this._servicestep = value;
            }
        }

        public string TopLevelConnectionPK
        {
            get
            {
                return this._toplevelconnectionpk;
            }
            set
            {
                this._toplevelconnectionpk = value;
            }
        }
    }
}

