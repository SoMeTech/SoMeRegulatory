namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_INSPECTION_Bll
    {
        private readonly PD_PROJECT_INSPECTION_Dal dal = new PD_PROJECT_INSPECTION_Dal();

        public bool Add(PD_PROJECT_INSPECTION_Model model)
        {
            return this.dal.Add(model);
        }

        public void AddList(List<PD_PROJECT_INSPECTION_Model> modelList)
        {
            foreach (PD_PROJECT_INSPECTION_Model model in modelList)
            {
                this.dal.Add(model);
            }
        }

        public List<PD_PROJECT_INSPECTION_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_INSPECTION_Model> list = new List<PD_PROJECT_INSPECTION_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_INSPECTION_Model item = new PD_PROJECT_INSPECTION_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString(),
                        PD_INSPECTION_PROCESS = dt.Rows[i]["PD_INSPECTION_PROCESS"].ToString()
                    };
                    if (dt.Rows[i]["PD_INSPECTION_DATE"].ToString() != "")
                    {
                        item.PD_INSPECTION_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_INSPECTION_DATE"].ToString()));
                    }
                    item.PD_INSPECTION_MANS = dt.Rows[i]["PD_INSPECTION_MANS"].ToString();
                    item.PD_INSPECTION_ADDR = dt.Rows[i]["PD_INSPECTION_ADDR"].ToString();
                    item.PD_INSPECTION_CONTENT = dt.Rows[i]["PD_INSPECTION_CONTENT"].ToString();
                    item.PD_INSPECTION_SUGGEST = dt.Rows[i]["PD_INSPECTION_SUGGEST"].ToString();
                    item.PD_INSPECTION_CONCLUSION = dt.Rows[i]["PD_INSPECTION_CONCLUSION"].ToString();
                    item.PD_INSPECTION_FILENAME = dt.Rows[i]["PD_INSPECTION_FILENAME"].ToString();
                    item.PD_INSPECTION_FILENAME_SYSTEM = dt.Rows[i]["PD_INSPECTION_FILENAME_SYSTEM"].ToString();
                    item.PD_INSPECTION_PEASANT = dt.Rows[i]["PD_INSPECTION_PEASANT"].ToString();
                    item.PD_INSPECTION_IDNO = dt.Rows[i]["PD_INSPECTION_IDNO"].ToString();
                    if (dt.Rows[i]["PD_INSPECTION_FFNUM"].ToString() != "")
                    {
                        item.PD_INSPECTION_FFNUM = new int?(int.Parse(dt.Rows[i]["PD_INSPECTION_FFNUM"].ToString()));
                    }
                    if (dt.Rows[i]["PD_INSPECTION_FFSTAND"].ToString() != "")
                    {
                        item.PD_INSPECTION_FFSTAND = new decimal?(int.Parse(dt.Rows[i]["PD_INSPECTION_FFSTAND"].ToString()));
                    }
                    if (dt.Rows[i]["PD_INSPECTION_FFMONEY"].ToString() != "")
                    {
                        item.PD_INSPECTION_FFMONEY = new decimal?(int.Parse(dt.Rows[i]["PD_INSPECTION_FFMONEY"].ToString()));
                    }
                    item.PD_INSPECTION_ACCOUNTNO = dt.Rows[i]["PD_INSPECTION_ACCOUNTNO"].ToString();
                    item.PD_INSPECTION_PEASANT_ADDR = dt.Rows[i]["PD_INSPECTION_PEASANT_ADDR"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(long AUTO_NO)
        {
            return this.dal.Delete(AUTO_NO);
        }

        public bool Delete(string PD_PROJECT_CODE, string str_Where)
        {
            return this.dal.Delete(PD_PROJECT_CODE, str_Where);
        }

        public bool DeleteList(string PD_PROJECT_CODElist)
        {
            return this.dal.DeleteList(PD_PROJECT_CODElist);
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

        public PD_PROJECT_INSPECTION_Model GetModel(int AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_PROJECT_INSPECTION_Model GetModelByCache(int AUTO_NO)
        {
            string cacheKey = "PD_PROJECT_INSPECTIONModel-" + AUTO_NO;
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
            return (PD_PROJECT_INSPECTION_Model) cache;
        }

        public List<PD_PROJECT_INSPECTION_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public DataSet HeDuiData(string PD_PROJECT_CODE)
        {
            return this.dal.HeDuiData(PD_PROJECT_CODE);
        }

        public bool Update(PD_PROJECT_INSPECTION_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

