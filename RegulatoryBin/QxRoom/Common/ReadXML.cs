namespace QxRoom.Common
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Xml;

    public class ReadXML
    {
        public string BackUpDB;
        public string backupsql2000;
        public string Dbase;
        public string DBserver;
        public string DbUserId;
        public string DbUserPSW;
        public string encryptKey;
        public int middlePicHeight;
        public int middlePicWidth;
        public int midPoductPicHeight;
        public int midPoductPicWidth;
        private string myKey;
        public int PageNo;
        public string pass;
        public int smallPicHeight;
        public int smallPicWidth;
        public int smallPoductPicHeight;
        public int smallPoductPicWidth;
        public int totalpage;
        public int xmlAdmin_Article_PageSize;
        public string xmlSiteName;

        public ReadXML()
        {
            string str2;
            this.BackUpDB = @"\BackUpDB\";
            this.backupsql2000 = @"\BackUpDB\";
            this.Dbase = string.Empty;
            this.DBserver = string.Empty;
            this.DbUserId = string.Empty;
            this.DbUserPSW = string.Empty;
            this.encryptKey = string.Empty;
            this.middlePicHeight = 340;
            this.middlePicWidth = 400;
            this.midPoductPicHeight = 340;
            this.midPoductPicWidth = 400;
            this.myKey = string.Empty;
            this.pass = string.Empty;
            this.smallPicHeight = 0x6c;
            this.smallPicWidth = 140;
            this.smallPoductPicHeight = 80;
            this.smallPoductPicWidth = 100;
            this.xmlAdmin_Article_PageSize = 10;
            this.xmlSiteName = string.Empty;
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
            if (((str2 = str) == null) || (str2 == ""))
            {
                this.BackUpDB = @"\BackUpDB\";
            }
            else
            {
                this.BackUpDB = str;
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

