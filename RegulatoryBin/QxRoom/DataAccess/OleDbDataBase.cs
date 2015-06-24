namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Xml;

    public sealed class OleDbDataBase : DataBaseEnter, IDisposable
    {
        private ConnectionOleDB _oledb = new ConnectionOleDB();

        public override void Close()
        {
            this._oledb.Close();
        }

        public override void Commit()
        {
            this._oledb.Commit();
        }

        public void Dispose()
        {
            if ((this._oledb != null) && this._oledb.IsOpen())
            {
                this._oledb.Close();
            }
        }

        public override DataSet ExcePageProcdure(string tablename, string sortname, int pagesize, int pageindex, bool iscount, bool sort, string sqlwhere)
        {
            return base.ExcePageProcdure(tablename, sortname, pagesize, pageindex, iscount, sort, sqlwhere);
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters, string tableName)
        {
            DataSet dataSet = null;
            using (OleDbCommand command = new OleDbCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
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
            using (OleDbCommand command = new OleDbCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                num = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return num;
        }

        public override IDataReader ExecuteReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            OleDbDataReader reader = null;
            using (OleDbCommand command = new OleDbCommand())
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
            using (OleDbCommand command = new OleDbCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                obj2 = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            return obj2;
        }

        public override XmlReader ExecuteXmlReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            return null;
        }

        ~OleDbDataBase()
        {
            this.Dispose();
        }

        public override bool IsOpen()
        {
            return this._oledb.IsOpen();
        }

        public override void Open()
        {
            this._oledb.Open();
        }

        public override void Open(string _connstring)
        {
            this._oledb.Open(_connstring);
        }

        private void PrepareCommand(OleDbCommand cmd, CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.Connection = this._oledb._CON;
            cmd.Transaction = this._oledb._Trans;
            if ((commandParameters != null) && (commandParameters.Count > 0))
            {
                for (int i = 0; i < commandParameters.Count; i++)
                {
                    commandParameters[i].InitRealParameter(DataBaseType.OleDB);
                    cmd.Parameters.Add(commandParameters[i].RealParameter as OleDbParameter);
                }
            }
        }

        public DataTable Query(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            DataTable table = null;
            DataTable table2;
            using (OleDbCommand command = new OleDbCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
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
            this._oledb.Rollback();
        }

        public override void Transaction()
        {
            this._oledb.Transaction();
        }
    }
}

