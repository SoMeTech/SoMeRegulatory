namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_APPRAISE_DAL
    {
        public void Add(PD_PROJECT_APPRAISE_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_APPRAISE(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_APP_DATE,PD_PROJECT_APP_COMPANY,PD_PROJECT_APP_COMPANY_LIST,PD_PROJECT_APP_MAN_LIST,PD_PROJECT_APPRAISE_FILENO)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_PROJECT_APP_DATE,:PD_PROJECT_APP_COMPANY,:PD_PROJECT_APP_COMPANY_LIST,:PD_PROJECT_APP_MAN_LIST,:PD_PROJECT_APPRAISE_FILENO)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_APP_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_APP_COMPANY", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_APP_COMPANY_LIST", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_APP_MAN_LIST", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_APPRAISE_FILENO", OracleType.VarChar, 100) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_PROJECT_APP_DATE;
            cmdParms[3].Value = model.PD_PROJECT_APP_COMPANY;
            cmdParms[4].Value = model.PD_PROJECT_APP_COMPANY_LIST;
            cmdParms[5].Value = model.PD_PROJECT_APP_MAN_LIST;
            cmdParms[6].Value = model.PD_PROJECT_APPRAISE_FILENO;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_APPRAISE ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_APPRAISE ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_APPRAISE ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Exists(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_APPRAISE");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_APPRAISE");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_APP_DATE,PD_PROJECT_APP_COMPANY,PD_PROJECT_APP_COMPANY_LIST,PD_PROJECT_APP_MAN_LIST,PD_PROJECT_APPRAISE_FILENO ");
            builder.Append(" FROM PD_PROJECT_APPRAISE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "PD_PROJECT_APPRAISE");
        }

        public PD_PROJECT_APPRAISE_Model GetModel(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_APP_DATE,PD_PROJECT_APP_COMPANY,PD_PROJECT_APP_COMPANY_LIST,PD_PROJECT_APP_MAN_LIST,PD_PROJECT_APPRAISE_FILENO from PD_PROJECT_APPRAISE ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_APPRAISE_Model model = new PD_PROJECT_APPRAISE_Model();
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
            if (set.Tables[0].Rows[0]["PD_PROJECT_APP_DATE"].ToString() != "")
            {
                model.PD_PROJECT_APP_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_APP_DATE"].ToString()));
            }
            model.PD_PROJECT_APP_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_APP_COMPANY"].ToString();
            model.PD_PROJECT_APP_COMPANY_LIST = set.Tables[0].Rows[0]["PD_PROJECT_APP_COMPANY_LIST"].ToString();
            model.PD_PROJECT_APP_MAN_LIST = set.Tables[0].Rows[0]["PD_PROJECT_APP_MAN_LIST"].ToString();
            model.PD_PROJECT_APPRAISE_FILENO = set.Tables[0].Rows[0]["PD_PROJECT_APPRAISE_FILENO"].ToString();
            return model;
        }

        public PD_PROJECT_APPRAISE_Model GetModelByProjectCode(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_APP_DATE,PD_PROJECT_APP_COMPANY,PD_PROJECT_APP_COMPANY_LIST,PD_PROJECT_APP_MAN_LIST,PD_PROJECT_APPRAISE_FILENO from PD_PROJECT_APPRAISE ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 20) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            PD_PROJECT_APPRAISE_Model model = new PD_PROJECT_APPRAISE_Model();
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
            if (set.Tables[0].Rows[0]["PD_PROJECT_APP_DATE"].ToString() != "")
            {
                model.PD_PROJECT_APP_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_APP_DATE"].ToString()));
            }
            model.PD_PROJECT_APP_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_APP_COMPANY"].ToString();
            model.PD_PROJECT_APP_COMPANY_LIST = set.Tables[0].Rows[0]["PD_PROJECT_APP_COMPANY_LIST"].ToString();
            model.PD_PROJECT_APP_MAN_LIST = set.Tables[0].Rows[0]["PD_PROJECT_APP_MAN_LIST"].ToString();
            model.PD_PROJECT_APPRAISE_FILENO = set.Tables[0].Rows[0]["PD_PROJECT_APPRAISE_FILENO"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_APPRAISE_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_APPRAISE set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_PROJECT_APP_DATE=:PD_PROJECT_APP_DATE,");
            builder.Append("PD_PROJECT_APP_COMPANY=:PD_PROJECT_APP_COMPANY,");
            builder.Append("PD_PROJECT_APP_COMPANY_LIST=:PD_PROJECT_APP_COMPANY_LIST,");
            builder.Append("PD_PROJECT_APP_MAN_LIST=:PD_PROJECT_APP_MAN_LIST,");
            builder.Append("PD_PROJECT_APPRAISE_FILENO=:PD_PROJECT_APPRAISE_FILENO");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_APP_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_APP_COMPANY", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_APP_COMPANY_LIST", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_APP_MAN_LIST", OracleType.VarChar, 200), new OracleParameter(":PD_PROJECT_APPRAISE_FILENO", OracleType.VarChar, 100), new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_APP_DATE;
            cmdParms[2].Value = model.PD_PROJECT_APP_COMPANY;
            cmdParms[3].Value = model.PD_PROJECT_APP_COMPANY_LIST;
            cmdParms[4].Value = model.PD_PROJECT_APP_MAN_LIST;
            cmdParms[5].Value = model.PD_PROJECT_APPRAISE_FILENO;
            cmdParms[6].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

