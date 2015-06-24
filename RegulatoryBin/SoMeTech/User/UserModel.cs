namespace SoMeTech.User
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.Company.Employee;
    using SoMeTech.Company.Role;
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Web.UI;

    public class UserModel
    {
        private string _bname;
        private BranchModel _branch;
        private string _branchpk;
        private string _cname;
        private CompanyModel _companyinfo;
        private string _companypower = "";
        private string _datapower = "";
        private string _discription;
        private EmployeeModel _employee;
        private string _employeepk;
        private string _isjgbm = "";
        private string _isuser;
        private string _password;
        private string _pk_corp;
        private string _power = "";
        private string _rname;
        private RoleModel _role;
        private string _rolepk;
        private string _rowpower = "";
        private string _servicespower = "";
        private string _truename;
        private string _username = "";
        private string _userpk = "";

        public virtual int Add(DB_OPT dbo)
        {
            return this.Add(dbo);
        }

        public virtual void Delete(DB_OPT dbo)
        {
            this.Delete(dbo);
        }

        public virtual int ExistsByEmpPK(DB_OPT dbo)
        {
            return this.ExistsByEmpPK(dbo);
        }

        public virtual int ExistsByUserName(DB_OPT dbo)
        {
            return this.ExistsByUserName(dbo);
        }

        public virtual int ExistsByUserPK(DB_OPT dbo)
        {
            return this.ExistsByUserPK(dbo);
        }

        public virtual string GetLastStream(Page page, DB_OPT dbo)
        {
            return this.GetLastStream(page, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual DataSet GetList(int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            return this.GetList(PageSize, PageIndex, strWhere, dbo);
        }

        public virtual DataSet GetListAll(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual void GetModel(DB_OPT dbo)
        {
            this.GetModel(dbo);
        }

        public virtual void GetModelOnly(DB_OPT dbo)
        {
            this.GetModelOnly(dbo);
        }

        public virtual void GetServiceCode(string objID, string path, string userID, out int IsShow, out string showtxt, DB_OPT dbo)
        {
            this.GetServiceCode(objID, path, userID, out IsShow, out showtxt, dbo);
        }

        public virtual void GetServiceStream(string path, string userID, string MainServerPK, out string ShowButtonID, out string ButtonShowTxt, out string BoHui_ZhuiHui, out string IsSava_objID, DB_OPT dbo)
        {
            this.GetServiceStream(path, userID, MainServerPK, out ShowButtonID, out ButtonShowTxt, out BoHui_ZhuiHui, out IsSava_objID, dbo);
        }

        public virtual void GetUpDownStream(string path, string serverPK, int operation, out string NewServerPK, DB_OPT dbo)
        {
            this.GetUpDownStream(path, serverPK, operation, out NewServerPK, dbo);
        }

        public virtual void Login(DB_OPT dbo)
        {
            this.Login(dbo);
        }

        public virtual void SetServiceStream(string path, string BILL_CODE, string userID, string userCompany, string userDepart, string userDate, string serverPK, int operation, out string NewServerPK, DB_OPT dbo)
        {
            this.SetServiceStream(path, BILL_CODE, userID, userCompany, userDepart, userDate, serverPK, operation, out NewServerPK, dbo);
        }

        public virtual int Update(UserUpdatePowerType uupt, UserUpdateIndex uui, DB_OPT dbo)
        {
            return this.Update(uupt, uui, dbo);
        }

        public virtual int UpdatePwd(string stropwd, DB_OPT dbo)
        {
            return this.UpdatePwd(stropwd, dbo);
        }

        public virtual string WelcomePower(string url, string username, ref string name)
        {
            return this.WelcomePower(url, username, ref name);
        }

        public string bName
        {
            get
            {
                return this._bname;
            }
            set
            {
                this._bname = value;
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

        public string cName
        {
            get
            {
                return this._cname;
            }
            set
            {
                this._cname = value;
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

        public EmployeeModel Employee
        {
            get
            {
                return this._employee;
            }
            set
            {
                this._employee = value;
            }
        }

        public string EmployeePK
        {
            get
            {
                return this._employeepk;
            }
            set
            {
                this._employeepk = value;
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

        public string IsUser
        {
            get
            {
                return this._isuser;
            }
            set
            {
                this._isuser = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
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

        public string rName
        {
            get
            {
                return this._rname;
            }
            set
            {
                this._rname = value;
            }
        }

        public RoleModel Role
        {
            get
            {
                return this._role;
            }
            set
            {
                this._role = value;
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

        public string TrueName
        {
            get
            {
                return this._truename;
            }
            set
            {
                this._truename = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string UserPK
        {
            get
            {
                return this._userpk;
            }
            set
            {
                this._userpk = value;
            }
        }
    }
}

