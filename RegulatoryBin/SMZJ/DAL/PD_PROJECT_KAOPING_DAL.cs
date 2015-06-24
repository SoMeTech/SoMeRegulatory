namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_KAOPING_DAL
    {
        public void Add(PD_PROJECT_KAOPING_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_KAOPING(");
            builder.Append("AUTO_ID,KP_TYPEID,KP_DETAILID,KP_YEAR,KP_COMPANYPK,KH_TYPE,KP_SCORE)");
            builder.Append(" values (");
            builder.Append(":AUTO_ID,:KP_TYPEID,:KP_DETAILID,:KP_YEAR,:KP_COMPANYPK,:KH_TYPE,:KP_SCORE)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4), new OracleParameter(":KP_TYPEID", OracleType.Number, 4), new OracleParameter(":KP_DETAILID", OracleType.Number, 4), new OracleParameter(":KP_YEAR", OracleType.NVarChar), new OracleParameter(":KP_COMPANYPK", OracleType.NVarChar), new OracleParameter(":KH_TYPE", OracleType.NVarChar), new OracleParameter(":KP_SCORE", OracleType.Number, 4) };
            cmdParms[0].Value = model.AUTO_ID;
            cmdParms[1].Value = model.KP_TYPEID;
            cmdParms[2].Value = model.KP_DETAILID;
            cmdParms[3].Value = model.KP_YEAR;
            cmdParms[4].Value = model.KP_COMPANYPK;
            cmdParms[5].Value = model.KH_TYPE;
            cmdParms[6].Value = model.KP_SCORE;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_KAOPING ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_KAOPING ");
            builder.Append(" where AUTO_ID in (" + AUTO_IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_KAOPING");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,KP_TYPEID,KP_DETAILID,KP_YEAR,KP_COMPANYPK,KH_TYPE,KP_SCORE ");
            builder.Append(" FROM PD_PROJECT_KAOPING ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_KAOPING_Model GetModel(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,KP_TYPEID,KP_DETAILID,KP_YEAR,KP_COMPANYPK,KH_TYPE,KP_SCORE from PD_PROJECT_KAOPING ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            PD_PROJECT_KAOPING_Model model = new PD_PROJECT_KAOPING_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_ID"].ToString() != "")
            {
                model.AUTO_ID = new int?(int.Parse(set.Tables[0].Rows[0]["AUTO_ID"].ToString()));
            }
            if (set.Tables[0].Rows[0]["KP_TYPEID"].ToString() != "")
            {
                model.KP_TYPEID = new int?(int.Parse(set.Tables[0].Rows[0]["KP_TYPEID"].ToString()));
            }
            if (set.Tables[0].Rows[0]["KP_DETAILID"].ToString() != "")
            {
                model.KP_DETAILID = new int?(int.Parse(set.Tables[0].Rows[0]["KP_DETAILID"].ToString()));
            }
            model.KP_YEAR = set.Tables[0].Rows[0]["KP_YEAR"].ToString();
            model.KP_COMPANYPK = set.Tables[0].Rows[0]["KP_COMPANYPK"].ToString();
            model.KH_TYPE = set.Tables[0].Rows[0]["KH_TYPE"].ToString();
            if (set.Tables[0].Rows[0]["KP_SCORE"].ToString() != "")
            {
                model.KP_SCORE = new int?(int.Parse(set.Tables[0].Rows[0]["KP_SCORE"].ToString()));
            }
            return model;
        }

        public bool Update(PD_PROJECT_KAOPING_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_KAOPING set ");
            builder.Append("AUTO_ID=:AUTO_ID,");
            builder.Append("KP_TYPEID=:KP_TYPEID,");
            builder.Append("KP_DETAILID=:KP_DETAILID,");
            builder.Append("KP_YEAR=:KP_YEAR,");
            builder.Append("KP_COMPANYPK=:KP_COMPANYPK,");
            builder.Append("KH_TYPE=:KH_TYPE,");
            builder.Append("KP_SCORE=:KP_SCORE");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4), new OracleParameter(":KP_TYPEID", OracleType.Number, 4), new OracleParameter(":KP_DETAILID", OracleType.Number, 4), new OracleParameter(":KP_YEAR", OracleType.NVarChar), new OracleParameter(":KP_COMPANYPK", OracleType.NVarChar), new OracleParameter(":KH_TYPE", OracleType.NVarChar), new OracleParameter(":KP_SCORE", OracleType.Number, 4) };
            cmdParms[0].Value = model.AUTO_ID;
            cmdParms[1].Value = model.KP_TYPEID;
            cmdParms[2].Value = model.KP_DETAILID;
            cmdParms[3].Value = model.KP_YEAR;
            cmdParms[4].Value = model.KP_COMPANYPK;
            cmdParms[5].Value = model.KH_TYPE;
            cmdParms[6].Value = model.KP_SCORE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

