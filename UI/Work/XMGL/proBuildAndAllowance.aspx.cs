using ASP;
using SoMeTech.Data;
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

public partial class Work_projectGL_proBuildAndAllowance : Page, IRequiresSessionState
{
    protected Button Button1;
    protected Label FK_money1;
    protected Label FK_money2;
    protected Label FK_money3;
    protected Label FK_money4;
    protected HtmlForm form1;
    protected Label GKDate1;
    protected Label GKDate2;
    protected Label GKDate3;
    protected Label GKDate4;
    protected Label GS_DATE1;
    protected Label GS_DATE2;
    protected Label GS_DATE3;
    protected Label GS_DATE4;
    protected Label lblxname;
    protected Label lblxz;
    protected HtmlGenericControl printDiv;
    protected Label project_name;
    protected Label project_type;
    protected Label PZ_no1;
    protected Label PZ_no2;
    protected Label PZ_no3;
    protected Label PZ_no4;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected Label tilte_name;
    protected Label UP_COMPANY1;
    protected Label UP_COMPANY2;
    protected Label UP_COMPANY3;
    protected Label UP_COMPANY4;
    protected Label UP_DATE1;
    protected Label UP_DATE2;
    protected Label UP_DATE3;
    protected Label UP_DATE4;
    protected Label YS_company1;
    protected Label YS_company2;
    protected Label YS_company3;
    protected Label YS_company4;
    protected Label YS_Date1;
    protected Label YS_Date2;
    protected Label YS_Date3;
    protected Label YS_Date4;
    protected Label ZBWH1;
    protected Label ZBWH2;
    protected Label ZBWH3;
    protected Label ZBWH4;
    protected Label ZJED1;
    protected Label ZJED2;
    protected Label ZJED3;
    protected Label ZJED4;

    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = "";
        if (base.Request["titlename"].ToString() == "1")
        {
            filename = "项目类财政资金监管台帐";
        }
        else if (base.Request["titlename"].ToString() == "2")
        {
            filename = "补助类财政资金监管台帐";
        }
        this.ExpertControl(this.printDiv, DocumentType.Word, filename);
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
        if (!base.IsCallback)
        {
            this.reprotButtonl1.DaochuBt.Attributes.Add("onclick", "newSaveWord()");
        }
        if ((!base.IsPostBack && (base.Request["UpdatePK"] != null)) && (base.Request["titlename"] != null))
        {
            this.ShowInfo(base.Request["UpdatePK"].ToString(), base.Request["titlename"].ToString());
        }
    }

    private void ShowInfo(string project_code, string project_type)
    {
        if (project_type.Trim() == "1")
        {
            this.tilte_name.Text = "项目类";
        }
        else if (project_type.Trim() == "2")
        {
            this.tilte_name.Text = "补助类";
        }
        string str = "";
        try
        {
            DataSet set = DbHelperOra.Query("select distinct t.pd_project_code, t.pd_project_name,pt.project_type_name,(select  systemusername from DB_CONFIGURATION where rownum=1) as Xname ,cp.name,t.pd_project_fileno_zb\r\n                                from tb_project t\r\n                                left join pd_project_type pt on t.PD_PROJECT_TYPE=pt.project_type_code\r\n                                left join db_company cp on cp.pk_corp=t.PD_PROJECT_INPUT_COMPANY\r\n                                where t.pd_project_code=" + project_code);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                DataTable table = set.Tables[0];
                this.lblxname.Text = table.Rows[0]["Xname"].ToString();
                this.lblxz.Text = table.Rows[0]["name"].ToString();
                this.project_name.Text = table.Rows[0]["pd_project_name"].ToString();
                this.project_type.Text = table.Rows[0]["project_type_name"].ToString();
                str = table.Rows[0]["pd_project_fileno_zb"].ToString();
            }
            string sQLString = "";
            if (project_type.Trim() == "1")
            {
                sQLString = " select t.PD_QUOTA_ZBWH,pt.pd_project_money_cz_sj as money,t.PD_QUOTA_UP_DATE,dc.name\r\n                                     from tb_quota t \r\n                                    left join PD_PROJECT_TZJGC pt on pt.TB_QUOTA_CODE=t.pd_quota_code\r\n                                    left join db_company dc on dc.pk_corp=t.PD_QUOTA_UP_COMPANY\r\n                                    where pt.pd_project_code=" + project_code;
            }
            else
            {
                sQLString = "select t.pd_quota_zbwh,t.pd_quota_zbxdzh as money,t.PD_QUOTA_UP_DATE,dc.name\r\n                                 from tb_quota t \r\n                                 left join db_company dc on dc.pk_corp=t.PD_QUOTA_UP_COMPANY\r\n                                 where t.pd_quota_code=" + str;
            }
            DataSet set2 = DbHelperOra.Query(sQLString);
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                DataTable table2 = set2.Tables[0];
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    string id = "UP_DATE" + ((i + 1)).ToString();
                    Label label = (Label)this.FindControl(id);
                    label.Text = Convert.ToDateTime(table2.Rows[i]["PD_QUOTA_UP_DATE"]).ToString("yyyy-MM-dd");
                    string str5 = "UP_COMPANY" + ((i + 1)).ToString();
                    Label label2 = (Label)this.FindControl(str5);
                    label2.Text = table2.Rows[i]["name"].ToString();
                    string str6 = "ZBWH" + ((i + 1)).ToString();
                    Label label3 = (Label)this.FindControl(str6);
                    label3.Text = table2.Rows[i]["PD_QUOTA_ZBWH"].ToString();
                    string str7 = "ZJED" + ((i + 1)).ToString();
                    Label label4 = (Label)this.FindControl(str7);
                    label4.Text = table2.Rows[i]["money"].ToString();
                }
            }
            DataSet set3 = DbHelperOra.Query("select pd_gs_date from pd_project_gkgs where pd_project_code=" + project_code);
            if ((set3 != null) && (set3.Tables[0].Rows.Count > 0))
            {
                DataTable table3 = set3.Tables[0];
                for (int j = 0; j < table3.Rows.Count; j++)
                {
                    string str9 = "GKDate" + ((j + 1)).ToString();
                    Label label5 = (Label)this.FindControl(str9);
                    label5.Text = Convert.ToDateTime(table3.Rows[j]["pd_gs_date"]).ToString("yyyy-MM-dd");
                }
            }
            DataSet set4 = DbHelperOra.Query("select t.PD_FOUND_DATE,t.PD_FOUND_MONEY,t.PD_FOUND_VOUNO from PD_FOUND_OUT t where t.pd_project_code=" + project_code);
            if ((set4 != null) && (set4.Tables[0].Rows.Count > 0))
            {
                DataTable table4 = set4.Tables[0];
                for (int k = 0; k < table4.Rows.Count; k++)
                {
                    string str11 = "GS_DATE" + ((k + 1)).ToString();
                    Label label6 = (Label)this.FindControl(str11);
                    label6.Text = Convert.ToDateTime(table4.Rows[k]["PD_FOUND_DATE"]).ToString("yyyy-MM-dd");
                    string str12 = "FK_money" + ((k + 1)).ToString();
                    Label label7 = (Label)this.FindControl(str12);
                    label7.Text = table4.Rows[k]["PD_FOUND_MONEY"].ToString();
                    string str13 = "PZ_no" + ((k + 1)).ToString();
                    Label label8 = (Label)this.FindControl(str13);
                    label8.Text = table4.Rows[k]["PD_FOUND_VOUNO"].ToString();
                }
            }
        }
        catch (Exception)
        {
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
