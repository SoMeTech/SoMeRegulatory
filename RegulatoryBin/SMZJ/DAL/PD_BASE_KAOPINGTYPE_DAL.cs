namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_BASE_KAOPINGTYPE_DAL
    {
        public void Add(PD_BASE_KAOPINGTYPE_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_BASE_KAOPINGTYPE(");
            builder.Append("AUTO_ID,KHTYPENAME,KHTYPEPER,ORDERID,REMARK,ISCOMFIRM,KHYEAR)");
            builder.Append(" values (");
            builder.Append("SQ_KAOHETYPE.NEXTVAL,:KHTYPENAME,:KHTYPEPER,:ORDERID,:REMARK,:ISCOMFIRM,:KHYEAR)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":KHTYPENAME", OracleType.NVarChar), new OracleParameter(":KHTYPEPER", OracleType.Number, 4), new OracleParameter(":ORDERID", OracleType.Number, 4), new OracleParameter(":REMARK", OracleType.NVarChar), new OracleParameter(":ISCOMFIRM", OracleType.Char, 1), new OracleParameter(":KHYEAR", OracleType.NVarChar) };
            cmdParms[0].Value = model.KHTYPENAME;
            cmdParms[1].Value = model.KHTYPEPER;
            cmdParms[2].Value = model.ORDERID;
            cmdParms[3].Value = model.REMARK;
            cmdParms[4].Value = model.ISCOMFIRM;
            cmdParms[5].Value = model.KHYEAR;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_BASE_KAOPINGTYPE ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_BASE_KAOPINGTYPE ");
            builder.Append(" where AUTO_ID in (" + AUTO_IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_BASE_KAOPINGTYPE");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,KHTYPENAME,KHTYPEPER,ORDERID,REMARK,ISCOMFIRM,KHYEAR ");
            builder.Append(" FROM PD_BASE_KAOPINGTYPE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_BASE_KAOPINGTYPE_Model GetModel(int AUTO_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_ID,KHTYPENAME,KHTYPEPER,ORDERID,REMARK,ISCOMFIRM,KHYEAR from PD_BASE_KAOPINGTYPE ");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_ID;
            PD_BASE_KAOPINGTYPE_Model model = new PD_BASE_KAOPINGTYPE_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_ID"].ToString() != "")
            {
                model.AUTO_ID = new int?(int.Parse(set.Tables[0].Rows[0]["AUTO_ID"].ToString()));
            }
            model.KHTYPENAME = set.Tables[0].Rows[0]["KHTYPENAME"].ToString();
            if (set.Tables[0].Rows[0]["KHTYPEPER"].ToString() != "")
            {
                model.KHTYPEPER = new int?(int.Parse(set.Tables[0].Rows[0]["KHTYPEPER"].ToString()));
            }
            if (set.Tables[0].Rows[0]["ORDERID"].ToString() != "")
            {
                model.ORDERID = new int?(int.Parse(set.Tables[0].Rows[0]["ORDERID"].ToString()));
            }
            model.REMARK = set.Tables[0].Rows[0]["REMARK"].ToString();
            model.ISCOMFIRM = set.Tables[0].Rows[0]["ISCOMFIRM"].ToString();
            model.KHYEAR = set.Tables[0].Rows[0]["KHYEAR"].ToString();
            return model;
        }

        public bool Update(PD_BASE_KAOPINGTYPE_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_BASE_KAOPINGTYPE set ");
            builder.Append("AUTO_ID=:AUTO_ID,");
            builder.Append("KHTYPENAME=:KHTYPENAME,");
            builder.Append("KHTYPEPER=:KHTYPEPER,");
            builder.Append("ORDERID=:ORDERID,");
            builder.Append("REMARK=:REMARK,");
            builder.Append("ISCOMFIRM=:ISCOMFIRM,");
            builder.Append("KHYEAR=:KHYEAR");
            builder.Append(" where AUTO_ID=:AUTO_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_ID", OracleType.Number, 4), new OracleParameter(":KHTYPENAME", OracleType.NVarChar), new OracleParameter(":KHTYPEPER", OracleType.Number, 4), new OracleParameter(":ORDERID", OracleType.Number, 4), new OracleParameter(":REMARK", OracleType.NVarChar), new OracleParameter(":ISCOMFIRM", OracleType.Char, 1), new OracleParameter(":KHYEAR", OracleType.NVarChar) };
            cmdParms[0].Value = model.AUTO_ID;
            cmdParms[1].Value = model.KHTYPENAME;
            cmdParms[2].Value = model.KHTYPEPER;
            cmdParms[3].Value = model.ORDERID;
            cmdParms[4].Value = model.REMARK;
            cmdParms[5].Value = model.ISCOMFIRM;
            cmdParms[6].Value = model.KHYEAR;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

