namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;
    public class MESS_BACK_Dal
    {
        public void Add(MESS_BACK_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into MESS_BACK(");
            builder.Append("MES_ID,MES_COMPANY,MES_DEPT,MES_MAN,MES_DATE,MES_KUNAN,MES_JIANYI,MES_XZYJ,MES_PZ,MES_TITLE,MES_FLAG,MES_SHCOMPANY,MES_SHDEPT,MES_SHMAN,MES_SHDATE,PD_NOW_SERVERPK,PD_PROJECT_CODE,PD_QUOTA_DEPART,PD_YEAR,PD_BASE_FKLX,MES_YWGSYJ,MES_XCJYJ)");
            builder.Append(" values (");
            builder.Append(":MES_ID,:MES_COMPANY,:MES_DEPT,:MES_MAN,:MES_DATE,:MES_KUNAN,:MES_JIANYI,:MES_XZYJ,:MES_PZ,:MES_TITLE,:MES_FLAG,:MES_SHCOMPANY,:MES_SHDEPT,:MES_SHMAN,:MES_SHDATE,:PD_NOW_SERVERPK,:PD_PROJECT_CODE,:PD_QUOTA_DEPART,:PD_YEAR,:PD_BASE_FKLX,:MES_YWGSYJ,:MES_XCJYJ)");
            OracleParameter[] cmdParms = new OracleParameter[] { 
            new OracleParameter(":MES_ID", OracleType.VarChar, 30), new OracleParameter(":MES_COMPANY", OracleType.VarChar, 50), new OracleParameter(":MES_DEPT", OracleType.VarChar, 50), new OracleParameter(":MES_MAN", OracleType.VarChar, 50), new OracleParameter(":MES_DATE", OracleType.DateTime), new OracleParameter(":MES_KUNAN", OracleType.VarChar, 100), new OracleParameter(":MES_JIANYI", OracleType.VarChar, 100), new OracleParameter(":MES_XZYJ", OracleType.VarChar, 100), new OracleParameter(":MES_PZ", OracleType.VarChar, 200), new OracleParameter(":MES_TITLE", OracleType.VarChar, 100), new OracleParameter(":MES_FLAG", OracleType.Char, 1), new OracleParameter(":MES_SHCOMPANY", OracleType.VarChar, 50), new OracleParameter(":MES_SHDEPT", OracleType.VarChar, 50), new OracleParameter(":MES_SHMAN", OracleType.VarChar, 50), new OracleParameter(":MES_SHDATE", OracleType.DateTime), new OracleParameter(":PD_NOW_SERVERPK", OracleType.VarChar, 50), 
            new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_DEPART", OracleType.VarChar, 50), new OracleParameter(":PD_YEAR", OracleType.VarChar, 6), new OracleParameter(":PD_BASE_FKLX", OracleType.VarChar, 10), new OracleParameter(":MES_YWGSYJ", OracleType.VarChar, 0xff), new OracleParameter(":MES_XCJYJ", OracleType.VarChar, 0xff)
         };
            cmdParms[0].Value = model.MES_ID;
            cmdParms[1].Value = model.MES_COMPANY;
            cmdParms[2].Value = model.MES_DEPT;
            cmdParms[3].Value = model.MES_MAN;
            cmdParms[4].Value = model.MES_DATE;
            cmdParms[5].Value = model.MES_KUNAN;
            cmdParms[6].Value = model.MES_JIANYI;
            cmdParms[7].Value = model.MES_XZYJ;
            cmdParms[8].Value = model.MES_PZ;
            cmdParms[9].Value = model.MES_TITLE;
            cmdParms[10].Value = model.MES_FLAG;
            cmdParms[11].Value = model.MES_SHCOMPANY;
            cmdParms[12].Value = model.MES_SHDEPT;
            cmdParms[13].Value = model.MES_SHMAN;
            cmdParms[14].Value = model.MES_SHDATE;
            cmdParms[15].Value = model.PD_NOW_SERVERPK;
            cmdParms[0x10].Value = model.PD_PROJECT_CODE;
            cmdParms[0x11].Value = model.PD_QUOTA_DEPART;
            cmdParms[0x12].Value = model.PD_YEAR;
            cmdParms[0x13].Value = model.PD_BASE_FKLX;
            cmdParms[20].Value = model.MES_YWGSYJ;
            cmdParms[0x15].Value = model.MES_XCJYJ;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string MES_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from MESS_BACK ");
            builder.Append(" where MES_ID=:MES_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":MES_ID", OracleType.VarChar, 50) };
            cmdParms[0].Value = MES_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string MES_IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from MESS_BACK ");
            builder.Append(" where MES_ID in (" + MES_IDlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select MES_ID,MES_COMPANY,MES_DEPT,MES_MAN,MES_DATE,MES_KUNAN,MES_JIANYI,MES_XZYJ,MES_PZ,MES_TITLE,MES_FLAG,MES_SHCOMPANY,MES_SHDEPT,MES_SHMAN,MES_SHDATE,PD_NOW_SERVERPK,PD_PROJECT_CODE,PD_QUOTA_DEPART,PD_YEAR,PD_BASE_FKLX,MES_YWGSYJ,MES_XCJYJ ");
            builder.Append(" FROM MESS_BACK ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public MESS_BACK_Model GetModel(string MES_ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select MES_ID,MES_COMPANY,MES_DEPT,MES_MAN,MES_DATE,MES_KUNAN,MES_JIANYI,MES_XZYJ,MES_PZ,MES_TITLE,MES_FLAG,MES_SHCOMPANY,MES_SHDEPT,MES_SHMAN,MES_SHDATE,PD_NOW_SERVERPK,t.PD_PROJECT_CODE,PD_QUOTA_DEPART,t.PD_YEAR,PD_PROJECT_NAME,PD_BASE_FKLX,comp.name MES_COMPANY_NAME,MES_YWGSYJ,MES_XCJYJ");
            builder.Append(" from MESS_BACK t ");
            builder.Append(" left join tb_project pro on pro.PD_PROJECT_CODE=t.PD_PROJECT_CODE");
            builder.Append(" left join db_company comp on trim(comp.pk_corp)=trim(t.MES_COMPANY)");
            builder.Append(" where MES_ID=:MES_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":MES_ID", OracleType.VarChar, 50) };
            cmdParms[0].Value = MES_ID;
            MESS_BACK_Model model = new MESS_BACK_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            model.MES_ID = set.Tables[0].Rows[0]["MES_ID"].ToString();
            model.MES_COMPANY = set.Tables[0].Rows[0]["MES_COMPANY"].ToString();
            model.MES_COMPANY_NAME = set.Tables[0].Rows[0]["MES_COMPANY_NAME"].ToString();
            model.MES_DEPT = set.Tables[0].Rows[0]["MES_DEPT"].ToString();
            model.MES_MAN = set.Tables[0].Rows[0]["MES_MAN"].ToString();
            if (set.Tables[0].Rows[0]["MES_DATE"].ToString() != "")
            {
                model.MES_DATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["MES_DATE"].ToString()));
            }
            model.MES_KUNAN = set.Tables[0].Rows[0]["MES_KUNAN"].ToString();
            model.MES_JIANYI = set.Tables[0].Rows[0]["MES_JIANYI"].ToString();
            model.MES_XZYJ = set.Tables[0].Rows[0]["MES_XZYJ"].ToString();
            model.MES_PZ = set.Tables[0].Rows[0]["MES_PZ"].ToString();
            model.MES_TITLE = set.Tables[0].Rows[0]["MES_TITLE"].ToString();
            model.MES_FLAG = set.Tables[0].Rows[0]["MES_FLAG"].ToString();
            model.MES_SHCOMPANY = set.Tables[0].Rows[0]["MES_SHCOMPANY"].ToString();
            model.MES_SHDEPT = set.Tables[0].Rows[0]["MES_SHDEPT"].ToString();
            model.MES_SHMAN = set.Tables[0].Rows[0]["MES_SHMAN"].ToString();
            model.PD_NOW_SERVERPK = set.Tables[0].Rows[0]["PD_NOW_SERVERPK"].ToString();
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.PD_PROJECT_NAME = set.Tables[0].Rows[0]["PD_PROJECT_NAME"].ToString();
            model.PD_QUOTA_DEPART = set.Tables[0].Rows[0]["PD_QUOTA_DEPART"].ToString();
            model.PD_YEAR = set.Tables[0].Rows[0]["PD_YEAR"].ToString();
            model.PD_BASE_FKLX = set.Tables[0].Rows[0]["PD_BASE_FKLX"].ToString();
            model.MES_YWGSYJ = set.Tables[0].Rows[0]["MES_YWGSYJ"].ToString();
            model.MES_XCJYJ = set.Tables[0].Rows[0]["MES_XCJYJ"].ToString();
            if (set.Tables[0].Rows[0]["MES_SHDATE"].ToString() != "")
            {
                model.MES_SHDATE = new DateTime?(DateTime.Parse(set.Tables[0].Rows[0]["MES_SHDATE"].ToString()));
            }
            return model;
        }

        public bool Update(MESS_BACK_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update MESS_BACK set ");
            builder.Append("MES_COMPANY=:MES_COMPANY,");
            builder.Append("MES_DEPT=:MES_DEPT,");
            builder.Append("MES_MAN=:MES_MAN,");
            builder.Append("MES_DATE=:MES_DATE,");
            builder.Append("MES_KUNAN=:MES_KUNAN,");
            builder.Append("MES_JIANYI=:MES_JIANYI,");
            builder.Append("MES_XZYJ=:MES_XZYJ,");
            builder.Append("MES_PZ=:MES_PZ,");
            builder.Append("MES_TITLE=:MES_TITLE,");
            builder.Append("MES_FLAG=:MES_FLAG,");
            builder.Append("MES_SHCOMPANY=:MES_SHCOMPANY,");
            builder.Append("MES_SHDEPT=:MES_SHDEPT,");
            builder.Append("MES_SHMAN=:MES_SHMAN,");
            builder.Append("MES_SHDATE=:MES_SHDATE,");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("PD_QUOTA_DEPART=:PD_QUOTA_DEPART,");
            builder.Append("PD_YEAR=:PD_YEAR,");
            builder.Append("PD_BASE_FKLX=:PD_BASE_FKLX,");
            builder.Append("MES_YWGSYJ=:MES_YWGSYJ,");
            builder.Append("MES_XCJYJ=:MES_XCJYJ");
            builder.Append(" where MES_ID=:MES_ID ");
            OracleParameter[] cmdParms = new OracleParameter[] { 
            new OracleParameter(":MES_COMPANY", OracleType.VarChar, 50), new OracleParameter(":MES_DEPT", OracleType.VarChar, 50), new OracleParameter(":MES_MAN", OracleType.VarChar, 50), new OracleParameter(":MES_DATE", OracleType.DateTime), new OracleParameter(":MES_KUNAN", OracleType.VarChar, 100), new OracleParameter(":MES_JIANYI", OracleType.VarChar, 100), new OracleParameter(":MES_XZYJ", OracleType.VarChar, 100), new OracleParameter(":MES_PZ", OracleType.VarChar, 200), new OracleParameter(":MES_TITLE", OracleType.VarChar, 100), new OracleParameter(":MES_FLAG", OracleType.Char, 1), new OracleParameter(":MES_SHCOMPANY", OracleType.VarChar, 50), new OracleParameter(":MES_SHDEPT", OracleType.VarChar, 50), new OracleParameter(":MES_SHMAN", OracleType.VarChar, 50), new OracleParameter(":MES_SHDATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50), new OracleParameter(":PD_QUOTA_DEPART", OracleType.VarChar, 50), 
            new OracleParameter(":PD_YEAR", OracleType.VarChar, 4), new OracleParameter(":PD_BASE_FKLX", OracleType.VarChar, 10), new OracleParameter(":MES_YWGSYJ", OracleType.VarChar, 0xff), new OracleParameter(":MES_XCJYJ", OracleType.VarChar, 0xff), new OracleParameter(":MES_ID", OracleType.VarChar, 30)
         };
            cmdParms[0].Value = model.MES_COMPANY;
            cmdParms[1].Value = model.MES_DEPT;
            cmdParms[2].Value = model.MES_MAN;
            cmdParms[3].Value = model.MES_DATE;
            cmdParms[4].Value = model.MES_KUNAN;
            cmdParms[5].Value = model.MES_JIANYI;
            cmdParms[6].Value = model.MES_XZYJ;
            cmdParms[7].Value = model.MES_PZ;
            cmdParms[8].Value = model.MES_TITLE;
            cmdParms[9].Value = model.MES_FLAG;
            cmdParms[10].Value = model.MES_SHCOMPANY;
            cmdParms[11].Value = model.MES_SHDEPT;
            cmdParms[12].Value = model.MES_SHMAN;
            cmdParms[13].Value = model.MES_SHDATE;
            cmdParms[14].Value = model.PD_PROJECT_CODE;
            cmdParms[15].Value = model.PD_QUOTA_DEPART;
            cmdParms[0x10].Value = model.PD_YEAR;
            cmdParms[0x11].Value = model.PD_BASE_FKLX;
            cmdParms[0x12].Value = model.MES_YWGSYJ;
            cmdParms[0x13].Value = model.MES_XCJYJ;
            cmdParms[20].Value = model.MES_ID;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }

}