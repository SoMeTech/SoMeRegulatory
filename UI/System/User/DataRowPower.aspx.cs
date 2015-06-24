using ASP;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class User_DataRowPower : Page, IRequiresSessionState
{
    protected Button btDo;
    private DB_OPT dbo;
    protected DropDownList ddlColumnName;
    protected DropDownList ddldatemax;
    protected DropDownList ddldatemin;
    protected DropDownList ddlDateTime;
    protected DropDownList ddlDateType;
    protected DropDownList ddlintppqk;
    protected DropDownList ddlstrppqk;
    protected DropDownList ddlstrself;
    protected DropDownList ddltablename;
    protected HtmlGenericControl divdatetime;
    protected HtmlGenericControl divdatetime1;
    protected HtmlGenericControl divdatetime2;
    protected HtmlGenericControl divint;
    protected HtmlGenericControl divint1;
    protected HtmlGenericControl divint2;
    protected HtmlGenericControl divstr1;
    protected HtmlGenericControl divstr2;
    private DataRowPowerModel drpm;
    protected HtmlForm form1;
    protected HtmlInputText ifadd;
    protected HtmlInputText pk;
    protected HtmlInputText tn;
    protected TextBox txtdatetime;
    protected TextBox txtDiscription;
    protected TextBox txtint;
    protected TextBox txtintmax;
    protected TextBox txtintmin;
    protected TextBox txtname;
    protected TextBox txtpowercode;
    protected TextBox txtstring;
    protected TextBox txtstring1;

    protected void btDo_Click(object sender, EventArgs e)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.drpm = new DataRowPowerDal();
            this.drpm.Name = this.txtname.Text.Trim();
            this.drpm.PowerCode = this.txtpowercode.Text.Trim();
            this.drpm.TableName = this.ddltablename.SelectedValue;
            this.drpm.ColumnName = this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0];
            this.drpm.TJType = this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[1];
            this.drpm.strWhere = this.GetStrWhere();
            this.drpm.Discription = this.txtDiscription.Text.Trim();
            if (this.ifadd.Value == "0")
            {
                this.drpm.PK = this.pk.Value;
                this.drpm.Update(this.dbo);
                Const.DoSuccessOpen("修改成功！", this.Page);
            }
            else
            {
                this.drpm.Add(this.dbo);
                Const.DoSuccessOpen("添加成功！", this.Page);
            }
        }
        catch (Exception exception)
        {
            Const.ShowMessage("操作失败！" + exception.Message, this.Page);
        }
    }

    protected void ddlColumnName_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[1])
        {
            case null:
                return;

            case "string":
                this.divstr1.Visible = true;
                this.divstr2.Visible = false;
                this.divint.Visible = false;
                this.divdatetime.Visible = false;
                return;

            case "bady":
                this.divstr1.Visible = false;
                this.divstr2.Visible = true;
                this.divint.Visible = false;
                this.divdatetime.Visible = false;
                return;

            case "int":
                this.divstr1.Visible = false;
                this.divstr2.Visible = false;
                this.divint.Visible = true;
                this.divdatetime.Visible = false;
                return;

            case "DateTime":
                this.divstr1.Visible = false;
                this.divstr2.Visible = false;
                this.divint.Visible = false;
                this.divdatetime.Visible = true;
                break;
        }
    }

    protected void ddlintppqk_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlintppqk.SelectedValue == "区间值")
        {
            this.divint1.Visible = false;
            this.divint2.Visible = true;
        }
        else
        {
            this.divint1.Visible = true;
            this.divint2.Visible = false;
        }
    }

    protected void ddltablename_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.ddlColumnName.Items.Clear();
            LoadData[] dataArray = LoadData.LoadXml(Public.GetServerPath() + @"\\bin\\DataMessage.xml");
            LoadData data = null;
            string selectedValue = this.ddltablename.SelectedValue;
            foreach (LoadData data2 in dataArray)
            {
                if (data2.TableName == selectedValue)
                {
                    data = data2;
                    break;
                }
            }
            this.ddlColumnName.DataSource = data.ColumnMess;
            this.ddlColumnName.DataTextField = "列中文名";
            this.ddlColumnName.DataValueField = "列英文名和数据类型";
            this.ddlColumnName.DataBind();
        }
        catch (Exception)
        {
        }
    }

    private string GetStrWhere()
    {
        string str = "";
        switch (this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[1])
        {
            case null:
                return str;

            case "string":
                {
                    string selectedValue = this.ddlstrppqk.SelectedValue;
                    switch (selectedValue)
                    {
                        case null:
                            return str;

                        case "精确匹配":
                            return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " = '" + this.txtstring.Text + "'");

                        case "模糊匹配":
                            return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " like '%" + this.txtstring.Text + "%'");

                        case "前匹配":
                            return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " like '" + this.txtstring.Text + "%'");
                    }
                    if (selectedValue != "后匹配")
                    {
                        return str;
                    }
                    return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " like '%" + this.txtstring.Text + "'");
                }
            case "bady":
                {
                    string str4 = this.ddlstrself.SelectedValue;
                    if (str4 == null)
                    {
                        return str;
                    }
                    if (!(str4 == "self"))
                    {
                        if (str4 != "branch")
                        {
                            return str;
                        }
                    }
                    else
                    {
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " = '" + this.ddlstrself.SelectedValue + "'");
                    }
                    return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " = '" + this.ddlstrself.SelectedValue + "'");
                }
            case "int":
                switch (this.ddlintppqk.SelectedValue)
                {
                    case "大于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " > " + this.txtint.Text);

                    case "大于等于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " >= " + this.txtint.Text);

                    case "小于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " < " + this.txtint.Text);

                    case "小于等于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " <= " + this.txtint.Text);

                    case "等于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " = " + this.txtint.Text);

                    case "区间值":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " > " + this.txtintmin.Text + " and " + this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " < " + this.txtintmax.Text);

                    case "含等于区间值":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " >= " + this.txtintmin.Text + " and " + this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " <= " + this.txtintmax.Text);
                }
                return str;

            case "DateTime":
                switch (this.ddlDateType.SelectedValue)
                {
                    case "大于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " > " + this.ddlDateTime.SelectedValue);

                    case "大于等于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " >= " + this.ddlDateTime.SelectedValue);

                    case "小于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " < " + this.ddlDateTime.SelectedValue);

                    case "小于等于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " <= " + this.ddlDateTime.SelectedValue);

                    case "等于":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " = " + this.ddlDateTime.SelectedValue);

                    case "区间值":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " > " + this.ddldatemin.SelectedValue + " and " + this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " < " + this.ddldatemax.SelectedValue);

                    case "含等于区间值":
                        return (this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " >= " + this.ddldatemin.SelectedValue + " and " + this.ddltablename.SelectedValue + "." + this.ddlColumnName.SelectedValue.Split(new char[] { '|' })[0] + " <= " + this.ddldatemax.SelectedValue);
                }
                break;
        }
        return str;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            try
            {
                this.dbo = new DB_OPT();
                this.dbo.Open();
                this.ShowZDData();
                if ((base.Request.QueryString["type"] != null) && (base.Request.QueryString["type"].ToString() == "Update"))
                {
                    this.ifadd.Value = "0";
                    this.btDo.Text = "修改";
                    this.pk.Value = base.Request.QueryString["PK"].ToString();
                    this.drpm = new DataRowPowerDal();
                    this.drpm.PK = this.pk.Value;
                    this.drpm.GetModel(this.dbo);
                    this.SetValue();
                }
                else
                {
                    this.ddltablename_SelectedIndexChanged(sender, e);
                    this.ddlColumnName_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception exception)
            {
                Const.OpenErrorPage("获取数据失败，请联系管理员！" + exception.Message, this.Page);
            }
            finally
            {
                this.dbo.Close();
            }
        }
    }

    private void SetValue()
    {
        if (this.drpm.PK != null)
        {
            this.txtname.Text = this.drpm.Name;
            this.txtpowercode.Text = this.drpm.PowerCode;
            this.ddltablename.SelectedValue = this.drpm.TableName;
            this.ddlColumnName.SelectedValue = this.drpm.ColumnName;
            this.txtDiscription.Text = this.drpm.Discription;
            switch (this.drpm.ColumnName)
            {
                case null:
                    return;

                case "string":
                    this.divstr1.Visible = true;
                    this.txtstring.Text = this.drpm.strWhere;
                    this.divstr2.Visible = false;
                    this.divint.Visible = false;
                    this.divdatetime.Visible = false;
                    return;

                case "bady":
                    this.divstr1.Visible = false;
                    this.divstr2.Visible = true;
                    this.txtstring1.Visible = true;
                    this.txtstring1.Text = this.drpm.strWhere;
                    this.divint.Visible = false;
                    this.divdatetime.Visible = false;
                    return;

                case "int":
                    this.divstr1.Visible = false;
                    this.divstr2.Visible = false;
                    this.divint.Visible = true;
                    this.txtint.Text = this.drpm.strWhere;
                    this.divdatetime.Visible = false;
                    return;

                case "DateTime":
                    this.divstr1.Visible = false;
                    this.divstr2.Visible = false;
                    this.divint.Visible = false;
                    this.divdatetime.Visible = true;
                    this.txtdatetime.Visible = true;
                    this.txtdatetime.Text = this.drpm.strWhere;
                    break;
            }
        }
    }

    private void ShowZDData()
    {
        LoadData[] dataArray = LoadData.LoadXml(Public.GetServerPath() + @"\\bin\\DataMessage.xml");
        this.ddltablename.DataSource = dataArray;
        this.ddltablename.DataTextField = "TextName";
        this.ddltablename.DataValueField = "TableName";
        this.ddltablename.DataBind();
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
