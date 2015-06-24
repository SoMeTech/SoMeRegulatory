namespace SoMeTech.Company.Bank
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class BankModel
    {
        private string _bankname;
        private string _banknum;
        private string _banknumman;
        private string _bankpk;
        private string _discription;
        private string _pk_corp;

        public virtual int Add(DB_OPT dbo)
        {
            return this.Add(dbo);
        }

        public virtual void Delete(DB_OPT dbo)
        {
            this.Delete(dbo);
        }

        public virtual int Exists(DB_OPT dbo)
        {
            return this.Exists(dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetViewList(strWhere, dbo);
        }

        public virtual void GetModel(DB_OPT dbo)
        {
            this.GetModel(dbo);
        }

        public virtual DataSet GetViewList(string strWhere, DB_OPT dbo)
        {
            return this.GetViewList(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public string BankName
        {
            get
            {
                return this._bankname;
            }
            set
            {
                this._bankname = value;
            }
        }

        public string BankNum
        {
            get
            {
                return this._banknum;
            }
            set
            {
                this._banknum = value;
            }
        }

        public string BankNumMan
        {
            get
            {
                return this._banknumman;
            }
            set
            {
                this._banknumman = value;
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
    }
}

