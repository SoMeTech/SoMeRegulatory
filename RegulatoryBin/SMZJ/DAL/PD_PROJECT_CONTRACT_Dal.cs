namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_CONTRACT_Dal
    {
        public void Add(PD_PROJECT_CONTRACT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_CONTRACT(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_DATE,PD_CONTRACT_COMPANY,PD_CONTRACT_MOENY,PD_CONTRACT_MOENY_CHANGE,PD_CONTRACT_ASK_LIMIT,PD_CONTRACT_ASK_PROCEED,PD_CONTRACT_ASK_PAYMENT,PD_CONTRACT_NOTE,PD_CONTRACT_FILENAME,PD_CONTRACT_FILENAME_SYSTEM,PD_CONTRACT_NAME,PD_YEAR,PD_NOW_SERVERPK)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_CONTRACT_TYPE,:PD_CONTRACT_NO,:PD_CONTRACT_DATE,:PD_CONTRACT_COMPANY,:PD_CONTRACT_MOENY,:PD_CONTRACT_MOENY_CHANGE,:PD_CONTRACT_ASK_LIMIT,:PD_CONTRACT_ASK_PROCEED,:PD_CONTRACT_ASK_PAYMENT,:PD_CONTRACT_NOTE,:PD_CONTRACT_FILENAME,:PD_CONTRACT_FILENAME_SYSTEM,:PD_CONTRACT_NAME,:PD_YEAR,:PD_NOW_SERVERPK)");
            builder.Append(" RETURNING Auto_No INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":AUTO_NO", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_DATE", OracleType.DateTime), new OracleParameter(":PD_CONTRACT_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_MOENY", OracleType.Number, 10), new OracleParameter(":PD_CONTRACT_MOENY_CHANGE", OracleType.Number, 10), new OracleParameter(":PD_CONTRACT_ASK_LIMIT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PROCEED", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PAYMENT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_NOTE", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), 
                new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":R_Auto_No", OracleType.VarChar, 30)
             };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_CONTRACT_TYPE;
            cmdParms[3].Value = model.PD_CONTRACT_NO;
            cmdParms[4].Value = model.PD_CONTRACT_DATE;
            cmdParms[5].Value = model.PD_CONTRACT_COMPANY;
            cmdParms[6].Value = model.PD_CONTRACT_MOENY;
            cmdParms[7].Value = model.PD_CONTRACT_MOENY_CHANGE;
            cmdParms[8].Value = model.PD_CONTRACT_ASK_LIMIT;
            cmdParms[9].Value = model.PD_CONTRACT_ASK_PROCEED;
            cmdParms[10].Value = model.PD_CONTRACT_ASK_PAYMENT;
            cmdParms[11].Value = model.PD_CONTRACT_NOTE;
            cmdParms[12].Value = model.PD_CONTRACT_FILENAME;
            cmdParms[13].Value = model.PD_CONTRACT_FILENAME_SYSTEM;
            cmdParms[14].Value = model.PD_CONTRACT_NAME;
            cmdParms[15].Value = model.PD_YEAR;
            cmdParms[0x10].Value = model.PD_NOW_SERVERPK;
            cmdParms[0x11].Direction = ParameterDirection.Output;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.AUTO_NO = cmdParms[0x11].Value.ToString();
        }

        public bool Delete(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_CONTRACT ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.VarChar, 30) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_CONTRACT ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_CONTRACT ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Exists(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_CONTRACT");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_DATE,PD_CONTRACT_COMPANY,PD_CONTRACT_MOENY,PD_CONTRACT_MOENY_CHANGE,PD_CONTRACT_ASK_LIMIT,PD_CONTRACT_ASK_PROCEED,PD_CONTRACT_ASK_PAYMENT,PD_CONTRACT_NOTE,PD_CONTRACT_FILENAME,PD_CONTRACT_FILENAME_SYSTEM,PD_CONTRACT_NAME,PD_YEAR ");
            builder.Append(" FROM PD_PROJECT_CONTRACT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        internal string GetMaxID(string pd_year, string company)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select max(PD_CONTRACT_NO)maxID from pd_project_contract where substr(PD_CONTRACT_NO,1,4)=:pd_year and substr(PD_CONTRACT_NO,5,length(PD_CONTRACT_NO)-7)=:company");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pd_year", OracleType.VarChar, 4), new OracleParameter(":company", OracleType.VarChar, 20) };
            cmdParms[0].Value = pd_year;
            cmdParms[1].Value = company;
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if ((set.Tables.Count <= 0) || (set.Tables[0].Rows.Count <= 0))
            {
                return (pd_year + company + "001");
            }
            if (set.Tables[0].Rows[0]["maxID"].ToString().Trim() == "")
            {
                return (pd_year + company + "001");
            }
            string str = set.Tables[0].Rows[0]["maxID"].ToString().Trim();
            int num = int.Parse(str.Substring(str.Length - 3));
            if (num >= 0x3e7)
            {
                return (pd_year + company + "001");
            }
            num++;
            str = num.ToString();
            switch (str.Length)
            {
                case 1:
                    str = "00" + str;
                    break;

                case 2:
                    str = "0" + str;
                    break;
            }
            return (pd_year + company + str);
        }

        public PD_PROJECT_CONTRACT_Model GetModel(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_DATE,PD_CONTRACT_COMPANY,PD_CONTRACT_MOENY,PD_CONTRACT_MOENY_CHANGE,PD_CONTRACT_ASK_LIMIT,PD_CONTRACT_ASK_PROCEED,PD_CONTRACT_ASK_PAYMENT,PD_CONTRACT_NOTE,PD_CONTRACT_FILENAME,PD_CONTRACT_FILENAME_SYSTEM,PD_CONTRACT_NAME,PD_YEAR from PD_PROJECT_CONTRACT ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.VarChar, 30) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_CONTRACT_Model model = new PD_PROJECT_CONTRACT_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_CONTRACT_TYPE = set.Tables[0].Rows[0]["PD_CONTRACT_TYPE"].ToString();
            model.PD_CONTRACT_NO = set.Tables[0].Rows[0]["PD_CONTRACT_NO"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_DATE"].ToString() != "")
            {
                model.PD_CONTRACT_DATE = DateTime.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_DATE"].ToString());
            }
            model.PD_CONTRACT_COMPANY = set.Tables[0].Rows[0]["PD_CONTRACT_COMPANY"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_MOENY"].ToString() != "")
            {
                model.PD_CONTRACT_MOENY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_MOENY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_CONTRACT_MOENY_CHANGE"].ToString() != "")
            {
                model.PD_CONTRACT_MOENY_CHANGE = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_MOENY_CHANGE"].ToString()));
            }
            model.PD_CONTRACT_ASK_LIMIT = set.Tables[0].Rows[0]["PD_CONTRACT_ASK_LIMIT"].ToString();
            model.PD_CONTRACT_ASK_PROCEED = set.Tables[0].Rows[0]["PD_CONTRACT_ASK_PROCEED"].ToString();
            model.PD_CONTRACT_ASK_PAYMENT = set.Tables[0].Rows[0]["PD_CONTRACT_ASK_PAYMENT"].ToString();
            model.PD_CONTRACT_NOTE = set.Tables[0].Rows[0]["PD_CONTRACT_NOTE"].ToString();
            model.PD_CONTRACT_FILENAME = set.Tables[0].Rows[0]["PD_CONTRACT_FILENAME"].ToString();
            model.PD_CONTRACT_FILENAME_SYSTEM = set.Tables[0].Rows[0]["PD_CONTRACT_FILENAME_SYSTEM"].ToString();
            model.PD_CONTRACT_NAME = set.Tables[0].Rows[0]["PD_CONTRACT_NAME"].ToString();
            model.PD_YEAR = set.Tables[0].Rows[0]["PD_YEAR"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_CONTRACT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_CONTRACT set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_CONTRACT_TYPE=:PD_CONTRACT_TYPE,");
            builder.Append("PD_CONTRACT_NO=:PD_CONTRACT_NO,");
            builder.Append("PD_CONTRACT_DATE=:PD_CONTRACT_DATE,");
            builder.Append("PD_CONTRACT_COMPANY=:PD_CONTRACT_COMPANY,");
            builder.Append("PD_CONTRACT_MOENY=:PD_CONTRACT_MOENY,");
            builder.Append("PD_CONTRACT_MOENY_CHANGE=:PD_CONTRACT_MOENY_CHANGE,");
            builder.Append("PD_CONTRACT_ASK_LIMIT=:PD_CONTRACT_ASK_LIMIT,");
            builder.Append("PD_CONTRACT_ASK_PROCEED=:PD_CONTRACT_ASK_PROCEED,");
            builder.Append("PD_CONTRACT_ASK_PAYMENT=:PD_CONTRACT_ASK_PAYMENT,");
            builder.Append("PD_CONTRACT_NOTE=:PD_CONTRACT_NOTE,");
            builder.Append("PD_CONTRACT_FILENAME=:PD_CONTRACT_FILENAME,");
            builder.Append("PD_CONTRACT_FILENAME_SYSTEM=:PD_CONTRACT_FILENAME_SYSTEM,");
            builder.Append("PD_CONTRACT_NAME=:PD_CONTRACT_NAME,");
            builder.Append("PD_DB_LOOP=:PD_DB_LOOP,");
            builder.Append("PD_YEAR=:PD_YEAR");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_DATE", OracleType.DateTime), new OracleParameter(":PD_CONTRACT_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_MOENY", OracleType.Number, 10), new OracleParameter(":PD_CONTRACT_MOENY_CHANGE", OracleType.Number, 10), new OracleParameter(":PD_CONTRACT_ASK_LIMIT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PROCEED", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_ASK_PAYMENT", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_NOTE", OracleType.VarChar, 500), new OracleParameter(":PD_CONTRACT_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_DB_LOOP", OracleType.Char, 1), new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), 
                new OracleParameter(":AUTO_NO", OracleType.VarChar, 30)
             };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_CONTRACT_TYPE;
            cmdParms[2].Value = model.PD_CONTRACT_NO;
            cmdParms[3].Value = model.PD_CONTRACT_DATE;
            cmdParms[4].Value = model.PD_CONTRACT_COMPANY;
            cmdParms[5].Value = model.PD_CONTRACT_MOENY;
            cmdParms[6].Value = model.PD_CONTRACT_MOENY_CHANGE;
            cmdParms[7].Value = model.PD_CONTRACT_ASK_LIMIT;
            cmdParms[8].Value = model.PD_CONTRACT_ASK_PROCEED;
            cmdParms[9].Value = model.PD_CONTRACT_ASK_PAYMENT;
            cmdParms[10].Value = model.PD_CONTRACT_NOTE;
            cmdParms[11].Value = model.PD_CONTRACT_FILENAME;
            cmdParms[12].Value = model.PD_CONTRACT_FILENAME_SYSTEM;
            cmdParms[13].Value = model.PD_CONTRACT_NAME;
            cmdParms[14].Value = model.PD_DB_LOOP;
            cmdParms[15].Value = model.PD_YEAR;
            cmdParms[0x10].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

