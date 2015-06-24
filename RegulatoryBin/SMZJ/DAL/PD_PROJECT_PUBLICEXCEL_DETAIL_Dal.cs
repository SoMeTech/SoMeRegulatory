namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_PUBLICEXCEL_DETAIL_Dal
    {
        public bool Add(PD_PROJECT_PUBLICEXCEL_DETAIL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_PUBLICEXCEL_DETAIL(");
            builder.Append("ID,PID,TABLE_ENAME,TABLE_CNAME,COLUMN_ENAME,COLUMN_CNAME,GETSYSNAME,ISPRIMARY,ISDEFAULTTYPE,DEFAULTDATA)");
            builder.Append(" values (");
            builder.Append(":ID,:PID,:TABLE_ENAME,:TABLE_CNAME,:COLUMN_ENAME,:COLUMN_CNAME,:GETSYSNAME,:ISPRIMARY,:ISDEFAULTTYPE,:DEFAULTDATA)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 4), new OracleParameter(":PID", OracleType.Number, 4), new OracleParameter(":TABLE_ENAME", OracleType.NVarChar), new OracleParameter(":TABLE_CNAME", OracleType.NVarChar), new OracleParameter(":COLUMN_ENAME", OracleType.NVarChar), new OracleParameter(":COLUMN_CNAME", OracleType.NVarChar), new OracleParameter(":GETSYSNAME", OracleType.NVarChar), new OracleParameter(":ISPRIMARY", OracleType.Char, 1), new OracleParameter(":ISDEFAULTTYPE", OracleType.Char, 1), new OracleParameter(":DEFAULTDATA", OracleType.NVarChar) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PID;
            cmdParms[2].Value = model.TABLE_ENAME;
            cmdParms[3].Value = model.TABLE_CNAME;
            cmdParms[4].Value = model.COLUMN_ENAME;
            cmdParms[5].Value = model.COLUMN_CNAME;
            cmdParms[6].Value = model.GETSYSNAME;
            cmdParms[7].Value = model.ISPRIMARY;
            cmdParms[8].Value = model.ISDEFAULTTYPE;
            cmdParms[9].Value = model.DEFAULTDATA;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public PD_PROJECT_PUBLICEXCEL_DETAIL_Model DataRowToModel(DataRow row)
        {
            PD_PROJECT_PUBLICEXCEL_DETAIL_Model model = new PD_PROJECT_PUBLICEXCEL_DETAIL_Model();
            if (row != null)
            {
                if ((row["ID"] != null) && (row["ID"].ToString() != ""))
                {
                    model.ID = decimal.Parse(row["ID"].ToString());
                }
                if ((row["PID"] != null) && (row["PID"].ToString() != ""))
                {
                    model.PID = new decimal?(decimal.Parse(row["PID"].ToString()));
                }
                if (row["TABLE_ENAME"] != null)
                {
                    model.TABLE_ENAME = row["TABLE_ENAME"].ToString();
                }
                if (row["TABLE_CNAME"] != null)
                {
                    model.TABLE_CNAME = row["TABLE_CNAME"].ToString();
                }
                if (row["COLUMN_ENAME"] != null)
                {
                    model.COLUMN_ENAME = row["COLUMN_ENAME"].ToString();
                }
                if (row["COLUMN_CNAME"] != null)
                {
                    model.COLUMN_CNAME = row["COLUMN_CNAME"].ToString();
                }
                if (row["GETSYSNAME"] != null)
                {
                    model.GETSYSNAME = row["GETSYSNAME"].ToString();
                }
                if (row["ISPRIMARY"] != null)
                {
                    model.ISPRIMARY = row["ISPRIMARY"].ToString();
                }
                if (row["ISDEFAULTTYPE"] != null)
                {
                    model.ISDEFAULTTYPE = row["ISDEFAULTTYPE"].ToString();
                }
                if (row["DEFAULTDATA"] != null)
                {
                    model.DEFAULTDATA = row["DEFAULTDATA"].ToString();
                }
            }
            return model;
        }

        public bool Delete(decimal ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_PUBLICEXCEL_DETAIL ");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        internal bool DeleteAll(decimal PID)
        {
            string sQLString = "delete PD_PROJECT_PUBLICEXCEL_DETAIL where pid=:pid";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pid", OracleType.Number, 10) };
            cmdParms[0].Value = PID;
            if (DbHelperOra.ExecuteSql(sQLString, cmdParms) < 1)
            {
                return false;
            }
            return true;
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_PUBLICEXCEL_DETAIL ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(decimal ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_PUBLICEXCEL_DETAIL");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 4) };
            cmdParms[0].Value = ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        internal bool GetCountBool(string sql)
        {
            return DbHelperOra.Exists(sql);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PID,TABLE_ENAME,TABLE_CNAME,COLUMN_ENAME,COLUMN_CNAME,GETSYSNAME,ISPRIMARY,ISDEFAULTTYPE,DEFAULTDATA ");
            builder.Append(" FROM PD_PROJECT_PUBLICEXCEL_DETAIL ");
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
                builder.Append("order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from PD_PROJECT_PUBLICEXCEL_DETAIL T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_PUBLICEXCEL_DETAIL_Model GetModel(decimal ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PID,TABLE_ENAME,TABLE_CNAME,COLUMN_ENAME,COLUMN_CNAME,GETSYSNAME,ISPRIMARY,ISDEFAULTTYPE,DEFAULTDATA from PD_PROJECT_PUBLICEXCEL_DETAIL ");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.Number, 4) };
            cmdParms[0].Value = ID;
            new PD_PROJECT_PUBLICEXCEL_DETAIL_Model();
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
            builder.Append("select count(1) FROM PD_PROJECT_PUBLICEXCEL_DETAIL ");
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

        public bool Update(PD_PROJECT_PUBLICEXCEL_DETAIL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_PUBLICEXCEL_DETAIL set ");
            builder.Append("PID=:PID,");
            builder.Append("TABLE_ENAME=:TABLE_ENAME,");
            builder.Append("TABLE_CNAME=:TABLE_CNAME,");
            builder.Append("COLUMN_ENAME=:COLUMN_ENAME,");
            builder.Append("COLUMN_CNAME=:COLUMN_CNAME,");
            builder.Append("GETSYSNAME=:GETSYSNAME,");
            builder.Append("ISPRIMARY=:ISPRIMARY,");
            builder.Append("ISDEFAULTTYPE=:ISDEFAULTTYPE,");
            builder.Append("DEFAULTDATA=:DEFAULTDATA");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PID", OracleType.Number, 4), new OracleParameter(":TABLE_ENAME", OracleType.NVarChar), new OracleParameter(":TABLE_CNAME", OracleType.NVarChar), new OracleParameter(":COLUMN_ENAME", OracleType.NVarChar), new OracleParameter(":COLUMN_CNAME", OracleType.NVarChar), new OracleParameter(":GETSYSNAME", OracleType.NVarChar), new OracleParameter(":ISPRIMARY", OracleType.Char, 1), new OracleParameter(":ISDEFAULTTYPE", OracleType.Char, 1), new OracleParameter(":DEFAULTDATA", OracleType.NVarChar), new OracleParameter(":ID", OracleType.Number, 4) };
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.TABLE_ENAME;
            cmdParms[2].Value = model.TABLE_CNAME;
            cmdParms[3].Value = model.COLUMN_ENAME;
            cmdParms[4].Value = model.COLUMN_CNAME;
            cmdParms[5].Value = model.GETSYSNAME;
            cmdParms[6].Value = model.ISPRIMARY;
            cmdParms[7].Value = model.ISDEFAULTTYPE;
            cmdParms[8].Value = model.DEFAULTDATA;
            cmdParms[9].Value = model.ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

