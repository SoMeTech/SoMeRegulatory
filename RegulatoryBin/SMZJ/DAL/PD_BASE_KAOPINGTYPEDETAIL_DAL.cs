namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_BASE_KAOPINGTYPEDETAIL_DAL
    {
        public void Add(PD_BASE_KAOPINGTYPEDETAIL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_BASE_KAOPINGTYPEDETAIL(");
            builder.Append("AUTO_ID,KP_YEAR,KP_CONTENT,KP_TYPEID,KP_BIAOZHUN,KP_BASECODE,ISCOMFIRM)");
            builder.Append(" values (");
            builder.Append("SQ_KAOPINGTYPEDETAIL.NEXTVAL,:KP_YEAR,:KP_CONTENT,:KP_TYPEID,:KP_BIAOZHUN,:KP_BASECODE,:ISCOMFIRM)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":KP_YEAR", OracleType.NVarChar), new OracleParameter(":KP_CONTENT", OracleType.NVarChar), new OracleParameter(":KP_TYPEID", OracleType.Number, 4), new OracleParameter(":KP_BIAOZHUN", OracleType.NVarChar), new OracleParameter(":KP_BASECODE", OracleType.Number, 4), new OracleParameter(":ISCOMFIRM", OracleType.Char, 1) };
            cmdParms[0].Value = model.KP_YEAR;
            cmdParms[1].Value = model.KP_CONTENT;
            cmdParms[2].Value = model.KP_TYPEID;
            cmdParms[3].Value = model.KP_BIAOZHUN;
            cmdParms[4].Value = model.KP_BASECODE;
            cmdParms[5].Value = model.ISCOMFIRM;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_BASE_KAOPINGTYPEDETAIL ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_BASE_KAOPINGTYPEDETAIL ");
            builder.Append(" where AUTO_ID in (" + AUTO_IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_BASE_KAOPINGTYPEDETAIL");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,KP_YEAR,KP_CONTENT,KP_TYPEID,KP_BIAOZHUN,KP_BASECODE,ISCOMFIRM ");
            builder.Append(" FROM View_PD_BASE_KAOPINGTYPEDETAIL ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_BASE_KAOPINGTYPEDETAIL_Model GetModel(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.*,b.khtypename from PD_BASE_KAOPINGTYPEDETAIL a ,PD_BASE_KAOPINGTYPE b where a.kp_typeid=b.auto_id ");
            builder.Append(" and a.AUTO_ID=:AUTO_ID");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            PD_BASE_KAOPINGTYPEDETAIL_Model model = new PD_BASE_KAOPINGTYPEDETAIL_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_ID"].ToString() != "")
            {
                model.AUTO_ID = new int?(int.Parse(set.Tables[0].Rows[0]["AUTO_ID"].ToString()));
            }
            model.KP_YEAR = set.Tables[0].Rows[0]["KP_YEAR"].ToString();
            model.KP_CONTENT = set.Tables[0].Rows[0]["KP_CONTENT"].ToString();
            if (set.Tables[0].Rows[0]["KP_TYPEID"].ToString() != "")
            {
                model.KP_TYPEID = new int?(int.Parse(set.Tables[0].Rows[0]["KP_TYPEID"].ToString()));
            }
            model.KP_BIAOZHUN = set.Tables[0].Rows[0]["KP_BIAOZHUN"].ToString();
            if (set.Tables[0].Rows[0]["KP_BASECODE"].ToString() != "")
            {
                model.KP_BASECODE = new int?(int.Parse(set.Tables[0].Rows[0]["KP_BASECODE"].ToString()));
            }
            model.ISCOMFIRM = set.Tables[0].Rows[0]["ISCOMFIRM"].ToString();
            model.typename = set.Tables[0].Rows[0]["khtypename"].ToString();
            return model;
        }

        public bool Update(PD_BASE_KAOPINGTYPEDETAIL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_BASE_KAOPINGTYPEDETAIL set ");
            builder.Append("AUTO_ID=:AUTO_ID,");
            builder.Append("KP_YEAR=:KP_YEAR,");
            builder.Append("KP_CONTENT=:KP_CONTENT,");
            builder.Append("KP_TYPEID=:KP_TYPEID,");
            builder.Append("KP_BIAOZHUN=:KP_BIAOZHUN,");
            builder.Append("KP_BASECODE=:KP_BASECODE,");
            builder.Append("ISCOMFIRM=:ISCOMFIRM");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4), new OracleParameter(":KP_YEAR", OracleType.NVarChar), new OracleParameter(":KP_CONTENT", OracleType.NVarChar), new OracleParameter(":KP_TYPEID", OracleType.Number, 4), new OracleParameter(":KP_BIAOZHUN", OracleType.NVarChar), new OracleParameter(":KP_BASECODE", OracleType.Number, 4), new OracleParameter(":ISCOMFIRM", OracleType.Char, 1) };
            cmdParms[0].Value = model.AUTO_ID;
            cmdParms[1].Value = model.KP_YEAR;
            cmdParms[2].Value = model.KP_CONTENT;
            cmdParms[3].Value = model.KP_TYPEID;
            cmdParms[4].Value = model.KP_BIAOZHUN;
            cmdParms[5].Value = model.KP_BASECODE;
            cmdParms[6].Value = model.ISCOMFIRM;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

