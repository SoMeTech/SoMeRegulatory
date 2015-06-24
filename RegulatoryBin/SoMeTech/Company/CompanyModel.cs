namespace SoMeTech.Company
{
    using SoMeTech.Company.Branch;
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class CompanyModel
    {
        private string _address;
        private string _area;
        private string _bankpk;
        private string _bh;
        private BranchModel[] _childs_branch;
        private CompanyModel[] _childs_company;
        private string _country;
        private string _discription;
        private string _dutynum;
        private string _email1;
        private string _email2;
        private string _email3;
        private CompanyModel _fatherinfo;
        private string _fatherpk;
        private string _fax1;
        private string _fax2;
        private string _fax3;
        private string _fpdwm;
        private int _grade;
        private string _holder;
        private string _invoicetype;
        private string _ishasbaby = "";
        private string _keychar;
        private string _linkman1;
        private string _linkman2;
        private string _name;
        private string _phone1;
        private string _phone2;
        private string _phone3;
        private string _pk_corp;
        private string _pkpath;
        private string _postalcode;
        private string _province;
        private decimal _regmoney;
        private string _shortname;
        private string _url;
        private string _zxbj;

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

        public virtual CompanyModel[] GetChilds(string parentpk, bool bj_branch, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, bj_branch, dbo);
        }

        public virtual CompanyModel[] GetEgality(bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
        {
            return this.GetEgality(bj_child, bj_father, bj_branch, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual CompanyModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual CompanyModel GetModel(bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
        {
            return this.GetModel(bj_child, bj_father, bj_branch, dbo);
        }

        public virtual CompanyModel[] GetModels(string strwhere, bool bj_child, bool bj_father, bool bj_branch, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj_child, bj_father, bj_branch, dbo);
        }

        public virtual CompanyModel[] GetParents(bool bj_branch, DB_OPT dbo)
        {
            return this.GetParents(bj_branch, dbo);
        }

        public virtual int Update(string oldpk, DB_OPT dbo)
        {
            return this.Update(oldpk, dbo);
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

        public string BankPK
        {
            get
            {
                return this._bankpk;
            }
            set
            {
                this._bankpk = value;
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

        public BranchModel[] Childs_Branch
        {
            get
            {
                return this._childs_branch;
            }
            set
            {
                this._childs_branch = value;
            }
        }

        public CompanyModel[] Childs_Company
        {
            get
            {
                return this._childs_company;
            }
            set
            {
                this._childs_company = value;
            }
        }

        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
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

        public string DutyNum
        {
            get
            {
                return this._dutynum;
            }
            set
            {
                this._dutynum = value;
            }
        }

        public string Email1
        {
            get
            {
                return this._email1;
            }
            set
            {
                this._email1 = value;
            }
        }

        public string Email2
        {
            get
            {
                return this._email2;
            }
            set
            {
                this._email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return this._email3;
            }
            set
            {
                this._email3 = value;
            }
        }

        public CompanyModel FatherInfo
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

        public string Fax1
        {
            get
            {
                return this._fax1;
            }
            set
            {
                this._fax1 = value;
            }
        }

        public string Fax2
        {
            get
            {
                return this._fax2;
            }
            set
            {
                this._fax2 = value;
            }
        }

        public string Fax3
        {
            get
            {
                return this._fax3;
            }
            set
            {
                this._fax3 = value;
            }
        }

        public string FPDWM
        {
            get
            {
                return this._fpdwm;
            }
            set
            {
                this._fpdwm = value;
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

        public string Holder
        {
            get
            {
                return this._holder;
            }
            set
            {
                this._holder = value;
            }
        }

        public string InvoiceType
        {
            get
            {
                return this._invoicetype;
            }
            set
            {
                this._invoicetype = value;
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

        public string KeyChar
        {
            get
            {
                return this._keychar;
            }
            set
            {
                this._keychar = value;
            }
        }

        public string linkman1
        {
            get
            {
                return this._linkman1;
            }
            set
            {
                this._linkman1 = value;
            }
        }

        public string linkman2
        {
            get
            {
                return this._linkman2;
            }
            set
            {
                this._linkman2 = value;
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

        public string Phone1
        {
            get
            {
                return this._phone1;
            }
            set
            {
                this._phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._phone2;
            }
            set
            {
                this._phone2 = value;
            }
        }

        public string Phone3
        {
            get
            {
                return this._phone3;
            }
            set
            {
                this._phone3 = value;
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

        public decimal RegMoney
        {
            get
            {
                return this._regmoney;
            }
            set
            {
                this._regmoney = value;
            }
        }

        public string ShortName
        {
            get
            {
                return this._shortname;
            }
            set
            {
                this._shortname = value;
            }
        }

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }

        public string ZXBJ
        {
            get
            {
                return this._zxbj;
            }
            set
            {
                this._zxbj = value;
            }
        }
    }
}

