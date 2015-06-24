namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Xml;

    public sealed class OracleDataBase : DataBaseEnter, IDisposable
    {
        private ConnectionOracle _oracle = new ConnectionOracle();

        public override void Close()
        {
            this._oracle.CloseCon();
        }

        public override void Commit()
        {
            this._oracle.Commit();
        }

        public void Dispose()
        {
            if ((this._oracle != null) && this._oracle.IsOpen())
            {
                this._oracle.CloseCon();
            }
        }

        public override DataSet ExcePageProcdure(string tablename, string sortname, int pagesize, int pageindex, bool iscount, bool sort, string sqlwhere)
        {
            return base.ExcePageProcdure(tablename, sortname, pagesize, pageindex, iscount, sort, sqlwhere);
        }

        public override DataSet ExecuteDataset(CommandType commandType, string commandText, ParameterCollection commandParameters, string tableName)
        {
            DataSet dataSet = null;
            using (OracleCommand command = new OracleCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                using (OracleDataAdapter adapter = new OracleDataAdapter(command))
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
            using (OracleCommand command = new OracleCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                num = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return num;
        }

        public override IDataReader ExecuteReader(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            OracleDataReader reader = null;
            using (OracleCommand command = new OracleCommand())
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
            using (OracleCommand command = new OracleCommand())
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

        ~OracleDataBase()
        {
            this.Dispose();
        }

        public override bool IsOpen()
        {
            return this._oracle.IsOpen();
        }

        public override void Open()
        {
            this._oracle.Open();
        }

        public override void Open(string _connstring)
        {
            this._oracle.Open(_connstring);
        }

        private void PrepareCommand(OracleCommand cmd, CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.Connection = this._oracle._CON;
            cmd.Transaction = this._oracle._Trans;
            if ((commandParameters != null) && (commandParameters.Count > 0))
            {
                for (int i = 0; i < commandParameters.Count; i++)
                {
                    commandParameters[i].InitRealParameter(DataBaseType.Oracle);
                    OracleParameter realParameter = commandParameters[i].RealParameter as OracleParameter;
                    if (realParameter.DbType == DbType.String)
                    {
                        realParameter.OracleType = OracleType.VarChar;
                    }
                    cmd.Parameters.Add(realParameter);
                }
            }
        }

        public DataTable Query(CommandType commandType, string commandText, ParameterCollection commandParameters)
        {
            DataTable table = null;
            DataTable table2;
            using (OracleCommand command = new OracleCommand())
            {
                this.PrepareCommand(command, commandType, commandText, commandParameters);
                using (OracleDataAdapter adapter = new OracleDataAdapter(command))
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
            this._oracle.Rollback();
        }

        public override void Transaction()
        {
            this._oracle.Transaction();
        }
    }
}

