﻿using ASP;
using SoMeTech.CommonDll;
using SoMeTech.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;
using System.Text;
using SoMeTech.Data;
using SoMeTech.YZXWPageClass;
using QxRoom.QxExcel;

public partial class pro : Page, IRequiresSessionState
{
    protected Button btnquery;
    protected DropDownList ddllb;
    protected DropDownList ddlxz;
    protected SmartGridView gvResult;
    protected HtmlInputHidden hcorp;
    protected tablepage_reprotButtonlTwo reprotButtonl1;
    protected TextBox txtproname;
    protected HtmlInputText txtxz;
    protected HtmlInputText txtxzs;
    protected TextBox txtyear;
    protected HtmlInputHidden upk;
    protected HtmlGenericControl tbHead;
    protected HtmlInputHidden ibtid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            upk.Value = ((UserModel)this.Session["User"]).Company.pk_corp.Trim();
            this.showdata(upk.Value.ToString());
            this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "SubmitDownExcel()");
            this.Button(this.ibtid.Value);
        }

    }
    protected void btnquery_Click(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        if (!(control.GetType().Name.Equals("SmartGridView")))
        {
            base.VerifyRenderingInServerForm(control);
        }
    }
    private void showdata(string str)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("SELECT project_type_code,project_type_name,pd_project_money_total,PD_PROJECT_SYRS,PD_PROJECT_CONTENT FROM ");
        builder.Append("(SELECT a.project_type_code,a.project_type_name,SUM(b.pd_project_money_total) AS pd_project_money_total,sum(b.PD_PROJECT_SYRS) AS PD_PROJECT_SYRS,'' PD_PROJECT_CONTENT from pd_project_type a left join tb_project b on a.project_type_code=b.pd_project_type ");
        builder.Append("WHERE b.pd_found_xz='01' and  b.PD_PROJECT_ISBXK='0' and b.pd_project_input_company='" + str + "' ");
        builder.Append("GROUP BY a.project_type_code,a.project_type_name ");
        builder.Append("union ALL ");
        builder.Append("SELECT distinct b.project_type_code||a.pd_project_code AS  project_type_code,a.pd_project_name,a.pd_project_money_total,a.PD_PROJECT_SYRS,PD_PROJECT_CONTENT  FROM tb_project a,pd_project_type b WHERE a.pd_project_type=b.project_type_code AND a.pd_found_xz='01' ");
        builder.Append(" and a.PD_PROJECT_ISBXK='0' and a.pd_project_input_company='" + str + "'");
        builder.Append(")ORDER BY project_type_code,project_type_name ");
        DataSet ds = DbHelperOra.Query(builder.ToString());
        this.gvResult.DataSource = ds.Tables[0];
        this.gvResult.DataBind();
    }

    private void Button(string p)
    {
        string str = p;
        if (str != null)
        {
            if (!(str == "ShowData"))
            {
                if (!(str == "DownExcel"))
                {
                    return;
                }
            }
            else
            {
                this.showdata("");
                return;
            }
            DataTable source = (DataTable)this.gvResult.DataSource;
            DataSet ds = new DataSet();
            ds.Tables.Add(source);
            base.Response.Clear();
            base.Response.ContentEncoding = Encoding.UTF8;
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + base.Server.UrlEncode(this.tbHead.InnerText) + ".xls");
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BufferOutput = true;
            new DataSetToExcel().ExportToExcel(ds, base.Response.OutputStream);
            base.Response.End();

        }
    }
}
