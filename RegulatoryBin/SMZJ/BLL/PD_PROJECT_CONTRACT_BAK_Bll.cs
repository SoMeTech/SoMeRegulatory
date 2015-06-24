namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_CONTRACT_BAK_Bll
    {
        private readonly PD_PROJECT_CONTRACT_BAK_Dal dal = new PD_PROJECT_CONTRACT_BAK_Dal();

        public bool Add(PD_PROJECT_CONTRACT_BAK_Model model)
        {
            return this.dal.Add(model);
        }

        public List<PD_PROJECT_CONTRACT_BAK_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_CONTRACT_BAK_Model> list = new List<PD_PROJECT_CONTRACT_BAK_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_CONTRACT_BAK_Model item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete(decimal ID)
        {
            return this.dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(decimal ID)
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

        public decimal? GetMaxID(string PD_CONTRACT_NO)
        {
            return this.dal.GetMaxID(PD_CONTRACT_NO);
        }

        public PD_PROJECT_CONTRACT_BAK_Model GetModel(decimal ID)
        {
            return this.dal.GetModel(ID);
        }

        public PD_PROJECT_CONTRACT_BAK_Model GetModelByCache(decimal ID)
        {
            string cacheKey = "PD_PROJECT_CONTRACT_BAKModel-" + ID;
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
            return (PD_PROJECT_CONTRACT_BAK_Model) cache;
        }

        public List<PD_PROJECT_CONTRACT_BAK_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool GetPd_Contract_Moeny_Total(string PD_PROJECT_CODE, string PD_CONTRACT_MOENY, string Contract_Code)
        {
            return this.dal.GetPd_Contract_Moeny_Total(PD_PROJECT_CODE, PD_CONTRACT_MOENY, Contract_Code);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(PD_PROJECT_CONTRACT_BAK_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

