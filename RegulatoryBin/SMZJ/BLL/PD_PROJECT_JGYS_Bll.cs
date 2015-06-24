namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_JGYS_Bll
    {
        private readonly PD_PROJECT_JGYS_DAL dal = new PD_PROJECT_JGYS_DAL();

        public void Add(PD_PROJECT_JGYS_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_PROJECT_JGYS_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_JGYS_Model> list = new List<PD_PROJECT_JGYS_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_JGYS_Model item = new PD_PROJECT_JGYS_Model();
                    if (dt.Rows[i]["AUTO_NO"].ToString() != "")
                    {
                        item.AUTO_NO = int.Parse(dt.Rows[i]["AUTO_NO"].ToString());
                    }
                    item.PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_COMPLETE_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_COMPLETE_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_COMPLETE_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_YSSQ_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_YSSQ_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_YSSQ_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_YS_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_YS_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_YS_DATE"].ToString()));
                    }
                    item.PD_PROJECT_YS_COMPANY = dt.Rows[i]["PD_PROJECT_YS_COMPANY"].ToString();
                    item.PD_PROJECT_YS_ZRR = dt.Rows[i]["PD_PROJECT_YS_ZRR"].ToString();
                    item.PD_PROJECT_YS_NAME = dt.Rows[i]["PD_PROJECT_YS_NAME"].ToString();
                    item.PD_PROJECT_YS_SUGGEST = dt.Rows[i]["PD_PROJECT_YS_SUGGEST"].ToString();
                    item.PD_PROJECT_YS_RESULT = dt.Rows[i]["PD_PROJECT_YS_RESULT"].ToString();
                    item.PD_PROJECT_YS_CONDITION = dt.Rows[i]["PD_PROJECT_YS_CONDITION"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            return this.dal.Delete(PD_PROJECT_CODE);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            return this.dal.DeleteList(AUTO_NOlist);
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

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public PD_PROJECT_JGYS_Model GetModel(string PD_PROJECT_CODE)
        {
            return this.dal.GetModel(PD_PROJECT_CODE);
        }

        public PD_PROJECT_JGYS_Model GetModelByProCode(string projectCode)
        {
            return this.dal.GetModelByProCode(projectCode);
        }

        public List<PD_PROJECT_JGYS_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_JGYS_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

