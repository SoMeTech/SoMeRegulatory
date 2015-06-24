using BHSoft.BHWeb.Common;
using SoMeTech.ServicesClass.Services;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YYControls;

public sealed class Common
{
    public static string Date_CutDate(object obj)
    {
        string str = "";
        if ((obj == null) || (obj.ToString() == ""))
        {
            return str;
        }
        if (obj.ToString() == "2001-1-1")
        {
            return "";
        }
        return DateTime.Parse(obj.ToString()).ToString("yyyy-MM-dd");
    }

    public static string GetDDLsText(ListControl ddl, string val)
    {
        if ((val.Trim() != "") && (val.Trim() != "0"))
        {
            try
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i].Value.Trim() == val.Trim())
                    {
                        return ddl.Items[i].Text;
                    }
                }
            }
            catch (Exception)
            {
                return " ";
            }
        }
        return " ";
    }

    public static void GetSearch(SmartGridView gv)
    {
    }

    public static DataSet GetSearchControlDataSet(string[] names)
    {
        DataSet set = new DataSet();
        DataTable table = new DataTable();
        for (int i = 0; i < names.Length; i++)
        {
            DataColumn column = new DataColumn {
                ColumnName = names[i]
            };
            table.Columns.Add(column);
        }
        set.Tables.Add(table);
        return set;
    }

    public static string GetServiceUserType(string str)
    {
        try
        {
            if (str.Trim() != "")
            {
                switch (((ServicesAddessTypeEnum) Enum.Parse(typeof(ServicesAddessTypeEnum), str)))
                {
                    case ServicesAddessTypeEnum.InPage:
                        return "站内服务";

                    case ServicesAddessTypeEnum.Dll:
                        return "动态链接库服务";

                    case ServicesAddessTypeEnum.WebServices:
                        return "Web服务";

                    case ServicesAddessTypeEnum.OutPage:
                        return "站外服务";
                }
                return "";
            }
            return str;
        }
        catch (Exception)
        {
            return "未知";
        }
    }

    public static string GetSqlStringFromDataSet(DataSet ds, int colnum)
    {
        string str = "";
        if ((ds.Tables[0].Rows.Count > 0) && (ds != null))
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str = str + "'" + ds.Tables[0].Rows[i][colnum].ToString().Trim() + "',";
            }
        }
        if (str != "")
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }

    public static string GetSqlStringFromDataSet(DataSet ds, string colname)
    {
        string str = "";
        if ((ds.Tables[0].Rows.Count > 0) && (ds != null))
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str = str + "'" + ds.Tables[0].Rows[i][colname].ToString().Trim() + "',";
            }
        }
        if (str != "")
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }

    public static string Money_CutString(object obj)
    {
        string str = "";
        if ((obj != null) && (obj.ToString().Trim() != ""))
        {
            str = decimal.Parse(obj.ToString()).ToString("N1");
        }
        return str;
    }

    public static string Str_GetIsApp(object obj)
    {
        string str = "";
        if ((obj == null) || (obj.ToString().Trim() == ""))
        {
            return str;
        }
        if (obj.ToString() == "0")
        {
            return "未审批";
        }
        if (obj.ToString() == "1")
        {
            return "已审批";
        }
        return "审批未通过";
    }

    public static string Str_GetIsHave(string str)
    {
        string str2 = "";
        if ((str != "") && (str != null))
        {
            if (str == "0")
            {
                return "无";
            }
            if (str == "1")
            {
                str2 = "有";
            }
        }
        return str2;
    }

    public static string Str_GetIsNum(string str)
    {
        string str2 = "";
        if ((str != "") && (str != null))
        {
            if (str == "0")
            {
                return "否";
            }
            if (str == "1")
            {
                str2 = "是";
            }
        }
        return str2;
    }

    public static string Str_GetIsOver(object obj)
    {
        string str = "";
        if ((obj == null) || (obj.ToString().Trim() == ""))
        {
            return str;
        }
        if (obj.ToString() == "0")
        {
            return "未完成";
        }
        return "已完成";
    }

    public static string Str_GetIsPass(object obj)
    {
        string str = "";
        if (obj == null)
        {
            return str;
        }
        if (obj.ToString() == "1")
        {
            return "已通过";
        }
        if (obj.ToString() == "0")
        {
            return "未通过";
        }
        return "";
    }

    public static string Str_GetIsShow(string str)
    {
        string str2 = "";
        if ((str != "") && (str != null))
        {
            if (str == "0")
            {
                return "不显示";
            }
            if (str == "1")
            {
                str2 = "显示";
            }
        }
        return str2;
    }

    public static string Str_GetIsYes(string str)
    {
        string str2 = "";
        if ((str != "") && (str != null))
        {
            if (str == "N")
            {
                return "否";
            }
            if (str == "Y")
            {
                str2 = "是";
            }
        }
        return str2;
    }

    public static string Str_GetSex(string str)
    {
        string str2 = "";
        if ((str == "") || (str == null))
        {
            return str2;
        }
        if (str == "0")
        {
            return "女";
        }
        return "男";
    }

    public static string Str_GetStartSign(string str)
    {
        string str2 = "";
        if ((str != "") && (str != null))
        {
            if (str == "0")
            {
                return "未启用";
            }
            if (str == "1")
            {
                str2 = "启用";
            }
        }
        return str2;
    }

    public static string Str_Myleft(string str, int _int)
    {
        if (((str != "") && (str != null)) && (str.Length > _int))
        {
            str = CheckChar.CutStr_New(str, _int) + "……";
        }
        return str;
    }

    public static void TieButton(Page page, Control TextBoxToTie, Control ButtonToTie)
    {
        string str = "";
        if (ButtonToTie is LinkButton)
        {
            str = "if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)) {" + page.ClientScript.GetPostBackEventReference(ButtonToTie, "").Replace(":", "$") + ";return false;} else return true;";
        }
        else if (ButtonToTie is ImageButton)
        {
            str = "if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)) {" + page.ClientScript.GetPostBackEventReference(ButtonToTie, "").Replace(":", "$") + ";return false;} else return true;";
        }
        else
        {
            str = "if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)) {document.forms[0].elements['" + ButtonToTie.UniqueID.Replace(":", "_") + "'].click();return false;} else return true; ";
        }
        if (TextBoxToTie is HtmlControl)
        {
            ((HtmlControl) TextBoxToTie).Attributes.Add("onkeydown", str);
        }
        else if (TextBoxToTie is WebControl)
        {
            ((WebControl) TextBoxToTie).Attributes.Add("onkeydown", str);
        }
    }
}

