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

public class Report_zjffQD : Page, IRequiresSessionState
{
    private string _bianzdw;
    private TableCell _conttd;
    protected SmartGridView gvResult;
    protected tablepage_reprotButtonl reprotButtonl1;

    private void BindSelect()
    {
        this._conttd = new TableCell();
        TextBox child = new TextBox();
        Label label = new Label
        {
            Text = ""
        };
        child.SkinID = "发放单位|TextBox";
        child.Attributes.Add("onfocus", "javascript:findwindow('XiangZhen',this);");
        child.Attributes.Add("readonly", "readonly");
        this._conttd.Controls.Add(label);
        this._conttd.Controls.Add(child);
        child.Visible = false;
        child = new TextBox();
        label = new Label
        {
            Text = "农户代码："
        };
        child.SkinID = "农户代码|TextBox";
        this._conttd.Controls.Add(label);
        this._conttd.Controls.Add(child);
        child = new TextBox();
        label = new Label
        {
            Text = "农户姓名："
        };
        child.SkinID = "农户姓名|TextBox";
        this._conttd.Controls.Add(label);
        this._conttd.Controls.Add(child);
        child = new TextBox();
        label = new Label
        {
            Text = "身份证号码："
        };
        child.SkinID = "身份证号码|TextBox";
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
        for (int i = 0; i < this._conttd.Controls.Count; i++)
        {
            TextBox box;
            DropDownList list;
            TextBox box2;
            string str3;
            Control control = this._conttd.Controls[i];
            string[] source = control.SkinID.Split(new char[] { '|' });
            if ((source.Count<string>() > 1) && ((str3 = source[1]) != null))
            {
                if (!(str3 == "TextBox"))
                {
                    if (str3 == "DropDownList")
                    {
                        goto Label_0100;
                    }
                    if (str3 == "Datetime")
                    {
                        goto Label_0154;
                    }
                }
                else
                {
                    box = (TextBox)control;
                    if (box.Text.Trim() != "")
                    {
                        string str4 = strWhere;
                        strWhere = str4 + " and " + source[0] + " = '" + box.Text.Trim() + "'";
                    }
                }
            }
            continue;
        Label_0100:
            list = (DropDownList)control;
            string str5 = strWhere;
            strWhere = str5 + " and " + source[0] + " = '" + list.SelectedValue + "'";
            continue;
        Label_0154:
            box2 = (TextBox)control;
            string str6 = strWhere;
            strWhere = str6 + " and " + source[0] + " >= to_date('" + box2.Text.Trim() + "','yyyy-mm-dd hh24:mi:ss')";
            i += 2;
            box = (TextBox)this._conttd.Controls[i];
            string str7 = strWhere;
            strWhere = str7 + " and " + source[0] + " <= to_date('" + box2.Text.Trim() + "','yyyy-mm-dd hh24:mi:ss')";
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
        UserModel model1 = (UserModel)this.Session["User"];
        if ((strWhere == null) || (strWhere.Trim() == ""))
        {
            strWhere = " 1=1 ";
        }
        this.Bianzdw = this.Session["companyname"].ToString();
        DataSet list = new ReportPublicBll().GetList(strWhere, "V_PD_BZFFLIST_QUERY");
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
