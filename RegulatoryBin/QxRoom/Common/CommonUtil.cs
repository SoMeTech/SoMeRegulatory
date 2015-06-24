namespace QxRoom.Common
{
    using QxRoom.Common.Configuration;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Security;

    public class CommonUtil
    {
        public static object DBThread = new object();
        private static string m_DbPassword = "hailsoft()!#$";
        private static string m_hostname = "";
        private static string m_path = "";
        private static string m_urlName = "";
        private static CacheItemRemovedCallback onRemove = null;

        public static string FormatForXML(object input)
        {
            return input.ToString().Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br>");
        }

        public static string GetMD5(string s)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
        }

        public static string GetSubFloder(string strKey)
        {
            string str = (HttpContext.Current.Request.ApplicationPath + strKey).Replace("//", "/");
            if (str.EndsWith("/"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            if (!str.StartsWith("/") && (str.Length > 0))
            {
                str = "/" + str;
            }
            Log.DebugLog("SubFloder: " + str);
            return str;
        }

        public static string GetWebPath()
        {
            HttpContext current = HttpContext.Current;
            string filename = "/";
            try
            {
                filename = current.Request.ApplicationPath;
            }
            catch
            {
            }
            return GetWebPath(filename);
        }

        public static string GetWebPath(string filename)
        {
            HttpContext current = HttpContext.Current;
            string path = filename;
            string str2 = current.Server.MapPath(path);
            if ((str2.Length > 0) && (str2.Substring(str2.Length - 1, 1) != @"\"))
            {
                str2 = str2 + @"\";
            }
            return str2;
        }

        public static IDbConnection OpenDataBase()
        {
            IDbConnection connection = null;
            try
            {
                Log.TraceLog("★★★★★★正在等待打开数据库!!!★★★★★★");
                lock (DBThread)
                {
                    HttpContext current = HttpContext.Current;
                    if (current.Cache[Const.DB_Conn_Key] == null)
                    {
                        onRemove = new CacheItemRemovedCallback(CommonUtil.RemovedCallback);
                        string key = "";
                        if (current.Session["Page_Key"] != null)
                        {
                            key = current.Session["Page_Key"].ToString();
                        }
                        ModuleConfig config = new ModuleConfig(key);
                        string connectionString = string.Format(config.Settings["ConnStrWebSite"].ToString(), GetWebPath(), m_DbPassword);
                        Log.TraceLog("★★★★★★开始创建数据库对象!!!★★★★★★");
                        Log.DebugLog("数据库：" + connectionString);
                        connection = new OleDbConnection(connectionString);
                        Log.TraceLog("★★★★★★开始打开数据库!!!★★★★★★");
                        if (connection != null)
                        {
                            connection.Open();
                        }
                        current.Cache.Add(Const.DB_Conn_Key, connection, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, onRemove);
                    }
                    else
                    {
                        connection = (IDbConnection) current.Cache[Const.DB_Conn_Key];
                    }
                    Log.TraceLog("★★★★★★数据库已经打开!!!★★★★★★");
                }
            }
            catch (Exception exception)
            {
                Log.ErrorLog(exception);
                if (connection != null)
                {
                    Log.ErrorLog("数据库的状态为：" + connection.State.ToString());
                    connection.Close();
                    connection = null;
                }
            }
            return connection;
        }

        public static string PostForm(string url, Hashtable hash, ref CookieCollection cookies)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DictionaryEntry entry in hash)
            {
                builder.Append(entry.Key);
                builder.Append("=");
                builder.Append(HttpUtility.UrlEncode(entry.Value.ToString(), Encoding.GetEncoding("GB2312")));
                builder.Append("&");
            }
            string str = builder.ToString();
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.Referer = url;
                request.AllowAutoRedirect = false;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.01; Windows NT 5.0)";
                request.Method = "POST";
                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = str.Length;
                request.CookieContainer = new CookieContainer();
                if (cookies != null)
                {
                    request.CookieContainer.Add(cookies);
                }
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(str);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = null;
                reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                if (cookies == null)
                {
                    cookies = response.Cookies;
                }
                string str2 = reader.ReadToEnd();
                reader.Close();
                return str2;
            }
            catch
            {
                return "";
            }
        }

        public static void RemovedCallback(string k, object v, CacheItemRemovedReason r)
        {
            Log.TraceLog("★★★★★★Cache中的数据库对象被移除！★★★★★★");
            Log.TraceLog("移除的原因为：" + r.ToString());
            try
            {
                if (v != null)
                {
                    if (v is IDbConnection)
                    {
                        IDbConnection connection = v as IDbConnection;
                        if (connection != null)
                        {
                            connection.Close();
                            connection = null;
                            Log.TraceLog("★★★★★★数据库正常关闭！！！★★★★★★");
                        }
                        else
                        {
                            Log.TraceLog("★★★★★★数据库已经关闭！！！★★★★★★");
                        }
                    }
                    else
                    {
                        Log.TraceLog("★★★★★★数据库已经关闭！！！★★★★★★");
                    }
                }
                else
                {
                    Log.TraceLog("★★★★★★不是数据库对象，无法关闭★★★★★★");
                }
            }
            catch (Exception exception)
            {
                Log.ErrorLog("★★★★★★数据库关闭发生错误！！！★★★★★★");
                Log.ErrorLog(exception.Message);
            }
        }

        public static void SetDBPassword(string strPassword)
        {
            m_DbPassword = strPassword;
        }

        public static string HostName
        {
            get
            {
                if (m_hostname.Length == 0)
                {
                    string str = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
                    if (str.EndsWith("/"))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    m_hostname = str;
                    Log.DebugLog("HostName: " + m_hostname);
                }
                return m_hostname;
            }
        }

        public static string Path
        {
            get
            {
                if (m_path.Length == 0)
                {
                    m_path = UrlName;
                }
                return m_path;
            }
        }

        public static string UrlName
        {
            get
            {
                if (m_urlName.Length == 0)
                {
                    HttpContext current = HttpContext.Current;
                    string str = "http://" + current.Request.ServerVariables["SERVER_NAME"] + current.Request.ApplicationPath;
                    if (!str.EndsWith("/"))
                    {
                        str = str + "/";
                    }
                    m_urlName = str;
                }
                return m_urlName;
            }
        }
    }
}

