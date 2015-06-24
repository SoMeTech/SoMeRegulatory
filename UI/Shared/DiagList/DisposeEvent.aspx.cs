using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Shared_DiagList_DisposeEvent : Page, IRequiresSessionState
{
    private ifExist exist = new ifExist();
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            switch (base.Request.QueryString["Event"])
            {
                case "CheckName":
                    if (this.exist.checkService("Name='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckBH":
                    if (this.exist.checkService("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckPowerCode":
                    if (this.exist.checkService("PowerCode='" + base.Server.UrlDecode(base.Request.QueryString["PowerCode"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckRegisterBH":
                    if (this.exist.checkServiceRegister("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckRegisterName":
                    if (this.exist.checkServiceRegister("Name='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckMessBH":
                    if (this.exist.checkServiceMess("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckMessName":
                    if (this.exist.checkServiceMess("Name='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckMessPowerCode":
                    if (this.exist.checkServiceMess("PowerCode='" + base.Server.UrlDecode(base.Request.QueryString["PowerCode"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "CheckMenuPowerCode":
                    if (this.exist.checkMenu("PowerCode='" + base.Server.UrlDecode(base.Request.QueryString["PowerCode"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkUsualBookTable":
                    if (this.exist.checkUsualBookTable("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'", base.Request["tableName"].ToString()))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;
             

                case "checkServiceTypeName":
                    if (this.exist.checkServiceType("Name='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

               

                case "checkEmployeeBH":
                    if (this.exist.checkEmployee("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkBranchBH":
                    if (this.exist.checkBranch("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkRoleBH":
                    if (this.exist.checkRole("BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkCompanyBH":
                    if (this.exist.checkCompany("pk_corp='" + base.Server.UrlDecode(base.Request.QueryString["pk_corp"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkCompanyName":
                    if (this.exist.checkCompany("Name='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkUserName":
                    if (this.exist.checkUser("UserName='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkBuildBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_DB_BuildingCompany where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkBuildCompanyName":
                    if (this.exist.checkIsRepeat("select NAME from GOV_TC_DB_BuildingCompany where BH='" + base.Server.UrlDecode(base.Request.QueryString["Name"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

               
                

                case "checkSoilBH":
                    if (this.exist.checkIsRepeat("select SoilNum from GOV_TC_DB_SoilDocument where SoilNum='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkSoilSubNum":
                    if (this.exist.checkIsRepeat("select SoilSubNum from GOV_TC_DB_SoilDocument where SoilSubNum='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkSoilGetBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_MAIN_SOILREQUISITION where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkSoilOutBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_MAIN_SOILREMISE where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkSoilAssignmentBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_Main_SoilAssignment where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkPlanBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_MAIN_PLANNING where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkBuildAllowBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_MAIN_BUILDALLOW where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkBuildFinishBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_Main_BuildFinish where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkHouseNewBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_Main_House_New where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;

                case "checkHouseSecondHandBH":
                    if (this.exist.checkIsRepeat("select BH from GOV_TC_Main_House_SecondHand where BH='" + base.Server.UrlDecode(base.Request.QueryString["BH"]) + "'"))
                    {
                        base.Response.Write("true");
                        break;
                    }
                    base.Response.Write("false");
                    break;
            }
            base.Response.End();
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }
}
