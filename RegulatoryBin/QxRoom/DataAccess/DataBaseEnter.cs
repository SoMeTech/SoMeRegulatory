namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Xml;

    public abstract class DataBaseEnter : DataBase
    {
        private IDbConnection con;
        private IDbTransaction trans;

        protected DataBaseEnter()
        {
        }

        public override void Close()
        {
            this.con.Close();
        }

        public override void Commit()
        {
            if (this.trans != null)
            {
                this.trans.Commit();
            }
        }

        public override DataSet ExcePageProcdure(string tablename, string sortname, int pagesize, int pageindex, bool iscount, bool sort, string sqlwhere)
        {
            return this.ExcePageProcdure(tablename, sortname, pagesize, pageindex, iscount, sort, sqlwhere);
        }

        public override DataSet ExecuteDataset(string commandText)
        {
            return this.ExecuteDataset(CommandType.Text, commandText, null, null);
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            return this.ExecuteDataset(commandType, commandText, null, null);
        }

        public override DataSet ExecuteDataset(string commandText, string tableName)
        {
            return this.ExecuteDataset(CommandType.Text, commandText, null, tableName);
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            return this.ExecuteDataset(commandType, commandText, commandParameters, null);
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText, string tableName)
        {
            return this.ExecuteDataset(commandType, commandText, null, tableName);
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters, string tableName)
        {
            return this.ExecuteDataset(commandType, commandText, commandParameters, tableName);
        }

        public override DataSet ExecuteDataset(string _tablename, string _showfield, string _sqlwhere, int _showcount)
        {
            string commandText = "select top " + _showcount.ToString() + " " + _showfield + " from " + _tablename + " where " + _sqlwhere;
            return this.ExecuteDataset(CommandType.Text, commandText, null, null);
        }

        public override DataSet ExecuteDataset(string _tablename, string _showfield, string _sqlwhere, int _showcount, ParameterCollection _commandParameters)
        {
            string commandText = "select top " + _showcount.ToString() + " " + _showfield + " from " + _tablename + " where " + _sqlwhere;
            return this.ExecuteDataset(CommandType.Text, commandText, _commandParameters, null);
        }

        public override int ExecuteNonQuery(string commandText)
        {
            return this.ExecuteNonQuery(CommandType.Text, commandText, null);
        }

        public override int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return this.ExecuteNonQuery(commandType, commandText, null);
        }

        public override int ExecuteNonQuery(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            return this.ExecuteNonQuery(commandType, commandText, commandParameters);
        }

        public override IDataReader ExecuteReader(string commandText)
        {
            return this.ExecuteReader(CommandType.Text, commandText, null);
        }

        public override IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return this.ExecuteReader(commandType, commandText, null);
        }

        public override IDataReader ExecuteReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            return this.ExecuteReader(commandType, commandText, commandParameters);
        }

        public override IDataReader ExecuteReader(string _tablename, string _showfield, string _sqlwhere, int _showcount)
        {
            string commandText = "select top " + _showcount.ToString() + " " + _showfield + " from " + _tablename + " where " + _sqlwhere;
            return this.ExecuteReader(CommandType.Text, commandText, null);
        }

        public override IDataReader ExecuteReader(string _tablename, string _showfield, string _sqlwhere, int _showcount, ParameterCollection _commandParameters)
        {
            string commandText = "select top " + _showcount.ToString() + " " + _showfield + " from " + _tablename + " where " + _sqlwhere;
            return this.ExecuteReader(CommandType.Text, commandText, _commandParameters);
        }

        public override object ExecuteScalar(string commandText)
        {
            return this.ExecuteScalar(CommandType.Text, commandText, null);
        }

        public override object ExecuteScalar(CommandType commandType, string commandText)
        {
            return this.ExecuteScalar(commandType, commandText, null);
        }

        public override object ExecuteScalar(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            return this.ExecuteScalar(commandType, commandText, commandParameters);
        }

        public override XmlReader ExecuteXmlReader(string commandText)
        {
            return this.ExecuteXmlReader(CommandType.Text, commandText, null);
        }

        public override XmlReader ExecuteXmlReader(CommandType commandType, string commandText)
        {
            return this.ExecuteXmlReader(commandType, commandText, null);
        }

        public override XmlReader ExecuteXmlReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            return this.ExecuteXmlReader(commandType, commandText, commandParameters);
        }

        public override bool IsOpen()
        {
            return this.con.State.Equals(ConnectionState.Closed);
        }

        public override void Open()
        {
            if (this.con.State.Equals(ConnectionState.Closed))
            {
                this.con.Open();
            }
        }

        public override void Open(string _connstring)
        {
            if (this.con.State.Equals(ConnectionState.Closed))
            {
                this.con.Open();
            }
        }

        public override void Rollback()
        {
            if (this.trans != null)
            {
                this.trans.Rollback();
            }
        }

        public override void Transaction()
        {
            this.trans = this.con.BeginTransaction();
        }
    }
}

