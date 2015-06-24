namespace SoMeTech.DataAccess
{
    using QxRoom.QxConst;
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public sealed class DB_Sql
    {
        public SqlConnection con;
        public SqlTransaction st;

        public DataSet BackDataSet(string strSql, Hashtable ht)
        {
            DataSet set;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlParameter parameter = null;
                adapter.SelectCommand = new SqlCommand();
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

        public DataSet BackDataSet(string strSql, SqlParameter[] parameters, string bj)
        {
            DataSet set;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter {
                    SelectCommand = new SqlCommand()
                };
                adapter.SelectCommand.CommandText = strSql;
                adapter.SelectCommand.Connection = this.con;
                if (this.st != null)
                {
                    adapter.SelectCommand.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
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
                SqlCommand command = new SqlCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                SqlParameter parameter = null;
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

        public int BackIsSelect(string strSql, SqlParameter[] parameters, string bj)
        {
            int num;
            try
            {
                SqlCommand command = new SqlCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
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

        public int BuildQueryCommand(string storedProcName, SqlParameter[] parameters)
        {
            int num;
            try
            {
                SqlCommand command = new SqlCommand {
                    CommandText = storedProcName,
                    Connection = this.con,
                    CommandType = CommandType.StoredProcedure
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                foreach (SqlParameter parameter in parameters)
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

        public SqlConnection conn()
        {
            string str = ConfigurationManager.AppSettings["DataConn"] + QxRoom.QxConst.QxConst.Decrypt(ConfigurationManager.AppSettings["PWD"], "powerich");
            this.con = new SqlConnection();
            this.con.ConnectionString = str;
            return this.con;
        }

        public SqlConnection conn(string i)
        {
            string str = ConfigurationManager.AppSettings["DataConn" + i] + QxRoom.QxConst.QxConst.Decrypt(ConfigurationManager.AppSettings["PWD" + i], "powerich");
            this.con = new SqlConnection();
            this.con.ConnectionString = str;
            return this.con;
        }

        public SqlConnection conn(string i, string database)
        {
            string str = ConfigurationManager.AppSettings["DataConn" + i] + QxRoom.QxConst.QxConst.Decrypt(ConfigurationManager.AppSettings["PWD" + i], "powerich") + ";database=" + database;
            this.con = new SqlConnection();
            this.con.ConnectionString = str;
            return this.con;
        }

        public int ExecutionIsSucess(string strSql, Hashtable ht)
        {
            int num;
            try
            {
                SqlCommand command = new SqlCommand {
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

        public int ExecutionIsSucess(string strSql, SqlParameter[] parameters, string bj)
        {
            int num;
            try
            {
                SqlCommand command = new SqlCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
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

        public static string GetSqlPK(DB_OPT dbo)
        {
            string strSql = "select newid()";
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
            this.con = new SqlConnection();
            this.con.ConnectionString = strcon;
            if (this.con != null)
            {
                this.con.Open();
            }
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
                SqlCommand command = new SqlCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                SqlParameter parameter = null;
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

        public string SelectString(string strSql, SqlParameter[] parameters, string bj)
        {
            string str;
            try
            {
                SqlCommand command = new SqlCommand {
                    CommandText = strSql,
                    Connection = this.con
                };
                if (this.st != null)
                {
                    command.Transaction = this.st;
                }
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
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

        public DataSet SqlSelectNoPar(string storedProcName)
        {
            DataSet set;
            try
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter {
                    SelectCommand = new SqlCommand()
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

        public DataSet SqlSelectProcPar(string storedProcName, SqlParameter[] parameters)
        {
            DataSet set;
            try
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter {
                    SelectCommand = new SqlCommand()
                };
                adapter.SelectCommand.Connection = this.con;
                adapter.SelectCommand.CommandText = storedProcName;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (this.st != null)
                {
                    adapter.SelectCommand.Transaction = this.st;
                }
                foreach (SqlParameter parameter in parameters)
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

        public void TranFar()
        {
            if (this.con != null)
            {
                this.st = this.con.BeginTransaction();
            }
        }
    }
}

