namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Text;
    using SMZJ.Model;

    public class TB_QUOTA_DETAIL
    {
        public bool Add(SMZJ.Model.TB_QUOTA_DETAIL model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into TB_QUOTA_DETAIL(");
            builder.Append("AUTO_NO,PD_QUOTA_CODE,COMPANY_NAME,FILE_NAME,FILE_SYSNAME,COMPANY_CODE,FILE_TYPE,ISRECEIVE,PD_UP_MONEY,PD_QUOTA_SERVERPK,IF_SHOW,ISHUIZHI,RECEIVE_MAN,HUIZHI_MAN)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_QUOTA_CODE,:COMPANY_NAME,:FILE_NAME,:FILE_SYSNAME,:COMPANY_CODE,:FILE_TYPE,:ISRECEIVE,:PD_UP_MONEY,:PD_QUOTA_SERVERPK,:IF_SHOW,:ISHUIZHI,:RECEIVE_MAN,:HUIZHI_MAN)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 8), new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 200), new OracleParameter(":COMPANY_NAME", OracleType.VarChar, 200), new OracleParameter(":FILE_NAME", OracleType.VarChar, 200), new OracleParameter(":FILE_SYSNAME", OracleType.VarChar, 200), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 200), new OracleParameter(":FILE_TYPE", OracleType.VarChar, 200), new OracleParameter(":ISRECEIVE", OracleType.Char, 1), new OracleParameter(":PD_UP_MONEY", OracleType.Number, 0x12), new OracleParameter(":PD_QUOTA_SERVERPK", OracleType.NVarChar), new OracleParameter(":IF_SHOW", OracleType.Char, 1), new OracleParameter(":ISHUIZHI", OracleType.Char, 1), new OracleParameter(":RECEIVE_MAN", OracleType.VarChar, 200), new OracleParameter(":HUIZHI_MAN", OracleType.VarChar, 200) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_QUOTA_CODE;
            cmdParms[2].Value = model.COMPANY_NAME;
            cmdParms[3].Value = model.FILE_NAME;
            cmdParms[4].Value = model.FILE_SYSNAME;
            cmdParms[5].Value = model.COMPANY_CODE;
            cmdParms[6].Value = model.FILE_TYPE;
            cmdParms[7].Value = model.ISRECEIVE;
            cmdParms[8].Value = model.PD_UP_MONEY;
            cmdParms[9].Value = model.PD_QUOTA_SERVERPK;
            cmdParms[10].Value = model.IF_SHOW;
            cmdParms[11].Value = model.ISHUIZHI;
            cmdParms[12].Value = model.RECEIVE_MAN;
            cmdParms[13].Value = model.HUIZHI_MAN;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA_DETAIL ");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA_DETAIL ");
            builder.Append(" where AUTO_NO in (" + AUTO_NOlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool DeleteProject(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA_DETAIL ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 100) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Exists(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from TB_QUOTA_DETAIL");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_QUOTA_CODE,COMPANY_NAME,FILE_NAME,FILE_SYSNAME,PD_QUOTA_SERVERPK,COMPANY_CODE,FILE_TYPE,trim(to_char(PD_UP_MONEY,9999999999999999999999990.9999))PD_UP_MONEY,ISRECEIVE,ISHUIZHI,RECEIVE_MAN,HUIZHI_MAN,RECEIVE_MANNAME,HUIZHI_MANNAME,IF_SHOW,ISRECEIVE_CH,ISHUIZHI_CH ");
            builder.Append(" FROM View_QUOTA_DETAIL_GetList ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by AUTO_NO ");
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "TB_QUOTA_DETAIL");
        }

        public SMZJ.Model.TB_QUOTA_DETAIL GetModel(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT  AUTO_NO, PD_QUOTA_CODE, COMPANY_NAME, FILE_NAME, FILE_SYSNAME, COMPANY_CODE, FILE_TYPE, PD_UP_MONEY, PD_QUOTA_SERVERPK, IF_SHOW,ISRECEIVE,ISHUIZHI,RECEIVE_MAN,HUIZHI_MAN,RECEIVE_MANNAME,HUIZHI_MANNAME ");
            builder.Append(" from View_QUOTA_DETAIL_GetList ");
            builder.Append(" where PD_QUOTA_CODE=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.Model.TB_QUOTA_DETAIL();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                tb_quota_detail.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            tb_quota_detail.PD_QUOTA_CODE = set.Tables[0].Rows[0]["PD_QUOTA_CODE"].ToString();
            tb_quota_detail.COMPANY_NAME = set.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
            tb_quota_detail.FILE_NAME = set.Tables[0].Rows[0]["FILE_NAME"].ToString();
            tb_quota_detail.FILE_SYSNAME = set.Tables[0].Rows[0]["FILE_SYSNAME"].ToString();
            tb_quota_detail.COMPANY_CODE = set.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
            tb_quota_detail.FILE_TYPE = set.Tables[0].Rows[0]["FILE_TYPE"].ToString();
            tb_quota_detail.PD_QUOTA_SERVERPK = set.Tables[0].Rows[0]["PD_QUOTA_SERVERPK"].ToString();
            tb_quota_detail.PD_UP_MONEY = set.Tables[0].Rows[0]["PD_UP_MONEY"].ToString();
            tb_quota_detail.ISRECEIVE = set.Tables[0].Rows[0]["ISRECEIVE"].ToString();
            tb_quota_detail.ISHUIZHI = set.Tables[0].Rows[0]["ISHUIZHI"].ToString();
            tb_quota_detail.RECEIVE_MAN = set.Tables[0].Rows[0]["RECEIVE_MANNAME"].ToString();
            tb_quota_detail.HUIZHI_MAN = set.Tables[0].Rows[0]["RECEIVE_MANNAME"].ToString();
            return tb_quota_detail;
        }

        public bool GetShiDFouJS_Model(string PD_QUOTA_CODE, int ISRECEIVE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from TB_QUOTA_DETAIL ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE and ISRECEIVE=:ISRECEIVE and trim(IF_SHOW)=1");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50), new OracleParameter(":ISRECEIVE", OracleType.Int32, 4) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            cmdParms[1].Value = ISRECEIVE;
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if ((set.Tables[0].Rows.Count > 0) && (int.Parse(set.Tables[0].Rows[0][0].ToString()) > 0))
            {
                return false;
            }
            return true;
        }

        public SMZJ.Model.TB_QUOTA_DETAIL GetSonServerPK_Model(string COMPANY_CODE, string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select distinct PD_QUOTA_SERVERPK,RECEIVE_MAN from TB_QUOTA_DETAIL ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE and trim(COMPANY_CODE)=:COMPANY_CODE and trim(IF_SHOW)=1");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            cmdParms[1].Value = COMPANY_CODE;
            SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.Model.TB_QUOTA_DETAIL();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                tb_quota_detail.PD_QUOTA_SERVERPK = set.Tables[0].Rows[0]["PD_QUOTA_SERVERPK"].ToString();
                tb_quota_detail.RECEIVE_MAN = set.Tables[0].Rows[0]["RECEIVE_MAN"].ToString();
                return tb_quota_detail;
            }
            return null;
        }

        internal void InPutXZXX(string PD_QUOTA_CODE, string PD_QUOTA_FWDATA, string PD_QUOTA_ZBWH, string DatabaseName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT YSDWDM,sum(JE)JE FROM ZB_MXZB_HR group by YSDWDM,FWRQ,MXZBWH having FWRQ=@FWRQ AND MXZBWH=@MXZBWH ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@FWRQ", SqlDbType.NVarChar, 50), new SqlParameter("@MXZBWH", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_FWDATA;
            cmdParms[1].Value = PD_QUOTA_ZBWH;
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            builder = new StringBuilder();
            builder.Append("insert into TB_QUOTA_DETAIL(PD_QUOTA_CODE,COMPANY_CODE,PD_UP_MONEY,IF_SHOW) values(:PD_QUOTA_CODE,:COMPANY_CODE,:PD_UP_MONEY,1)");
            OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 50), new OracleParameter(":PD_UP_MONEY", OracleType.VarChar, 50) };
            if ((set != null) && (set.Tables.Count > 0))
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    parameterArray2[0].Value = PD_QUOTA_CODE;
                    parameterArray2[1].Value = row["YSDWDM"];
                    parameterArray2[2].Value = row["JE"];
                    DbHelperOra.ExecuteSql(builder.ToString(), parameterArray2);
                }
                builder = new StringBuilder();
                builder.Append("update ZB_MXZB_HR set IsFlag=1 where FWRQ=@FWRQ AND MXZBWH=@MXZBWH");
                DbHelperSQL.Query(builder.ToString(), cmdParms);
            }
        }

        public bool IsHuiZhi(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from TB_QUOTA_DETAIL ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE and trim(ISRECEIVE)=0 and trim(IF_SHOW)=1");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return false;
            }
            return (int.Parse(set.Tables[0].Rows[0][0].ToString()) == 0);
        }

        public bool Update(SMZJ.Model.TB_QUOTA_DETAIL model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_QUOTA_DETAIL set ");
            builder.Append("PD_QUOTA_CODE=:PD_QUOTA_CODE,");
            builder.Append("COMPANY_NAME=:COMPANY_NAME,");
            builder.Append("FILE_NAME=:FILE_NAME,");
            builder.Append("FILE_SYSNAME=:FILE_SYSNAME,");
            builder.Append("COMPANY_CODE=:COMPANY_CODE,");
            builder.Append("FILE_TYPE=:FILE_TYPE");
            builder.Append("ISRECEIVE=:ISRECEIVE");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 30), new OracleParameter(":COMPANY_NAME", OracleType.VarChar, 50), new OracleParameter(":FILE_NAME", OracleType.VarChar, 30), new OracleParameter(":FILE_SYSNAME", OracleType.VarChar, 50), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 20), new OracleParameter(":FILE_TYPE", OracleType.VarChar, 20), new OracleParameter(":ISRECEIVE", OracleType.VarChar, 20), new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = model.PD_QUOTA_CODE;
            cmdParms[1].Value = model.COMPANY_NAME;
            cmdParms[2].Value = model.FILE_NAME;
            cmdParms[3].Value = model.FILE_SYSNAME;
            cmdParms[4].Value = model.COMPANY_CODE;
            cmdParms[5].Value = model.FILE_TYPE;
            cmdParms[6].Value = model.ISRECEIVE;
            cmdParms[7].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateIsReceive(SMZJ.Model.TB_QUOTA_DETAIL model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_QUOTA_DETAIL set ");
            builder.Append("ISRECEIVE=:ISRECEIVE");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":ISRECEIVE", OracleType.VarChar, 20), new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = model.ISRECEIVE;
            cmdParms[1].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSonServerPK(string PD_QUOTA_CODE, string PD_QUOTA_SERVERPK, string ISRECEIVE, string ISHUIZHI, string RECEIVEMAN, string HUIZHIMAN)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_QUOTA_DETAIL set PD_QUOTA_SERVERPK=:PD_QUOTA_SERVERPK,ISRECEIVE=:ISRECEIVE,ISHUIZHI=:ISHUIZHI,RECEIVE_MAN=:RECEIVE_MAN,HUIZHI_MAN=:HUIZHI_MAN ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE and trim(IF_SHOW)=1");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":ISRECEIVE", OracleType.VarChar, 10), new OracleParameter(":ISHUIZHI", OracleType.VarChar, 10), new OracleParameter(":RECEIVE_MAN", OracleType.VarChar, 50), new OracleParameter(":HUIZHI_MAN", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 100) };
            cmdParms[0].Value = PD_QUOTA_SERVERPK;
            cmdParms[1].Value = ISRECEIVE;
            cmdParms[2].Value = ISHUIZHI;
            cmdParms[3].Value = RECEIVEMAN;
            cmdParms[4].Value = HUIZHIMAN;
            cmdParms[5].Value = PD_QUOTA_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSonServerPK(string PD_QUOTA_CODE, string COMPANY_CODE, string PD_QUOTA_SERVERPK, string ISRECEIVE, string ISHUIZHI, string RECEIVEMAN, string HUIZHIMAN)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_QUOTA_DETAIL set PD_QUOTA_SERVERPK=:PD_QUOTA_SERVERPK,ISRECEIVE=:ISRECEIVE,ISHUIZHI=:ISHUIZHI,RECEIVE_MAN=:RECEIVE_MAN,HUIZHI_MAN=:HUIZHI_MAN ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE and COMPANY_CODE=:COMPANY_CODE and trim(IF_SHOW)=1");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_SERVERPK", OracleType.VarChar, 100), new OracleParameter(":ISRECEIVE", OracleType.VarChar, 10), new OracleParameter(":ISHUIZHI", OracleType.VarChar, 10), new OracleParameter(":RECEIVE_MAN", OracleType.VarChar, 50), new OracleParameter(":HUIZHI_MAN", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 100), new OracleParameter(":COMPANY_CODE", OracleType.VarChar, 100) };
            cmdParms[0].Value = PD_QUOTA_SERVERPK;
            cmdParms[1].Value = ISRECEIVE;
            cmdParms[2].Value = ISHUIZHI;
            cmdParms[3].Value = RECEIVEMAN;
            cmdParms[4].Value = HUIZHIMAN;
            cmdParms[5].Value = PD_QUOTA_CODE;
            cmdParms[6].Value = COMPANY_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

