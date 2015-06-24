using ASP;
using QxRoom.Common;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public class WebControls_FileShow : UserControl
{
    private string controlpage = "";
    private string defaultdir;
    private string removedir = "";
    private string removefile = "";
    protected Table TbFiles;
    private string windowname = "file";

    private bool BDir(string filename)
    {
        string[] strArray = null;
        if (this.RemoveDir.IndexOf(",") > 0)
        {
            strArray = this.RemoveDir.Split(",".ToCharArray());
        }
        else
        {
            strArray = new string[] { this.RemoveDir };
        }
        for (int i = 0; i < strArray.Length; i++)
        {
            if (filename.Trim().ToLower() == strArray[i].ToLower().Trim())
            {
                return false;
            }
        }
        return true;
    }

    private bool BFile(string filename)
    {
        string str = filename;
        if (this.ShowFiles == "")
        {
            return true;
        }
        int num = str.LastIndexOf(".");
        str = str.Substring(num + 1);
        string[] strArray = null;
        if (this.ShowFiles.IndexOf(",") > 0)
        {
            strArray = this.ShowFiles.Split(",".ToCharArray());
        }
        else
        {
            strArray = new string[] { this.ShowFiles };
        }
        for (int i = 0; i < strArray.Length; i++)
        {
            if (str.Trim().ToLower() == strArray[i].ToLower().Trim())
            {
                return true;
            }
        }
        return false;
    }

    private void GetFiles(string strpath)
    {
        if (strpath == "~")
        {
            strpath = base.Server.MapPath(strpath);
        }
        else
        {
            strpath = base.Server.MapPath(Public.RelativelyPath(strpath));
        }
        int num = 0;
        string[] directories = Directory.GetDirectories(strpath);
        string[] files = Directory.GetFiles(strpath);
        TableRow row = null;
        for (int i = 0; i < directories.Length; i++)
        {
            TableCell cell = new TableCell
            {
                BorderColor = ColorTranslator.FromHtml("#404040")
            };
            string s = "";
            string filename = s = directories[i];
            int num3 = filename.LastIndexOf(@"\");
            filename = filename.Substring(num3 + 1);
            s = s.Replace(base.Server.MapPath("~"), "").Replace(@"\", "/");
            if (s.Substring(0, 1) == "/")
            {
                s = s.Substring(1);
            }
            if (this.BDir(filename))
            {
                if ((num % 4) == 0)
                {
                    if (num > 0)
                    {
                        this.TbFiles.Rows.Add(row);
                        row = null;
                    }
                    row = new TableRow
                    {
                        BorderColor = ColorTranslator.FromHtml("#404040")
                    };
                }
                cell.Text = "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + this.ControlPage + "?filepath=" + base.Server.UrlEncode(s) + "\" target=\"" + this.WindowName + "\"><img border=\"0\" src=\"" + Public.RelativelyPath("System/menu/images/WJJ_S_0605_26.jpg") + "\" width=\"18\">" + filename + "</a>";
                row.Cells.Add(cell);
                num++;
            }
        }
        for (int j = 0; j < files.Length; j++)
        {
            TableCell cell2 = new TableCell
            {
                BorderColor = ColorTranslator.FromHtml("#404040")
            };
            string str3 = files[j];
            int num5 = str3.LastIndexOf(@"\");
            str3 = str3.Substring(num5 + 1);
            if (this.BFile(str3))
            {
                if ((num % 4) == 0)
                {
                    if (num > 0)
                    {
                        this.TbFiles.Rows.Add(row);
                        row = null;
                    }
                    row = new TableRow
                    {
                        BorderColor = ColorTranslator.FromHtml("#404040")
                    };
                }
                string str4 = files[j].Replace(base.Server.MapPath("~"), "").Replace(@"\", "/");
                if (str4.Substring(0, 1) == "/")
                {
                    str4 = str4.Substring(1);
                }
                cell2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\" onclick=\"javascript:window.returnValue='" + str4 + "';window.close();\" target=\"file\"><img border=\"0\" src=\"" + Public.RelativelyPath("System/menu/images/WJ_B_0609_3.jpg") + "\" width=\"15\">" + str3 + "</a>";
                row.Cells.Add(cell2);
                num++;
            }
        }
        if ((num % 4) != 0)
        {
            TableCell cell3 = new TableCell
            {
                BorderColor = ColorTranslator.FromHtml("#404040"),
                ColumnSpan = 4 - (num % 4)
            };
            row.Cells.Add(cell3);
            this.TbFiles.Rows.Add(row);
        }
        else if (row != null)
        {
            this.TbFiles.Rows.Add(row);
        }
        if (num == 0)
        {
            row = new TableRow
            {
                BorderColor = ColorTranslator.FromHtml("#404040")
            };
            TableCell cell4 = new TableCell
            {
                BorderColor = ColorTranslator.FromHtml("#404040"),
                ColumnSpan = 4,
                HorizontalAlign = HorizontalAlign.Center,
                Text = "没有数据"
            };
            row.Cells.Add(cell4);
            this.TbFiles.Rows.Add(row);
        }
        row = new TableRow
        {
            BorderColor = ColorTranslator.FromHtml("#404040")
        };
        TableCell cell5 = new TableCell
        {
            BorderColor = ColorTranslator.FromHtml("#404040"),
            ColumnSpan = 4,
            HorizontalAlign = HorizontalAlign.Center,
            Text = "<a href=\"" + this.ControlPage + "?filepath=" + base.Request.Cookies["fileshowpath"].Value + "\" target=\"" + this.WindowName + "\">返回</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\" onclick=\"javascript:window.close()\" target=\"" + this.WindowName + "\">关闭</a>"
        };
        row.Cells.Add(cell5);
        this.TbFiles.Rows.Add(row);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string defaultDir = this.DefaultDir;
        HttpCookie cookie = new HttpCookie("fileshowpath");
        base.Response.Cookies.Add(cookie);
        if ((base.Request["filepath"] != null) && (base.Request["filepath"].Trim() != ""))
        {
            defaultDir = base.Request["filepath"];
            if (!this.Page.IsPostBack)
            {
                cookie.Value = defaultDir;
            }
        }
        this.GetFiles(defaultDir);
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public string ControlPage
    {
        get
        {
            return this.controlpage;
        }
        set
        {
            this.controlpage = value;
        }
    }

    public string DefaultDir
    {
        get
        {
            if (this.defaultdir != null)
            {
                return this.defaultdir;
            }
            return "~";
        }
        set
        {
            this.defaultdir = value;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public string RemoveDir
    {
        get
        {
            return this.removedir;
        }
        set
        {
            this.removedir = value;
        }
    }

    public string ShowFiles
    {
        get
        {
            return this.removefile;
        }
        set
        {
            this.removefile = value;
        }
    }

    public string WindowName
    {
        get
        {
            return this.windowname;
        }
        set
        {
            this.windowname = value;
        }
    }
}
