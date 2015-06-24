namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_ATTACH_SS_Bll
    {
        private readonly PD_PROJECT_ATTACH_SS_Dal dal = new PD_PROJECT_ATTACH_SS_Dal();

        public void Add(PD_PROJECT_ATTACH_SS_Model model)
        {
            this.dal.Add(model);
        }

        public void AddList(List<PD_PROJECT_ATTACH_SS_Model> modelList)
        {
            foreach (PD_PROJECT_ATTACH_SS_Model model in modelList)
            {
                this.dal.Add(model);
            }
        }

        public List<PD_PROJECT_ATTACH_SS_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_ATTACH_SS_Model> list = new List<PD_PROJECT_ATTACH_SS_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_ATTACH_SS_Model item = new PD_PROJECT_ATTACH_SS_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString(),
                        PD_PROJECT_ATTACH_TYPE = dt.Rows[i]["PD_PROJECT_ATTACH_TYPE"].ToString(),
                        PD_PROJECT_ATTACH_NAME = dt.Rows[i]["PD_PROJECT_ATTACH_NAME"].ToString(),
                        PD_PROJECT_ATTACH_NAME_SYSTEM = dt.Rows[i]["PD_PROJECT_ATTACH_NAME_SYSTEM"].ToString()
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            return this.dal.Delete(PD_PROJECT_CODE);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            return this.dal.DeleteList(PD_PROJECT_CODElist);
        }

        public bool Exists(string PD_PROJECT_CODE)
        {
            return this.dal.Exists(PD_PROJECT_CODE);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public PD_PROJECT_ATTACH_SS_Model GetModel(string PD_PROJECT_CODE)
        {
            return this.dal.GetModel(PD_PROJECT_CODE);
        }

        public PD_PROJECT_ATTACH_SS_Model GetModelByCache(string PD_PROJECT_CODE)
        {
            string cacheKey = "PD_PROJECT_ATTACH_SSModel-" + PD_PROJECT_CODE;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(PD_PROJECT_CODE);
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
            return (PD_PROJECT_ATTACH_SS_Model) cache;
        }

        public List<PD_PROJECT_ATTACH_SS_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_ATTACH_SS_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

