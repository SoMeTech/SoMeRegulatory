using ASP;
using System;
using System.Runtime.CompilerServices;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageNavigator : UserControl
{
    private int _PageCount = 1;
    private int _PageIndex = 1;
    private int _PageSize = 20;
    private int _RecordCount;
    protected ImageButton BtnGoto;
    protected Label LblPageCount;
    protected Label LblPageIndex;
    protected Label LblPageSize;
    protected Label LblRecordCount;
    protected ImageButton LnkBtnFirst;
    protected ImageButton LnkBtnLast;
    protected ImageButton LnkBtnNext;
    protected ImageButton LnkBtnPrevious;
    protected TextBox TextBox1;
    protected TextBox txtNewPageIndex;

    public event PageChangeHandl OnPageChange;

    protected void BtnGoto_Click(object sender, ImageClickEventArgs e)
    {
        int num;
        try
        {
            num = Convert.ToInt32(this.txtNewPageIndex.Text);
        }
        catch
        {
            num = Convert.ToInt32(this.LblPageIndex.Text);
        }
        int num2 = Convert.ToInt32(this.LblPageCount.Text.Trim());
        if (num > num2)
        {
            num = num2;
        }
        if (num < 1)
        {
            num = 1;
        }
        int num3 = 0;
        if (this._PageSize != 0)
        {
            num3 = this._RecordCount / this._PageSize;
        }
        if (this._PageSize > this._RecordCount)
        {
            this.OnPageChange(sender, 1);
            this.TextBox1.Text = this._RecordCount.ToString();
        }
        else
        {
            if (num > (num3 + 1))
            {
                num = num3 + 1;
            }
            this.OnPageChange(sender, num);
        }
    }

    private void FirstType()
    {
        this.LnkBtnFirst.Enabled = false;
        this.LnkBtnFirst.ImageUrl = "~/Ext/resources/images/default/grid/page-first-disabled.gif";
        this.LnkBtnPrevious.Enabled = false;
        this.LnkBtnPrevious.ImageUrl = "~/Ext/resources/images/default/grid/page-prev-disabled.gif";
        this.LnkBtnNext.Enabled = true;
        this.LnkBtnNext.ImageUrl = "~/Ext/resources/images/default/grid/page-next.gif";
        this.LnkBtnLast.Enabled = true;
        this.LnkBtnLast.ImageUrl = "~/Ext/resources/images/default/grid/page-last.gif";
    }

    private void LastType()
    {
        this.LnkBtnFirst.Enabled = true;
        this.LnkBtnFirst.ImageUrl = "~/Ext/resources/images/default/grid/page-first.gif";
        this.LnkBtnPrevious.Enabled = true;
        this.LnkBtnPrevious.ImageUrl = "~/Ext/resources/images/default/grid/page-prev.gif";
        this.LnkBtnLast.Enabled = false;
        this.LnkBtnLast.ImageUrl = "~/Ext/resources/images/default/grid/page-last-disabled.gif";
        this.LnkBtnNext.Enabled = false;
        this.LnkBtnNext.ImageUrl = "~/Ext/resources/images/default/grid/page-next-disabled.gif";
    }

    protected void LnkBtnFirst_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            this.OnPageChange(sender, 1);
            this.FirstType();
        }
        catch
        {
        }
    }

    protected void LnkBtnLast_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int nPageIndex = Convert.ToInt32(this.LblPageCount.Text);
            this.LastType();
            this.OnPageChange(sender, nPageIndex);
        }
        catch
        {
            throw;
        }
    }

    protected void LnkBtnNext_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int nPageIndex = Convert.ToInt32(this.LblPageIndex.Text);
            int num2 = Convert.ToInt32(this.LblPageCount.Text.Trim());
            this.LnkBtnFirst.Enabled = true;
            this.LnkBtnFirst.ImageUrl = "~/Ext/resources/images/default/grid/page-first.gif";
            this.LnkBtnPrevious.Enabled = true;
            this.LnkBtnPrevious.ImageUrl = "~/Ext/resources/images/default/grid/page-prev.gif";
            if (nPageIndex < num2)
            {
                nPageIndex++;
                this.OnPageChange(sender, nPageIndex);
            }
            if (nPageIndex >= num2)
            {
                this.LnkBtnNext.Enabled = false;
                this.LnkBtnNext.ImageUrl = "~/Ext/resources/images/default/grid/page-next-disabled.gif";
                this.LnkBtnLast.Enabled = false;
                this.LnkBtnLast.ImageUrl = "~/Ext/resources/images/default/grid/page-last-disabled.gif";
            }
        }
        catch
        {
            throw;
        }
    }

    protected void LnkBtnPrevious_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int nPageIndex = Convert.ToInt32(this.LblPageIndex.Text);
            this.LnkBtnNext.Enabled = true;
            this.LnkBtnNext.ImageUrl = "~/Ext/resources/images/default/grid/page-next.gif";
            this.LnkBtnLast.Enabled = true;
            this.LnkBtnLast.ImageUrl = "~/Ext/resources/images/default/grid/page-last.gif";
            if (nPageIndex > 1)
            {
                nPageIndex--;
                this.OnPageChange(sender, nPageIndex);
            }
            if (nPageIndex <= 1)
            {
                this.LnkBtnFirst.Enabled = false;
                this.LnkBtnFirst.ImageUrl = "~/Ext/resources/images/default/grid/page-first-disabled.gif";
                this.LnkBtnPrevious.Enabled = false;
                this.LnkBtnPrevious.ImageUrl = "~/Ext/resources/images/default/grid/page-prev-disabled.gif";
            }
        }
        catch
        {
            throw;
        }
    }

    private void MiddleType()
    {
        this.LnkBtnFirst.Enabled = true;
        this.LnkBtnFirst.ImageUrl = "~/Ext/resources/images/default/grid/page-first.gif";
        this.LnkBtnPrevious.Enabled = true;
        this.LnkBtnPrevious.ImageUrl = "~/Ext/resources/images/default/grid/page-prev.gif";
        this.LnkBtnNext.Enabled = true;
        this.LnkBtnNext.ImageUrl = "~/Ext/resources/images/default/grid/page-next.gif";
        this.LnkBtnLast.Enabled = true;
        this.LnkBtnLast.ImageUrl = "~/Ext/resources/images/default/grid/page-last.gif";
    }

    private void NoType()
    {
        this.LnkBtnFirst.Enabled = false;
        this.LnkBtnFirst.ImageUrl = "~/Ext/resources/images/default/grid/page-first-disabled.gif";
        this.LnkBtnPrevious.Enabled = false;
        this.LnkBtnPrevious.ImageUrl = "~/Ext/resources/images/default/grid/page-prev-disabled.gif";
        this.LnkBtnNext.Enabled = false;
        this.LnkBtnNext.ImageUrl = "~/Ext/resources/images/default/grid/page-next-disabled.gif";
        this.LnkBtnLast.Enabled = false;
        this.LnkBtnLast.ImageUrl = "~/Ext/resources/images/default/grid/page-last-disabled.gif";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.LblRecordCount.Text))
        {
            this._RecordCount = int.Parse(this.LblRecordCount.Text);
        }
        if (!string.IsNullOrEmpty(this.TextBox1.Text))
        {
            try
            {
                this._PageSize = Convert.ToInt32(this.TextBox1.Text);
            }
            catch
            {
                this.TextBox1.Text = "20";
            }
        }
        if (this._PageSize != 0)
        {
            if ((this._RecordCount % this._PageSize) == 0)
            {
                this._PageCount = this._RecordCount / this._PageSize;
                this.LblPageCount.Text = this._PageCount.ToString();
            }
            else
            {
                this._PageCount = ((this._RecordCount - (this._RecordCount % this._PageSize)) / this._PageSize) + 1;
                this.LblPageCount.Text = this._PageCount.ToString();
            }
        }
        if (!string.IsNullOrEmpty(this.LblPageCount.Text))
        {
            this._PageCount = int.Parse(this.LblPageCount.Text);
        }
        if (this._RecordCount <= this._PageSize)
        {
            this.NoType();
        }
        else if (this.LblPageIndex.Text == "1")
        {
            this.FirstType();
        }
        else if (this.LblPageIndex.Text == this.LblPageCount.Text)
        {
            this.LastType();
        }
        else
        {
            this.MiddleType();
        }
    }

    protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax)this.Context.ApplicationInstance;
        }
    }

    public int PageCount
    {
        get
        {
            if (this.LblPageCount.Text != "")
            {
                return int.Parse(this.LblPageCount.Text);
            }
            return 1;
        }
    }

    public int PageIndex
    {
        get
        {
            if (this.LblPageIndex.Text != "")
            {
                return int.Parse(this.LblPageIndex.Text);
            }
            return 1;
        }
        set
        {
            try
            {
                this._PageSize = Convert.ToInt32(this.TextBox1.Text);
            }
            catch
            {
                this._PageSize = 10;
                this.TextBox1.Text = "10";
            }
            this._PageIndex = value;
            this.txtNewPageIndex.Text = this.LblPageIndex.Text = this._PageIndex.ToString();
            if (this._PageIndex < 2)
            {
                this.LnkBtnFirst.Enabled = true;
                this.LnkBtnPrevious.Enabled = true;
            }
            else
            {
                this.LnkBtnFirst.Enabled = true;
                this.LnkBtnPrevious.Enabled = true;
            }
            if (this._PageIndex >= this._PageCount)
            {
                this.LnkBtnNext.Enabled = true;
                this.LnkBtnLast.Enabled = true;
            }
            else
            {
                this.LnkBtnNext.Enabled = true;
                this.LnkBtnLast.Enabled = true;
            }
        }
    }

    public int PageSize
    {
        get
        {
            int num;
            try
            {
                num = Convert.ToInt32(this.TextBox1.Text);
            }
            catch
            {
                num = 10;
                this.TextBox1.Text = "10";
            }
            return num;
        }
        set
        {
            this._PageSize = value;
            this.TextBox1.Text = this._PageSize.ToString();
            if (this._PageSize != 0)
            {
                if ((this._RecordCount % this._PageSize) == 0)
                {
                    this._PageCount = this._RecordCount / this._PageSize;
                    this.LblPageCount.Text = this._PageCount.ToString();
                }
                else
                {
                    this._PageCount = ((this._RecordCount - (this._RecordCount % this._PageSize)) / this._PageSize) + 1;
                    this.LblPageCount.Text = this._PageCount.ToString();
                }
            }
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }

    public int RecordCount
    {
        get
        {
            if (this.LblRecordCount.Text != "")
            {
                return int.Parse(this.LblRecordCount.Text);
            }
            return 0;
        }
        set
        {
            this._RecordCount = value;
            try
            {
                this._PageSize = Convert.ToInt32(this.TextBox1.Text);
            }
            catch
            {
                this.TextBox1.Text = "20";
            }
            this.LblRecordCount.Text = this._RecordCount.ToString();
            if (this._PageSize != 0)
            {
                if ((this._RecordCount % this._PageSize) == 0)
                {
                    this._PageCount = this._RecordCount / this._PageSize;
                    this.LblPageCount.Text = this._PageCount.ToString();
                }
                else
                {
                    this._PageCount = ((this._RecordCount - (this._RecordCount % this._PageSize)) / this._PageSize) + 1;
                    this.LblPageCount.Text = this._PageCount.ToString();
                }
            }
        }
    }
}
