namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_ZTB_Bll
    {
        private readonly PD_PROJECT_ZTB_Dal dal = new PD_PROJECT_ZTB_Dal();

        public void Add(PD_PROJECT_ZTB_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_PROJECT_ZTB_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_ZTB_Model> list = new List<PD_PROJECT_ZTB_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_ZTB_Model item = new PD_PROJECT_ZTB_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString()
                    };
                    if (dt.Rows[i]["PD_PROJECT_ZTB_IF_SSFA"].ToString() != "")
                    {
                        item.PD_PROJECT_ZTB_IF_SSFA = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_ZTB_IF_SSFA"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_ZTB_IF_ZTB"].ToString() != "")
                    {
                        item.PD_PROJECT_ZTB_IF_ZTB = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_ZTB_IF_ZTB"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_ZTB_IF_WCFB"].ToString() != "")
                    {
                        item.PD_PROJECT_ZTB_IF_WCFB = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_ZTB_IF_WCFB"].ToString()));
                    }
                    item.PD_PROJECT_ZTB_STYLE = dt.Rows[i]["PD_PROJECT_ZTB_STYLE"].ToString();
                    item.PD_PROJECT_ZTB_FILE = dt.Rows[i]["PD_PROJECT_ZTB_FILE"].ToString();
                    item.PD_PROJECT_ZTB_FILE_SYSTEM = dt.Rows[i]["PD_PROJECT_ZTB_FILE_SYSTEM"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(string AUTO_NO)
        {
            return this.dal.Delete(AUTO_NO);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            return this.dal.DeleteList(AUTO_NOlist);
        }

        public bool DeletePROJECT(string PD_PROJECT_CODE)
        {
            return this.dal.DeletePROJECT(PD_PROJECT_CODE);
        }

        public bool Exists(string AUTO_NO)
        {
            return this.dal.Exists(AUTO_NO);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public PD_PROJECT_ZTB_Model GetModel(string AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_PROJECT_ZTB_Model GetModelByCache(string AUTO_NO)
        {
            string cacheKey = "PD_PROJECT_ZTBModel-" + AUTO_NO;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(AUTO_NO);
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
            return (PD_PROJECT_ZTB_Model) cache;
        }

        public List<PD_PROJECT_ZTB_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public PD_PROJECT_ZTB_Model GetModelPROJECT(string PD_PROJECT_CODE)
        {
            return this.dal.GetModelPROJECT(PD_PROJECT_CODE);
        }

        public bool Update(PD_PROJECT_ZTB_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

