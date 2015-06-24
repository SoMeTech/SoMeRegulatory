namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class PD_FOUND_OUT_Bll
    {
        private readonly PD_FOUND_OUT_DAL dal = new PD_FOUND_OUT_DAL();

        public void Add(PD_FOUND_OUT_Model model)
        {
            this.dal.Add(model);
        }

        public List<PD_FOUND_OUT_Model> DataTableToList(DataTable dt)
        {
            List<PD_FOUND_OUT_Model> list = new List<PD_FOUND_OUT_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    PD_FOUND_OUT_Model item = new PD_FOUND_OUT_Model();
                    if (dt.Rows[i]["AUTO_NO"].ToString() != "")
                    {
                        item.AUTO_NO = int.Parse(dt.Rows[i]["AUTO_NO"].ToString());
                    }
                    if (dt.Rows[i]["PD_YEAR"].ToString() != "")
                    {
                        item.PD_YEAR = new int?(int.Parse(dt.Rows[i]["PD_YEAR"].ToString()));
                    }
                    if (dt.Rows[i]["PD_FOUND_DATE"].ToString() != "")
                    {
                        item.PD_FOUND_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_FOUND_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_IF_HAVE"].ToString() != "")
                    {
                        item.PD_IF_HAVE = new int?(int.Parse(dt.Rows[i]["PD_IF_HAVE"].ToString()));
                    }
                    item.PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString();
                    item.PD_PROJECT_NAME = dt.Rows[i]["PD_PROJECT_NAME"].ToString();
                    item.PD_CONTRACT_TYPE = dt.Rows[i]["PD_CONTRACT_TYPE"].ToString();
                    item.PD_CONTRACT_COMPANY = dt.Rows[i]["PD_CONTRACT_COMPANY"].ToString();
                    item.PD_FOUND_COMPANY = dt.Rows[i]["PD_FOUND_COMPANY"].ToString();
                    if (dt.Rows[i]["PD_CONTRACT_MONEY"].ToString() != "")
                    {
                        item.PD_CONTRACT_MONEY = new decimal?(int.Parse(dt.Rows[i]["PD_CONTRACT_MONEY"].ToString()));
                    }
                    item.PD_FOUND_SOURCES = dt.Rows[i]["资金来源"].ToString();
                    item.PD_FOUND_TYPE = dt.Rows[i]["PD_FOUND_TYPE"].ToString();
                    item.PD_FOUND_STYLE = dt.Rows[i]["PD_FOUND_STYLE"].ToString();
                    item.PD_FOUND_ACC_TYPE = dt.Rows[i]["PD_FOUND_ACC_TYPE"].ToString();
                    item.PD_FOUND_VOUNO = dt.Rows[i]["PD_FOUND_VOUNO"].ToString();
                    if (dt.Rows[i]["PD_FOUND_MONEY"].ToString() != "")
                    {
                        item.PD_FOUND_MONEY = new decimal?(int.Parse(dt.Rows[i]["PD_FOUND_MONEY"].ToString()));
                    }
                    if (dt.Rows[i]["PD_FOUND_MONEY_TOTAL"].ToString() != "")
                    {
                        item.PD_FOUND_MONEY_TOTAL = new decimal?(int.Parse(dt.Rows[i]["PD_FOUND_MONEY_TOTAL"].ToString()));
                    }
                    item.PD_FOUND_MONEY_WCL = dt.Rows[i]["PD_FOUND_MONEY_WCL"].ToString();
                    item.PD_FOUND_FILENAME = dt.Rows[i]["PD_FOUND_FILENAME"].ToString();
                    item.PD_FOUND_SYS_FILENAME = dt.Rows[i]["PD_FOUND_SYS_FILENAME"].ToString();
                    item.PD_PROJ_STATUS = dt.Rows[i]["PD_PROJ_STATUS"].ToString();
                    item.PD_PROJ_LAST_AUDIT_STATUS = dt.Rows[i]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
                    if (dt.Rows[i]["PD_IS_RETURN"].ToString() != "")
                    {
                        item.PD_IS_RETURN = new int?(int.Parse(dt.Rows[i]["PD_IS_RETURN"].ToString()));
                    }
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

        public bool Exists(long AUTO_NO)
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

        public decimal getLJMoney(string PD_PROJECT_CODE, long AUTO_ID)
        {
            return this.dal.getLJMoney(PD_PROJECT_CODE, AUTO_ID);
        }

        public decimal getLJMoney(string PD_PROJECT_CODE, long AUTO_ID, DateTime? PD_FOUND_DATE)
        {
            return this.dal.getLJMoney(PD_PROJECT_CODE, AUTO_ID, PD_FOUND_DATE);
        }

        public decimal getLJMoney(string PD_CONTRACT_ID, string PD_PROJECD_CODE, long AUTO_ID)
        {
            return this.dal.getLJMoney(PD_CONTRACT_ID, PD_PROJECD_CODE, AUTO_ID);
        }

        public decimal getLJMoney_CZ(string PD_PROJECT_CODE, long AUTO_ID)
        {
            return this.dal.getLJMoney_CZ(PD_PROJECT_CODE, AUTO_ID);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public PD_FOUND_OUT_Model GetModel(long AUTO_NO)
        {
            return this.dal.GetModel(AUTO_NO);
        }

        public List<PD_FOUND_OUT_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public PD_FOUND_OUT_Model GetModelName(long AUTO_NO)
        {
            return this.dal.GetModelName(AUTO_NO);
        }

        public decimal getProjectJSZJE(string PD_PROJECT_CODE)
        {
            return this.dal.getProjectJSZJE(PD_PROJECT_CODE);
        }

        public string OutPut_PingZheng(string auto_no, string databaseName, string kjkm_JF, string kjkm_DF, string fzhs)
        {
            return this.dal.OutPut_PingZheng(auto_no, databaseName, kjkm_JF, kjkm_DF, fzhs);
        }

        public bool Update(PD_FOUND_OUT_Model model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateLJMoney(string PD_PROJECT_CODE)
        {
            return this.dal.UpdateLJMoney(PD_PROJECT_CODE);
        }
    }
}

