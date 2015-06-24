namespace SoMeTech.DataAccess
{
    using QxRoom.QxConst;
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.OracleClient;

    public sealed class DB_Oracle
    {
        public OracleConnection con;
        public OracleTransaction st;

        public DataSet BackDataSet(string strSql, Hashtable ht)
        {
            DataSet set;
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                OracleParameter parameter = null;
                adapter.SelectCommand = new OracleCommand();
                adapter.SelectCommand.CommandText = strSql;
                adapter.SelectCommand.Connection = this.con;
                if (this.st != null)
                {
                    adapter.SelectCommand.Transaction = this.st;
                }
                if (ht != null)
                {
                    foreach (DictionaryEntry entry in ht)
                    {
                        parameter = adapter.SelectCommand.CreateParameter();
                        parameter.ParameterName = entry.Key.ToString();
                        parameter.Value = entry.Value.ToString();
                        adapter.SelectCommand.Parameters.Add(parameter);
                    }
                }
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                set = dataSet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public DataSet BackDataSet(string strSql, OracleParameter[] parameters, string bj)
        {
            DataSet set;
            try
            {
                BindDBNull(parameters);
                OracleDataAdapter adapter = new OracleDataAdapter {
                    SelectCommand = new OracleCommand()
                };
                adapter.SelectCommand.CommandText = strSql;
                adapter.SelectCommand.Connection = this.con;
                if (this.st != null)
                {
                    adapter.SelectCommand.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (OracleParameter parameter in parameters)
                    {
                        adapter.SelectCommand.Parameters.Add(parameter);
                    }
                }
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                set = dataSet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public int BackIsSelect(string strSql, Hashtable ht)
        {
            int num;
            try
            {
                OracleCommand command = new OracleCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                OracleParameter parameter = null;
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (ht != null)
                {
                    foreach (DictionaryEntry entry in ht)
                    {
                        parameter = command.CreateParameter();
                        parameter.ParameterName = entry.Key.ToString();
                        parameter.Value = entry.Value.ToString();
                        command.Parameters.Add(parameter);
                    }
                }
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public int BackIsSelect(string strSql, OracleParameter[] parameters, string bj)
        {
            int num;
            try
            {
                BindDBNull(parameters);
                OracleCommand command = new OracleCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (OracleParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        private static void BindDBNull(OracleParameter[] cmdParms)
        {
            if (cmdParms != null)
            {
                foreach (OracleParameter parameter in cmdParms)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    if (((parameter.OracleType == OracleType.Number) && (parameter.Value != null)) && (parameter.Value.ToString().Trim() == ""))
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
            }
        }

        public int BuildQueryCommand(string storedProcName, OracleParameter[] parameters)
        {
            int num;
            try
            {
                BindDBNull(parameters);
                OracleCommand command = new OracleCommand {
                    CommandText = storedProcName,
                    Connection = this.con,
                    CommandType = CommandType.StoredProcedure
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                foreach (OracleParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                num = Convert.ToInt32(command.ExecuteNonQuery());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public void Close()
        {
            if ((this.con != null) && (this.con.State == ConnectionState.Open))
            {
                this.con.Close();
            }
        }

        public void Commit()
        {
            if (this.con != null)
            {
                this.st.Commit();
            }
        }

        public OracleConnection conn()
        {
            string str = ConfigurationManager.AppSettings["DataConn"] + QxRoom.QxConst.QxConst.Decrypt(ConfigurationManager.AppSettings["PWD"], "powerich");
            this.con = new OracleConnection();
            this.con.ConnectionString = str;
            return this.con;
        }

        public OracleConnection conn(string i)
        {
            string str = ConfigurationManager.AppSettings["DataConn" + i] + QxRoom.QxConst.QxConst.Decrypt(ConfigurationManager.AppSettings["PWD" + i], "powerich");
            this.con = new OracleConnection();
            this.con.ConnectionString = str;
            return this.con;
        }

        public int ExecutionIsSucess(string strSql, Hashtable ht)
        {
            int num;
            try
            {
                OracleCommand command = new OracleCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                IDbDataParameter parameter = null;
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (ht != null)
                {
                    foreach (DictionaryEntry entry in ht)
                    {
                        parameter = command.CreateParameter();
                        parameter.ParameterName = entry.Key.ToString();
                        parameter.Value = entry.Value.ToString();
                        command.Parameters.Add(parameter);
                    }
                }
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public int ExecutionIsSucess(string strSql, OracleParameter[] parameters, string bj)
        {
            int num;
            try
            {
                BindDBNull(parameters);
                OracleCommand command = new OracleCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (OracleParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public static string GetOraclePK(DB_OPT dbo)
        {
            string strSql = "select sys_guid() from dual";
            return dbo.SelectString(strSql, null);
        }

        public void Open()
        {
            if (this.con != null)
            {
                this.con.Open();
            }
        }

        public void OpenTest(string strcon)
        {
            this.con = new OracleConnection();
            this.con.ConnectionString = strcon;
            if (this.con != null)
            {
                this.con.Open();
            }
        }

        public void OracleProcPar(string storedProcName, OracleParameter[] parameters)
        {
            try
            {
                BindDBNull(parameters);
                OracleCommand command = new OracleCommand();
                if (this.con.State == ConnectionState.Closed)
                {
                    this.con.Open();
                }
                command.Connection = this.con;
                command.CommandText = storedProcName;
                command.CommandType = CommandType.StoredProcedure;
                foreach (OracleParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
                this.con.Close();
            }
            catch (Exception exception)
            {
                this.con.Close();
                throw exception;
            }
        }

        public DataSet OracleSelectNoPar(string storedProcName)
        {
            DataSet set;
            try
            {
                DataSet dataSet = new DataSet();
                OracleDataAdapter adapter = new OracleDataAdapter {
                    SelectCommand = new OracleCommand()
                };
                adapter.SelectCommand.Connection = this.con;
                adapter.SelectCommand.CommandText = storedProcName;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (this.st != null)
                {
                    adapter.SelectCommand.Transaction = this.st;
                }
                adapter.Fill(dataSet);
                set = dataSet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public DataSet OracleSelectProcPar(string storedProcName, OracleParameter[] parameters)
        {
            DataSet set;
            try
            {
                BindDBNull(parameters);
                DataSet dataSet = new DataSet();
                OracleDataAdapter adapter = new OracleDataAdapter {
                    SelectCommand = new OracleCommand()
                };
                adapter.SelectCommand.Connection = this.con;
                adapter.SelectCommand.CommandText = storedProcName;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (this.st != null)
                {
                    adapter.SelectCommand.Transaction = this.st;
                }
                foreach (OracleParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.Add(parameter);
                }
                adapter.Fill(dataSet);
                set = dataSet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public void RollBack()
        {
            if (this.con != null)
            {
                this.st.Rollback();
            }
        }

        public string SelectString(string strSql, Hashtable ht)
        {
            string str;
            try
            {
                OracleCommand command = new OracleCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                OracleParameter parameter = null;
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (ht != null)
                {
                    foreach (DictionaryEntry entry in ht)
                    {
                        parameter = command.CreateParameter();
                        parameter.ParameterName = entry.Key.ToString();
                        parameter.Value = entry.Value.ToString();
                        command.Parameters.Add(parameter);
                    }
                }
                string str2 = "";
                object obj2 = command.ExecuteScalar();
                if (obj2 != null)
                {
                    str2 = obj2.ToString();
                }
                str = str2;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public string SelectString(string strSql, OracleParameter[] parameters, string bj)
        {
            string str;
            try
            {
                BindDBNull(parameters);
                OracleCommand command = new OracleCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (OracleParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                string str2 = "";
                object obj2 = command.ExecuteScalar();
                if (obj2 != null)
                {
                    str2 = obj2.ToString();
                }
                str = str2;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public void TranFar()
        {
            if (this.con != null)
            {
                this.st = this.con.BeginTransaction();
            }
        }
    }
}

