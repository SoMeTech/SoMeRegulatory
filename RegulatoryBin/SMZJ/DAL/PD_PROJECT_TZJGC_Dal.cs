namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_TZJGC_Dal
    {
        public bool Add(PD_PROJECT_TZJGC_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_TZJGC(");
            builder.Append("ID,PD_BASE_TZJGC,TB_QUOTA_ZBWH,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_CODE,TB_QUOTA_CODE)");
            builder.Append(" values (");
            builder.Append(":ID,:PD_BASE_TZJGC,:TB_QUOTA_ZBWH,:PD_PROJECT_MONEY_CZ_SJ,:PD_PROJECT_CODE,:TB_QUOTA_CODE)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.VarChar, 30), new OracleParameter(":PD_BASE_TZJGC", OracleType.Number, 2), new OracleParameter(":TB_QUOTA_ZBWH", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ", OracleType.Number, 0x10), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":TB_QUOTA_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PD_BASE_TZJGC;
            cmdParms[2].Value = model.TB_QUOTA_ZBWH;
            cmdParms[3].Value = model.PD_PROJECT_MONEY_CZ_SJ;
            cmdParms[4].Value = model.PD_PROJECT_CODE;
            cmdParms[5].Value = model.TB_QUOTA_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public PD_PROJECT_TZJGC_Model DataRowToModel(DataRow row)
        {
            PD_PROJECT_TZJGC_Model model = new PD_PROJECT_TZJGC_Model();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if ((row["PD_BASE_TZJGC"] != null) && (row["PD_BASE_TZJGC"].ToString() != ""))
                {
                    model.PD_BASE_TZJGC = new decimal?(decimal.Parse(row["PD_BASE_TZJGC"].ToString()));
                }
                if (row["TB_QUOTA_ZBWH"] != null)
                {
                    model.TB_QUOTA_ZBWH = row["TB_QUOTA_ZBWH"].ToString();
                }
                if ((row["PD_PROJECT_MONEY_CZ_SJ"] != null) && (row["PD_PROJECT_MONEY_CZ_SJ"].ToString() != ""))
                {
                    model.PD_PROJECT_MONEY_CZ_SJ = new decimal?(decimal.Parse(row["PD_PROJECT_MONEY_CZ_SJ"].ToString()));
                }
                if (row["PD_PROJECT_CODE"] != null)
                {
                    model.PD_PROJECT_CODE = row["PD_PROJECT_CODE"].ToString();
                }
                if (row["TB_QUOTA_CODE"] != null)
                {
                    model.TB_QUOTA_CODE = row["TB_QUOTA_CODE"].ToString();
                }
            }
            return model;
        }

        public bool Delete(string ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_TZJGC ");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.VarChar, 30) };
            cmdParms[0].Value = ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteAll(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_TZJGC ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_TZJGC ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_TZJGC");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.VarChar, 30) };
            cmdParms[0].Value = ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PD_BASE_TZJGC,TB_QUOTA_ZBWH,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_CODE,TB_QUOTA_CODE ");
            builder.Append(" FROM PD_PROJECT_TZJGC ");
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
            builder.Append(")AS Row, T.*  from PD_PROJECT_TZJGC T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_TZJGC_Model GetModel(string ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PD_BASE_TZJGC,TB_QUOTA_ZBWH,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_CODE,TB_QUOTA_CODE from PD_PROJECT_TZJGC ");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ID", OracleType.VarChar, 30) };
            cmdParms[0].Value = ID;
            new PD_PROJECT_TZJGC_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        internal DataSet GetProjectList(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT CHECKBOX,PD_BASE_TZJGC,TB_QUOTA_CODE,TB_QUOTA_ZBWH_H,PD_PROJECT_MONEY_CZ_SJ,PD_QUOTA_DEPART_NAME PD_GK_DEPART,PD_QUOTA_BASIS_JG PD_PROJECT_FILENO_JG,PD_QUOTA_ZJLY_NAME PD_PROJECT_ZJLY,PD_QUOTA_ZGKJ_NAME PD_PROJECT_ZGKJ,ISGETQUOTA");
            builder.Append(" FROM V_GETPROJECTLIST_TZJGC");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Query(builder.ToString(), cmdParms);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM PD_PROJECT_TZJGC ");
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

        public bool Update(PD_PROJECT_TZJGC_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_TZJGC set ");
            builder.Append("PD_BASE_TZJGC=:PD_BASE_TZJGC,");
            builder.Append("TB_QUOTA_ZBWH=:TB_QUOTA_ZBWH,");
            builder.Append("PD_PROJECT_MONEY_CZ_SJ=:PD_PROJECT_MONEY_CZ_SJ,");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("TB_QUOTA_CODE=:TB_QUOTA_CODE");
            builder.Append(" where ID=:ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_BASE_TZJGC", OracleType.Number, 2), new OracleParameter(":TB_QUOTA_ZBWH", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ", OracleType.Number, 0x10), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":TB_QUOTA_CODE", OracleType.VarChar, 30), new OracleParameter(":ID", OracleType.VarChar, 30) };
            cmdParms[0].Value = model.PD_BASE_TZJGC;
            cmdParms[1].Value = model.TB_QUOTA_ZBWH;
            cmdParms[2].Value = model.PD_PROJECT_MONEY_CZ_SJ;
            cmdParms[3].Value = model.PD_PROJECT_CODE;
            cmdParms[4].Value = model.TB_QUOTA_CODE;
            cmdParms[5].Value = model.ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

