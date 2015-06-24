namespace SoMeTech.Dictionary.DataDic.DataTable
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class DataTableDal
    {
        public int Add(DataTableModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_DATATABLE(");
            builder.Append("TABLEREMARK,TABLENAME,REMARK");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + model.TABLEREMARK + "',");
            builder.Append("'" + model.TABLENAME + "',");
            builder.Append("'" + model.REMARK + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from DB_DATATABLE ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from DB_DATATABLE");
            builder.Append(" where PK=:PK");
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            return dbo.BackIsSelect(builder.ToString(), parameters, "");
        }

        public DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public DataTableModel GetModel(DataRow dr)
        {
            return new DataTableModel { PK = dr["PK"].ToString(), TABLEREMARK = dr["TABLEREMARK"].ToString(), TABLENAME = dr["TABLENAME"].ToString(), REMARK = dr["REMARK"].ToString() };
        }

        public DataTableModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new DataTableModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public DataTableModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            DataTableModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new DataTableModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new DataTableModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,TABLEREMARK,TABLENAME,REMARK FROM DB_DATATABLE ";
        }

        public static string GetTableColumns()
        {
            return " PK,TABLEREMARK,TABLENAME,REMARK ";
        }

        public int Update(DataTableModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_DATATABLE set ");
            builder.Append("TABLEREMARK='" + model.TABLEREMARK + "',");
            builder.Append("TABLENAME='" + model.TABLENAME + "',");
            builder.Append("REMARK='" + model.REMARK + "'");
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

