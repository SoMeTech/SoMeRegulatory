namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using SMZJ.Model;
    using System;
    using System.Data;
    using System.Data.OracleClient;
    using System.Text;

    public class DAL_news
    {
        public int Add(news model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into pd_project_regulate(");
            builder.Append("PD_PROJECT_CODE,PD_PROJECT_SUBJECTS,PD_PROJECT_CONTENTS,PD_PROJECT_SYSDATE,PD_PROJECT_TYPE)");
            builder.Append(" values (");
            builder.Append(":PD_PROJECT_CODE,:PD_PROJECT_SUBJECTS,:PD_PROJECT_CONTENTS,:PD_PROJECT_SYSDATE,:PD_PROJECT_TYPE)");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.Char, 0x24), new OracleParameter(":PD_PROJECT_SUBJECTS", OracleType.VarChar, 220), new OracleParameter(":PD_PROJECT_CONTENTS", OracleType.LongVarChar), new OracleParameter(":PD_PROJECT_SYSDATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_TYPE", OracleType.Number, 4) };
            cmdParms[0].Value = model.newid;
            cmdParms[1].Value = model.subjects;
            cmdParms[2].Value = model.contents;
            cmdParms[3].Value = model.sysdate_;
            cmdParms[4].Value = model.type;
            return DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }

        public bool Delete(string newid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from pd_project_regulate ");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_CODE", OracleType.Char, 0x24) };
            cmdParms[0].Value = newid;
            if (DbHelperOra.ExecuteSql(builder.ToString(), cmdParms) <= 0)
            {
                return false;
            }
            return true;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM PD_PROJECT_REGULATE ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }

        public string GetNextID(string id)
        {
            DataSet set = DbHelperOra.Query("select min(newid) from pd_news where newid>'" + id + "'");
            if (set.Tables[0].Rows[0][0].ToString().Trim() != "")
            {
                return set.Tables[0].Rows[0][0].ToString();
            }
            return "0";
        }

        public string GetTopID(string id)
        {
            DataSet set = DbHelperOra.Query("select max(newid) from pd_news where newid<'" + id + "'");
            if (set.Tables[0].Rows[0][0].ToString().Trim() != "")
            {
                return set.Tables[0].Rows[0][0].ToString();
            }
            return "0";
        }

        public int Update(news model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update PD_PROJECT_REGULATE set ");
            builder.Append("PD_PROJECT_SUBJECTS=:PD_PROJECT_SUBJECTS,");
            builder.Append("PD_PROJECT_CONTENTS=:PD_PROJECT_CONTENTS,");
            builder.Append("PD_PROJECT_SYSDATE=:PD_PROJECT_SYSDATE,");
            builder.Append("PD_PROJECT_TYPE=:PD_PROJECT_TYPE");
            builder.Append(" where PD_PROJECT_CODE=:PD_PROJECT_CODE ");
            OracleParameter[] cmdParms = new OracleParameter[] { new OracleParameter(":PD_PROJECT_SUBJECTS", OracleType.VarChar, 220), new OracleParameter(":PD_PROJECT_CONTENTS", OracleType.LongVarChar), new OracleParameter(":PD_PROJECT_SYSDATE", OracleType.DateTime), new OracleParameter(":PD_PROJECT_TYPE", OracleType.Number, 4), new OracleParameter(":PD_PROJECT_CODE", OracleType.Char, 100) };
            cmdParms[0].Value = model.subjects;
            cmdParms[1].Value = model.contents;
            cmdParms[2].Value = model.sysdate_;
            cmdParms[3].Value = model.type;
            cmdParms[4].Value = model.newid;
            return DbHelperOra.ExecuteSql(builder.ToString(), cmdParms);
        }
    }
}

