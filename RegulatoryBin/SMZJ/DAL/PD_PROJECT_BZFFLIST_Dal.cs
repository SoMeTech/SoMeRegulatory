namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_BZFFLIST_Dal
    {
        public void Add(PD_PROJECT_BZFFLIST_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_BZFFLIST(");
            builder.Append("AUTO_NO,PD_BZFFLIST_DATE,PD_BZFFLIST_COMPANY,PD_BZFFLIST_COUNTRY,PD_BZFFLIST_PEASANT_CODE,PD_BZFFLIST_PEASANT_NAME,PD_BZFFLIST_IDNO,PD_BZFFLIST_FFNUM,PD_BZFFLIST_FFSTAND,PD_BZFFLIST_FFMONEY,PD_BZFFLIST_ACCOUNTNO,PD_BZFFLIST_PEASANT_ADDR)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_BZFFLIST_DATE,:PD_BZFFLIST_COMPANY,:PD_BZFFLIST_COUNTRY,:PD_BZFFLIST_PEASANT_CODE,:PD_BZFFLIST_PEASANT_NAME,:PD_BZFFLIST_IDNO,:PD_BZFFLIST_FFNUM,:PD_BZFFLIST_FFSTAND,:PD_BZFFLIST_FFMONEY,:PD_BZFFLIST_ACCOUNTNO,:PD_BZFFLIST_PEASANT_ADDR)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 0x24), new OracleParameter(":PD_BZFFLIST_DATE", OracleType.DateTime), new OracleParameter(":PD_BZFFLIST_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_COUNTRY", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_PEASANT_CODE", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_PEASANT_NAME", OracleType.VarChar, 200), new OracleParameter(":PD_BZFFLIST_IDNO", OracleType.VarChar, 50), new OracleParameter(":PD_BZFFLIST_FFNUM", OracleType.Number, 20), new OracleParameter(":PD_BZFFLIST_FFSTAND", OracleType.Number, 20), new OracleParameter(":PD_BZFFLIST_FFMONEY", OracleType.Number, 20), new OracleParameter(":PD_BZFFLIST_ACCOUNTNO", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_PEASANT_ADDR", OracleType.VarChar, 100) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_BZFFLIST_DATE;
            cmdParms[2].Value = model.PD_BZFFLIST_COMPANY;
            cmdParms[3].Value = model.PD_BZFFLIST_COUNTRY;
            cmdParms[4].Value = model.PD_BZFFLIST_PEASANT_CODE;
            cmdParms[5].Value = model.PD_BZFFLIST_PEASANT_NAME;
            cmdParms[6].Value = model.PD_BZFFLIST_IDNO;
            cmdParms[7].Value = model.PD_BZFFLIST_FFNUM;
            cmdParms[8].Value = model.PD_BZFFLIST_FFSTAND;
            cmdParms[9].Value = model.PD_BZFFLIST_FFMONEY;
            cmdParms[10].Value = model.PD_BZFFLIST_ACCOUNTNO;
            cmdParms[11].Value = model.PD_BZFFLIST_PEASANT_ADDR;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_BZFFLIST ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_BZFFLIST ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_BZFFLIST");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_BZFFLIST_DATE,PD_BZFFLIST_COMPANY,PD_BZFFLIST_COUNTRY,PD_BZFFLIST_PEASANT_CODE,PD_BZFFLIST_PEASANT_NAME,PD_BZFFLIST_IDNO,PD_BZFFLIST_FFNUM,PD_BZFFLIST_FFSTAND,PD_BZFFLIST_FFMONEY,PD_BZFFLIST_ACCOUNTNO,PD_BZFFLIST_PEASANT_ADDR ");
            builder.Append(" FROM PD_PROJECT_BZFFLIST ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_BZFFLIST_Model GetModel(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_BZFFLIST_DATE,PD_BZFFLIST_COMPANY,PD_BZFFLIST_COUNTRY,PD_BZFFLIST_PEASANT_CODE,PD_BZFFLIST_PEASANT_NAME,PD_BZFFLIST_IDNO,PD_BZFFLIST_FFNUM,PD_BZFFLIST_FFSTAND,PD_BZFFLIST_FFMONEY,PD_BZFFLIST_ACCOUNTNO,PD_BZFFLIST_PEASANT_ADDR from PD_PROJECT_BZFFLIST ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_BZFFLIST_Model model = new PD_PROJECT_BZFFLIST_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            if (set.Tables[0].Rows[0]["PD_BZFFLIST_DATE"].ToString() != "")
            {
                model.PD_BZFFLIST_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_BZFFLIST_DATE"].ToString()));
            }
            model.PD_BZFFLIST_COMPANY = set.Tables[0].Rows[0]["PD_BZFFLIST_COMPANY"].ToString();
            model.PD_BZFFLIST_COUNTRY = set.Tables[0].Rows[0]["PD_BZFFLIST_COUNTRY"].ToString();
            model.PD_BZFFLIST_PEASANT_CODE = set.Tables[0].Rows[0]["PD_BZFFLIST_PEASANT_CODE"].ToString();
            model.PD_BZFFLIST_PEASANT_NAME = set.Tables[0].Rows[0]["PD_BZFFLIST_PEASANT_NAME"].ToString();
            model.PD_BZFFLIST_IDNO = set.Tables[0].Rows[0]["PD_BZFFLIST_IDNO"].ToString();
            if (set.Tables[0].Rows[0]["PD_BZFFLIST_FFNUM"].ToString() != "")
            {
                model.PD_BZFFLIST_FFNUM = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_BZFFLIST_FFNUM"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_BZFFLIST_FFSTAND"].ToString() != "")
            {
                model.PD_BZFFLIST_FFSTAND = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_BZFFLIST_FFSTAND"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_BZFFLIST_FFMONEY"].ToString() != "")
            {
                model.PD_BZFFLIST_FFMONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_BZFFLIST_FFMONEY"].ToString()));
            }
            model.PD_BZFFLIST_ACCOUNTNO = set.Tables[0].Rows[0]["PD_BZFFLIST_ACCOUNTNO"].ToString();
            model.PD_BZFFLIST_PEASANT_ADDR = set.Tables[0].Rows[0]["PD_BZFFLIST_PEASANT_ADDR"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_BZFFLIST_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_BZFFLIST set ");
            builder.Append("PD_BZFFLIST_DATE=:PD_BZFFLIST_DATE,");
            builder.Append("PD_BZFFLIST_COMPANY=:PD_BZFFLIST_COMPANY,");
            builder.Append("PD_BZFFLIST_COUNTRY=:PD_BZFFLIST_COUNTRY,");
            builder.Append("PD_BZFFLIST_PEASANT_CODE=:PD_BZFFLIST_PEASANT_CODE,");
            builder.Append("PD_BZFFLIST_PEASANT_NAME=:PD_BZFFLIST_PEASANT_NAME,");
            builder.Append("PD_BZFFLIST_IDNO=:PD_BZFFLIST_IDNO,");
            builder.Append("PD_BZFFLIST_FFNUM=:PD_BZFFLIST_FFNUM,");
            builder.Append("PD_BZFFLIST_FFSTAND=:PD_BZFFLIST_FFSTAND,");
            builder.Append("PD_BZFFLIST_FFMONEY=:PD_BZFFLIST_FFMONEY,");
            builder.Append("PD_BZFFLIST_ACCOUNTNO=:PD_BZFFLIST_ACCOUNTNO,");
            builder.Append("PD_BZFFLIST_PEASANT_ADDR=:PD_BZFFLIST_PEASANT_ADDR");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_BZFFLIST_DATE", OracleType.DateTime), new OracleParameter(":PD_BZFFLIST_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_COUNTRY", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_PEASANT_CODE", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_PEASANT_NAME", OracleType.VarChar, 200), new OracleParameter(":PD_BZFFLIST_IDNO", OracleType.VarChar, 50), new OracleParameter(":PD_BZFFLIST_FFNUM", OracleType.Number, 20), new OracleParameter(":PD_BZFFLIST_FFSTAND", OracleType.Number, 20), new OracleParameter(":PD_BZFFLIST_FFMONEY", OracleType.Number, 20), new OracleParameter(":PD_BZFFLIST_ACCOUNTNO", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_PEASANT_ADDR", OracleType.VarChar, 100), new OracleParameter(":AUTO_NO", OracleType.Char, 0x24) };
            cmdParms[0].Value = model.PD_BZFFLIST_DATE;
            cmdParms[1].Value = model.PD_BZFFLIST_COMPANY;
            cmdParms[2].Value = model.PD_BZFFLIST_COUNTRY;
            cmdParms[3].Value = model.PD_BZFFLIST_PEASANT_CODE;
            cmdParms[4].Value = model.PD_BZFFLIST_PEASANT_NAME;
            cmdParms[5].Value = model.PD_BZFFLIST_IDNO;
            cmdParms[6].Value = model.PD_BZFFLIST_FFNUM;
            cmdParms[7].Value = model.PD_BZFFLIST_FFSTAND;
            cmdParms[8].Value = model.PD_BZFFLIST_FFMONEY;
            cmdParms[9].Value = model.PD_BZFFLIST_ACCOUNTNO;
            cmdParms[10].Value = model.PD_BZFFLIST_PEASANT_ADDR;
            cmdParms[11].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

