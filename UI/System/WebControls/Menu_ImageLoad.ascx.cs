using ASP;
using QxRoom.Common;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Menu_ImageLoad : UserControl
{
    protected FileUpload Fu;
    private string imagepath;
    protected System.Web.UI.WebControls.Image Img;
    protected TextBox TxtImg;
    private string virtualcatalog;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Fu.Attributes.Add("onpropertychange", "javascript:img_change();");
        this.Img.Attributes.Add("onpropertychange", "javascript:setimgsize();");
        this.Img.Attributes.Add("onload", "javascript:setimgsize();");
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public string ImagePath
    {
        get
        {
            return this.imagepath;
        }
        set
        {
            this.imagepath = value;
        }
    }

    public string ImageUrl
    {
        get
        {
            string str = this.TxtImg.ClientID.Replace('_', '$');
            return base.Request[str];
        }
        set
        {
            this.TxtImg.Text = value;
            this.Img.ImageUrl = Public.RelativelyPath(value);
        }
    }

    public FileUpload LoadFile
    {
        get
        {
            return this.Fu;
        }
        set
        {
            this.Fu = value;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public string VirtualCatalog
    {
        get
        {
            return this.virtualcatalog;
        }
        set
        {
            this.virtualcatalog = value;
        }
    }
}
