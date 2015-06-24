namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_KAOPING_Bll
    {
        private readonly PD_PROJECT_KAOPING_DAL dal = new PD_PROJECT_KAOPING_DAL();

        public void Add(PD_PROJECT_KAOPING_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_PROJECT_KAOPING_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_KAOPING_Model> list = new List<PD_PROJECT_KAOPING_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_KAOPING_Model item = new PD_PROJECT_KAOPING_Model();
                    if (dt.Rows[i]["AUTO_ID"].ToString() != "")
                    {
                        item.AUTO_ID = new int?(int.Parse(dt.Rows[i]["AUTO_ID"].ToString()));
                    }
                    if (dt.Rows[i]["KP_TYPEID"].ToString() != "")
                    {
                        item.KP_TYPEID = new int?(int.Parse(dt.Rows[i]["KP_TYPEID"].ToString()));
                    }
                    if (dt.Rows[i]["KP_DETAILID"].ToString() != "")
                    {
                        item.KP_DETAILID = new int?(int.Parse(dt.Rows[i]["KP_DETAILID"].ToString()));
                    }
                    item.KP_YEAR = dt.Rows[i]["KP_YEAR"].ToString();
                    item.KP_COMPANYPK = dt.Rows[i]["KP_COMPANYPK"].ToString();
                    item.KH_TYPE = dt.Rows[i]["KH_TYPE"].ToString();
                    if (dt.Rows[i]["KP_SCORE"].ToString() != "")
                    {
                        item.KP_SCORE = new int?(int.Parse(dt.Rows[i]["KP_SCORE"].ToString()));
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(int AUTO_ID)
        {
            return this.dal.Delete(AUTO_ID);
        }

        public bool DeleteList(string AUTO_IDlist)
        {
            return this.dal.DeleteList(AUTO_IDlist);
        }

        public bool Exists(int AUTO_ID)
        {
            return this.dal.Exists(AUTO_ID);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public PD_PROJECT_KAOPING_Model GetModel(int AUTO_ID)
        {
            return this.dal.GetModel(AUTO_ID);
        }

        public List<PD_PROJECT_KAOPING_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_KAOPING_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

