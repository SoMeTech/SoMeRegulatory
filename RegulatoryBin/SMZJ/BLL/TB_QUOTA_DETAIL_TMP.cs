namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class TB_QUOTA_DETAIL_TMP
    {
        private readonly SMZJ.DAL.TB_QUOTA_DETAIL_TMP dal = new SMZJ.DAL.TB_QUOTA_DETAIL_TMP();

        public void Add(SMZJ.Model.TB_QUOTA_DETAIL_TMP model)
        {
            this.dal.Add(model);
        }

        public List<SMZJ.Model.TB_QUOTA_DETAIL_TMP> DataTableToList(DataTable dt)
        {
            List<SMZJ.Model.TB_QUOTA_DETAIL_TMP> list = new List<SMZJ.Model.TB_QUOTA_DETAIL_TMP>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SMZJ.Model.TB_QUOTA_DETAIL_TMP item = new SMZJ.Model.TB_QUOTA_DETAIL_TMP();
                    if (dt.Rows[i]["AUTO_NO"].ToString() != "")
                    {
                        item.AUTO_NO = int.Parse(dt.Rows[i]["AUTO_NO"].ToString());
                    }
                    item.PD_QUOTA_CODE = dt.Rows[i]["PD_QUOTA_CODE"].ToString();
                    item.COMPANY_NAME = dt.Rows[i]["COMPANY_NAME"].ToString();
                    item.FILE_NAME = dt.Rows[i]["FILE_NAME"].ToString();
                    item.FILE_SYSNAME = dt.Rows[i]["FILE_SYSNAME"].ToString();
                    item.COMPANY_CODE = dt.Rows[i]["COMPANY_CODE"].ToString();
                    item.FILE_TYPE = dt.Rows[i]["FILE_TYPE"].ToString();
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

        public SMZJ.Model.TB_QUOTA_DETAIL_TMP GetModel(int AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public List<SMZJ.Model.TB_QUOTA_DETAIL_TMP> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool Update(SMZJ.Model.TB_QUOTA_DETAIL_TMP model)
        {
            return this.dal.Update(model);
        }
    }
}

