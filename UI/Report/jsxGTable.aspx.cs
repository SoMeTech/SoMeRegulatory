using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;

public class Report_jsxGTable : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label lblxname;
    protected Label lblxz;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label 本级自筹资金;
    protected Label 财政所意见;
    protected Label 抽查巡查次数;
    protected Label 公示情况;
    protected Label 计划开工日期;
    protected Label 计划完工日期;
    protected Label 监管依据;
    protected Label 监管资金名称;
    protected Label 建账单位名称;
    protected Label 建账日期;
    protected Label 经办人;
    protected Label 其他来源资金;
    protected Label 上级财政资金;
    protected Label 项目负责人;
    protected Label 项目概况;
    protected Label 项目建设地点及内容;
    protected Label 项目决算金额;
    protected Label 项目投资概况;
    protected Label 项目完工日期;
    protected Label 项目预算金额;
    protected Label 项目责任人;
    protected Label 政策要求;
    protected Label 指标额度;
    protected Label 指标文号;
    protected Label 资金拨付情况;
    protected Label 资金类别;
    protected Label 资金使用单位;
    protected Label 资金用途;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsCallback)
        {
            this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "tbSaveExcel('项目建设资金监管记录表','table1',window)");
        }
        this.ShowInfo(base.Request["code"], base.Request["pd_found_xz"]);
    }

    private void ShowInfo(string code, string pd_found_xz)
    {
        DataSet list = new ReportPublicBll().GetList("项目编码='" + base.Request["UpdatePK"].ToString() + "'", "view_tb_project_jgljb_xm");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["县名"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["资金使用单位"].ToString();
            this.建账单位名称.Text = list.Tables[0].Rows[0]["建账单位名称"].ToString();
            this.建账日期.Text = list.Tables[0].Rows[0]["建账日期"].ToString();
            this.经办人.Text = list.Tables[0].Rows[0]["经办人"].ToString();
            this.指标文号.Text = list.Tables[0].Rows[0]["指标文号"].ToString();
            this.监管资金名称.Text = list.Tables[0].Rows[0]["监管资金名称"].ToString();
            this.资金用途.Text = list.Tables[0].Rows[0]["资金用途"].ToString();
            this.项目建设地点及内容.Text = list.Tables[0].Rows[0]["项目建设地点及内容"].ToString();
            this.监管依据.Text = list.Tables[0].Rows[0]["监管依据"].ToString();
            this.资金类别.Text = list.Tables[0].Rows[0]["资金类别"].ToString();
            this.指标额度.Text = list.Tables[0].Rows[0]["指标额度"].ToString();
            this.政策要求.Text = list.Tables[0].Rows[0]["政策要求"].ToString();
            this.资金使用单位.Text = list.Tables[0].Rows[0]["资金使用单位"].ToString();
            this.计划开工日期.Text = list.Tables[0].Rows[0]["计划开工日期"].ToString();
            this.计划完工日期.Text = list.Tables[0].Rows[0]["计划完工日期"].ToString();
            this.项目责任人.Text = list.Tables[0].Rows[0]["项目责任人"].ToString();
            this.项目负责人.Text = list.Tables[0].Rows[0]["项目负责人"].ToString();
            this.项目预算金额.Text = list.Tables[0].Rows[0]["项目预算金额"].ToString();
            this.项目决算金额.Text = list.Tables[0].Rows[0]["项目决算金额"].ToString();
            this.项目投资概况.Text = list.Tables[0].Rows[0]["项目投资概况"].ToString();
            this.上级财政资金.Text = list.Tables[0].Rows[0]["上级财政资金"].ToString();
            this.本级自筹资金.Text = list.Tables[0].Rows[0]["本级自筹资金"].ToString();
            this.其他来源资金.Text = list.Tables[0].Rows[0]["其他来源资金"].ToString();
            this.资金拨付情况.Text = list.Tables[0].Rows[0]["资金拨付情况"].ToString();
            this.项目完工日期.Text = list.Tables[0].Rows[0]["项目完工日期"].ToString();
            this.公示情况.Text = list.Tables[0].Rows[0]["公示情况"].ToString();
            this.抽查巡查次数.Text = list.Tables[0].Rows[0]["抽查巡查次数"].ToString();
            this.项目概况.Text = list.Tables[0].Rows[0]["项目概况"].ToString();
            this.财政所意见.Text = list.Tables[0].Rows[0]["财政所意见"].ToString();
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
