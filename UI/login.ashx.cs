
using System;
using System.Web;

public class login_page : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {

        string response_str = "false";
        string username = context.Server.UrlDecode(context.Request["username"]);
       
        if (username != null)
        {
            string userCompany = UserBll.GetUserCompany(username);
            if (userCompany == "false")
            {
                response_str = "false";
            }
            response_str = userCompany;
        }


        context.Response.ContentType = "text/plain";
        context.Response.Write(response_str);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}