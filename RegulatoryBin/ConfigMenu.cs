using QxRoom.QxXml;
using System;
using System.Web;

public sealed class ConfigMenu
{
    public static string MenuName = "瘦马科技";
    public static string MenuUrl = "";
    public static string Type = "1";

    public static void SetConfig()
    {
        QxXmlDocument document = new QxXmlDocument(HttpContext.Current.Server.MapPath("~") + @"\Menu\MenuConfig.xml");
        Type = document.GetNodeString("root/menutype", 0);
        MenuName = document.GetNodeString("root/menutree", 0);
        MenuUrl = document.GetNodeString("root/menuurl", 0);
    }
}

