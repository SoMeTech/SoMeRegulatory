namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_JGYS_DAL
    {
        public void Add(PD_PROJECT_JGYS_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_JGYS(");
            builder.Append("PD_PROJECT_CODE,PD_PROJECT_COMPLETE_DATE,PD_PROJECT_YSSQ_DATE,PD_PROJECT_YS_DATE,PD_PROJECT_YS_COMPANY,PD_PROJECT_YS_ZRR,PD_PROJECT_YS_NAME,PD_PROJECT_YS_SUGGEST,PD_PROJECT_YS_RESULT,PD_PROJECT_YS_CONDITION)");
            builder.Append(" values (");
            builder.Append(":PD_PROJECT_CODE,:PD_PROJECT_COMPLETE_DATE,:PD_PROJECT_YSSQ_DATE,:PD_PROJECT_YS_DATE,:PD_PROJECT_YS_COMPANY,:PD_PROJECT_YS_ZRR,:PD_PROJECT_YS_NAME,:PD_PROJECT_YS_SUGGEST,:PD_PROJECT_YS_RESULT,:PD_PROJECT_YS_CONDITION)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_COMPLETE_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YSSQ_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YS_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YS_COMPANY", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_YS_ZRR", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_YS_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_YS_SUGGEST", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_YS_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_YS_CONDITION", OracleType.VarChar, 100) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_COMPLETE_DATE;
            cmdParms[2].Value = model.PD_PROJECT_YSSQ_DATE;
            cmdParms[3].Value = model.PD_PROJECT_YS_DATE;
            cmdParms[4].Value = model.PD_PROJECT_YS_COMPANY;
            cmdParms[5].Value = model.PD_PROJECT_YS_ZRR;
            cmdParms[6].Value = model.PD_PROJECT_YS_NAME;
            cmdParms[7].Value = model.PD_PROJECT_YS_SUGGEST;
            cmdParms[8].Value = model.PD_PROJECT_YS_RESULT;
            cmdParms[9].Value = model.PD_PROJECT_YS_CONDITION;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_JGYS ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_JGYS ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_JGYS");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_COMPLETE_DATE,PD_PROJECT_YSSQ_DATE,PD_PROJECT_YS_DATE,PD_PROJECT_YS_COMPANY,PD_PROJECT_YS_ZRR,PD_PROJECT_YS_NAME,PD_PROJECT_YS_SUGGEST,PD_PROJECT_YS_RESULT,PD_PROJECT_YS_CONDITION ");
            builder.Append(" FROM PD_PROJECT_JGYS ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "PD_PROJECT_JGYS");
        }

        public PD_PROJECT_JGYS_Model GetModel(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_COMPLETE_DATE,PD_PROJECT_YSSQ_DATE,PD_PROJECT_YS_DATE,PD_PROJECT_YS_COMPANY,PD_PROJECT_YS_ZRR,PD_PROJECT_YS_NAME,PD_PROJECT_YS_SUGGEST,PD_PROJECT_YS_RESULT,PD_PROJECT_YS_CONDITION from PD_PROJECT_JGYS ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            PD_PROJECT_JGYS_Model model = new PD_PROJECT_JGYS_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                model.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_COMPLETE_DATE"].ToString() != "")
            {
                model.PD_PROJECT_COMPLETE_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_COMPLETE_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_YSSQ_DATE"].ToString() != "")
            {
                model.PD_PROJECT_YSSQ_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_YSSQ_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_YS_DATE"].ToString() != "")
            {
                model.PD_PROJECT_YS_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_YS_DATE"].ToString()));
            }
            model.PD_PROJECT_YS_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_YS_COMPANY"].ToString();
            model.PD_PROJECT_YS_ZRR = set.Tables[0].Rows[0]["PD_PROJECT_YS_ZRR"].ToString();
            model.PD_PROJECT_YS_NAME = set.Tables[0].Rows[0]["PD_PROJECT_YS_NAME"].ToString();
            model.PD_PROJECT_YS_SUGGEST = set.Tables[0].Rows[0]["PD_PROJECT_YS_SUGGEST"].ToString();
            model.PD_PROJECT_YS_RESULT = set.Tables[0].Rows[0]["PD_PROJECT_YS_RESULT"].ToString();
            model.PD_PROJECT_YS_CONDITION = set.Tables[0].Rows[0]["PD_PROJECT_YS_CONDITION"].ToString();
            return model;
        }

        public PD_PROJECT_JGYS_Model GetModelByProCode(string projectCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_COMPLETE_DATE,PD_PROJECT_YSSQ_DATE,PD_PROJECT_YS_DATE,PD_PROJECT_YS_COMPANY,PD_PROJECT_YS_ZRR,PD_PROJECT_YS_NAME,PD_PROJECT_YS_SUGGEST,PD_PROJECT_YS_RESULT,PD_PROJECT_YS_CONDITION from PD_PROJECT_JGYS ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 20) };
            cmdParms[0].Value = projectCode;
            PD_PROJECT_JGYS_Model model = new PD_PROJECT_JGYS_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                model.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_COMPLETE_DATE"].ToString() != "")
            {
                model.PD_PROJECT_COMPLETE_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_COMPLETE_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_YSSQ_DATE"].ToString() != "")
            {
                model.PD_PROJECT_YSSQ_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_YSSQ_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_YS_DATE"].ToString() != "")
            {
                model.PD_PROJECT_YS_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_YS_DATE"].ToString()));
            }
            model.PD_PROJECT_YS_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_YS_COMPANY"].ToString();
            model.PD_PROJECT_YS_ZRR = set.Tables[0].Rows[0]["PD_PROJECT_YS_ZRR"].ToString();
            model.PD_PROJECT_YS_NAME = set.Tables[0].Rows[0]["PD_PROJECT_YS_NAME"].ToString();
            model.PD_PROJECT_YS_SUGGEST = set.Tables[0].Rows[0]["PD_PROJECT_YS_SUGGEST"].ToString();
            model.PD_PROJECT_YS_RESULT = set.Tables[0].Rows[0]["PD_PROJECT_YS_RESULT"].ToString();
            model.PD_PROJECT_YS_CONDITION = set.Tables[0].Rows[0]["PD_PROJECT_YS_CONDITION"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_JGYS_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_JGYS set ");
            builder.Append("PD_PROJECT_COMPLETE_DATE=:PD_PROJECT_COMPLETE_DATE,");
            builder.Append("PD_PROJECT_YSSQ_DATE=:PD_PROJECT_YSSQ_DATE,");
            builder.Append("PD_PROJECT_YS_DATE=:PD_PROJECT_YS_DATE,");
            builder.Append("PD_PROJECT_YS_COMPANY=:PD_PROJECT_YS_COMPANY,");
            builder.Append("PD_PROJECT_YS_ZRR=:PD_PROJECT_YS_ZRR,");
            builder.Append("PD_PROJECT_YS_NAME=:PD_PROJECT_YS_NAME,");
            builder.Append("PD_PROJECT_YS_SUGGEST=:PD_PROJECT_YS_SUGGEST,");
            builder.Append("PD_PROJECT_YS_RESULT=:PD_PROJECT_YS_RESULT,");
            builder.Append("PD_PROJECT_YS_CONDITION=:PD_PROJECT_YS_CONDITION");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_COMPLETE_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YSSQ_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YS_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YS_COMPANY", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_YS_ZRR", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_YS_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_YS_SUGGEST", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_YS_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_YS_CONDITION", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = model.PD_PROJECT_COMPLETE_DATE;
            cmdParms[1].Value = model.PD_PROJECT_YSSQ_DATE;
            cmdParms[2].Value = model.PD_PROJECT_YS_DATE;
            cmdParms[3].Value = model.PD_PROJECT_YS_COMPANY;
            cmdParms[4].Value = model.PD_PROJECT_YS_ZRR;
            cmdParms[5].Value = model.PD_PROJECT_YS_NAME;
            cmdParms[6].Value = model.PD_PROJECT_YS_SUGGEST;
            cmdParms[7].Value = model.PD_PROJECT_YS_RESULT;
            cmdParms[8].Value = model.PD_PROJECT_YS_CONDITION;
            cmdParms[9].Value = model.PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

