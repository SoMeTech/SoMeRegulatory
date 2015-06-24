namespace SoMeTech.ServicesClass.Services
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    public class ServicesRegisterModel
    {
        private ServicesRegisterModel[] _childs;
        private string _classname = "";
        private string _contparameters = "";
        private string _discription = "";
        private ServicesRegisterModel _fatherinfo;
        private string _fatherpk = "";
        private string _getservicetype = "";
        private int _grade;
        private string _iftwocont = "";
        private string _iftwomet = "";
        private DateTime _intime = DateTime.Parse("2001-01-01");
        private string _ishasbaby = "";
        private int _mannum = -1;
        private string _method = "";
        private string _name = "";
        private DateTime _outtime = DateTime.Parse("2001-01-01");
        private string _parameters = "";
        private string _path = "";
        private string _pk = "";
        private string _pkpath = "";
        private string _servicetypepk = "";
        private string _startsign = "";

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

        public virtual ServicesRegisterModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, dbo);
        }

        public virtual ServicesRegisterModel[] GetEgality(bool bj_child, bool bj_father, DB_OPT dbo)
        {
            return this.GetEgality(bj_child, bj_father, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual ServicesRegisterModel GetModel(bool bj_child, bool bj_father, DB_OPT dbo)
        {
            return this.GetModel(bj_child, bj_father, dbo);
        }

        public virtual ServicesRegisterModel[] GetModel(string strWhere, bool bj_child, bool bj_father, DB_OPT dbo)
        {
            return this.GetModel(strWhere, bj_child, bj_father, dbo);
        }

        public virtual ServicesRegisterModel[] GetParents(DB_OPT dbo)
        {
            return this.GetParents(dbo);
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

        public ServicesRegisterModel[] Childs
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

        public ServicesRegisterModel FatherInfo
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

        public DateTime InTime
        {
            get
            {
                return this._intime;
            }
            set
            {
                this._intime = value;
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

        public int MaxNum
        {
            get
            {
                return this._mannum;
            }
            set
            {
                this._mannum = value;
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

        public DateTime OutTime
        {
            get
            {
                return this._outtime;
            }
            set
            {
                this._outtime = value;
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

        public string StartSign
        {
            get
            {
                return this._startsign;
            }
            set
            {
                this._startsign = value;
            }
        }
    }
}

