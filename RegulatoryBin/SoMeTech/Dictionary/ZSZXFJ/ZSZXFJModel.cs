namespace SoMeTech.Dictionary.ZSZXFJ
{
    using SoMeTech.DataAccess;
    using SoMeTech.Dictionary.SFType;
    using SoMeTech.UsualBookTable;
    using System;
    using System.Data;

    public class ZSZXFJModel
    {
        private string _discription;
        private decimal _executevalue1;
        private decimal _executevalue2;
        private decimal _executevalue3;
        private int _flog;
        private string _operationname;
        private string _operationpk;
        private string _pk;
        private string _projecttype;
        private UsualBookTableModel _projecttypeinfo;
        private SFTypeModel _sfinfo;
        private string _sfpk;
        private string _termname1;
        private string _termname2;

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

        public virtual ZSZXFJModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
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

        public decimal ExecuteValue1
        {
            get
            {
                return this._executevalue1;
            }
            set
            {
                this._executevalue1 = value;
            }
        }

        public decimal ExecuteValue2
        {
            get
            {
                return this._executevalue2;
            }
            set
            {
                this._executevalue2 = value;
            }
        }

        public decimal ExecuteValue3
        {
            get
            {
                return this._executevalue3;
            }
            set
            {
                this._executevalue3 = value;
            }
        }

        public int flog
        {
            get
            {
                return this._flog;
            }
            set
            {
                this._flog = value;
            }
        }

        public string OperationName
        {
            get
            {
                return this._operationname;
            }
            set
            {
                this._operationname = value;
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

        public string pk
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

        public string ProjectType
        {
            get
            {
                return this._projecttype;
            }
            set
            {
                this._projecttype = value;
            }
        }

        public UsualBookTableModel ProjecttypeInfo
        {
            get
            {
                return this._projecttypeinfo;
            }
            set
            {
                this._projecttypeinfo = value;
            }
        }

        public SFTypeModel Sfinfo
        {
            get
            {
                return this._sfinfo;
            }
            set
            {
                this._sfinfo = value;
            }
        }

        public string SFPK
        {
            get
            {
                return this._sfpk;
            }
            set
            {
                this._sfpk = value;
            }
        }

        public string TermName1
        {
            get
            {
                return this._termname1;
            }
            set
            {
                this._termname1 = value;
            }
        }

        public string TermName2
        {
            get
            {
                return this._termname2;
            }
            set
            {
                this._termname2 = value;
            }
        }
    }
}

