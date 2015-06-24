namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_ATTACH_YS_Bll
    {
        private readonly PD_PROJECT_ATTACH_YS_DAL dal = new PD_PROJECT_ATTACH_YS_DAL();

        public void Add(PD_PROJECT_ATTACH_YS_Model model)
        {
            this.dal.Add(model);
        }

        public void AddList(List<PD_PROJECT_ATTACH_YS_Model> modelList)
        {
            foreach (PD_PROJECT_ATTACH_YS_Model model in modelList)
            {
                this.dal.Add(model);
            }
        }

        public List<PD_PROJECT_ATTACH_YS_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_ATTACH_YS_Model> list = new List<PD_PROJECT_ATTACH_YS_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_ATTACH_YS_Model item = new PD_PROJECT_ATTACH_YS_Model();
                    if (dt.Rows[i]["AUTO_NO"].ToString() != "")
                    {
                        item.AUTO_NO = int.Parse(dt.Rows[i]["AUTO_NO"].ToString());
                    }
                    item.PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString();
                    item.PD_PROJECT_ATTACH_TYPE = dt.Rows[i]["PD_PROJECT_ATTACH_TYPE"].ToString();
                    item.PD_PROJECT_ATTACH_NAME = dt.Rows[i]["PD_PROJECT_ATTACH_NAME"].ToString();
                    item.PD_PROJECT_ATTACH_NAME_SYSTEM = dt.Rows[i]["PD_PROJECT_ATTACH_NAME_SYSTEM"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(int AUTO_NO)
        {
            return this.dal.Delete(AUTO_NO);
        }

        public bool Delete(string PD_PROJECT_CODE)
        {
            return this.dal.Delete(PD_PROJECT_CODE);
        }

        public bool DeleteList(string AUTO_NOlist)
        {
            return this.dal.DeleteList(AUTO_NOlist);
        }

        public bool Exists(int AUTO_NO)
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

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public PD_PROJECT_ATTACH_YS_Model GetModel(int AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public List<PD_PROJECT_ATTACH_YS_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_ATTACH_YS_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

