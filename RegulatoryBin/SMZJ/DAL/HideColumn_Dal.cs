namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using SMZJ.Model;
    using System;
    using System.Data;
    using System.Text;
    using System.Data.OracleClient;
    public class HideColumn_Dal
    {
        public int Add(HideColumn_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into HIDECOLUMN(");
            builder.Append("ID,REPORTPARAMPK,COLUMNNAME)");
            builder.Append(" values (");
            builder.Append(":REPORTPARAMPK,:COLUMNNAME)");
            OracleParameter[] cmdParms = {
					new OracleParameter(":REPORTPARAMPK", OracleType.Number,4),
					new OracleParameter(":COLUMNNAME", OracleType.VarChar,50)};
            cmdParms[0].Value = model.reportParamPK;
            cmdParms[1].Value = model.ColumnName;
            return DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public HideColumn_Model DataRowToModel(DataRow row)
        {
            HideColumn_Model model = new HideColumn_Model();
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
                if (row["ColumnName"] != null)
                {
                    model.ColumnName = row["ColumnName"].ToString();
                }
            }
            return model;
        }

        public bool Delete(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from HideColumn ");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string idlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from HideColumn ");
            builder.Append(" where id in (" + idlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from HideColumn");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,reportParamPK,ColumnName ");
            builder.Append(" FROM HideColumn ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
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
            builder.Append(")AS Row, T.*  from HideColumn T ");
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
            return DbHelperOra.GetMaxID("id", "HideColumn");
        }

        public HideColumn_Model GetModel(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,reportParamPK,ColumnName from HideColumn ");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            new HideColumn_Model();
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
            builder.Append("select count(1) FROM HideColumn ");
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

        public bool Update(HideColumn_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update HideColumn set ");
            builder.Append("reportParamPK=:reportParamPK,");
            builder.Append("ColumnName=:ColumnName");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":reportParamPK", OracleType.Number, 4), new OracleParameter(":ColumnName", OracleType.VarChar, 50), new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = model.reportParamPK;
            cmdParms[1].Value = model.ColumnName;
            cmdParms[2].Value = model.id;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

