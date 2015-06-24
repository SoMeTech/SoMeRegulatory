namespace SoMeTech.UsualBookTable
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class UsualBookTableModel
    {
        private string _bh = "";
        private string _discription = "";
        private string _fatherpk = "";
        private int _grade;
        private string _ishasbaby = "";
        private string _name = "";
        private string _pk = "";
        private string _pk_corp = "";
        private string _pkpath = "";
        private UsualBookTableModel[] _ubtm;
        private string tablename = "";

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

        public virtual int Exists(string BH, DB_OPT dbo)
        {
            return this.Exists(BH, dbo);
        }

        public virtual UsualBookTableModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, dbo);
        }

        public virtual UsualBookTableModel[] GetEgality(bool bj, DB_OPT dbo)
        {
            return this.GetEgality(bj, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual DataSet GetList(string TableName, string keystr, int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            return this.GetList(TableName, keystr, PageSize, PageIndex, strWhere, dbo);
        }

        public virtual UsualBookTableModel GetModel(bool bj, DB_OPT dbo)
        {
            return this.GetModel(bj, dbo);
        }

        public virtual UsualBookTableModel[] GetModels(string strwhere, bool bj, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj, dbo);
        }

        public virtual UsualBookTableModel[] GetParents(DB_OPT dbo)
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

        public string TableName
        {
            get
            {
                return this.tablename;
            }
            set
            {
                this.tablename = value;
            }
        }

        public UsualBookTableModel[] ubtm
        {
            get
            {
                return this._ubtm;
            }
            set
            {
                this._ubtm = value;
            }
        }
    }
}

