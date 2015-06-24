namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.DataAccess;
    using SoMeTech.ServicesClass.Operation;
    using System;
    using System.Data;

    public class ServicesMessModel
    {
        private string _bh;
        private string _BLPassType = "0";
        private string _BLPKs = "0";
        private BranchModel _branchinfo;
        private string _branchpk = "";
        private CompanyModel _companyinfo;
        private string _companypk = "";
        private string _discription = "";
        private ServicesMessModel _ininfo;
        private ServicesMessModel _ininfojzjz;
        private string _inpk = "";
        private string _inpkjzjz = "";
        private string _isBLservice = "0";
        private string _isshow = "1";
        private string _name;
        private BusinessMessModel _operationinfo;
        private string _operationpk = "0";
        private string _pk;
        private string _powercode;
        private ServicesRegisterModel _serviceregisterinfo;
        private string _serviceRegisterpk;
        private string _servicetypepk;
        private string _taxfeecallectionName = "";
        private string _taxfeecallectionPK = "";

        public virtual int Add(DB_OPT dbo)
        {
            return this.Add(dbo);
        }

        public virtual int AddManyApply(DB_OPT dbo)
        {
            return this.AddManyApply(dbo);
        }

        public virtual int Delete(DB_OPT dbo)
        {
            return this.Delete(dbo);
        }

        public virtual int Exists(DB_OPT dbo)
        {
            return this.Exists(dbo);
        }

        public virtual DataSet Exists(string Clo, string ColValue, DB_OPT dbo)
        {
            return this.Exists(Clo, ColValue, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual ServicesMessModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual ServicesMessModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            return this.GetModel(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public virtual int UpdateManyApply(DB_OPT dbo)
        {
            return this.UpdateManyApply(dbo);
        }

        public string BH
        {
            get
            {
                return this._bh;
            }
            set
            {
                this._bh = value;
            }
        }

        public string BLPassType
        {
            get
            {
                return this._BLPassType;
            }
            set
            {
                this._BLPassType = value;
            }
        }

        public string BLPKs
        {
            get
            {
                return this._BLPKs;
            }
            set
            {
                this._BLPKs = value;
            }
        }

        public BranchModel BranchInfo
        {
            get
            {
                return this._branchinfo;
            }
            set
            {
                this._branchinfo = value;
            }
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

        public CompanyModel CompanyInfo
        {
            get
            {
                return this._companyinfo;
            }
            set
            {
                this._companyinfo = value;
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

        public ServicesMessModel InInfo
        {
            get
            {
                return this._ininfo;
            }
            set
            {
                this._ininfo = value;
            }
        }

        public ServicesMessModel InInfoJZJZ
        {
            get
            {
                return this._ininfojzjz;
            }
            set
            {
                this._ininfojzjz = value;
            }
        }

        public string InPK
        {
            get
            {
                return this._inpk;
            }
            set
            {
                this._inpk = value;
            }
        }

        public string InPKJZJZ
        {
            get
            {
                return this._inpkjzjz;
            }
            set
            {
                this._inpkjzjz = value;
            }
        }

        public string IsBLService
        {
            get
            {
                return this._isBLservice;
            }
            set
            {
                this._isBLservice = value;
            }
        }

        public string IsShow
        {
            get
            {
                return this._isshow;
            }
            set
            {
                this._isshow = value;
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

        public BusinessMessModel OperationInfo
        {
            get
            {
                return this._operationinfo;
            }
            set
            {
                this._operationinfo = value;
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

        public ServicesRegisterModel ServiceRegisterInfo
        {
            get
            {
                return this._serviceregisterinfo;
            }
            set
            {
                this._serviceregisterinfo = value;
            }
        }

        public string ServiceRegisterPK
        {
            get
            {
                return this._serviceRegisterpk;
            }
            set
            {
                this._serviceRegisterpk = value;
            }
        }

        public string ServiceTypePK
        {
            get
            {
                return this._servicetypepk;
            }
            set
            {
                this._servicetypepk = value;
            }
        }

        public string TaxFeeCallectionName
        {
            get
            {
                return this._taxfeecallectionName;
            }
            set
            {
                this._taxfeecallectionName = value;
            }
        }

        public string TaxFeeCallectionPK
        {
            get
            {
                return this._taxfeecallectionPK;
            }
            set
            {
                this._taxfeecallectionPK = value;
            }
        }
    }
}

