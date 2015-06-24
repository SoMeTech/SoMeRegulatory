namespace BHSoft.BHWeb.Common.Configuration
{
    using BHSoft.BHWeb.Common;
    using BHSoft.BHWeb.Common.CommonClasses;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Configuration;
    using System.Web;
    using System.Web.Caching;
    using System.Xml;

    public class ModuleConfig
    {
        protected string cacheKey;
        private string Key_PageImages;
        private string Key_PageUrls;
        private string Key_Settings;
        private string Tag_HostName;
        private string Tag_SubFloder;

        public ModuleConfig()
        {
            this.cacheKey = "";
            this.Key_Settings = "/ModuleConfig/Settings/Add";
            this.Key_PageUrls = "/ModuleConfig/PageUrls/Url";
            this.Key_PageImages = "/ModuleConfig/PageImages/Image";
            this.Tag_HostName = "$hostname$";
            this.Tag_SubFloder = "$SubFloder$";
            string className = TypeDescriptor.GetClassName(this);
            int num = className.LastIndexOf(".");
            if (num > 0)
            {
                this.cacheKey = className.Substring(num + 1, (className.Length - num) - 1);
            }
            else
            {
                this.cacheKey = "ModuleConfig";
            }
        }

        public ModuleConfig(string key)
        {
            this.cacheKey = "";
            this.Key_Settings = "/ModuleConfig/Settings/Add";
            this.Key_PageUrls = "/ModuleConfig/PageUrls/Url";
            this.Key_PageImages = "/ModuleConfig/PageImages/Image";
            this.Tag_HostName = "$hostname$";
            this.Tag_SubFloder = "$SubFloder$";
            string className = TypeDescriptor.GetClassName(this);
            int num = className.LastIndexOf(".");
            if (num > 0)
            {
                this.cacheKey = className.Substring(num + 1, (className.Length - num) - 1);
            }
            else
            {
                this.cacheKey = "ModuleConfig";
            }
            if (!key.Equals(""))
            {
                this.cacheKey = this.cacheKey + "_" + key;
            }
        }

        protected virtual Hashtable GetConfigInfo(string name)
        {
            Cache cache = HttpContext.Current.Cache;
            Hashtable hashtable = HttpContext.Current.Cache[this.cacheKey + name] as Hashtable;
            if (hashtable == null)
            {
                hashtable = new Hashtable();
                string filename = CommonUtil.GetWebPath() + ConfigurationManager.AppSettings[this.cacheKey].ToString();
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                XmlNodeList list = document.SelectNodes(name);
                string newValue = "";
                foreach (XmlNode node in list)
                {
                    Hashtable hashtable2 = new Hashtable();
                    if (node.ChildNodes.Count == 0)
                    {
                        string strKey = node.Attributes["value"].Value;
                        string key = node.Attributes["key"].Value;
                        if (name == this.Key_PageUrls)
                        {
                            if (key == "SubFloder")
                            {
                                newValue = CommonUtil.GetSubFloder(strKey);
                            }
                            if (((key == "Images") || (key == "Styles")) || (((key == "Javascript") || (key == "AJax")) || key.StartsWith("Manager")))
                            {
                                strKey = strKey.Replace(this.Tag_HostName, CommonUtil.HostName).Replace(this.Tag_SubFloder, newValue);
                            }
                            else
                            {
                                strKey = strKey.Replace(this.Tag_HostName, CommonUtil.HostName).Replace(this.Tag_SubFloder, newValue + "/websource");
                            }
                            if (strKey.EndsWith(".htm"))
                            {
                                strKey = strKey.Replace(".htm", ".aspx");
                            }
                        }
                        hashtable.Add(key, strKey);
                    }
                    else
                    {
                        foreach (XmlNode node2 in node.ChildNodes)
                        {
                            hashtable2.Add(node2.LocalName, node2.Value);
                        }
                        hashtable.Add(node.Attributes["key"].Value, hashtable2);
                    }
                }
                HttpContext.Current.Cache.Add(this.cacheKey + name, hashtable, new CacheDependency(filename), DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
            }
            return hashtable;
        }

        public void SetXMLValue(string strXPath, string strValue, string strKey)
        {
            string filename = CommonUtil.GetWebPath() + ConfigurationManager.AppSettings[this.cacheKey].ToString();
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            log.DebugLog(strXPath);
            XmlNode node = document.SelectSingleNode(strXPath);
            if (node != null)
            {
                if ((strKey != null) && (strKey.Length != 0))
                {
                    node.Attributes[strKey].Value = strValue;
                }
                else
                {
                    node.InnerText = strValue;
                }
                document.Save(filename);
            }
        }

        public Hashtable PageImages
        {
            get
            {
                return this.GetConfigInfo(this.Key_PageImages);
            }
        }

        public Hashtable PageUrls
        {
            get
            {
                return this.GetConfigInfo(this.Key_PageUrls);
            }
        }

        public Hashtable Settings
        {
            get
            {
                return this.GetConfigInfo(this.Key_Settings);
            }
        }
    }
}

