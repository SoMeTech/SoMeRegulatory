<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        SoMeTech.CommonDll.GetSetXiangCunZu cl = new SoMeTech.CommonDll.GetSetXiangCunZu();
        string stype = context.Request["type"];
        if (stype.Equals("Xiang"))
        {
            
            context.Response.Write(cl.getZu(context.Request["Id"]));
        }
        else if (stype.Equals("Cun"))
        {
            context.Response.Write(cl.getCun(context.Request["Id"]));
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}