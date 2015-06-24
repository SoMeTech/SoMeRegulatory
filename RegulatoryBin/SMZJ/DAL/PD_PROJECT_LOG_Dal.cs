namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_LOG_Dal
    {
        public void Add(PD_PROJECT_LOG_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_LOG(");
            builder.Append("AUTOID,PD_PROJECT_TYPE,PD_PROJECT_CODE,MAN,COMPANY,BM,EXE_DTIME,EXE_CZ,EXE_JG,EXE_TXT,FREE1,FREE2,FREE3)");
            builder.Append(" values (");
            builder.Append(":AUTOID,:PD_PROJECT_TYPE,:PD_PROJECT_CODE,:MAN,:COMPANY,:BM,:EXE_DTIME,:EXE_CZ,:EXE_JG,:EXE_TXT,:FREE1,:FREE2,:FREE3)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTOID", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TYPE", OracleType.Char, 1), new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar), new OracleParameter(":MAN", OracleType.NVarChar), new OracleParameter(":COMPANY", OracleType.NVarChar), new OracleParameter(":BM", OracleType.NVarChar), new OracleParameter(":EXE_DTIME", OracleType.NVarChar), new OracleParameter(":EXE_CZ", OracleType.NVarChar), new OracleParameter(":EXE_JG", OracleType.NVarChar), new OracleParameter(":EXE_TXT", OracleType.NVarChar), new OracleParameter(":FREE1", OracleType.NVarChar), new OracleParameter(":FREE2", OracleType.NVarChar), new OracleParameter(":FREE3", OracleType.NVarChar) };
            cmdParms[0].Value = model.AUTOID;
            cmdParms[1].Value = model.PD_PROJECT_TYPE;
            cmdParms[2].Value = model.PD_PROJECT_CODE;
            cmdParms[3].Value = model.MAN;
            cmdParms[4].Value = model.COMPANY;
            cmdParms[5].Value = model.BM;
            cmdParms[6].Value = model.EXE_DTIME;
            cmdParms[7].Value = model.EXE_CZ;
            cmdParms[8].Value = model.EXE_JG;
            cmdParms[9].Value = model.EXE_TXT;
            cmdParms[10].Value = model.FREE1;
            cmdParms[11].Value = model.FREE2;
            cmdParms[12].Value = model.FREE3;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_LOG ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_LOG ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_LOG");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTOID,PD_PROJECT_TYPE,PD_PROJECT_CODE,MAN,COMPANY,BM,EXE_DTIME,EXE_CZ,EXE_JG,EXE_TXT,FREE1,FREE2,FREE3 ");
            builder.Append(" FROM PD_PROJECT_LOG ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public DataSet GetList(string code, string type)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTOID,PD_PROJECT_TYPE,PD_PROJECT_CODE,MAN,COMPANY,BM,EXE_DTIME,EXE_CZ,EXE_JG,EXE_TXT,FREE1,FREE2,FREE3 ");
            builder.Append(" FROM View_PD_PROJECT_LOG ");
            builder.Append(" where PD_PROJECT_CODE =:PD_PROJECT_CODE ");
            builder.Append(" and PD_PROJECT_TYPE =:PD_PROJECT_TYPE ");
            builder.Append(" order by AUTOID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar), new OracleParameter(":PD_PROJECT_TYPE", OracleType.NVarChar) };
            cmdParms[0].Value = code;
            cmdParms[1].Value = type;
            return DbHelperOra.Query(builder.ToString(), cmdParms);
        }

        public PD_PROJECT_LOG_Model GetModel(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTOID,PD_PROJECT_TYPE,PD_PROJECT_CODE,MAN,COMPANY,BM,EXE_DTIME,EXE_CZ,EXE_JG,EXE_TXT,FREE1,FREE2,FREE3 from PD_PROJECT_LOG ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            PD_PROJECT_LOG_Model model = new PD_PROJECT_LOG_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                model.AUTOID = set.Tables[0].Rows[0]["AUTOID"].ToString();
                model.PD_PROJECT_TYPE = set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString();
                model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
                model.MAN = set.Tables[0].Rows[0]["MAN"].ToString();
                model.COMPANY = set.Tables[0].Rows[0]["COMPANY"].ToString();
                model.BM = set.Tables[0].Rows[0]["BM"].ToString();
                model.EXE_DTIME = set.Tables[0].Rows[0]["EXE_DTIME"].ToString();
                model.EXE_CZ = set.Tables[0].Rows[0]["EXE_CZ"].ToString();
                model.EXE_JG = set.Tables[0].Rows[0]["EXE_JG"].ToString();
                model.EXE_TXT = set.Tables[0].Rows[0]["EXE_TXT"].ToString();
                model.FREE1 = set.Tables[0].Rows[0]["FREE1"].ToString();
                model.FREE2 = set.Tables[0].Rows[0]["FREE2"].ToString();
                model.FREE3 = set.Tables[0].Rows[0]["FREE3"].ToString();
                return model;
            }
            return null;
        }

        public bool Update(PD_PROJECT_LOG_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_LOG set ");
            builder.Append("PD_PROJECT_TYPE=:PD_PROJECT_TYPE,");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("MAN=:MAN,");
            builder.Append("COMPANY=:COMPANY,");
            builder.Append("BM=:BM,");
            builder.Append("EXE_DTIME=:EXE_DTIME,");
            builder.Append("EXE_CZ=:EXE_CZ,");
            builder.Append("EXE_JG=:EXE_JG,");
            builder.Append("EXE_TXT=:EXE_TXT,");
            builder.Append("FREE1=:FREE1,");
            builder.Append("FREE2=:FREE2,");
            builder.Append("FREE3=:FREE3");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_TYPE", OracleType.Char, 1), new OracleParameter(":PD_PROJECT_CODE", OracleType.NVarChar), new OracleParameter(":MAN", OracleType.NVarChar), new OracleParameter(":COMPANY", OracleType.NVarChar), new OracleParameter(":BM", OracleType.NVarChar), new OracleParameter(":EXE_DTIME", OracleType.NVarChar), new OracleParameter(":EXE_CZ", OracleType.NVarChar), new OracleParameter(":EXE_JG", OracleType.NVarChar), new OracleParameter(":EXE_TXT", OracleType.NVarChar), new OracleParameter(":FREE1", OracleType.NVarChar), new OracleParameter(":FREE2", OracleType.NVarChar), new OracleParameter(":FREE3", OracleType.NVarChar), new OracleParameter(":AUTOID", OracleType.Number, 4) };
            cmdParms[0].Value = model.PD_PROJECT_TYPE;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.MAN;
            cmdParms[3].Value = model.COMPANY;
            cmdParms[4].Value = model.BM;
            cmdParms[5].Value = model.EXE_DTIME;
            cmdParms[6].Value = model.EXE_CZ;
            cmdParms[7].Value = model.EXE_JG;
            cmdParms[8].Value = model.EXE_TXT;
            cmdParms[9].Value = model.FREE1;
            cmdParms[10].Value = model.FREE2;
            cmdParms[11].Value = model.FREE3;
            cmdParms[12].Value = model.AUTOID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

