namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class TB_QUOTA_DETAIL_TMP
    {
        public void Add(SMZJ.Model.TB_QUOTA_DETAIL_TMP model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into TB_QUOTA_DETAIL_TMP(");
            builder.Append("AUTO_NO,PD_QUOTA_CODE,COMPANY_NAME,FILE_NAME,FILE_SYSNAME,COMPANY_CODE,FILE_TYPE)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_QUOTA_CODE,:COMPANY_NAME,:FILE_NAME,:FILE_SYSNAME,:COMPANY_CODE,:FILE_TYPE)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 30), new OracleParameter(":COMPANY_NAME", OracleType.VarChar, 50), new OracleParameter(":FILE_NAME", OracleType.VarChar, 30), new OracleParameter(":FILE_SYSNAME", OracleType.VarChar, 50), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 20), new OracleParameter(":FILE_TYPE", OracleType.VarChar, 20) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_QUOTA_CODE;
            cmdParms[2].Value = model.COMPANY_NAME;
            cmdParms[3].Value = model.FILE_NAME;
            cmdParms[4].Value = model.FILE_SYSNAME;
            cmdParms[5].Value = model.COMPANY_CODE;
            cmdParms[6].Value = model.FILE_TYPE;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA_DETAIL_TMP ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA_DETAIL_TMP ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from TB_QUOTA_DETAIL_TMP");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_QUOTA_CODE,COMPANY_NAME,FILE_NAME,FILE_SYSNAME,COMPANY_CODE,FILE_TYPE ");
            builder.Append(" FROM TB_QUOTA_DETAIL_TMP ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "TB_QUOTA_DETAIL_TMP");
        }

        public SMZJ.Model.TB_QUOTA_DETAIL_TMP GetModel(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_QUOTA_CODE,COMPANY_NAME,FILE_NAME,FILE_SYSNAME,COMPANY_CODE,FILE_TYPE from TB_QUOTA_DETAIL_TMP ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            SMZJ.Model.TB_QUOTA_DETAIL_TMP tb_quota_detail_tmp = new SMZJ.Model.TB_QUOTA_DETAIL_TMP();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                tb_quota_detail_tmp.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            tb_quota_detail_tmp.PD_QUOTA_CODE = set.Tables[0].Rows[0]["PD_QUOTA_CODE"].ToString();
            tb_quota_detail_tmp.COMPANY_NAME = set.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
            tb_quota_detail_tmp.FILE_NAME = set.Tables[0].Rows[0]["FILE_NAME"].ToString();
            tb_quota_detail_tmp.FILE_SYSNAME = set.Tables[0].Rows[0]["FILE_SYSNAME"].ToString();
            tb_quota_detail_tmp.COMPANY_CODE = set.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
            tb_quota_detail_tmp.FILE_TYPE = set.Tables[0].Rows[0]["FILE_TYPE"].ToString();
            return tb_quota_detail_tmp;
        }

        public bool Update(SMZJ.Model.TB_QUOTA_DETAIL_TMP model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_QUOTA_DETAIL_TMP set ");
            builder.Append("PD_QUOTA_CODE=:PD_QUOTA_CODE,");
            builder.Append("COMPANY_NAME=:COMPANY_NAME,");
            builder.Append("FILE_NAME=:FILE_NAME,");
            builder.Append("FILE_SYSNAME=:FILE_SYSNAME,");
            builder.Append("COMPANY_CODE=:COMPANY_CODE,");
            builder.Append("FILE_TYPE=:FILE_TYPE");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 30), new OracleParameter(":COMPANY_NAME", OracleType.VarChar, 50), new OracleParameter(":FILE_NAME", OracleType.VarChar, 30), new OracleParameter(":FILE_SYSNAME", OracleType.VarChar, 50), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 20), new OracleParameter(":FILE_TYPE", OracleType.VarChar, 20), new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = model.PD_QUOTA_CODE;
            cmdParms[1].Value = model.COMPANY_NAME;
            cmdParms[2].Value = model.FILE_NAME;
            cmdParms[3].Value = model.FILE_SYSNAME;
            cmdParms[4].Value = model.COMPANY_CODE;
            cmdParms[5].Value = model.FILE_TYPE;
            cmdParms[6].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

