namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_CONTRACT_Bll
    {
        private readonly PD_PROJECT_CONTRACT_Dal dal = new PD_PROJECT_CONTRACT_Dal();

        public void Add(PD_PROJECT_CONTRACT_Model model)
        {
            this.dal.Add(model);
        }

        public void AddList(List<PD_PROJECT_CONTRACT_Model> modelList)
        {
            foreach (PD_PROJECT_CONTRACT_Model model in modelList)
            {
                this.dal.Add(model);
            }
        }

        public List<PD_PROJECT_CONTRACT_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_CONTRACT_Model> list = new List<PD_PROJECT_CONTRACT_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_CONTRACT_Model item = new PD_PROJECT_CONTRACT_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString(),
                        PD_CONTRACT_TYPE = dt.Rows[i]["PD_CONTRACT_TYPE"].ToString(),
                        PD_CONTRACT_NO = dt.Rows[i]["PD_CONTRACT_NO"].ToString()
                    };
                    if (dt.Rows[i]["PD_CONTRACT_DATE"].ToString() != "")
                    {
                        item.PD_CONTRACT_DATE = DateTime.Parse(dt.Rows[i]["PD_CONTRACT_DATE"].ToString());
                    }
                    item.PD_CONTRACT_COMPANY = dt.Rows[i]["PD_CONTRACT_COMPANY"].ToString();
                    if (dt.Rows[i]["PD_CONTRACT_MOENY"].ToString() != "")
                    {
                        item.PD_CONTRACT_MOENY = new decimal?(int.Parse(dt.Rows[i]["PD_CONTRACT_MOENY"].ToString()));
                    }
                    if (dt.Rows[i]["PD_CONTRACT_MOENY_CHANGE"].ToString() != "")
                    {
                        item.PD_CONTRACT_MOENY_CHANGE = new decimal?(int.Parse(dt.Rows[i]["PD_CONTRACT_MOENY_CHANGE"].ToString()));
                    }
                    item.PD_CONTRACT_ASK_LIMIT = dt.Rows[i]["PD_CONTRACT_ASK_LIMIT"].ToString();
                    item.PD_CONTRACT_ASK_PROCEED = dt.Rows[i]["PD_CONTRACT_ASK_PROCEED"].ToString();
                    item.PD_CONTRACT_ASK_PAYMENT = dt.Rows[i]["PD_CONTRACT_ASK_PAYMENT"].ToString();
                    item.PD_CONTRACT_NOTE = dt.Rows[i]["PD_CONTRACT_NOTE"].ToString();
                    item.PD_CONTRACT_FILENAME = dt.Rows[i]["PD_CONTRACT_FILENAME"].ToString();
                    item.PD_CONTRACT_FILENAME_SYSTEM = dt.Rows[i]["PD_CONTRACT_FILENAME_SYSTEM"].ToString();
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

        public string GetMaxID(string pd_year, string company)
        {
            return this.dal.GetMaxID(pd_year, company);
        }

        public PD_PROJECT_CONTRACT_Model GetModel(string AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_PROJECT_CONTRACT_Model GetModelByCache(string AUTO_NO)
        {
            string cacheKey = "PD_PROJECT_CONTRACTModel-" + AUTO_NO;
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
            return (PD_PROJECT_CONTRACT_Model) cache;
        }

        public List<PD_PROJECT_CONTRACT_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_CONTRACT_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

