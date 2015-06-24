namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_FOUND_OUT_DAL
    {
        public void Add(PD_FOUND_OUT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_FOUND_OUT(");
            builder.Append("AUTO_NO,PD_YEAR,PD_FOUND_DATE,PD_IF_HAVE,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_CONTRACT_TYPE,PD_CONTRACT_COMPANY,PD_FOUND_COMPANY,PD_CONTRACT_MONEY,PD_FOUND_SOURCES,PD_FOUND_TYPE,PD_FOUND_STYLE,PD_FOUND_ACC_TYPE,PD_FOUND_VOUNO,PD_FOUND_MONEY,PD_FOUND_MONEY_TOTAL,PD_FOUND_MONEY_WCL,PD_FOUND_FILENAME,PD_FOUND_SYS_FILENAME,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,");
            builder.Append("PD_PZ_YEAR,PD_PZ_MONTH,PD_FOUND_JJFL,PD_NOW_SERVERPK,PD_PROJECT_CONTRACT,PD_FOUND_MONEY_JS,PD_FOUND_MONEY_CZ,PD_FOUND_MONEY_TOTAL_CZ,PD_FOUND_MONEY_CZZTZ_WCL)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_YEAR,:PD_FOUND_DATE,:PD_IF_HAVE,:PD_PROJECT_CODE,:PD_PROJECT_NAME,:PD_CONTRACT_TYPE,:PD_CONTRACT_COMPANY,:PD_FOUND_COMPANY,:PD_CONTRACT_MONEY,:PD_FOUND_SOURCES,:PD_FOUND_TYPE,:PD_FOUND_STYLE,:PD_FOUND_ACC_TYPE,:PD_FOUND_VOUNO,:PD_FOUND_MONEY,:PD_FOUND_MONEY_TOTAL,:PD_FOUND_MONEY_WCL,:PD_FOUND_FILENAME,:PD_FOUND_SYS_FILENAME,:PD_PROJ_STATUS,:PD_PROJ_LAST_AUDIT_STATUS,:PD_IS_RETURN,");
            builder.Append(":PD_PZ_YEAR,:PD_PZ_MONTH,:PD_FOUND_JJFL,:PD_NOW_SERVERPK,:PD_PROJECT_CONTRACT,:PD_FOUND_MONEY_JS,:PD_FOUND_MONEY_CZ,:PD_FOUND_MONEY_TOTAL_CZ,:PD_FOUND_MONEY_CZZTZ_WCL)");
            builder.Append(" RETURNING AUTO_NO INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":AUTO_NO", OracleType.Number, 20), new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_FOUND_DATE", OracleType.DateTime), new OracleParameter(":PD_IF_HAVE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_FOUND_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_MONEY", OracleType.Number, 4), new OracleParameter(":PD_FOUND_SOURCES", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_STYLE", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_ACC_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_VOUNO", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_MONEY", OracleType.Number, 20), 
                new OracleParameter(":PD_FOUND_MONEY_TOTAL", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_WCL", OracleType.VarChar, 20), new OracleParameter(":PD_FOUND_FILENAME", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_SYS_FILENAME", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 30), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 30), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":PD_PZ_YEAR", OracleType.Int32), new OracleParameter(":PD_PZ_MONTH", OracleType.Int32), new OracleParameter(":PD_FOUND_JJFL", OracleType.VarChar, 100), new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CONTRACT", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_MONEY_JS", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_CZ", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_TOTAL_CZ", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_CZZTZ_WCL", OracleType.VarChar, 100), 
                new OracleParameter(":R_Auto_No", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_YEAR;
            cmdParms[2].Value = model.PD_FOUND_DATE;
            cmdParms[3].Value = model.PD_IF_HAVE;
            cmdParms[4].Value = model.PD_PROJECT_CODE;
            cmdParms[5].Value = model.PD_PROJECT_NAME;
            cmdParms[6].Value = model.PD_CONTRACT_TYPE;
            cmdParms[7].Value = model.PD_CONTRACT_COMPANY;
            cmdParms[8].Value = model.PD_FOUND_COMPANY;
            cmdParms[9].Value = model.PD_CONTRACT_MONEY;
            cmdParms[10].Value = model.PD_FOUND_SOURCES;
            cmdParms[11].Value = model.PD_FOUND_TYPE;
            cmdParms[12].Value = model.PD_FOUND_STYLE;
            cmdParms[13].Value = model.PD_FOUND_ACC_TYPE;
            cmdParms[14].Value = model.PD_FOUND_VOUNO;
            cmdParms[15].Value = model.PD_FOUND_MONEY;
            cmdParms[0x10].Value = model.PD_FOUND_MONEY_TOTAL;
            cmdParms[0x11].Value = model.PD_FOUND_MONEY_WCL;
            cmdParms[0x12].Value = model.PD_FOUND_FILENAME;
            cmdParms[0x13].Value = model.PD_FOUND_SYS_FILENAME;
            cmdParms[20].Value = model.PD_PROJ_STATUS;
            cmdParms[0x15].Value = model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[0x16].Value = model.PD_IS_RETURN;
            cmdParms[0x17].Value = model.PD_PZ_YEAR;
            cmdParms[0x18].Value = model.PD_PZ_MONTH;
            cmdParms[0x19].Value = model.PD_FOUND_JJFL;
            cmdParms[0x1a].Value = model.PD_NOW_SERVERPK;
            cmdParms[0x1b].Value = model.PD_PROJECT_CONTRACT;
            cmdParms[0x1c].Value = model.PD_FOUND_MONEY_JS;
            cmdParms[0x1d].Value = model.PD_FOUND_MONEY_CZ;
            cmdParms[30].Value = model.PD_FOUND_MONEY_TOTAL_CZ;
            cmdParms[0x1f].Value = model.PD_FOUND_MONEY_CZZTZ_WCL;
            cmdParms[0x20].Direction = ParameterDirection.Output;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.AUTO_NO = long.Parse(cmdParms[0x20].Value.ToString());
        }

        public bool Delete(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_FOUND_OUT ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_FOUND_OUT ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(long AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_FOUND_OUT");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_YEAR,PD_FOUND_DATE,PD_IF_HAVE,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_CONTRACT_TYPE,PD_CONTRACT_COMPANY,PD_FOUND_COMPANY,PD_CONTRACT_MONEY,PD_FOUND_SOURCES,PD_FOUND_TYPE,PD_FOUND_STYLE,PD_FOUND_ACC_TYPE,PD_FOUND_VOUNO,PD_FOUND_MONEY,PD_FOUND_MONEY_TOTAL,PD_FOUND_MONEY_WCL,PD_FOUND_FILENAME,PD_FOUND_SYS_FILENAME,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_FOUND_MONEY_JS,PD_FOUND_MONEY_CZ,PD_FOUND_MONEY_TOTAL_CZ,PD_FOUND_MONEY_CZZTZ_WCL ");
            builder.Append(" FROM PD_FOUND_OUT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        internal decimal getLJMoney(string PD_PROJECT_CODE, long AUTO_ID)
        {
            string sQLString = "select sum(PD_FOUND_MONEY) as PD_CONTRACT_MONEY from PD_FOUND_OUT where PD_PROJECT_CODE=:PD_PROJECT_CODE and AUTO_NO!=:AUTO_NO";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar, 50), new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            cmdParms[1].Value = AUTO_ID;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            if (single != null)
            {
                return decimal.Parse(single.ToString());
            }
            return 0M;
        }

        internal decimal getLJMoney(string PD_PROJECT_CODE, long AUTO_ID, DateTime? PD_FOUND_DATE)
        {
            string sQLString = "select sum(PD_FOUND_MONEY) as PD_CONTRACT_MONEY from PD_FOUND_OUT where PD_PROJECT_CODE=:PD_PROJECT_CODE and AUTO_NO!=:AUTO_NO and PD_FOUND_DATE<=:PD_FOUND_DATE ";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar, 50), new OracleParameter(":AUTO_NO", OracleType.Number, 20), new OracleParameter(":PD_FOUND_DATE", OracleType.DateTime) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            cmdParms[1].Value = AUTO_ID;
            cmdParms[2].Value = PD_FOUND_DATE;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            if (single != null)
            {
                return decimal.Parse(single.ToString());
            }
            return 0M;
        }

        internal decimal getLJMoney(string PD_CONTRACT_ID, string PD_PROJECT_CODE, long AUTO_ID)
        {
            string sQLString = "select sum(PD_FOUND_MONEY) as PD_CONTRACT_MONEY from PD_FOUND_OUT where PD_PROJECT_CODE=:PD_PROJECT_CODE and PD_PROJECT_CONTRACT=:PD_PROJECT_CONTRACT and AUTO_NO!=:AUTO_NO";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar, 50), new OracleParameter(":PD_PROJECT_CONTRACT", OracleType.NVarChar, 50), new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            cmdParms[1].Value = PD_CONTRACT_ID;
            cmdParms[2].Value = AUTO_ID;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            if (single != null)
            {
                return decimal.Parse(single.ToString());
            }
            return 0M;
        }

        internal decimal getLJMoney_CZ(string PD_PROJECT_CODE, long AUTO_ID)
        {
            string sQLString = "select sum(PD_FOUND_MONEY_TOTAL_CZ) as PD_FOUND_MONEY_TOTAL_CZ from PD_FOUND_OUT where PD_PROJECT_CODE=:PD_PROJECT_CODE and AUTO_NO!=:AUTO_NO";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar, 50), new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            cmdParms[1].Value = AUTO_ID;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            if (single != null)
            {
                return decimal.Parse(single.ToString());
            }
            return 0M;
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "PD_FOUND_OUT");
        }

        public PD_FOUND_OUT_Model GetModel(long AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_YEAR,PD_FOUND_DATE,PD_IF_HAVE,PD_PROJECT_CODE,PD_PROJECT_NAME,PD_CONTRACT_TYPE,PD_CONTRACT_COMPANY,PD_FOUND_COMPANY,PD_CONTRACT_MONEY,PD_FOUND_SOURCES,PD_FOUND_TYPE,PD_FOUND_STYLE,PD_FOUND_ACC_TYPE,PD_FOUND_VOUNO,PD_FOUND_MONEY,PD_FOUND_MONEY_TOTAL,PD_FOUND_MONEY_WCL,PD_FOUND_FILENAME,PD_FOUND_SYS_FILENAME,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,");
            builder.Append("PD_PZ_YEAR,PD_PZ_MONTH,PD_FOUND_JJFL,PD_NOW_SERVERPK,pd_contract_no,PD_PROJECT_CONTRACT,PD_FOUND_MONEY_JS,PD_FOUND_MONEY_CZ,PD_FOUND_MONEY_TOTAL_CZ,PD_FOUND_MONEY_CZZTZ_WCL  from PD_FOUND_OUT ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            PD_FOUND_OUT_Model model = new PD_FOUND_OUT_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                model.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_YEAR"].ToString() != "")
            {
                model.PD_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_YEAR"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_DATE"].ToString() != "")
            {
                model.PD_FOUND_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_FOUND_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_IF_HAVE"].ToString() != "")
            {
                model.PD_IF_HAVE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IF_HAVE"].ToString()));
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            model.PD_CONTRACT_TYPE = set.Tables[0].Rows[0]["PD_CONTRACT_TYPE"].ToString();
            model.PD_CONTRACT_COMPANY = set.Tables[0].Rows[0]["PD_CONTRACT_COMPANY"].ToString();
            model.PD_FOUND_COMPANY = set.Tables[0].Rows[0]["PD_FOUND_COMPANY"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_MONEY"].ToString() != "")
            {
                model.PD_CONTRACT_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_MONEY"].ToString()));
            }
            model.PD_FOUND_SOURCES = set.Tables[0].Rows[0]["PD_FOUND_SOURCES"].ToString();
            model.PD_FOUND_TYPE = set.Tables[0].Rows[0]["PD_FOUND_TYPE"].ToString();
            model.PD_FOUND_STYLE = set.Tables[0].Rows[0]["PD_FOUND_STYLE"].ToString();
            model.PD_FOUND_ACC_TYPE = set.Tables[0].Rows[0]["PD_FOUND_ACC_TYPE"].ToString();
            model.PD_FOUND_VOUNO = set.Tables[0].Rows[0]["PD_FOUND_VOUNO"].ToString();
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY"].ToString() != "")
            {
                model.PD_FOUND_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL"].ToString() != "")
            {
                model.PD_FOUND_MONEY_TOTAL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL"].ToString()));
            }
            model.PD_FOUND_MONEY_WCL = set.Tables[0].Rows[0]["PD_FOUND_MONEY_WCL"].ToString();
            model.PD_FOUND_FILENAME = set.Tables[0].Rows[0]["PD_FOUND_FILENAME"].ToString();
            model.PD_FOUND_SYS_FILENAME = set.Tables[0].Rows[0]["PD_FOUND_SYS_FILENAME"].ToString();
            model.PD_PROJ_STATUS = set.Tables[0].Rows[0]["PD_PROJ_STATUS"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_PZ_YEAR"].ToString() != "")
            {
                model.PD_PZ_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PZ_YEAR"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PZ_MONTH"].ToString() != "")
            {
                model.PD_PZ_MONTH = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PZ_MONTH"].ToString()));
            }
            model.PD_FOUND_JJFL = set.Tables[0].Rows[0]["PD_FOUND_JJFL"].ToString();
            if (set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString() != "")
            {
                model.PD_IS_RETURN = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString()));
            }
            model.PD_NOW_SERVERPK = set.Tables[0].Rows[0]["PD_NOW_SERVERPK"].ToString();
            model.PD_CONTRACT_NO = set.Tables[0].Rows[0]["pd_contract_no"].ToString();
            model.PD_PROJECT_CONTRACT = set.Tables[0].Rows[0]["PD_PROJECT_CONTRACT"].ToString();
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_JS"].ToString() != "")
            {
                model.PD_FOUND_MONEY_JS = decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_JS"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_CZ"].ToString() != "")
            {
                model.PD_FOUND_MONEY_CZ = decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_CZ"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL_CZ"].ToString() != "")
            {
                model.PD_FOUND_MONEY_TOTAL_CZ = decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL_CZ"].ToString());
            }
            model.PD_FOUND_MONEY_CZZTZ_WCL = set.Tables[0].Rows[0]["PD_FOUND_MONEY_CZZTZ_WCL"].ToString();
            return model;
        }

        internal PD_FOUND_OUT_Model GetModelName(long AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select t.AUTO_NO,t.PD_YEAR,t.PD_FOUND_DATE,PD_IF_HAVE,t.PD_PROJECT_CODE,tp.PD_PROJECT_NAME,t.PD_CONTRACT_TYPE,t.PD_CONTRACT_COMPANY,t.PD_FOUND_COMPANY,t.PD_CONTRACT_MONEY,t.PD_FOUND_SOURCES,t.PD_FOUND_TYPE,t.PD_FOUND_STYLE,t.PD_FOUND_ACC_TYPE,t.PD_FOUND_VOUNO,t.PD_FOUND_MONEY,t.PD_FOUND_MONEY_TOTAL,t.PD_FOUND_MONEY_WCL,t.PD_FOUND_FILENAME,t.PD_FOUND_SYS_FILENAME,t.PD_PROJ_STATUS,t.PD_PROJ_LAST_AUDIT_STATUS,t.PD_IS_RETURN,t.PD_PZ_YEAR,t.PD_PZ_MONTH,t.PD_FOUND_JJFL,t.PD_NOW_SERVERPK,t.pd_contract_no,t.PD_PROJECT_CONTRACT,tp.PD_PROJECT_MONEY_TOTAL,t.pcon.PD_CONTRACT_NAME,t.PD_FOUND_MONEY_JS,t.PD_FOUND_MONEY_CZ,t.PD_FOUND_MONEY_TOTAL_CZ,t.PD_FOUND_MONEY_CZZTZ_WCL,tp.free8 ");
            builder.Append(" from PD_FOUND_OUT t ");
            builder.Append(" left join tb_project tp on tp.pd_project_code=t.pd_project_code");
            builder.Append(" left join pd_project_contract pcon on pcon.PD_CONTRACT_NO=t.pd_project_contract");
            builder.Append(" where t.AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            PD_FOUND_OUT_Model model = new PD_FOUND_OUT_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                model.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_YEAR"].ToString() != "")
            {
                model.PD_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_YEAR"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_DATE"].ToString() != "")
            {
                model.PD_FOUND_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_FOUND_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_IF_HAVE"].ToString() != "")
            {
                model.PD_IF_HAVE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IF_HAVE"].ToString()));
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            model.PD_CONTRACT_TYPE = set.Tables[0].Rows[0]["PD_CONTRACT_TYPE"].ToString();
            model.PD_CONTRACT_COMPANY = set.Tables[0].Rows[0]["PD_CONTRACT_COMPANY"].ToString();
            model.PD_FOUND_COMPANY = set.Tables[0].Rows[0]["PD_FOUND_COMPANY"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_MONEY"].ToString() != "")
            {
                model.PD_CONTRACT_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_MONEY"].ToString()));
            }
            model.PD_FOUND_SOURCES = set.Tables[0].Rows[0]["PD_FOUND_SOURCES"].ToString();
            model.PD_FOUND_TYPE = set.Tables[0].Rows[0]["PD_FOUND_TYPE"].ToString();
            model.PD_FOUND_STYLE = set.Tables[0].Rows[0]["PD_FOUND_STYLE"].ToString();
            model.PD_FOUND_ACC_TYPE = set.Tables[0].Rows[0]["PD_FOUND_ACC_TYPE"].ToString();
            model.PD_FOUND_VOUNO = set.Tables[0].Rows[0]["PD_FOUND_VOUNO"].ToString();
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY"].ToString() != "")
            {
                model.PD_FOUND_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL"].ToString() != "")
            {
                model.PD_FOUND_MONEY_TOTAL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL"].ToString()));
            }
            model.PD_FOUND_MONEY_WCL = set.Tables[0].Rows[0]["PD_FOUND_MONEY_WCL"].ToString();
            model.PD_FOUND_FILENAME = set.Tables[0].Rows[0]["PD_FOUND_FILENAME"].ToString();
            model.PD_FOUND_SYS_FILENAME = set.Tables[0].Rows[0]["PD_FOUND_SYS_FILENAME"].ToString();
            model.PD_PROJ_STATUS = set.Tables[0].Rows[0]["PD_PROJ_STATUS"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_PZ_YEAR"].ToString() != "")
            {
                model.PD_PZ_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PZ_YEAR"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PZ_MONTH"].ToString() != "")
            {
                model.PD_PZ_MONTH = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PZ_MONTH"].ToString()));
            }
            model.PD_FOUND_JJFL = set.Tables[0].Rows[0]["PD_FOUND_JJFL"].ToString();
            if (set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString() != "")
            {
                model.PD_IS_RETURN = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString()));
            }
            model.PD_NOW_SERVERPK = set.Tables[0].Rows[0]["PD_NOW_SERVERPK"].ToString();
            model.PD_CONTRACT_NO = set.Tables[0].Rows[0]["pd_contract_no"].ToString();
            model.PD_PROJECT_CONTRACT = set.Tables[0].Rows[0]["PD_PROJECT_CONTRACT"].ToString();
            model.PD_PROJECT_MONEY_TOTAL = set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL"].ToString();
            model.PD_PROJECT_CONTRACT_NAME = set.Tables[0].Rows[0]["PD_CONTRACT_NAME"].ToString();
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_JS"].ToString() != "")
            {
                model.PD_FOUND_MONEY_JS = decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_JS"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_CZ"].ToString() != "")
            {
                model.PD_FOUND_MONEY_CZ = decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_CZ"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL_CZ"].ToString() != "")
            {
                model.PD_FOUND_MONEY_TOTAL_CZ = decimal.Parse(set.Tables[0].Rows[0]["PD_FOUND_MONEY_TOTAL_CZ"].ToString());
            }
            model.PD_FOUND_MONEY_CZZTZ_WCL = set.Tables[0].Rows[0]["PD_FOUND_MONEY_CZZTZ_WCL"].ToString();
            if (set.Tables[0].Rows[0]["free8"].ToString() != "")
            {
                model.PD_PROJECT_JSZJE = decimal.Parse(set.Tables[0].Rows[0]["free8"].ToString());
            }
            return model;
        }

        public bool GetPd_BF_Moeny_Total(string PD_PROJECT_CODE, string PD_CONTRACT_MOENY)
        {
            string sQLString = "select :PD_CONTRACT_MOENY-PD_FOUND_MONEY_TOTAL as PD_CONTRACT_MONEY from PD_FOUND_OUT where PD_PROJECT_CODE=:PD_PROJECT_CODE and PD_PROJECT_CONTRACT=:PD_PROJECT_CONTRACT";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar, 50), new OracleParameter(":PD_PROJECT_CONTRACT", OracleType.NVarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            cmdParms[1].Value = PD_CONTRACT_MOENY;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            return ((single != null) && (decimal.Parse(single.ToString()) >= 0M));
        }

        internal decimal getProjectJSZJE(string PD_PROJECT_CODE)
        {
            string sQLString = "select Free8 from TB_PROJECT where PD_PROJECT_CODE=:PD_PROJECT_CODE";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            object single = DbHelperOra.GetSingle(sQLString, cmdParms);
            if (single != null)
            {
                return decimal.Parse(single.ToString());
            }
            return 0M;
        }

        internal string OutPut_PingZheng(string auto_no, string databaseName, string kjkm_JF, string kjkm_DF, string fzhs)
        {
            Hashtable sQLStringList = new Hashtable();
            DataSet set = DbHelperOra.Query("select PD_PROJECT_CODE,PD_FOUND_MONEY from PD_FOUND_OUT where AUTO_NO=" + auto_no);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            string str = set.Tables[0].Rows[0]["PD_FOUND_MONEY"].ToString();
            string str2 = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            ArrayList sQLString = new ArrayList();
            sQLString.Add("use " + databaseName);
            string returnDataSQL = "select count(*)count from GL_Pzml where idpzh='" + str2 + "'";
            if (int.Parse(DbHelperSQL.Query(sQLString, returnDataSQL).Tables[0].Rows[0]["count"].ToString()) > 0)
            {
                return "此项目已拨付生成凭证,请勿重复生成!";
            }
            StringBuilder builder = new StringBuilder();
            sQLString = new ArrayList();
            sQLString.Add("use " + databaseName);
            DataSet set3 = DbHelperSQL.Query(sQLString, "select substring(max(pzh),1,len(max(pzh))-len(ltrim(rtrim(substring(max(pzh),3,len(max(pzh)))+1))))+ltrim(rtrim(substring(max(pzh),3,len(max(pzh)))+1))MaxPZH from gl_pzml where kjqj='" + DateTime.Now.ToString("yyyyMM") + "' ");
            if (((set3.Tables[0].Rows.Count > 0) && (set3.Tables[0].Rows[0]["MaxPZH"] != null)) && (set3.Tables[0].Rows[0]["MaxPZH"].ToString().Trim() != ""))
            {
                builder.Append(set3.Tables[0].Rows[0]["MaxPZH"]);
            }
            else
            {
                builder.Append("记账     1");
            }
            sQLStringList.Add("use " + databaseName, null);
            string key = "INSERT INTO [GL_Pzml]([gsdm], [kjqj], [pzly], [pzh], [pzrq], [fjzs], [srID], [sr], [shID], [sh], [jsr], [jzrID], [jzr], [srrq], [shrq], [jzrq], [pzhzkmdy], [pzhzbz], [zt], [pzzy], [pzje], [CN], [BZ], [kjzg], [idpzh]) VALUES(@gsdm, @kjqj, @pzly, @pzh, @pzrq, @fjzs, @srID, @sr, @shID, @sh, @jsr, @jzrID, @jzr, @srrq, @shrq, @jzrq, @pzhzkmdy, @pzhzbz, @zt, @pzzy, @pzje, @CN, @BZ, @kjzg, @idpzh)";
            SqlParameter[] parameterArray = new SqlParameter[] { 
                new SqlParameter("@gsdm", SqlDbType.Char, 12), new SqlParameter("@kjqj", SqlDbType.Char, 6), new SqlParameter("@pzly", SqlDbType.Char, 2), new SqlParameter("@pzh", SqlDbType.Char, 10), new SqlParameter("@pzrq", SqlDbType.Char, 10), new SqlParameter("@fjzs", SqlDbType.Int), new SqlParameter("@srID", SqlDbType.Int), new SqlParameter("@sr", SqlDbType.Char, 10), new SqlParameter("@shID", SqlDbType.Int), new SqlParameter("@sh", SqlDbType.Char, 10), new SqlParameter("@jsr", SqlDbType.Char, 10), new SqlParameter("@jzrID", SqlDbType.Int), new SqlParameter("@jzr", SqlDbType.Char, 10), new SqlParameter("@srrq", SqlDbType.Char, 10), new SqlParameter("@shrq", SqlDbType.Char, 10), new SqlParameter("@jzrq", SqlDbType.Char, 10), 
                new SqlParameter("@pzhzkmdy", SqlDbType.Char, 1), new SqlParameter("@pzhzbz", SqlDbType.VarChar, 20), new SqlParameter("@zt", SqlDbType.TinyInt), new SqlParameter("@pzzy", SqlDbType.VarChar, 100), new SqlParameter("@pzje", SqlDbType.Float), new SqlParameter("@CN", SqlDbType.VarChar, 10), new SqlParameter("@BZ", SqlDbType.VarChar, 20), new SqlParameter("@kjzg", SqlDbType.VarChar, 10), new SqlParameter("@idpzh", SqlDbType.Char, 0x21)
             };
            parameterArray[0].Value = "";
            parameterArray[1].Value = DateTime.Now.ToString("yyyyMM");
            parameterArray[2].Value = "";
            parameterArray[3].Value = builder.ToString();
            parameterArray[4].Value = DateTime.Now.ToString("yyyyMMdd");
            parameterArray[5].Value = 0;
            parameterArray[6].Value = 1;
            parameterArray[7].Value = "系统管理员";
            parameterArray[8].Value = -2;
            parameterArray[9].Value = "";
            parameterArray[10].Value = DBNull.Value;
            parameterArray[11].Value = -1;
            parameterArray[12].Value = "";
            parameterArray[13].Value = DateTime.Now.ToString("yyyyMMdd");
            parameterArray[14].Value = "";
            parameterArray[15].Value = "";
            parameterArray[0x10].Value = DBNull.Value;
            parameterArray[0x11].Value = DBNull.Value;
            parameterArray[0x12].Value = 0;
            parameterArray[0x13].Value = "监管系统自动生成";
            parameterArray[20].Value = str;
            parameterArray[0x15].Value = DBNull.Value;
            parameterArray[0x16].Value = DBNull.Value;
            parameterArray[0x17].Value = "";
            parameterArray[0x18].Value = str2;
            sQLStringList.Add(key, parameterArray);
            key = "insert into [gl_pznr]([gsdm], [kjqj], [pzly], [pzh], [flh], [zy], [kmdm], [wbdm], [hl], [jdbz], [wbje], [je], [spz], [wldrq], [sl], [dj], [bmdm], [wldm], [xmdm], [fzsm1], [fzsm2], [fzsm3], [fzsm4], [fzsm5], [fzsm6], [fzsm7], [fzsm8], [fzsm9], [cess], [fplx], [fprq], [fphfw1], [fphfw2])  values(@gsdm, @kjqj, @pzly, @pzh, @flh, @zy, @kmdm, @wbdm, @hl, @jdbz, @wbje, @je, @spz, @wldrq, @sl, @dj, @bmdm, @wldm, @xmdm, @fzsm1, @fzsm2, @fzsm3, @fzsm4, @fzsm5, @fzsm6, @fzsm7, @fzsm8, @fzsm9, @cess, @fplx, @fprq, @fphfw1, @fphfw2)";
            SqlParameter[] parameterArray2 = new SqlParameter[] { 
                new SqlParameter("@gsdm", SqlDbType.Char, 12), new SqlParameter("@kjqj", SqlDbType.Char, 6), new SqlParameter("@pzly", SqlDbType.Char, 2), new SqlParameter("@pzh", SqlDbType.Char, 10), new SqlParameter("@flh", SqlDbType.SmallInt), new SqlParameter("@zy", SqlDbType.VarChar, 100), new SqlParameter("@kmdm", SqlDbType.Char, 0x10), new SqlParameter("@wbdm", SqlDbType.Char, 10), new SqlParameter("@hl", SqlDbType.Float), new SqlParameter("@jdbz", SqlDbType.Char, 2), new SqlParameter("@wbje", SqlDbType.Float), new SqlParameter("@je", SqlDbType.Float), new SqlParameter("@spz", SqlDbType.Char, 30), new SqlParameter("@wldrq", SqlDbType.Char, 8), new SqlParameter("@sl", SqlDbType.Float), new SqlParameter("@dj", SqlDbType.Float), 
                new SqlParameter("@bmdm", SqlDbType.Char, 12), new SqlParameter("@wldm", SqlDbType.Char, 20), new SqlParameter("@xmdm", SqlDbType.Char, 12), new SqlParameter("@fzsm1", SqlDbType.VarChar, 30), new SqlParameter("@fzsm2", SqlDbType.VarChar, 30), new SqlParameter("@fzsm3", SqlDbType.VarChar, 30), new SqlParameter("@fzsm4", SqlDbType.VarChar, 30), new SqlParameter("@fzsm6", SqlDbType.VarChar, 30), new SqlParameter("@fzsm5", SqlDbType.VarChar, 30), new SqlParameter("@fzsm7", SqlDbType.VarChar, 30), new SqlParameter("@fzsm8", SqlDbType.VarChar, 30), new SqlParameter("@fzsm9", SqlDbType.VarChar, 30), new SqlParameter("@cess", SqlDbType.Float), new SqlParameter("@fplx", SqlDbType.Char, 10), new SqlParameter("@fprq", SqlDbType.Char, 8), new SqlParameter("@fphfw1", SqlDbType.Int), 
                new SqlParameter("@fphfw2", SqlDbType.Int)
             };
            parameterArray2[0].Value = "";
            parameterArray2[1].Value = DateTime.Now.ToString("yyyyMM");
            parameterArray2[2].Value = "";
            parameterArray2[3].Value = builder.ToString();
            parameterArray2[4].Value = 1;
            parameterArray2[5].Value = "监管系统自动生成";
            parameterArray2[6].Value = kjkm_JF;
            parameterArray2[7].Value = "";
            parameterArray2[8].Value = "1.0";
            parameterArray2[9].Value = "借";
            parameterArray2[10].Value = "0.0";
            parameterArray2[11].Value = str;
            parameterArray2[12].Value = "";
            parameterArray2[13].Value = "";
            parameterArray2[14].Value = "0.0";
            parameterArray2[15].Value = "0.0";
            parameterArray2[0x10].Value = "";
            parameterArray2[0x11].Value = "";
            parameterArray2[0x12].Value = fzhs;
            parameterArray2[0x13].Value = DBNull.Value;
            parameterArray2[20].Value = DBNull.Value;
            parameterArray2[0x15].Value = DBNull.Value;
            parameterArray2[0x16].Value = DBNull.Value;
            parameterArray2[0x17].Value = DBNull.Value;
            parameterArray2[0x18].Value = DBNull.Value;
            parameterArray2[0x19].Value = DBNull.Value;
            parameterArray2[0x1a].Value = DBNull.Value;
            parameterArray2[0x1b].Value = DBNull.Value;
            parameterArray2[0x1c].Value = "0.0";
            parameterArray2[0x1d].Value = "";
            parameterArray2[30].Value = "";
            parameterArray2[0x1f].Value = "0";
            parameterArray2[0x20].Value = "0";
            sQLStringList.Add(key, parameterArray2);
            key = " INSERT INTO [gl_pznr]([gsdm], [kjqj], [pzly], [pzh], [flh], [zy], [kmdm], [wbdm], [hl], [jdbz], [wbje], [je], [spz], [wldrq], [sl], [dj], [bmdm], [wldm], [xmdm], [fzsm1], [fzsm2], [fzsm3], [fzsm4], [fzsm5], [fzsm6], [fzsm7], [fzsm8], [fzsm9], [cess], [fplx], [fprq], [fphfw1], [fphfw2])  VALUES(@gsdm, @kjqj, @pzly, @pzh, @flh, @zy, @kmdm, @wbdm, @hl, @jdbz, @wbje, @je, @spz, @wldrq, @sl, @dj, @bmdm, @wldm, @xmdm, @fzsm1, @fzsm2, @fzsm3, @fzsm4, @fzsm5, @fzsm6, @fzsm7, @fzsm8, @fzsm9, @cess, @fplx, @fprq, @fphfw1, @fphfw2)";
            SqlParameter[] parameterArray3 = new SqlParameter[] { 
                new SqlParameter("@gsdm", SqlDbType.Char, 12), new SqlParameter("@kjqj", SqlDbType.Char, 6), new SqlParameter("@pzly", SqlDbType.Char, 2), new SqlParameter("@pzh", SqlDbType.Char, 10), new SqlParameter("@flh", SqlDbType.SmallInt), new SqlParameter("@zy", SqlDbType.VarChar, 100), new SqlParameter("@kmdm", SqlDbType.Char, 0x10), new SqlParameter("@wbdm", SqlDbType.Char, 10), new SqlParameter("@hl", SqlDbType.Float), new SqlParameter("@jdbz", SqlDbType.Char, 2), new SqlParameter("@wbje", SqlDbType.Float), new SqlParameter("@je", SqlDbType.Float), new SqlParameter("@spz", SqlDbType.Char, 30), new SqlParameter("@wldrq", SqlDbType.Char, 8), new SqlParameter("@sl", SqlDbType.Float), new SqlParameter("@dj", SqlDbType.Float), 
                new SqlParameter("@bmdm", SqlDbType.Char, 12), new SqlParameter("@wldm", SqlDbType.Char, 20), new SqlParameter("@xmdm", SqlDbType.Char, 12), new SqlParameter("@fzsm1", SqlDbType.VarChar, 30), new SqlParameter("@fzsm2", SqlDbType.VarChar, 30), new SqlParameter("@fzsm3", SqlDbType.VarChar, 30), new SqlParameter("@fzsm4", SqlDbType.VarChar, 30), new SqlParameter("@fzsm5", SqlDbType.VarChar, 30), new SqlParameter("@fzsm6", SqlDbType.VarChar, 30), new SqlParameter("@fzsm7", SqlDbType.VarChar, 30), new SqlParameter("@fzsm8", SqlDbType.VarChar, 30), new SqlParameter("@fzsm9", SqlDbType.VarChar, 30), new SqlParameter("@cess", SqlDbType.Float), new SqlParameter("@fplx", SqlDbType.Char, 10), new SqlParameter("@fprq", SqlDbType.Char, 8), new SqlParameter("@fphfw1", SqlDbType.Int), 
                new SqlParameter("@fphfw2", SqlDbType.Int)
             };
            parameterArray3[0].Value = "";
            parameterArray3[1].Value = DateTime.Now.ToString("yyyyMM");
            parameterArray3[2].Value = "";
            parameterArray3[3].Value = builder.ToString();
            parameterArray3[4].Value = 2;
            parameterArray3[5].Value = "监管系统自动生成";
            parameterArray3[6].Value = kjkm_JF;
            parameterArray3[7].Value = "";
            parameterArray3[8].Value = "1.0";
            parameterArray3[9].Value = "贷";
            parameterArray3[10].Value = "0.0";
            parameterArray3[11].Value = str;
            parameterArray3[12].Value = "";
            parameterArray3[13].Value = "";
            parameterArray3[14].Value = "0.0";
            parameterArray3[15].Value = "0.0";
            parameterArray3[0x10].Value = "";
            parameterArray3[0x11].Value = "";
            parameterArray3[0x12].Value = fzhs;
            parameterArray3[0x13].Value = DBNull.Value;
            parameterArray3[20].Value = DBNull.Value;
            parameterArray3[0x15].Value = DBNull.Value;
            parameterArray3[0x16].Value = DBNull.Value;
            parameterArray3[0x17].Value = DBNull.Value;
            parameterArray3[0x18].Value = DBNull.Value;
            parameterArray3[0x19].Value = DBNull.Value;
            parameterArray3[0x1a].Value = DBNull.Value;
            parameterArray3[0x1b].Value = DBNull.Value;
            parameterArray3[0x1c].Value = "0.0";
            parameterArray3[0x1d].Value = "";
            parameterArray3[30].Value = "";
            parameterArray3[0x1f].Value = "0";
            parameterArray3[0x20].Value = "0";
            sQLStringList.Add(key, parameterArray3);
            return DbHelperSQL.ExecuteSqlTran(sQLStringList);
        }

        public bool Update(PD_FOUND_OUT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_FOUND_OUT set ");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("PD_FOUND_DATE=:PD_FOUND_DATE,");
            builder.Append("PD_IF_HAVE=:PD_IF_HAVE,");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_PROJECT_NAME=:PD_PROJECT_NAME,");
            builder.Append("PD_CONTRACT_TYPE=:PD_CONTRACT_TYPE,");
            builder.Append("PD_CONTRACT_COMPANY=:PD_CONTRACT_COMPANY,");
            builder.Append("PD_FOUND_COMPANY=:PD_FOUND_COMPANY,");
            builder.Append("PD_CONTRACT_MONEY=:PD_CONTRACT_MONEY,");
            builder.Append("PD_FOUND_SOURCES=:PD_FOUND_SOURCES,");
            builder.Append("PD_FOUND_TYPE=:PD_FOUND_TYPE,");
            builder.Append("PD_FOUND_STYLE=:PD_FOUND_STYLE,");
            builder.Append("PD_FOUND_ACC_TYPE=:PD_FOUND_ACC_TYPE,");
            builder.Append("PD_FOUND_VOUNO=:PD_FOUND_VOUNO,");
            builder.Append("PD_FOUND_MONEY=:PD_FOUND_MONEY,");
            builder.Append("PD_FOUND_MONEY_TOTAL=:PD_FOUND_MONEY_TOTAL,");
            builder.Append("PD_FOUND_MONEY_WCL=:PD_FOUND_MONEY_WCL,");
            builder.Append("PD_FOUND_FILENAME=:PD_FOUND_FILENAME,");
            builder.Append("PD_FOUND_SYS_FILENAME=:PD_FOUND_SYS_FILENAME,");
            builder.Append("PD_PROJ_STATUS=:PD_PROJ_STATUS,");
            builder.Append("PD_PROJ_LAST_AUDIT_STATUS=:PD_PROJ_LAST_AUDIT_STATUS,");
            builder.Append("PD_IS_RETURN=:PD_IS_RETURN,");
            builder.Append("PD_PZ_YEAR=:PD_PZ_YEAR,");
            builder.Append("PD_PZ_MONTH=:PD_PZ_MONTH,");
            builder.Append("PD_FOUND_JJFL=:PD_FOUND_JJFL,");
            builder.Append("pd_contract_no=:pd_contract_no,");
            builder.Append("PD_PROJECT_CONTRACT=:PD_PROJECT_CONTRACT,");
            builder.Append("PD_FOUND_MONEY_JS=:PD_FOUND_MONEY_JS,");
            builder.Append("PD_FOUND_MONEY_CZ=:PD_FOUND_MONEY_CZ,");
            builder.Append("PD_FOUND_MONEY_TOTAL_CZ=:PD_FOUND_MONEY_TOTAL_CZ,");
            builder.Append("PD_FOUND_MONEY_CZZTZ_WCL=:PD_FOUND_MONEY_CZZTZ_WCL");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_FOUND_DATE", OracleType.DateTime), new OracleParameter(":PD_IF_HAVE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_FOUND_COMPANY", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_MONEY", OracleType.Number, 4), new OracleParameter(":PD_FOUND_SOURCES", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_STYLE", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_ACC_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_VOUNO", OracleType.VarChar, 30), new OracleParameter(":PD_FOUND_MONEY", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_TOTAL", OracleType.Number, 20), 
                new OracleParameter(":PD_FOUND_MONEY_WCL", OracleType.VarChar, 20), new OracleParameter(":PD_FOUND_FILENAME", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_SYS_FILENAME", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 30), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 30), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":AUTO_NO", OracleType.Number, 4), new OracleParameter(":PD_PZ_YEAR", OracleType.Int32), new OracleParameter(":PD_PZ_MONTH", OracleType.Int32), new OracleParameter(":PD_FOUND_JJFL", OracleType.VarChar, 100), new OracleParameter(":pd_contract_no", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CONTRACT", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_MONEY_JS", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_CZ", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_TOTAL_CZ", OracleType.Number, 20), new OracleParameter(":PD_FOUND_MONEY_CZZTZ_WCL", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.PD_YEAR;
            cmdParms[1].Value = model.PD_FOUND_DATE;
            cmdParms[2].Value = model.PD_IF_HAVE;
            cmdParms[3].Value = model.PD_PROJECT_CODE;
            cmdParms[4].Value = model.PD_PROJECT_NAME;
            cmdParms[5].Value = (model.PD_CONTRACT_TYPE == null) ? "" : model.PD_CONTRACT_TYPE;
            cmdParms[6].Value = model.PD_CONTRACT_COMPANY;
            cmdParms[7].Value = model.PD_FOUND_COMPANY;
            cmdParms[8].Value = model.PD_CONTRACT_MONEY;
            cmdParms[9].Value = model.PD_FOUND_SOURCES;
            cmdParms[10].Value = (model.PD_FOUND_TYPE == null) ? "" : model.PD_FOUND_TYPE;
            cmdParms[11].Value = model.PD_FOUND_STYLE;
            cmdParms[12].Value = model.PD_FOUND_ACC_TYPE;
            cmdParms[13].Value = model.PD_FOUND_VOUNO;
            cmdParms[14].Value = model.PD_FOUND_MONEY;
            cmdParms[15].Value = model.PD_FOUND_MONEY_TOTAL;
            cmdParms[0x10].Value = model.PD_FOUND_MONEY_WCL;
            cmdParms[0x11].Value = model.PD_FOUND_FILENAME;
            cmdParms[0x12].Value = model.PD_FOUND_SYS_FILENAME;
            cmdParms[0x13].Value = (model.PD_PROJ_STATUS == null) ? "" : model.PD_PROJ_STATUS;
            cmdParms[20].Value = (model.PD_PROJ_LAST_AUDIT_STATUS == null) ? "" : model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[0x15].Value = !model.PD_IS_RETURN.HasValue ? 0 : model.PD_IS_RETURN;
            cmdParms[0x16].Value = model.AUTO_NO;
            cmdParms[0x17].Value = model.PD_PZ_YEAR;
            cmdParms[0x18].Value = model.PD_PZ_MONTH;
            cmdParms[0x19].Value = model.PD_FOUND_JJFL;
            cmdParms[0x1a].Value = model.PD_CONTRACT_NO;
            cmdParms[0x1b].Value = model.PD_PROJECT_CONTRACT;
            cmdParms[0x1c].Value = model.PD_FOUND_MONEY_JS;
            cmdParms[0x1d].Value = model.PD_FOUND_MONEY_CZ;
            cmdParms[30].Value = model.PD_FOUND_MONEY_TOTAL_CZ;
            cmdParms[0x1f].Value = model.PD_FOUND_MONEY_CZZTZ_WCL;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        internal bool UpdateLJMoney(string PD_PROJECT_CODE)
        {
            string sQLString = "update PD_FOUND_OUT t set PD_FOUND_MONEY_TOTAL=(select sum(PD_FOUND_MONEY) from PD_FOUND_OUT t1  where t1.PD_FOUND_DATE<=t.PD_FOUND_DATE and t1.pd_project_code=t.pd_project_code) where t.pd_project_code=:pd_project_code";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pd_project_code", OracleType.NVarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            bool flag = DbHelperOra.ExecuteSql(sQLString, cmdParms) > 0;
            if (flag)
            {
                sQLString = "update PD_FOUND_OUT t set t.pd_found_money_wcl=(case when (select free8 from tb_project where tb_project.pd_project_code=t.pd_project_code)!=0 then round(PD_FOUND_MONEY_TOTAL / (select free8 from tb_project where tb_project.pd_project_code=t.pd_project_code) * 100,2) else  0 end)";
                flag = DbHelperOra.ExecuteSql(sQLString) > 0;
            }
            return flag;
        }
    }
}

