namespace SMZJ.BLL
{
    using Maticsoft.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class TB_PROJECT_BZ_Bll
    {
        private readonly TB_PROJECT_BZ_Dal dal = new TB_PROJECT_BZ_Dal();

        public void Add(TB_PROJECT_BZ_Model model)
        {
            this.dal.Add(model);
        }

        public List<TB_PROJECT_BZ_Model> DataTableToList(DataTable dt)
        {
            List<TB_PROJECT_BZ_Model> list = new List<TB_PROJECT_BZ_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    TB_PROJECT_BZ_Model item = new TB_PROJECT_BZ_Model {
                        PD_PROJECT_FILENO_ZB = dt.Rows[i]["PD_PROJECT_FILENO_ZB"].ToString(),
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString(),
                        PD_PROJECT_NAME = dt.Rows[i]["PD_PROJECT_NAME"].ToString()
                    };
                    if (dt.Rows[i]["PD_YEAR"].ToString() != "")
                    {
                        item.PD_YEAR = new int?(int.Parse(dt.Rows[i]["PD_YEAR"].ToString()));
                    }
                    item.PD_PROJECT_TYPE = dt.Rows[i]["PD_PROJECT_TYPE"].ToString();
                    item.PD_GK_DEPART = dt.Rows[i]["PD_GK_DEPART"].ToString();
                    item.PD_FOUND_XZ = dt.Rows[i]["PD_FOUND_XZ"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_IFGS"].ToString() != "")
                    {
                        item.PD_PROJECT_IFGS = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_IFGS"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_IFGS_BEFORE"].ToString() != "")
                    {
                        item.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_IFGS_BEFORE"].ToString()));
                    }
                    item.PD_PROJECT_OPEN_BODY = dt.Rows[i]["PD_PROJECT_OPEN_BODY"].ToString();
                    item.PD_PROJECT_STATUS = dt.Rows[i]["PD_PROJECT_STATUS"].ToString();
                    item.PD_PROJECT_FILENO_JG = dt.Rows[i]["PD_PROJECT_FILENO_JG"].ToString();
                    item.PD_PROJECT_INPUT_COMPANY = dt.Rows[i]["PD_PROJECT_INPUT_COMPANY"].ToString();
                    item.PD_PROJECT_INPUT_MAN = dt.Rows[i]["PD_PROJECT_INPUT_MAN"].ToString();
                    item.PD_PROJECT_INPUT_DATE = dt.Rows[i]["PD_PROJECT_INPUT_DATE"].ToString();
                    item.PD_PROJECT_BZYJ = dt.Rows[i]["PD_PROJECT_BZYJ"].ToString();
                    item.PD_PROJECT_BZFW = dt.Rows[i]["PD_PROJECT_BZFW"].ToString();
                    item.PD_PROJECT_BZDX = dt.Rows[i]["PD_PROJECT_BZDX"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_BZNUM"].ToString() != "")
                    {
                        item.PD_PROJECT_BZNUM = new decimal?(decimal.Parse(dt.Rows[i]["PD_PROJECT_BZNUM"].ToString()));
                    }
                    item.PD_PROJECT_BZSTAND_NUM = dt.Rows[i]["PD_PROJECT_BZSTAND_NUM"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_BZMONEY"].ToString() != "")
                    {
                        item.PD_PROJECT_BZMONEY = new decimal?(decimal.Parse(dt.Rows[i]["PD_PROJECT_BZMONEY"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_BZFF_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_BZFF_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_BZFF_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_SJFF_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_SJFF_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_SJFF_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_IFFF"].ToString() != "")
                    {
                        item.PD_PROJECT_IFFF = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_IFFF"].ToString()));
                    }
                    item.PD_PROJECT_JGYQ = dt.Rows[i]["PD_PROJECT_JGYQ"].ToString();
                    item.PD_PROJECT_JGJL = dt.Rows[i]["PD_PROJECT_JGJL"].ToString();
                    item.PD_PROJECT_JG_RESULT = dt.Rows[i]["PD_PROJECT_JG_RESULT"].ToString();
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

        public TB_PROJECT_BZ_Model GetModel(string PD_PROJECT_CODE)
        {
            return this.dal.GetModel(PD_PROJECT_CODE);
        }

        public TB_PROJECT_BZ_Model GetModelByCache(string PD_PROJECT_CODE)
        {
            string cacheKey = "TB_PROJECT_BZ_BllModel-" + PD_PROJECT_CODE;
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
            return (TB_PROJECT_BZ_Model) cache;
        }

        public List<TB_PROJECT_BZ_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public TB_PROJECT_BZ_Model GetModelName(string PD_PROJECT_CODE)
        {
            return this.dal.GetModelName(PD_PROJECT_CODE);
        }

        public string InputData(DataSet ds)
        {
            return this.dal.InputData(ds);
        }

        public bool Update(TB_PROJECT_BZ_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

