namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using SMZJ.Model;
    using System;
    using System.Data;
    using System.Text;
    using System.Data.OracleClient;

    public class reportParam_Dal
    {
        public bool Add(reportParam_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into reportParam(");
            builder.Append("name,tabelName,tbtype,ShowReportName,columndata,IsOpenShow,ReportSpanRow,IsColumnWhere)");
            builder.Append(" values (");
            builder.Append(":name,:tabelName,:tbtype,:ShowReportName,:columndata,:IsOpenShow,:ReportSpanRow,:IsColumnWhere)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":name", OracleType.VarChar, 50), new OracleParameter(":tabelName", OracleType.VarChar, 50), new OracleParameter(":tbtype", OracleType.VarChar,1), new OracleParameter(":ShowReportName", OracleType.VarChar, 50), new OracleParameter(":columndata", OracleType.VarChar, 0), new OracleParameter(":IsOpenShow", OracleType.Number,4), new OracleParameter(":ReportSpanRow", OracleType.Number,4), new OracleParameter(":IsColumnWhere", OracleType.Number,4) };
            cmdParms[0].Value = model.name;
            cmdParms[1].Value = model.tabelName;
            cmdParms[2].Value = model.tbtype;
            cmdParms[3].Value = model.ShowReportName;
            cmdParms[4].Value = model.columndata;
            cmdParms[5].Value = model.IsOpenShow;
            cmdParms[6].Value = model.ReportSpanRow;
            cmdParms[7].Value = model.IsColumnWhere;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public reportParam_Model DataRowToModel(DataRow row)
        {
            reportParam_Model model = new reportParam_Model();
            if (row != null)
            {
                if ((row["id"] != null) && (row["id"].ToString() != ""))
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["tabelName"] != null)
                {
                    model.tabelName = row["tabelName"].ToString();
                }
                if (row["tbtype"] != null)
                {
                    model.tbtype = row["tbtype"].ToString();
                }
                if (row["ShowReportName"] != null)
                {
                    model.ShowReportName = row["ShowReportName"].ToString();
                }
                if (row["columndata"] != null)
                {
                    model.columndata = row["columndata"].ToString();
                }
                if ((row["IsOpenShow"] != null) && (row["IsOpenShow"].ToString().Trim() != ""))
                {
                    model.IsOpenShow = byte.Parse(row["IsOpenShow"].ToString());
                }
                if ((row["ReportSpanRow"] != null) && (row["ReportSpanRow"].ToString().Trim() != ""))
                {
                    model.ReportSpanRow = int.Parse(row["ReportSpanRow"].ToString());
                }
                if ((row["IsColumnWhere"] != null) && (row["IsColumnWhere"].ToString().Trim() != ""))
                {
                    model.IsColumnWhere = byte.Parse(row["IsColumnWhere"].ToString());
                }
            }
            return model;
        }

        public bool Delete(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from reportParam ");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string idlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from reportParam ");
            builder.Append(" where id in (" + idlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from reportParam");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,name,tabelName,tbtype,ShowReportName,columndata,IsOpenShow,ReportSpanRow,IsColumnWhere ");
            builder.Append(" FROM reportParam ");
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
            builder.Append(")AS Row, T.*  from reportParam T ");
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
            return DbHelperOra.GetMaxID("id", "reportParam");
        }

        public reportParam_Model GetModel(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select id,name,tabelName,tbtype,ShowReportName,columndata,IsOpenShow,ReportSpanRow,IsColumnWhere from reportParam ");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = id;
            new reportParam_Model();
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
            builder.Append("select count(1) FROM reportParam ");
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

        public bool Update(reportParam_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update reportParam set ");
            builder.Append("name=:name,");
            builder.Append("tabelName=:tabelName,");
            builder.Append("tbtype=:tbtype,");
            builder.Append("ShowReportName=:ShowReportName,");
            builder.Append("columndata=;columndata,");
            builder.Append("IsOpenShow=:IsOpenShow,");
            builder.Append("ReportSpanRow=:ReportSpanRow,");
            builder.Append("IsColumnWhere=:IsColumnWhere");
            builder.Append(" where id=:id");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":name", OracleType.VarChar, 50), new OracleParameter(":tabelName", OracleType.VarChar, 50), new OracleParameter(":tbtype", OracleType.VarChar,1), new OracleParameter(":ShowReportName", OracleType.VarChar, 50), new OracleParameter("@columndata", OracleType.VarChar, 0), new OracleParameter(":IsOpenShow", OracleType.Number,4), new OracleParameter(":ReportSpanRow", OracleType.Number), new OracleParameter(":IsColumnWhere", OracleType.Number,4), new OracleParameter(":id", OracleType.Number, 4) };
            cmdParms[0].Value = model.name;
            cmdParms[1].Value = model.tabelName;
            cmdParms[2].Value = model.tbtype;
            cmdParms[3].Value = model.ShowReportName;
            cmdParms[4].Value = model.columndata;
            cmdParms[5].Value = model.IsOpenShow;
            cmdParms[6].Value = model.ReportSpanRow;
            cmdParms[7].Value = model.IsColumnWhere;
            cmdParms[8].Value = model.id;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

