namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_MONITOR_Dal
    {
        public void Add(PD_PROJECT_MONITOR_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_MONITOR(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_MONITOR_INPUT_DATE,PD_MONITOR_INPUT_MONTH,PD_MONITOR_PROCEED_WCL,PD_PROJECT_TOTAL_MONEY,PD_MONITOR_TOTAL_MONEY_PAY,PD_MONITOR_TOTAL_MONEY_WCL,PD_MONITOR_FILENAME,PD_MONITOR_FILENAME_SYSTEM,PD_ISGKGS,PD_ZHILIANG)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_MONITOR_INPUT_DATE,:PD_MONITOR_INPUT_MONTH,:PD_MONITOR_PROCEED_WCL,:PD_PROJECT_TOTAL_MONEY,:PD_MONITOR_TOTAL_MONEY_PAY,:PD_MONITOR_TOTAL_MONEY_WCL,:PD_MONITOR_FILENAME,:PD_MONITOR_FILENAME_SYSTEM,:PD_ISGKGS,:PD_ZHILIANG)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 0x24), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_MONITOR_INPUT_DATE", OracleType.DateTime), new OracleParameter(":PD_MONITOR_INPUT_MONTH", OracleType.Number, 20), new OracleParameter(":PD_MONITOR_PROCEED_WCL", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_TOTAL_MONEY", OracleType.Number, 20), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_PAY", OracleType.Number, 20), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_WCL", OracleType.Number, 20), new OracleParameter(":PD_MONITOR_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_MONITOR_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_ISGKGS", OracleType.VarChar, 2), new OracleParameter(":PD_ZHILIANG", OracleType.VarChar, 0x3e8) };
            cmdParms[0].Value = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_MONITOR_INPUT_DATE;
            cmdParms[3].Value = model.PD_MONITOR_INPUT_MONTH;
            cmdParms[4].Value = model.PD_MONITOR_PROCEED_WCL;
            cmdParms[5].Value = model.PD_PROJECT_TOTAL_MONEY;
            cmdParms[6].Value = model.PD_MONITOR_TOTAL_MONEY_PAY;
            cmdParms[7].Value = model.PD_MONITOR_TOTAL_MONEY_WCL;
            cmdParms[8].Value = model.PD_MONITOR_FILENAME;
            cmdParms[9].Value = model.PD_MONITOR_FILENAME_SYSTEM;
            cmdParms[10].Value = model.PD_ISGKGS;
            cmdParms[11].Value = model.PD_ZHILIANG;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_MONITOR ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_MONITOR ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_MONITOR ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Exists(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_MONITOR");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_MONITOR_INPUT_DATE,PD_MONITOR_INPUT_MONTH,PD_MONITOR_PROCEED_WCL,PD_PROJECT_TOTAL_MONEY,PD_MONITOR_TOTAL_MONEY_PAY,PD_MONITOR_TOTAL_MONEY_WCL,PD_MONITOR_FILENAME,PD_MONITOR_FILENAME_SYSTEM,PD_ISGKGS,PD_ZHILIANG ");
            builder.Append(" FROM PD_PROJECT_MONITOR ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_MONITOR_Model GetModel(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_MONITOR_INPUT_DATE,PD_MONITOR_INPUT_MONTH,PD_MONITOR_PROCEED_WCL,PD_PROJECT_TOTAL_MONEY,PD_MONITOR_TOTAL_MONEY_PAY,PD_MONITOR_TOTAL_MONEY_WCL,PD_MONITOR_FILENAME,PD_MONITOR_FILENAME_SYSTEM,PD_ISGKGS,PD_ZHILIANG from PD_PROJECT_MONITOR ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_MONITOR_Model model = new PD_PROJECT_MONITOR_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            if (set.Tables[0].Rows[0]["PD_MONITOR_INPUT_DATE"].ToString() != "")
            {
                model.PD_MONITOR_INPUT_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_MONITOR_INPUT_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_MONITOR_INPUT_MONTH"].ToString() != "")
            {
                model.PD_MONITOR_INPUT_MONTH = new int?(int.Parse(set.Tables[0].Rows[0]["PD_MONITOR_INPUT_MONTH"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_MONITOR_PROCEED_WCL"].ToString() != "")
            {
                model.PD_MONITOR_PROCEED_WCL = new decimal?(int.Parse(set.Tables[0].Rows[0]["PD_MONITOR_PROCEED_WCL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_TOTAL_MONEY"].ToString() != "")
            {
                model.PD_PROJECT_TOTAL_MONEY = new decimal?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_TOTAL_MONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_PAY"].ToString() != "")
            {
                model.PD_MONITOR_TOTAL_MONEY_PAY = new decimal?(int.Parse(set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_PAY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_WCL"].ToString() != "")
            {
                model.PD_MONITOR_TOTAL_MONEY_WCL = new decimal?(int.Parse(set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_WCL"].ToString()));
            }
            model.PD_MONITOR_FILENAME = set.Tables[0].Rows[0]["PD_MONITOR_FILENAME"].ToString();
            model.PD_MONITOR_FILENAME_SYSTEM = set.Tables[0].Rows[0]["PD_MONITOR_FILENAME_SYSTEM"].ToString();
            model.PD_ISGKGS = set.Tables[0].Rows[0]["PD_ISGKGS"].ToString();
            model.PD_ZHILIANG = set.Tables[0].Rows[0]["PD_ZHILIANG"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_MONITOR_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_MONITOR set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_MONITOR_INPUT_DATE=:PD_MONITOR_INPUT_DATE,");
            builder.Append("PD_MONITOR_INPUT_MONTH=:PD_MONITOR_INPUT_MONTH,");
            builder.Append("PD_MONITOR_PROCEED_WCL=:PD_MONITOR_PROCEED_WCL,");
            builder.Append("PD_PROJECT_TOTAL_MONEY=:PD_PROJECT_TOTAL_MONEY,");
            builder.Append("PD_MONITOR_TOTAL_MONEY_PAY=:PD_MONITOR_TOTAL_MONEY_PAY,");
            builder.Append("PD_MONITOR_TOTAL_MONEY_WCL=:PD_MONITOR_TOTAL_MONEY_WCL,");
            builder.Append("PD_MONITOR_FILENAME=:PD_MONITOR_FILENAME,");
            builder.Append("PD_MONITOR_FILENAME_SYSTEM=:PD_MONITOR_FILENAME_SYSTEM,");
            builder.Append("PD_ISGKGS=:PD_ISGKGS,");
            builder.Append("PD_ZHILIANG=:PD_ZHILIANG");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_MONITOR_INPUT_DATE", OracleType.DateTime), new OracleParameter(":PD_MONITOR_INPUT_MONTH", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_PROCEED_WCL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TOTAL_MONEY", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_PAY", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_WCL", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_MONITOR_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_ISGKGS", OracleType.VarChar, 2), new OracleParameter(":PD_ZHILIANG", OracleType.VarChar, 0x3e8), new OracleParameter(":AUTO_NO", OracleType.Char, 0x24) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_MONITOR_INPUT_DATE;
            cmdParms[2].Value = model.PD_MONITOR_INPUT_MONTH;
            cmdParms[3].Value = model.PD_MONITOR_PROCEED_WCL;
            cmdParms[4].Value = model.PD_PROJECT_TOTAL_MONEY;
            cmdParms[5].Value = model.PD_MONITOR_TOTAL_MONEY_PAY;
            cmdParms[6].Value = model.PD_MONITOR_TOTAL_MONEY_WCL;
            cmdParms[7].Value = model.PD_MONITOR_FILENAME;
            cmdParms[8].Value = model.PD_MONITOR_FILENAME_SYSTEM;
            cmdParms[9].Value = model.PD_ISGKGS;
            cmdParms[10].Value = model.PD_ZHILIANG;
            cmdParms[11].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

