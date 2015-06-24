using ASP;
using ExtExtenders;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SMZJ.BLL;
using SMZJ.Model;

public partial class Work_ZB_fileup : Page, IRequiresSessionState
{
    protected HtmlForm form1;
    protected GridView GridView1;
    protected HtmlHead Head1;
    protected ScriptManager ScriptManager1;
    protected TabContainer TabContainer1;
    protected TabPanel TabPanel1;

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SMZJ.Model.MYFILETEST model = new SMZJ.Model.MYFILETEST();
        FileUpload upload = (FileUpload)this.GridView1.Rows[e.RowIndex].FindControl("商品小图上传");
        if (upload.HasFile)
        {
            string str = DateTime.Now.Date.ToString("yyyyMMdd");
            string str2 = DateTime.Now.ToShortTimeString().Replace(":", "");
            string str3 = str + str2 + DateTime.Now.Millisecond.ToString();
            string fileName = upload.FileName;
            upload.PostedFile.ContentLength.ToString();
            string str5 = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
            string filename = base.Server.MapPath("上传图片/小图/") + str3 + "." + str5;
            upload.SaveAs(filename);
            TextBox box = (TextBox)this.GridView1.Rows[e.RowIndex].FindControl("商品编号填写");
            model.商品名称 = fileName;
            model.商品小图地址 = filename;
            model.商品编号 = new int?(int.Parse(box.Text.Trim()));
            new SMZJ.BLL.MYFILETEST().Add(model);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            SMZJ.BLL.MYFILETEST myfiletest = new SMZJ.BLL.MYFILETEST();
            DataTable table = myfiletest.GetAllList().Tables[0];
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();
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
