namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class TB_QUOTA_DETAIL
    {
        private readonly SMZJ.DAL.TB_QUOTA_DETAIL dal = new SMZJ.DAL.TB_QUOTA_DETAIL();

        public void Add(SMZJ.Model.TB_QUOTA_DETAIL model)
        {
            this.dal.Add(model);
        }

        public void AddList(List<SMZJ.Model.TB_QUOTA_DETAIL> modelList)
        {
            foreach (SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail in modelList)
            {
                this.dal.Add(tb_quota_detail);
            }
        }

        public List<SMZJ.Model.TB_QUOTA_DETAIL> DataTableToList(DataTable dt)
        {
            List<SMZJ.Model.TB_QUOTA_DETAIL> list = new List<SMZJ.Model.TB_QUOTA_DETAIL>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SMZJ.Model.TB_QUOTA_DETAIL item = new SMZJ.Model.TB_QUOTA_DETAIL();
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

        public bool DeleteProject(string PD_QUOTA_CODE)
        {
            return this.dal.DeleteProject(PD_QUOTA_CODE);
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

        public SMZJ.Model.TB_QUOTA_DETAIL GetModel(string PD_QUOTA_CODE)
        {
            return this.dal.GetModel(PD_QUOTA_CODE);
        }

        public List<SMZJ.Model.TB_QUOTA_DETAIL> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public bool GetShiDFouJS_Model(string PD_QUOTA_CODE, int ISRECEIVE)
        {
            return this.dal.GetShiDFouJS_Model(PD_QUOTA_CODE, ISRECEIVE);
        }

        public SMZJ.Model.TB_QUOTA_DETAIL GetSonServerPK_Model(string COMPANY_CODE, string PD_QUOTA_CODE)
        {
            return this.dal.GetSonServerPK_Model(COMPANY_CODE, PD_QUOTA_CODE);
        }

        public void InPutXZXX(string PD_QUOTA_CODE, string PD_QUOTA_FWDATA, string PD_QUOTA_ZBWH, string DatabaseName)
        {
            this.dal.InPutXZXX(PD_QUOTA_CODE, PD_QUOTA_FWDATA, PD_QUOTA_ZBWH, DatabaseName);
        }

        public bool IsHuiZhi(string PD_QUOTA_CODE)
        {
            return this.dal.IsHuiZhi(PD_QUOTA_CODE);
        }

        public bool Update(SMZJ.Model.TB_QUOTA_DETAIL model)
        {
            return this.dal.Update(model);
        }

        public void UpdateIsReceiveList(List<SMZJ.Model.TB_QUOTA_DETAIL> modelList)
        {
            foreach (SMZJ.Model.TB_QUOTA_DETAIL tb_quota_detail in modelList)
            {
                tb_quota_detail.ISRECEIVE = "1";
                this.dal.UpdateIsReceive(tb_quota_detail);
            }
        }

        public bool UpdateSonServerPK(string PD_QUOTA_CODE, string PD_QUOTA_SERVERPK, string ISRECEIVE, string ISHUIZHI, string RECEIVEMAN, string HUIZHIMAN)
        {
            return this.dal.UpdateSonServerPK(PD_QUOTA_CODE, PD_QUOTA_SERVERPK, ISRECEIVE, ISHUIZHI, RECEIVEMAN, HUIZHIMAN);
        }

        public bool UpdateSonServerPK(string PD_QUOTA_CODE, string COMPANY_CODE, string PD_QUOTA_SERVERPK, string ISRECEIVE, string ISHUIZHI, string RECEIVEMAN, string HUIZHIMAN)
        {
            return this.dal.UpdateSonServerPK(PD_QUOTA_CODE, COMPANY_CODE, PD_QUOTA_SERVERPK, ISRECEIVE, ISHUIZHI, RECEIVEMAN, HUIZHIMAN);
        }
    }
}

