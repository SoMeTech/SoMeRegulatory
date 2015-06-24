namespace BHSoft.BHWeb.Common
{
    using System;

    public class Common_Login
    {
        public static void Check_Login(object str)
        {
            if (str == null)
            {
                Location.LocationToPage("登录超时!!!", PageBase.PathPrefix + "/admin/default.aspx");
            }
        }
    }
}

