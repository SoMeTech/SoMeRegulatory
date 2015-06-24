using ASP;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using QxRoom.Common;
using System;
using System.Runtime.InteropServices;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class User_DataRowPowerItem : Page, IRequiresSessionState
{
    protected Button btadd;
    protected Button btdel;
    protected Button btDo;
    private DB_OPT dbo;
    protected DropDownList ddlColumnName;
    protected DropDownList ddlgxysf;
    protected DropDownList ddltablename;
    private DataRowPowerItemModel drpim;
    private DataRowPowerModel drpm;
    protected HtmlForm form1;
    protected HtmlInputText ifadd;
    protected ListBox lballqxxx;
    protected ListBox lbxzqx;
    protected HtmlInputText pk;
    protected HtmlInputText tn;
    protected TextBox txtDiscription;
    protected TextBox txtname;
    protected TextBox txtpowercode;

    protected void btadd_Click(object sender, EventArgs e)
    {
        ListItem selectedItem = new ListItem();
        selectedItem = this.lballqxxx.SelectedItem;
        selectedItem.Text = selectedItem.Text + " " + this.ddlgxysf.SelectedValue + " ";
        selectedItem.Value = selectedItem.Value + " " + this.ddlgxysf.SelectedValue + " ";
        this.lbxzqx.Items.Add(selectedItem);
        this.lballqxxx.Items.Remove(this.lballqxxx.SelectedItem);
        this.lbxzqx.SelectedIndex = -1;
    }

    protected void btdel_Click(object sender, EventArgs e)
    {
        ListItem selectedItem = new ListItem();
        selectedItem = this.lbxzqx.SelectedItem;
        selectedItem.Text = selectedItem.Text.Substring(0, selectedItem.Text.Length - 5);
        selectedItem.Value = selectedItem.Value.Substring(0, selectedItem.Value.Length - 5);
        this.lballqxxx.Items.Add(selectedItem);
        this.lbxzqx.Items.Remove(this.lbxzqx.SelectedItem);
        this.lballqxxx.SelectedIndex = -1;
    }

    protected void btDo_Click(object sender, EventArgs e)
    {
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.drpim = new DataRowPowerItemDal();
            this.drpim.Name = this.txtname.Text.Trim();
            this.drpim.PowerCode = this.txtpowercode.Text.Trim();
            this.drpim.TableName = this.ddltablename.SelectedValue;
            string qxlist = "";
            string strwhere = "";
            this.GetStrWhere(out qxlist, out strwhere);
            this.drpim.Discription = this.txtDiscription.Text.Trim();
            this.drpim.QXList = qxlist;
            this.drpim.strWhere = strwhere;
            if (this.ifadd.Value == "0")
            {
                this.drpim.PK = this.pk.Value;
                this.drpim.Update(this.dbo);
                Const.DoSuccessOpen("修改成功！", this.Page);
            }
            else
            {
                this.drpim.Add(this.dbo);
                Const.DoSuccessOpen("添加成功！", this.Page);
            }
        }
        catch (Exception exception)
        {
            Const.OpenErrorPage("操作失败！" + exception.Message, this.Page);
        }
    }

    protected void ddltablename_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.lballqxxx.Items.Clear();
            this.lbxzqx.Items.Clear();
            this.dbo = new DB_OPT();
            this.dbo.Open();
            this.drpm = new DataRowPowerDal();
            this.drpm.TableName = this.ddltablename.SelectedValue;
            DataRowPowerModel[] models = this.drpm.GetModels(this.dbo);
            if (models != null)
            {
                this.lballqxxx.DataSource = models;
                this.lballqxxx.DataTextField = "Name";
                this.lballqxxx.DataValueField = "CodeAndWhere";
                this.lballqxxx.DataBind();
            }
        }
        catch (Exception)
        {
        }
    }

    private void GetStrWhere(out string qxlist, out string strwhere)
    {
        qxlist = "";
        strwhere = "";
        foreach (ListItem item in this.lbxzqx.Items)
        {
            qxlist = qxlist + item.Value.Split(new char[] { '|' })[0] + "|";
            strwhere = strwhere + item.Value.Split(new char[] { '|' })[1];
        }
        if (qxlist.Length > 0)
        {
            qxlist = qxlist.Substring(0, qxlist.Length - 1);
        }
        strwhere = strwhere.Substring(0, strwhere.Length - 5);
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
                    this.drpim = new DataRowPowerItemDal();
                    this.drpim.PK = this.pk.Value;
                    this.drpim.GetModel(this.dbo);
                    this.SetValue(sender, e);
                }
                else
                {
                    this.ddltablename_SelectedIndexChanged(sender, e);
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

    private void SetValue(object sender, EventArgs e)
    {
        if (this.drpim.PK != null)
        {
            this.txtname.Text = this.drpim.Name;
            this.txtpowercode.Text = this.drpim.PowerCode;
            this.ddltablename.SelectedValue = this.drpim.TableName;
            this.ddlColumnName.SelectedValue = this.drpim.ColumnName;
            this.txtDiscription.Text = this.drpim.Discription;
            this.ddltablename_SelectedIndexChanged(sender, e);
            string[] strArray = this.drpim.QXList.Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int j = 0; j < this.lballqxxx.Items.Count; j++)
                {
                    ListItem item = new ListItem();
                    item = this.lballqxxx.Items[j];
                    if (item.Value.Split(new char[] { '|' })[0] == strArray[i])
                    {
                        item.Text = item.Text + " " + this.ddlgxysf.SelectedValue + " ";
                        item.Value = item.Value + " " + this.ddlgxysf.SelectedValue + " ";
                        this.lbxzqx.Items.Add(item);
                        this.lballqxxx.Items.Remove(this.lballqxxx.Items[j]);
                        this.lbxzqx.SelectedIndex = -1;
                    }
                }
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
