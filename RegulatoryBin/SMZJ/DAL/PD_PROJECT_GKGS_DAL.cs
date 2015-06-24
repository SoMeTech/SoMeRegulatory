namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_GKGS_DAL
    {
        public bool Add(PD_PROJECT_GKGS_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_GKGS(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_TYPE,PD_GS_TYPE,PD_GS_STYLE,PD_GS_ZHUTI,PD_GS_DATE,PD_GS_ADDR,PD_GS_FILENAME,PD_GS_FILENAME_SYSTEM,PD_GS_DETAIL,PD_GS_DATE_END)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_PROJECT_TYPE,:PD_GS_TYPE,:PD_GS_STYLE,:PD_GS_ZHUTI,:PD_GS_DATE,:PD_GS_ADDR,:PD_GS_FILENAME,:PD_GS_FILENAME_SYSTEM,:PD_GS_DETAIL,:PD_GS_DATE_END)");
            builder.Append(" RETURNING AUTO_NO INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar), new OracleParameter(":PD_PROJECT_TYPE", OracleType.Number, 4), new OracleParameter(":PD_GS_TYPE", OracleType.Number, 4), new OracleParameter(":PD_GS_STYLE", OracleType.NVarChar), new OracleParameter(":PD_GS_ZHUTI", OracleType.NVarChar), new OracleParameter(":PD_GS_DATE", OracleType.DateTime), new OracleParameter(":PD_GS_ADDR", OracleType.NVarChar), new OracleParameter(":PD_GS_FILENAME", OracleType.NVarChar), new OracleParameter(":PD_GS_FILENAME_SYSTEM", OracleType.NVarChar), new OracleParameter(":PD_GS_DETAIL", OracleType.NVarChar), new OracleParameter(":PD_GS_DATE_END", OracleType.DateTime), new OracleParameter(":R_Auto_No", OracleType.Number, 20) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_PROJECT_TYPE;
            cmdParms[3].Value = model.PD_GS_TYPE;
            cmdParms[4].Value = model.PD_GS_STYLE;
            cmdParms[5].Value = model.PD_GS_ZHUTI;
            cmdParms[6].Value = model.PD_GS_DATE;
            cmdParms[7].Value = model.PD_GS_ADDR;
            cmdParms[8].Value = model.PD_GS_FILENAME;
            cmdParms[9].Value = model.PD_GS_FILENAME_SYSTEM;
            cmdParms[10].Value = model.PD_GS_DETAIL;
            cmdParms[11].Value = model.PD_GS_DATE_END;
            cmdParms[12].Direction = ParameterDirection.Output;
            int num = DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.AUTO_NO = int.Parse(cmdParms[12].Value.ToString());
            return (num > 0);
        }

        public bool Delete(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_GKGS ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_GKGS ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_GKGS");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_TYPE,PD_GS_TYPE,PD_GS_STYLE,PD_GS_ZHUTI,PD_GS_DATE,PD_GS_ADDR,PD_GS_FILENAME,PD_GS_FILENAME_SYSTEM,PD_GS_DETAIL,PD_GS_DATE_END ");
            builder.Append(" FROM PD_PROJECT_GKGS ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "PD_PROJECT_GKGS");
        }

        public PD_PROJECT_GKGS_Model GetModel(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_TYPE,PD_GS_TYPE,PD_GS_STYLE,PD_GS_ZHUTI,PD_GS_DATE,PD_GS_ADDR,PD_GS_FILENAME,PD_GS_FILENAME_SYSTEM,PD_GS_DETAIL,PD_GS_DATE_END from PD_PROJECT_GKGS ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_GKGS_Model model = new PD_PROJECT_GKGS_Model();
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
            if (set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString() != "")
            {
                model.PD_PROJECT_TYPE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_GS_TYPE"].ToString() != "")
            {
                model.PD_GS_TYPE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_GS_TYPE"].ToString()));
            }
            model.PD_GS_STYLE = set.Tables[0].Rows[0]["PD_GS_STYLE"].ToString();
            model.PD_GS_ZHUTI = set.Tables[0].Rows[0]["PD_GS_ZHUTI"].ToString();
            if (set.Tables[0].Rows[0]["PD_GS_DATE"].ToString() != "")
            {
                model.PD_GS_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_GS_DATE"].ToString()));
            }
            model.PD_GS_ADDR = set.Tables[0].Rows[0]["PD_GS_ADDR"].ToString();
            model.PD_GS_FILENAME = set.Tables[0].Rows[0]["PD_GS_FILENAME"].ToString();
            model.PD_GS_FILENAME_SYSTEM = set.Tables[0].Rows[0]["PD_GS_FILENAME_SYSTEM"].ToString();
            model.PD_GS_DETAIL = set.Tables[0].Rows[0]["PD_GS_DETAIL"].ToString();
            if (set.Tables[0].Rows[0]["PD_GS_DATE_END"].ToString() != "")
            {
                model.PD_GS_DATE_END = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_GS_DATE_END"].ToString()));
            }
            return model;
        }

        public bool Update(PD_PROJECT_GKGS_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_GKGS set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_PROJECT_TYPE=:PD_PROJECT_TYPE,");
            builder.Append("PD_GS_TYPE=:PD_GS_TYPE,");
            builder.Append("PD_GS_STYLE=:PD_GS_STYLE,");
            builder.Append("PD_GS_ZHUTI=:PD_GS_ZHUTI,");
            builder.Append("PD_GS_DATE=:PD_GS_DATE,");
            builder.Append("PD_GS_ADDR=:PD_GS_ADDR,");
            builder.Append("PD_GS_FILENAME=:PD_GS_FILENAME,");
            builder.Append("PD_GS_FILENAME_SYSTEM=:PD_GS_FILENAME_SYSTEM,");
            builder.Append("PD_GS_DETAIL=:PD_GS_DETAIL,");
            builder.Append("PD_GS_DATE_END=:PD_GS_DATE_END");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar), new OracleParameter(":PD_PROJECT_TYPE", OracleType.Number, 4), new OracleParameter(":PD_GS_TYPE", OracleType.Number, 4), new OracleParameter(":PD_GS_STYLE", OracleType.NVarChar), new OracleParameter(":PD_GS_ZHUTI", OracleType.NVarChar), new OracleParameter(":PD_GS_DATE", OracleType.DateTime), new OracleParameter(":PD_GS_ADDR", OracleType.NVarChar), new OracleParameter(":PD_GS_FILENAME", OracleType.NVarChar), new OracleParameter(":PD_GS_FILENAME_SYSTEM", OracleType.NVarChar), new OracleParameter(":PD_GS_DETAIL", OracleType.NVarChar), new OracleParameter(":PD_GS_DATE_END", OracleType.DateTime), new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_TYPE;
            cmdParms[2].Value = model.PD_GS_TYPE;
            cmdParms[3].Value = model.PD_GS_STYLE;
            cmdParms[4].Value = model.PD_GS_ZHUTI;
            cmdParms[5].Value = model.PD_GS_DATE;
            cmdParms[6].Value = model.PD_GS_ADDR;
            cmdParms[7].Value = model.PD_GS_FILENAME;
            cmdParms[8].Value = model.PD_GS_FILENAME_SYSTEM;
            cmdParms[9].Value = model.PD_GS_DETAIL;
            cmdParms[10].Value = model.PD_GS_DATE_END;
            cmdParms[11].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

