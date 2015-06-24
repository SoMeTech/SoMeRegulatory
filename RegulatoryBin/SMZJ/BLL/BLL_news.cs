namespace SMZJ.BLL
{
    using SMZJ.DAL;
    using SMZJ.Model;
    using System;
    using System.Data;

    public class BLL_news
    {
        private DAL_news dal = new DAL_news();

        public int Add(news model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(string newid)
        {
            return this.dal.Delete(newid);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public string GetNextID(string id)
        {
            return this.dal.GetNextID(id);
        }

        public string GetTopID(string id)
        {
            return this.dal.GetTopID(id);
        }

        public int Update(news model)
        {
            return this.dal.Update(model);
        }
    }
}

