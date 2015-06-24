namespace BHSoft.BHWeb.Common.Data
{
    using BHSoft.BHWeb.Common.CommonClasses;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Threading;

    public abstract class DBBase
    {
        protected OleDbConnection _connection;
        protected OleDbTransaction _transaction;
        protected string DB_Driver_Type;
        private static readonly object DbThread = new object();

        public DBBase()
        {
            this._connection = null;
            this._transaction = null;
            this.DB_Driver_Type = "OleDb";
        }

        public DBBase(IDbConnection conn)
        {
            this._connection = null;
            this._transaction = null;
            this.DB_Driver_Type = "OleDb";
            this._connection = (OleDbConnection) conn;
        }

        public DBBase(IDbConnection conn, IDbTransaction tran)
        {
            this._connection = null;
            this._transaction = null;
            this.DB_Driver_Type = "OleDb";
            this._connection = (OleDbConnection) conn;
            this._transaction = (OleDbTransaction) tran;
        }

        public IDbTransaction BeginTran()
        {
            if (this._connection != null)
            {
                this._transaction = this._connection.BeginTransaction();
                return this._transaction;
            }
            return null;
        }

        protected string CreateSQL(string table, DBTableData data, int type)
        {
            int num;
            string format = "";
            string str2 = "";
            string str3 = "";
            switch (type)
            {
                case 0:
                    format = "INSERT INTO " + table + "(";
                    for (num = 0; num < data.Count; num++)
                    {
                        if (!data.GetKeys(num).Substring(0, 1).Equals("&"))
                        {
                            if (num > 0)
                            {
                                format = format + "," + data.GetKeys(num).Substring(1);
                                str2 = str2 + ", ?";
                            }
                            else
                            {
                                format = format + data.GetKeys(num).Substring(1);
                                str2 = str2 + " ?";
                            }
                        }
                    }
                    return (format + ") VALUES (" + str2 + ")");

                case 1:
                    format = "UPDATE " + table + " SET {0} WHERE 1 = 1 {1}";
                    for (num = 0; num < data.Count; num++)
                    {
                        if (data.GetKeys(num).Substring(0, 1).Equals("#"))
                        {
                            if (str2.Length == 0)
                            {
                                str2 = str2 + "  " + data.GetKeys(num).Substring(1) + " = ? ";
                            }
                            else
                            {
                                str2 = str2 + ", " + data.GetKeys(num).Substring(1) + " = ? ";
                            }
                        }
                        else
                        {
                            str3 = str3 + " AND " + data.GetKeys(num).Substring(1) + " = ? ";
                        }
                    }
                    return string.Format(format, str2, str3);

                case 2:
                    format = "DELETE FROM " + table + " WHERE 1 = 1 {0}";
                    for (num = 0; num < data.Count; num++)
                    {
                        str2 = str2 + " AND " + data.GetKeys(num).Substring(1) + " = ? ";
                    }
                    return string.Format(format, str2);

                case 3:
                    format = "SELECT {0} FROM " + table + " WHERE 1 = 1 {1} ";
                    for (num = 0; num < data.Count; num++)
                    {
                        if (data.GetKeys(num).Substring(0, 1).Equals("#"))
                        {
                            if (str2.Length == 0)
                            {
                                str2 = str2 + "  " + data.GetKeys(num).Substring(1);
                            }
                            else
                            {
                                str2 = str2 + ", " + data.GetKeys(num).Substring(1);
                            }
                        }
                        else
                        {
                            str3 = str3 + " AND " + data.GetKeys(num).Substring(1) + " = ? ";
                        }
                    }
                    if (str2.Length == 0)
                    {
                        str2 = " * ";
                    }
                    return string.Format(format, str2, str3);
            }
            return format;
        }

        protected int executeNonQuerySql(string sql)
        {
            return this.executeNonQuerySql(sql, null);
        }

        protected int executeNonQuerySql(string sql, IDataParameter[] parameters)
        {
            OleDbCommand command = null;
            Exception exception;
            int num = 0;
            try
            {
                log.DebugLog(sql);
                command = new OleDbCommand {
                    CommandType = CommandType.Text,
                    CommandText = sql
                };
                if (parameters != null)
                {
                    foreach (OleDbParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                if (this._connection == null)
                {
                    log.DebugLog("数据库连接已经为空，无法更新数据。");
                    return -1;
                }
                command.Connection = this._connection;
                command.Transaction = this._transaction;
                lock (DbThread)
                {
                    if (this.WaitDb(this._connection))
                    {
                        try
                        {
                            num = command.ExecuteNonQuery();
                            log.DebugLog(num + "条数据被更新了。  ");
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                            log.ErrorLog(exception.Message);
                        }
                        return num;
                    }
                    return -1;
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                log.ErrorLog(exception.Message);
            }
            finally
            {
                if (command != null)
                {
                    command.Parameters.Clear();
                    command.Dispose();
                }
            }
            return num;
        }

        protected DataTable executeQuerySql(string sql)
        {
            return this.executeQuerySql(sql, null);
        }

        protected DataTable executeQuerySql(string sql, IDataParameter[] parameters)
        {
            return this.executeQuerySql(sql, parameters, -1, -1, "");
        }

        protected DataTable executeQuerySql(string sql, IDataParameter[] parameters, int startRow, int maxRow, string tableName)
        {
            OleDbCommand selectCommand = null;
            OleDbDataAdapter adapter = null;
            Exception exception;
            DataTable dataTable = new DataTable();
            try
            {
                log.DebugLog(sql);
                selectCommand = new OleDbCommand {
                    CommandText = sql
                };
                if (parameters != null)
                {
                    log.DebugLog("==============OleDbParameter===============");
                    foreach (OleDbParameter parameter in parameters)
                    {
                        log.DebugLog(parameter.ParameterName + ": " + parameter.Value);
                        selectCommand.Parameters.Add(parameter);
                    }
                    log.DebugLog("==========================================");
                }
                if (this._connection == null)
                {
                    return dataTable;
                }
                selectCommand.Connection = this._connection;
                selectCommand.Transaction = this._transaction;
                lock (DbThread)
                {
                    if (this.WaitDb(this._connection))
                    {
                        try
                        {
                            dataTable = new DataTable();
                            adapter = new OleDbDataAdapter(selectCommand);
                            if ((startRow == -1) && (maxRow == -1))
                            {
                                adapter.Fill(dataTable);
                            }
                            else
                            {
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet, startRow, maxRow, tableName);
                                dataTable = dataSet.Tables[0];
                            }
                            log.DebugLog(string.Concat(new object[] { "从", dataTable.TableName, "表中，取得", dataTable.Rows.Count, "条数据。" }));
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                            log.ErrorLog(exception.Message);
                        }
                        finally
                        {
                            if (adapter != null)
                            {
                                adapter.Dispose();
                            }
                            if (selectCommand != null)
                            {
                                selectCommand.Parameters.Clear();
                                selectCommand.Dispose();
                            }
                        }
                    }
                    return dataTable;
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                log.ErrorLog(exception);
            }
            finally
            {
                if (selectCommand != null)
                {
                    selectCommand.Parameters.Clear();
                    selectCommand.Dispose();
                }
            }
            return dataTable;
        }

        protected IDataParameter[] NewParameter(int size)
        {
            return this.NewParameter(size, null);
        }

        protected IDataParameter[] NewParameter(int size, DBTableData data)
        {
            int index = 0;
            IDataParameter[] parameterArray = new OleDbParameter[size];
            for (int i = 0; i < size; i++)
            {
                parameterArray[i] = new OleDbParameter();
                if ((data != null) && !data.GetKeys(i).Substring(0, 1).Equals("&"))
                {
                    parameterArray[index].ParameterName = data.GetKeys(i);
                    parameterArray[index].Value = data.GetValues(i);
                    parameterArray[index].DbType = data.GetTypes(i);
                    index++;
                }
            }
            return parameterArray;
        }

        private bool WaitDb(IDbConnection conn)
        {
            try
            {
                for (int i = 1; i < 30; i++)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        log.DebugLog("取得正确可以使用的连接！ ");
                        return true;
                    }
                    Thread.Sleep(0x3e8);
                    log.DebugLog(string.Concat(new object[] { "没有取到正常的连接，重试", i.ToString(), " 连接状态为：", conn.State }));
                }
            }
            catch (Exception exception)
            {
                log.ErrorLog(exception.Message);
            }
            return false;
        }
    }
}

