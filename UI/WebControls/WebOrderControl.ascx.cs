using ASP;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebOrderControl : UserControl
{
    private DataSet _DataSetClo;
    private DataSet _DataSetTable;
    private string _StrClomun = "";
    private string _StrCloname = "";
    private string _StrSelect = "";
    private string _StrSql = "";
    private string _TableName = "";
    protected Button btn_order;
    protected Button btnlike;
    protected Button btnOutPut;
    protected DropDownList DropDownList1;
    protected TextBox TextBox1;

    public event PageChangeHandler OnPageChange;

    public void band()
    {
        if ((this._DataSetTable != null) && (this._DataSetClo != null))
        {
            for (int i = 0; i < this._DataSetTable.Tables[0].Columns.Count; i++)
            {
                this.DropDownList1.Items.Add(new ListItem(this._DataSetTable.Tables[0].Columns[i].ToString(), this._DataSetClo.Tables[0].Columns[i].ToString()));
            }
        }
    }

    protected void btn_order_Click(object sender, EventArgs e)
    {
        base.Session["SearchButtonClick"] = SearchControlButtonClickType.Search;
        string str = "";
        if (this.TextBox1.Text.Trim() != "")
        {
            str = this.DropDownList1.SelectedItem.Value + " = '" + this.TextBox1.Text.Trim() + "'";
        }
        this._StrSelect = str;
        this.OnPageChange(sender, this._StrSelect, this._StrCloname, this._StrSql, this._DataSetTable, this._DataSetClo);
    }

    protected void btnlike_Click(object sender, EventArgs e)
    {
        base.Session["SearchButtonClick"] = SearchControlButtonClickType.Like;
        string str = "";
        if (this.TextBox1.Text.Trim() != "")
        {
            str = this.DropDownList1.SelectedValue.ToString() + " like '%" + this.TextBox1.Text.Trim() + "%'";
        }
        this._StrSelect = str;
        this.OnPageChange(sender, this._StrSelect, this._StrCloname, this._StrSql, this._DataSetTable, this._DataSetClo);
    }

    public void OutPutExcelGridViewID(string ClientID)
    {
        this.btnOutPut.Attributes.Add("out-tb-id", ClientID);
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

    public Button BtnOutPut
    {
        get
        {
            return this.btnOutPut;
        }
        set
        {
            this.btnOutPut = value;
        }
    }

    public DataSet DataSetClo
    {
        get
        {
            return this._DataSetClo;
        }
        set
        {
            this._DataSetClo = value;
        }
    }

    public DataSet DataSetTable
    {
        get
        {
            return this._DataSetTable;
        }
        set
        {
            this._DataSetTable = value;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public string SelectText
    {
        get
        {
            return this.DropDownList1.SelectedItem.Text;
        }
        set
        {
            this.DropDownList1.SelectedItem.Text = value;
        }
    }

    public string SelectValue
    {
        get
        {
            return this.DropDownList1.SelectedItem.Value;
        }
        set
        {
            this.DropDownList1.SelectedItem.Value = value;
        }
    }

    public string StrClomun
    {
        get
        {
            return this._StrClomun;
        }
        set
        {
            this._StrClomun = value;
        }
    }

    public string StrCloname
    {
        get
        {
            return this._StrCloname;
        }
        set
        {
            this._StrCloname = value;
        }
    }

    public string StrSelect
    {
        get
        {
            if ((this.TextBox1.Text.Trim() != "") && (base.Session["SearchButtonClick"] != null))
            {
                switch (((SearchControlButtonClickType)base.Session["SearchButtonClick"]))
                {
                    case SearchControlButtonClickType.Search:
                        this._StrSelect = this.DropDownList1.SelectedItem.Value + " = '" + this.TextBox1.Text.Trim() + "'";
                        break;

                    case SearchControlButtonClickType.Like:
                        this._StrSelect = this.DropDownList1.SelectedValue.ToString() + " like '%" + this.TextBox1.Text.Trim() + "%'";
                        break;
                }
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

    public string TableName
    {
        get
        {
            return this._TableName;
        }
        set
        {
            this._TableName = value;
        }
    }

    public string TextValue
    {
        get
        {
            return this.TextBox1.Text;
        }
        set
        {
            this.TextBox1.Text = value;
        }
    }
}
