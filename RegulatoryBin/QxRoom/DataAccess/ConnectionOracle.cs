namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OracleClient;

    public sealed class ConnectionOracle
    {
        private OracleConnection _con;
        private OracleTransaction _trans;

        public void CloseCon()
        {
            if (this._con != null)
            {
                if (this._con.State == ConnectionState.Open)
                {
                    this._con.Close();
                }
                this._con.Dispose();
            }
        }

        public void Commit()
        {
            if (this._trans != null)
            {
                this._trans.Commit();
            }
        }

        public bool IsOpen()
        {
            return (this._con.State == ConnectionState.Open);
        }

        public void Open()
        {
            if (this._con == null)
            {
                this._con = new OracleConnection(DataConfig.nDataConString);
                this._con.Open();
            }
            else if (this._con.State == ConnectionState.Closed)
            {
                this._con.Open();
            }
        }

        public void Open(string _connstring)
        {
            if (this._con == null)
            {
                this._con = new OracleConnection(_connstring);
                this._con.Open();
            }
            else if (this._con.State == ConnectionState.Closed)
            {
                this._con.Open();
            }
        }

        public void Rollback()
        {
            if (this._trans != null)
            {
                this._trans.Rollback();
            }
        }

        public void Transaction()
        {
            this._trans = this._con.BeginTransaction();
        }

        public OracleConnection _CON
        {
            get
            {
                return this._con;
            }
            set
            {
                this._con = value;
            }
        }

        public OracleTransaction _Trans
        {
            get
            {
                return this._trans;
            }
            set
            {
                this._trans = value;
            }
        }
    }
}

