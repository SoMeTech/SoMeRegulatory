namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Xml;

    public abstract class DataBase
    {
        protected DataBase()
        {
        }

        public abstract void Close();
        public abstract void Commit();
        public abstract DataSet ExcePageProcdure(string tablename, string sortname, int pagesize, int pageindex, bool iscount, bool sort, string sqlwhere);
        public abstract DataSet ExecuteDataset(string commandText);
        public abstract DataSet ExecuteDataset(CommandType commandType, string commandText);
        public abstract DataSet ExecuteDataset(string commandText, string tableName);
        public abstract DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters);
        public abstract DataSet ExecuteDataset(CommandType commandType, string commandText, string tableName);
        public abstract DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters, string tableName);
        public abstract DataSet ExecuteDataset(string _tablename, string _showfield, string _sqlwhere, int _showcount);
        public abstract DataSet ExecuteDataset(string _tablename, string _showfield, string _sqlwhere, int _showcount, ParameterCollection _commandParameters);
        public abstract int ExecuteNonQuery(string commandText);
        public abstract int ExecuteNonQuery(CommandType commandType, string commandText);
        public abstract int ExecuteNonQuery(CommandType commandType, string commandText, ParameterCollection commandParameters);
        public abstract IDataReader ExecuteReader(string commandText);
        public abstract IDataReader ExecuteReader(CommandType commandType, string commandText);
        public abstract IDataReader ExecuteReader(CommandType commandType, string commandText, ParameterCollection commandParameters);
        public abstract IDataReader ExecuteReader(string _tablename, string _showfield, string _sqlwhere, int _showcount);
        public abstract IDataReader ExecuteReader(string _tablename, string _showfield, string _sqlwhere, int _showcount, ParameterCollection _commandParameters);
        public abstract object ExecuteScalar(string commandText);
        public abstract object ExecuteScalar(CommandType commandType, string commandText);
        public abstract object ExecuteScalar(CommandType commandType, string commandText, ParameterCollection commandParameters);
        public abstract XmlReader ExecuteXmlReader(string commandText);
        public abstract XmlReader ExecuteXmlReader(CommandType commandType, string commandText);
        public abstract XmlReader ExecuteXmlReader(CommandType commandType, string commandText, ParameterCollection commandParameters);
        public abstract bool IsOpen();
        public abstract void Open();
        public abstract void Open(string _connstring);
        public abstract void Rollback();
        public abstract void Transaction();
    }
}

