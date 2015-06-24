using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;

public class Report_JGTable : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label lblxname;
    protected Label lblxz;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label 补贴范围;
    protected Label 补助人数;
    protected Label 财政所意见;
    protected Label 抽查巡查次数;
    protected Label 公示情况;
    protected Label 公示主体;
    protected Label 监管概况;
    protected Label 监管依据;
    protected Label 监管资金名称;
    protected Label 建账单位名称;
    protected Label 建账日期;
    protected Label 经办人;
    protected Label 政策要求;
    protected Label 指标额度;
    protected Label 指标文号;
    protected Label 资金类别;
    protected Label 资金用途;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["UpdatePK"] != null)
        {
            if (!base.IsCallback)
            {
                this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "tbSaveExcel('补助性资金监管记录表','table1',window)");
            }
            this.ShowInfo("");
        }
    }

    private void ShowInfo(string strWhere)
    {
        DataSet list = new ReportPublicBll().GetList("项目编码='" + base.Request["UpdatePK"].ToString() + "'", "V_INSPECTION_BZ");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["县名"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["建账单位名称"].ToString();
            this.建账单位名称.Text = list.Tables[0].Rows[0]["建账单位名称"].ToString();
            this.建账日期.Text = list.Tables[0].Rows[0]["建账日期"].ToString();
            this.经办人.Text = list.Tables[0].Rows[0]["经办人"].ToString();
            this.指标文号.Text = list.Tables[0].Rows[0]["指标文号"].ToString();
            this.监管资金名称.Text = list.Tables[0].Rows[0]["监管资金名称"].ToString();
            this.资金用途.Text = list.Tables[0].Rows[0]["资金用途"].ToString();
            this.补贴范围.Text = list.Tables[0].Rows[0]["补贴范围"].ToString();
            this.监管依据.Text = list.Tables[0].Rows[0]["监管依据"].ToString();
            this.资金类别.Text = list.Tables[0].Rows[0]["资金类别"].ToString();
            this.指标额度.Text = list.Tables[0].Rows[0]["指标额度"].ToString();
            this.政策要求.Text = list.Tables[0].Rows[0]["政策要求"].ToString();
            this.补助人数.Text = list.Tables[0].Rows[0]["补助人数"].ToString();
            this.公示主体.Text = list.Tables[0].Rows[0]["公示主体"].ToString();
            this.抽查巡查次数.Text = list.Tables[0].Rows[0]["抽查巡查次数"].ToString();
            this.监管概况.Text = list.Tables[0].Rows[0]["监管概况"].ToString();
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
