<%@ WebHandler Language="C#" Class="getData" %>

using System;
using System.Web;

public class getData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write(SoMeTech.CommonDll.PublicDal.DataToJSON(SoMeTech.CommonDll.PublicDal.GetPDBaseValues("DB_Company", "PK_CORP,NAME", " ishasbaby=0 order by pk_corp")));

        string LoginCompany = context.Request["LoginCompany"];
        if (LoginCompany != null)
            context.Response.Write(SoMeTech.CommonDll.PublicDal.DataToJSON(SoMeTech.CommonDll.PublicDal.GetPDBaseValues("DB_Company", "PK_CORP,NAME", " PK_CORP like '" + LoginCompany + "%' and ishasbaby=0 order by pk_corp")));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}