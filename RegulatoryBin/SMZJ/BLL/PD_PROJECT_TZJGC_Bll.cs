namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_TZJGC_Bll
    {
        private readonly PD_PROJECT_TZJGC_Dal dal = new PD_PROJECT_TZJGC_Dal();

        public bool Add(PD_PROJECT_TZJGC_Model model)
        {
            return this.dal.Add(model);
        }

        public bool Add(List<PD_PROJECT_TZJGC_Model> ListModel)
        {
            foreach (PD_PROJECT_TZJGC_Model model in ListModel)
            {
                this.dal.Add(model);
            }
            return true;
        }

        public List<PD_PROJECT_TZJGC_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_TZJGC_Model> list = new List<PD_PROJECT_TZJGC_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_TZJGC_Model item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete(string ID)
        {
            return this.dal.Delete(ID);
        }

        public bool DeleteAll(string PD_PROJECT_CODE)
        {
            return this.dal.DeleteAll(PD_PROJECT_CODE);
        }

        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(string ID)
        {
            return this.dal.Exists(ID);
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

        public PD_PROJECT_TZJGC_Model GetModel(string ID)
        {
            return this.dal.GetModel(ID);
        }

        public PD_PROJECT_TZJGC_Model GetModelByCache(string ID)
        {
            string cacheKey = "PD_PROJECT_TZJGCModel-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(ID);
                    if (cache != null)
                    {
                        int configInt = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(cacheKey, cache, DateTime.Now.AddMinutes((double) configInt), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (PD_PROJECT_TZJGC_Model) cache;
        }

        public List<PD_PROJECT_TZJGC_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public DataSet GetProjectList(string PD_PROJECT_CODE)
        {
            return this.dal.GetProjectList(PD_PROJECT_CODE);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(PD_PROJECT_TZJGC_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

