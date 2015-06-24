namespace BHSoft.BHWeb.Common.CommonClasses
{
    using log4net;
    using System;
    using System.Web;

    public class log
    {
        private static ILog _log;

        public static void DebugLog(string message)
        {
            if (_log != null)
            {
                _log.Debug(message);
            }
        }

        public static void DebugLog(string method, string message)
        {
            if (_log != null)
            {
                _log.Debug("[" + method + "] " + message);
            }
        }

        public static void ErrorLog(Exception ex)
        {
            if (_log != null)
            {
                _log.Error(ex.Message);
                _log.Error(ex.StackTrace);
            }
        }

        public static void ErrorLog(string message)
        {
            if (_log != null)
            {
                _log.Error(message);
            }
        }

        public static void ErrorLog(string method, string message)
        {
            if (_log != null)
            {
                _log.Error("[" + method + "] " + message);
            }
        }

        public static string GetIp()
        {
            string str2;
            string str = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (((str2 = str) != null) && !(str2 == ""))
            {
                return str;
            }
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static void InsertLog(string key)
        {
            _log = LogManager.GetLogger(key);
            _log.Debug("★★★★★★★★★★★★新的日志开始记录★★★★★★★★★★★★");
        }

        public static void TraceLog(string message)
        {
            if (_log != null)
            {
                _log.Info(message);
            }
        }

        public static void TraceLog(string method, string message)
        {
            if (_log != null)
            {
                _log.Info("[" + method + "] " + message);
            }
        }
    }
}

