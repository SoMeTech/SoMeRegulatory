﻿namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_PROJECT_GKGS_Bll
    {
        private readonly PD_PROJECT_GKGS_DAL dal = new PD_PROJECT_GKGS_DAL();

        public bool Add(PD_PROJECT_GKGS_Model model)
        {
            return this.dal.Add(model);
        }

        public List<PD_PROJECT_GKGS_Model> DataTableToList(DataTable dt)
        {
            List<PD_PROJECT_GKGS_Model> list = new List<PD_PROJECT_GKGS_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_PROJECT_GKGS_Model item = new PD_PROJECT_GKGS_Model();
                    if (dt.Rows[i]["AUTO_NO"].ToString() != "")
                    {
                        item.AUTO_NO = int.Parse(dt.Rows[i]["AUTO_NO"].ToString());
                    }
                    item.PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_TYPE"].ToString() != "")
                    {
                        item.PD_PROJECT_TYPE = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_TYPE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_GS_TYPE"].ToString() != "")
                    {
                        item.PD_GS_TYPE = new int?(int.Parse(dt.Rows[i]["PD_GS_TYPE"].ToString()));
                    }
                    item.PD_GS_STYLE = dt.Rows[i]["PD_GS_STYLE"].ToString();
                    item.PD_GS_ZHUTI = dt.Rows[i]["PD_GS_ZHUTI"].ToString();
                    if (dt.Rows[i]["PD_GS_DATE"].ToString() != "")
                    {
                        item.PD_GS_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_GS_DATE"].ToString()));
                    }
                    item.PD_GS_ADDR = dt.Rows[i]["PD_GS_ADDR"].ToString();
                    item.PD_GS_FILENAME = dt.Rows[i]["PD_GS_FILENAME"].ToString();
                    item.PD_GS_FILENAME_SYSTEM = dt.Rows[i]["PD_GS_FILENAME_SYSTEM"].ToString();
                    item.PD_GS_DETAIL = dt.Rows[i]["PD_GS_DETAIL"].ToString();
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

        public PD_PROJECT_GKGS_Model GetModel(int AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public List<PD_PROJECT_GKGS_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(PD_PROJECT_GKGS_Model model)
        {
            return this.dal.Update(model);
        }
    }
}

