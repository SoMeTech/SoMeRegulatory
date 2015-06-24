using ASP;
using Commons.Collections;
using SoMeTech.Data;
using SoMeTech.User;
using NVelocity;
using NVelocity.App;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using SMZJ.BLL;
using SMZJ.Model;

public partial class Work_ZB_ZPRINT : Page, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["User"] != null)
        {
            UserModel model = (UserModel)this.Session["User"];
            string isHasBaby = model.Company.IsHasBaby;
            string isJGBM = model.Branch.IsJGBM;
            VelocityEngine engine = new VelocityEngine();
            ExtendedProperties p = new ExtendedProperties();
            p.AddProperty("file.resource.loader.path", base.Server.MapPath("Templete"));
            p.SetProperty("input.encoding", "utf-8");
            p.SetProperty("output.encoding", "utf-8");
            engine.Init(p);
            Template template = engine.GetTemplate("0.vm", "utf-8");
            DataTable table = null;
            string str3 = "0";
            string str4 = "";
            string sQLString = "";
            string str6 = "";
            if (base.Request.Params["yl"] != null)
            {
                string str7 = base.Server.UrlDecode(base.Request.Params["pk"]).Replace("'", "");
                str6 = DbHelperOra.GetSingle("select t.systemusername from DB_CONFIGURATION t").ToString();
                TB_QUOTA_Model model2 = new TB_QUOTA_Bll().GetModel(base.Request.Params["pk"]);
                if (base.Request.Params["yl"] == "1")
                {
                    sQLString = "select * from v_mes_gs where pd_quota_code in (" + str7 + ")";
                    if (model2.PD_QUOTA_IFPASS != "1")
                    {
                        str4 = "此指标没有传递，不能打印“业务股室告知乡财”告知书";
                    }
                    else
                    {
                        template = engine.GetTemplate("1.vm", "utf-8");
                    }
                }
                else if (base.Request.Params["yl"] == "2")
                {
                    sQLString = "select * from v_mes_gs_2 where pd_quota_code in (" + str7 + ")";
                    string str8 = ((UserModel)this.Session["User"]).Company.pk_corp;
                    if (str8.Trim() != model2.PD_QUOTA_INPUT_COMPANY.Trim())
                    {
                        sQLString = sQLString + " and COMPANY_CODE='" + str8 + "'";
                    }
                    if (model2.PD_QUOTA_ISUP != "1")
                    {
                        str4 = "此指标没有下发，不能打印“乡财告知乡镇”告知书";
                    }
                    else
                    {
                        template = engine.GetTemplate("2.vm", "utf-8");
                    }
                }
                else if (base.Request.Params["yl"] == "3")
                {
                    string name = "3.vm";
                    if (DbHelperOra.Exists("select count(*) from tb_quota where  pd_quota_code in (" + str7 + ") and PD_QUOTA_ZJXZ='01'"))
                    {
                        sQLString = "select * from v_mes_gs_4 where pd_quota_code in (" + str7 + ")";
                        name = "4.vm";
                    }
                    else
                    {
                        sQLString = "select * from v_mes_gs_3 where pd_quota_code in (" + str7 + ")";
                    }
                    SMZJ.BLL.TB_QUOTA_DETAIL tb_quota_detail = new SMZJ.BLL.TB_QUOTA_DETAIL();
                    string strWhere = " PD_QUOTA_CODE='" + base.Request.Params["pk"] + "' and IF_SHOW=1 ";
                    string str11 = ((UserModel)this.Session["User"]).Company.pk_corp;
                    if (str11.Trim() != model2.PD_QUOTA_INPUT_COMPANY.Trim())
                    {
                        strWhere = strWhere + " and COMPANY_CODE='" + str11 + "'";
                        sQLString = sQLString + " and COMPANY_CODE='" + str11 + "'";
                    }
                    DataSet list = tb_quota_detail.GetList(strWhere);
                    if ((list.Tables[0].Rows[0]["ishuizhi"].ToString().Trim() != "是") && (list.Tables[0].Rows[0]["ishuizhi"].ToString().Trim() != "1"))
                    {
                        str4 = "此指标没有回执，不能打印“乡镇回执乡财”告知书";
                    }
                    else
                    {
                        template = engine.GetTemplate(name, "utf-8");
                    }
                }
                else
                {
                    str4 = "内部错误，请重新登录";
                }
                if (str4 == "")
                {
                    table = DbHelperOra.Query(sQLString).Tables[0];
                    str3 = "1";
                }
            }
            VelocityContext context = new VelocityContext();
            context.Put("XiangZhen", str6);
            context.Put("xzs", table);
            context.Put("isnew", str3);
            context.Put("isHasBaby", isHasBaby.Trim());
            context.Put("IsJGBM", isJGBM.Trim());
            context.Put("DataPK", base.Request.Params["pk"]);
            context.Put("PrintTxt", str4);
            context.Put("rc", ((table == null) || (table.Rows.Count == 0)) ? "0" : table.Rows.Count.ToString());
            template.Merge(context, base.Response.Output);
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
