namespace SoMeTech.Dictionary.DataDic.DataColumn
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public sealed class DataColumnDal
    {
        public int Add(DataColumnModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into DB_DATACOLUMN(");
            builder.Append("TABLEPK,COLUMNREMARK,COLUMNNAME,REMARK");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + model.TABLEPK + "',");
            builder.Append("'" + model.COLUMNREMARK + "',");
            builder.Append("'" + model.COLUMNNAME + "',");
            builder.Append("'" + model.REMARK + "'");
            builder.Append(")");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Delete(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from DB_DATACOLUMN ");
            builder.Append(" where PK='" + PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }

        public int Exists(string PK, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(PK) from DB_DATACOLUMN");
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

        public DataColumnModel GetModel(DataRow dr)
        {
            return new DataColumnModel { PK = dr["PK"].ToString(), TABLEPK = dr["TABLEPK"].ToString(), COLUMNREMARK = dr["COLUMNREMARK"].ToString(), COLUMNNAME = dr["COLUMNNAME"].ToString(), REMARK = dr["REMARK"].ToString() };
        }

        public DataColumnModel GetModel(string PK, DB_OPT dbo)
        {
            string strSql = this.GetSql() + " where PK=:PK";
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter(":PK", OracleType.Char) };
            parameters[0].Value = PK;
            DataSet set = dbo.BackDataSet(strSql, parameters, "");
            if (set.Tables[0].Rows.Count > 0)
            {
                new DataColumnModel();
                return this.GetModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public DataColumnModel[] GetModels(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.GetSql());
            if (strWhere != "")
            {
                builder.Append(" where " + strWhere);
            }
            OracleParameter[] parameters = null;
            DataSet set = dbo.BackDataSet(builder.ToString(), parameters, "");
            DataColumnModel[] modelArray = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            modelArray = new DataColumnModel[set.Tables[0].Rows.Count];
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                modelArray[i] = new DataColumnModel();
                modelArray[i] = this.GetModel(set.Tables[0].Rows[i]);
            }
            return modelArray;
        }

        public string GetSql()
        {
            return "select PK,TABLEPK,COLUMNREMARK,COLUMNNAME,REMARK FROM DB_DATACOLUMN ";
        }

        public static string GetTableColumns()
        {
            return " PK,TABLEPK,COLUMNREMARK,COLUMNNAME,REMARK ";
        }

        public static string GetViewGOV_TC_VIEW_DATADICColumns()
        {
            return " PK,TABLEPK,TABLEREMARK,COLUMNREMARK,COLUMNNAME,REMARK ";
        }

        public int Update(DataColumnModel model, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update DB_DATACOLUMN set ");
            builder.Append("TABLEPK='" + model.TABLEPK + "',");
            builder.Append("COLUMNREMARK='" + model.COLUMNREMARK + "',");
            builder.Append("COLUMNNAME='" + model.COLUMNNAME + "',");
            builder.Append("REMARK='" + model.REMARK + "'");
            builder.Append(" where PK='" + model.PK + "' ");
            return dbo.ExecutionIsSucess(builder.ToString(), null);
        }
    }
}

