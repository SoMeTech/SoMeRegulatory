using ASP;
using SoMeTech.Menu;
using QxRoom.Common;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using YYControls;

public class User_XmlEdit : Page, IRequiresSessionState
{
    protected Button Button1;
    protected Button Button2;
    protected DropDownList ddlDataType;
    protected DropDownList ddlTableName;
    protected HtmlForm form1;
    protected SmartGridView gvResult;
    protected TextBox txtColChina;
    protected HtmlInputText txtColChinaVal;
    protected TextBox txtColName;
    protected HtmlInputText txtColNameVal;
    protected HtmlInputText txtDataType;
    protected TextBox txtTableChina;
    protected HtmlInputText txtTableChinaVal;
    protected TextBox txtTableName;
    protected HtmlInputText txtTableNameVal;

    private void BindTableMess()
    {
        LoadData[] dataArray = LoadData.LoadXml(Public.GetServerPath() + @"\\bin\\DataMessage.xml");
        this.ddlTableName.DataSource = dataArray;
        this.ddlTableName.DataTextField = "TextName";
        this.ddlTableName.DataValueField = "TableName";
        this.ddlTableName.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        XmlDocument document = new XmlDocument();
        string serverPath = Public.GetServerPath();
        document.Load(serverPath + @"\\bin\\DataMessage.xml");
        foreach (XmlNode node in document.SelectNodes("/DataMessage/DataTableItem"))
        {
            XmlElement element = (XmlElement)node;
            if (element.GetAttribute("TableName") == this.txtTableNameVal.Value.Trim())
            {
                element.SetAttribute("TableName", this.txtTableName.Text.Trim());
                element.SetAttribute("Text", this.txtTableChina.Text.Trim());
                foreach (XmlNode node2 in element.ChildNodes)
                {
                    XmlElement element2 = (XmlElement)node2;
                    if (element2.GetAttribute("ColumnName") == this.txtColNameVal.Value.Trim())
                    {
                        element2.InnerText = this.txtColChina.Text.Trim();
                        element2.SetAttribute("ColumnName", this.txtColName.Text.Trim());
                        element2.SetAttribute("ColumnType", this.ddlDataType.SelectedValue);
                        break;
                    }
                }
                break;
            }
        }
        document.Save(serverPath + @"\\bin\\DataMessage.xml");
        Public.Show("修改成功！");
        this.ClearForm();
        this.BindTableMess();
        this.ddlTableName_SelectedIndexChanged(sender, e);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        XmlDocument document = new XmlDocument();
        string serverPath = Public.GetServerPath();
        document.Load(serverPath + @"\\bin\\DataMessage.xml");
        XmlNodeList list = document.SelectNodes("/DataMessage/DataTableItem");
        int num = 0;
        foreach (XmlNode node in list)
        {
            XmlElement element = (XmlElement)node;
            if (element.GetAttribute("TableName") == this.txtTableName.Text.Trim())
            {
                num++;
                element.SetAttribute("Text", this.txtTableChina.Text.Trim());
                XmlNodeList childNodes = element.ChildNodes;
                int num2 = 0;
                foreach (XmlNode node2 in childNodes)
                {
                    XmlElement element2 = (XmlElement)node2;
                    if (element2.GetAttribute("ColumnName") == this.txtColName.Text.Trim())
                    {
                        num2++;
                        Public.Show("该节点已存在！");
                        break;
                    }
                }
                if (num2 == 0)
                {
                    XmlElement newChild = document.CreateElement("DataColumnItem");
                    newChild.InnerText = this.txtColChina.Text.Trim();
                    newChild.SetAttribute("ColumnName", this.txtColName.Text.Trim());
                    newChild.SetAttribute("ColumnType", this.ddlDataType.SelectedValue);
                    element.AppendChild(newChild);
                    document.Save(serverPath + @"\\bin\\DataMessage.xml");
                    Public.Show("新增成功！");
                    this.BindTableMess();
                    this.ddlTableName_SelectedIndexChanged(sender, e);
                }
                break;
            }
        }
        if (num == 0)
        {
            XmlNode node3 = document.SelectSingleNode("/DataMessage");
            XmlElement element4 = document.CreateElement("DataTableItem");
            element4.SetAttribute("TableName", this.txtTableName.Text.Trim());
            element4.SetAttribute("Text", this.txtTableChina.Text.Trim());
            XmlElement element5 = document.CreateElement("DataColumnItem");
            element5.InnerText = this.txtColChina.Text.Trim();
            element5.SetAttribute("ColumnName", this.txtColName.Text.Trim());
            element5.SetAttribute("ColumnType", this.ddlDataType.SelectedValue);
            element4.AppendChild(element5);
            node3.AppendChild(element4);
            document.Save(serverPath + @"\\bin\\DataMessage.xml");
            Public.Show("新增成功！");
            this.ClearForm();
            this.BindTableMess();
            this.ddlTableName_SelectedIndexChanged(sender, e);
        }
    }

    private void ClearForm()
    {
        this.txtTableName.Text = "";
        this.txtTableChina.Text = "";
        this.txtColName.Text = "";
        this.ddlDataType.SelectedIndex = 0;
        this.txtColChina.Text = "";
        this.txtTableNameVal.Value = "";
        this.txtTableChinaVal.Value = "";
        this.txtColNameVal.Value = "";
        this.txtDataType.Value = "";
        this.txtColChinaVal.Value = "";
    }

    protected void ddlTableName_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData[] dataArray = LoadData.LoadXml(Public.GetServerPath() + @"\\bin\\DataMessage.xml");
        new DataTable();
        for (int i = 0; i < dataArray.Length; i++)
        {
            if (dataArray[i].TableName == this.ddlTableName.SelectedItem.Value)
            {
                this.gvResult.DataSource = dataArray[i].ColumnMess;
                this.gvResult.DataBind();
            }
        }
    }

    protected void gvResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string str = this.gvResult.Rows[e.RowIndex].Cells[2].Text.ToString();
        XmlDocument document = new XmlDocument();
        string serverPath = Public.GetServerPath();
        document.Load(serverPath + @"\\bin\\DataMessage.xml");
        foreach (XmlNode node in document.SelectNodes("/DataMessage/DataTableItem"))
        {
            XmlElement element = (XmlElement)node;
            if (element.GetAttribute("TableName") == this.ddlTableName.SelectedValue)
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    XmlElement oldChild = (XmlElement)node2;
                    if (oldChild.GetAttribute("ColumnName") == str)
                    {
                        oldChild.ParentNode.RemoveChild(oldChild);
                    }
                }
            }
        }
        document.Save(serverPath + @"\\bin\\DataMessage.xml");
        Public.Show("删除成功！");
        this.BindTableMess();
        this.ddlTableName_SelectedIndexChanged(sender, e);
    }

    protected void gvResult_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        this.Button2.Enabled = false;
        this.Button1.Enabled = true;
        this.txtTableName.Text = this.ddlTableName.SelectedValue;
        this.txtTableChina.Text = this.ddlTableName.SelectedItem.Text;
        this.txtColName.Text = this.gvResult.Rows[e.NewSelectedIndex].Cells[2].Text.ToString();
        this.ddlDataType.SelectedValue = this.gvResult.Rows[e.NewSelectedIndex].Cells[3].Text.ToString();
        this.txtColChina.Text = this.gvResult.Rows[e.NewSelectedIndex].Cells[4].Text.ToString();
        this.txtTableNameVal.Value = this.ddlTableName.SelectedValue;
        this.txtTableChinaVal.Value = this.ddlTableName.SelectedItem.Text;
        this.txtColNameVal.Value = this.gvResult.Rows[e.NewSelectedIndex].Cells[2].Text.ToString();
        this.txtDataType.Value = this.gvResult.Rows[e.NewSelectedIndex].Cells[3].Text.ToString();
        this.txtColChinaVal.Value = this.gvResult.Rows[e.NewSelectedIndex].Cells[4].Text.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            try
            {
                this.Button1.Enabled = false;
                this.BindTableMess();
                this.ddlTableName_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
            }
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
