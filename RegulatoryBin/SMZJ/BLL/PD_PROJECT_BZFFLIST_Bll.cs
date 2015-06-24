namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_BZFFLIST_Bll
    {
        private readonly PD_PROJECT_BZFFLIST_Dal dal = new PD_PROJECT_BZFFLIST_Dal();

        public void Add(PD_PROJECT_BZFFLIST_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_PROJECT_BZFFLIST_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_BZFFLIST_Model> list = new List<PD_PROJECT_BZFFLIST_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_BZFFLIST_Model item = new PD_PROJECT_BZFFLIST_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString()
                    };
                    if (dt.Rows[i]["PD_BZFFLIST_DATE"].ToString() != "")
                    {
                        item.PD_BZFFLIST_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_BZFFLIST_DATE"].ToString()));
                    }
                    item.PD_BZFFLIST_COMPANY = dt.Rows[i]["PD_BZFFLIST_COMPANY"].ToString();
                    item.PD_BZFFLIST_COUNTRY = dt.Rows[i]["PD_BZFFLIST_COUNTRY"].ToString();
                    item.PD_BZFFLIST_PEASANT_CODE = dt.Rows[i]["PD_BZFFLIST_PEASANT_CODE"].ToString();
                    item.PD_BZFFLIST_PEASANT_NAME = dt.Rows[i]["PD_BZFFLIST_PEASANT_NAME"].ToString();
                    item.PD_BZFFLIST_IDNO = dt.Rows[i]["PD_BZFFLIST_IDNO"].ToString();
                    if (dt.Rows[i]["PD_BZFFLIST_FFNUM"].ToString() != "")
                    {
                        item.PD_BZFFLIST_FFNUM = new decimal?(int.Parse(dt.Rows[i]["PD_BZFFLIST_FFNUM"].ToString()));
                    }
                    if (dt.Rows[i]["PD_BZFFLIST_FFSTAND"].ToString() != "")
                    {
                        item.PD_BZFFLIST_FFSTAND = new decimal?(int.Parse(dt.Rows[i]["PD_BZFFLIST_FFSTAND"].ToString()));
                    }
                    if (dt.Rows[i]["PD_BZFFLIST_FFMONEY"].ToString() != "")
                    {
                        item.PD_BZFFLIST_FFMONEY = new decimal?(int.Parse(dt.Rows[i]["PD_BZFFLIST_FFMONEY"].ToString()));
                    }
                    item.PD_BZFFLIST_ACCOUNTNO = dt.Rows[i]["PD_BZFFLIST_ACCOUNTNO"].ToString();
                    item.PD_BZFFLIST_PEASANT_ADDR = dt.Rows[i]["PD_BZFFLIST_PEASANT_ADDR"].ToString();
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

        public PD_PROJECT_BZFFLIST_Model GetModel(string AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_PROJECT_BZFFLIST_Model GetModelByCache(string AUTO_NO)
        {
            string cacheKey = "PD_PROJECT_BZFFLISTModel-" + AUTO_NO;
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
            return (PD_PROJECT_BZFFLIST_Model) cache;
        }

        public List<PD_PROJECT_BZFFLIST_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_BZFFLIST_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

