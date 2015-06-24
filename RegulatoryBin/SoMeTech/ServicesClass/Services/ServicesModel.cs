namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    public class ServicesModel
    {
        private string _bh;
        private string _BLPassType = "0";
        private string _BLPKs = "0";
        private string _branchpk = "";
        private string _classname;
        private string _companypk = "";
        private string _contparameters = "";
        private string _discription = "";
        private string _getservicetype = "";
        private string _iftwocont = "";
        private string _iftwomet = "";
        private string _isBLservice = "0";
        private string _isshow = "1";
        private string _method;
        private string _name;
        private string _operationpk = "0";
        private string _parameters = "";
        private string _path;
        private string _pk;
        private string _powercode;
        private string _servicetypepk;
        private string _table1 = "";
        private string _table2 = "";
        private string _table3 = "";
        private string _table4 = "";
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

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual ServicesModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual ServicesModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            return this.GetModel(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
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

        public string ClassName
        {
            get
            {
                return this._classname;
            }
            set
            {
                this._classname = value;
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

        public string ContParameters
        {
            get
            {
                return this._contparameters;
            }
            set
            {
                this._contparameters = value;
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

        public string GetServiceType
        {
            get
            {
                return this._getservicetype;
            }
            set
            {
                this._getservicetype = value;
            }
        }

        public string IfTwoCont
        {
            get
            {
                return this._iftwocont;
            }
            set
            {
                this._iftwocont = value;
            }
        }

        public string IfTwoMet
        {
            get
            {
                return this._iftwomet;
            }
            set
            {
                this._iftwomet = value;
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

        public string Method
        {
            get
            {
                return this._method;
            }
            set
            {
                this._method = value;
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

        public string Parameters
        {
            get
            {
                return this._parameters;
            }
            set
            {
                this._parameters = value;
            }
        }

        public string Path
        {
            get
            {
                return this._path;
            }
            set
            {
                this._path = value;
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

        public string Table1
        {
            get
            {
                return this._table1;
            }
            set
            {
                this._table1 = value;
            }
        }

        public string Table2
        {
            get
            {
                return this._table2;
            }
            set
            {
                this._table2 = value;
            }
        }

        public string Table3
        {
            get
            {
                return this._table3;
            }
            set
            {
                this._table3 = value;
            }
        }

        public string Table4
        {
            get
            {
                return this._table4;
            }
            set
            {
                this._table4 = value;
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

