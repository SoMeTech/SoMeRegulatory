namespace SMZJ.BLL
{
    using System;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;
    using System.Text;
    using SoMeTech.Data;
    public class GL_GNFL_dal
    {
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT fzdm id,fzdm||' - '||fzmc fzmc ,(length(trim(fzdm))-1)/2   leve,0 parentID FROM gl_fzxzl where gsdm=2015 and lbdm=4 and length(trim(fzdm))=3 ");
            builder.Append(" union all ");
            builder.Append("select fzdm id,fzdm||' - '||fzmc fzmc,(length(trim(fzdm))-1)/2   leve,to_number(substr(fzdm,1,length(trim(fzdm))-2)) parentID from gl_fzxzl where gsdm=2015 and lbdm=4 and length(trim(fzdm))>3 order by id");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(builder.ToString());
        }


    }
}
