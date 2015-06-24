namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using SoMeTech.DataAccess;
    using SoMeTech.User;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using SMZJ.Model;

    public class TB_QUOTA_DAL
    {
        public void Add(TB_QUOTA_Model model, string wh)
        {
            model.PD_QUOTA_CODE = DateTime.Now.ToString("yyyyMMddhhmmssffffff");
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into TB_QUOTA(");
            builder.Append("AUTO_NO,PD_QUOTA_CODE,PD_QUOTA_NAME,PD_YEAR,PD_QUOTA_LWJG,PD_QUOTA_IFUP,PD_QUOTA_ZJXZ,PD_QUOTA_TARGET,PD_QUOTA_STANDARD,PD_QUOTA_BASIS,PD_QUOTA_IFXZQS,PD_QUOTA_IFPASS,PD_QUOTA_BASIS_JG,PD_QUOTA_INPUT_MAN,PD_QUOTA_PASS_DATE,PD_QUOTA_ACCEPT_MAN,PD_QUOTA_PASS_MAN,PD_QUOTA_ACCEPT_COMPANY,PD_QUOTA_ACCEPT_DATE,PD_QUOTA_IFLLYQS,PD_QUOTA_FILE,PD_QUOTA_XZ_ACCEPT_COMPANY,PD_QUOTA_XZ_ACCEPT_DATE,PD_QUOTA_MONEY_TOTAL,PD_QUOTA_DEPART,PD_QUOTA_JGYQ,PD_QUOTA_INPUT_DATE,PD_QUOTA_INPUT_COMPANY,PD_QUOTA_XZ_ACCEPT_MAN,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_QUOTA_ZBWH,PD_QUOTA_FWDATA,PD_QUOTA_COMPANY,PD_QUOTA_ZBYT,PD_QUOTA_QCDW,PD_QUOTA_QCBM,PD_QUOTA_GLLX,PD_QUOTA_JJLX,");
            builder.Append("PD_QUOTA_ZJLY,PD_QUOTA_ZGKJ,PD_QUOTA_XMZGBM,PD_QUOTA_SERVERPK,PD_QUOTA_INPUT_DEPART,PD_QUOTA_ZBXDZH,PD_QUOTA_ZGBM,PD_QUOTA_PICI,");
            builder.Append("PD_QUOTA_YSLX,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_QUOTA_CODE,:PD_QUOTA_NAME,:PD_YEAR,:PD_QUOTA_LWJG,:PD_QUOTA_IFUP,:PD_QUOTA_ZJXZ,:PD_QUOTA_TARGET,:PD_QUOTA_STANDARD,:PD_QUOTA_BASIS,:PD_QUOTA_IFXZQS,:PD_QUOTA_IFPASS,:PD_QUOTA_BASIS_JG,:PD_QUOTA_INPUT_MAN,:PD_QUOTA_PASS_DATE,:PD_QUOTA_ACCEPT_MAN,:PD_QUOTA_PASS_MAN,:PD_QUOTA_ACCEPT_COMPANY,:PD_QUOTA_ACCEPT_DATE,:PD_QUOTA_IFLLYQS,:PD_QUOTA_FILE,:PD_QUOTA_XZ_ACCEPT_COMPANY,:PD_QUOTA_XZ_ACCEPT_DATE,:PD_QUOTA_MONEY_TOTAL,:PD_QUOTA_DEPART,:PD_QUOTA_JGYQ,:PD_QUOTA_INPUT_DATE,:PD_QUOTA_INPUT_COMPANY,:PD_QUOTA_XZ_ACCEPT_MAN,:PD_PROJ_STATUS,:PD_PROJ_LAST_AUDIT_STATUS,:PD_IS_RETURN,:PD_ISOUT_QUOTA,:PD_QUOTA_ZBWH,:PD_QUOTA_FWDATA,:PD_QUOTA_COMPANY,:PD_QUOTA_ZBYT,:PD_QUOTA_QCDW,:PD_QUOTA_QCBM,:PD_QUOTA_GLLX,:PD_QUOTA_JJLX,");
            builder.Append(":PD_QUOTA_ZJLY,:PD_QUOTA_ZGKJ,:PD_QUOTA_XMZGBM,:PD_QUOTA_SERVERPK,:PD_QUOTA_INPUT_DEPART,:PD_QUOTA_ZBXDZH,:PD_QUOTA_ZGBM,:PD_QUOTA_PICI,");
            builder.Append(":PD_QUOTA_YSLX,:Free1,:Free2,:Free3,:Free4,:Free5,:Free6,:Free7,:Free8,:Free9,:Free10)");
            builder.Append(" RETURNING PD_QUOTA_CODE INTO :R_Auto_No");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":AUTO_NO", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_LWJG", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_IFUP", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_ZJXZ", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_TARGET", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_STANDARD", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_BASIS", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZQS", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_IFPASS", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_BASIS_JG", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_INPUT_MAN", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_PASS_DATE", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_ACCEPT_MAN", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_PASS_MAN", OracleType.VarChar, 30), 
                new OracleParameter(":PD_QUOTA_ACCEPT_COMPANY", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_ACCEPT_DATE", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_IFLLYQS", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_FILE", OracleType.VarChar, 300), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_COMPANY", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_DATE", OracleType.DateTime), new OracleParameter(":PD_QUOTA_MONEY_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_DEPART", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_JGYQ", OracleType.VarChar, 0x7d0), new OracleParameter(":PD_QUOTA_INPUT_DATE", OracleType.DateTime), new OracleParameter(":PD_QUOTA_INPUT_COMPANY", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_MAN", OracleType.VarChar, 30), new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":PD_ISOUT_QUOTA", OracleType.Number, 4), 
                new OracleParameter(":PD_QUOTA_ZBWH", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_FWDATA", OracleType.DateTime), new OracleParameter(":PD_QUOTA_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_QUOTA_ZBYT", OracleType.VarChar, 100), new OracleParameter(":PD_QUOTA_QCDW", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_QCBM", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_GLLX", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_JJLX", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_ZJLY", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_ZGKJ", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_XMZGBM", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_SERVERPK", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_INPUT_DEPART", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_ZBXDZH", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_ZGBM", OracleType.VarChar, 50), 
                new OracleParameter(":PD_QUOTA_PICI", OracleType.VarChar, 4), new OracleParameter(":PD_QUOTA_YSLX", OracleType.VarChar, 100), new OracleParameter(":Free1", OracleType.VarChar, 100), new OracleParameter(":Free2", OracleType.VarChar, 100), new OracleParameter(":Free3", OracleType.VarChar, 100), new OracleParameter(":Free4", OracleType.VarChar, 100), new OracleParameter(":Free5", OracleType.VarChar, 100), new OracleParameter(":Free6", OracleType.Int32, 4), new OracleParameter(":Free7", OracleType.Int32, 4), new OracleParameter(":Free8", OracleType.Number), new OracleParameter(":Free9", OracleType.Number), new OracleParameter(":Free10", OracleType.Number), new OracleParameter(":R_Auto_No", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_QUOTA_NAME;
            cmdParms[2].Value = model.PD_YEAR;
            cmdParms[3].Value = model.PD_QUOTA_LWJG;
            cmdParms[4].Value = model.PD_QUOTA_IFUP;
            cmdParms[5].Value = model.PD_QUOTA_ZJXZ;
            cmdParms[6].Value = model.PD_QUOTA_TARGET;
            cmdParms[7].Value = model.PD_QUOTA_STANDARD;
            cmdParms[8].Value = model.PD_QUOTA_BASIS;
            cmdParms[9].Value = model.PD_QUOTA_IFXZQS;
            cmdParms[10].Value = model.PD_QUOTA_IFPASS;
            cmdParms[11].Value = model.PD_QUOTA_BASIS_JG;
            cmdParms[12].Value = model.PD_QUOTA_INPUT_MAN;
            cmdParms[13].Value = model.PD_QUOTA_PASS_DATE;
            cmdParms[14].Value = model.PD_QUOTA_ACCEPT_MAN;
            cmdParms[15].Value = model.PD_QUOTA_PASS_MAN;
            cmdParms[0x10].Value = model.PD_QUOTA_ACCEPT_COMPANY;
            cmdParms[0x11].Value = model.PD_QUOTA_ACCEPT_DATE;
            cmdParms[0x12].Value = model.PD_QUOTA_IFLLYQS;
            cmdParms[0x13].Value = model.PD_QUOTA_FILE;
            cmdParms[20].Value = model.PD_QUOTA_XZ_ACCEPT_COMPANY;
            cmdParms[0x15].Value = model.PD_QUOTA_XZ_ACCEPT_DATE;
            cmdParms[0x16].Value = model.PD_QUOTA_MONEY_TOTAL;
            cmdParms[0x17].Value = model.PD_QUOTA_DEPART;
            cmdParms[0x18].Value = model.PD_QUOTA_JGYQ;
            cmdParms[0x19].Value = model.PD_QUOTA_INPUT_DATE;
            cmdParms[0x1a].Value = model.PD_QUOTA_INPUT_COMPANY;
            cmdParms[0x1b].Value = model.PD_QUOTA_XZ_ACCEPT_MAN;
            cmdParms[0x1c].Value = model.PD_PROJ_STATUS;
            cmdParms[0x1d].Value = model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[30].Value = model.PD_IS_RETURN;
            cmdParms[0x1f].Value = model.PD_ISOUT_QUOTA;
            cmdParms[0x20].Value = model.PD_QUOTA_ZBWH;
            cmdParms[0x21].Value = model.PD_QUOTA_FWDATA;
            cmdParms[0x22].Value = model.PD_QUOTA_COMPANY;
            cmdParms[0x23].Value = model.PD_QUOTA_ZBYT;
            cmdParms[0x24].Value = model.PD_QUOTA_QCDW;
            cmdParms[0x25].Value = model.PD_QUOTA_QCBM;
            cmdParms[0x26].Value = model.PD_QUOTA_GLLX;
            cmdParms[0x27].Value = model.PD_QUOTA_JJLX;
            cmdParms[40].Value = model.PD_QUOTA_ZJLY;
            cmdParms[0x29].Value = model.PD_QUOTA_ZGKJ;
            cmdParms[0x2a].Value = model.PD_QUOTA_XMZGBM;
            cmdParms[0x2b].Value = model.PD_QUOTA_SERVERPK;
            cmdParms[0x2c].Value = model.PD_QUOTA_CODE;
            cmdParms[0x2d].Value = model.PD_QUOTA_INPUT_DEPART;
            cmdParms[0x2e].Value = model.PD_QUOTA_ZBXDZH;
            cmdParms[0x2f].Value = model.PD_QUOTA_ZGBM;
            cmdParms[0x30].Value = model.PD_QUOTA_PICI;
            cmdParms[0x31].Value = model.PD_QUOTA_YSLX;
            cmdParms[50].Value = model.Free1;
            cmdParms[0x33].Value = model.Free2;
            cmdParms[0x34].Value = model.Free3;
            cmdParms[0x35].Value = model.Free4;
            cmdParms[0x36].Value = model.Free5;
            cmdParms[0x37].Value = model.Free6;
            cmdParms[0x38].Value = model.Free7;
            cmdParms[0x39].Value = model.Free8;
            cmdParms[0x3a].Value = model.Free9;
            cmdParms[0x3b].Value = model.Free10;
            cmdParms[60].Direction = ParameterDirection.Output;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.PD_QUOTA_CODE = cmdParms[60].Value.ToString();
        }

        private void Createzb_mxzb_HR(string DatabaseName, string sqlTextPath)
        {
            string sQLString = " select *,0 as IsFlag into zb_mxzb_HR from zb_mxzb ";
            StringBuilder builder = new StringBuilder();
            if (File.Exists(sqlTextPath))
            {
                string str2 = File.ReadAllText(sqlTextPath);
                builder.Append(str2);
            }
            else
            {
                builder.Append(" CREATE TRIGGER ZB_MXZB_to_HR ON ZB_MXZB");
                builder.Append(" FOR INSERT, UPDATE, DELETE as");
                builder.Append(" declare @delCount int,@insCount int; ");
                builder.Append(" declare @GSDM nvarchar(50),@KJND nvarchar(50),@MXZBLB nvarchar(50) ,@MXZBBH numeric(10),@IsFlag int ");
                builder.Append(" select @delCount=count(*) from   deleted; select @insCount=count(*) from inserted; select @delCount,@insCount;");
                builder.Append(" if (@delCount)=0 and (@insCount)>0 ");
                builder.Append(" begin ");
                builder.Append(" insert into zb_mxzb_HR select *,0 from inserted ");
                builder.Append(" end ");
                builder.Append(" else if(@delCount)>0 and (@insCount)=0 ");
                builder.Append(" begin ");
                builder.Append(" declare MyCursor1 cursor local for ");
                builder.Append(" select GSDM,KJND,MXZBLB,MXZBBH from deleted ");
                builder.Append(" open MyCursor1 ");
                builder.Append(" fetch next from MyCursor1 into @GSDM,@KJND,@MXZBLB,@MXZBBH ");
                builder.Append(" while @@FETCH_STATUS = 0 ");
                builder.Append(" begin ");
                builder.Append(" delete zb_mxzb_HR where GSDM=@GSDM and KJND=@KJND and MXZBLB=@MXZBLB and MXZBBH=@MXZBBH ");
                builder.Append(" fetch next from MyCursor1 into @GSDM,@KJND,@MXZBLB,@MXZBBH ");
                builder.Append(" end ");
                builder.Append(" close MyCursor1 ");
                builder.Append(" deallocate MyCursor1 ");
                builder.Append(" end ");
                builder.Append(" else if(@delCount)>0 and (@insCount)>0 ");
                builder.Append(" begin ");
                builder.Append(" declare MyCursor1 cursor local for ");
                builder.Append(" select GSDM,KJND,MXZBLB,MXZBBH from deleted ");
                builder.Append(" open MyCursor1 ");
                builder.Append(" fetch next from MyCursor1 into @GSDM,@KJND,@MXZBLB,@MXZBBH ");
                builder.Append(" while @@FETCH_STATUS = 0 ");
                builder.Append(" begin ");
                builder.Append(" select @IsFlag=IsFlag from zb_mxzb_HR where GSDM=@GSDM and KJND=@KJND and MXZBLB=@MXZBLB and MXZBBH=@MXZBBH ");
                builder.Append(" delete zb_mxzb_HR where GSDM=@GSDM and KJND=@KJND and MXZBLB=@MXZBLB and MXZBBH=@MXZBBH ");
                builder.Append(" insert into zb_mxzb_HR select *,@IsFlag from inserted ");
                builder.Append(" fetch next from MyCursor1 into @GSDM,@KJND,@MXZBLB,@MXZBBH ");
                builder.Append(" end ");
                builder.Append(" close MyCursor1 ");
                builder.Append(" deallocate MyCursor1 ");
                builder.Append(" end ");
            }
            DbHelperSQL.ExecuteSql(sQLString);
            DbHelperSQL.ExecuteSql(builder.ToString());
        }

        public bool Delete(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA ");
            builder.Append(" where PD_QUOTA_CODE=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 100) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_QUOTA_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_QUOTA ");
            builder.Append(" where PD_QUOTA_CODE in (" + PD_QUOTA_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int AUTO_NO)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from TB_QUOTA");
            builder.Append(" where AUTO_NO=:AUTO_NO ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 4) };
            cmdParms[0].Value = AUTO_NO;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        internal DataSet GetInputData(DateTime startDate, DateTime endDate, string DatabaseName, string sqlTextPath)
        {
            DbHelperSQL.connectionString = DbHelperSQL.connectionString;
            DatabaseName = ConfigurationManager.AppSettings["SqlDBName"].ToString();
            if (DbHelperSQL.Exists(" SELECT count(Name) FROM " + DatabaseName + "..SysObjects Where  Name='zb_mxzb_HR'"))
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(" select top 20 * from V_ZB_InPut ");
                builder.Append(" where 发文日期>=@startDate and 发文日期<=@endDate");
                SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@startDate", SqlDbType.DateTime), new SqlParameter("@endDate", SqlDbType.DateTime) };
                cmdParms[0].Value = startDate;
                cmdParms[1].Value = endDate;
                return DbHelperSQL.Query(builder.ToString(), cmdParms);
            }
            if ((DatabaseName != null) && (DatabaseName.Trim() != ""))
            {
                this.Createzb_mxzb_HR(DatabaseName, sqlTextPath);
            }
            return null;
        }

        internal DataSet GetInputDropDownList(string CompanyPK)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select dataname,showname from GOV_TC_DB_COMPANYDATADZ ");
            builder.Append(" where trim(companybh)=trim(:companybh)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":companybh", OracleType.VarChar, 30) };
            cmdParms[0].Value = CompanyPK.Trim();
            return DbHelperOra.Query(builder.ToString(), cmdParms);
        }

        public TB_QUOTA_Model GetIsUpModel(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PD_QUOTA_ISUP,PD_QUOTA_INPUT_DEPART,PD_QUOTA_SERVERPK,PD_QUOTA_IFXZHZ,PD_QUOTA_IFSBXM from TB_QUOTA ");
            builder.Append(" where trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 30) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            TB_QUOTA_Model model = new TB_QUOTA_Model();
            if (set.Tables[0].Rows.Count > 0)
            {
                model.PD_QUOTA_ISUP = set.Tables[0].Rows[0]["PD_QUOTA_ISUP"].ToString().Trim();
                model.PD_QUOTA_INPUT_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_DEPART"].ToString().Trim();
                model.PD_QUOTA_SERVERPK = set.Tables[0].Rows[0]["PD_QUOTA_SERVERPK"].ToString().Trim();
                model.PD_QUOTA_IFXZHZ = set.Tables[0].Rows[0]["PD_QUOTA_IFXZHZ"].ToString().Trim();
                model.PD_QUOTA_IFSBXM = set.Tables[0].Rows[0]["PD_QUOTA_IFSBXM"].ToString().Trim();
                return model;
            }
            return null;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select distinct t.AUTO_NO,t.PD_QUOTA_CODE,PD_QUOTA_NAME,PD_YEAR,PD_QUOTA_LWJG,PD_QUOTA_IFUP,PD_QUOTA_ZJXZ,PD_QUOTA_TARGET,PD_QUOTA_STANDARD,PD_QUOTA_BASIS,PD_QUOTA_IFXZQS,PD_QUOTA_IFPASS,PD_QUOTA_BASIS_JG,PD_QUOTA_INPUT_MAN,PD_QUOTA_PASS_DATE,PD_QUOTA_ACCEPT_MAN,PD_QUOTA_PASS_MAN,PD_QUOTA_ACCEPT_COMPANY,PD_QUOTA_ACCEPT_DATE,PD_QUOTA_IFLLYQS,PD_QUOTA_FILE,PD_QUOTA_XZ_ACCEPT_COMPANY,PD_QUOTA_XZ_ACCEPT_DATE,PD_QUOTA_MONEY_TOTAL,PD_QUOTA_DEPART,PD_QUOTA_JGYQ,PD_QUOTA_INPUT_DATE,PD_QUOTA_INPUT_COMPANY,PD_QUOTA_XZ_ACCEPT_MAN,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,pd_quota_zbwh,PD_QUOTA_PICI,PD_QUOTA_YSLX,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10 ");
            builder.Append(" FROM TB_QUOTA t ");
            builder.Append(" left join TB_QUOTA_DETAIL det on det.pd_quota_code=t.Pd_Quota_Code ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("AUTO_NO", "TB_QUOTA");
        }

        internal int? GetMaxPiCi(string PD_QUOTA_ZBWH)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select Max(pd_quota_pici)MaxPC from tb_quota where trim(PD_QUOTA_ZBWH)=:PD_QUOTA_ZBWH ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_ZBWH", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_ZBWH.Trim();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (((set != null) && (set.Tables.Count > 0)) && ((set.Tables[0].Rows.Count > 0) && (set.Tables[0].Rows[0][0].ToString().Trim().Length != 0)))
            {
                return new int?(int.Parse(set.Tables[0].Rows[0][0].ToString()) + 1);
            }
            return 1;
        }

        public TB_QUOTA_Model GetModel(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PD_QUOTA_CODE,PD_QUOTA_NAME,PD_YEAR,PD_QUOTA_LWJG,PD_QUOTA_IFUP,PD_QUOTA_ZJXZ,PD_QUOTA_TARGET,PD_QUOTA_STANDARD,PD_QUOTA_BASIS,PD_QUOTA_BASIS_JG,PD_QUOTA_INPUT_MAN,PD_QUOTA_INPUT_DATE,PD_QUOTA_INPUT_COMPANY,PD_QUOTA_IFPASS,PD_QUOTA_PASS_DATE,PD_QUOTA_PASS_MAN,PD_QUOTA_ACCEPT_MAN,PD_QUOTA_FILE,PD_QUOTA_IFLLYQS,PD_QUOTA_ACCEPT_DATE,PD_QUOTA_ACCEPT_COMPANY,PD_QUOTA_XZ_ACCEPT_COMPANY,PD_QUOTA_IFXZQS,PD_QUOTA_MONEY_TOTAL,PD_QUOTA_XZ_ACCEPT_DATE,PD_PROJ_STATUS,PD_QUOTA_DEPART,PD_QUOTA_JGYQ,PD_QUOTA_XZ_ACCEPT_MAN,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_QUOTA_LX,PD_QUOTA_PASS_COMPANY,AUTO_NO,PD_QUOTA_SERVERPK,PD_QUOTA_ZBWH,PD_QUOTA_FWDATA,PD_QUOTA_COMPANY,PD_QUOTA_ZBYT,PD_QUOTA_QCDW,PD_QUOTA_QCBM,PD_QUOTA_GLLX,PD_QUOTA_JJLX,PD_QUOTA_ZJLY,PD_QUOTA_ZGKJ,PD_QUOTA_XMZGBM,PD_QUOTA_GZSPH,PD_QUOTA_ISUP,PD_QUOTA_INPUT_DEPART,PD_QUOTA_ACCEPT_DEPART,PD_QUOTA_XZ_ACCEPT_DEPART,PD_QUOTA_UP_DATE,PD_QUOTA_UP_MAN,PD_QUOTA_UP_COMPANY,PD_QUOTA_UP_DEPART,PD_QUOTA_HZ_DATE,PD_QUOTA_HZ_MAN,PD_QUOTA_HZ_COMPANY,PD_QUOTA_HZ_DEPART,PD_QUOTA_ZBXDZH,PD_QUOTA_ZGBM,PD_QUOTA_PASS_DEPART,PD_QUOTA_WH,PD_QUOTA_IFXZHZ,PD_QUOTA_IFSBXM,PD_QUOTA_PICI ,PD_QUOTA_YSLX,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10 ");
            builder.Append(" from TB_QUOTA where PD_QUOTA_CODE=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            TB_QUOTA_Model model = new TB_QUOTA_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.PD_QUOTA_CODE = set.Tables[0].Rows[0]["PD_QUOTA_CODE"].ToString();
            model.PD_QUOTA_NAME = set.Tables[0].Rows[0]["PD_QUOTA_NAME"].ToString();
            model.PD_YEAR = set.Tables[0].Rows[0]["PD_YEAR"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_LWJG"].ToString() != "")
            {
                model.PD_QUOTA_LWJG = new int?(int.Parse(set.Tables[0].Rows[0]["PD_QUOTA_LWJG"].ToString()));
            }
            model.PD_QUOTA_IFUP = set.Tables[0].Rows[0]["PD_QUOTA_IFUP"].ToString();
            model.PD_QUOTA_ZJXZ = set.Tables[0].Rows[0]["PD_QUOTA_ZJXZ"].ToString();
            model.PD_QUOTA_TARGET = set.Tables[0].Rows[0]["PD_QUOTA_TARGET"].ToString();
            model.PD_QUOTA_STANDARD = set.Tables[0].Rows[0]["PD_QUOTA_STANDARD"].ToString();
            model.PD_QUOTA_BASIS = set.Tables[0].Rows[0]["PD_QUOTA_BASIS"].ToString();
            model.PD_QUOTA_BASIS_JG = set.Tables[0].Rows[0]["PD_QUOTA_BASIS_JG"].ToString();
            model.PD_QUOTA_INPUT_MAN = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_MAN"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_INPUT_DATE"].ToString() != "")
            {
                model.PD_QUOTA_INPUT_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_QUOTA_INPUT_DATE"].ToString()));
            }
            model.PD_QUOTA_INPUT_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_COMPANY"].ToString();
            model.PD_QUOTA_IFPASS = set.Tables[0].Rows[0]["PD_QUOTA_IFPASS"].ToString();
            model.PD_QUOTA_PASS_DATE = set.Tables[0].Rows[0]["PD_QUOTA_PASS_DATE"].ToString();
            model.PD_QUOTA_PASS_MAN = set.Tables[0].Rows[0]["PD_QUOTA_PASS_MAN"].ToString();
            model.PD_QUOTA_ACCEPT_MAN = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_MAN"].ToString();
            model.PD_QUOTA_FILE = set.Tables[0].Rows[0]["PD_QUOTA_FILE"].ToString();
            model.PD_QUOTA_IFLLYQS = set.Tables[0].Rows[0]["PD_QUOTA_IFLLYQS"].ToString();
            model.PD_QUOTA_ACCEPT_DATE = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_DATE"].ToString();
            model.PD_QUOTA_ACCEPT_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_COMPANY"].ToString();
            model.PD_QUOTA_XZ_ACCEPT_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_COMPANY"].ToString();
            model.PD_QUOTA_IFXZQS = set.Tables[0].Rows[0]["PD_QUOTA_IFXZQS"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_MONEY_TOTAL"].ToString() != "")
            {
                model.PD_QUOTA_MONEY_TOTAL = decimal.Parse(set.Tables[0].Rows[0]["PD_QUOTA_MONEY_TOTAL"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_DATE"].ToString() != "")
            {
                model.PD_QUOTA_XZ_ACCEPT_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_DATE"].ToString()));
            }
            model.PD_PROJ_STATUS = set.Tables[0].Rows[0]["PD_PROJ_STATUS"].ToString();
            model.PD_QUOTA_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_DEPART"].ToString();
            model.PD_QUOTA_JGYQ = set.Tables[0].Rows[0]["PD_QUOTA_JGYQ"].ToString();
            model.PD_QUOTA_XZ_ACCEPT_MAN = set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_MAN"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString() != "")
            {
                model.PD_IS_RETURN = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString() != "")
            {
                model.PD_ISOUT_QUOTA = new int?(int.Parse(set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString()));
            }
            model.PD_QUOTA_PASS_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_PASS_COMPANY"].ToString();
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_QUOTA_SERVERPK = set.Tables[0].Rows[0]["PD_QUOTA_SERVERPK"].ToString();
            model.PD_QUOTA_ZBWH = set.Tables[0].Rows[0]["PD_QUOTA_ZBWH"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_FWDATA"].ToString() != "")
            {
                model.PD_QUOTA_FWDATA = DateTime.Parse(set.Tables[0].Rows[0]["PD_QUOTA_FWDATA"].ToString());
            }
            model.PD_QUOTA_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_COMPANY"].ToString();
            model.PD_QUOTA_ZBYT = set.Tables[0].Rows[0]["PD_QUOTA_ZBYT"].ToString();
            model.PD_QUOTA_QCDW = set.Tables[0].Rows[0]["PD_QUOTA_QCDW"].ToString();
            model.PD_QUOTA_QCBM = set.Tables[0].Rows[0]["PD_QUOTA_QCBM"].ToString();
            model.PD_QUOTA_GLLX = set.Tables[0].Rows[0]["PD_QUOTA_GLLX"].ToString();
            model.PD_QUOTA_JJLX = set.Tables[0].Rows[0]["PD_QUOTA_JJLX"].ToString();
            model.PD_QUOTA_ZJLY = set.Tables[0].Rows[0]["PD_QUOTA_ZJLY"].ToString();
            model.PD_QUOTA_ZGKJ = set.Tables[0].Rows[0]["PD_QUOTA_ZGKJ"].ToString();
            model.PD_QUOTA_XMZGBM = set.Tables[0].Rows[0]["PD_QUOTA_XMZGBM"].ToString();
            model.PD_QUOTA_GZSPH = set.Tables[0].Rows[0]["PD_QUOTA_GZSPH"].ToString();
            model.PD_QUOTA_ISUP = set.Tables[0].Rows[0]["PD_QUOTA_ISUP"].ToString();
            model.PD_QUOTA_INPUT_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_DEPART"].ToString();
            model.PD_QUOTA_ACCEPT_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_DEPART"].ToString();
            model.PD_QUOTA_UP_DATE = set.Tables[0].Rows[0]["PD_QUOTA_UP_DATE"].ToString();
            model.PD_QUOTA_UP_MAN = set.Tables[0].Rows[0]["PD_QUOTA_UP_MAN"].ToString();
            model.PD_QUOTA_UP_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_UP_COMPANY"].ToString();
            model.PD_QUOTA_UP_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_UP_DEPART"].ToString();
            model.PD_QUOTA_ZBXDZH = set.Tables[0].Rows[0]["PD_QUOTA_ZBXDZH"].ToString();
            model.PD_QUOTA_ZGBM = set.Tables[0].Rows[0]["PD_QUOTA_ZGBM"].ToString();
            model.PD_QUOTA_PASS_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_PASS_DEPART"].ToString();
            model.PD_QUOTA_IFXZHZ = set.Tables[0].Rows[0]["PD_QUOTA_IFXZHZ"].ToString();
            model.PD_QUOTA_IFSBXM = set.Tables[0].Rows[0]["PD_QUOTA_IFSBXM"].ToString();
            model.PD_QUOTA_PICI = set.Tables[0].Rows[0]["PD_QUOTA_PICI"].ToString();
            model.PD_QUOTA_YSLX = set.Tables[0].Rows[0]["PD_QUOTA_YSLX"].ToString();
            model.Free1 = set.Tables[0].Rows[0]["Free1"].ToString();
            model.Free2 = set.Tables[0].Rows[0]["Free2"].ToString();
            model.Free3 = set.Tables[0].Rows[0]["Free3"].ToString();
            model.Free4 = set.Tables[0].Rows[0]["Free4"].ToString();
            model.Free5 = set.Tables[0].Rows[0]["Free5"].ToString();
            if (set.Tables[0].Rows[0]["Free6"].ToString() != "")
            {
                model.Free6 = int.Parse(set.Tables[0].Rows[0]["Free6"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free7"].ToString() != "")
            {
                model.Free7 = int.Parse(set.Tables[0].Rows[0]["Free7"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free8"].ToString() != "")
            {
                model.Free8 = decimal.Parse(set.Tables[0].Rows[0]["Free8"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free9"].ToString() != "")
            {
                model.Free9 = decimal.Parse(set.Tables[0].Rows[0]["Free9"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free10"].ToString() != "")
            {
                model.Free10 = decimal.Parse(set.Tables[0].Rows[0]["Free10"].ToString());
            }
            return model;
        }

        public TB_QUOTA_Model GetModelByCode(string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_QUOTA_CODE,PD_QUOTA_NAME,PD_YEAR,PD_QUOTA_LWJG,PD_QUOTA_LWJG_NAME,PD_QUOTA_IFUP,PD_QUOTA_ZJXZ,pd_quota_zjxzCode,PD_QUOTA_TARGET,PD_QUOTA_STANDARD,PD_QUOTA_BASIS,PD_QUOTA_IFXZQS,PD_QUOTA_IFXZQS_NAME,PD_QUOTA_IFPASS,PD_QUOTA_BASIS_JG,PD_QUOTA_INPUT_MAN,PD_QUOTA_PASS_DATE,PD_QUOTA_ACCEPT_MAN,PD_QUOTA_PASS_MAN,PD_QUOTA_ACCEPT_COMPANY,PD_QUOTA_ACCEPT_DATE,PD_QUOTA_IFLLYQS,PD_QUOTA_FILE,PD_QUOTA_XZ_ACCEPT_COMPANY,PD_QUOTA_XZ_ACCEPT_DATE,PD_QUOTA_MONEY_TOTAL,PD_QUOTA_DEPART,PD_QUOTA_JGYQ,PD_QUOTA_INPUT_DATE,PD_QUOTA_INPUT_COMPANY,PD_QUOTA_XZ_ACCEPT_MAN,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,pd_quota_zbwh,PD_QUOTA_FWDATA,PD_QUOTA_COMPANY,PD_QUOTA_ZBYT,PD_QUOTA_QCDW,PD_QUOTA_QCBM,PD_QUOTA_GLLX,PD_QUOTA_JJLX,");
            builder.Append("PD_QUOTA_PASS_COMPANY,PD_QUOTA_PASS_DEPART,PD_QUOTA_ACCEPT_DEPART,PD_QUOTA_UP_COMPANY,PD_QUOTA_UP_DEPART,PD_QUOTA_UP_DATE,PD_QUOTA_UP_MAN,PD_QUOTA_PASS_COMPANY_NAme,PD_QUOTA_ACCEPT_COMPANY_NAME,PD_QUOTA_UP_COMPANY_NAME,PD_QUOTA_PASS_DEPART_NAME,PD_QUOTA_ACCEPT_DEPART_NAME,PD_QUOTA_UP_DEPART_NAME,PD_QUOTA_PASS_MAN,PD_QUOTA_ACCEPT_MAN,PD_QUOTA_UP_MAN,PD_QUOTA_IFPASS_NAME,PD_QUOTA_IFLLYQS_NAME,");
            builder.Append("PD_QUOTA_ZJLY,PD_QUOTA_ZGKJ,PD_QUOTA_XMZGBM,PD_QUOTA_ISUP,PD_QUOTA_ISUP_NAME,PD_QUOTA_ZBXDZH,PD_QUOTA_ZGBM,PD_QUOTA_IFXZHZ,PD_QUOTA_IFXZHZ_NAME,pd_quota_serverpk,PD_QUOTA_PICI,PD_JY_MONEY,PD_QUOTA_YSLX,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10 from view_tb_quota_list ");
            builder.Append(" where PD_QUOTA_CODE=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 100) };
            cmdParms[0].Value = PD_QUOTA_CODE;
            TB_QUOTA_Model model = new TB_QUOTA_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.AUTO_NO = set.Tables[0].Rows[0]["AUTO_NO"].ToString();
            model.PD_QUOTA_CODE = set.Tables[0].Rows[0]["PD_QUOTA_CODE"].ToString();
            model.PD_QUOTA_NAME = set.Tables[0].Rows[0]["PD_QUOTA_NAME"].ToString();
            model.PD_YEAR = set.Tables[0].Rows[0]["PD_YEAR"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_LWJG"].ToString() != "")
            {
                model.PD_QUOTA_LWJG = new int?(int.Parse(set.Tables[0].Rows[0]["PD_QUOTA_LWJG"].ToString()));
            }
            model.PD_QUOTA_LWJG_NAME = set.Tables[0].Rows[0]["PD_QUOTA_LWJG_NAME"].ToString();
            model.PD_QUOTA_IFUP = set.Tables[0].Rows[0]["PD_QUOTA_IFUP"].ToString();
            model.PD_QUOTA_ZJXZ = set.Tables[0].Rows[0]["pd_quota_zjxzCode"].ToString();
            model.PD_QUOTA_TARGET = set.Tables[0].Rows[0]["PD_QUOTA_TARGET"].ToString();
            model.PD_QUOTA_STANDARD = set.Tables[0].Rows[0]["PD_QUOTA_STANDARD"].ToString();
            model.PD_QUOTA_BASIS = set.Tables[0].Rows[0]["PD_QUOTA_BASIS"].ToString();
            model.PD_QUOTA_IFXZQS = set.Tables[0].Rows[0]["PD_QUOTA_IFXZQS_NAME"].ToString();
            model.PD_QUOTA_IFPASS = set.Tables[0].Rows[0]["PD_QUOTA_IFPASS_NAME"].ToString();
            model.PD_QUOTA_BASIS_JG = set.Tables[0].Rows[0]["PD_QUOTA_BASIS_JG"].ToString();
            model.PD_QUOTA_INPUT_MAN = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_MAN"].ToString();
            model.PD_QUOTA_PASS_DATE = set.Tables[0].Rows[0]["PD_QUOTA_PASS_DATE"].ToString();
            model.PD_QUOTA_ACCEPT_MAN = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_MAN"].ToString();
            model.PD_QUOTA_PASS_MAN = set.Tables[0].Rows[0]["PD_QUOTA_PASS_MAN"].ToString();
            model.PD_QUOTA_ACCEPT_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_COMPANY_NAME"].ToString();
            model.PD_QUOTA_ACCEPT_DATE = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_DATE"].ToString();
            model.PD_QUOTA_IFLLYQS = set.Tables[0].Rows[0]["PD_QUOTA_IFLLYQS_NAME"].ToString();
            model.PD_QUOTA_IFXZHZ = set.Tables[0].Rows[0]["PD_QUOTA_IFXZHZ_NAME"].ToString();
            model.PD_QUOTA_FILE = set.Tables[0].Rows[0]["PD_QUOTA_FILE"].ToString();
            model.PD_QUOTA_XZ_ACCEPT_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_COMPANY"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_DATE"].ToString() != "")
            {
                model.PD_QUOTA_XZ_ACCEPT_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_QUOTA_MONEY_TOTAL"].ToString() != "")
            {
                model.PD_QUOTA_MONEY_TOTAL = decimal.Parse(set.Tables[0].Rows[0]["PD_QUOTA_MONEY_TOTAL"].ToString());
            }
            model.PD_QUOTA_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_DEPART"].ToString();
            model.PD_QUOTA_JGYQ = set.Tables[0].Rows[0]["PD_QUOTA_JGYQ"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_INPUT_DATE"].ToString() != "")
            {
                model.PD_QUOTA_INPUT_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_QUOTA_INPUT_DATE"].ToString()));
            }
            model.PD_QUOTA_INPUT_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_COMPANY"].ToString();
            model.INPUT_COMPANYNAME = new PublicModel();
            model.INPUT_COMPANYNAME.PK_CODE = set.Tables[0].Rows[0]["PD_QUOTA_INPUT_COMPANY"].ToString();
            model.PD_QUOTA_XZ_ACCEPT_MAN = set.Tables[0].Rows[0]["PD_QUOTA_XZ_ACCEPT_MAN"].ToString();
            model.PD_PROJ_STATUS = set.Tables[0].Rows[0]["PD_PROJ_STATUS"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
            model.PD_QUOTA_ZBWH = set.Tables[0].Rows[0]["pd_quota_zbwh"].ToString();
            if (set.Tables[0].Rows[0]["PD_QUOTA_FWDATA"].ToString() != "")
            {
                model.PD_QUOTA_FWDATA = DateTime.Parse(set.Tables[0].Rows[0]["PD_QUOTA_FWDATA"].ToString());
            }
            model.PD_QUOTA_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_COMPANY"].ToString();
            model.PD_QUOTA_ZBYT = set.Tables[0].Rows[0]["PD_QUOTA_ZBYT"].ToString();
            model.PD_QUOTA_QCDW = set.Tables[0].Rows[0]["PD_QUOTA_QCDW"].ToString();
            model.PD_QUOTA_QCBM = set.Tables[0].Rows[0]["PD_QUOTA_QCBM"].ToString();
            model.PD_QUOTA_GLLX = set.Tables[0].Rows[0]["PD_QUOTA_GLLX"].ToString();
            model.PD_QUOTA_JJLX = set.Tables[0].Rows[0]["PD_QUOTA_JJLX"].ToString();
            model.PD_QUOTA_ZJLY = set.Tables[0].Rows[0]["PD_QUOTA_ZJLY"].ToString();
            model.PD_QUOTA_ZGKJ = set.Tables[0].Rows[0]["PD_QUOTA_ZGKJ"].ToString();
            model.PD_QUOTA_XMZGBM = set.Tables[0].Rows[0]["PD_QUOTA_XMZGBM"].ToString();
            model.PD_QUOTA_ISUP = set.Tables[0].Rows[0]["PD_QUOTA_ISUP_NAME"].ToString();
            model.PD_QUOTA_ZBXDZH = set.Tables[0].Rows[0]["PD_QUOTA_ZBXDZH"].ToString();
            model.PD_QUOTA_ZGBM = set.Tables[0].Rows[0]["PD_QUOTA_ZGBM"].ToString();
            model.PD_QUOTA_PASS_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_PASS_COMPANY_NAME"].ToString();
            model.PD_QUOTA_PASS_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_PASS_DEPART_NAME"].ToString();
            model.PD_QUOTA_ACCEPT_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_ACCEPT_DEPART_NAME"].ToString();
            model.PD_QUOTA_UP_COMPANY = set.Tables[0].Rows[0]["PD_QUOTA_UP_COMPANY_NAME"].ToString();
            model.PD_QUOTA_UP_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_UP_DEPART_NAME"].ToString();
            model.PD_QUOTA_UP_DATE = set.Tables[0].Rows[0]["PD_QUOTA_UP_DATE"].ToString();
            model.PD_QUOTA_UP_MAN = set.Tables[0].Rows[0]["PD_QUOTA_UP_MAN"].ToString();
            model.PD_QUOTA_SERVERPK = set.Tables[0].Rows[0]["pd_quota_serverpk"].ToString();
            if (set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString() != "")
            {
                model.PD_IS_RETURN = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString() != "")
            {
                model.PD_ISOUT_QUOTA = new int?(int.Parse(set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString()));
            }
            model.PD_QUOTA_PICI = set.Tables[0].Rows[0]["PD_QUOTA_PICI"].ToString();
            model.PD_JY_MONEY = set.Tables[0].Rows[0]["PD_JY_MONEY"].ToString();
            model.PD_QUOTA_YSLX = set.Tables[0].Rows[0]["PD_QUOTA_YSLX"].ToString();
            model.Free1 = set.Tables[0].Rows[0]["Free1"].ToString();
            model.Free2 = set.Tables[0].Rows[0]["Free2"].ToString();
            model.Free3 = set.Tables[0].Rows[0]["Free3"].ToString();
            model.Free4 = set.Tables[0].Rows[0]["Free4"].ToString();
            model.Free5 = set.Tables[0].Rows[0]["Free5"].ToString();
            if (set.Tables[0].Rows[0]["Free6"].ToString() != "")
            {
                model.Free6 = int.Parse(set.Tables[0].Rows[0]["Free6"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free7"].ToString() != "")
            {
                model.Free7 = int.Parse(set.Tables[0].Rows[0]["Free7"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free8"].ToString() != "")
            {
                model.Free8 = decimal.Parse(set.Tables[0].Rows[0]["Free8"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free9"].ToString() != "")
            {
                model.Free9 = decimal.Parse(set.Tables[0].Rows[0]["Free9"].ToString());
            }
            if (set.Tables[0].Rows[0]["Free10"].ToString() != "")
            {
                model.Free10 = decimal.Parse(set.Tables[0].Rows[0]["Free10"].ToString());
            }
            return model;
        }

        public string getUpDownServerPKName(string path, string serverPK, int operation, out string NewServerPK)
        {
            UserModel model = new UserDal();
            DB_OPT dbo = new DB_OPT();
            model.GetUpDownStream(path, serverPK, operation, out NewServerPK, dbo);
            string sQLString = "select t.inpk from gov_tc_db_servicesmess t where trim(pk)=:pk";
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pk", OracleType.VarChar, 50) };
            cmdParms[0].Value = NewServerPK;
            DataSet set = DbHelperOra.Query(sQLString, cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return set.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }

        public int IsReceive(string pd_quota_code, string company_code)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from tb_quota_detail t where trim(pd_quota_code)=:pd_quota_code and trim(company_code)=:company_code and ISRECEIVE=1");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pd_quota_code", OracleType.VarChar, 50), new OracleParameter(":company_code", OracleType.VarChar, 50) };
            cmdParms[0].Value = pd_quota_code;
            cmdParms[1].Value = company_code;
            if (int.Parse(DbHelperOra.Query(builder.ToString(), cmdParms).Tables[0].Rows[0][0].ToString()) > 0)
            {
                return 1;
            }
            return 0;
        }

        public int IsXiaFaRight(string str, string serverPK)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select oper.serverpks from ");
            builder.Append("gov_tc_db_servicesmess ser ");
            builder.Append("left join gov_tc_view_sfproject sf on sf.PK=ser.taxfeecallectionpk ");
            builder.Append("left join gov_tc_db_taxfeekind tax on tax.pk=sf.TAXFEEKINDPK ");
            builder.Append("left join gov_tc_db_operation oper on oper.operationpk=ser.operationpk ");
            builder.Append("where trim(tax.pkpath)=:str and trim(ser.pk)=:serverPK");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":str", OracleType.VarChar, 50), new OracleParameter(":serverPK", OracleType.VarChar, 50) };
            cmdParms[0].Value = str;
            cmdParms[1].Value = serverPK;
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                string sQLString = "select ser.pk from  gov_tc_db_servicesmess ser left join gov_tc_view_sfproject sf on sf.PK=ser.taxfeecallectionpk left join gov_tc_db_taxfeekind tax on tax.pk=sf.TAXFEEKINDPK where trim(tax.pkpath)=:str and trim(tax.discription)='ibtcontrol_ibtaudit'";
                OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter(":str", OracleType.VarChar, 50) };
                parameterArray2[0].Value = str;
                DataSet set2 = DbHelperOra.Query(sQLString, parameterArray2);
                if (set2.Tables[0].Rows.Count > 0)
                {
                    string str3 = set.Tables[0].Rows[0][0].ToString();
                    if ((str3 != null) && (str3.Trim() != ""))
                    {
                        str3 = "|" + str3 + "|";
                    }
                    int index = str3.IndexOf(serverPK);
                    int num2 = -1;
                    foreach (DataRow row in set2.Tables[0].Rows)
                    {
                        num2 = str3.IndexOf(row[0].ToString());
                        if (num2 != -1)
                        {
                            break;
                        }
                    }
                    if ((index != -1) && (num2 != -1))
                    {
                        if (index > num2)
                        {
                            return 1;
                        }
                        return 0;
                    }
                }
            }
            return -1;
        }

        internal bool pd_IsZBWH(string PD_QUOTA_ZBWH, string PD_QUOTA_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from tb_quota where trim(PD_QUOTA_ZBWH)=:PD_QUOTA_ZBWH ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_ZBWH", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_QUOTA_ZBWH.Trim();
            if (DbHelperOra.Exists(builder.ToString(), cmdParms))
            {
                builder = new StringBuilder();
                builder.Append("select count(*) from tb_quota where trim(PD_QUOTA_ZBWH)=:PD_QUOTA_ZBWH and trim(PD_QUOTA_CODE)=:PD_QUOTA_CODE ");
                OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter(":PD_QUOTA_ZBWH", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_CODE", OracleType.VarChar, 50) };
                parameterArray2[0].Value = PD_QUOTA_ZBWH.Trim();
                parameterArray2[1].Value = PD_QUOTA_CODE.Trim();
                return !DbHelperOra.Exists(builder.ToString(), parameterArray2);
            }
            return false;
        }

        internal int SaveSetting(string url, string varID, string type)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from DB_SETTING where trim(url)=:MUrl and trim(VARIABLEID)=:varID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":MUrl", OracleType.VarChar, 50), new OracleParameter(":varID", OracleType.VarChar, 50) };
            cmdParms[0].Value = url.Trim();
            cmdParms[1].Value = varID.Trim();
            StringBuilder builder2 = new StringBuilder();
            if (DbHelperOra.Exists(builder.ToString(), cmdParms))
            {
                builder2.Append("update DB_SETTING set type=:type where  trim(url)=:MUrl and trim(VARIABLEID)=:varID ");
                OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter(":MUrl", OracleType.VarChar, 50), new OracleParameter(":varID", OracleType.VarChar, 50), new OracleParameter(":type", OracleType.VarChar, 5) };
                parameterArray2[0].Value = url.Trim();
                parameterArray2[1].Value = varID.Trim();
                parameterArray2[2].Value = type.Trim();
                return DbHelperOra.ExecuteSql(builder2.ToString(), parameterArray2);
            }
            builder2.Append("insert into DB_SETTING(id,url,VARIABLEID,type) values((select max(id)+1 from DB_SETTING),:MUrl,:varID,:type)");
            OracleParameter[] parameterArray3 = new OracleParameter[] { new OracleParameter(":MUrl", OracleType.VarChar, 50), new OracleParameter(":varID", OracleType.VarChar, 50), new OracleParameter(":type", OracleType.VarChar, 5) };
            parameterArray3[0].Value = url.Trim();
            parameterArray3[1].Value = varID.Trim();
            parameterArray3[2].Value = type.Trim();
            return DbHelperOra.ExecuteSql(builder2.ToString(), parameterArray3);
        }

        internal object tFileIsShow(string url, string varID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select type from DB_SETTING where trim(url)=:MUrl and trim(VARIABLEID)=:varID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":MUrl", OracleType.VarChar, 50), new OracleParameter(":varID", OracleType.VarChar, 50) };
            cmdParms[0].Value = url.Trim();
            cmdParms[1].Value = varID.Trim();
            return DbHelperOra.GetSingle(builder.ToString(), cmdParms);
        }

        public bool Update(TB_QUOTA_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_QUOTA set ");
            builder.Append("PD_QUOTA_NAME=:PD_QUOTA_NAME,");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("PD_QUOTA_LWJG=:PD_QUOTA_LWJG,");
            builder.Append("PD_QUOTA_IFUP=:PD_QUOTA_IFUP,");
            builder.Append("PD_QUOTA_ZJXZ=:PD_QUOTA_ZJXZ,");
            builder.Append("PD_QUOTA_TARGET=:PD_QUOTA_TARGET,");
            builder.Append("PD_QUOTA_STANDARD=:PD_QUOTA_STANDARD,");
            builder.Append("PD_QUOTA_BASIS=:PD_QUOTA_BASIS,");
            builder.Append("PD_QUOTA_BASIS_JG=:PD_QUOTA_BASIS_JG,");
            builder.Append("PD_QUOTA_INPUT_MAN=:PD_QUOTA_INPUT_MAN,");
            builder.Append("PD_QUOTA_FILE=:PD_QUOTA_FILE,");
            builder.Append("PD_QUOTA_XZ_ACCEPT_COMPANY=:PD_QUOTA_XZ_ACCEPT_COMPANY,");
            builder.Append("PD_QUOTA_XZ_ACCEPT_DATE=:PD_QUOTA_XZ_ACCEPT_DATE,");
            builder.Append("PD_QUOTA_MONEY_TOTAL=:PD_QUOTA_MONEY_TOTAL,");
            builder.Append("PD_QUOTA_DEPART=:PD_QUOTA_DEPART,");
            builder.Append("PD_QUOTA_JGYQ=:PD_QUOTA_JGYQ,");
            builder.Append("PD_QUOTA_INPUT_DATE=:PD_QUOTA_INPUT_DATE,");
            builder.Append("PD_QUOTA_INPUT_COMPANY=:PD_QUOTA_INPUT_COMPANY,");
            builder.Append("PD_QUOTA_XZ_ACCEPT_MAN=:PD_QUOTA_XZ_ACCEPT_MAN,");
            builder.Append("PD_PROJ_STATUS=:PD_PROJ_STATUS,");
            builder.Append("PD_PROJ_LAST_AUDIT_STATUS=:PD_PROJ_LAST_AUDIT_STATUS,");
            builder.Append("PD_IS_RETURN=:PD_IS_RETURN,");
            builder.Append("PD_ISOUT_QUOTA=:PD_ISOUT_QUOTA,");
            builder.Append("PD_QUOTA_ZBWH=:PD_QUOTA_ZBWH,");
            builder.Append("PD_QUOTA_FWDATA=:PD_QUOTA_FWDATA,");
            builder.Append("PD_QUOTA_COMPANY=:PD_QUOTA_COMPANY,");
            builder.Append("PD_QUOTA_ZBYT=:PD_QUOTA_ZBYT,");
            builder.Append("PD_QUOTA_QCDW=:PD_QUOTA_QCDW,");
            builder.Append("PD_QUOTA_QCBM=:PD_QUOTA_QCBM,");
            builder.Append("PD_QUOTA_GLLX=:PD_QUOTA_GLLX,");
            builder.Append("PD_QUOTA_JJLX=:PD_QUOTA_JJLX, ");
            builder.Append("PD_QUOTA_ZJLY=:PD_QUOTA_ZJLY, ");
            builder.Append("PD_QUOTA_ZGKJ=:PD_QUOTA_ZGKJ, ");
            builder.Append("PD_QUOTA_XMZGBM=:PD_QUOTA_XMZGBM, ");
            builder.Append("PD_QUOTA_ZBXDZH=:PD_QUOTA_ZBXDZH,");
            builder.Append("PD_QUOTA_ZGBM=:PD_QUOTA_ZGBM,");
            builder.Append("PD_QUOTA_PICI=:PD_QUOTA_PICI,");
            builder.Append("PD_QUOTA_YSLX=:PD_QUOTA_YSLX,");
            builder.Append("Free1=:Free1,");
            builder.Append("Free2=:Free2,");
            builder.Append("Free3=:Free3,");
            builder.Append("Free4=:Free4,");
            builder.Append("Free5=:Free5,");
            builder.Append("Free6=:Free6,");
            builder.Append("Free7=:Free7,");
            builder.Append("Free8=:Free8,");
            builder.Append("Free9=:Free9,");
            builder.Append("Free10=:Free10");
            builder.Append(" where PD_QUOTA_CODE=:PD_QUOTA_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_QUOTA_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_LWJG", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_IFUP", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_ZJXZ", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_TARGET", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_STANDARD", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_BASIS", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_BASIS_JG", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_INPUT_MAN", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_FILE", OracleType.VarChar, 300), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_COMPANY", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_DATE", OracleType.DateTime), new OracleParameter(":PD_QUOTA_MONEY_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_DEPART", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_JGYQ", OracleType.VarChar, 0x7d0), 
                new OracleParameter(":PD_QUOTA_INPUT_DATE", OracleType.DateTime), new OracleParameter(":PD_QUOTA_INPUT_COMPANY", OracleType.Char, 10), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_MAN", OracleType.VarChar, 30), new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":PD_ISOUT_QUOTA", OracleType.Number, 4), new OracleParameter(":PD_QUOTA_CODE", OracleType.NVarChar, 30), new OracleParameter(":PD_QUOTA_ZBWH", OracleType.VarChar, 30), new OracleParameter(":PD_QUOTA_FWDATA", OracleType.DateTime), new OracleParameter(":PD_QUOTA_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_QUOTA_ZBYT", OracleType.VarChar, 100), new OracleParameter(":PD_QUOTA_QCDW", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_QCBM", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_GLLX", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_JJLX", OracleType.VarChar, 50), 
                new OracleParameter(":PD_QUOTA_ZJLY", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_ZGKJ", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_XMZGBM", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_XMZGBM", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_ZBXDZH", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_ZGBM", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_PICI", OracleType.VarChar, 4), new OracleParameter(":PD_QUOTA_YSLX", OracleType.VarChar, 100), new OracleParameter(":Free1", OracleType.VarChar, 100), new OracleParameter(":Free2", OracleType.VarChar, 100), new OracleParameter(":Free3", OracleType.VarChar, 100), new OracleParameter(":Free4", OracleType.VarChar, 100), new OracleParameter(":Free5", OracleType.VarChar, 100), new OracleParameter(":Free6", OracleType.Int32, 4), new OracleParameter(":Free7", OracleType.Int32, 4), new OracleParameter(":Free8", OracleType.Number), 
                new OracleParameter(":Free9", OracleType.Number), new OracleParameter(":Free10", OracleType.Number)
             };
            cmdParms[0].Value = model.PD_QUOTA_NAME;
            cmdParms[1].Value = model.PD_YEAR;
            cmdParms[2].Value = model.PD_QUOTA_LWJG;
            cmdParms[3].Value = model.PD_QUOTA_IFUP;
            cmdParms[4].Value = model.PD_QUOTA_ZJXZ;
            cmdParms[5].Value = model.PD_QUOTA_TARGET;
            cmdParms[6].Value = model.PD_QUOTA_STANDARD;
            cmdParms[7].Value = model.PD_QUOTA_BASIS;
            cmdParms[8].Value = model.PD_QUOTA_BASIS_JG;
            cmdParms[9].Value = model.PD_QUOTA_INPUT_MAN;
            cmdParms[10].Value = model.PD_QUOTA_FILE;
            cmdParms[11].Value = model.PD_QUOTA_XZ_ACCEPT_COMPANY;
            cmdParms[12].Value = model.PD_QUOTA_XZ_ACCEPT_DATE;
            cmdParms[13].Value = model.PD_QUOTA_MONEY_TOTAL;
            cmdParms[14].Value = model.PD_QUOTA_DEPART;
            cmdParms[15].Value = model.PD_QUOTA_JGYQ;
            cmdParms[0x10].Value = model.PD_QUOTA_INPUT_DATE;
            cmdParms[0x11].Value = model.PD_QUOTA_INPUT_COMPANY;
            cmdParms[0x12].Value = model.PD_QUOTA_XZ_ACCEPT_MAN;
            cmdParms[0x13].Value = model.PD_PROJ_STATUS;
            cmdParms[20].Value = model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[0x15].Value = model.PD_IS_RETURN;
            cmdParms[0x16].Value = model.PD_ISOUT_QUOTA;
            cmdParms[0x17].Value = model.PD_QUOTA_CODE;
            cmdParms[0x18].Value = model.PD_QUOTA_ZBWH;
            cmdParms[0x19].Value = model.PD_QUOTA_FWDATA;
            cmdParms[0x1a].Value = model.PD_QUOTA_COMPANY;
            cmdParms[0x1b].Value = model.PD_QUOTA_ZBYT;
            cmdParms[0x1c].Value = model.PD_QUOTA_QCDW;
            cmdParms[0x1d].Value = model.PD_QUOTA_QCBM;
            cmdParms[30].Value = model.PD_QUOTA_GLLX;
            cmdParms[0x1f].Value = model.PD_QUOTA_JJLX;
            cmdParms[0x20].Value = model.PD_QUOTA_ZJLY;
            cmdParms[0x21].Value = model.PD_QUOTA_ZGKJ;
            cmdParms[0x22].Value = model.PD_QUOTA_XMZGBM;
            cmdParms[0x23].Value = model.PD_QUOTA_CODE;
            cmdParms[0x24].Value = model.PD_QUOTA_ZBXDZH;
            cmdParms[0x25].Value = model.PD_QUOTA_ZGBM;
            cmdParms[0x26].Value = model.PD_QUOTA_PICI;
            cmdParms[0x27].Value = model.PD_QUOTA_YSLX;
            cmdParms[40].Value = model.Free1;
            cmdParms[0x29].Value = model.Free2;
            cmdParms[0x2a].Value = model.Free3;
            cmdParms[0x2b].Value = model.Free4;
            cmdParms[0x2c].Value = model.Free5;
            cmdParms[0x2d].Value = model.Free6;
            cmdParms[0x2e].Value = model.Free7;
            cmdParms[0x2f].Value = model.Free8;
            cmdParms[0x30].Value = model.Free9;
            cmdParms[0x31].Value = model.Free10;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public int UpdateIsXiaFa(string pd_quota_code, string IsXiaFa, string IsQianShou, string IsHuiZhi)
        {
            StringBuilder builder = new StringBuilder();
            if ((IsQianShou == "1") && (IsHuiZhi == "1"))
            {
                OracleParameter[] parameterArray = new OracleParameter[] { new OracleParameter(":PD_QUOTA_ISUP", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZQS", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZHZ", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_HZ_DATE", OracleType.DateTime), new OracleParameter(":pd_quota_code", OracleType.VarChar, 50) };
                parameterArray[0].Value = IsXiaFa;
                parameterArray[1].Value = IsQianShou;
                parameterArray[2].Value = IsHuiZhi;
                parameterArray[3].Value = DateTime.Now;
                parameterArray[4].Value = pd_quota_code;
                builder.Append("update tb_quota set PD_QUOTA_ISUP=:PD_QUOTA_ISUP,PD_QUOTA_IFXZQS=:PD_QUOTA_IFXZQS,PD_QUOTA_IFXZHZ=:PD_QUOTA_IFXZHZ,PD_QUOTA_HZ_DATE=:PD_QUOTA_HZ_DATE where trim(pd_quota_code)=:pd_quota_code");
                return DbHelperOra.ExecuteSql(builder.ToString(), parameterArray);
            }
            if ((IsQianShou == "1") && (IsHuiZhi == "0"))
            {
                OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter(":PD_QUOTA_ISUP", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZQS", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZHZ", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_DATE", OracleType.DateTime), new OracleParameter(":pd_quota_code", OracleType.VarChar, 50) };
                parameterArray2[0].Value = IsXiaFa;
                parameterArray2[1].Value = IsQianShou;
                parameterArray2[2].Value = IsHuiZhi;
                parameterArray2[3].Value = DateTime.Now;
                parameterArray2[4].Value = pd_quota_code;
                builder.Append("update tb_quota set PD_QUOTA_ISUP=:PD_QUOTA_ISUP,PD_QUOTA_IFXZQS=:PD_QUOTA_IFXZQS,PD_QUOTA_IFXZHZ=:PD_QUOTA_IFXZHZ,PD_QUOTA_XZ_ACCEPT_DATE=:PD_QUOTA_XZ_ACCEPT_DATE where trim(pd_quota_code)=:pd_quota_code");
                return DbHelperOra.ExecuteSql(builder.ToString(), parameterArray2);
            }
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_QUOTA_ISUP", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZQS", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_IFXZHZ", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_XZ_ACCEPT_DATE", OracleType.DateTime), new OracleParameter(":PD_QUOTA_HZ_DATE", OracleType.DateTime), new OracleParameter(":pd_quota_code", OracleType.VarChar, 50) };
            cmdParms[0].Value = IsXiaFa;
            cmdParms[1].Value = IsQianShou;
            cmdParms[2].Value = IsHuiZhi;
            cmdParms[3].Value = DateTime.Now;
            cmdParms[4].Value = DateTime.Now;
            cmdParms[5].Value = pd_quota_code;
            builder.Append("update tb_quota set PD_QUOTA_ISUP=:PD_QUOTA_ISUP,PD_QUOTA_IFXZQS=:PD_QUOTA_IFXZQS,PD_QUOTA_IFXZHZ=:PD_QUOTA_IFXZHZ,PD_QUOTA_XZ_ACCEPT_DATE=:PD_QUOTA_XZ_ACCEPT_DATE,PD_QUOTA_HZ_DATE=:PD_QUOTA_HZ_DATE where trim(pd_quota_code)=:pd_quota_code");
            return DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }
    }
}

