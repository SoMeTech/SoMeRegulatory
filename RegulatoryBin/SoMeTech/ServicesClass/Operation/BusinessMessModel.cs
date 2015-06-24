namespace SoMeTech.ServicesClass.Operation
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;

    public class BusinessMessModel
    {
        private string _name;
        private int _oprateorder;
        private string _pk;
        private string _remark;
        private string _tachetype;

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

        public virtual BusinessMessModel GetModel(DB_OPT dbo)
        {
            return this.GetModel(dbo);
        }

        public virtual BusinessMessModel[] GetModel(string strWhere, DB_OPT dbo)
        {
            return this.GetModel(strWhere, dbo);
        }

        public virtual int Update(DB_OPT dbo)
        {
            return this.Update(dbo);
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

        public int OprateOrder
        {
            get
            {
                return this._oprateorder;
            }
            set
            {
                this._oprateorder = value;
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

        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        public string TacheType
        {
            get
            {
                return this._tachetype;
            }
            set
            {
                this._tachetype = value;
            }
        }
    }
}

