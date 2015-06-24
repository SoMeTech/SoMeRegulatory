namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_ZTB_Dal
    {
        public void Add(PD_PROJECT_ZTB_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_ZTB(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ZTB_IF_SSFA,PD_PROJECT_ZTB_IF_ZTB,PD_PROJECT_ZTB_IF_WCFB,PD_PROJECT_ZTB_STYLE,PD_PROJECT_ZTB_FILE,PD_PROJECT_ZTB_FILE_SYSTEM,PD_PROJECT_ISCONTRACT,PD_PROJECT_XXJD,PD_PROJECT_FCXMGCL,PD_PROJECT_GCZLQK)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_PROJECT_ZTB_IF_SSFA,:PD_PROJECT_ZTB_IF_ZTB,:PD_PROJECT_ZTB_IF_WCFB,:PD_PROJECT_ZTB_STYLE,:PD_PROJECT_ZTB_FILE,:PD_PROJECT_ZTB_FILE_SYSTEM,:PD_PROJECT_ISCONTRACT,:PD_PROJECT_XXJD,:PD_PROJECT_FCXMGCL,:PD_PROJECT_GCZLQK)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 0x24), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_PROJECT_ZTB_IF_SSFA", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_ZTB_IF_ZTB", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_ZTB_IF_WCFB", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_ZTB_STYLE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_ZTB_FILE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ZTB_FILE_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ISCONTRACT", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_XXJD", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_FCXMGCL", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_GCZLQK", OracleType.VarChar, 50) };
            cmdParms[0].Value = Guid.NewGuid().ToString();
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_PROJECT_ZTB_IF_SSFA;
            cmdParms[3].Value = model.PD_PROJECT_ZTB_IF_ZTB;
            cmdParms[4].Value = model.PD_PROJECT_ZTB_IF_WCFB;
            cmdParms[5].Value = model.PD_PROJECT_ZTB_STYLE;
            cmdParms[6].Value = model.PD_PROJECT_ZTB_FILE;
            cmdParms[7].Value = model.PD_PROJECT_ZTB_FILE_SYSTEM;
            cmdParms[8].Value = model.PD_PROJECT_ISCONTRACT;
            cmdParms[9].Value = model.PD_PROJECT_XXJD;
            cmdParms[10].Value = model.PD_PROJECT_FCXMGCL;
            cmdParms[11].Value = model.PD_PROJECT_GCZLQK;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_ZTB ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_ZTB ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        internal bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            return true;
        }

        public bool Exists(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_ZTB");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ZTB_IF_SSFA,PD_PROJECT_ZTB_IF_ZTB,PD_PROJECT_ZTB_IF_WCFB,PD_PROJECT_ZTB_STYLE,PD_PROJECT_ZTB_FILE,PD_PROJECT_ZTB_FILE_SYSTEM,PD_PROJECT_ISCONTRACT,PD_PROJECT_XXJD,PD_PROJECT_FCXMGCL,PD_PROJECT_GCZLQK ");
            builder.Append(" FROM PD_PROJECT_ZTB ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_ZTB_Model GetModel(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ZTB_IF_SSFA,PD_PROJECT_ZTB_IF_ZTB,PD_PROJECT_ZTB_IF_WCFB,PD_PROJECT_ZTB_STYLE,PD_PROJECT_ZTB_FILE,PD_PROJECT_ZTB_FILE_SYSTEM,PD_PROJECT_ISCONTRACT,PD_PROJECT_XXJD,PD_PROJECT_FCXMGCL,PD_PROJECT_GCZLQK from PD_PROJECT_ZTB ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_ZTB_Model model = new PD_PROJECT_ZTB_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_SSFA"].ToString() != "")
            {
                model.PD_PROJECT_ZTB_IF_SSFA = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_SSFA"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_ZTB"].ToString() != "")
            {
                model.PD_PROJECT_ZTB_IF_ZTB = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_ZTB"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_WCFB"].ToString() != "")
            {
                model.PD_PROJECT_ZTB_IF_WCFB = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_WCFB"].ToString()));
            }
            model.PD_PROJECT_ZTB_STYLE = set.Tables[0].Rows[0]["PD_PROJECT_ZTB_STYLE"].ToString();
            model.PD_PROJECT_ZTB_FILE = set.Tables[0].Rows[0]["PD_PROJECT_ZTB_FILE"].ToString();
            model.PD_PROJECT_ZTB_FILE_SYSTEM = set.Tables[0].Rows[0]["PD_PROJECT_ZTB_FILE_SYSTEM"].ToString();
            model.PD_PROJECT_ISCONTRACT = set.Tables[0].Rows[0]["PD_PROJECT_ISCONTRACT"].ToString();
            model.PD_PROJECT_XXJD = set.Tables[0].Rows[0]["PD_PROJECT_XXJD"].ToString();
            model.PD_PROJECT_FCXMGCL = set.Tables[0].Rows[0]["PD_PROJECT_FCXMGCL"].ToString();
            model.PD_PROJECT_GCZLQK = set.Tables[0].Rows[0]["PD_PROJECT_GCZLQK"].ToString();
            return model;
        }

        public PD_PROJECT_ZTB_Model GetModelPROJECT(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ZTB_IF_SSFA,PD_PROJECT_ZTB_IF_ZTB,PD_PROJECT_ZTB_IF_WCFB,PD_PROJECT_ZTB_STYLE,PD_PROJECT_ZTB_FILE,PD_PROJECT_ZTB_FILE_SYSTEM,PD_PROJECT_ISCONTRACT,PD_PROJECT_XXJD,PD_PROJECT_FCXMGCL,PD_PROJECT_GCZLQK from PD_PROJECT_ZTB ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            PD_PROJECT_ZTB_Model model = new PD_PROJECT_ZTB_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_SSFA"].ToString() != "")
            {
                model.PD_PROJECT_ZTB_IF_SSFA = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_SSFA"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_ZTB"].ToString() != "")
            {
                model.PD_PROJECT_ZTB_IF_ZTB = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_ZTB"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_WCFB"].ToString() != "")
            {
                model.PD_PROJECT_ZTB_IF_WCFB = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_ZTB_IF_WCFB"].ToString()));
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_PROJECT_ZTB_STYLE = set.Tables[0].Rows[0]["PD_PROJECT_ZTB_STYLE"].ToString();
            model.PD_PROJECT_ZTB_FILE = set.Tables[0].Rows[0]["PD_PROJECT_ZTB_FILE"].ToString();
            model.PD_PROJECT_ZTB_FILE_SYSTEM = set.Tables[0].Rows[0]["PD_PROJECT_ZTB_FILE_SYSTEM"].ToString();
            model.PD_PROJECT_ISCONTRACT = set.Tables[0].Rows[0]["PD_PROJECT_ISCONTRACT"].ToString();
            model.PD_PROJECT_XXJD = set.Tables[0].Rows[0]["PD_PROJECT_XXJD"].ToString();
            model.PD_PROJECT_FCXMGCL = set.Tables[0].Rows[0]["PD_PROJECT_FCXMGCL"].ToString();
            model.PD_PROJECT_GCZLQK = set.Tables[0].Rows[0]["PD_PROJECT_GCZLQK"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_ZTB_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_ZTB set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_PROJECT_ZTB_IF_SSFA=:PD_PROJECT_ZTB_IF_SSFA,");
            builder.Append("PD_PROJECT_ZTB_IF_ZTB=:PD_PROJECT_ZTB_IF_ZTB,");
            builder.Append("PD_PROJECT_ZTB_IF_WCFB=:PD_PROJECT_ZTB_IF_WCFB,");
            builder.Append("PD_PROJECT_ZTB_STYLE=:PD_PROJECT_ZTB_STYLE,");
            builder.Append("PD_PROJECT_ZTB_FILE=:PD_PROJECT_ZTB_FILE,");
            builder.Append("PD_PROJECT_ZTB_FILE_SYSTEM=:PD_PROJECT_ZTB_FILE_SYSTEM,");
            builder.Append("PD_PROJECT_ISCONTRACT=:PD_PROJECT_ISCONTRACT,");
            builder.Append("PD_PROJECT_XXJD=:PD_PROJECT_XXJD,");
            builder.Append("PD_PROJECT_FCXMGCL=:PD_PROJECT_FCXMGCL,");
            builder.Append("PD_PROJECT_GCZLQK=:PD_PROJECT_GCZLQK");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_PROJECT_ZTB_IF_SSFA", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_ZTB_IF_ZTB", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_ZTB_IF_WCFB", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_ZTB_STYLE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_ZTB_FILE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ZTB_FILE_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ISCONTRACT", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_XXJD", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_FCXMGCL", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_GCZLQK", OracleType.VarChar, 50), new OracleParameter(":AUTO_NO", OracleType.Char, 0x24) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_ZTB_IF_SSFA;
            cmdParms[2].Value = model.PD_PROJECT_ZTB_IF_ZTB;
            cmdParms[3].Value = model.PD_PROJECT_ZTB_IF_WCFB;
            cmdParms[4].Value = model.PD_PROJECT_ZTB_STYLE;
            cmdParms[5].Value = model.PD_PROJECT_ZTB_FILE;
            cmdParms[6].Value = model.PD_PROJECT_ZTB_FILE_SYSTEM;
            cmdParms[7].Value = model.PD_PROJECT_ISCONTRACT;
            cmdParms[8].Value = model.PD_PROJECT_XXJD;
            cmdParms[9].Value = model.PD_PROJECT_FCXMGCL;
            cmdParms[10].Value = model.PD_PROJECT_GCZLQK;
            cmdParms[11].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

