namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_INSPECTION_Dal
    {
        public bool Add(PD_PROJECT_INSPECTION_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_INSPECTION(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_INSPECTION_PROCESS,PD_INSPECTION_DATE,PD_INSPECTION_MANS,PD_INSPECTION_ADDR,PD_INSPECTION_CONTENT,PD_INSPECTION_SUGGEST,PD_INSPECTION_CONCLUSION,PD_INSPECTION_FILENAME,PD_INSPECTION_FILENAME_SYSTEM,PD_INSPECTION_PEASANT,PD_INSPECTION_IDNO,PD_INSPECTION_FFNUM,PD_INSPECTION_FFSTAND,PD_INSPECTION_FFMONEY,PD_INSPECTION_ACCOUNTNO,PD_INSPECTION_PEASANT_ADDR,PD_MONITOR_PROCEED_WCL,PD_PROJECT_TOTAL_MONEY,PD_MONITOR_TOTAL_MONEY_PAY,PD_MONITOR_TOTAL_MONEY_WCL,PD_BZFFLIST_DATE,PD_INSPECTION_BTFFID,PD_INSPECTION_BTFFNAME,PD_YEAR,PD_NOW_SERVERPK)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_INSPECTION_PROCESS,:PD_INSPECTION_DATE,:PD_INSPECTION_MANS,:PD_INSPECTION_ADDR,:PD_INSPECTION_CONTENT,:PD_INSPECTION_SUGGEST,:PD_INSPECTION_CONCLUSION,:PD_INSPECTION_FILENAME,:PD_INSPECTION_FILENAME_SYSTEM,:PD_INSPECTION_PEASANT,:PD_INSPECTION_IDNO,:PD_INSPECTION_FFNUM,:PD_INSPECTION_FFSTAND,:PD_INSPECTION_FFMONEY,:PD_INSPECTION_ACCOUNTNO,:PD_INSPECTION_PEASANT_ADDR,:PD_MONITOR_PROCEED_WCL,:PD_PROJECT_TOTAL_MONEY,:PD_MONITOR_TOTAL_MONEY_PAY,:PD_MONITOR_TOTAL_MONEY_WCL,:PD_BZFFLIST_DATE,:PD_INSPECTION_BTFFID,:PD_INSPECTION_BTFFNAME,:PD_YEAR,:PD_NOW_SERVERPK)");
            builder.Append(" RETURNING AUTO_NO INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":AUTO_NO", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_INSPECTION_PROCESS", OracleType.VarChar, 30), new OracleParameter(":PD_INSPECTION_DATE", OracleType.DateTime), new OracleParameter(":PD_INSPECTION_MANS", OracleType.VarChar, 100), new OracleParameter(":PD_INSPECTION_ADDR", OracleType.VarChar, 100), new OracleParameter(":PD_INSPECTION_CONTENT", OracleType.VarChar, 0x3e8), new OracleParameter(":PD_INSPECTION_SUGGEST", OracleType.VarChar, 0x3e8), new OracleParameter(":PD_INSPECTION_CONCLUSION", OracleType.VarChar, 0x3e8), new OracleParameter(":PD_INSPECTION_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_PEASANT", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_IDNO", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_FFNUM", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_FFSTAND", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_FFMONEY", OracleType.Number, 4), 
                new OracleParameter(":PD_INSPECTION_ACCOUNTNO", OracleType.VarChar, 100), new OracleParameter(":PD_INSPECTION_PEASANT_ADDR", OracleType.VarChar, 100), new OracleParameter(":PD_MONITOR_PROCEED_WCL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TOTAL_MONEY", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_PAY", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_WCL", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_BTFFID", OracleType.Number, 20), new OracleParameter(":PD_INSPECTION_BTFFNAME", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_DATE", OracleType.DateTime), new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":R_Auto_No", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_INSPECTION_PROCESS;
            cmdParms[3].Value = model.PD_INSPECTION_DATE;
            cmdParms[4].Value = model.PD_INSPECTION_MANS;
            cmdParms[5].Value = model.PD_INSPECTION_ADDR;
            cmdParms[6].Value = model.PD_INSPECTION_CONTENT;
            cmdParms[7].Value = model.PD_INSPECTION_SUGGEST;
            cmdParms[8].Value = model.PD_INSPECTION_CONCLUSION;
            cmdParms[9].Value = model.PD_INSPECTION_FILENAME;
            cmdParms[10].Value = model.PD_INSPECTION_FILENAME_SYSTEM;
            cmdParms[11].Value = model.PD_INSPECTION_PEASANT;
            cmdParms[12].Value = model.PD_INSPECTION_IDNO;
            cmdParms[13].Value = model.PD_INSPECTION_FFNUM;
            cmdParms[14].Value = model.PD_INSPECTION_FFSTAND;
            cmdParms[15].Value = model.PD_INSPECTION_FFMONEY;
            cmdParms[0x10].Value = model.PD_INSPECTION_ACCOUNTNO;
            cmdParms[0x11].Value = model.PD_INSPECTION_PEASANT_ADDR;
            cmdParms[0x12].Value = model.PD_MONITOR_PROCEED_WCL;
            cmdParms[0x13].Value = model.PD_PROJECT_TOTAL_MONEY;
            cmdParms[20].Value = model.PD_MONITOR_TOTAL_MONEY_PAY;
            cmdParms[0x15].Value = model.PD_MONITOR_TOTAL_MONEY_WCL;
            cmdParms[0x16].Value = model.PD_INSPECTION_BTFFID;
            cmdParms[0x17].Value = model.PD_INSPECTION_BTFFNAME;
            cmdParms[0x18].Value = model.PD_BZFFLIST_DATE;
            cmdParms[0x19].Value = model.PD_YEAR;
            cmdParms[0x1a].Value = model.PD_NOW_SERVERPK;
            cmdParms[0x1b].Direction = ParameterDirection.Output;
            int num = DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.AUTO_NO = cmdParms[0x1b].Value.ToString();
            return (num > 0);
        }

        public bool Delete(long AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_INSPECTION ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(string PD_PROJECT_CODE, string str_Where)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_INSPECTION ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            if (str_Where != null)
            {
                builder.Append(str_Where);
            }
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.Char, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_INSPECTION ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_INSPECTION ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Exists(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_INSPECTION");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_INSPECTION_PROCESS,PD_INSPECTION_DATE,PD_INSPECTION_MANS,PD_INSPECTION_ADDR,PD_INSPECTION_CONTENT,PD_INSPECTION_SUGGEST,PD_INSPECTION_CONCLUSION,PD_INSPECTION_FILENAME,PD_INSPECTION_FILENAME_SYSTEM,PD_INSPECTION_PEASANT,PD_INSPECTION_IDNO,PD_INSPECTION_FFNUM,PD_INSPECTION_FFSTAND,PD_INSPECTION_FFMONEY,PD_INSPECTION_ACCOUNTNO,PD_INSPECTION_PEASANT_ADDR,PD_MONITOR_PROCEED_WCL,PD_PROJECT_TOTAL_MONEY,PD_MONITOR_TOTAL_MONEY_PAY,PD_MONITOR_TOTAL_MONEY_WCL,PD_DB_LOOP,PD_BZFFLIST_DATE,PD_INSPECTION_BTFFID,PD_INSPECTION_BTFFNAME ");
            builder.Append(" FROM PD_PROJECT_INSPECTION ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_INSPECTION_Model GetModel(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_INSPECTION_PROCESS,PD_INSPECTION_DATE,PD_INSPECTION_MANS,PD_INSPECTION_ADDR,PD_INSPECTION_CONTENT,PD_INSPECTION_SUGGEST,PD_INSPECTION_CONCLUSION,PD_INSPECTION_FILENAME,PD_INSPECTION_FILENAME_SYSTEM,PD_INSPECTION_PEASANT,PD_INSPECTION_IDNO,PD_INSPECTION_FFNUM,PD_INSPECTION_FFSTAND,PD_INSPECTION_FFMONEY,PD_INSPECTION_ACCOUNTNO,PD_INSPECTION_PEASANT_ADDR,PD_MONITOR_PROCEED_WCL,PD_PROJECT_TOTAL_MONEY,PD_MONITOR_TOTAL_MONEY_PAY,PD_MONITOR_TOTAL_MONEY_WCL,PD_DB_LOOP,PD_BZFFLIST_DATE,PD_INSPECTION_BTFFID,PD_INSPECTION_BTFFNAME,PD_YEAR from PD_PROJECT_INSPECTION ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            PD_PROJECT_INSPECTION_Model model = new PD_PROJECT_INSPECTION_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_INSPECTION_PROCESS = set.Tables[0].Rows[0]["PD_INSPECTION_PROCESS"].ToString();
            if (set.Tables[0].Rows[0]["PD_INSPECTION_DATE"].ToString() != "")
            {
                model.PD_INSPECTION_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_INSPECTION_DATE"].ToString()));
            }
            model.PD_INSPECTION_MANS = set.Tables[0].Rows[0]["PD_INSPECTION_MANS"].ToString();
            model.PD_INSPECTION_ADDR = set.Tables[0].Rows[0]["PD_INSPECTION_ADDR"].ToString();
            model.PD_INSPECTION_CONTENT = set.Tables[0].Rows[0]["PD_INSPECTION_CONTENT"].ToString();
            model.PD_INSPECTION_SUGGEST = set.Tables[0].Rows[0]["PD_INSPECTION_SUGGEST"].ToString();
            model.PD_INSPECTION_CONCLUSION = set.Tables[0].Rows[0]["PD_INSPECTION_CONCLUSION"].ToString();
            model.PD_INSPECTION_FILENAME = set.Tables[0].Rows[0]["PD_INSPECTION_FILENAME"].ToString();
            model.PD_INSPECTION_FILENAME_SYSTEM = set.Tables[0].Rows[0]["PD_INSPECTION_FILENAME_SYSTEM"].ToString();
            model.PD_INSPECTION_PEASANT = set.Tables[0].Rows[0]["PD_INSPECTION_PEASANT"].ToString();
            model.PD_INSPECTION_IDNO = set.Tables[0].Rows[0]["PD_INSPECTION_IDNO"].ToString();
            if (set.Tables[0].Rows[0]["PD_INSPECTION_FFNUM"].ToString() != "")
            {
                model.PD_INSPECTION_FFNUM = new int?(int.Parse(set.Tables[0].Rows[0]["PD_INSPECTION_FFNUM"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_INSPECTION_FFSTAND"].ToString() != "")
            {
                model.PD_INSPECTION_FFSTAND = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_INSPECTION_FFSTAND"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_INSPECTION_FFMONEY"].ToString() != "")
            {
                model.PD_INSPECTION_FFMONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_INSPECTION_FFMONEY"].ToString()));
            }
            model.PD_INSPECTION_ACCOUNTNO = set.Tables[0].Rows[0]["PD_INSPECTION_ACCOUNTNO"].ToString();
            model.PD_INSPECTION_PEASANT_ADDR = set.Tables[0].Rows[0]["PD_INSPECTION_PEASANT_ADDR"].ToString();
            if (set.Tables[0].Rows[0]["PD_MONITOR_PROCEED_WCL"].ToString() != "")
            {
                model.PD_MONITOR_PROCEED_WCL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_MONITOR_PROCEED_WCL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_TOTAL_MONEY"].ToString() != "")
            {
                model.PD_PROJECT_TOTAL_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_TOTAL_MONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_PAY"].ToString() != "")
            {
                model.PD_MONITOR_TOTAL_MONEY_PAY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_PAY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_WCL"].ToString() != "")
            {
                model.PD_MONITOR_TOTAL_MONEY_WCL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_MONITOR_TOTAL_MONEY_WCL"].ToString()));
            }
            model.PD_DB_LOOP = set.Tables[0].Rows[0]["PD_DB_LOOP"].ToString();
            if (set.Tables[0].Rows[0]["PD_BZFFLIST_DATE"].ToString() != "")
            {
                model.PD_BZFFLIST_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_BZFFLIST_DATE"].ToString()));
            }
            model.PD_INSPECTION_BTFFID = set.Tables[0].Rows[0]["PD_INSPECTION_BTFFID"].ToString();
            model.PD_INSPECTION_BTFFNAME = set.Tables[0].Rows[0]["PD_INSPECTION_BTFFNAME"].ToString();
            model.PD_YEAR = set.Tables[0].Rows[0]["PD_YEAR"].ToString();
            return model;
        }

        public DataSet HeDuiData(string PD_PROJECT_CODE)
        {
            OracleParameter[] parameters = new OracleParameter[] { new OracleParameter("code", OracleType.VarChar, 50), new OracleParameter("p_cursor", OracleType.Cursor) };
            parameters[0].Value = PD_PROJECT_CODE;
            parameters[1].Direction = ParameterDirection.Output;
            return DbHelperOra.RunProcedure("is_ssccxc_hd.PD_TC_PROC_ssccxc_hd", parameters, "table1");
        }

        public bool Update(PD_PROJECT_INSPECTION_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_INSPECTION set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_INSPECTION_PROCESS=:PD_INSPECTION_PROCESS,");
            builder.Append("PD_INSPECTION_DATE=:PD_INSPECTION_DATE,");
            builder.Append("PD_INSPECTION_MANS=:PD_INSPECTION_MANS,");
            builder.Append("PD_INSPECTION_ADDR=:PD_INSPECTION_ADDR,");
            builder.Append("PD_INSPECTION_CONTENT=:PD_INSPECTION_CONTENT,");
            builder.Append("PD_INSPECTION_SUGGEST=:PD_INSPECTION_SUGGEST,");
            builder.Append("PD_INSPECTION_CONCLUSION=:PD_INSPECTION_CONCLUSION,");
            builder.Append("PD_INSPECTION_FILENAME=:PD_INSPECTION_FILENAME,");
            builder.Append("PD_INSPECTION_FILENAME_SYSTEM=:PD_INSPECTION_FILENAME_SYSTEM,");
            builder.Append("PD_INSPECTION_PEASANT=:PD_INSPECTION_PEASANT,");
            builder.Append("PD_INSPECTION_IDNO=:PD_INSPECTION_IDNO,");
            builder.Append("PD_INSPECTION_FFNUM=:PD_INSPECTION_FFNUM,");
            builder.Append("PD_INSPECTION_FFSTAND=:PD_INSPECTION_FFSTAND,");
            builder.Append("PD_INSPECTION_FFMONEY=:PD_INSPECTION_FFMONEY,");
            builder.Append("PD_INSPECTION_ACCOUNTNO=:PD_INSPECTION_ACCOUNTNO,");
            builder.Append("PD_INSPECTION_PEASANT_ADDR=:PD_INSPECTION_PEASANT_ADDR,");
            builder.Append("PD_MONITOR_PROCEED_WCL=:PD_MONITOR_PROCEED_WCL,");
            builder.Append("PD_PROJECT_TOTAL_MONEY=:PD_PROJECT_TOTAL_MONEY,");
            builder.Append("PD_MONITOR_TOTAL_MONEY_PAY=:PD_MONITOR_TOTAL_MONEY_PAY,");
            builder.Append("PD_MONITOR_TOTAL_MONEY_WCL=:PD_MONITOR_TOTAL_MONEY_WCL,");
            builder.Append("PD_INSPECTION_BTFFID=:PD_INSPECTION_BTFFID,");
            builder.Append("PD_INSPECTION_BTFFNAME=:PD_INSPECTION_BTFFNAME,");
            builder.Append("PD_BZFFLIST_DATE=:PD_BZFFLIST_DATE,");
            builder.Append("PD_YEAR=:PD_YEAR");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_INSPECTION_PROCESS", OracleType.VarChar, 30), new OracleParameter(":PD_INSPECTION_DATE", OracleType.DateTime), new OracleParameter(":PD_INSPECTION_MANS", OracleType.VarChar, 100), new OracleParameter(":PD_INSPECTION_ADDR", OracleType.VarChar, 100), new OracleParameter(":PD_INSPECTION_CONTENT", OracleType.VarChar, 0x3e8), new OracleParameter(":PD_INSPECTION_SUGGEST", OracleType.VarChar, 0x3e8), new OracleParameter(":PD_INSPECTION_CONCLUSION", OracleType.VarChar, 0x3e8), new OracleParameter(":PD_INSPECTION_FILENAME", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_FILENAME_SYSTEM", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_PEASANT", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_IDNO", OracleType.VarChar, 50), new OracleParameter(":PD_INSPECTION_FFNUM", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_FFSTAND", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_FFMONEY", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_ACCOUNTNO", OracleType.VarChar, 100), 
                new OracleParameter(":PD_INSPECTION_PEASANT_ADDR", OracleType.VarChar, 100), new OracleParameter(":PD_MONITOR_PROCEED_WCL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TOTAL_MONEY", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_PAY", OracleType.Number, 4), new OracleParameter(":PD_MONITOR_TOTAL_MONEY_WCL", OracleType.Number, 4), new OracleParameter(":PD_INSPECTION_BTFFID", OracleType.Number, 20), new OracleParameter(":PD_INSPECTION_BTFFNAME", OracleType.VarChar, 100), new OracleParameter(":PD_BZFFLIST_DATE", OracleType.DateTime), new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), new OracleParameter(":AUTO_NO", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_INSPECTION_PROCESS;
            cmdParms[2].Value = model.PD_INSPECTION_DATE;
            cmdParms[3].Value = model.PD_INSPECTION_MANS;
            cmdParms[4].Value = model.PD_INSPECTION_ADDR;
            cmdParms[5].Value = model.PD_INSPECTION_CONTENT;
            cmdParms[6].Value = model.PD_INSPECTION_SUGGEST;
            cmdParms[7].Value = model.PD_INSPECTION_CONCLUSION;
            cmdParms[8].Value = model.PD_INSPECTION_FILENAME;
            cmdParms[9].Value = model.PD_INSPECTION_FILENAME_SYSTEM;
            cmdParms[10].Value = model.PD_INSPECTION_PEASANT;
            cmdParms[11].Value = model.PD_INSPECTION_IDNO;
            cmdParms[12].Value = model.PD_INSPECTION_FFNUM;
            cmdParms[13].Value = model.PD_INSPECTION_FFSTAND;
            cmdParms[14].Value = model.PD_INSPECTION_FFMONEY;
            cmdParms[15].Value = model.PD_INSPECTION_ACCOUNTNO;
            cmdParms[0x10].Value = model.PD_INSPECTION_PEASANT_ADDR;
            cmdParms[0x11].Value = model.PD_MONITOR_PROCEED_WCL;
            cmdParms[0x12].Value = model.PD_PROJECT_TOTAL_MONEY;
            cmdParms[0x13].Value = model.PD_MONITOR_TOTAL_MONEY_PAY;
            cmdParms[20].Value = model.PD_MONITOR_TOTAL_MONEY_WCL;
            cmdParms[0x15].Value = model.PD_INSPECTION_BTFFID;
            cmdParms[0x16].Value = model.PD_INSPECTION_BTFFNAME;
            cmdParms[0x17].Value = model.PD_BZFFLIST_DATE;
            cmdParms[0x18].Value = model.PD_YEAR;
            cmdParms[0x19].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

