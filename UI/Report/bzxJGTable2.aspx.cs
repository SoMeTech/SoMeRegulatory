using ASP;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;

public class Report_JGTable2 : Page, IRequiresSessionState
{
    protected Button Button1;
    protected HtmlForm form1;
    protected HtmlHead Head1;
    protected Label lblxname;
    protected Label lblxz;
    protected HtmlGenericControl printDiv;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label 补贴标准;
    protected Label 补贴范围;
    protected Label 补助对象;
    protected Label 补助人数;
    protected Label 财政所意见;
    protected Label 财政所长签名;
    protected Label 公示;
    protected Label 公示主体;
    protected Label 监管记录;
    protected Label 监管结论;
    protected Label 监管人签名;
    protected Label 监管依据;
    protected Label 监管资金名称;
    protected Label 是否公示;
    protected Label 指标额度;
    protected Label 指标文号;

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ExpertControl(this.printDiv, DocumentType.Word, "补助性资金监管记录表");
    }

    public void ExpertControl(Control source, DocumentType type, string filename)
    {
        if (type == DocumentType.Excel)
        {
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8) + ".xls");
            base.Response.ContentType = "application/ms-excel";
        }
        else if (type == DocumentType.Word)
        {
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8) + ".doc");
            base.Response.ContentType = "application/ms-word";
        }
        base.Response.Charset = "UTF-8";
        base.Response.ContentEncoding = Encoding.UTF8;
        source.Page.EnableViewState = false;
        StringWriter writer = new StringWriter();
        HtmlTextWriter writer2 = new HtmlTextWriter(writer);
        source.RenderControl(writer2);
        base.Response.Write(writer.ToString());
        base.Response.End();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request["UpdatePK"] != null)
        {
            if (!base.IsCallback)
            {
                this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "newSaveWord()");
            }
            if ((this.Session["printID"] != null) && (this.Session["printID"].ToString() != ""))
            {
                this.ShowInfo(base.Request["UpdatePK"].ToString(), this.Session["printID"].ToString());
                this.Session["printID"] = null;
            }
            else
            {
                this.ShowInfo(base.Request["UpdatePK"].ToString());
            }
        }
    }

    private void ShowInfo(string strWhere)
    {
        DataSet list = new ReportPublicBll().GetList("项目编码='" + base.Request["UpdatePK"].ToString() + "'", "V_INSPECTION_BZ2");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["县名"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["建账单位名称"].ToString();
            this.监管资金名称.Text = list.Tables[0].Rows[0]["监管资金名称"].ToString();
            this.监管依据.Text = list.Tables[0].Rows[0]["监管依据"].ToString();
            this.补贴范围.Text = list.Tables[0].Rows[0]["补贴范围"].ToString();
            this.指标文号.Text = list.Tables[0].Rows[0]["指标文号"].ToString();
            this.指标额度.Text = list.Tables[0].Rows[0]["指标额度"].ToString();
            this.补助对象.Text = list.Tables[0].Rows[0]["补助对象"].ToString();
            this.补贴标准.Text = list.Tables[0].Rows[0]["补贴标准"].ToString();
            this.补助人数.Text = list.Tables[0].Rows[0]["补助人数"].ToString();
            this.公示.Text = list.Tables[0].Rows[0]["公示"].ToString();
            this.公示主体.Text = list.Tables[0].Rows[0]["公示主体"].ToString();
            this.是否公示.Text = list.Tables[0].Rows[0]["是否公示"].ToString();
            this.监管记录.Text = list.Tables[0].Rows[0]["监管记录"].ToString();
            this.监管人签名.Text = list.Tables[0].Rows[0]["监管人签名"].ToString();
            this.监管结论.Text = list.Tables[0].Rows[0]["监管结论"].ToString();
            this.财政所意见.Text = list.Tables[0].Rows[0]["财政所意见"].ToString();
            this.财政所长签名.Text = list.Tables[0].Rows[0]["财政所长签名"].ToString();
        }
    }

    private void ShowInfo(string strWhere, string pd_project_auto_no)
    {
        DataSet list = new ReportPublicBll().GetList("项目编码='" + base.Request["UpdatePK"].ToString() + "' and  auto_no='" + pd_project_auto_no + "' ", "V_INSPECTION_BZ3");
        if ((list.Tables.Count > 0) && (list.Tables[0].Rows.Count > 0))
        {
            this.lblxname.Text = list.Tables[0].Rows[0]["县名"].ToString();
            this.lblxz.Text = list.Tables[0].Rows[0]["建账单位名称"].ToString();
            this.监管资金名称.Text = list.Tables[0].Rows[0]["监管资金名称"].ToString();
            this.监管依据.Text = list.Tables[0].Rows[0]["监管依据"].ToString();
            this.补贴范围.Text = list.Tables[0].Rows[0]["补贴范围"].ToString();
            this.指标文号.Text = list.Tables[0].Rows[0]["指标文号"].ToString();
            this.指标额度.Text = list.Tables[0].Rows[0]["指标额度"].ToString();
            this.补助对象.Text = list.Tables[0].Rows[0]["补助对象"].ToString();
            this.补贴标准.Text = list.Tables[0].Rows[0]["补贴标准"].ToString();
            this.补助人数.Text = list.Tables[0].Rows[0]["补助人数"].ToString();
            this.公示.Text = list.Tables[0].Rows[0]["公示"].ToString();
            this.公示主体.Text = list.Tables[0].Rows[0]["公示主体"].ToString();
            this.是否公示.Text = list.Tables[0].Rows[0]["是否公示"].ToString();
            this.监管记录.Text = list.Tables[0].Rows[0]["监管记录"].ToString();
            this.监管人签名.Text = list.Tables[0].Rows[0]["监管人签名"].ToString();
            this.监管结论.Text = list.Tables[0].Rows[0]["监管结论"].ToString();
            this.财政所意见.Text = list.Tables[0].Rows[0]["财政所意见"].ToString();
            this.财政所长签名.Text = list.Tables[0].Rows[0]["财政所长签名"].ToString();
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

    public enum DocumentType
    {
        Word,
        Excel
    }
}
