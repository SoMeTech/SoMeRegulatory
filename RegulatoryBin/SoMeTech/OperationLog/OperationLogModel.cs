namespace SoMeTech.OperationLog
{
    using SoMeTech.DataAccess;
    using QxRoom.Common;
    using System;
    using System.Data;

    public class OperationLogModel
    {
        private string _business;
        private string _content;
        private string _ifpass;
        private DateTime _optime;
        private string _optype;
        private string _pk;
        private string _username;

        public virtual int Add(DB_OPT dbo)
        {
            return this.Add(dbo);
        }

        public virtual int Delete(DB_OPT db)
        {
            return this.Delete(db);
        }

        public virtual int Exists(DB_OPT dbo)
        {
            return this.Exists(dbo);
        }

        public virtual DataSet GetList(string strWhere, DB_OPT dbo)
        {
            return this.GetList(strWhere, dbo);
        }

        public virtual OperationLogModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
        }

        public string Business
        {
            get
            {
                return this._business;
            }
            set
            {
                this._business = value;
            }
        }

        public string Content
        {
            get
            {
                if (this._content.Length > 0xfa0)
                {
                    return CharCheck.CutStr_New(this._content, 0xfa0);
                }
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        public string ifPass
        {
            get
            {
                return this._ifpass;
            }
            set
            {
                this._ifpass = value;
            }
        }

        public DateTime opTime
        {
            get
            {
                return this._optime;
            }
            set
            {
                this._optime = value;
            }
        }

        public string opType
        {
            get
            {
                return this._optype;
            }
            set
            {
                this._optype = value;
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
    }
}

