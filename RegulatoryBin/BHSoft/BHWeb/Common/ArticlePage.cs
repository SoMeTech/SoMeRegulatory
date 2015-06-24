namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Web.UI;

    public class ArticlePage : Page
    {
        private int pagesize;
        private string str;
        private int strl;

        private void page_load(object sender, EventArgs e)
        {
            this.str = "1234567891234567898522555";
            this.pagesize = 3;
            this.strl = this.str.Length;
            base.Response.Write(this.strl);
            this.substr();
        }

        private void substr()
        {
            int num;
            string str;
            int num2 = int.Parse(base.Request.QueryString["page"]);
            if (this.strl == ((this.strl / this.pagesize) * this.pagesize))
            {
                for (num = 1; num <= (this.strl / this.pagesize); num++)
                {
                    base.Response.Write("页:<a href='#'>" + num + "</a>");
                }
                str = this.str.Substring((this.pagesize * num2) - this.pagesize, this.pagesize);
                base.Response.Write(str);
            }
            else if ((num2 * this.pagesize) > this.strl)
            {
                for (num = 1; num <= ((this.strl / this.pagesize) + 1); num++)
                {
                    base.Response.Write("页:<a href='#' /a>");
                }
                str = this.str.Substring((num2 - 1) * this.pagesize, this.strl - ((num2 - 1) * this.pagesize));
                base.Response.Write(str);
            }
            else
            {
                for (num = 1; num <= ((this.strl / this.pagesize) + 1); num++)
                {
                    base.Response.Write("页:<a href='#'>" + num + "</a>");
                }
                str = this.str.Substring((this.pagesize * num2) - this.pagesize, this.pagesize);
                base.Response.Write(str);
            }
        }
    }
}

