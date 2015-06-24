namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_CONTRACT_CHANGE_Dal
    {
        public void Add(PD_CONTRACT_CHANGE_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_CONTRACT_CHANGE(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,PD_CONTRACT_CHANGE_DATE,PD_CONTRACT_CHANGE_TYPE,PD_CONTRACT_CHANGE_REASON,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_MONEY,PD_CONTRACT_CHANGE_ZJ,PD_CONTRACT_CHANGE_MONEY,PD_CONTRACT_CHANGE_FILENAME_SQ,PD_CONTRACT_FILENAME_SYSTEM_SQ,PD_CONTRACT_FILENO_PF,PD_CONTRACT_FILENAME_PF,PD_CONTRACT_FILENAME_SYS_PF,PD_CONTRACT_PICI,PD_CONTRACT_STATE,PD_CONTRACT_CHANGE_WH,PD_YEAR,PD_NOW_SERVERPK,CONTR_CHANGE_MIAN_ID)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:PD_CONTRACT_CHANGE_DATE,:PD_CONTRACT_CHANGE_TYPE,:PD_CONTRACT_CHANGE_REASON,:PD_CONTRACT_TYPE,:PD_CONTRACT_NO,:PD_CONTRACT_MONEY,:PD_CONTRACT_CHANGE_ZJ,:PD_CONTRACT_CHANGE_MONEY,:PD_CONTRACT_CHANGE_FILENAME_SQ,:PD_CONTRACT_FILENAME_SYSTEM_SQ,:PD_CONTRACT_FILENO_PF,:PD_CONTRACT_FILENAME_PF,:PD_CONTRACT_FILENAME_SYS_PF,:PD_CONTRACT_PICI,:PD_CONTRACT_STATE,:PD_CONTRACT_CHANGE_WH,:PD_YEAR,:PD_NOW_SERVERPK,:CONTR_CHANGE_MIAN_ID)");
            builder.Append(" RETURNING AUTO_NO INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":AUTO_NO", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_CONTRACT_CHANGE_DATE", OracleType.DateTime), new OracleParameter(":PD_CONTRACT_CHANGE_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_CHANGE_REASON", OracleType.VarChar, 200), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 100), new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 100), new OracleParameter(":PD_CONTRACT_MONEY", OracleType.Number, 4), new OracleParameter(":PD_CONTRACT_CHANGE_ZJ", OracleType.VarChar, 200), new OracleParameter(":PD_CONTRACT_CHANGE_MONEY", OracleType.Number, 4), new OracleParameter(":PD_CONTRACT_CHANGE_FILENAME_SQ", OracleType.VarChar, 0xff), new OracleParameter(":PD_CONTRACT_FILENAME_SYSTEM_SQ", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENO_PF", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_PF", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_SYS_PF", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_PICI", OracleType.Number, 4), 
                new OracleParameter(":PD_CONTRACT_STATE", OracleType.Number, 4), new OracleParameter(":PD_CONTRACT_CHANGE_WH", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":CONTR_CHANGE_MIAN_ID", OracleType.Number, 20), new OracleParameter(":R_Auto_No", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.PD_CONTRACT_CHANGE_DATE;
            cmdParms[3].Value = model.PD_CONTRACT_CHANGE_TYPE;
            cmdParms[4].Value = model.PD_CONTRACT_CHANGE_REASON;
            cmdParms[5].Value = model.PD_CONTRACT_TYPE;
            cmdParms[6].Value = model.PD_CONTRACT_NO;
            cmdParms[7].Value = model.PD_CONTRACT_MONEY;
            cmdParms[8].Value = model.PD_CONTRACT_CHANGE_ZJ;
            cmdParms[9].Value = model.PD_CONTRACT_CHANGE_MONEY;
            cmdParms[10].Value = model.PD_CONTRACT_CHANGE_FILENAME_SQ;
            cmdParms[11].Value = model.PD_CONTRACT_FILENAME_SYSTEM_SQ;
            cmdParms[12].Value = model.PD_CONTRACT_FILENO_PF;
            cmdParms[13].Value = model.PD_CONTRACT_FILENAME_PF;
            cmdParms[14].Value = model.PD_CONTRACT_FILENAME_SYS_PF;
            cmdParms[15].Value = model.PD_CONTRACT_PICI;
            cmdParms[0x10].Value = model.PD_CONTRACT_STATE;
            cmdParms[0x11].Value = model.PD_CONTRACT_CHANGE_WH;
            cmdParms[0x12].Value = model.PD_YEAR;
            cmdParms[0x13].Value = model.PD_NOW_SERVERPK;
            cmdParms[20].Value = model.CONTR_CHANGE_MIAN_ID;
            cmdParms[0x15].Direction = ParameterDirection.Output;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.AUTO_NO = cmdParms[0x15].Value.ToString();
        }

        public bool Delete(long AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_CONTRACT_CHANGE ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_CONTRACT_CHANGE ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_CONTRACT_CHANGE ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            builder.Append(" AND PD_CONTRACT_State!=1 ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Exists(string AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_CONTRACT_CHANGE");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Char, 50) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,PD_CONTRACT_CHANGE_DATE,PD_CONTRACT_CHANGE_TYPE,PD_CONTRACT_CHANGE_REASON,PD_CONTRACT_TYPE,PD_CONTRACT_NO,PD_CONTRACT_MONEY,PD_CONTRACT_CHANGE_ZJ,PD_CONTRACT_CHANGE_MONEY,PD_CONTRACT_CHANGE_FILENAME_SQ,PD_CONTRACT_FILENAME_SYSTEM_SQ,PD_CONTRACT_FILENO_PF,PD_CONTRACT_FILENAME_PF,PD_CONTRACT_FILENAME_SYS_PF,PD_CONTRACT_PICI,PD_CONTRACT_STATE,PD_CONTRACT_CHANGE_WH,PD_YEAR,CONTR_CHANGE_MIAN_ID ");
            builder.Append(" FROM PD_CONTRACT_CHANGE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_CONTRACT_CHANGE_Model GetModel(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select t.AUTO_NO,t.PD_PROJECT_CODE,PD_CONTRACT_CHANGE_DATE,PD_CONTRACT_CHANGE_TYPE,PD_CONTRACT_CHANGE_REASON,t.PD_CONTRACT_TYPE,t.PD_CONTRACT_NO,PD_CONTRACT_MONEY,PD_CONTRACT_CHANGE_ZJ,PD_CONTRACT_CHANGE_MONEY,PD_CONTRACT_CHANGE_FILENAME_SQ,PD_CONTRACT_FILENAME_SYSTEM_SQ,PD_CONTRACT_FILENO_PF,PD_CONTRACT_FILENAME_PF,PD_CONTRACT_FILENAME_SYS_PF,PD_CONTRACT_PICI,PD_CONTRACT_STATE,PD_CONTRACT_CHANGE_WH,t.PD_YEAR,contract.pd_contract_name PD_CONTRACT_NO_Name,CONTR_CHANGE_MIAN_ID ");
            builder.Append(" from PD_CONTRACT_CHANGE t  ");
            builder.Append(" left join PD_PROJECT_CONTRACT contract on contract.PD_CONTRACT_NO=t.PD_CONTRACT_NO ");
            builder.Append(" where t.AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = AUTO_NO;
            PD_CONTRACT_CHANGE_Model model = new PD_CONTRACT_CHANGE_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_DATE"].ToString() != "")
            {
                model.PD_CONTRACT_CHANGE_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_DATE"].ToString()));
            }
            model.PD_CONTRACT_CHANGE_TYPE = set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_TYPE"].ToString();
            model.PD_CONTRACT_CHANGE_REASON = set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_REASON"].ToString();
            model.PD_CONTRACT_TYPE = set.Tables[0].Rows[0]["PD_CONTRACT_TYPE"].ToString();
            model.PD_CONTRACT_NO = set.Tables[0].Rows[0]["PD_CONTRACT_NO"].ToString();
            model.PD_CONTRACT_NO_Name = set.Tables[0].Rows[0]["PD_CONTRACT_NO_Name"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_MONEY"].ToString() != "")
            {
                model.PD_CONTRACT_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_MONEY"].ToString()));
            }
            model.PD_CONTRACT_CHANGE_ZJ = set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_ZJ"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_MONEY"].ToString() != "")
            {
                model.PD_CONTRACT_CHANGE_MONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_MONEY"].ToString()));
            }
            model.PD_CONTRACT_CHANGE_FILENAME_SQ = set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_FILENAME_SQ"].ToString();
            model.PD_CONTRACT_FILENAME_SYSTEM_SQ = set.Tables[0].Rows[0]["PD_CONTRACT_FILENAME_SYSTEM_SQ"].ToString();
            model.PD_CONTRACT_FILENO_PF = set.Tables[0].Rows[0]["PD_CONTRACT_FILENO_PF"].ToString();
            model.PD_CONTRACT_FILENAME_PF = set.Tables[0].Rows[0]["PD_CONTRACT_FILENAME_PF"].ToString();
            model.PD_CONTRACT_FILENAME_SYS_PF = set.Tables[0].Rows[0]["PD_CONTRACT_FILENAME_SYS_PF"].ToString();
            if (set.Tables[0].Rows[0]["PD_CONTRACT_PICI"].ToString() != "")
            {
                model.PD_CONTRACT_PICI = new int?(int.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_PICI"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_CONTRACT_STATE"].ToString() != "")
            {
                model.PD_CONTRACT_STATE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_CONTRACT_STATE"].ToString()));
            }
            model.PD_CONTRACT_CHANGE_WH = set.Tables[0].Rows[0]["PD_CONTRACT_CHANGE_WH"].ToString();
            model.PD_YEAR = set.Tables[0].Rows[0]["PD_YEAR"].ToString();
            if (set.Tables[0].Rows[0]["CONTR_CHANGE_MIAN_ID"].ToString() != "")
            {
                model.CONTR_CHANGE_MIAN_ID = decimal.Parse(set.Tables[0].Rows[0]["CONTR_CHANGE_MIAN_ID"].ToString());
            }
            return model;
        }

        public bool Update(PD_CONTRACT_CHANGE_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_CONTRACT_CHANGE set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_CONTRACT_CHANGE_DATE=:PD_CONTRACT_CHANGE_DATE,");
            builder.Append("PD_CONTRACT_CHANGE_TYPE=:PD_CONTRACT_CHANGE_TYPE,");
            builder.Append("PD_CONTRACT_CHANGE_REASON=:PD_CONTRACT_CHANGE_REASON,");
            builder.Append("PD_CONTRACT_TYPE=:PD_CONTRACT_TYPE,");
            builder.Append("PD_CONTRACT_NO=:PD_CONTRACT_NO,");
            builder.Append("PD_CONTRACT_MONEY=:PD_CONTRACT_MONEY,");
            builder.Append("PD_CONTRACT_CHANGE_ZJ=:PD_CONTRACT_CHANGE_ZJ,");
            builder.Append("PD_CONTRACT_CHANGE_MONEY=:PD_CONTRACT_CHANGE_MONEY,");
            builder.Append("PD_CONTRACT_CHANGE_FILENAME_SQ=:PD_CONTRACT_CHANGE_FILENAME_SQ,");
            builder.Append("PD_CONTRACT_FILENAME_SYSTEM_SQ=:PD_CONTRACT_FILENAME_SYSTEM_SQ,");
            builder.Append("PD_CONTRACT_FILENO_PF=:PD_CONTRACT_FILENO_PF,");
            builder.Append("PD_CONTRACT_FILENAME_PF=:PD_CONTRACT_FILENAME_PF,");
            builder.Append("PD_CONTRACT_FILENAME_SYS_PF=:PD_CONTRACT_FILENAME_SYS_PF,");
            builder.Append("PD_CONTRACT_PICI=:PD_CONTRACT_PICI,");
            builder.Append("PD_CONTRACT_STATE=:PD_CONTRACT_STATE,");
            builder.Append("PD_CONTRACT_CHANGE_WH=:PD_CONTRACT_CHANGE_WH,");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("CONTR_CHANGE_MIAN_ID=:CONTR_CHANGE_MIAN_ID");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":PD_CONTRACT_CHANGE_DATE", OracleType.DateTime), new OracleParameter(":PD_CONTRACT_CHANGE_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_CONTRACT_CHANGE_REASON", OracleType.VarChar, 200), new OracleParameter(":PD_CONTRACT_TYPE", OracleType.VarChar, 100), new OracleParameter(":PD_CONTRACT_NO", OracleType.VarChar, 100), new OracleParameter(":PD_CONTRACT_MONEY", OracleType.Number, 4), new OracleParameter(":PD_CONTRACT_CHANGE_ZJ", OracleType.VarChar, 200), new OracleParameter(":PD_CONTRACT_CHANGE_MONEY", OracleType.Number, 4), new OracleParameter(":PD_CONTRACT_CHANGE_FILENAME_SQ", OracleType.VarChar, 0xff), new OracleParameter(":PD_CONTRACT_FILENAME_SYSTEM_SQ", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENO_PF", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_PF", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_FILENAME_SYS_PF", OracleType.VarChar, 50), new OracleParameter(":PD_CONTRACT_PICI", OracleType.Number, 4), new OracleParameter(":PD_CONTRACT_STATE", OracleType.Number, 4), 
                new OracleParameter(":PD_CONTRACT_CHANGE_WH", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), new OracleParameter(":CONTR_CHANGE_MIAN_ID", OracleType.Number, 20), new OracleParameter(":AUTO_NO", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_CONTRACT_CHANGE_DATE;
            cmdParms[2].Value = model.PD_CONTRACT_CHANGE_TYPE;
            cmdParms[3].Value = model.PD_CONTRACT_CHANGE_REASON;
            cmdParms[4].Value = model.PD_CONTRACT_TYPE;
            cmdParms[5].Value = model.PD_CONTRACT_NO;
            cmdParms[6].Value = model.PD_CONTRACT_MONEY;
            cmdParms[7].Value = model.PD_CONTRACT_CHANGE_ZJ;
            cmdParms[8].Value = model.PD_CONTRACT_CHANGE_MONEY;
            cmdParms[9].Value = model.PD_CONTRACT_CHANGE_FILENAME_SQ;
            cmdParms[10].Value = model.PD_CONTRACT_FILENAME_SYSTEM_SQ;
            cmdParms[11].Value = model.PD_CONTRACT_FILENO_PF;
            cmdParms[12].Value = model.PD_CONTRACT_FILENAME_PF;
            cmdParms[13].Value = model.PD_CONTRACT_FILENAME_SYS_PF;
            cmdParms[14].Value = model.PD_CONTRACT_PICI;
            cmdParms[15].Value = model.PD_CONTRACT_STATE;
            cmdParms[0x10].Value = model.PD_CONTRACT_CHANGE_WH;
            cmdParms[0x11].Value = model.PD_YEAR;
            cmdParms[0x12].Value = model.CONTR_CHANGE_MIAN_ID;
            cmdParms[0x13].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

