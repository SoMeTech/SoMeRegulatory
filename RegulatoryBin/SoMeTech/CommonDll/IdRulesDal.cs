namespace SoMeTech.CommonDll
{
    using SoMeTech.DataAccess;
    using System;
    using System.Data;
    using System.Text;

    public sealed class IdRulesDal
    {
        public DataSet GetList(string strWhere, DB_OPT dbo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select PARAGRAPHS,ID,TYPEID,CURRENTVALUE,ENDSIGN,STEP,ISRESTORE,INITIALVALUE,RESTORECYCLE,MAXVALUE ");
            builder.Append(" FROM DB_IdRules join DB_RulesType on DB_IdRules.TypeId=DB_RulesType.TypeId ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return dbo.BackDataSet(builder.ToString(), null);
        }

        public int UpdateDate(string currentDate, int id, int typeid, DB_OPT dbo)
        {
            string strSql = string.Concat(new object[] { "update DB_IdRules set CurrentValue='", currentDate, "' where id=", id, " and typeid=  ", typeid });
            return dbo.ExecutionIsSucess(strSql, null);
        }

        public int UpdateNum(int currentvalue, int id, int typeid, DB_OPT dbo)
        {
            string strSql = string.Concat(new object[] { "update DB_IdRules set CurrentValue='", currentvalue, "' where id=", id, " and typeid=  ", typeid });
            return dbo.ExecutionIsSucess(strSql, null);
        }
    }
}

