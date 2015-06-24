namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_MONITOR_Bll
    {
        private readonly PD_PROJECT_MONITOR_Dal dal = new PD_PROJECT_MONITOR_Dal();

        public void Add(PD_PROJECT_MONITOR_Model model)
        {
            this.dal.Add(model);
        }

        public void AddList(List<PD_PROJECT_MONITOR_Model> modelList)
        {
            foreach (PD_PROJECT_MONITOR_Model model in modelList)
            {
                this.dal.Add(model);
            }
        }

        public List<PD_PROJECT_MONITOR_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_MONITOR_Model> list = new List<PD_PROJECT_MONITOR_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_MONITOR_Model item = new PD_PROJECT_MONITOR_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString()
                    };
                    if (dt.Rows[i]["PD_MONITOR_INPUT_DATE"].ToString() != "")
                    {
                        item.PD_MONITOR_INPUT_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_MONITOR_INPUT_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_MONITOR_INPUT_MONTH"].ToString() != "")
                    {
                        item.PD_MONITOR_INPUT_MONTH = new int?(int.Parse(dt.Rows[i]["PD_MONITOR_INPUT_MONTH"].ToString()));
                    }
                    if (dt.Rows[i]["PD_MONITOR_PROCEED_WCL"].ToString() != "")
                    {
                        item.PD_MONITOR_PROCEED_WCL = new decimal?(int.Parse(dt.Rows[i]["PD_MONITOR_PROCEED_WCL"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_TOTAL_MONEY"].ToString() != "")
                    {
                        item.PD_PROJECT_TOTAL_MONEY = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_TOTAL_MONEY"].ToString()));
                    }
                    if (dt.Rows[i]["PD_MONITOR_TOTAL_MONEY_PAY"].ToString() != "")
                    {
                        item.PD_MONITOR_TOTAL_MONEY_PAY = new decimal?(int.Parse(dt.Rows[i]["PD_MONITOR_TOTAL_MONEY_PAY"].ToString()));
                    }
                    if (dt.Rows[i]["PD_MONITOR_TOTAL_MONEY_WCL"].ToString() != "")
                    {
                        item.PD_MONITOR_TOTAL_MONEY_WCL = new decimal?(int.Parse(dt.Rows[i]["PD_MONITOR_TOTAL_MONEY_WCL"].ToString()));
                    }
                    item.PD_MONITOR_FILENAME = dt.Rows[i]["PD_MONITOR_FILENAME"].ToString();
                    item.PD_MONITOR_FILENAME_SYSTEM = dt.Rows[i]["PD_MONITOR_FILENAME_SYSTEM"].ToString();
                    item.PD_ISGKGS = dt.Rows[i]["PD_ISGKGS"].ToString();
                    item.PD_ZHILIANG = dt.Rows[i]["PD_ZHILIANG"].ToString();
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

        public PD_PROJECT_MONITOR_Model GetModel(string AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_PROJECT_MONITOR_Model GetModelByCache(string AUTO_NO)
        {
            string cacheKey = "PD_PROJECT_MONITORModel-" + AUTO_NO;
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
            return (PD_PROJECT_MONITOR_Model) cache;
        }

        public List<PD_PROJECT_MONITOR_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_MONITOR_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

