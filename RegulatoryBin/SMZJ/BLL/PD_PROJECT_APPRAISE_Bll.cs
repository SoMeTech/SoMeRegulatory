namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_APPRAISE_Bll
    {
        private readonly PD_PROJECT_APPRAISE_DAL dal = new PD_PROJECT_APPRAISE_DAL();

        public void Add(PD_PROJECT_APPRAISE_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_PROJECT_APPRAISE_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_APPRAISE_Model> list = new List<PD_PROJECT_APPRAISE_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_APPRAISE_Model item = new PD_PROJECT_APPRAISE_Model();
                    if (dt.Rows[i]["AUTO_NO"].ToString() != "")
                    {
                        item.AUTO_NO = int.Parse(dt.Rows[i]["AUTO_NO"].ToString());
                    }
                    item.PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_APP_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_APP_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_APP_DATE"].ToString()));
                    }
                    item.PD_PROJECT_APP_COMPANY = dt.Rows[i]["PD_PROJECT_APP_COMPANY"].ToString();
                    item.PD_PROJECT_APP_COMPANY_LIST = dt.Rows[i]["PD_PROJECT_APP_COMPANY_LIST"].ToString();
                    item.PD_PROJECT_APP_MAN_LIST = dt.Rows[i]["PD_PROJECT_APP_MAN_LIST"].ToString();
                    item.PD_PROJECT_APPRAISE_FILENO = dt.Rows[i]["PD_PROJECT_APPRAISE_FILENO"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(int AUTO_NO)
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

        public bool Exists(int AUTO_NO)
        {
            return this.dal.Exists(AUTO_NO);
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

        public PD_PROJECT_APPRAISE_Model GetModel(int AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public PD_PROJECT_APPRAISE_Model GetModelByProjectCode(string PD_PROJECT_CODE)
        {
            return this.dal.GetModelByProjectCode(PD_PROJECT_CODE);
        }

        public List<PD_PROJECT_APPRAISE_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_APPRAISE_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

