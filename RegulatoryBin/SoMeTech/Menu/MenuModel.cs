namespace SoMeTech.Menu
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    [Serializable]
    public class MenuModel
    {
        private MenuModel[] _childs;
        private string _deletepc;
        private string _discription;
        private string _fatherbh;
        private int _grade = -1;
        private string _imgurl;
        private string _insertpc;
        private string _ischeckpower;
        private string _ishasbaby = "";
        private string _isshow;
        private string _memupk = "";
        private string _menubh;
        private string _menuname;
        private string _menutype;
        private string _opentype;
        private int _orderby;
        private string _pageurl;
        private string _pk_corp;
        private string _pkpath = "";
        private string _powercode;
        private string _printpc;
        private string _updatepc;
        private int _visitpoint;

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

        public virtual int Exists(string PowerCode, DB_OPT dbo)
        {
            return this.Exists(PowerCode, dbo);
        }

        public virtual MenuModel[] GetChilds(string parentpk, DB_OPT dbo)
        {
            return this.GetChilds(parentpk, dbo);
        }

        public virtual MenuModel[] GetEgality(bool bj, DB_OPT dbo)
        {
            return this.GetEgality(bj, dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual MenuModel GetModel(bool bj, DB_OPT dbo)
        {
            return this.GetModel(bj, dbo);
        }

        public virtual MenuModel[] GetModels(string strwhere, bool bj, DB_OPT dbo)
        {
            return this.GetModels(strwhere, bj, dbo);
        }

        public virtual MenuModel[] GetParents(DB_OPT dbo)
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

        public MenuModel[] Childs
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

        public string DeletePC
        {
            get
            {
                return this._deletepc;
            }
            set
            {
                this._deletepc = value;
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
                return this._fatherbh;
            }
            set
            {
                this._fatherbh = value;
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

        public string ImgUrl
        {
            get
            {
                return this._imgurl;
            }
            set
            {
                this._imgurl = value;
            }
        }

        public string InsertPC
        {
            get
            {
                return this._insertpc;
            }
            set
            {
                this._insertpc = value;
            }
        }

        public string IsCheckPower
        {
            get
            {
                return this._ischeckpower;
            }
            set
            {
                this._ischeckpower = value;
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

        public string IsShow
        {
            get
            {
                return this._isshow;
            }
            set
            {
                this._isshow = value;
            }
        }

        public string MemuPK
        {
            get
            {
                return this._memupk;
            }
            set
            {
                this._memupk = value;
            }
        }

        public string MenuBH
        {
            get
            {
                return this._menubh;
            }
            set
            {
                this._menubh = value;
            }
        }

        public string MenuName
        {
            get
            {
                return this._menuname;
            }
            set
            {
                this._menuname = value;
            }
        }

        public string MenuType
        {
            get
            {
                return this._menutype;
            }
            set
            {
                this._menutype = value;
            }
        }

        public string OpenType
        {
            get
            {
                return this._opentype;
            }
            set
            {
                this._opentype = value;
            }
        }

        public int OrderBy
        {
            get
            {
                return this._orderby;
            }
            set
            {
                this._orderby = value;
            }
        }

        public string PageUrl
        {
            get
            {
                return this._pageurl;
            }
            set
            {
                this._pageurl = value;
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

        public string PowerCode
        {
            get
            {
                return this._powercode;
            }
            set
            {
                this._powercode = value;
            }
        }

        public string PrintPC
        {
            get
            {
                return this._printpc;
            }
            set
            {
                this._printpc = value;
            }
        }

        public string UpdatePC
        {
            get
            {
                return this._updatepc;
            }
            set
            {
                this._updatepc = value;
            }
        }

        public int VisitPoint
        {
            get
            {
                return this._visitpoint;
            }
            set
            {
                this._visitpoint = value;
            }
        }
    }
}

