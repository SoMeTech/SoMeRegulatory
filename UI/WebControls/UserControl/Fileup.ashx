<%@ WebHandler Language="C#" Class="Fileup" Debug="true"%>

using System;
using System.Web;
using System.IO;


public class Fileup : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string str1 = "";
        string str2 = "";
        string rvalue = "";
        try
        {
            HttpFileCollection fileList = context.Request.Files;
            //HttpFileCollection fileList = HttpContext.Current.Request.Files;
            for (int i = 0; i < fileList.Count; i++)
            {
                HttpPostedFile hPostedFile = fileList[i];
                string filename = "";
                string filepath = "";
                if (hPostedFile.ContentLength > 0 && hPostedFile.FileName.Length > 0)
                {

                    //float zldx = hPostedFile.ContentLength / 1024;
                    filename = hPostedFile.FileName;

                    int k = filename.LastIndexOf(".");
                    int j = filename.LastIndexOf("\\");
                    string type = filename.Substring(k + 1);
                    //filename = filename.Substring(j + 1, k - j - 1);
                    filename = filename.Substring(j + 1);
                    DateTime datetime1 = System.DateTime.Now;
                    type = type.ToLower();

                    filepath = Guid.NewGuid().ToString("N") + "." + type;
                    string serverPath = System.Web.HttpContext.Current.Server.MapPath("upfile\\" + filepath);
                    if (context.Request["temp"] != null)
                        serverPath = System.Web.HttpContext.Current.Server.MapPath("~/" + "temp/" + filepath);

                    if (context.Request["filepath"] != null && context.Request["filepath"].Trim().Length!=0)
                        //serverPath = System.Web.HttpContext.Current.Server.MapPath("~/" + "/" + context.Request["filepath"] + "/" + filename);
                        serverPath = System.Web.HttpContext.Current.Server.MapPath("~/" + "/" + context.Request["filepath"] + "/" + filepath);
                    
                    hPostedFile.SaveAs(serverPath);
                    if (str1 == "")
                        str1 = filepath;
                    else
                        str1 += "," + filepath;
                    if (str2 == "")
                    {
                        str2 += filename;
                    }
                    else
                        str2 += "," + filename;
                }
            }
            if (str1.Length > 0)
            {
                //context.Response.Write(str1 + "&" + str2);
                rvalue = str1;
                //插入图片保存到数据库中
                //插入图片
                //string strSql = "insert into t_photos (photoid, fkid, photoname, photopath, remarks, sortid) values  (T_PHOTOS_SEQ.NEXTVAL, 'ssXCMX_" + model.AUTO_NO + "', 'a.jpg', 'c:\\', '', 1); ";
            }
            else
            {
                rvalue = "000";
                
            }
        }
        catch (Exception e)
        {
            rvalue = "001";
        }
        finally
        {
            ;
        }
        
        context.Response.Expires = -1;
        context.Response.Clear();
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        context.Response.ContentType = "text/plain";
        //context.Response.Write("<script type='text/javascript'>parent.finish('" + rvalue + "');</script>");
        context.Response.Write("@returnstart@" + rvalue + "@returnend@");
        context.Response.End();
        
       
      //string strSql = "select photoid, fkid, photoname, photopath, remarks, sortid from t_photos where fkID ='ssXCMX_"+model.AUTO_NO+"'";
      ////插入图片
      //string strSql = "insert into t_photos (photoid, fkid, photoname, photopath, remarks, sortid) values  (T_PHOTOS_SEQ.NEXTVAL, 'ssXCMX_"+model.AUTO_NO+"', 'a.jpg', 'c:\\', '', 1); ";

        
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}