namespace SMZJ.DAL
{
    using SoMeTech.Data;
    using System;
    using System.Data;
    using System.Text;

    public class ReportPublicDal
    {
        public DataSet GetList(string strWhere, string ViewName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from " + ViewName);
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }
    }
}

