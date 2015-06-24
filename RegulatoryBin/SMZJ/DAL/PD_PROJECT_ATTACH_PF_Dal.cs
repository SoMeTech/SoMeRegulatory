namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_ATTACH_PF_Dal
    {
        public void Add(PD_PROJECT_ATTACH_PF_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_ATTACH_PF(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ATTACH_TYPE,PD_PROJECT_ATTACH_NAME,PD_PROJECT_ATTACH_NAME_SYSTEM)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_PROJECT_ATTACH_TYPE,:PD_PROJECT_ATTACH_NAME,:PD_PROJECT_ATTACH_NAME_SYSTEM)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 8), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_ATTACH_TYPE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ATTACH_NAME", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ATTACH_NAME_SYSTEM", OracleType.VarChar, 50) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_PROJECT_ATTACH_TYPE;
            cmdParms[3].Value = model.PD_PROJECT_ATTACH_NAME;
            cmdParms[4].Value = model.PD_PROJECT_ATTACH_NAME_SYSTEM;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_ATTACH_PF ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_ATTACH_PF ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_ATTACH_PF");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ATTACH_TYPE,PD_PROJECT_ATTACH_NAME,PD_PROJECT_ATTACH_NAME_SYSTEM ");
            builder.Append(" FROM PD_PROJECT_ATTACH_PF ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_ATTACH_PF_Model GetModel(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_PROJECT_ATTACH_TYPE,PD_PROJECT_ATTACH_NAME,PD_PROJECT_ATTACH_NAME_SYSTEM from PD_PROJECT_ATTACH_PF ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            PD_PROJECT_ATTACH_PF_Model model = new PD_PROJECT_ATTACH_PF_Model();
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
            model.PD_PROJECT_ATTACH_TYPE = set.Tables[0].Rows[0]["PD_PROJECT_ATTACH_TYPE"].ToString();
            model.PD_PROJECT_ATTACH_NAME = set.Tables[0].Rows[0]["PD_PROJECT_ATTACH_NAME"].ToString();
            model.PD_PROJECT_ATTACH_NAME_SYSTEM = set.Tables[0].Rows[0]["PD_PROJECT_ATTACH_NAME_SYSTEM"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_ATTACH_PF_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_ATTACH_PF set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_PROJECT_ATTACH_TYPE=:PD_PROJECT_ATTACH_TYPE,");
            builder.Append("PD_PROJECT_ATTACH_NAME=:PD_PROJECT_ATTACH_NAME,");
            builder.Append("PD_PROJECT_ATTACH_NAME_SYSTEM=:PD_PROJECT_ATTACH_NAME_SYSTEM");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_ATTACH_TYPE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ATTACH_NAME", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_ATTACH_NAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_ATTACH_TYPE;
            cmdParms[2].Value = model.PD_PROJECT_ATTACH_NAME;
            cmdParms[3].Value = model.PD_PROJECT_ATTACH_NAME_SYSTEM;
            cmdParms[4].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

