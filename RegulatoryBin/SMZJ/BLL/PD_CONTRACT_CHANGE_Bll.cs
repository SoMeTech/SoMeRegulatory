namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_CONTRACT_CHANGE_Bll
    {
        private readonly PD_CONTRACT_CHANGE_Dal dal = new PD_CONTRACT_CHANGE_Dal();

        public void Add(PD_CONTRACT_CHANGE_Model model)
        {
            this.dal.Add(model);
        }

        public void AddList(List<PD_CONTRACT_CHANGE_Model> modelList)
        {
            foreach (PD_CONTRACT_CHANGE_Model model in modelList)
            {
                this.dal.Add(model);
            }
        }

        public List<PD_CONTRACT_CHANGE_Model> DataTableToList(DataTable dt)
        {
            List<PD_CONTRACT_CHANGE_Model> list = new List<PD_CONTRACT_CHANGE_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_CONTRACT_CHANGE_Model item = new PD_CONTRACT_CHANGE_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString()
                    };
                    if (dt.Rows[i]["PD_CONTRACT_CHANGE_DATE"].ToString() != "")
                    {
                        item.PD_CONTRACT_CHANGE_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_CONTRACT_CHANGE_DATE"].ToString()));
                    }
                    item.PD_CONTRACT_CHANGE_TYPE = dt.Rows[i]["PD_CONTRACT_CHANGE_TYPE"].ToString();
                    item.PD_CONTRACT_CHANGE_REASON = dt.Rows[i]["PD_CONTRACT_CHANGE_REASON"].ToString();
                    item.PD_CONTRACT_TYPE = dt.Rows[i]["PD_CONTRACT_TYPE"].ToString();
                    item.PD_CONTRACT_NO = dt.Rows[i]["PD_CONTRACT_NO"].ToString();
                    if (dt.Rows[i]["PD_CONTRACT_MONEY"].ToString() != "")
                    {
                        item.PD_CONTRACT_MONEY = new decimal?(int.Parse(dt.Rows[i]["PD_CONTRACT_MONEY"].ToString()));
                    }
                    item.PD_CONTRACT_CHANGE_ZJ = dt.Rows[i]["PD_CONTRACT_CHANGE_ZJ"].ToString();
                    if (dt.Rows[i]["PD_CONTRACT_CHANGE_MONEY"].ToString() != "")
                    {
                        item.PD_CONTRACT_CHANGE_MONEY = new decimal?(int.Parse(dt.Rows[i]["PD_CONTRACT_CHANGE_MONEY"].ToString()));
                    }
                    item.PD_CONTRACT_CHANGE_FILENAME_SQ = dt.Rows[i]["PD_CONTRACT_CHANGE_FILENAME_SQ"].ToString();
                    item.PD_CONTRACT_FILENAME_SYSTEM_SQ = dt.Rows[i]["PD_CONTRACT_FILENAME_SYSTEM_SQ"].ToString();
                    item.PD_CONTRACT_FILENO_PF = dt.Rows[i]["PD_CONTRACT_FILENO_PF"].ToString();
                    item.PD_CONTRACT_FILENAME_PF = dt.Rows[i]["PD_CONTRACT_FILENAME_PF"].ToString();
                    item.PD_CONTRACT_FILENAME_SYS_PF = dt.Rows[i]["PD_CONTRACT_FILENAME_SYS_PF"].ToString();
                    if (dt.Rows[i]["PD_CONTRACT_PICI"].ToString() != "")
                    {
                        item.PD_CONTRACT_PICI = new int?(int.Parse(dt.Rows[i]["PD_CONTRACT_PICI"].ToString()));
                    }
                    if (dt.Rows[i]["PD_CONTRACT_STATE"].ToString() != "")
                    {
                        item.PD_CONTRACT_STATE = new int?(int.Parse(dt.Rows[i]["PD_CONTRACT_STATE"].ToString()));
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(long AUTO_NO)
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

        public PD_CONTRACT_CHANGE_Model GetModel(int AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_CONTRACT_CHANGE_Model GetModelByCache(int AUTO_NO)
        {
            string cacheKey = "PD_CONTRACT_CHANGEModel-" + AUTO_NO;
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
            return (PD_CONTRACT_CHANGE_Model) cache;
        }

        public List<PD_CONTRACT_CHANGE_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_CONTRACT_CHANGE_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

