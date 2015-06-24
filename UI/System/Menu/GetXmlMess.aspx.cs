using ASP;
using SoMeTech.Menu;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Menu_GetXmlMess : Page, IRequiresSessionState
{
    protected DropDownList ddlColumnName;
    protected DropDownList ddltablename;
    protected HtmlForm form1;
    protected HtmlHead Head1;

    protected void ddlColumnName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Public.Show(this.ddlColumnName.SelectedItem.Value);
    }

    protected void ddltablename_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
            this.ddlColumnName.DataTextField = "ColumnText";
            this.ddlColumnName.DataValueField = "ColumnName";
            this.ddlColumnName.DataBind();
        }
        catch (Exception)
        {
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            try
            {
                LoadData[] dataArray = LoadData.LoadXml(Public.GetServerPath() + @"\\bin\\DataMessage.xml");
                this.ddltablename.DataSource = dataArray;
                this.ddltablename.DataTextField = "TextName";
                this.ddltablename.DataValueField = "TableName";
                this.ddltablename.DataBind();
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
