using Synv.Common;
using System;
using System.IO;
using System.Web;

public class HttpFileUpload
{
    private WebSetInfo wsi;

    public HttpFileUpload()
    {
        string configFilePath = HttpContext.Current.Server.MapPath(@"Config\WebSet.config");
        this.wsi = new WebSetManager().LoadConfig(configFilePath);
    }

    private bool CheckFileExt(string _fileType, string _fileExt)
    {
        string[] strArray = _fileType.Split(new char[] { '|' });
        for (int i = 0; i < strArray.Length; i++)
        {
            if (strArray[i].ToLower() == _fileExt.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    public StateInfo FileSaveAs(HttpPostedFile _postedFile, bool _isWater, string ImgType)
    {
        StateInfo info = new StateInfo();
        try
        {
            string str = _postedFile.FileName.Substring(_postedFile.FileName.LastIndexOf(".") + 1);
            if (!this.CheckFileExt(this.wsi.WebFileType, str))
            {
                info.State = 0;
                info.Info = "不允许上传" + str + "类型的文件！";
            }
            if ((this.wsi.WebFileSize > 0) && (_postedFile.ContentLength > (this.wsi.WebFileSize * 0x400)))
            {
                info.State = 0;
                info.Info = "文件超过限制的大小啦！";
            }
            string str2 = DateTime.Now.ToString("yyyyMMddHHmmssff") + "." + str;
            if (!this.wsi.WebFilePath.StartsWith("jquery.easyui/"))
            {
                this.wsi.WebFilePath = "jquery.easyui/" + this.wsi.WebFilePath;
            }
            if (!this.wsi.WebFilePath.EndsWith("/"))
            {
                this.wsi.WebFilePath = this.wsi.WebFilePath + "/";
            }
            string str3 = ImgType + "/";
            this.wsi.WebFilePath = this.wsi.WebFilePath + str3;
            string imgPath = this.wsi.WebFilePath + str2;
            string path = HttpContext.Current.Server.MapPath(this.wsi.WebFilePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = path + str2;
            _postedFile.SaveAs(filename);
            if (((this.wsi.IsWatermark > 0) && _isWater) && this.CheckFileExt("BMP|JPEG|JPG|GIF|PNG|TIFF", str))
            {
                switch (this.wsi.IsWatermark)
                {
                    case 1:
                        ImageWaterMark.AddImageSignText(imgPath, this.wsi.WebFilePath + str2, this.wsi.WaterText, this.wsi.WatermarkStatus, this.wsi.ImgQuality, this.wsi.WaterFont, this.wsi.FontSize);
                        break;

                    case 2:
                        ImageWaterMark.AddImageSignPic(imgPath, this.wsi.WebFilePath + str2, this.wsi.ImgWaterPath, this.wsi.WatermarkStatus, this.wsi.ImgQuality, this.wsi.ImgWaterTransparency);
                        break;
                }
            }
            info.State = 1;
            info.Info = str3 + str2;
        }
        catch
        {
            info.State = 0;
            info.Info = "传过程中发生意外错误！";
        }
        return info;
    }
}

