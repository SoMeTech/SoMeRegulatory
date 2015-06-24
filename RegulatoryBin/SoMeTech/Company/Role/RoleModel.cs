namespace SoMeTech.Company.Role
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class RoleModel
    {
        private string _bh;
        private BranchModel _branch;
        private string _branchpk;
        private RoleModel[] _childs;
        private CompanyModel _companyinfo;
        private string _companypower;
        private string _datapower;
        private string _discription;
        private RoleModel _fatherinfo;
        private string _fatherpk;
        private int _grade;
        private string _ishasbaby;
        private string _isuserpower;
        private string _name;
        private string _pk_corp;
        private string _pkpath;
        private string _power;
        private string _rolepk;
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

        public virtual RoleModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, dbo);
        }

        public virtual RoleModel[] GetEgality(bool bj_child, bool bj_father, DB_OPT dbo)
        {
            return this.GetEgality(bj_child, bj_father, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual DataSet GetList(int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            return this.GetList(PageSize, PageIndex, strWhere, dbo);
        }

        public virtual RoleModel GetModel(bool bj_child, bool bj_father, DB_OPT dbo)
        {
            return this.GetModel(bj_child, bj_father, dbo);
        }

        public virtual RoleModel[] GetModels(string strwhere, bool bj_child, bool bj_father, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj_child, bj_father, dbo);
        }

        public virtual RoleModel[] GetParents(DB_OPT dbo)
        {
            return this.GetParents(dbo);
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

        public BranchModel Branch
        {
            get
            {
                return this._branch;
            }
            set
            {
                this._branch = value;
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

        public RoleModel[] Childs
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

        public CompanyModel Company
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

        public RoleModel FatherInfo
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

        public string RolePK
        {
            get
            {
                return this._rolepk;
            }
            set
            {
                this._rolepk = value;
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

