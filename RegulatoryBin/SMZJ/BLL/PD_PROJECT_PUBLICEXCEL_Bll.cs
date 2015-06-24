namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_PUBLICEXCEL_Bll
    {
        private readonly PD_PROJECT_PUBLICEXCEL_Dal dal = new PD_PROJECT_PUBLICEXCEL_Dal();

        public bool Add(PD_PROJECT_PUBLICEXCEL_Model model)
        {
            return this.dal.Add(model);
        }

        public List<PD_PROJECT_PUBLICEXCEL_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_PUBLICEXCEL_Model> list = new List<PD_PROJECT_PUBLICEXCEL_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_PUBLICEXCEL_Model item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete(decimal AUTO_ID)
        {
            return this.dal.Delete(AUTO_ID);
        }

        public bool DeleteList(string AUTO_IDlist)
        {
            return this.dal.DeleteList(AUTO_IDlist);
        }

        public bool Exists(decimal AUTO_ID)
        {
            return this.dal.Exists(AUTO_ID);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetAllUserTable()
        {
            return this.dal.GetAllUserTable();
        }

        public DataSet GetBranch(string Company)
        {
            return this.dal.GetBranch(Company);
        }

        public DataSet GetDataSet(string tablename, string columnNames)
        {
            return this.dal.GetDataSet(tablename, columnNames);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public PD_PROJECT_PUBLICEXCEL_Model GetModel(decimal AUTO_ID)
        {
            return this.dal.GetModel(AUTO_ID);
        }

        public PD_PROJECT_PUBLICEXCEL_Model GetModelByCache(decimal AUTO_ID)
        {
            string cacheKey = "PD_PROJECT_PUBLICEXCELModel-" + AUTO_ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(AUTO_ID);
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
            return (PD_PROJECT_PUBLICEXCEL_Model) cache;
        }

        public List<PD_PROJECT_PUBLICEXCEL_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public DataSet GetTableColumns(string table_name)
        {
            return this.dal.GetTableColumns(table_name);
        }

        public bool Update(PD_PROJECT_PUBLICEXCEL_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

