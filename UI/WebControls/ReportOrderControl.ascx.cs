using ASP;
using System;
using System.Runtime.CompilerServices;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public class ReportOrderControl : UserControl
{
    protected TableRow _controw;
    protected Table _conttable;
    private string _StrSelect = "";
    private string _StrSql = "";
    protected DropDownList DropDownList_xz;
    protected DropDownList DropDownList_zjxz;
    protected TextBox TextBox_wjbh;
    protected TextBox TextBox_wjmc;


    public void band()
    {
    }

    protected void btn_order_Click(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.band();
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public TableRow ContRow
    {
        get
        {
            return this._controw;
        }
        set
        {
            this._controw = value;
        }
    }

    public Table ContTable
    {
        get
        {
            return this._conttable;
        }
        set
        {
            this._conttable = value;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public string StrSelect
    {
        get
        {
            if (this.DropDownList_zjxz.Text.Trim() != "")
            {
                this._StrSelect = " and " + this.DropDownList_zjxz.SkinID + " = '" + this.DropDownList_zjxz.SelectedItem.Value.Trim() + "'";
            }
            if (this.DropDownList_xz.Text.Trim() != "")
            {
                string str = this._StrSelect;
                this._StrSelect = str + " and " + this.DropDownList_xz.SkinID + " = '" + this.DropDownList_xz.SelectedItem.Value.Trim() + "'";
            }
            if (this.TextBox_wjbh.Text.Trim() != "")
            {
                string str2 = this._StrSelect;
                this._StrSelect = str2 + " and " + this.TextBox_wjbh.SkinID + " = '" + this.TextBox_wjbh.Text.Trim() + "'";
            }
            if (this.TextBox_wjmc.Text.Trim() != "")
            {
                string str3 = this._StrSelect;
                this._StrSelect = str3 + " and " + this.TextBox_wjmc.SkinID + " = '" + this.TextBox_wjmc.Text.Trim() + "'";
            }
            return this._StrSelect;
        }
        set
        {
            this._StrSelect = value;
        }
    }

    public string StrSql
    {
        get
        {
            return this._StrSql;
        }
        set
        {
            this._StrSql = value;
        }
    }
}
