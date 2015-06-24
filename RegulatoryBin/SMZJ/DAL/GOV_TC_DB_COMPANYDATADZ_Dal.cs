namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class GOV_TC_DB_COMPANYDATADZ_Dal
    {
        public bool Add(GOV_TC_DB_COMPANYDATADZ_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into GOV_TC_DB_COMPANYDATADZ(");
            builder.Append("PK,DATANAME,TABLENAME,COLUMNNAME,COMPANYBH,SHOWNAME,IP,USERID,PWD)");
            builder.Append(" values (");
            builder.Append(":PK,:DATANAME,:TABLENAME,:COLUMNNAME,:COMPANYBH,:SHOWNAME,:IP,:USERID,:PWD)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PK", OracleType.Number, 4), new OracleParameter(":DATANAME", OracleType.VarChar, 40), new OracleParameter(":TABLENAME", OracleType.VarChar, 100), new OracleParameter(":COLUMNNAME", OracleType.VarChar, 0xff), new OracleParameter(":COMPANYBH", OracleType.VarChar, 40), new OracleParameter(":SHOWNAME", OracleType.VarChar, 40), new OracleParameter(":IP", OracleType.VarChar, 40), new OracleParameter(":USERID", OracleType.VarChar, 40), new OracleParameter(":PWD", OracleType.VarChar, 40) };
            cmdParms[0].Value = model.PK;
            cmdParms[1].Value = model.DATANAME;
            cmdParms[2].Value = model.TABLENAME;
            cmdParms[3].Value = model.COLUMNNAME;
            cmdParms[4].Value = model.COMPANYBH;
            cmdParms[5].Value = model.SHOWNAME;
            cmdParms[6].Value = model.IP;
            cmdParms[7].Value = model.USERID;
            cmdParms[8].Value = model.PWD;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(long PK)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GOV_TC_DB_COMPANYDATADZ ");
            builder.Append(" where PK=:PK ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PK", OracleType.Number, 20) };
            cmdParms[0].Value = PK;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PKlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from GOV_TC_DB_COMPANYDATADZ ");
            builder.Append(" where PK in (" + PKlist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int PK)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from GOV_TC_DB_COMPANYDATADZ");
            builder.Append(" where PK=:PK ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PK", OracleType.Number, 4) };
            cmdParms[0].Value = PK;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,DATANAME,TABLENAME,COLUMNNAME,COMPANYBH,SHOWNAME,IP,USERID,PWD ");
            builder.Append(" FROM GOV_TC_DB_COMPANYDATADZ ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperOra.GetMaxID("PK", "GOV_TC_DB_COMPANYDATADZ");
        }

        public GOV_TC_DB_COMPANYDATADZ_Model GetModel(long PK)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PK,DATANAME,TABLENAME,COLUMNNAME,COMPANYBH,db_company.name COMPANYNAME,SHOWNAME,IP,USERID,PWD from GOV_TC_DB_COMPANYDATADZ ");
            builder.Append(" left join db_company on db_company.pk_corp=GOV_TC_DB_COMPANYDATADZ.COMPANYBH ");
            builder.Append(" where PK=:PK ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PK", OracleType.Number, 4) };
            cmdParms[0].Value = PK;
            GOV_TC_DB_COMPANYDATADZ_Model model = new GOV_TC_DB_COMPANYDATADZ_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["PK"].ToString() != "")
            {
                model.PK = long.Parse(set.Tables[0].Rows[0]["PK"].ToString());
            }
            model.DATANAME = set.Tables[0].Rows[0]["DATANAME"].ToString();
            model.TABLENAME = set.Tables[0].Rows[0]["TABLENAME"].ToString();
            model.COLUMNNAME = set.Tables[0].Rows[0]["COLUMNNAME"].ToString();
            model.COMPANYBH = set.Tables[0].Rows[0]["COMPANYBH"].ToString();
            model.COMPANYNAME = set.Tables[0].Rows[0]["COMPANYNAME"].ToString();
            model.SHOWNAME = set.Tables[0].Rows[0]["SHOWNAME"].ToString();
            model.IP = set.Tables[0].Rows[0]["IP"].ToString();
            model.USERID = set.Tables[0].Rows[0]["USERID"].ToString();
            model.PWD = set.Tables[0].Rows[0]["PWD"].ToString();
            return model;
        }

        public DataSet GetSQLDataName()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT count(name) FROM Master..SysDatabases  where Name='anyisys' ");
            DbHelperSQL.connectionString = "server=.;database=Master;uid=sa;pwd=123456";
            DataSet set = DbHelperSQL.Query(builder.ToString());
            if (((set.Tables.Count > 0) && (set.Tables[0].Rows.Count > 0)) && (int.Parse(set.Tables[0].Rows[0][0].ToString()) > 0))
            {
                return DbHelperSQL.Query("select ltrim(rtrim(ztmc))+'['+ltrim(rtrim(zth))+']' ztmc,dbname from anyisys.dbo.anyigl");
            }
            return null;
        }

        public bool Update(GOV_TC_DB_COMPANYDATADZ_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update GOV_TC_DB_COMPANYDATADZ set ");
            builder.Append("DATANAME=:DATANAME,");
            builder.Append("TABLENAME=:TABLENAME,");
            builder.Append("COLUMNNAME=:COLUMNNAME,");
            builder.Append("COMPANYBH=:COMPANYBH,");
            builder.Append("SHOWNAME=:SHOWNAME,");
            builder.Append("IP=:IP,");
            builder.Append("USERID=:USERID,");
            builder.Append("PWD=:PWD");
            builder.Append(" where PK=:PK ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":DATANAME", OracleType.VarChar, 40), new OracleParameter(":TABLENAME", OracleType.VarChar, 100), new OracleParameter(":COLUMNNAME", OracleType.VarChar, 0xff), new OracleParameter(":COMPANYBH", OracleType.VarChar, 40), new OracleParameter(":SHOWNAME", OracleType.VarChar, 40), new OracleParameter(":IP", OracleType.VarChar, 40), new OracleParameter(":USERID", OracleType.VarChar, 40), new OracleParameter(":PWD", OracleType.VarChar, 40), new OracleParameter(":PK", OracleType.Number, 4) };
            cmdParms[0].Value = model.DATANAME;
            cmdParms[1].Value = model.TABLENAME;
            cmdParms[2].Value = model.COLUMNNAME;
            cmdParms[3].Value = model.COMPANYBH;
            cmdParms[4].Value = model.SHOWNAME;
            cmdParms[5].Value = model.IP;
            cmdParms[6].Value = model.USERID;
            cmdParms[7].Value = model.PWD;
            cmdParms[8].Value = model.PK;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

