namespace SoMeTech.DataAccess
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;

    public class DB_OPT
    {
        private DB_Oracle db_ora;
        private DB_Sql db_sql;
        private static DataBaseType dbt = DataBaseType.Oracle;

        public DB_OPT()
        {
            this.db_ora = new DB_Oracle();
            this.db_sql = new DB_Sql();
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.conn();
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.conn();
                    return;
            }
            this.db_ora.conn();
        }

        public DB_OPT(string i)
        {
            this.db_ora = new DB_Oracle();
            this.db_sql = new DB_Sql();
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.conn(i);
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.conn(i);
                    return;
            }
            this.db_ora.conn(i);
        }

        public DB_OPT(string i, string databaseName, DataBaseType databasetype)
        {
            this.db_ora = new DB_Oracle();
            this.db_sql = new DB_Sql();
            switch (databasetype)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.conn(i, databaseName);
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.conn(i);
                    return;
            }
            this.db_ora.conn(i);
        }

        public DataSet BackDataSet(string strSql, Hashtable ht)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.BackDataSet(strSql, ht);

                case DataBaseType.Oracle:
                    return this.db_ora.BackDataSet(strSql, ht);
            }
            return this.db_ora.BackDataSet(strSql, ht);
        }

        public DataSet BackDataSet(string strSql, object parameters, string bj)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.BackDataSet(strSql, (SqlParameter[]) parameters, bj);

                case DataBaseType.Oracle:
                    return this.db_ora.BackDataSet(strSql, (OracleParameter[]) parameters, bj);
            }
            return this.db_ora.BackDataSet(strSql, (OracleParameter[]) parameters, bj);
        }

        public int BackIsSelect(string strSql, Hashtable ht)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.BackIsSelect(strSql, ht);

                case DataBaseType.Oracle:
                    return this.db_ora.BackIsSelect(strSql, ht);
            }
            return this.db_ora.BackIsSelect(strSql, ht);
        }

        public int BackIsSelect(string strSql, object parameters, string bj)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.BackIsSelect(strSql, (SqlParameter[]) parameters, bj);

                case DataBaseType.Oracle:
                    return this.db_ora.BackIsSelect(strSql, (OracleParameter[]) parameters, bj);
            }
            return this.db_ora.BackIsSelect(strSql, (OracleParameter[]) parameters, bj);
        }

        public int BuildQueryCommand(string storedProcName, object parameters)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.BuildQueryCommand(storedProcName, (SqlParameter[]) parameters);

                case DataBaseType.Oracle:
                    return this.db_ora.BuildQueryCommand(storedProcName, (OracleParameter[]) parameters);
            }
            return this.db_ora.BuildQueryCommand(storedProcName, (OracleParameter[]) parameters);
        }

        public void Close()
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.Close();
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.Close();
                    return;
            }
            this.db_ora.Close();
        }

        public void Commit()
        {
            try
            {
                switch (dbt)
                {
                    case DataBaseType.SqlServer:
                        this.db_sql.Commit();
                        return;

                    case DataBaseType.Oracle:
                        this.db_ora.Commit();
                        return;
                }
                this.db_ora.Commit();
            }
            catch (Exception)
            {
            }
        }

        public int ExecuteSql(string strSql, object parameters)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.ExecutionIsSucess(strSql, (SqlParameter[]) parameters, null);

                case DataBaseType.Oracle:
                    return this.db_ora.ExecutionIsSucess(strSql, (OracleParameter[]) parameters, null);
            }
            return this.db_ora.ExecutionIsSucess(strSql, (OracleParameter[]) parameters, null);
        }

        public int ExecutionIsSucess(string strSql, Hashtable ht)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.ExecutionIsSucess(strSql, ht);

                case DataBaseType.Oracle:
                    return this.db_ora.ExecutionIsSucess(strSql, ht);
            }
            return this.db_ora.ExecutionIsSucess(strSql, ht);
        }

        public int ExecutionIsSucess(string strSql, object parameters, string bj)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.ExecutionIsSucess(strSql, (SqlParameter[]) parameters, bj);

                case DataBaseType.Oracle:
                    return this.db_ora.ExecutionIsSucess(strSql, (OracleParameter[]) parameters, bj);
            }
            return this.db_ora.ExecutionIsSucess(strSql, (OracleParameter[]) parameters, bj);
        }

        public bool Exists(string strSql, object parameters)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return (this.db_sql.BackIsSelect(strSql, (SqlParameter[]) parameters, null) == 1);

                case DataBaseType.Oracle:
                    return (this.db_ora.BackIsSelect(strSql, (OracleParameter[]) parameters, null) == 1);
            }
            return (this.db_ora.BackIsSelect(strSql, (OracleParameter[]) parameters, null) == 1);
        }

        public void Open()
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.Open();
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.Open();
                    return;
            }
            this.db_ora.Open();
        }

        public void OpenTest(string strcon)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.OpenTest(strcon);
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.OpenTest(strcon);
                    return;
            }
            this.db_ora.OpenTest(strcon);
        }

        public DataSet Query(string strSql, object parameters)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.BackDataSet(strSql, (SqlParameter[]) parameters, null);

                case DataBaseType.Oracle:
                    return this.db_ora.BackDataSet(strSql, (OracleParameter[]) parameters, null);
            }
            return this.db_ora.BackDataSet(strSql, (OracleParameter[]) parameters, null);
        }

        public void RollBack()
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.RollBack();
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.RollBack();
                    return;
            }
            this.db_ora.RollBack();
        }

        public string SelectString(string strSql, Hashtable ht)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.SelectString(strSql, ht);

                case DataBaseType.Oracle:
                    return this.db_ora.SelectString(strSql, ht);
            }
            return this.db_ora.SelectString(strSql, ht);
        }

        public string SelectString(string strSql, object parameters, string bj)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.SelectString(strSql, (SqlParameter[]) parameters, bj);

                case DataBaseType.Oracle:
                    return this.db_ora.SelectString(strSql, (OracleParameter[]) parameters, bj);
            }
            return this.db_ora.SelectString(strSql, (OracleParameter[]) parameters, bj);
        }

        public void SqlProcPar(string storedProcName, object parameters)
        {
            this.db_ora.OracleProcPar(storedProcName, (OracleParameter[]) parameters);
        }

        public DataSet SqlSelectNoPar(string storedProcName)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.SqlSelectNoPar(storedProcName);

                case DataBaseType.Oracle:
                    return this.db_ora.OracleSelectNoPar(storedProcName);
            }
            return this.db_ora.OracleSelectNoPar(storedProcName);
        }

        public DataSet SqlSelectProcPar(string storedProcName, object parameters)
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    return this.db_sql.SqlSelectProcPar(storedProcName, (SqlParameter[]) parameters);

                case DataBaseType.Oracle:
                    return this.db_ora.OracleSelectProcPar(storedProcName, (OracleParameter[]) parameters);
            }
            return this.db_ora.OracleSelectProcPar(storedProcName, (OracleParameter[]) parameters);
        }

        public void TranFar()
        {
            switch (dbt)
            {
                case DataBaseType.SqlServer:
                    this.db_sql.TranFar();
                    return;

                case DataBaseType.Oracle:
                    this.db_ora.TranFar();
                    return;
            }
            this.db_ora.TranFar();
        }

        public static DataBaseType DBT
        {
            get
            {
                return dbt;
            }
            set
            {
                dbt = value;
            }
        }
    }
}

