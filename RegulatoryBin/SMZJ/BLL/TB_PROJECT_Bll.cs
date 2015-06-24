namespace SMZJ.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SMZJ.DAL;
    using SMZJ.Model;

    public class TB_PROJECT_Bll
    {
        private readonly TB_PROJECT_Dal dal = new TB_PROJECT_Dal();

        public void Add(TB_PROJECT_Model model)
        {
            this.dal.Add(model);
        }

        public void Add(TB_PROJECT_Model model, ref string PD_PROJECT_CODE)
        {
            this.dal.Add(model, ref PD_PROJECT_CODE);
        }

        public List<TB_PROJECT_Model> DataTableToList(DataTable dt)
        {
            List<TB_PROJECT_Model> list = new List<TB_PROJECT_Model>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    TB_PROJECT_Model item = new TB_PROJECT_Model {
                        PD_PROJECT_CODE = dt.Rows[i]["PD_PROJECT_CODE"].ToString(),
                        PD_PROJECT_FILENO_ZB = dt.Rows[i]["PD_PROJECT_FILENO_ZB"].ToString(),
                        PD_PROJECT_NAME = dt.Rows[i]["PD_PROJECT_NAME"].ToString()
                    };
                    if (dt.Rows[i]["PD_YEAR"].ToString() != "")
                    {
                        item.PD_YEAR = new int?(int.Parse(dt.Rows[i]["PD_YEAR"].ToString()));
                    }
                    item.PD_PROJECT_TYPE = dt.Rows[i]["PD_PROJECT_TYPE"].ToString();
                    item.PD_PROJECT_TYPE_NAME = dt.Rows[i]["PD_PROJECT_TYPE_NAME"].ToString();
                    item.PD_GK_DEPART_ID = dt.Rows[i]["PD_GK_DEPART_ID"].ToString();
                    item.PD_GK_DEPART = dt.Rows[i]["PD_GK_DEPART"].ToString();
                    item.PD_FOUND_XZ = dt.Rows[i]["PD_FOUND_XZ"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_MONEY_TOTAL"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_TOTAL = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_TOTAL"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_CZ_TOTAL"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_CZ_TOTAL = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_CZ_TOTAL"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_CZ_SJ"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_CZ_SJ = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_CZ_SJ"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_CZ_BJ"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_CZ_BJ = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_CZ_BJ"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_ZC"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_ZC = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_ZC"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_QT"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_QT = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_QT"].ToString()));
                    }
                    item.PD_PROJECT_MONEY_ADDR = dt.Rows[i]["PD_PROJECT_MONEY_ADDR"].ToString();
                    item.PD_PROJECT_CONTENT = dt.Rows[i]["PD_PROJECT_CONTENT"].ToString();
                    item.PD_PROJECT_XMYT = dt.Rows[i]["PD_PROJECT_XMYT"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_IFXZGL"].ToString() != "")
                    {
                        item.PD_PROJECT_IFXZGL = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_IFXZGL"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_IFGS"].ToString() != "")
                    {
                        item.PD_PROJECT_IFGS = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_IFGS"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_IFGS_BEFORE"].ToString() != "")
                    {
                        item.PD_PROJECT_IFGS_BEFORE = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_IFGS_BEFORE"].ToString()));
                    }
                    item.PD_PROJECT_OPEN_BODY = dt.Rows[i]["PD_PROJECT_OPEN_BODY"].ToString();
                    item.PD_PROJECT_FZR = dt.Rows[i]["PD_PROJECT_FZR"].ToString();
                    item.PD_PROJECT_CWFZR = dt.Rows[i]["PD_PROJECT_CWFZR"].ToString();
                    item.PD_PROJECT_STATUS = dt.Rows[i]["PD_PROJECT_STATUS"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_BEGIN_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_BEGIN_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_BEGIN_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_END_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_END_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_END_DATE"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_YEARS"].ToString() != "")
                    {
                        item.PD_PROJECT_YEARS = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_YEARS"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_CHECK_DATE"].ToString() != "")
                    {
                        item.PD_PROJECT_CHECK_DATE = new DateTime?(DateTime.Parse(dt.Rows[i]["PD_PROJECT_CHECK_DATE"].ToString()));
                    }
                    item.PD_PROJECT_FILENO_LX = dt.Rows[i]["PD_PROJECT_FILENO_LX"].ToString();
                    item.PD_PROJECT_FILENO_JG = dt.Rows[i]["PD_PROJECT_FILENO_JG"].ToString();
                    item.PD_PROJECT_INPUT_COMPANY = dt.Rows[i]["PD_PROJECT_INPUT_COMPANY"].ToString();
                    item.PD_PROJECT_INPUT_MAN = dt.Rows[i]["PD_PROJECT_INPUT_MAN"].ToString();
                    item.PD_PROJECT_INPUT_DATE = dt.Rows[i]["PD_PROJECT_INPUT_DATE"].ToString();
                    item.PD_PROJECT_REPLY_COMPANY = dt.Rows[i]["PD_PROJECT_REPLY_COMPANY"].ToString();
                    item.PD_PROJECT_REPLY_MAN2 = dt.Rows[i]["PD_PROJECT_REPLY_MAN2"].ToString();
                    item.PD_PROJECT_CHECK_COMPANY = dt.Rows[i]["PD_PROJECT_CHECK_COMPANY"].ToString();
                    item.PD_PROJECT_CHENCK_MAN = dt.Rows[i]["PD_PROJECT_CHENCK_MAN"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_MONEY_TOTAL_PF"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_TOTAL_PF = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_TOTAL_PF"].ToString()));
                    }
                    item.PD_PROJECT_REPLY_DATE = dt.Rows[i]["PD_PROJECT_REPLY_DATE"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_MONEY_CZ_TOTAL_PF"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_CZ_TOTAL_PF = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_CZ_TOTAL_PF"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_CZ_SJ_PF"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_CZ_SJ_PF = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_CZ_SJ_PF"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_CZ_BJ_PF"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_CZ_BJ_PF = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_CZ_BJ_PF"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_ZC_PF"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_ZC_PF = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_ZC_PF"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_MONEY_QT_PF"].ToString() != "")
                    {
                        item.PD_PROJECT_MONEY_QT_PF = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_MONEY_QT_PF"].ToString()));
                    }
                    item.PD_PROJECT_COUNTRY = dt.Rows[i]["PD_PROJECT_COUNTRY"].ToString();
                    item.PD_PROJECT_VILLAGE = dt.Rows[i]["PD_PROJECT_VILLAGE"].ToString();
                    item.PD_PROJECT_GROUP = dt.Rows[i]["PD_PROJECT_GROUP"].ToString();
                    item.PD_PROJECT_FILENO_PF = dt.Rows[i]["PD_PROJECT_FILENO_PF"].ToString();
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
                    item.PD_PROJECT_BZYJ = dt.Rows[i]["PD_PROJECT_BZYJ"].ToString();
                    item.PD_PROJECT_BZFW = dt.Rows[i]["PD_PROJECT_BZFW"].ToString();
                    item.PD_PROJECT_BZDX = dt.Rows[i]["PD_PROJECT_BZDX"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_BZNUM"].ToString() != "")
                    {
                        item.PD_PROJECT_BZNUM = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_BZNUM"].ToString()));
                    }
                    item.PD_PROJECT_BZSTAND_NUM = dt.Rows[i]["PD_PROJECT_BZSTAND_NUM"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_BZMONEY"].ToString() != "")
                    {
                        item.PD_PROJECT_BZMONEY = new decimal?(int.Parse(dt.Rows[i]["PD_PROJECT_BZMONEY"].ToString()));
                    }
                    if (dt.Rows[i]["PD_PROJECT_SYRS"].ToString() != "")
                    {
                        item.PD_PROJECT_SYRS = new int?(int.Parse(dt.Rows[i]["PD_PROJECT_SYRS"].ToString()));
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
                    item.PD_PROJECT_JG_SUGGEST = dt.Rows[i]["PD_PROJECT_JG_SUGGEST"].ToString();
                    if (dt.Rows[i]["PD_PROJECT_SYHS"].ToString() != "")
                    {
                        item.PD_PROJECT_SYHS = int.Parse(dt.Rows[i]["PD_PROJECT_SYHS"].ToString());
                    }
                    if (dt.Rows[i]["PD_PROJECT_GNFL"].ToString() != "")
                    {
                        item.PD_PROJECT_GNFL = dt.Rows[i]["PD_PROJECT_GNFL"].ToString();
                    }
                    item.PD_PROJECT_GNFL_CODE = dt.Rows[i]["PD_PROJECT_GNFL_CODE"].ToString();
                    item.PD_PROJECT_CJDW = dt.Rows[i]["PD_PROJECT_CJDW"].ToString();
                    item.PD_PROJECT_JBDH = dt.Rows[i]["PD_PROJECT_JBDH"].ToString();
                    item.PD_PROJECT_SSFW = dt.Rows[i]["PD_PROJECT_SSFW"].ToString();
                    item.Free1 = dt.Rows[i]["Free1"].ToString();
                    item.Free2 = dt.Rows[i]["Free2"].ToString();
                    item.Free3 = dt.Rows[i]["Free3"].ToString();
                    item.Free4 = dt.Rows[i]["Free4"].ToString();
                    item.Free5 = dt.Rows[i]["Free5"].ToString();
                    if (dt.Rows[i]["Free6"].ToString() != "")
                    {
                        item.Free6 = int.Parse(dt.Rows[i]["Free6"].ToString());
                    }
                    if (dt.Rows[i]["Free7"].ToString() != "")
                    {
                        item.Free7 = int.Parse(dt.Rows[i]["Free7"].ToString());
                    }
                    if (dt.Rows[i]["Free8"].ToString() != "")
                    {
                        item.Free8 = decimal.Parse(dt.Rows[i]["Free8"].ToString());
                    }
                    if (dt.Rows[i]["Free9"].ToString() != "")
                    {
                        item.Free9 = decimal.Parse(dt.Rows[i]["Free9"].ToString());
                    }
                    if (dt.Rows[i]["Free10"].ToString() != "")
                    {
                        item.Free10 = decimal.Parse(dt.Rows[i]["Free10"].ToString());
                    }
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

        public TB_PROJECT_Model GetModel(string PD_PROJECT_CODE)
        {
            return this.dal.GetModel(PD_PROJECT_CODE);
        }

        public List<TB_PROJECT_Model> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public TB_PROJECT_Model GetModelName(string PD_PROJECT_CODE)
        {
            return this.dal.GetModelName(PD_PROJECT_CODE);
        }

        public string GetServerPK(string tableName, string IdName, string IdValue, string PD_NOW_SERVERPK_NAME)
        {
            return this.dal.GetServerPK(tableName, IdName, IdValue, PD_NOW_SERVERPK_NAME);
        }

        public bool NameExists(string PD_PROJECT_NAME)
        {
            return this.dal.NameExists(PD_PROJECT_NAME);
        }

        public bool PD_SUB_QuotaMoney(object code, object money, string company, ref decimal okMoney, string pd_project_code)
        {
            return this.dal.PD_SUB_QuotaMoney(code, money, company, ref okMoney, pd_project_code);
        }

        public bool ProjectIsBX(string PD_PROJECT_CODE)
        {
            return this.dal.ProjectIsBX(PD_PROJECT_CODE);
        }

        public bool Update(TB_PROJECT_Model model)
        {
            return this.dal.Update(model);
        }

        public int UpdateJGJL(TB_PROJECT_Model model)
        {
            return this.dal.UpdateJGJL(model);
        }

        public int UpdatePFMoney(string PD_PROJECT_CODE)
        {
            return this.dal.UpdatePFMoney(PD_PROJECT_CODE);
        }

        public bool UpdateServerPK(string tableName, string IdName, string IdValue, string ServerPK, string PD_NOW_SERVERPK_NAME)
        {
            return this.dal.UpdateServerPK(tableName, IdName, IdValue, ServerPK, PD_NOW_SERVERPK_NAME);
        }
    }
}

