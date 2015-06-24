using ASP;
using SoMeTech.User;
using System;
using System.Data;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;
using SMZJ.BLL;

public class Report_zbxxJSHZ : Page, IRequiresSessionState
{
    private TableCell _conttd;
    protected Button btnQuery;
    protected DropDownList ddlxz;
    protected SmartGridView gvResult;
    protected tablepage_reprotButtonl reprotButtonl1;
    protected HtmlInputText txtcids;
    protected HtmlInputText txtdepart;
    protected HtmlInputText txtname;
    protected HtmlInputText txtwh;
    protected HtmlInputText txtxz;
    protected HtmlInputText txtxzs;
    protected TextBox txtyear;

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
                        strWhere = str4 + " and " + source[0] + " = '" + box.Text.Trim() + "'";
                    }
                }
            }
            continue;
        Label_00F0:
            list = (DropDownList)control;
            string str5 = strWhere;
            strWhere = str5 + " and " + source[0] + " = '" + list.SelectedValue + "'";
        }
        this.Master.StrSelect = strWhere;
        this.ShowInfo(strWhere);
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string strWhere = " 1=1 ";
        if (this.ddlxz.SelectedValue != "0")
        {
            strWhere = strWhere + " and trim(资金性质)='" + this.ddlxz.SelectedValue + "'";
        }
        if (this.txtwh.Value.Trim() != "")
        {
            strWhere = strWhere + " and trim(pd_quota_zbwh) like '%" + this.txtwh.Value + "%'";
        }
        if (this.txtname.Value != "")
        {
            strWhere = strWhere + " and trim(文件名称) like '%" + this.txtname.Value + "%'";
        }
        if (this.txtyear.Text != "")
        {
            strWhere = strWhere + " and trim(pd_year) like '%" + this.txtyear.Text + "%'";
        }
        if (this.txtdepart.Value != "")
        {
            strWhere = strWhere + " and trim(pd_quota_depart)  in('" + this.txtcids.Value.Replace(",", "','") + "')";
        }
        if (this.txtxz.Value.Trim() != "")
        {
            strWhere = strWhere + " and trim(PD_QUOTA_INPUT_COMPANY)  in('" + this.txtxzs.Value.Replace(",", "','") + "')";
        }
        this.ShowInfo(strWhere);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.ShowInfo(null);
        }
    }

    private void ShowInfo(string strWhere)
    {
        if ((strWhere == null) || (strWhere.Trim() == ""))
        {
            strWhere = " 1=1 ";
        }
        UserModel model1 = (UserModel)this.Session["User"];
        DataSet list = new ReportPublicBll().GetList(strWhere, "v_quota_accept");
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
