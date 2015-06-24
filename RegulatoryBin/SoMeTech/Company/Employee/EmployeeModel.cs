namespace SoMeTech.Company.Employee
{
    using SoMeTech.Company;
    using SoMeTech.Company.Branch;
    using SoMeTech.Company.Role;
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class EmployeeModel
    {
        private string _address;
        private int _age;
        private string _area;
        private string _bh;
        private DateTime _birthday;
        private BranchModel _branch;
        private string _branchpk;
        private string _cardnum;
        private EmployeeModel[] _childs;
        private string _city;
        private CompanyModel _companyinfo;
        private string _email;
        private string _employeepk;
        private EmployeeModel _fatherinfo;
        private string _fatherpk;
        private int _grade;
        private string _icqnum;
        private string _ishasbaby;
        private string _mobile1;
        private string _mobile2;
        private string _mobile3;
        private string _msnnum;
        private string _mz;
        private string _name;
        private string _nationals;
        private string _officephone;
        private string _otherlink;
        private string _phone;
        private string _pk_corp;
        private string _pkpath;
        private string _postalcode;
        private string _province;
        private string _qqnum;
        private RoleModel _role;
        private string _rolepk;
        private string _sex;
        private int _workage;

        public virtual int Add(DB_OPT dbo)
        {
            return this.Add(dbo);
        }

        public virtual int Delete(DB_OPT dbo)
        {
            return this.Delete(dbo);
        }

        public virtual int Exists(string BH, DB_OPT dbo)
        {
            return this.Exists(BH, dbo);
        }

        public virtual int Exists(string col, string val, DB_OPT dbo)
        {
            return this.Exists(col, val, dbo);
        }

        public virtual EmployeeModel[] GetChilds(string parentpk, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, bj_company, bj_branch, bj_role, dbo);
        }

        public virtual EmployeeModel[] GetEgality(bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            return this.GetEgality(bj_child, bj_father, bj_company, bj_branch, bj_role, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual EmployeeModel GetModel(bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            return this.GetModel(bj_child, bj_father, bj_company, bj_branch, bj_role, dbo);
        }

        public virtual EmployeeModel[] GetModels(string strwhere, bool bj_child, bool bj_father, bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj_child, bj_father, bj_company, bj_branch, bj_role, dbo);
        }

        public virtual EmployeeModel[] GetParents(bool bj_company, bool bj_branch, bool bj_role, DB_OPT dbo)
        {
            return this.GetParents(bj_company, bj_branch, bj_role, dbo);
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

        public virtual int UpdateZXBJ(DB_OPT dbo)
        {
            return this.UpdateZXBJ(dbo);
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

        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }

        public string Area
        {
            get
            {
                return this._area;
            }
            set
            {
                this._area = value;
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

        public DateTime BirthDay
        {
            get
            {
                return this._birthday;
            }
            set
            {
                this._birthday = value;
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

        public string CardNum
        {
            get
            {
                return this._cardnum;
            }
            set
            {
                this._cardnum = value;
            }
        }

        public EmployeeModel[] Childs
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

        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
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

        public EmployeeModel FatherInfo
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

        public string ICQNum
        {
            get
            {
                return this._icqnum;
            }
            set
            {
                this._icqnum = value;
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

        public string Mobile1
        {
            get
            {
                return this._mobile1;
            }
            set
            {
                this._mobile1 = value;
            }
        }

        public string Mobile2
        {
            get
            {
                return this._mobile2;
            }
            set
            {
                this._mobile2 = value;
            }
        }

        public string Mobile3
        {
            get
            {
                return this._mobile3;
            }
            set
            {
                this._mobile3 = value;
            }
        }

        public string MSNNum
        {
            get
            {
                return this._msnnum;
            }
            set
            {
                this._msnnum = value;
            }
        }

        public string MZ
        {
            get
            {
                return this._mz;
            }
            set
            {
                this._mz = value;
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

        public string Nationals
        {
            get
            {
                return this._nationals;
            }
            set
            {
                this._nationals = value;
            }
        }

        public string OfficePhone
        {
            get
            {
                return this._officephone;
            }
            set
            {
                this._officephone = value;
            }
        }

        public string OtherLink
        {
            get
            {
                return this._otherlink;
            }
            set
            {
                this._otherlink = value;
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

        public string PostalCode
        {
            get
            {
                return this._postalcode;
            }
            set
            {
                this._postalcode = value;
            }
        }

        public string Province
        {
            get
            {
                return this._province;
            }
            set
            {
                this._province = value;
            }
        }

        public string QQNum
        {
            get
            {
                return this._qqnum;
            }
            set
            {
                this._qqnum = value;
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

        public string Sex
        {
            get
            {
                return this._sex;
            }
            set
            {
                this._sex = value;
            }
        }

        public int WorkAge
        {
            get
            {
                return this._workage;
            }
            set
            {
                this._workage = value;
            }
        }
    }
}

