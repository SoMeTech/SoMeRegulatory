namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;
    using SMZJ.Model;

    public class PD_PROJECT_REGULATE_DETAIL_Dal
    {
        public void Add(PD_PROJECT_REGULATE_DETAIL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into PD_PROJECT_REGULATE_DETAIL(");
            builder.Append("AUTO_NO,PD_PROJECT_CODE,FILENAME,FILESYSNAME,FILETYPE)");
            builder.Append(" values (");
            builder.Append(":AUTO_NO,:PD_PROJECT_CODE,:FILENAME,:FILESYSNAME,:FILETYPE)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":AUTO_NO", OracleType.Number, 20), new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":FILENAME", OracleType.VarChar, 100), new OracleParameter(":FILESYSNAME", OracleType.VarChar, 50), new OracleParameter(":FILETYPE", OracleType.Char, 1) };
            cmdParms[0].Value = model.AUTO_NO;
            cmdParms[1].Value = model.PD_PROJECT_CODE;
            cmdParms[2].Value = model.FILENAME;
            cmdParms[3].Value = model.FILESYSNAME;
            cmdParms[4].Value = model.FILETYPE;
            DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_REGULATE_DETAIL ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from PD_PROJECT_REGULATE_DETAIL ");
            builder.Append(" where PD_PROJECT_CODE in (" + PD_PROJECT_CODElist + ")  ");
            return (DbHelperOra.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from PD_PROJECT_REGULATE_DETAIL");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            return DbHelperOra.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,FILENAME,FILESYSNAME,FILETYPE ");
            builder.Append(" FROM PD_PROJECT_REGULATE_DETAIL ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public PD_PROJECT_REGULATE_DETAIL_Model GetModel(string PD_PROJECT_CODE)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select AUTO_NO,PD_PROJECT_CODE,FILENAME,FILESYSNAME,FILETYPE from PD_PROJECT_REGULATE_DETAIL ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 50) };
            cmdParms[0].Value = PD_PROJECT_CODE;
            PD_PROJECT_REGULATE_DETAIL_Model model = new PD_PROJECT_REGULATE_DETAIL_Model();
            DataSet set = DbHelperOra.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["AUTO_NO"].ToString() != "")
            {
                model.AUTO_NO = int.Parse(set.Tables[0].Rows[0]["AUTO_NO"].ToString());
            }
            model.PD_PROJECT_CODE = set.Tables[0].Rows[0]["PD_PROJECT_CODE"].ToString();
            model.FILENAME = set.Tables[0].Rows[0]["FILENAME"].ToString();
            model.FILESYSNAME = set.Tables[0].Rows[0]["FILESYSNAME"].ToString();
            model.FILETYPE = set.Tables[0].Rows[0]["FILETYPE"].ToString();
            return model;
        }

        public bool Update(PD_PROJECT_REGULATE_DETAIL_Model model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_REGULATE_DETAIL set ");
            builder.Append("PD_PROJECT_CODE=:PD_PROJECT_CODE,");
            builder.Append("FILENAME=:FILENAME,");
            builder.Append("FILESYSNAME=:FILESYSNAME,");
            builder.Append("FILETYPE=:FILETYPE");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.VarChar, 0x24), new OracleParameter(":FILENAME", OracleType.VarChar, 100), new OracleParameter(":FILESYSNAME", OracleType.VarChar, 50), new OracleParameter(":FILETYPE", OracleType.Char, 1), new OracleParameter(":AUTO_NO", OracleType.Number, 20) };
            cmdParms[0].Value = model.PD_PROJECT_CODE;
            cmdParms[1].Value = model.FILENAME;
            cmdParms[2].Value = model.FILESYSNAME;
            cmdParms[3].Value = model.FILETYPE;
            cmdParms[4].Value = model.AUTO_NO;
            return (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

