namespace QxRoom.Common.ControlDo
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YYControls;

    public sealed class DataListDo
    {
        public static string GetViewSort()
        {
            if ((HttpContext.Current.Request.Cookies["SortOrder"] != null) && (HttpContext.Current.Request.Cookies["OrderDire"] != null))
            {
                return (HttpContext.Current.Request.Cookies["SortOrder"].Value + " " + HttpContext.Current.Request.Cookies["OrderDire"].Value);
            }
            return "";
        }

        public static void OutExcel(Page myPage, DataGrid dg, string name, string codetype)
        {
            if (codetype == "")
            {
                codetype = "GB2312";
            }
            HttpResponse response = myPage.Response;
            string str = "attachment;filename=" + HttpContext.Current.Server.UrlEncode(name) + ".xls";
            dg.Visible = true;
            response.Clear();
            response.Buffer = true;
            response.Charset = codetype;
            response.AppendHeader("Content-Disposition", str);
            response.ContentEncoding = Encoding.GetEncoding(codetype);
            response.ContentType = "application/ms-excel";
            dg.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            dg.RenderControl(writer2);
            response.Write(writer.ToString());
            response.End();
        }

        public static void OutExcel(Page myPage, GridView gv, string name, string codetype)
        {
            if (codetype == "")
            {
                codetype = "GB2312";
            }
            HttpResponse response = myPage.Response;
            string str = "attachment;filename=" + HttpContext.Current.Server.UrlEncode(name) + ".xls";
            gv.Visible = true;
            response.Clear();
            response.Buffer = true;
            response.Charset = codetype;
            response.AppendHeader("Content-Disposition", str);
            response.ContentEncoding = Encoding.GetEncoding(codetype);
            response.ContentType = "application/ms-excel";
            gv.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            gv.RenderControl(writer2);
            response.Write(writer.ToString());
            response.End();
        }

        public static void OutExcel(Page myPage, SmartGridView gv, string name, string codetype)
        {
            if (codetype == "")
            {
                codetype = "GB2312";
            }
            HttpResponse response = myPage.Response;
            string str = "attachment;filename=" + HttpContext.Current.Server.UrlEncode(name) + ".xls";
            gv.Visible = true;
            response.Clear();
            response.Buffer = true;
            response.Charset = codetype;
            response.AppendHeader("Content-Disposition", str);
            response.ContentEncoding = Encoding.GetEncoding(codetype);
            response.ContentType = "application/ms-excel";
            gv.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            gv.RenderControl(writer2);
            response.Write(writer.ToString());
            response.End();
        }

        public static void SetDataGridSorting(object sender, DataGridSortCommandEventArgs e)
        {
            SetSorting(e.SortExpression);
        }

        public static void SetGridViewRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#8C9FF0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        public static void SetGridViewSorting(object sender, GridViewSortEventArgs e)
        {
            SetSorting(e.SortExpression);
        }

        private static void SetSorting(string sPage)
        {
            if ((HttpContext.Current.Request.Cookies["SortOrder"] != null) && (HttpContext.Current.Request.Cookies["OrderDire"] != null))
            {
                if (HttpContext.Current.Request.Cookies["SortOrder"].Value == sPage)
                {
                    if (HttpContext.Current.Request.Cookies["OrderDire"].Value == "Desc")
                    {
                        HttpContext.Current.Response.Cookies["OrderDire"].Value = "ASC";
                    }
                    else
                    {
                        HttpContext.Current.Response.Cookies["OrderDire"].Value = "Desc";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Cookies["SortOrder"].Value = sPage;
                    HttpContext.Current.Response.Cookies["OrderDire"].Value = "ASC";
                }
            }
            else
            {
                HttpContext.Current.Response.Cookies["SortOrder"].Value = sPage;
                HttpContext.Current.Response.Cookies["OrderDire"].Value = "ASC";
            }
        }
    }
}

