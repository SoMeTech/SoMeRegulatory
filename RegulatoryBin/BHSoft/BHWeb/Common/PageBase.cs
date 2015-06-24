namespace BHSoft.BHWeb.Common
{
    using BHSoft.BHWeb.Common.CommonClasses;
    using System;
    using System.ComponentModel;
    using System.Web;
    using System.Web.UI;

    public class PageBase : Page
    {
        private static string basePathPrefix;
        private const string KEY_root = "www.geautos.com";
        private const string UNHANDLED_EXCEPTION = "Unhandled Exception:";

        protected override void OnError(EventArgs e)
        {
            log.ErrorLog("出现错误: Unhandled Exception:");
            base.OnError(e);
        }

        [Browsable(false)]
        public static string PathPrefix
        {
            get
            {
                if ((basePathPrefix == null) && (HttpContext.Current != null))
                {
                    basePathPrefix = UrlBase;
                }
                return basePathPrefix;
            }
            set
            {
                basePathPrefix = value;
            }
        }

        public static string SecureUrlBase
        {
            get
            {
                return ("https://" + UrlSuffix);
            }
        }

        public static string UrlBase
        {
            get
            {
                return ("http://" + UrlSuffix);
            }
        }

        private static string UrlSuffix
        {
            get
            {
                return (HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath);
            }
        }
    }
}

