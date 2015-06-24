namespace SMZJ.BLL
{
    using System;
    using System.Data;
    using SMZJ.DAL;

    public class ReportPublicBll
    {
        private readonly ReportPublicDal dal = new ReportPublicDal();

        public DataSet GetList(string strWhere, string ViewName)
        {
            return this.dal.GetList(strWhere, ViewName);
        }
    }
}

