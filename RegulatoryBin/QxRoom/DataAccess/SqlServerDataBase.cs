namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;

    public sealed class SqlServerDataBase : DataBaseEnter, IDisposable
    {
        private ConnectionSqlServer _sqlserver = new ConnectionSqlServer();

        public override void Close()
        {
            this._sqlserver.CloseCon();
        }

        public override void Commit()
        {
            this._sqlserver.Commit();
        }

        public void Dispose()
        {
            if ((this._sqlserver != null) && this._sqlserver.IsOpen())
            {
                this._sqlserver.CloseCon();
            }
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters, string tableName)
        {
            DataSet dataSet = null;
            using (SqlCommand command = new SqlCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    dataSet = new DataSet();
                    if (object.Equals(tableName, null) || (tableName.Length < 1))
                    {
                        adapter.Fill(dataSet);
                    }
                    else
                    {
                        adapter.Fill(dataSet, tableName);
                    }
                    command.Parameters.Clear();
                }
            }
            return dataSet;
        }

        public override int ExecuteNonQuery(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            int num = 0;
            using (SqlCommand command = new SqlCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                num = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return num;
        }

        public override IDataReader ExecuteReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            SqlDataReader reader = null;
            using (SqlCommand command = new SqlCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                reader = command.ExecuteReader();
                command.Parameters.Clear();
            }
            return reader;
        }

        public override object ExecuteScalar(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            object obj2 = null;
            using (SqlCommand command = new SqlCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                obj2 = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            return obj2;
        }

        public override XmlReader ExecuteXmlReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            XmlReader reader = null;
            using (SqlCommand command = new SqlCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                reader = command.ExecuteXmlReader();
                command.Parameters.Clear();
            }
            return reader;
        }

        ~SqlServerDataBase()
        {
            this.Dispose();
        }

        public override bool IsOpen()
        {
            return this._sqlserver.IsOpen();
        }

        public override void Open()
        {
            this._sqlserver.Open();
        }

        public override void Open(string _connstring)
        {
            this._sqlserver.Open(_connstring);
        }

        public void PrepareCommand(SqlCommand cmd, CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.Connection = this._sqlserver._CON;
            cmd.Transaction = this._sqlserver._Trans;
            if ((commandParameters != null) && (commandParameters.Count > 0))
            {
                for (int i = 0; i < commandParameters.Count; i++)
                {
                    commandParameters[i].InitRealParameter(DataBaseType.SqlServer);
                    cmd.Parameters.Add(commandParameters[i].RealParameter as SqlParameter);
                }
            }
        }

        public DataTable Query(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            DataTable table = null;
            DataTable table2;
            using (SqlCommand command = new SqlCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    using (DataSet set = new DataSet())
                    {
                        adapter.Fill(set);
                        if (set.Tables.Count > 0)
                        {
                            table = set.Tables[0].Copy();
                        }
                    }
                    table2 = table;
                }
            }
            return table2;
        }

        public override void Rollback()
        {
            this._sqlserver.Rollback();
        }

        public override void Transaction()
        {
            this._sqlserver.Transaction();
        }
    }
}

