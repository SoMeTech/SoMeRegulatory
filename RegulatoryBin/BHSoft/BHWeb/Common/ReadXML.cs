namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Xml;

    public class ReadXML
    {
        public string BackUpDB = string.Empty;
        public string backupsql2000 = "/BackUpDB/";
        public string Dbase = string.Empty;
        public string DBserver = string.Empty;
        public string DbUserId = string.Empty;
        public string DbUserPSW = string.Empty;
        public string encryptKey = string.Empty;
        public int middlePicHeight = 340;
        public int middlePicWidth = 400;
        public int midPoductPicHeight = 340;
        public int midPoductPicWidth = 400;
        private string myKey = string.Empty;
        public int PageNo;
        public string pass = string.Empty;
        public int smallPicHeight = 0x6c;
        public int smallPicWidth = 140;
        public int smallPoductPicHeight = 80;
        public int smallPoductPicWidth = 100;
        public int totalpage;
        public int xmlAdmin_Article_PageSize = 10;
        public string xmlSiteName = string.Empty;

        public ReadXML()
        {
            this.xmlSiteName = ConfigurationManager.AppSettings["SiteName"];
            this.pass = ConfigurationManager.AppSettings["pass"];
            this.xmlAdmin_Article_PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["Admin_Article@PageSize"]);
            this.smallPicWidth = Convert.ToInt32(ConfigurationManager.AppSettings["smallPicWidth"]);
            this.smallPicHeight = Convert.ToInt32(ConfigurationManager.AppSettings["smallPicHeight"]);
            this.middlePicWidth = Convert.ToInt32(ConfigurationManager.AppSettings["middlePicWidth"]);
            this.middlePicHeight = Convert.ToInt32(ConfigurationManager.AppSettings["middlePicHeight"]);
            this.smallPoductPicWidth = Convert.ToInt32(ConfigurationManager.AppSettings["smallPoductPicWidth"]);
            this.smallPoductPicHeight = Convert.ToInt32(ConfigurationManager.AppSettings["smallPoductPicHeight"]);
            this.midPoductPicWidth = Convert.ToInt32(ConfigurationManager.AppSettings["midPoductPicWidth"]);
            this.midPoductPicHeight = Convert.ToInt32(ConfigurationManager.AppSettings["midPoductPicHeight"]);
            this.myKey = Convert.ToString(ConfigurationManager.AppSettings["encryptKey"]);
            if ((this.myKey == "") || (this.myKey == null))
            {
                this.encryptKey = "1234567890";
            }
            else
            {
                this.encryptKey = this.myKey;
            }
            string str = Convert.ToString(ConfigurationManager.AppSettings["BackUpDB"]);
            switch (str)
            {
                case "":
                case null:
                    this.BackUpDB = "/BackUpDB/";
                    break;

                default:
                    this.BackUpDB = str;
                    break;
            }
            this.DBserver = Convert.ToString(ConfigurationManager.AppSettings["DBserver"]);
            this.Dbase = Convert.ToString(ConfigurationManager.AppSettings["Dbase"]);
            this.DbUserId = Convert.ToString(ConfigurationManager.AppSettings["DbUserId"]);
            this.DbUserPSW = Convert.ToString(ConfigurationManager.AppSettings["DbUserPSW"]);
        }

        public static void SaveSetting(string strKeyName, string strKeyValue)
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath("/web.config"));
            XmlNodeList childNodes = document.SelectSingleNode("//appSettings").ChildNodes;
            try
            {
                foreach (XmlNode node in childNodes)
                {
                    XmlElement element = (XmlElement) node;
                    if (element.Attributes["key"].InnerText == strKeyName)
                    {
                        element.Attributes["value"].InnerText = strKeyValue;
                        document.Save(HttpContext.Current.Server.MapPath("/web.config"));
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

