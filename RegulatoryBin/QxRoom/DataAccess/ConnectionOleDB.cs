﻿namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    internal sealed class ConnectionOleDB
    {
        private OleDbConnection _con;
        private OleDbTransaction _trans;

        public void Close()
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
                this._con = new OleDbConnection(DataConfig.nDataConString);
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
                this._con = new OleDbConnection(_connstring);
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

        public OleDbConnection _CON
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

        public OleDbTransaction _Trans
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

