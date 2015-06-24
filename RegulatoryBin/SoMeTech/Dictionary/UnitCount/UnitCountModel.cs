namespace SoMeTech.Dictionary.UnitCount
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    public class UnitCountModel
    {
        private string _bh = "";
        private int _countfactor;
        private string _discription = "";
        private string _fatherpk = "";
        private int _grade;
        private string _ishasbaby = "";
        private string _name = "";
        private string _pk = "";
        private string _pkpath = "";
        private UnitCountModel[] _ubtm;

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

        public virtual UnitCountModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, dbo);
        }

        public virtual UnitCountModel[] GetEgality(bool bj, DB_OPT dbo)
        {
            return this.GetEgality(bj, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual DataSet GetList(string keystr, int PageSize, int PageIndex, string strWhere, DB_OPT dbo)
        {
            return this.GetList(keystr, PageSize, PageIndex, strWhere, dbo);
        }

        public virtual UnitCountModel GetModel(bool bj, DB_OPT dbo)
        {
            return this.GetModel(bj, dbo);
        }

        public virtual UnitCountModel[] GetModels(string strwhere, bool bj, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj, dbo);
        }

        public virtual UnitCountModel[] GetParents(DB_OPT dbo)
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

        public int CountFactor
        {
            get
            {
                return this._countfactor;
            }
            set
            {
                this._countfactor = value;
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

        public UnitCountModel[] ubtm
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

