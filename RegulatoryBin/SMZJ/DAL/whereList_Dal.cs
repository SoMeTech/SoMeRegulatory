namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using SMZJ.Model;
    using System;
    using System.Data;
    using System.Text;
    using System.Data.OracleClient;

    public class whereList_Dal
    {
        public bool Add(whereList_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into whereList(");
            builder.Append("reportParamPK,columnName,columnType,IsBindDate,DateType,IsQuJian,IsProcParam,IsLike,IsShow,IsGetData,ShowTableName,ShowColumn)");
            builder.Append(" values (");
            builder.Append(":reportParamPK,:columnName,:columnType,:IsBindDate,:DateType,:IsQuJian,:IsProcParam,:IsLike,:IsShow,:IsGetData,:ShowTableName,:ShowColumn)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":reportParamPK", OracleType.Number, 4), new OracleParameter(":columnName", OracleType.VarChar, 0), new OracleParameter(":columnType", OracleType.VarChar, 50), new OracleParameter(":IsBindDate", OracleType.Number,4), new OracleParameter(":DateType", OracleType.VarChar, 50), new OracleParameter(":IsQuJian", OracleType.Number,4), new OracleParameter(":IsProcParam", OracleType.Number,4), new OracleParameter(":IsLike", OracleType.Number,4), new OracleParameter(":IsShow", OracleType.VarChar, 50), new OracleParameter(":IsGetData", OracleType.Number,4), new OracleParameter(":ShowTableName", OracleType.VarChar, 50), new OracleParameter(":ShowColumn", OracleType.VarChar, 0xff) };
            cmdParms[0].Value = model.reportParamPK;
            cmdParms[1].Value = model.columnName;
            cmdParms[2].Value = model.columnType;
            cmdParms[3].Value = model.IsBindDate;
            cmdParms[4].Value = model.DateType;
            cmdParms[5].Value = model.IsQuJian;
            cmdParms[6].Value = model.IsProcParam;
            cmdParms[7].Value = model.IsLike;
            cmdParms[8].Value = model.IsShow;
            cmdParms[9].Value = model.IsGetData;
            cmdParms[10].Value = model.ShowTableName;
            cmdParms[11].Value = model.ShowColumn;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public whereList_Model DataRowToModel(DataRow row)
        {
            whereList_Model model = new whereList_Model();
            if (row != null)
            {
                if ((row["id"] != null) && (row["id"].ToString() != ""))
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if ((row["reportParamPK"] != null) && (row["reportParamPK"].ToString() != ""))
                {
                    model.reportParamPK = new int?(int.Parse(row["reportParamPK"].ToString()));
                }
                if (row["columnName"] != null)
                {
                    model.columnName = row["columnName"].ToString();
                }
                if (row["columnType"] != null)
                {
                    model.columnType = row["columnType"].ToString();
                }
                if ((row["IsBindDate"] != null) && (row["IsBindDate"].ToString().Trim() != ""))
                {
                    model.IsBindDate = byte.Parse(row["IsBindDate"].ToString());
                }
                if (row["DateType"] != null)
                {
                    model.DateType = row["DateType"].ToString();
                }
                if (row["IsQuJian"] != null)
                {
                    model.IsQuJian = byte.Parse(row["IsQuJian"].ToString());
                }
                if (row["IsProcParam"] != null)
                {
                    model.IsProcParam = byte.Parse(row["IsProcParam"].ToString());
                }
                if (row["IsLike"] != null)
                {
                    model.IsLike = byte.Parse(row["IsLike"].ToString());
                }
                if (row["IsShow"] != null)
                {
                    model.IsShow = row["IsShow"].ToString();
                }
                if ((row["IsGetData"] != null) && (row["IsGetData"].ToString().Trim() != ""))
                {
                    model.IsGetData = byte.Parse(row["IsGetData"].ToString());
                }
                if (row["ShowTableName"] != null)
                {
                    model.ShowTableName = row["ShowTableName"].ToString();
                }
                if (row["ShowColumn"] != null)
                {
                    model.ShowColumn = row["ShowColumn"].ToString();
                }
                if (row["ShowWhere"] != null)
                {
                    model.ShowWhere = row["ShowWhere"].ToString();
                }
            }
            return model;
        }

        public bool Delete(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from whereList ");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string idlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from whereList ");
            builder.Append(" where id in (" + idlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from whereList");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,reportParamPK,columnName,columnType,IsBindDate,DateType,IsQuJian,IsProcParam,IsLike,IsShow,IsGetData,ShowTableName,ShowColumn,ShowWhere ");
            builder.Append(" FROM whereList ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by id ");
            return DbHelperOra.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append("order by T." + orderby);
            }
            else
            {
                builder.Append("order by T.id desc");
            }
            builder.Append(")AS Row, T.*  from whereList T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("id", "whereList");
        }

        public whereList_Model GetModel(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,reportParamPK,columnName,columnType,IsBindDate,DateType,IsQuJian,IsProcParam,IsLike,IsShow,IsGetData,ShowTableName,ShowColumn,ShowWhere from whereList ");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            new whereList_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM whereList ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = DbHelperOra.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(whereList_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update whereList set ");
            builder.Append("reportParamPK=:reportParamPK,");
            builder.Append("columnName=:columnName,");
            builder.Append("columnType=:columnType,");
            builder.Append("IsBindDate=:IsBindDate,");
            builder.Append("DateType=:DateType,");
            builder.Append("IsQuJian=:IsQuJian,");
            builder.Append("IsProcParam=:IsProcParam,");
            builder.Append("IsLike=:IsLike,");
            builder.Append("IsShow=:IsShow,");
            builder.Append("IsGetData=:IsGetData,");
            builder.Append("ShowTableName=:ShowTableName,");
            builder.Append("ShowColumn=:ShowColumn");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":reportParamPK", OracleType.Number, 4), new OracleParameter(":columnName", OracleType.VarChar, 0), new OracleParameter(":columnType", OracleType.VarChar, 50), new OracleParameter(":IsBindDate", OracleType.Number,4), new OracleParameter(":DateType", OracleType.VarChar, 50), new OracleParameter(":IsQuJian", OracleType.Number,4), new OracleParameter(":IsProcParam", OracleType.Number,4), new OracleParameter(":IsLike", OracleType.Number,4), new OracleParameter(":IsShow", OracleType.VarChar, 50), new OracleParameter(":IsGetData", OracleType.Number,4), new OracleParameter(":ShowTableName", OracleType.VarChar, 50), new OracleParameter(":ShowColumn", OracleType.VarChar, 0xff), new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = model.reportParamPK;
            cmdParms[1].Value = model.columnName;
            cmdParms[2].Value = model.columnType;
            cmdParms[3].Value = model.IsBindDate;
            cmdParms[4].Value = model.DateType;
            cmdParms[5].Value = model.IsQuJian;
            cmdParms[6].Value = model.IsProcParam;
            cmdParms[7].Value = model.IsLike;
            cmdParms[8].Value = model.IsShow;
            cmdParms[9].Value = model.IsGetData;
            cmdParms[10].Value = model.ShowTableName;
            cmdParms[11].Value = model.ShowColumn;
            cmdParms[12].Value = model.id;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

