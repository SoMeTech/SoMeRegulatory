namespace SMZJ.BLL
{
    using SMZJ.DAL;
    using SMZJ.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class reportParam_Bll
    {
        private readonly reportParam_Dal dal = new reportParam_Dal();

        public bool Add(reportParam_Model model)
        {
            return this.dal.Add(model);
        }

        public List<reportParam_Model> DataTableToList(DataTable dt)
        {
            List<reportParam_Model> list = new List<reportParam_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    reportParam_Model item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete(int id)
        {
            return this.dal.Delete(id);
        }

        public bool DeleteList(string idlist)
        {
            return this.dal.DeleteList(idlist);
        }

        public bool Exists(int id)
        {
            return this.dal.Exists(id);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public reportParam_Model GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public List<reportParam_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(reportParam_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

