using AjaxPro;
using SoMeTech.Company;
using SoMeTech.Company.Branch;
using SoMeTech.DataAccess;
using SoMeTech.Menu;
using SoMeTech.UsualBookTable;
using System;

public sealed class UsualBookTable : MainPageClass
{
    private string columns;
    private DB_OPT dbo;
    private int grade = -1;
    private string gradecolname = "Grade";
    private bool isgrade = true;
    private string pagetitle;
    private int showselect;
    private string strstep = "";
    private string strwhere = "";
    private string tablename;
    private string tj = "0~0~0";
    private string upcolname = "FatherPK";

    [AjaxMethod]
    public BranchModel[] GetBranch(string parentid)
    {
        BranchModel[] modelArray;
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            modelArray = new BranchDal().GetModels("FatherPK='" + parentid.Split(new char[] { '|' })[0] + "'", false, false, true, true, this.dbo);
        }
        catch (Exception)
        {
            modelArray = null;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return modelArray;
    }

    [AjaxMethod]
    public CompanyModel[] GetCompany(string parentid)
    {
        CompanyModel[] modelArray;
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            modelArray = new CompanyDal().GetModels("FatherPK='" + parentid.Split(new char[] { '|' })[0] + "'", false, false, true, this.dbo);
        }
        catch (Exception)
        {
            modelArray = null;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return modelArray;
    }

    [AjaxMethod]
    public MenuModel[] GetMenuList(string parentid)
    {
        MenuModel[] modelArray;
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            modelArray = new MenuDal().GetModels("FatherPK='" + parentid.Split(new char[] { '|' })[0] + "'", false, this.dbo);
        }
        catch (Exception)
        {
            modelArray = null;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return modelArray;
    }

    [AjaxMethod]
    public UsualBookTableModel[] GetMenus(string parentid)
    {
        UsualBookTableModel[] modelArray;
        try
        {
            this.dbo = new DB_OPT();
            this.dbo.Open();
            modelArray = new UsualBookTableDal { TableName = parentid.Split(new char[] { '|' })[1] }.GetModels("FatherPK='" + parentid.Split(new char[] { '|' })[0] + "'", false, this.dbo);
        }
        catch (Exception)
        {
            modelArray = null;
        }
        finally
        {
            if (this.dbo != null)
            {
                this.dbo.Close();
            }
        }
        return modelArray;
    }

    public string Select()
    {
        if (this.strwhere == "")
        {
            if (this.grade >= 0)
            {
                return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.gradecolname, "=", this.grade });
            }
            return ("select " + this.columns + " from " + this.tablename);
        }
        if (this.grade >= 0)
        {
            return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.strwhere, " and ", this.gradecolname, "=", this.grade });
        }
        return ("select " + this.columns + " from " + this.tablename + " where " + this.strwhere);
    }

    public string selectMCas(string strID, string strMC)
    {
        string str = "select " + this.columns + " from " + this.tablename + " where 1=1 ";
        if (this.strwhere != "")
        {
            str = str + " and " + this.strwhere;
        }
        if (strID != "")
        {
            string str2 = str;
            str = str2 + " and " + this.columns.Split(new char[] { char.Parse(",") })[0].Split(new char[] { ' ' })[0].Trim() + " like '%" + strID + "%'";
        }
        if (strMC != "")
        {
            string str3 = str;
            str = str3 + " and " + this.columns.Split(new char[] { char.Parse(",") })[1].Split(new char[] { ' ' })[0].Trim() + " like '%" + strMC + "%'";
        }
        return str;
    }

    public string selectNextStep()
    {
        string str = "";
        if (this.TJ.Split(new char[] { '~' })[0].IndexOf("|") > 0)
        {
            str = this.TJ.Split(new char[] { '~' })[0].Split(new char[] { '|' })[0];
        }
        else
        {
            str = this.TJ.Split(new char[] { '~' })[0];
        }
        this.grade = int.Parse(this.TJ.Split(new char[] { '~' })[2]) + 1;
        if (this.strwhere == "")
        {
            return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.upcolname, "='", str, "' and ", this.gradecolname, "=", this.grade });
        }
        return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.strwhere, " and ", this.upcolname, "='", str, "' and ", this.gradecolname, "=", this.grade });
    }

    public string selectStep(string dm)
    {
        this.grade = int.Parse(this.TJ.Split(new char[] { '~' })[2]) + 2;
        if (this.strwhere == "")
        {
            return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.upcolname, "='", dm, "' and ", this.gradecolname, "=", this.grade });
        }
        return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.strwhere, " and ", this.upcolname, "='", dm, "' and ", this.gradecolname, "=", this.grade });
    }

    public string selectUpStep()
    {
        this.grade = int.Parse(this.TJ.Split(new char[] { '~' })[2]) - 1;
        if (this.strwhere == "")
        {
            return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.upcolname, "='", this.TJ.Split(new char[] { '~' })[0], "' and ", this.gradecolname, "=", this.grade });
        }
        return string.Concat(new object[] { "select ", this.columns, " from ", this.tablename, " where ", this.strwhere, " and ", this.upcolname, "='", this.TJ.Split(new char[] { '~' })[0], "' and ", this.gradecolname, "=", this.grade });
    }

    public string Columns
    {
        get
        {
            return this.columns;
        }
        set
        {
            this.columns = value;
        }
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            this.grade = value;
        }
    }

    public string GradeColName
    {
        get
        {
            return this.gradecolname;
        }
        set
        {
            this.gradecolname = value;
        }
    }

    public bool IsGrade
    {
        get
        {
            return this.isgrade;
        }
        set
        {
            this.isgrade = value;
        }
    }

    public string PageTitle
    {
        get
        {
            return this.pagetitle;
        }
        set
        {
            this.pagetitle = value;
        }
    }

    public int ShowSelect
    {
        get
        {
            return this.showselect;
        }
        set
        {
            this.showselect = value;
        }
    }

    public string strStep
    {
        get
        {
            return this.strstep;
        }
        set
        {
            this.strstep = value;
        }
    }

    public string StrWhere
    {
        get
        {
            return this.strwhere;
        }
        set
        {
            this.strwhere = value;
        }
    }

    public string TableName
    {
        get
        {
            return this.tablename;
        }
        set
        {
            this.tablename = value;
        }
    }

    public string TJ
    {
        get
        {
            return this.tj;
        }
        set
        {
            this.tj = value;
        }
    }

    public string UpColName
    {
        get
        {
            return this.upcolname;
        }
        set
        {
            this.upcolname = value;
        }
    }
}

