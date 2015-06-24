namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class GOV_TC_DB_COMPANYDATADZ_Bll
    {
        private readonly GOV_TC_DB_COMPANYDATADZ_Dal dal = new GOV_TC_DB_COMPANYDATADZ_Dal();

        public bool Add(GOV_TC_DB_COMPANYDATADZ_Model model)
        {
            return this.dal.Add(model);
        }

        public List<GOV_TC_DB_COMPANYDATADZ_Model> DataTableToList(DataTable dt)
        {
            List<GOV_TC_DB_COMPANYDATADZ_Model> list = new List<GOV_TC_DB_COMPANYDATADZ_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    GOV_TC_DB_COMPANYDATADZ_Model item = new GOV_TC_DB_COMPANYDATADZ_Model();
                    if (dt.Rows[i]["PK"].ToString() != "")
                    {
                        item.PK = int.Parse(dt.Rows[i]["PK"].ToString());
                    }
                    item.DATANAME = dt.Rows[i]["DATANAME"].ToString();
                    item.TABLENAME = dt.Rows[i]["TABLENAME"].ToString();
                    item.COLUMNNAME = dt.Rows[i]["COLUMNNAME"].ToString();
                    item.COMPANYBH = dt.Rows[i]["COMPANYBH"].ToString();
                    item.SHOWNAME = dt.Rows[i]["SHOWNAME"].ToString();
                    item.IP = dt.Rows[i]["IP"].ToString();
                    item.USERID = dt.Rows[i]["USERID"].ToString();
                    item.PWD = dt.Rows[i]["PWD"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(long PK)
        {
            return this.dal.Delete(PK);
        }

        public bool DeleteList(string PKlist)
        {
            return this.dal.DeleteList(PKlist);
        }

        public bool Exists(int PK)
        {
            return this.dal.Exists(PK);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GOV_TC_DB_COMPANYDATADZ_Model GetModel(long PK)
        {
            return this.dal.GetModel(PK);
        }

        public GOV_TC_DB_COMPANYDATADZ_Model GetModelByCache(long PK)
        {
            string cacheKey = "GOV_TC_DB_COMPANYDATADZModel-" + PK;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(PK);
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
            return (GOV_TC_DB_COMPANYDATADZ_Model) cache;
        }

        public List<GOV_TC_DB_COMPANYDATADZ_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public DataSet GetSQLDataName()
        {
            return this.dal.GetSQLDataName();
        }

        public bool Update(GOV_TC_DB_COMPANYDATADZ_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

