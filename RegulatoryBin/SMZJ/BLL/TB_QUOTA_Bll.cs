namespace SMZJ.BLL
{
    using SoMeTech.CommonDll;
    using SoMeTech.User;
    using SoMeTech.YZXWPageClass;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Web;
    using System.Web.UI;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class TB_QUOTA_Bll
    {
        private readonly TB_QUOTA_DAL dal = new TB_QUOTA_DAL();

        public void Add(TB_QUOTA_Model model, string wh)
        {
            this.dal.Add(model, wh);
        }

        public void AddList(List<TB_QUOTA_Model> modelList, string DatabaseName)
        {
            foreach (TB_QUOTA_Model model in modelList)
            {
                this.dal.Add(model, "");
                new SMZJ.BLL.TB_QUOTA_DETAIL().InPutXZXX(model.PD_QUOTA_CODE, model.PD_QUOTA_FWDATA.ToString("yyyyMMdd"), model.PD_QUOTA_ZBWH, DatabaseName);
            }
        }

        public List<TB_QUOTA_Model> DataTableToList(DataTable dt)
        {
            List<TB_QUOTA_Model> list = new List<TB_QUOTA_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    TB_QUOTA_Model item = new TB_QUOTA_Model {
                        AUTO_NO = dt.Rows[i]["AUTO_NO"].ToString(),
                        PD_QUOTA_CODE = dt.Rows[i]["PD_QUOTA_CODE"].ToString(),
                        PD_QUOTA_NAME = dt.Rows[i]["PD_QUOTA_NAME"].ToString(),
                        PD_YEAR = dt.Rows[i]["PD_YEAR"].ToString()
                    };
                    if (dt.Rows[i]["PD_QUOTA_LWJG"].ToString() != "")
                    {
                        item.PD_QUOTA_LWJG = new int?(int.Parse(dt.Rows[i]["PD_QUOTA_LWJG"].ToString()));
                    }
                    item.PD_QUOTA_IFUP = dt.Rows[i]["PD_QUOTA_IFUP"].ToString();
                    item.PD_QUOTA_ZJXZ = dt.Rows[i]["PD_QUOTA_ZJXZ"].ToString();
                    item.PD_QUOTA_TARGET = dt.Rows[i]["PD_QUOTA_TARGET"].ToString();
                    item.PD_QUOTA_STANDARD = dt.Rows[i]["PD_QUOTA_STANDARD"].ToString();
                    item.PD_QUOTA_BASIS = dt.Rows[i]["PD_QUOTA_BASIS"].ToString();
                    item.PD_QUOTA_IFXZQS = dt.Rows[i]["PD_QUOTA_IFXZQS"].ToString();
                    item.PD_QUOTA_IFPASS = dt.Rows[i]["PD_QUOTA_IFPASS"].ToString();
                    item.PD_QUOTA_BASIS_JG = dt.Rows[i]["PD_QUOTA_BASIS_JG"].ToString();
                    item.PD_QUOTA_INPUT_MAN = dt.Rows[i]["PD_QUOTA_INPUT_MAN"].ToString();
                    item.PD_QUOTA_PASS_DATE = dt.Rows[i]["PD_QUOTA_PASS_DATE"].ToString();
                    item.PD_QUOTA_ACCEPT_MAN = dt.Rows[i]["PD_QUOTA_ACCEPT_MAN"].ToString();
                    item.PD_QUOTA_PASS_MAN = dt.Rows[i]["PD_QUOTA_PASS_MAN"].ToString();
                    item.PD_QUOTA_ACCEPT_COMPANY = dt.Rows[i]["PD_QUOTA_ACCEPT_COMPANY"].ToString();
                    item.PD_QUOTA_ACCEPT_DATE = dt.Rows[i]["PD_QUOTA_ACCEPT_DATE"].ToString();
                    if (dt.Rows[i]["PD_QUOTA_IFLLYQS"].ToString() != "")
                    {
                        item.PD_QUOTA_IFLLYQS = dt.Rows[i]["PD_QUOTA_IFLLYQS"].ToString();
                    }
                    item.PD_QUOTA_FILE = dt.Rows[i]["PD_QUOTA_FILE"].ToString();
                    item.PD_QUOTA_XZ_ACCEPT_COMPANY = dt.Rows[i]["PD_QUOTA_XZ_ACCEPT_COMPANY"].ToString();
                    if (dt.Rows[i]["PD_QUOTA_XZ_ACCEPT_DATE"].ToString() != "")
                    {
                        item.PD_QUOTA_XZ_ACCEPT_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_QUOTA_XZ_ACCEPT_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_QUOTA_MONEY_TOTAL"].ToString() != "")
                    {
                        item.PD_QUOTA_MONEY_TOTAL = int.Parse(dt.Rows[i]["PD_QUOTA_MONEY_TOTAL"].ToString());
                    }
                    item.PD_QUOTA_DEPART = dt.Rows[i]["PD_QUOTA_DEPART"].ToString();
                    item.PD_QUOTA_JGYQ = dt.Rows[i]["PD_QUOTA_JGYQ"].ToString();
                    if (dt.Rows[i]["PD_QUOTA_INPUT_DATE"].ToString() != "")
                    {
                        item.PD_QUOTA_INPUT_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_QUOTA_INPUT_DATE"].ToString()));
                    }
                    item.PD_QUOTA_INPUT_COMPANY = dt.Rows[i]["PD_QUOTA_INPUT_COMPANY"].ToString();
                    item.PD_QUOTA_XZ_ACCEPT_MAN = dt.Rows[i]["PD_QUOTA_XZ_ACCEPT_MAN"].ToString();
                    item.PD_PROJ_STATUS = dt.Rows[i]["PD_PROJ_STATUS"].ToString();
                    item.PD_PROJ_LAST_AUDIT_STATUS = dt.Rows[i]["PD_PROJ_LAST_AUDIT_STATUS"].ToString();
                    if (dt.Rows[i]["PD_IS_RETURN"].ToString() != "")
                    {
                        item.PD_IS_RETURN = new int?(int.Parse(dt.Rows[i]["PD_IS_RETURN"].ToString()));
                    }
                    if (dt.Rows[i]["PD_ISOUT_QUOTA"].ToString() != "")
                    {
                        item.PD_ISOUT_QUOTA = new int?(int.Parse(dt.Rows[i]["PD_ISOUT_QUOTA"].ToString()));
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Delete(string PD_QUOTA_CODE)
        {
            return this.dal.Delete(PD_QUOTA_CODE);
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

        public DataSet GetInputData(DateTime startDate, DateTime endDate, string DatabaseName, string sqlTextPath)
        {
            return this.dal.GetInputData(startDate, endDate, DatabaseName, sqlTextPath);
        }

        public DataSet GetInputDropDownList(string CompanyPK)
        {
            return this.dal.GetInputDropDownList(CompanyPK);
        }

        public TB_QUOTA_Model GetIsUpModel(string PD_QUOTA_CODE)
        {
            return this.dal.GetIsUpModel(PD_QUOTA_CODE);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public int? GetMaxPiCi(string PD_QUOTA_NAME)
        {
            return this.dal.GetMaxPiCi(PD_QUOTA_NAME);
        }

        public TB_QUOTA_Model GetModel(string PD_QUOTA_CODE)
        {
            return this.dal.GetModel(PD_QUOTA_CODE);
        }

        public TB_QUOTA_Model GetModelByCODE(string PD_QUOTA_CODE)
        {
            return this.dal.GetModelByCode(PD_QUOTA_CODE);
        }

        public List<TB_QUOTA_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public string getUpDownServerPKName(string path, string serverPK, int operation, out string NewServerPK)
        {
            return this.dal.getUpDownServerPKName(path, serverPK, operation, out NewServerPK);
        }

        public int IsReceive(string pd_quota_code, string company_code)
        {
            return this.dal.IsReceive(pd_quota_code, company_code);
        }

        public int IsXiaFaRight(string str, string serverPK)
        {
            return this.dal.IsXiaFaRight(str, serverPK);
        }

        public static void ListPageLoad(Page page, out ButtonsModel main_bm)
        {
            string userName = ((UserModel) HttpContext.Current.Session["User"]).UserName;
            main_bm = new ButtonsModel(userName);
            main_bm.IfAdd = true;
            main_bm.IfUpdate = true;
            main_bm.IfSave = true;
            main_bm.IfAudit = true;
            main_bm.IfSetBack = true;
            main_bm.IfRollBack = true;
            main_bm.IfExit = true;
            main_bm.IfDo = true;
            main_bm.IbtDoText = "指标下发";
            main_bm.IbtDoUrl = "images/new/process.png";
        }

        public bool pd_IsZBWH(string PD_QUOTA_NAME, string PD_QUOTA_CODE)
        {
            return this.dal.pd_IsZBWH(PD_QUOTA_NAME, PD_QUOTA_CODE);
        }

        public int SaveSetting(string url, string varID, string type)
        {
            return this.dal.SaveSetting(url, varID, type);
        }

        public int SetZbState(string PD_QUOTA_CODE)
        {
            return PublicDal.SetZbState(PD_QUOTA_CODE);
        }

        public object tFileIsShow(string url, string varID)
        {
            return this.dal.tFileIsShow(url, varID);
        }

        public bool Update(TB_QUOTA_Model model)
        {
            return this.dal.Update(model);
        }

        public int UpdateIsXiaFa(string pd_quota_code, string IsXiaFa, string IsQianShou, string IsHuiZhi)
        {
            return this.dal.UpdateIsXiaFa(pd_quota_code, IsXiaFa, IsQianShou, IsHuiZhi);
        }
    }
}

