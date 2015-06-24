using SoMeTech.CommonDll;
using System;
using System.Web;
using System.Web.Services;

[WebService(Namespace="http://tempuri.org/"), WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
public class FileUploadService : WebService
{
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public void Upload()
    {
        StateInfo o = new StateInfo();
        HttpRequest request = HttpContext.Current.Request;
        string str = "";
        string str2 = "";
        str = request["name"].ToString();
        string imgType = request["ImgType"].ToString();
        HttpPostedFile file = request.Files[str];
        if (str == "FileUpload")
        {
            str2 = request.Params["txtOrignalUrl"];
        }
        else
        {
            str2 = request.Params["txtOrignalUrl1"];
        }
        if (file == null)
        {
            o.State = 0;
            o.Info = "请选择要上传的文件";
        }
        o = new HttpFileUpload().FileSaveAs(file, false, imgType);
        if (!string.IsNullOrEmpty(str2))
        {
            try
            {
                str2 = "../../" + str2;
                Utils.FileDelete(HttpContext.Current.Server.MapPath(str2));
            }
            catch
            {
            }
        }
        JSONHelper.Write(JSONHelper.Convert2Json(o));
    }
}

