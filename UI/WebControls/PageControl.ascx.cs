using ASP;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public class manager_PageControl : UserControl
{
    private string databindmethod;
    private object databindmethoddal;
    private Type databindtype;
    private GridView gvResult;
    protected Label lblCurrentIndex;
    protected Label lblPageCount;
    private object[] objs;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ShowStats();
    }

    public void PagerButtonClick(object sender, EventArgs e)
    {
        if (this.gvResult.PageCount <= 1)
        {
            return;
        }
        string str = ((LinkButton)sender).CommandArgument.ToString();
        string str2 = str;
        switch (str2)
        {
            case null:
                break;

            case "next":
                if (this.gvResult.PageIndex < (this.gvResult.PageCount - 1))
                {
                    this.gvResult.PageIndex++;
                }
                goto Label_00CC;

            default:
                if (str2 == "prev")
                {
                    if (this.gvResult.PageIndex > 0)
                    {
                        this.gvResult.PageIndex--;
                    }
                }
                else
                {
                    if (!(str2 == "last"))
                    {
                        break;
                    }
                    this.gvResult.PageIndex = this.gvResult.PageCount - 1;
                }
                goto Label_00CC;
        }
        this.gvResult.PageIndex = Convert.ToInt32(str);
    Label_00CC:
        this.DataBindType.GetMethod(this.DataBindMethod).Invoke(this.DataBindMethodDal, this.DataBindMethodObj);
        this.ShowStats();
    }

    public void ShowStats()
    {
        string str = " ";
        this.lblCurrentIndex.Text = "第 " + ((this.gvResult.PageIndex + 1)).ToString() + str;
        this.lblPageCount.Text = "共 " + this.gvResult.PageCount.ToString() + str;
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public string DataBindMethod
    {
        get
        {
            return this.databindmethod;
        }
        set
        {
            this.databindmethod = value;
        }
    }

    public object DataBindMethodDal
    {
        get
        {
            return this.databindmethoddal;
        }
        set
        {
            this.databindmethoddal = value;
        }
    }

    public object[] DataBindMethodObj
    {
        get
        {
            return this.objs;
        }
        set
        {
            this.objs = value;
        }
    }

    public Type DataBindType
    {
        get
        {
            return this.databindtype;
        }
        set
        {
            this.databindtype = value;
        }
    }

    public GridView GVResult
    {
        get
        {
            return this.gvResult;
        }
        set
        {
            this.gvResult = value;
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
