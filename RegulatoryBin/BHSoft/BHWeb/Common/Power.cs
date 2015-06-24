namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Web;

    public class Power
    {
        public static string ChangPowerStr(string str)
        {
            str = str.Replace("1_1", "文章栏目添加");
            str = str.Replace("1_2", "文章栏目删除");
            str = str.Replace("1_3", "文章栏目修改");
            str = str.Replace("2_1", "文章专题栏目添加");
            str = str.Replace("2_2", "文章专题栏目删除");
            str = str.Replace("2_3", "文章专题栏目修改");
            str = str.Replace("3_1", "文章查看");
            str = str.Replace("3_2", "文章添加");
            str = str.Replace("3_3", "文章删除");
            str = str.Replace("3_4", "文章修改");
            str = str.Replace("3_5", "文章审核");
            str = str.Replace("3_6", "文章评论管理");
            str = str.Replace("4_1", "产品类型添加");
            str = str.Replace("4_2", "产品类型删除");
            str = str.Replace("4_3", "产品类型修改");
            str = str.Replace("5_1", "产品添加");
            str = str.Replace("5_2", "产品删除");
            str = str.Replace("5_3", "产品修改");
            str = str.Replace("6_1", "角色配置");
            str = str.Replace("6_2", "添加用户");
            str = str.Replace("6_3", "角色变更");
            str = str.Replace("6_4", "删除用户");
            str = str.Replace("7_1", "备份数据库");
            str = str.Replace("7_2", "还原数据库");
            return str;
        }

        public static bool checkLoginTime()
        {
            bool flag = false;
            if (object.Equals(HttpContext.Current.Session["Logined_UserName"], null))
            {
                HttpContext.Current.Session.Remove("Logined_UserName");
                Location.LocationToPage("Please login", PageBase.UrlBase + "/Admin/Login.aspx");
                flag = true;
            }
            if (object.Equals(HttpContext.Current.Session["Logined_RoleID"], null))
            {
                HttpContext.Current.Session.Remove("Logined_RoleID");
                Location.LocationToPage("Please login", PageBase.UrlBase + "/Admin/Login.aspx");
                flag = true;
            }
            if (object.Equals(HttpContext.Current.Session["Logined_Power"], null))
            {
                HttpContext.Current.Session.Remove("Logined_Power");
                Location.LocationToPage("Please login", PageBase.UrlBase + "/Admin/Login.aspx");
                flag = true;
            }
            if (object.Equals(HttpContext.Current.Session["Logined_RoleName"], null))
            {
                HttpContext.Current.Session.Remove("Logined_RoleName");
                Location.LocationToPage("Please login", PageBase.UrlBase + "/Admin/Login.aspx");
                flag = true;
            }
            return flag;
        }

        public static bool checkLoginTime_CN()
        {
            bool flag = false;
            if (object.Equals(Utils.GetCookie("Logined_UserName"), ""))
            {
                Location.LocationToPage("登录超时，请重新登录管理后台", "/Admin/Login.aspx");
                flag = true;
            }
            if (object.Equals(Utils.GetCookie("Logined_RoleID"), ""))
            {
                Location.LocationToPage("登录超时，请重新登录管理后台", "/Admin/Login.aspx");
                flag = true;
            }
            if (object.Equals(Utils.GetCookie("Logined_Power"), ""))
            {
                Location.LocationToPage("登录超时，请重新登录管理后台", "/Admin/Login.aspx");
                flag = true;
            }
            if (object.Equals(Utils.GetCookie("Logined_RoleName"), ""))
            {
                Location.LocationToPage("登录超时，请重新登录管理后台", "/Admin/Login.aspx");
                flag = true;
            }
            return flag;
        }

        public static bool CheckPower(string InputStr, string Powerstr)
        {
            bool flag = false;
            if (Powerstr == "ALL")
            {
                return true;
            }
            if ((Powerstr == "") || (Powerstr == null))
            {
                return false;
            }
            string[] strArray = Powerstr.Split(new char[] { '|' });
            for (int i = 0; i <= (strArray.Length - 1); i++)
            {
                if (InputStr == strArray[i])
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool[] CheckUserPower(string Input)
        {
            bool[] flagArray = new bool[0x18];
            if (Input == "ALL")
            {
                for (int j = 0; j < 0x18; j++)
                {
                    flagArray[j] = true;
                }
            }
            string[] strArray = Input.Split(new char[] { '|' });
            for (int i = 0; i <= (strArray.Length - 1); i++)
            {
                if (strArray[i] == "1_1")
                {
                    flagArray[0] = true;
                }
                else if (strArray[i] == "1_2")
                {
                    flagArray[1] = true;
                }
                else if (strArray[i] == "1_3")
                {
                    flagArray[2] = true;
                }
                else if (strArray[i] == "2_1")
                {
                    flagArray[3] = true;
                }
                else if (strArray[i] == "2_2")
                {
                    flagArray[4] = true;
                }
                else if (strArray[i] == "2_3")
                {
                    flagArray[5] = true;
                }
                else if (strArray[i] == "3_1")
                {
                    flagArray[6] = true;
                }
                else if (strArray[i] == "3_2")
                {
                    flagArray[7] = true;
                }
                else if (strArray[i] == "3_3")
                {
                    flagArray[8] = true;
                }
                else if (strArray[i] == "3_4")
                {
                    flagArray[9] = true;
                }
                else if (strArray[i] == "3_5")
                {
                    flagArray[10] = true;
                }
                else if (strArray[i] == "3_6")
                {
                    flagArray[11] = true;
                }
                else if (strArray[i] == "4_1")
                {
                    flagArray[12] = true;
                }
                else if (strArray[i] == "4_2")
                {
                    flagArray[13] = true;
                }
                else if (strArray[i] == "4_3")
                {
                    flagArray[14] = true;
                }
                else if (strArray[i] == "5_1")
                {
                    flagArray[15] = true;
                }
                else if (strArray[i] == "5_2")
                {
                    flagArray[0x10] = true;
                }
                else if (strArray[i] == "5_3")
                {
                    flagArray[0x11] = true;
                }
                else if (strArray[i] == "6_1")
                {
                    flagArray[0x12] = true;
                }
                else if (strArray[i] == "6_2")
                {
                    flagArray[0x13] = true;
                }
                else if (strArray[i] == "6_3")
                {
                    flagArray[20] = true;
                }
                else if (strArray[i] == "6_4")
                {
                    flagArray[0x15] = true;
                }
                else if (strArray[i] == "7_1")
                {
                    flagArray[0x16] = true;
                }
                else if (strArray[i] == "7_2")
                {
                    flagArray[0x17] = true;
                }
            }
            return flagArray;
        }
    }
}

