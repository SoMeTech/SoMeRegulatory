using ASP;
using SoMeTech.User;
using System;
using System.Data;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;

public class Report_zjjgGSCT : Page, IRequiresSessionState
{
    private string _bianzdw;
    private TableCell _conttd;
    protected SmartGridView gvResult;
    protected tablepage_reprotButtonl reprotButtonl1;

    private void BindSelect()
    {
        this._conttd = new TableCell();
        TextBox child = new TextBox();
        Label label = new Label();
        child = new TextBox();
        label = new Label
        {
            Text = "资金性质："
        };
        child.SkinID = "资金性质|TextBox";
        this._conttd.Controls.Add(label);
        this._conttd.Controls.Add(child);
        child = new TextBox();
        label = new Label
        {
            Text = "文件字号："
        };
        child.SkinID = "文件字号|TextBox";
        this._conttd.Controls.Add(label);
        this._conttd.Controls.Add(child);
        child = new TextBox();
        label = new Label
        {
            Text = "文件名称："
        };
        child.SkinID = "文件名称|TextBox";
        this._conttd.Controls.Add(label);
        this._conttd.Controls.Add(child);
        Button button = new Button
        {
            Text = "查 询"
        };
        button.Click += new EventHandler(this.btn_order_Click);
        this._conttd.Controls.Add(button);
        this.Master.ContRow.Cells.Add(this._conttd);
    }

    protected void btn_order_Click(object sender, EventArgs e)
    {
        string strWhere = " 1=1 ";
        foreach (Control control in this._conttd.Controls)
        {
            DropDownList list;
            string str3;
            string[] source = control.SkinID.Split(new char[] { '|' });
            if ((source.Count<string>() > 1) && ((str3 = source[1]) != null))
            {
                if (!(str3 == "TextBox"))
                {
                    if (str3 == "DropDownList")
                    {
                        goto Label_00F0;
                    }
                }
                else
                {
                    TextBox box = (TextBox)control;
                    if (box.Text.Trim() != "")
                    {
                        string str4 = strWhere;
                        strWhere = str4 + " and " + source[0] + " like '%" + box.Text.Trim() + "%' and PD_QUOTA_IFPASS=1";
                    }
                }
            }
            continue;
        Label_00F0:
            list = (DropDownList)control;
            string str5 = strWhere;
            strWhere = str5 + " and " + source[0] + " like '%" + list.SelectedValue + "%' PD_QUOTA_IFPASS=1";
        }
        this.Master.StrSelect = strWhere;
        this.ShowInfo(strWhere);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.ShowInfo(null);
        }
        this.BindSelect();
    }

    private void ShowInfo(string strWhere)
    {
        if ((strWhere == null) || (strWhere.Trim() == ""))
        {
            strWhere = " 1=1 and PD_QUOTA_IFPASS=1";
        }
        UserModel model1 = (UserModel)this.Session["User"];
        DataSet list = new ReportPublicBll().GetList(strWhere, "tb_quota");
        if (list.Tables[0].Rows.Count == 0)
        {
            list.Tables[0].Rows.Add(list.Tables[0].NewRow());
        }
        this.gvResult.DataSource = list.Tables[0];
        this.gvResult.DataBind();
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public string Bianzdw
    {
        get
        {
            return this._bianzdw;
        }
        set
        {
            this._bianzdw = value;
        }
    }

    public MainReport Master
    {
        get
        {
            return (MainReport)base.Master;
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
