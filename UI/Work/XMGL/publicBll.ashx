<%@ WebHandler Language="C#" Class="publicBll" %>

using System;
using System.Web;
using SoMeTech.CommonDll;

public class publicBll : IHttpHandler, System.Web.SessionState.IReadOnlySessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string printText = "";
        string loop = context.Request["loop"];
        SMZJ.BLL.TB_PROJECT_Bll bll = new SMZJ.BLL.TB_PROJECT_Bll();
        switch (loop)
        {
            case "xmsb":
                string name = context.Request["name"];
                string value = context.Request["value"];
                if (name.ToLower().IndexOf("txtpd_project_code") > -1)
                {
                    if (bll.Exists(value))
                        printText = "项目代码已存在";
                }
                else
                {
                    if (bll.NameExists(value))
                        printText = "项目名称已存在";
                }
                break;
            case "project_type":
                string year = context.Request["year"];
                string pd_found_xz = context.Request["pd_found_xz"];
                printText = PublicDal.DataToJSON(
                    PublicDal.GetPDBaseValues("PD_BASE_ProjectType", "PROJECTTYPE_CODE code,ProjectType_Name name", "projecttype_year=" + year
                    + " and zjxz_type='" + pd_found_xz + "'")
                );
                break;
            case "OutputZJBF":
                string company = context.Request["company"];
                SMZJ.BLL.TB_QUOTA_Bll bll2 = new SMZJ.BLL.TB_QUOTA_Bll();
                printText = PublicDal.DataToJSON(
                   bll2.GetInputDropDownList(company)
                );
                break;
            case "Welcome":
                string CDname = "";
                string url = context.Server.HtmlDecode(context.Request["url"]);
                string userid = context.Server.HtmlDecode(context.Request["userid"]);
                SoMeTech.User.UserModel usermodel = new SoMeTech.User.UserDal();
                printText = usermodel.WelcomePower(url, userid, ref CDname) + "|" + CDname;
                break;
            case "pd_IsZBWH":
                string zbwh = context.Server.HtmlDecode(context.Request["zbwh"]);
                string pd_quota_code = context.Server.HtmlDecode(context.Request["code"]);
                SMZJ.BLL.TB_QUOTA_Bll pd_IsZBWH_Bll = new SMZJ.BLL.TB_QUOTA_Bll();
                if (pd_IsZBWH_Bll.pd_IsZBWH(zbwh, pd_quota_code))
                    printText = "true";
                else
                    printText = "false";
                break;
            case "SubSb_Quota":
                string quota = context.Request["quota"];
                string pd_project_code = context.Request["pd_project_code"];
                System.Data.DataSet ds = PublicDal.JsonToDataSet(quota);
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    decimal OkMoney = 0M;
                    if (!bll.PD_SUB_QuotaMoney(dr["code"], dr["money"], ((SoMeTech.User.UserModel)context.Session["User"]).Company.pk_corp, ref OkMoney, pd_project_code))
                    {
                        printText = "[{ref:0,money:" + OkMoney + ",code:" + dr["code"] + "}]";
                        break;
                    }
                }

                if (printText == "")
                    printText = "[{ref:1}]";
                break;
            case "zjbf_pdmoney":
                string bcMoney = context.Request["bcMoney"];
                string bcCzMoney = context.Request["bcCzMoney"];
                string pj_code = context.Request["pj_code"];
                string contract = context.Request["contract"];
                string bfid = context.Request["bfid"];
                SMZJ.BLL.PD_FOUND_OUT_Bll OUT_Bll = new SMZJ.BLL.PD_FOUND_OUT_Bll();
                long id = -1;
                if (PublicDal.PageValidate.IsNumber(bfid))
                    id = long.Parse(bfid);
                
                {
                    decimal ProjectFoundLJ = OUT_Bll.getLJMoney(pj_code, id);
                    decimal cztzze = OUT_Bll.getProjectJSZJE(pj_code);
                    if (PublicDal.PageValidate.IsDecimal(bcMoney))
                    {
                        if (ProjectFoundLJ + decimal.Parse(bcMoney) > cztzze)
                            printText = "【本次拨付金额】超过项目剩余结算总金额(剩余" + (cztzze - ProjectFoundLJ) + " 元)！请修改";
                    }
                }

                printText = "[{ref:'" + printText + "'}]";
                break;
            case "FileType":
                printText = PublicDal.DataToJSON(
                    PublicDal.GetPDBaseValues("PD_BASE_FILE_TYPE", "type_code id,type_name name", "")
                );
                break;
        }
        context.Response.Write(printText);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}