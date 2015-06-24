namespace SoMeTech.Company.Branch
{
    using SoMeTech.Company;
    using SoMeTech.Company.Employee;
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class BranchModel
    {
        private string _address;
        private string _bh;
        private string _branchpk;
        private BranchModel[] _childs;
        private string _companypower;
        private string _datapower;
        private string _discription;
        private string _email;
        private BranchModel _fatherinfo;
        private string _fatherpk;
        private string _fax;
        private int _grade;
        private string _ishasbaby = "";
        private string _isjgbm;
        private string _isuserpower = "1";
        private string _manager;
        private EmployeeModel _managerinfo;
        private string _name;
        private string _phone;
        private string _pk_corp;
        private CompanyModel _pk_corp_info;
        private string _pkpath;
        private string _power;
        private string _rowpower;
        private string _servicespower;

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

        public virtual int Exists(string bh, DB_OPT dbo)
        {
            return this.Exists(bh, dbo);
        }

        public virtual BranchModel[] GetChilds(string parentpk, bool bj_employee, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, bj_employee, dbo);
        }

        public virtual BranchModel[] GetEgality(bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            return this.GetEgality(bj_child, bj_father, bj_company, bj_employee, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual DataSet GetList(int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            return this.GetList(PageSize, PageIndex, strWhere, dbo);
        }

        public virtual BranchModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual BranchModel GetModel(bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            return this.GetModel(bj_child, bj_father, bj_company, bj_employee, dbo);
        }

        public virtual BranchModel GetModel_BH(DB_OPT dbo)
        {
            return this.GetModel_BH(dbo);
        }

        public virtual BranchModel GetModel_BH(bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            return this.GetModel_BH(bj_child, bj_father, bj_company, bj_employee, dbo);
        }

        public virtual BranchModel[] GetModels(string strwhere, bool bj_child, bool bj_father, bool bj_company, bool bj_employee, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj_child, bj_father, bj_company, bj_employee, dbo);
        }

        public virtual BranchModel[] GetParents(bool bj_employee, DB_OPT dbo)
        {
            return this.GetParents(bj_employee, dbo);
        }

        public virtual DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public virtual int UpdateHasBaby(DB_OPT dbo)
        {
            return this.UpdateHasBaby(dbo);
        }

        public virtual int UpdatePKPathAndGrade(DB_OPT dbo)
        {
            return this.UpdatePKPathAndGrade(dbo);
        }

        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
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

        public BranchModel[] Childs
        {
            get
            {
                return this._childs;
            }
            set
            {
                this._childs = value;
            }
        }

        public string CompanyPower
        {
            get
            {
                return this._companypower;
            }
            set
            {
                this._companypower = value;
            }
        }

        public string DataPower
        {
            get
            {
                return this._datapower;
            }
            set
            {
                this._datapower = value;
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

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public BranchModel FatherInfo
        {
            get
            {
                return this._fatherinfo;
            }
            set
            {
                this._fatherinfo = value;
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

        public string Fax
        {
            get
            {
                return this._fax;
            }
            set
            {
                this._fax = value;
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

        public string IsJGBM
        {
            get
            {
                return this._isjgbm;
            }
            set
            {
                this._isjgbm = value;
            }
        }

        public string IsUserPower
        {
            get
            {
                return this._isuserpower;
            }
            set
            {
                this._isuserpower = value;
            }
        }

        public string Manager
        {
            get
            {
                return this._manager;
            }
            set
            {
                this._manager = value;
            }
        }

        public EmployeeModel ManagerInfo
        {
            get
            {
                return this._managerinfo;
            }
            set
            {
                this._managerinfo = value;
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

        public string Phone
        {
            get
            {
                return this._phone;
            }
            set
            {
                this._phone = value;
            }
        }

        public string pk_corp
        {
            get
            {
                return this._pk_corp;
            }
            set
            {
                this._pk_corp = value;
            }
        }

        public CompanyModel PK_Corp_Info
        {
            get
            {
                return this._pk_corp_info;
            }
            set
            {
                this._pk_corp_info = value;
            }
        }

        public string PKPath
        {
            get
            {
                return this._pkpath;
            }
            set
            {
                this._pkpath = value;
            }
        }

        public string Power
        {
            get
            {
                return this._power;
            }
            set
            {
                this._power = value;
            }
        }

        public string RowPower
        {
            get
            {
                return this._rowpower;
            }
            set
            {
                this._rowpower = value;
            }
        }

        public string ServicesPower
        {
            get
            {
                return this._servicespower;
            }
            set
            {
                this._servicespower = value;
            }
        }
    }
}

