namespace BHSoft.BHWeb.Common
{
    using BHSoft.BHWeb.Common.CommonClasses;
    using System;
    using System.Reflection;
    using System.Web;

    public class Const
    {
        public const string COOKIE_KEY_USERID = "UserID";
        public const string COOKIE_KEY_USERNAME = "UserName";
        public const int LOG_DEBUG = 3;
        public const int LOG_ERROR = 1;
        public const int LOG_INFO = 2;
        public const int LOG_NONE = 0;

        public static string ApplicationName
        {
            get
            {
                log.DebugLog(AppDomain.CurrentDomain.SetupInformation.ApplicationName);
                return AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            }
        }

        public static string DB_Conn_Key
        {
            get
            {
                string message = "DB_Conn_Key_" + ApplicationName;
                string str2 = "";
                HttpContext current = HttpContext.Current;
                if ((current != null) && (current.Session["Page_Key"] != null))
                {
                    str2 = current.Session["Page_Key"].ToString();
                }
                if (str2.Trim().Length != 0)
                {
                    message = message + "_" + str2;
                }
                log.DebugLog(message);
                return message;
            }
        }

        public static string EntryAssemblyFullName
        {
            get
            {
                string str = Assembly.GetEntryAssembly().ToString();
                return str.Substring(0, str.IndexOf(", "));
            }
        }
    }
}

