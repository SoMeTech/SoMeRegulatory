namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;

    public class img
    {
        public static void pic_0(string pic_path, string pic_path0, int width, int height)
        {
            Image image = Image.FromFile(pic_path);
            int num = width;
            int num2 = height;
            int srcWidth = image.Width;
            int srcHeight = image.Height;
            int num5 = (num >= num2) ? num2 : num;
            if (srcWidth == srcHeight)
            {
                num = num2 = num5;
            }
            else if (srcWidth > srcHeight)
            {
                num2 = (num * srcHeight) / srcWidth;
                if (num2 > height)
                {
                    num2 = height;
                    num = (num2 * srcWidth) / srcHeight;
                }
            }
            else
            {
                num = (num2 * srcWidth) / srcHeight;
                if (num > width)
                {
                    num = width;
                    num2 = (num * srcHeight) / srcWidth;
                }
            }
            Bitmap bitmap = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            Rectangle destRect = new Rectangle(0, 0, num, num2);
            graphics.DrawImage(image, destRect, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
            bitmap.Save(pic_path0, ImageFormat.Jpeg);
            image.Dispose();
            graphics.Dispose();
            bitmap.Dispose();
        }

        public static string SaveSmallImages(HtmlInputFile File1, string SaveFileFolder)
        {
            string str = string.Empty;
            if (File1.Value != "")
            {
                string extension = Path.GetExtension(File1.Value);
                string str3 = Guid.NewGuid().ToString("n");
                string str4 = str3 + extension;
                string str5 = "s" + str3 + extension;
                string path = HttpContext.Current.Server.MapPath(SaveFileFolder) + str4;
                string str7 = HttpContext.Current.Server.MapPath(SaveFileFolder) + str5;
                string str8 = SaveFileFolder + str5;
                if (File.Exists(path))
                {
                    Location.MsgBox("已存在相同文件名,请重新上传JPG图片!");
                    return str;
                }
                ReadXML dxml = new ReadXML();
                string str9 = HttpContext.Current.Server.MapPath("UpFiles/");
                if (!Directory.Exists(str9))
                {
                    Directory.CreateDirectory(str9);
                }
                File1.PostedFile.SaveAs(path);
                pic_0(path, str7, dxml.smallPicWidth, dxml.smallPicHeight);
                str = str8;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            return str;
        }
    }
}

