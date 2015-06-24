namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class TB_PROJECT_Dal
    {
        public void Add(TB_PROJECT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into TB_PROJECT(");
            builder.Append("PD_PROJECT_CODE,PD_PROJECT_FILENO_ZB,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_PROJECT_TYPE_NAME,PD_GK_DEPART_ID,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_MONEY_TOTAL,PD_PROJECT_MONEY_CZ_TOTAL,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_MONEY_CZ_BJ,PD_PROJECT_MONEY_ZC,PD_PROJECT_MONEY_QT,PD_PROJECT_MONEY_ADDR,PD_PROJECT_CONTENT,PD_PROJECT_XMYT,PD_PROJECT_IFXZGL,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_FZR,PD_PROJECT_CWFZR,PD_PROJECT_STATUS,PD_PROJECT_BEGIN_DATE,PD_PROJECT_END_DATE,PD_PROJECT_YEARS,PD_PROJECT_CHECK_DATE,PD_PROJECT_FILENO_LX,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_REPLY_COMPANY,PD_PROJECT_REPLY_MAN2,PD_PROJECT_CHECK_COMPANY,PD_PROJECT_CHENCK_MAN,PD_PROJECT_MONEY_TOTAL_PF,PD_PROJECT_REPLY_DATE,PD_PROJECT_MONEY_CZ_TOTAL_PF,PD_PROJECT_MONEY_CZ_SJ_PF,PD_PROJECT_MONEY_CZ_BJ_PF,PD_PROJECT_MONEY_ZC_PF,PD_PROJECT_MONEY_QT_PF,PD_PROJECT_COUNTRY,PD_PROJECT_VILLAGE,PD_PROJECT_GROUP,PD_PROJECT_FILENO_PF,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_SYRS,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT,PD_PROJECT_JG_SUGGEST,PD_PROJECT_SYHS,PD_PROJECT_GNFL,PD_PROJECT_GNFL_CODE,PD_PROJECT_ZJLY,PD_PROJECT_ZGKJ,PD_PROJECT_ISBXK          ,PD_PROJECT_CJDW,PD_PROJECT_JBDH,PD_PROJECT_SSFW,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10)");
            builder.Append(" values (");
            builder.Append(":PD_PROJECT_CODE,:PD_PROJECT_FILENO_ZB,:PD_PROJECT_NAME,:PD_YEAR,:PD_PROJECT_TYPE,:PD_PROJECT_TYPE_NAME,:PD_GK_DEPART_ID,:PD_GK_DEPART,:PD_FOUND_XZ,:PD_PROJECT_MONEY_TOTAL,:PD_PROJECT_MONEY_CZ_TOTAL,:PD_PROJECT_MONEY_CZ_SJ,:PD_PROJECT_MONEY_CZ_BJ,:PD_PROJECT_MONEY_ZC,:PD_PROJECT_MONEY_QT,:PD_PROJECT_MONEY_ADDR,:PD_PROJECT_CONTENT,:PD_PROJECT_XMYT,:PD_PROJECT_IFXZGL,:PD_PROJECT_IFGS,:PD_PROJECT_IFGS_BEFORE,:PD_PROJECT_OPEN_BODY,:PD_PROJECT_FZR,:PD_PROJECT_CWFZR,:PD_PROJECT_STATUS,:PD_PROJECT_BEGIN_DATE,:PD_PROJECT_END_DATE,:PD_PROJECT_YEARS,:PD_PROJECT_CHECK_DATE,:PD_PROJECT_FILENO_LX,:PD_PROJECT_FILENO_JG,:PD_PROJECT_INPUT_COMPANY,:PD_PROJECT_INPUT_MAN,:PD_PROJECT_INPUT_DATE,:PD_PROJECT_REPLY_COMPANY,:PD_PROJECT_REPLY_MAN2,:PD_PROJECT_CHECK_COMPANY,:PD_PROJECT_CHENCK_MAN,:PD_PROJECT_MONEY_TOTAL_PF,:PD_PROJECT_REPLY_DATE,:PD_PROJECT_MONEY_CZ_TOTAL_PF,:PD_PROJECT_MONEY_CZ_SJ_PF,:PD_PROJECT_MONEY_CZ_BJ_PF,:PD_PROJECT_MONEY_ZC_PF,:PD_PROJECT_MONEY_QT_PF,:PD_PROJECT_COUNTRY,:PD_PROJECT_VILLAGE,:PD_PROJECT_GROUP,:PD_PROJECT_FILENO_PF,:PD_PROJ_STATUS,:PD_PROJ_LAST_AUDIT_STATUS,:PD_IS_RETURN,:PD_ISOUT_QUOTA,:PD_PROJECT_BZYJ,:PD_PROJECT_BZFW,:PD_PROJECT_BZDX,:PD_PROJECT_BZNUM,:PD_PROJECT_BZSTAND_NUM,:PD_PROJECT_BZMONEY,:PD_PROJECT_SYRS,:PD_PROJECT_BZFF_DATE,:PD_PROJECT_SJFF_DATE,:PD_PROJECT_IFFF,:PD_PROJECT_JGYQ,:PD_PROJECT_JGJL,:PD_PROJECT_JG_RESULT,:PD_PROJECT_JG_SUGGEST,:PD_PROJECT_SYHS,:PD_PROJECT_GNFL,:PD_PROJECT_GNFL_CODE,:PD_PROJECT_ZJLY,:PD_PROJECT_ZGKJ,:PD_PROJECT_ISBXK           ,:PD_PROJECT_CJDW,:PD_PROJECT_JBDH,:PD_PROJECT_SSFW,:Free1,:Free2,:Free3,:Free4,:Free5,:Free6,:Free7,:Free8,:Free9,:Free10)");
            builder.Append(" RETURNING PD_PROJECT_CODE INTO :R_Auto_No ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_FILENO_ZB", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_TYPE_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_GK_DEPART_ID", OracleType.VarChar, 100), new OracleParameter(":PD_GK_DEPART", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_XZ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_BJ", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ZC", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_QT", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ADDR", OracleType.VarChar, 0xfa0), 
                new OracleParameter(":PD_PROJECT_CONTENT", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_XMYT", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_IFXZGL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS_BEFORE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_OPEN_BODY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_FZR", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CWFZR", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_STATUS", OracleType.VarChar, 20), new OracleParameter(":PD_PROJECT_BEGIN_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_END_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YEARS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CHECK_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_FILENO_LX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_FILENO_JG", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_COMPANY", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_INPUT_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_REPLY_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_REPLY_MAN2", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CHECK_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CHENCK_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_TOTAL_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_REPLY_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_CZ_TOTAL_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_CZ_BJ_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_ZC_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_QT_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_COUNTRY", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_VILLAGE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_GROUP", OracleType.VarChar, 50), 
                new OracleParameter(":PD_PROJECT_FILENO_PF", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":PD_ISOUT_QUOTA", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZYJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZFW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZDX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZNUM", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZSTAND_NUM", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZMONEY", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_SYRS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_SJFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_IFFF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_JGYQ", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_JGJL", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JG_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JG_SUGGEST", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SYHS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_GNFL", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_GNFL_CODE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ZJLY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ZGKJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ISBXK", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CJDW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JBDH", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SSFW", OracleType.VarChar, 100), new OracleParameter(":Free1", OracleType.VarChar, 100), new OracleParameter(":Free2", OracleType.VarChar, 100), new OracleParameter(":Free3", OracleType.VarChar, 100), new OracleParameter(":Free4", OracleType.VarChar, 100), 
                new OracleParameter(":Free5", OracleType.VarChar, 100), new OracleParameter(":Free6", OracleType.Int32, 4), new OracleParameter(":Free7", OracleType.Int32, 4), new OracleParameter(":Free8", OracleType.Number), new OracleParameter(":Free9", OracleType.Number), new OracleParameter(":Free10", OracleType.Number), new OracleParameter(":R_Auto_No", OracleType.Number, 20)
             };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_FILENO_ZB;
            cmdParms[2].Value = model.PD_PROJECT_NAME;
            cmdParms[3].Value = model.PD_YEAR;
            cmdParms[4].Value = model.PD_PROJECT_TYPE;
            cmdParms[5].Value = model.PD_PROJECT_TYPE_NAME;
            cmdParms[6].Value = model.PD_GK_DEPART_ID;
            cmdParms[7].Value = model.PD_GK_DEPART;
            cmdParms[8].Value = model.PD_FOUND_XZ;
            cmdParms[9].Value = model.PD_PROJECT_MONEY_TOTAL;
            cmdParms[10].Value = model.PD_PROJECT_MONEY_CZ_TOTAL;
            cmdParms[11].Value = model.PD_PROJECT_MONEY_CZ_SJ;
            cmdParms[12].Value = model.PD_PROJECT_MONEY_CZ_BJ;
            cmdParms[13].Value = model.PD_PROJECT_MONEY_ZC;
            cmdParms[14].Value = model.PD_PROJECT_MONEY_QT;
            cmdParms[15].Value = model.PD_PROJECT_MONEY_ADDR;
            cmdParms[0x10].Value = model.PD_PROJECT_CONTENT;
            cmdParms[0x11].Value = model.PD_PROJECT_XMYT;
            cmdParms[0x12].Value = model.PD_PROJECT_IFXZGL;
            cmdParms[0x13].Value = model.PD_PROJECT_IFGS;
            cmdParms[20].Value = model.PD_PROJECT_IFGS_BEFORE;
            cmdParms[0x15].Value = model.PD_PROJECT_OPEN_BODY;
            cmdParms[0x16].Value = model.PD_PROJECT_FZR;
            cmdParms[0x17].Value = model.PD_PROJECT_CWFZR;
            cmdParms[0x18].Value = model.PD_PROJECT_STATUS;
            cmdParms[0x19].Value = model.PD_PROJECT_BEGIN_DATE;
            cmdParms[0x1a].Value = model.PD_PROJECT_END_DATE;
            cmdParms[0x1b].Value = model.PD_PROJECT_YEARS;
            cmdParms[0x1c].Value = model.PD_PROJECT_CHECK_DATE;
            cmdParms[0x1d].Value = model.PD_PROJECT_FILENO_LX;
            cmdParms[30].Value = model.PD_PROJECT_FILENO_JG;
            cmdParms[0x1f].Value = model.PD_PROJECT_INPUT_COMPANY;
            cmdParms[0x20].Value = model.PD_PROJECT_INPUT_MAN;
            cmdParms[0x21].Value = model.PD_PROJECT_INPUT_DATE;
            cmdParms[0x22].Value = model.PD_PROJECT_REPLY_COMPANY;
            cmdParms[0x23].Value = model.PD_PROJECT_REPLY_MAN2;
            cmdParms[0x24].Value = model.PD_PROJECT_CHECK_COMPANY;
            cmdParms[0x25].Value = model.PD_PROJECT_CHENCK_MAN;
            cmdParms[0x26].Value = model.PD_PROJECT_MONEY_TOTAL_PF;
            cmdParms[0x27].Value = model.PD_PROJECT_REPLY_DATE;
            cmdParms[40].Value = model.PD_PROJECT_MONEY_CZ_TOTAL_PF;
            cmdParms[0x29].Value = model.PD_PROJECT_MONEY_CZ_SJ_PF;
            cmdParms[0x2a].Value = model.PD_PROJECT_MONEY_CZ_BJ_PF;
            cmdParms[0x2b].Value = model.PD_PROJECT_MONEY_ZC_PF;
            cmdParms[0x2c].Value = model.PD_PROJECT_MONEY_QT_PF;
            cmdParms[0x2d].Value = model.PD_PROJECT_COUNTRY;
            cmdParms[0x2e].Value = model.PD_PROJECT_VILLAGE;
            cmdParms[0x2f].Value = model.PD_PROJECT_GROUP;
            cmdParms[0x30].Value = model.PD_PROJECT_FILENO_PF;
            cmdParms[0x31].Value = model.PD_PROJ_STATUS;
            cmdParms[50].Value = model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[0x33].Value = model.PD_IS_RETURN;
            cmdParms[0x34].Value = model.PD_ISOUT_QUOTA;
            cmdParms[0x35].Value = model.PD_PROJECT_BZYJ;
            cmdParms[0x36].Value = model.PD_PROJECT_BZFW;
            cmdParms[0x37].Value = model.PD_PROJECT_BZDX;
            cmdParms[0x38].Value = model.PD_PROJECT_BZNUM;
            cmdParms[0x39].Value = model.PD_PROJECT_BZSTAND_NUM;
            cmdParms[0x3a].Value = model.PD_PROJECT_BZMONEY;
            cmdParms[0x3b].Value = model.PD_PROJECT_SYRS;
            cmdParms[60].Value = model.PD_PROJECT_BZFF_DATE;
            cmdParms[0x3d].Value = model.PD_PROJECT_SJFF_DATE;
            cmdParms[0x3e].Value = model.PD_PROJECT_IFFF;
            cmdParms[0x3f].Value = model.PD_PROJECT_JGYQ;
            cmdParms[0x40].Value = model.PD_PROJECT_JGJL;
            cmdParms[0x41].Value = model.PD_PROJECT_JG_RESULT;
            cmdParms[0x42].Value = model.PD_PROJECT_JG_SUGGEST;
            cmdParms[0x43].Value = model.PD_PROJECT_SYHS;
            cmdParms[0x44].Value = model.PD_PROJECT_GNFL;
            cmdParms[0x45].Value = model.PD_PROJECT_GNFL_CODE;
            cmdParms[70].Value = model.PD_PROJECT_ZJLY;
            cmdParms[0x47].Value = model.PD_PROJECT_ZGKJ;
            cmdParms[0x48].Value = model.PD_PROJECT_ISBXK;
            cmdParms[0x49].Value = model.PD_PROJECT_CJDW;
            cmdParms[0x4a].Value = model.PD_PROJECT_JBDH;
            cmdParms[0x4b].Value = model.PD_PROJECT_SSFW;
            cmdParms[0x4c].Value = model.Free1;
            cmdParms[0x4d].Value = model.Free2;
            cmdParms[0x4e].Value = model.Free3;
            cmdParms[0x4f].Value = model.Free4;
            cmdParms[80].Value = model.Free5;
            cmdParms[0x51].Value = model.Free6;
            cmdParms[0x52].Value = model.Free7;
            cmdParms[0x53].Value = model.Free8;
            cmdParms[0x54].Value = model.Free9;
            cmdParms[0x55].Value = model.Free10;
            cmdParms[0x56].Direction = ParameterDirection.Output;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
            model.PD_PROJECT_CODE = cmdParms[0x56].Value.ToString();
        }

        public void Add(TB_PROJECT_Model model, ref string PD_PROJECT_CODE)
        {
            PD_PROJECT_CODE = model.PD_PROJECT_CODE;
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into TB_PROJECT(");
            builder.Append("PD_PROJECT_CODE,PD_PROJECT_FILENO_ZB,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_PROJECT_TYPE_NAME,PD_GK_DEPART_ID,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_MONEY_TOTAL,PD_PROJECT_MONEY_CZ_TOTAL,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_MONEY_CZ_BJ,PD_PROJECT_MONEY_ZC,PD_PROJECT_MONEY_QT,PD_PROJECT_MONEY_ADDR,PD_PROJECT_CONTENT,PD_PROJECT_XMYT,PD_PROJECT_IFXZGL,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_FZR,PD_PROJECT_CWFZR,PD_PROJECT_STATUS,PD_PROJECT_BEGIN_DATE,PD_PROJECT_END_DATE,PD_PROJECT_YEARS,PD_PROJECT_CHECK_DATE,PD_PROJECT_FILENO_LX,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_REPLY_COMPANY,PD_PROJECT_REPLY_MAN2,PD_PROJECT_CHECK_COMPANY,PD_PROJECT_CHENCK_MAN,PD_PROJECT_MONEY_TOTAL_PF,PD_PROJECT_REPLY_DATE,PD_PROJECT_MONEY_CZ_TOTAL_PF,PD_PROJECT_MONEY_CZ_SJ_PF,PD_PROJECT_MONEY_CZ_BJ_PF,PD_PROJECT_MONEY_ZC_PF,PD_PROJECT_MONEY_QT_PF,PD_PROJECT_COUNTRY,PD_PROJECT_VILLAGE,PD_PROJECT_GROUP,PD_PROJECT_FILENO_PF,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_SYRS,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT,PD_PROJECT_JG_SUGGEST,PD_PROJECT_SYHS,PD_PROJECT_GNFL,PD_PROJECT_GNFL_CODE,PD_PROJECT_ZJLY,PD_PROJECT_ZGKJ,PD_PROJECT_ISBXK          ,PD_PROJECT_CJDW,PD_PROJECT_JBDH,PD_PROJECT_SSFW,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10)");
            builder.Append(" values (");
            builder.Append(":PD_PROJECT_CODE,:PD_PROJECT_FILENO_ZB,:PD_PROJECT_NAME,:PD_YEAR,:PD_PROJECT_TYPE,:PD_PROJECT_TYPE_NAME,:PD_GK_DEPART_ID,:PD_GK_DEPART,:PD_FOUND_XZ,:PD_PROJECT_MONEY_TOTAL,:PD_PROJECT_MONEY_CZ_TOTAL,:PD_PROJECT_MONEY_CZ_SJ,:PD_PROJECT_MONEY_CZ_BJ,:PD_PROJECT_MONEY_ZC,:PD_PROJECT_MONEY_QT,:PD_PROJECT_MONEY_ADDR,:PD_PROJECT_CONTENT,:PD_PROJECT_XMYT,:PD_PROJECT_IFXZGL,:PD_PROJECT_IFGS,:PD_PROJECT_IFGS_BEFORE,:PD_PROJECT_OPEN_BODY,:PD_PROJECT_FZR,:PD_PROJECT_CWFZR,:PD_PROJECT_STATUS,:PD_PROJECT_BEGIN_DATE,:PD_PROJECT_END_DATE,:PD_PROJECT_YEARS,:PD_PROJECT_CHECK_DATE,:PD_PROJECT_FILENO_LX,:PD_PROJECT_FILENO_JG,:PD_PROJECT_INPUT_COMPANY,:PD_PROJECT_INPUT_MAN,:PD_PROJECT_INPUT_DATE,:PD_PROJECT_REPLY_COMPANY,:PD_PROJECT_REPLY_MAN2,:PD_PROJECT_CHECK_COMPANY,:PD_PROJECT_CHENCK_MAN,:PD_PROJECT_MONEY_TOTAL_PF,:PD_PROJECT_REPLY_DATE,:PD_PROJECT_MONEY_CZ_TOTAL_PF,:PD_PROJECT_MONEY_CZ_SJ_PF,:PD_PROJECT_MONEY_CZ_BJ_PF,:PD_PROJECT_MONEY_ZC_PF,:PD_PROJECT_MONEY_QT_PF,:PD_PROJECT_COUNTRY,:PD_PROJECT_VILLAGE,:PD_PROJECT_GROUP,:PD_PROJECT_FILENO_PF,:PD_PROJ_STATUS,:PD_PROJ_LAST_AUDIT_STATUS,:PD_IS_RETURN,:PD_ISOUT_QUOTA,:PD_PROJECT_BZYJ,:PD_PROJECT_BZFW,:PD_PROJECT_BZDX,:PD_PROJECT_BZNUM,:PD_PROJECT_BZSTAND_NUM,:PD_PROJECT_BZMONEY,:PD_PROJECT_SYRS,:PD_PROJECT_BZFF_DATE,:PD_PROJECT_SJFF_DATE,:PD_PROJECT_IFFF,:PD_PROJECT_JGYQ,:PD_PROJECT_JGJL,:PD_PROJECT_JG_RESULT,:PD_PROJECT_JG_SUGGEST,:PD_PROJECT_SYHS,:PD_PROJECT_GNFL,:PD_PROJECT_GNFL_CODE,:PD_PROJECT_ZJLY,:PD_PROJECT_ZGKJ,:PD_PROJECT_ISBXK           ,:PD_PROJECT_CJDW,:PD_PROJECT_JBDH,:PD_PROJECT_SSFW,:Free1,:Free2,:Free3,:Free4,:Free5,:Free6,:Free7,:Free8,:Free9,:Free10)");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_FILENO_ZB", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_TYPE_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_GK_DEPART_ID", OracleType.VarChar, 100), new OracleParameter(":PD_GK_DEPART", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_XZ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_BJ", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ZC", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_QT", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ADDR", OracleType.VarChar, 0xfa0), 
                new OracleParameter(":PD_PROJECT_CONTENT", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_XMYT", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_IFXZGL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS_BEFORE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_OPEN_BODY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_FZR", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CWFZR", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_STATUS", OracleType.VarChar, 20), new OracleParameter(":PD_PROJECT_BEGIN_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_END_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YEARS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CHECK_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_FILENO_LX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_FILENO_JG", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_COMPANY", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_INPUT_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_REPLY_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_REPLY_MAN2", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CHECK_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CHENCK_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_TOTAL_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_REPLY_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_CZ_TOTAL_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_CZ_BJ_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_ZC_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_MONEY_QT_PF", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_COUNTRY", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_VILLAGE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_GROUP", OracleType.VarChar, 50), 
                new OracleParameter(":PD_PROJECT_FILENO_PF", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":PD_ISOUT_QUOTA", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZYJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZFW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZDX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZNUM", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZSTAND_NUM", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZMONEY", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_SYRS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_SJFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_IFFF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_JGYQ", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_JGJL", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JG_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JG_SUGGEST", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SYHS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_GNFL", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_GNFL_CODE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ZJLY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ZGKJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ISBXK", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CJDW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JBDH", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SSFW", OracleType.VarChar, 100), new OracleParameter(":Free1", OracleType.VarChar, 100), new OracleParameter(":Free2", OracleType.VarChar, 100), new OracleParameter(":Free3", OracleType.VarChar, 100), new OracleParameter(":Free4", OracleType.VarChar, 100), 
                new OracleParameter(":Free5", OracleType.VarChar, 100), new OracleParameter(":Free6", OracleType.Int32, 4), new OracleParameter(":Free7", OracleType.Int32, 4), new OracleParameter(":Free8", OracleType.Number), new OracleParameter(":Free9", OracleType.Number), new OracleParameter(":Free10", OracleType.Number)
             };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.PD_PROJECT_FILENO_ZB;
            cmdParms[2].Value = model.PD_PROJECT_NAME;
            cmdParms[3].Value = model.PD_YEAR;
            cmdParms[4].Value = model.PD_PROJECT_TYPE;
            cmdParms[5].Value = model.PD_PROJECT_TYPE_NAME;
            cmdParms[6].Value = model.PD_GK_DEPART_ID;
            cmdParms[7].Value = model.PD_GK_DEPART;
            cmdParms[8].Value = model.PD_FOUND_XZ;
            cmdParms[9].Value = model.PD_PROJECT_MONEY_TOTAL;
            cmdParms[10].Value = model.PD_PROJECT_MONEY_CZ_TOTAL;
            cmdParms[11].Value = model.PD_PROJECT_MONEY_CZ_SJ;
            cmdParms[12].Value = model.PD_PROJECT_MONEY_CZ_BJ;
            cmdParms[13].Value = model.PD_PROJECT_MONEY_ZC;
            cmdParms[14].Value = model.PD_PROJECT_MONEY_QT;
            cmdParms[15].Value = model.PD_PROJECT_MONEY_ADDR;
            cmdParms[0x10].Value = model.PD_PROJECT_CONTENT;
            cmdParms[0x11].Value = model.PD_PROJECT_XMYT;
            cmdParms[0x12].Value = model.PD_PROJECT_IFXZGL;
            cmdParms[0x13].Value = model.PD_PROJECT_IFGS;
            cmdParms[20].Value = model.PD_PROJECT_IFGS_BEFORE;
            cmdParms[0x15].Value = model.PD_PROJECT_OPEN_BODY;
            cmdParms[0x16].Value = model.PD_PROJECT_FZR;
            cmdParms[0x17].Value = model.PD_PROJECT_CWFZR;
            cmdParms[0x18].Value = model.PD_PROJECT_STATUS;
            cmdParms[0x19].Value = model.PD_PROJECT_BEGIN_DATE;
            cmdParms[0x1a].Value = model.PD_PROJECT_END_DATE;
            cmdParms[0x1b].Value = model.PD_PROJECT_YEARS;
            cmdParms[0x1c].Value = model.PD_PROJECT_CHECK_DATE;
            cmdParms[0x1d].Value = model.PD_PROJECT_FILENO_LX;
            cmdParms[30].Value = model.PD_PROJECT_FILENO_JG;
            cmdParms[0x1f].Value = model.PD_PROJECT_INPUT_COMPANY;
            cmdParms[0x20].Value = model.PD_PROJECT_INPUT_MAN;
            cmdParms[0x21].Value = model.PD_PROJECT_INPUT_DATE;
            cmdParms[0x22].Value = model.PD_PROJECT_REPLY_COMPANY;
            cmdParms[0x23].Value = model.PD_PROJECT_REPLY_MAN2;
            cmdParms[0x24].Value = model.PD_PROJECT_CHECK_COMPANY;
            cmdParms[0x25].Value = model.PD_PROJECT_CHENCK_MAN;
            cmdParms[0x26].Value = model.PD_PROJECT_MONEY_TOTAL_PF;
            cmdParms[0x27].Value = model.PD_PROJECT_REPLY_DATE;
            cmdParms[40].Value = model.PD_PROJECT_MONEY_CZ_TOTAL_PF;
            cmdParms[0x29].Value = model.PD_PROJECT_MONEY_CZ_SJ_PF;
            cmdParms[0x2a].Value = model.PD_PROJECT_MONEY_CZ_BJ_PF;
            cmdParms[0x2b].Value = model.PD_PROJECT_MONEY_ZC_PF;
            cmdParms[0x2c].Value = model.PD_PROJECT_MONEY_QT_PF;
            cmdParms[0x2d].Value = model.PD_PROJECT_COUNTRY;
            cmdParms[0x2e].Value = model.PD_PROJECT_VILLAGE;
            cmdParms[0x2f].Value = model.PD_PROJECT_GROUP;
            cmdParms[0x30].Value = model.PD_PROJECT_FILENO_PF;
            cmdParms[0x31].Value = model.PD_PROJ_STATUS;
            cmdParms[50].Value = model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[0x33].Value = model.PD_IS_RETURN;
            cmdParms[0x34].Value = model.PD_ISOUT_QUOTA;
            cmdParms[0x35].Value = model.PD_PROJECT_BZYJ;
            cmdParms[0x36].Value = model.PD_PROJECT_BZFW;
            cmdParms[0x37].Value = model.PD_PROJECT_BZDX;
            cmdParms[0x38].Value = model.PD_PROJECT_BZNUM;
            cmdParms[0x39].Value = model.PD_PROJECT_BZSTAND_NUM;
            cmdParms[0x3a].Value = model.PD_PROJECT_BZMONEY;
            cmdParms[0x3b].Value = model.PD_PROJECT_SYRS;
            cmdParms[60].Value = model.PD_PROJECT_BZFF_DATE;
            cmdParms[0x3d].Value = model.PD_PROJECT_SJFF_DATE;
            cmdParms[0x3e].Value = model.PD_PROJECT_IFFF;
            cmdParms[0x3f].Value = model.PD_PROJECT_JGYQ;
            cmdParms[0x40].Value = model.PD_PROJECT_JGJL;
            cmdParms[0x41].Value = model.PD_PROJECT_JG_RESULT;
            cmdParms[0x42].Value = model.PD_PROJECT_JG_SUGGEST;
            cmdParms[0x43].Value = model.PD_PROJECT_SYHS;
            cmdParms[0x44].Value = model.PD_PROJECT_GNFL;
            cmdParms[0x45].Value = model.PD_PROJECT_GNFL_CODE;
            cmdParms[70].Value = model.PD_PROJECT_ZJLY;
            cmdParms[0x47].Value = model.PD_PROJECT_ZGKJ;
            cmdParms[0x48].Value = model.PD_PROJECT_ISBXK;
            cmdParms[0x49].Value = model.PD_PROJECT_CJDW;
            cmdParms[0x4a].Value = model.PD_PROJECT_JBDH;
            cmdParms[0x4b].Value = model.PD_PROJECT_SSFW;
            cmdParms[0x4c].Value = model.Free1;
            cmdParms[0x4d].Value = model.Free2;
            cmdParms[0x4e].Value = model.Free3;
            cmdParms[0x4f].Value = model.Free4;
            cmdParms[80].Value = model.Free5;
            cmdParms[0x51].Value = model.Free6;
            cmdParms[0x52].Value = model.Free7;
            cmdParms[0x53].Value = model.Free8;
            cmdParms[0x54].Value = model.Free9;
            cmdParms[0x55].Value = model.Free10;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_PROJECT ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from TB_PROJECT ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from TB_PROJECT");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PD_PROJECT_CODE,PD_PROJECT_FILENO_ZB,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_PROJECT_TYPE_NAME,PD_GK_DEPART_ID,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_MONEY_TOTAL,PD_PROJECT_MONEY_CZ_TOTAL,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_MONEY_CZ_BJ,PD_PROJECT_MONEY_ZC,PD_PROJECT_MONEY_QT,PD_PROJECT_MONEY_ADDR,PD_PROJECT_CONTENT,PD_PROJECT_XMYT,PD_PROJECT_IFXZGL,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_FZR,PD_PROJECT_CWFZR,PD_PROJECT_STATUS,PD_PROJECT_BEGIN_DATE,PD_PROJECT_END_DATE,PD_PROJECT_YEARS,PD_PROJECT_CHECK_DATE,PD_PROJECT_FILENO_LX,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_REPLY_COMPANY,PD_PROJECT_REPLY_MAN2,PD_PROJECT_CHECK_COMPANY,PD_PROJECT_CHENCK_MAN,PD_PROJECT_MONEY_TOTAL_PF,PD_PROJECT_REPLY_DATE,PD_PROJECT_MONEY_CZ_TOTAL_PF,PD_PROJECT_MONEY_CZ_SJ_PF,PD_PROJECT_MONEY_CZ_BJ_PF,PD_PROJECT_MONEY_ZC_PF,PD_PROJECT_MONEY_QT_PF,PD_PROJECT_COUNTRY,PD_PROJECT_VILLAGE,PD_PROJECT_GROUP,PD_PROJECT_FILENO_PF,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_SYRS,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT,PD_PROJECT_JG_SUGGEST,PD_PROJECT_SYHS,PD_PROJECT_GNFL,PD_PROJECT_GNFL_CODE,PD_PROJECT_ZJLY,PD_PROJECT_ZGKJ,PD_PROJECT_CJDW,PD_PROJECT_JBDH,PD_PROJECT_SSFW,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10 ");
            builder.Append(" FROM TB_PROJECT ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public TB_PROJECT_Model GetModel(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select maxtb.* ,z.zjly_name from( ");
            builder.Append("select tb.*,b.zgkj_name from ( ");
            builder.Append("select t.PD_PROJECT_FILENO_PF, PD_PROJECT_CODE,PD_PROJECT_FILENO_ZB,PD_PROJECT_NAME,PD_YEAR,PD_PROJECT_TYPE,PD_PROJECT_TYPE_NAME,PD_GK_DEPART_ID,PD_GK_DEPART,PD_FOUND_XZ,PD_PROJECT_MONEY_TOTAL,PD_PROJECT_MONEY_CZ_TOTAL,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_MONEY_CZ_BJ,PD_PROJECT_MONEY_ZC,PD_PROJECT_MONEY_QT,PD_PROJECT_MONEY_ADDR,PD_PROJECT_CONTENT,PD_PROJECT_XMYT,PD_PROJECT_IFXZGL,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_FZR,PD_PROJECT_CWFZR,PD_PROJECT_STATUS,PD_PROJECT_BEGIN_DATE,PD_PROJECT_END_DATE,PD_PROJECT_YEARS,PD_PROJECT_CHECK_DATE,PD_PROJECT_FILENO_LX,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_REPLY_COMPANY,PD_PROJECT_REPLY_MAN2,PD_PROJECT_CHECK_COMPANY,PD_PROJECT_CHENCK_MAN,PD_PROJECT_MONEY_TOTAL_PF,PD_PROJECT_REPLY_DATE,PD_PROJECT_MONEY_CZ_TOTAL_PF,PD_PROJECT_MONEY_CZ_SJ_PF,PD_PROJECT_MONEY_CZ_BJ_PF,PD_PROJECT_MONEY_ZC_PF,PD_PROJECT_MONEY_QT_PF,PD_PROJECT_COUNTRY,PD_PROJECT_VILLAGE,PD_PROJECT_GROUP,tbQuota.ShowText PD_QUOTA_ZBWH,PD_PROJECT_FILENO_PF PD_PROJECT_FILENO_PF_CODE,PD_PROJ_STATUS,PD_PROJ_LAST_AUDIT_STATUS,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_SYRS,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT,PD_PROJECT_JG_SUGGEST,PD_PROJECT_SYHS,PD_PROJECT_GNFL,PD_PROJECT_GNFL_CODE,db_users.truename,db_company.name companyName,PD_PROJECT_SERVERPK,PD_PROJECT_ZJLY,PD_PROJECT_ZGKJ ,PD_PROJECT_CJDW,PD_PROJECT_JBDH,PD_PROJECT_SSFW,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10 from TB_PROJECT t");
            builder.Append(" left join db_users on db_users.username=t.Pd_Project_Input_Man ");
            builder.Append(" left join db_company on trim(db_company.pk_corp)=trim(t.PD_PROJECT_INPUT_COMPANY) ");
            builder.Append(" left join projectUnionQuota tbQuota on trim(tbQuota.pd_quota_code)=trim(t.PD_PROJECT_FILENO_PF) ");
            builder.Append(") tb left join PD_PROJECT_ZGKJ b on tb.PD_PROJECT_ZGKJ=b.zgkj_code ");
            builder.Append("  ) maxtb  left join pd_base_zjly z on  maxtb.PD_PROJECT_ZJLY=z.zjly_code ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            TB_PROJECT_Model model = new TB_PROJECT_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_FILENO_ZB = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_ZB"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            model.zjly_name = set.Tables[0].Rows[0]["zjly_name"].ToString();
            model.zgkj_name = set.Tables[0].Rows[0]["zgkj_name"].ToString();
            if (set.Tables[0].Rows[0]["PD_YEAR"].ToString() != "")
            {
                model.PD_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_YEAR"].ToString()));
            }
            model.PD_PROJECT_TYPE = set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString();
            model.PD_PROJECT_TYPE_NAME = set.Tables[0].Rows[0]["PD_PROJECT_TYPE_NAME"].ToString();
            model.PD_GK_DEPART_ID = set.Tables[0].Rows[0]["PD_GK_DEPART_ID"].ToString();
            model.PD_GK_DEPART = set.Tables[0].Rows[0]["PD_GK_DEPART"].ToString();
            model.PD_FOUND_XZ = set.Tables[0].Rows[0]["PD_FOUND_XZ"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_TOTAL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_TOTAL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_SJ = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_BJ = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_ZC = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_QT = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT"].ToString()));
            }
            model.PD_PROJECT_MONEY_ADDR = set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ADDR"].ToString();
            model.PD_PROJECT_CONTENT = set.Tables[0].Rows[0]["PD_PROJECT_CONTENT"].ToString();
            model.PD_PROJECT_XMYT = set.Tables[0].Rows[0]["PD_PROJECT_XMYT"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFXZGL"].ToString() != "")
            {
                model.PD_PROJECT_IFXZGL = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFXZGL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString() != "")
            {
                model.PD_PROJECT_IFGS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString() != "")
            {
                model.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString()));
            }
            model.PD_PROJECT_OPEN_BODY = set.Tables[0].Rows[0]["PD_PROJECT_OPEN_BODY"].ToString();
            model.PD_PROJECT_FZR = set.Tables[0].Rows[0]["PD_PROJECT_FZR"].ToString();
            model.PD_PROJECT_CWFZR = set.Tables[0].Rows[0]["PD_PROJECT_CWFZR"].ToString();
            model.PD_PROJECT_STATUS = set.Tables[0].Rows[0]["PD_PROJECT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BEGIN_DATE"].ToString() != "")
            {
                model.PD_PROJECT_BEGIN_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BEGIN_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_END_DATE"].ToString() != "")
            {
                model.PD_PROJECT_END_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_END_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_YEARS"].ToString() != "")
            {
                model.PD_PROJECT_YEARS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_YEARS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_CHECK_DATE"].ToString() != "")
            {
                model.PD_PROJECT_CHECK_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_CHECK_DATE"].ToString()));
            }
            model.PD_PROJECT_FILENO_LX = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_LX"].ToString();
            model.PD_PROJECT_FILENO_JG = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_JG"].ToString();
            model.PD_PROJECT_INPUT_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_COMPANY"].ToString();
            model.ShowPD_PROJECT_INPUT_COMPANY = set.Tables[0].Rows[0]["companyName"].ToString();
            model.PD_PROJECT_INPUT_MAN = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_MAN"].ToString();
            model.ShowPD_PROJECT_INPUT_MAN = set.Tables[0].Rows[0]["truename"].ToString();
            model.PD_PROJECT_INPUT_DATE = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_DATE"].ToString();
            model.PD_PROJECT_REPLY_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_COMPANY"].ToString();
            model.PD_PROJECT_REPLY_MAN2 = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_MAN2"].ToString();
            model.PD_PROJECT_CHECK_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_CHECK_COMPANY"].ToString();
            model.PD_PROJECT_CHENCK_MAN = set.Tables[0].Rows[0]["PD_PROJECT_CHENCK_MAN"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_TOTAL_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL_PF"].ToString()));
            }
            model.PD_PROJECT_REPLY_DATE = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_DATE"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_TOTAL_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_SJ_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_BJ_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_ZC_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_QT_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT_PF"].ToString()));
            }
            model.PD_PROJECT_COUNTRY = set.Tables[0].Rows[0]["PD_PROJECT_COUNTRY"].ToString();
            model.PD_PROJECT_VILLAGE = set.Tables[0].Rows[0]["PD_PROJECT_VILLAGE"].ToString();
            model.PD_PROJECT_GROUP = set.Tables[0].Rows[0]["PD_PROJECT_GROUP"].ToString();
            model.PD_PROJECT_FILENO_PF = set.Tables[0].Rows[0]["PD_QUOTA_ZBWH"].ToString();
            model.PD_PROJECT_FILENO_PF_CODE = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_PF_CODE"].ToString();
            model.PD_PROJ_STATUS = set.Tables[0].Rows[0]["PD_PROJ_STATUS"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString() != "")
            {
                model.PD_IS_RETURN = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString() != "")
            {
                model.PD_ISOUT_QUOTA = new int?(int.Parse(set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString()));
            }
            model.PD_PROJECT_BZYJ = set.Tables[0].Rows[0]["PD_PROJECT_BZYJ"].ToString();
            model.PD_PROJECT_BZFW = set.Tables[0].Rows[0]["PD_PROJECT_BZFW"].ToString();
            model.PD_PROJECT_BZDX = set.Tables[0].Rows[0]["PD_PROJECT_BZDX"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString() != "")
            {
                model.PD_PROJECT_BZNUM = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString()));
            }
            model.PD_PROJECT_BZSTAND_NUM = set.Tables[0].Rows[0]["PD_PROJECT_BZSTAND_NUM"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString() != "")
            {
                model.PD_PROJECT_BZMONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_SYRS"].ToString() != "")
            {
                model.PD_PROJECT_SYRS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SYRS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_BZFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_SJFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString() != "")
            {
                model.PD_PROJECT_IFFF = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString()));
            }
            model.PD_PROJECT_JGYQ = set.Tables[0].Rows[0]["PD_PROJECT_JGYQ"].ToString();
            model.PD_PROJECT_JGJL = set.Tables[0].Rows[0]["PD_PROJECT_JGJL"].ToString();
            model.PD_PROJECT_JG_RESULT = set.Tables[0].Rows[0]["PD_PROJECT_JG_RESULT"].ToString();
            model.PD_PROJECT_JG_SUGGEST = set.Tables[0].Rows[0]["PD_PROJECT_JG_SUGGEST"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_SYHS"].ToString() != "")
            {
                model.PD_PROJECT_SYHS = int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SYHS"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_GNFL"].ToString() != "")
            {
                model.PD_PROJECT_GNFL = set.Tables[0].Rows[0]["PD_PROJECT_GNFL"].ToString();
            }
            model.PD_PROJECT_GNFL_CODE = set.Tables[0].Rows[0]["PD_PROJECT_GNFL_CODE"].ToString();
            model.PD_PROJECT_SERVERPK = set.Tables[0].Rows[0]["PD_PROJECT_SERVERPK"].ToString();
            model.PD_PROJECT_ZJLY = set.Tables[0].Rows[0]["PD_PROJECT_ZJLY"].ToString();
            model.PD_PROJECT_ZGKJ = set.Tables[0].Rows[0]["PD_PROJECT_ZGKJ"].ToString();
            model.PD_PROJECT_CJDW = set.Tables[0].Rows[0]["PD_PROJECT_CJDW"].ToString();
            model.PD_PROJECT_JBDH = set.Tables[0].Rows[0]["PD_PROJECT_JBDH"].ToString();
            model.PD_PROJECT_SSFW = set.Tables[0].Rows[0]["PD_PROJECT_SSFW"].ToString();
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

        public TB_PROJECT_Model GetModelName(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PD_PROJECT_CODE,PD_PROJECT_FILENO_ZB,PD_PROJECT_NAME,(select  max(Year_Name) from PD_BASE_YEAR where Year_Code=a.PD_YEAR) as PD_YEAR_Name,PD_YEAR,PD_PROJECT_TYPE,(select Max(PROJECT_TYPE_NAME) from PD_PROJECT_TYPE where PROJECT_TYPE_CODE=a.PD_PROJECT_TYPE) as PD_PROJECT_TYPE_NAME,PD_GK_DEPART_ID,(select Max(Name) from db_branch where bh=a.PD_GK_DEPART) as PD_GK_DEPART_NAME,PD_GK_DEPART,PD_FOUND_XZ,(select   FOUND_PROPERTY_NAME from PD_BASE_FOUND_PROPERTY where FOUND_PROPERTY_CODE=a.PD_FOUND_XZ) as PD_FOUND_XZ_Name,PD_PROJECT_MONEY_TOTAL,PD_PROJECT_MONEY_CZ_TOTAL,PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_MONEY_CZ_BJ,PD_PROJECT_MONEY_ZC,PD_PROJECT_MONEY_QT,PD_PROJECT_MONEY_ADDR,PD_PROJECT_CONTENT,PD_PROJECT_XMYT,PD_PROJECT_IFXZGL,PD_PROJECT_IFGS,PD_PROJECT_IFGS_BEFORE,PD_PROJECT_OPEN_BODY,PD_PROJECT_FZR,PD_PROJECT_CWFZR,(select Max(STATUS_NAME) from PD_BASE_STATUS where STATUS_CODE = a.PD_PROJECT_STATUS) as PD_PROJECT_STATUS_Name,PD_PROJECT_STATUS,PD_PROJECT_BEGIN_DATE,PD_PROJECT_END_DATE,PD_PROJECT_YEARS,PD_PROJECT_CHECK_DATE,PD_PROJECT_FILENO_LX,PD_PROJECT_FILENO_JG,PD_PROJECT_INPUT_COMPANY,(select Max(Name) from DB_Company where PK_CORP=a.PD_PROJECT_INPUT_COMPANY) as PD_PROJECT_INPUT_COMPANY_Name,PD_PROJECT_INPUT_MAN,PD_PROJECT_INPUT_DATE,PD_PROJECT_REPLY_COMPANY,(select Max(Name) from DB_Company where PK_CORP=a.PD_PROJECT_REPLY_COMPANY) as PD_PROJECT_REPLY_COMPANY_Name,PD_PROJECT_REPLY_MAN2,PD_PROJECT_CHECK_COMPANY,(select Max(Name) from DB_Company where PK_CORP=a.PD_PROJECT_CHECK_COMPANY) as PD_PROJECT_CHECK_COMPANY_Name,PD_PROJECT_CHENCK_MAN,a.PD_PROJECT_MONEY_TOTAL_PF,PD_PROJECT_REPLY_DATE,PD_PROJECT_MONEY_CZ_TOTAL_PF,PD_PROJECT_MONEY_CZ_SJ_PF,PD_PROJECT_MONEY_CZ_BJ_PF,PD_PROJECT_MONEY_ZC_PF,PD_PROJECT_MONEY_QT_PF,(select Max(Name) from DB_Company where PK_CORP=a.PD_PROJECT_INPUT_COMPANY) as PD_PROJECT_COUNTRY_Name ,PD_PROJECT_COUNTRY,PD_PROJECT_VILLAGE,PD_PROJECT_GROUP,op.ShowText PD_PROJECT_FILENO_PF,PD_PROJECT_FILENO_PF PD_PROJECT_FILENO_PF_CODE,PD_PROJ_STATUS,(select max(CheckStatus_Name) from PD_BASE_CheckStatus where CheckStatus_Code=a.PD_PROJ_STATUS) as PD_PROJ_STATUS_Name,PD_PROJ_LAST_AUDIT_STATUS,(select max(CheckStatus_Name) from PD_BASE_CheckStatus where CheckStatus_Code=a.PD_PROJ_LAST_AUDIT_STATUS) as PD_PROJ_LAST_AUDIT_STATUS_Name,PD_IS_RETURN,PD_ISOUT_QUOTA,PD_PROJECT_BZYJ,PD_PROJECT_BZFW,PD_PROJECT_BZDX,PD_PROJECT_BZNUM,PD_PROJECT_BZSTAND_NUM,PD_PROJECT_BZMONEY,PD_PROJECT_SYRS,PD_PROJECT_BZFF_DATE,PD_PROJECT_SJFF_DATE,PD_PROJECT_IFFF,PD_PROJECT_JGYQ,PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT,PD_PROJECT_JG_SUGGEST,PD_PROJECT_SYHS,PD_PROJECT_GNFL,PD_PROJECT_GNFL_CODE,PD_PROJECT_SERVERPK,zjly_name ,zgkj_name ,PD_PROJECT_CJDW,PD_PROJECT_JBDH,PD_PROJECT_SSFW,Free1,Free2,Free3,Free4,Free5,Free6,Free7,Free8,Free9,Free10from TB_PROJECT a");
            builder.Append(" left join open_pd_quotaaddmoney op on trim(op.pd_quota_code)=trim(a.PD_PROJECT_FILENO_PF) ");
            builder.Append(" left join PD_PROJECT_ZGKJ zgkj on trim(zgkj.ZGKJ_CODE)=trim(a.PD_PROJECT_ZGKJ) ");
            builder.Append(" left join PD_PROJECT_ZJLY zjly on trim(zjly.ZJLY_CODE)=trim(a.PD_PROJECT_ZJLY) ");
            builder.Append(" where a.PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            TB_PROJECT_Model model = new TB_PROJECT_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_FILENO_ZB = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_ZB"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            if (set.Tables[0].Rows[0]["PD_YEAR"].ToString() != "")
            {
                model.PD_YEAR = new int?(int.Parse(set.Tables[0].Rows[0]["PD_YEAR"].ToString()));
            }
            model.PD_PROJECT_TYPE = set.Tables[0].Rows[0]["PD_PROJECT_TYPE"].ToString();
            model.PD_PROJECT_TYPE_NAME = set.Tables[0].Rows[0]["PD_PROJECT_TYPE_NAME"].ToString();
            model.PD_GK_DEPART_ID = set.Tables[0].Rows[0]["PD_GK_DEPART_ID"].ToString();
            model.PD_GK_DEPART = set.Tables[0].Rows[0]["PD_GK_DEPART_NAME"].ToString();
            model.PD_GK_DEPART_ID = set.Tables[0].Rows[0]["PD_GK_DEPART"].ToString();
            model.PD_FOUND_XZ = set.Tables[0].Rows[0]["PD_FOUND_XZ"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_TOTAL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_TOTAL = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_SJ = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_BJ = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_ZC = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_QT = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT"].ToString()));
            }
            model.PD_PROJECT_MONEY_ADDR = set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ADDR"].ToString();
            model.PD_PROJECT_CONTENT = set.Tables[0].Rows[0]["PD_PROJECT_CONTENT"].ToString();
            model.PD_PROJECT_XMYT = set.Tables[0].Rows[0]["PD_PROJECT_XMYT"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFXZGL"].ToString() != "")
            {
                model.PD_PROJECT_IFXZGL = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFXZGL"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString() != "")
            {
                model.PD_PROJECT_IFGS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString() != "")
            {
                model.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFGS_BEFORE"].ToString()));
            }
            model.PD_PROJECT_OPEN_BODY = set.Tables[0].Rows[0]["PD_PROJECT_OPEN_BODY"].ToString();
            model.PD_PROJECT_FZR = set.Tables[0].Rows[0]["PD_PROJECT_FZR"].ToString();
            model.PD_PROJECT_CWFZR = set.Tables[0].Rows[0]["PD_PROJECT_CWFZR"].ToString();
            model.PD_PROJECT_STATUS = set.Tables[0].Rows[0]["PD_PROJECT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BEGIN_DATE"].ToString() != "")
            {
                model.PD_PROJECT_BEGIN_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BEGIN_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_END_DATE"].ToString() != "")
            {
                model.PD_PROJECT_END_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_END_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_YEARS"].ToString() != "")
            {
                model.PD_PROJECT_YEARS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_YEARS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_CHECK_DATE"].ToString() != "")
            {
                model.PD_PROJECT_CHECK_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_CHECK_DATE"].ToString()));
            }
            model.PD_PROJECT_FILENO_LX = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_LX"].ToString();
            model.PD_PROJECT_FILENO_JG = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_JG"].ToString();
            model.PD_PROJECT_INPUT_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_COMPANY"].ToString();
            model.PD_PROJECT_INPUT_MAN = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_MAN"].ToString();
            model.PD_PROJECT_INPUT_DATE = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_DATE"].ToString();
            model.PD_PROJECT_REPLY_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_COMPANY"].ToString();
            model.PD_PROJECT_REPLY_MAN2 = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_MAN2"].ToString();
            model.PD_PROJECT_CHECK_COMPANY = set.Tables[0].Rows[0]["PD_PROJECT_CHECK_COMPANY"].ToString();
            model.PD_PROJECT_CHENCK_MAN = set.Tables[0].Rows[0]["PD_PROJECT_CHENCK_MAN"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_TOTAL_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_TOTAL_PF"].ToString()));
            }
            model.PD_PROJECT_REPLY_DATE = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_DATE"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_TOTAL_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_TOTAL_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_SJ_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_SJ_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_CZ_BJ_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_CZ_BJ_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_ZC_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_ZC_PF"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT_PF"].ToString() != "")
            {
                model.PD_PROJECT_MONEY_QT_PF = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_MONEY_QT_PF"].ToString()));
            }
            model.PD_PROJECT_COUNTRY = set.Tables[0].Rows[0]["PD_PROJECT_COUNTRY"].ToString();
            model.PD_PROJECT_VILLAGE = set.Tables[0].Rows[0]["PD_PROJECT_VILLAGE"].ToString();
            model.PD_PROJECT_GROUP = set.Tables[0].Rows[0]["PD_PROJECT_GROUP"].ToString();
            model.PD_PROJECT_FILENO_PF = set.Tables[0].Rows[0]["PD_PROJECT_FILENO_PF"].ToString();
            model.PD_PROJ_STATUS = set.Tables[0].Rows[0]["PD_PROJ_STATUS"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
            if (set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString() != "")
            {
                model.PD_IS_RETURN = new int?(int.Parse(set.Tables[0].Rows[0]["PD_IS_RETURN"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString() != "")
            {
                model.PD_ISOUT_QUOTA = new int?(int.Parse(set.Tables[0].Rows[0]["PD_ISOUT_QUOTA"].ToString()));
            }
            model.PD_PROJECT_BZYJ = set.Tables[0].Rows[0]["PD_PROJECT_BZYJ"].ToString();
            model.PD_PROJECT_BZFW = set.Tables[0].Rows[0]["PD_PROJECT_BZFW"].ToString();
            model.PD_PROJECT_BZDX = set.Tables[0].Rows[0]["PD_PROJECT_BZDX"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString() != "")
            {
                model.PD_PROJECT_BZNUM = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZNUM"].ToString()));
            }
            model.PD_PROJECT_BZSTAND_NUM = set.Tables[0].Rows[0]["PD_PROJECT_BZSTAND_NUM"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString() != "")
            {
                model.PD_PROJECT_BZMONEY = new decimal?(decimal.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZMONEY"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_SYRS"].ToString() != "")
            {
                model.PD_PROJECT_SYRS = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SYRS"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_BZFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_BZFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString() != "")
            {
                model.PD_PROJECT_SJFF_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SJFF_DATE"].ToString()));
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString() != "")
            {
                model.PD_PROJECT_IFFF = new int?(int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_IFFF"].ToString()));
            }
            model.PD_PROJECT_JGYQ = set.Tables[0].Rows[0]["PD_PROJECT_JGYQ"].ToString();
            model.PD_PROJECT_JGJL = set.Tables[0].Rows[0]["PD_PROJECT_JGJL"].ToString();
            model.PD_PROJECT_JG_RESULT = set.Tables[0].Rows[0]["PD_PROJECT_JG_RESULT"].ToString();
            model.PD_PROJECT_JG_SUGGEST = set.Tables[0].Rows[0]["PD_PROJECT_JG_SUGGEST"].ToString();
            if (set.Tables[0].Rows[0]["PD_PROJECT_SYHS"].ToString() != "")
            {
                model.PD_PROJECT_SYHS = int.Parse(set.Tables[0].Rows[0]["PD_PROJECT_SYHS"].ToString());
            }
            if (set.Tables[0].Rows[0]["PD_PROJECT_GNFL"].ToString() != "")
            {
                model.PD_PROJECT_GNFL = set.Tables[0].Rows[0]["PD_PROJECT_GNFL"].ToString();
            }
            model.PD_PROJECT_GNFL_CODE = set.Tables[0].Rows[0]["PD_PROJECT_GNFL_CODE"].ToString();
            model.PD_YEAR_Name = set.Tables[0].Rows[0]["PD_YEAR_Name"].ToString();
            model.PD_FOUND_XZ_Name = set.Tables[0].Rows[0]["PD_FOUND_XZ_Name"].ToString();
            model.PD_PROJECT_STATUS_Name = set.Tables[0].Rows[0]["PD_PROJECT_STATUS_Name"].ToString();
            model.PD_PROJECT_INPUT_COMPANY_Name = set.Tables[0].Rows[0]["PD_PROJECT_INPUT_COMPANY_Name"].ToString();
            model.PD_PROJECT_REPLY_COMPANY_Name = set.Tables[0].Rows[0]["PD_PROJECT_REPLY_COMPANY_Name"].ToString();
            model.PD_PROJECT_CHECK_COMPANY_Name = set.Tables[0].Rows[0]["PD_PROJECT_CHECK_COMPANY_Name"].ToString();
            model.PD_PROJ_STATUS_Name = set.Tables[0].Rows[0]["PD_PROJ_STATUS_Name"].ToString();
            model.PD_PROJ_LAST_AUDIT_STATUS_Name = set.Tables[0].Rows[0]["PD_PROJ_LAST_AUDIT_STATUS_Name"].ToString();
            model.PD_PROJECT_COUNTRY_Name = set.Tables[0].Rows[0]["PD_PROJECT_COUNTRY_Name"].ToString();
            model.PD_PROJECT_SERVERPK = set.Tables[0].Rows[0]["PD_PROJECT_SERVERPK"].ToString();
            model.PD_PROJECT_ZJLY = set.Tables[0].Rows[0]["zjly_name"].ToString();
            model.PD_PROJECT_ZGKJ = set.Tables[0].Rows[0]["zgkj_name"].ToString();
            model.PD_PROJECT_CJDW = set.Tables[0].Rows[0]["PD_PROJECT_CJDW"].ToString();
            model.PD_PROJECT_JBDH = set.Tables[0].Rows[0]["PD_PROJECT_JBDH"].ToString();
            model.PD_PROJECT_SSFW = set.Tables[0].Rows[0]["PD_PROJECT_SSFW"].ToString();
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

        public string GetServerPK(string tableName, string IdName, string IdValue, string PD_NOW_SERVERPK_NAME)
        {
            if ((tableName.Trim() != "") && (IdName != ""))
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT " + PD_NOW_SERVERPK_NAME + " FROM " + tableName);
                builder.Append(" where " + IdName + "=:" + IdName);
                OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":" + IdName, OracleType.VarChar, 50) };
                cmdParms[0].Value = IdValue;
                object single = DbHelperOra.GetSingle(builder.ToString(), cmdParms);
                if (single != null)
                {
                    return single.ToString();
                }
            }
            return "";
        }

        public bool NameExists(string PD_PROJECT_NAME)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from TB_PROJECT");
            builder.Append(" where PD_PROJECT_NAME=:PD_PROJECT_NAME ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_NAME;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        internal bool PD_SUB_QuotaMoney(object code, object money, string company, ref decimal okMoney, string pd_project_code)
        {
            DataSet set;
            StringBuilder builder = new StringBuilder();
            builder.Append("select pd_up_money-nvl(( ");
            builder.Append("select sum(t.pd_project_money_cz_sj)sumMoney  from PD_PROJECT_TZJGC t,tb_project m  ");
            builder.Append("where t.pd_project_code=m.pd_project_code and t.tb_quota_code is not null and t.tb_quota_code=:tb_quota_code    ");
            if (pd_project_code != "")
            {
                builder.Append(" and t.pd_project_code!=:pd_project_code ");
            }
            builder.Append(" and m.pd_project_input_company=:company_code  ");
            builder.Append("group by t.tb_quota_code ");
            builder.Append("),0)jyMoney from TB_QUOTA_DETAIL ");
            builder.Append("where pd_quota_code=:tb_quota_code  and company_code=:company_code ");
            if (pd_project_code != "")
            {
                OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":company_code", OracleType.NVarChar, 20), new OracleParameter(":tb_quota_code", OracleType.NVarChar, 30), new OracleParameter(":pd_project_code", OracleType.NVarChar, 30) };
                cmdParms[0].Value = company;
                cmdParms[1].Value = code;
                cmdParms[2].Value = pd_project_code;
                set = DbHelperOra.Query(builder.ToString(), cmdParms);
            }
            else
            {
                OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter(":company_code", OracleType.NVarChar, 20), new OracleParameter(":tb_quota_code", OracleType.NVarChar, 30) };
                parameterArray2[0].Value = company;
                parameterArray2[1].Value = code;
                set = DbHelperOra.Query(builder.ToString(), parameterArray2);
            }
            if (set.Tables[0].Rows.Count <= 0)
            {
                return false;
            }
            decimal num = decimal.Parse(set.Tables[0].Rows[0]["JYMONEY"].ToString());
            decimal num2 = decimal.Parse(money.ToString());
            if (num2 > num)
            {
                okMoney = num2 - num;
                return false;
            }
            return true;
        }

        internal bool ProjectIsBX(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*) from tb_project where Free1=:pd_project_code");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":pd_project_code", OracleType.NVarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public bool Update(TB_PROJECT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_PROJECT set ");
            builder.Append("PD_PROJECT_FILENO_ZB=:PD_PROJECT_FILENO_ZB,");
            builder.Append("PD_PROJECT_NAME=:PD_PROJECT_NAME,");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("PD_PROJECT_TYPE=:PD_PROJECT_TYPE,");
            builder.Append("PD_PROJECT_TYPE_NAME=:PD_PROJECT_TYPE_NAME,");
            builder.Append("PD_GK_DEPART_ID=:PD_GK_DEPART_ID,");
            builder.Append("PD_GK_DEPART=:PD_GK_DEPART,");
            builder.Append("PD_FOUND_XZ=:PD_FOUND_XZ,");
            builder.Append("PD_PROJECT_MONEY_TOTAL=:PD_PROJECT_MONEY_TOTAL,");
            builder.Append("PD_PROJECT_MONEY_CZ_TOTAL=:PD_PROJECT_MONEY_CZ_TOTAL,");
            builder.Append("PD_PROJECT_MONEY_CZ_SJ=:PD_PROJECT_MONEY_CZ_SJ,");
            builder.Append("PD_PROJECT_MONEY_CZ_BJ=:PD_PROJECT_MONEY_CZ_BJ,");
            builder.Append("PD_PROJECT_MONEY_ZC=:PD_PROJECT_MONEY_ZC,");
            builder.Append("PD_PROJECT_MONEY_QT=:PD_PROJECT_MONEY_QT,");
            builder.Append("PD_PROJECT_MONEY_ADDR=:PD_PROJECT_MONEY_ADDR,");
            builder.Append("PD_PROJECT_CONTENT=:PD_PROJECT_CONTENT,");
            builder.Append("PD_PROJECT_XMYT=:PD_PROJECT_XMYT,");
            builder.Append("PD_PROJECT_IFXZGL=:PD_PROJECT_IFXZGL,");
            builder.Append("PD_PROJECT_IFGS=:PD_PROJECT_IFGS,");
            builder.Append("PD_PROJECT_IFGS_BEFORE=:PD_PROJECT_IFGS_BEFORE,");
            builder.Append("PD_PROJECT_OPEN_BODY=:PD_PROJECT_OPEN_BODY,");
            builder.Append("PD_PROJECT_FZR=:PD_PROJECT_FZR,");
            builder.Append("PD_PROJECT_CWFZR=:PD_PROJECT_CWFZR,");
            builder.Append("PD_PROJECT_STATUS=:PD_PROJECT_STATUS,");
            builder.Append("PD_PROJECT_BEGIN_DATE=:PD_PROJECT_BEGIN_DATE,");
            builder.Append("PD_PROJECT_END_DATE=:PD_PROJECT_END_DATE,");
            builder.Append("PD_PROJECT_YEARS=:PD_PROJECT_YEARS,");
            builder.Append("PD_PROJECT_CHECK_DATE=:PD_PROJECT_CHECK_DATE,");
            builder.Append("PD_PROJECT_FILENO_LX=:PD_PROJECT_FILENO_LX,");
            builder.Append("PD_PROJECT_FILENO_JG=:PD_PROJECT_FILENO_JG,");
            builder.Append("PD_PROJECT_INPUT_COMPANY=:PD_PROJECT_INPUT_COMPANY,");
            builder.Append("PD_PROJECT_INPUT_MAN=:PD_PROJECT_INPUT_MAN,");
            builder.Append("PD_PROJECT_INPUT_DATE=:PD_PROJECT_INPUT_DATE,");
            builder.Append("PD_PROJECT_REPLY_COMPANY=:PD_PROJECT_REPLY_COMPANY,");
            builder.Append("PD_PROJECT_REPLY_MAN2=:PD_PROJECT_REPLY_MAN2,");
            builder.Append("PD_PROJECT_CHECK_COMPANY=:PD_PROJECT_CHECK_COMPANY,");
            builder.Append("PD_PROJECT_CHENCK_MAN=:PD_PROJECT_CHENCK_MAN,");
            builder.Append("PD_PROJECT_MONEY_TOTAL_PF=:PD_PROJECT_MONEY_TOTAL_PF,");
            builder.Append("PD_PROJECT_REPLY_DATE=:PD_PROJECT_REPLY_DATE,");
            builder.Append("PD_PROJECT_MONEY_CZ_TOTAL_PF=:PD_PROJECT_MONEY_CZ_TOTAL_PF,");
            builder.Append("PD_PROJECT_MONEY_CZ_SJ_PF=:PD_PROJECT_MONEY_CZ_SJ_PF,");
            builder.Append("PD_PROJECT_MONEY_CZ_BJ_PF=:PD_PROJECT_MONEY_CZ_BJ_PF,");
            builder.Append("PD_PROJECT_MONEY_ZC_PF=:PD_PROJECT_MONEY_ZC_PF,");
            builder.Append("PD_PROJECT_MONEY_QT_PF=:PD_PROJECT_MONEY_QT_PF,");
            builder.Append("PD_PROJECT_COUNTRY=:PD_PROJECT_COUNTRY,");
            builder.Append("PD_PROJECT_VILLAGE=:PD_PROJECT_VILLAGE,");
            builder.Append("PD_PROJECT_GROUP=:PD_PROJECT_GROUP,");
            builder.Append("PD_PROJECT_FILENO_PF=:PD_PROJECT_FILENO_PF,");
            builder.Append("PD_PROJ_STATUS=:PD_PROJ_STATUS,");
            builder.Append("PD_PROJ_LAST_AUDIT_STATUS=:PD_PROJ_LAST_AUDIT_STATUS,");
            builder.Append("PD_IS_RETURN=:PD_IS_RETURN,");
            builder.Append("PD_ISOUT_QUOTA=:PD_ISOUT_QUOTA,");
            builder.Append("PD_PROJECT_BZYJ=:PD_PROJECT_BZYJ,");
            builder.Append("PD_PROJECT_BZFW=:PD_PROJECT_BZFW,");
            builder.Append("PD_PROJECT_BZDX=:PD_PROJECT_BZDX,");
            builder.Append("PD_PROJECT_BZNUM=:PD_PROJECT_BZNUM,");
            builder.Append("PD_PROJECT_BZSTAND_NUM=:PD_PROJECT_BZSTAND_NUM,");
            builder.Append("PD_PROJECT_BZMONEY=:PD_PROJECT_BZMONEY,");
            builder.Append("PD_PROJECT_SYRS=:PD_PROJECT_SYRS,");
            builder.Append("PD_PROJECT_BZFF_DATE=:PD_PROJECT_BZFF_DATE,");
            builder.Append("PD_PROJECT_SJFF_DATE=:PD_PROJECT_SJFF_DATE,");
            builder.Append("PD_PROJECT_IFFF=:PD_PROJECT_IFFF,");
            builder.Append("PD_PROJECT_JGYQ=:PD_PROJECT_JGYQ,");
            builder.Append("PD_PROJECT_JGJL=:PD_PROJECT_JGJL,");
            builder.Append("PD_PROJECT_JG_RESULT=:PD_PROJECT_JG_RESULT,");
            builder.Append("PD_PROJECT_JG_SUGGEST=:PD_PROJECT_JG_SUGGEST,");
            builder.Append("PD_PROJECT_SYHS=:PD_PROJECT_SYHS,");
            builder.Append("PD_PROJECT_GNFL=:PD_PROJECT_GNFL,");
            builder.Append("PD_PROJECT_GNFL_CODE=:PD_PROJECT_GNFL_CODE,");
            builder.Append("PD_PROJECT_ZJLY=:PD_PROJECT_ZJLY,");
            builder.Append("PD_PROJECT_ZGKJ=:PD_PROJECT_ZGKJ,");
            builder.Append("PD_PROJECT_CJDW=:PD_PROJECT_CJDW,");
            builder.Append("PD_PROJECT_JBDH=:PD_PROJECT_JBDH,");
            builder.Append("PD_PROJECT_SSFW=:PD_PROJECT_SSFW,");
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
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
                new OracleParameter(":PD_PROJECT_FILENO_ZB", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_YEAR", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_TYPE", OracleType.VarChar, 30), new OracleParameter(":PD_PROJECT_TYPE_NAME", OracleType.VarChar, 100), new OracleParameter(":PD_GK_DEPART_ID", OracleType.VarChar, 100), new OracleParameter(":PD_GK_DEPART", OracleType.VarChar, 100), new OracleParameter(":PD_FOUND_XZ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_TOTAL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_BJ", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ZC", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_QT", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ADDR", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_CONTENT", OracleType.VarChar, 0xfa0), 
                new OracleParameter(":PD_PROJECT_XMYT", OracleType.VarChar, 0xfa0), new OracleParameter(":PD_PROJECT_IFXZGL", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_IFGS_BEFORE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_OPEN_BODY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_FZR", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CWFZR", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_STATUS", OracleType.VarChar, 20), new OracleParameter(":PD_PROJECT_BEGIN_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_END_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_YEARS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CHECK_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_FILENO_LX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_FILENO_JG", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_INPUT_MAN", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_INPUT_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_REPLY_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_REPLY_MAN2", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CHECK_COMPANY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CHENCK_MAN", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_TOTAL_PF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_REPLY_DATE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_MONEY_CZ_TOTAL_PF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_SJ_PF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_CZ_BJ_PF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_ZC_PF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_MONEY_QT_PF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_COUNTRY", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_VILLAGE", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_GROUP", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_FILENO_PF", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJ_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_PROJ_LAST_AUDIT_STATUS", OracleType.VarChar, 100), new OracleParameter(":PD_IS_RETURN", OracleType.Number, 4), new OracleParameter(":PD_ISOUT_QUOTA", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZYJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZFW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZDX", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZNUM", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZSTAND_NUM", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_BZMONEY", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_SYRS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_BZFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_SJFF_DATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_IFFF", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_JGYQ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JGJL", OracleType.VarChar, 100), 
                new OracleParameter(":PD_PROJECT_JG_RESULT", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JG_SUGGEST", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SYHS", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_GNFL", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_GNFL_CODE", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ZJLY", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_ZGKJ", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_CJDW", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_JBDH", OracleType.VarChar, 100), new OracleParameter(":PD_PROJECT_SSFW", OracleType.VarChar, 100), new OracleParameter(":Free1", OracleType.VarChar, 100), new OracleParameter(":Free2", OracleType.VarChar, 100), new OracleParameter(":Free3", OracleType.VarChar, 100), new OracleParameter(":Free4", OracleType.VarChar, 100), new OracleParameter(":Free5", OracleType.VarChar, 100), new OracleParameter(":Free6", OracleType.Int32, 4), 
                new OracleParameter(":Free7", OracleType.Int32, 4), new OracleParameter(":Free8", OracleType.Number), new OracleParameter(":Free9", OracleType.Number), new OracleParameter(":Free10", OracleType.Number), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 30)
             };
            cmdParms[0].Value = model.PD_PROJECT_FILENO_ZB;
            cmdParms[1].Value = model.PD_PROJECT_NAME;
            cmdParms[2].Value = model.PD_YEAR;
            cmdParms[3].Value = model.PD_PROJECT_TYPE;
            cmdParms[4].Value = model.PD_PROJECT_TYPE_NAME;
            cmdParms[5].Value = model.PD_GK_DEPART_ID;
            cmdParms[6].Value = model.PD_GK_DEPART;
            cmdParms[7].Value = model.PD_FOUND_XZ;
            cmdParms[8].Value = model.PD_PROJECT_MONEY_TOTAL;
            cmdParms[9].Value = model.PD_PROJECT_MONEY_CZ_TOTAL;
            cmdParms[10].Value = model.PD_PROJECT_MONEY_CZ_SJ;
            cmdParms[11].Value = model.PD_PROJECT_MONEY_CZ_BJ;
            cmdParms[12].Value = model.PD_PROJECT_MONEY_ZC;
            cmdParms[13].Value = model.PD_PROJECT_MONEY_QT;
            cmdParms[14].Value = model.PD_PROJECT_MONEY_ADDR;
            cmdParms[15].Value = model.PD_PROJECT_CONTENT;
            cmdParms[0x10].Value = model.PD_PROJECT_XMYT;
            cmdParms[0x11].Value = model.PD_PROJECT_IFXZGL;
            cmdParms[0x12].Value = model.PD_PROJECT_IFGS;
            cmdParms[0x13].Value = model.PD_PROJECT_IFGS_BEFORE;
            cmdParms[20].Value = model.PD_PROJECT_OPEN_BODY;
            cmdParms[0x15].Value = model.PD_PROJECT_FZR;
            cmdParms[0x16].Value = model.PD_PROJECT_CWFZR;
            cmdParms[0x17].Value = model.PD_PROJECT_STATUS;
            cmdParms[0x18].Value = model.PD_PROJECT_BEGIN_DATE;
            cmdParms[0x19].Value = model.PD_PROJECT_END_DATE;
            cmdParms[0x1a].Value = model.PD_PROJECT_YEARS;
            cmdParms[0x1b].Value = model.PD_PROJECT_CHECK_DATE;
            cmdParms[0x1c].Value = model.PD_PROJECT_FILENO_LX;
            cmdParms[0x1d].Value = model.PD_PROJECT_FILENO_JG;
            cmdParms[30].Value = model.PD_PROJECT_INPUT_COMPANY;
            cmdParms[0x1f].Value = model.PD_PROJECT_INPUT_MAN;
            cmdParms[0x20].Value = model.PD_PROJECT_INPUT_DATE;
            cmdParms[0x21].Value = model.PD_PROJECT_REPLY_COMPANY;
            cmdParms[0x22].Value = model.PD_PROJECT_REPLY_MAN2;
            cmdParms[0x23].Value = model.PD_PROJECT_CHECK_COMPANY;
            cmdParms[0x24].Value = model.PD_PROJECT_CHENCK_MAN;
            cmdParms[0x25].Value = model.PD_PROJECT_MONEY_TOTAL_PF;
            cmdParms[0x26].Value = model.PD_PROJECT_REPLY_DATE;
            cmdParms[0x27].Value = model.PD_PROJECT_MONEY_CZ_TOTAL_PF;
            cmdParms[40].Value = model.PD_PROJECT_MONEY_CZ_SJ_PF;
            cmdParms[0x29].Value = model.PD_PROJECT_MONEY_CZ_BJ_PF;
            cmdParms[0x2a].Value = model.PD_PROJECT_MONEY_ZC_PF;
            cmdParms[0x2b].Value = model.PD_PROJECT_MONEY_QT_PF;
            cmdParms[0x2c].Value = model.PD_PROJECT_COUNTRY;
            cmdParms[0x2d].Value = model.PD_PROJECT_VILLAGE;
            cmdParms[0x2e].Value = model.PD_PROJECT_GROUP;
            cmdParms[0x2f].Value = model.PD_PROJECT_FILENO_PF;
            cmdParms[0x30].Value = model.PD_PROJ_STATUS;
            cmdParms[0x31].Value = model.PD_PROJ_LAST_AUDIT_STATUS;
            cmdParms[50].Value = model.PD_IS_RETURN;
            cmdParms[0x33].Value = model.PD_ISOUT_QUOTA;
            cmdParms[0x34].Value = model.PD_PROJECT_BZYJ;
            cmdParms[0x35].Value = model.PD_PROJECT_BZFW;
            cmdParms[0x36].Value = model.PD_PROJECT_BZDX;
            cmdParms[0x37].Value = model.PD_PROJECT_BZNUM;
            cmdParms[0x38].Value = model.PD_PROJECT_BZSTAND_NUM;
            cmdParms[0x39].Value = model.PD_PROJECT_BZMONEY;
            cmdParms[0x3a].Value = model.PD_PROJECT_SYRS;
            cmdParms[0x3b].Value = model.PD_PROJECT_BZFF_DATE;
            cmdParms[60].Value = model.PD_PROJECT_SJFF_DATE;
            cmdParms[0x3d].Value = model.PD_PROJECT_IFFF;
            cmdParms[0x3e].Value = model.PD_PROJECT_JGYQ;
            cmdParms[0x3f].Value = model.PD_PROJECT_JGJL;
            cmdParms[0x40].Value = model.PD_PROJECT_JG_RESULT;
            cmdParms[0x41].Value = model.PD_PROJECT_JG_SUGGEST;
            cmdParms[0x42].Value = model.PD_PROJECT_SYHS;
            cmdParms[0x43].Value = model.PD_PROJECT_GNFL;
            cmdParms[0x44].Value = model.PD_PROJECT_GNFL_CODE;
            cmdParms[0x45].Value = model.PD_PROJECT_ZJLY;
            cmdParms[70].Value = model.PD_PROJECT_ZGKJ;
            cmdParms[0x47].Value = model.PD_PROJECT_CJDW;
            cmdParms[0x48].Value = model.PD_PROJECT_JBDH;
            cmdParms[0x49].Value = model.PD_PROJECT_SSFW;
            cmdParms[0x4a].Value = model.Free1;
            cmdParms[0x4b].Value = model.Free2;
            cmdParms[0x4c].Value = model.Free3;
            cmdParms[0x4d].Value = model.Free4;
            cmdParms[0x4e].Value = model.Free5;
            cmdParms[0x4f].Value = model.Free6;
            cmdParms[80].Value = model.Free7;
            cmdParms[0x51].Value = model.Free8;
            cmdParms[0x52].Value = model.Free9;
            cmdParms[0x53].Value = model.Free10;
            cmdParms[0x54].Value = model.PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        internal int UpdateJGJL(TB_PROJECT_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_PROJECT set PD_PROJECT_JGJL=:PD_PROJECT_JGJL,PD_PROJECT_JG_RESULT=:PD_PROJECT_JG_RESULT,PD_PROJECT_JG_SUGGEST=:PD_PROJECT_JG_SUGGEST where PD_PROJECT_CODE=:PD_PROJECT_CODE");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_JGJL", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_JG_RESULT", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_JG_SUGGEST", OracleType.VarChar, 50), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = model.PD_PROJECT_JGJL;
            cmdParms[1].Value = model.PD_PROJECT_JG_RESULT;
            cmdParms[2].Value = model.PD_PROJECT_JG_SUGGEST;
            cmdParms[3].Value = model.PD_PROJECT_CODE;
            return DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        internal int UpdatePFMoney(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update TB_PROJECT set PD_PROJECT_MONEY_TOTAL_PF=PD_PROJECT_MONEY_TOTAL,PD_PROJECT_MONEY_CZ_TOTAL_PF=PD_PROJECT_MONEY_CZ_TOTAL,PD_PROJECT_MONEY_CZ_SJ_PF=PD_PROJECT_MONEY_CZ_SJ,PD_PROJECT_MONEY_CZ_BJ_PF=PD_PROJECT_MONEY_CZ_BJ,PD_PROJECT_MONEY_ZC_PF=PD_PROJECT_MONEY_ZC,PD_PROJECT_MONEY_QT_PF=PD_PROJECT_MONEY_QT");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool UpdateServerPK(string tableName, string IdName, string IdValue, string ServerPK, string PD_NOW_SERVERPK_NAME)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update " + tableName + "  set " + PD_NOW_SERVERPK_NAME + "=:" + PD_NOW_SERVERPK_NAME + " ");
            builder.Append(" where " + IdName + "=:" + IdName + " ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":" + PD_NOW_SERVERPK_NAME, OracleType.VarChar, 50), new OracleParameter(":" + IdName, OracleType.VarChar, 50) };
            cmdParms[0].Value = ServerPK;
            cmdParms[1].Value = IdValue;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

