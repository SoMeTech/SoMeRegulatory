namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_LOG_Bll
    {
        private readonly PD_PROJECT_LOG_Dal dal = new PD_PROJECT_LOG_Dal();

        public void Add(PD_PROJECT_LOG_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_PROJECT_LOG_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_LOG_Model> list = new List<PD_PROJECT_LOG_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_LOG_Model item = new PD_PROJECT_LOG_Model {
                        AUTOID = dt.Rows[i]["AUTOID"].ToString(),
                        PD_PROJECT_TYPE = dt.Rows[i]["PD_PROJECT_TYPE"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString(),
                        MAN = dt.Rows[i]["MAN"].ToString(),
                        COMPANY = dt.Rows[i]["COMPANY"].ToString(),
                        BM = dt.Rows[i]["BM"].ToString(),
                        EXE_DTIME = dt.Rows[i]["EXE_DTIME"].ToString(),
                        EXE_CZ = dt.Rows[i]["EXE_CZ"].ToString(),
                        EXE_JG = dt.Rows[i]["EXE_JG"].ToString(),
                        EXE_TXT = dt.Rows[i]["EXE_TXT"].ToString(),
                        FREE1 = dt.Rows[i]["FREE1"].ToString(),
                        FREE2 = dt.Rows[i]["FREE2"].ToString(),
                        FREE3 = dt.Rows[i]["FREE3"].ToString()
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

        public DataSet GetList(string strWhere, string code)
        {
            return this.dal.GetList(strWhere, code);
        }

        public PD_PROJECT_LOG_Model GetModel(string PD_PROJECT_CODE)
        {
            return this.dal.GetModel(PD_PROJECT_CODE);
        }

        public PD_PROJECT_LOG_Model GetModelByCache(string PD_PROJECT_CODE)
        {
            string cacheKey = "PD_PROJECT_LOG_BllModel-" + PD_PROJECT_CODE;
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
            return (PD_PROJECT_LOG_Model) cache;
        }

        public List<PD_PROJECT_LOG_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_LOG_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

