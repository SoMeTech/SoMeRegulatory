using ASP;
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


public partial class bt : Page, IRequiresSessionState
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

            }
            else
            {
                this.Button(this.ibtid.Value);
                this.ibtid.Value = "";
            }
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
            builder.Append("select a.project_type_code,a.project_type_name,SUM(b.PD_PROJECT_BZNUM) PD_PROJECT_BZNUM, SUM(b.pd_project_bzmoney) pd_project_bzmoney  from pd_project_type a left join tb_project b on a.project_type_code=b.pd_project_type  WHERE b.pd_found_xz='02' ");
            builder.Append(" and b.pd_project_input_company='" + str + "' AND b.pd_year='2015' GROUP BY a.project_type_code,a.project_type_name ");
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
