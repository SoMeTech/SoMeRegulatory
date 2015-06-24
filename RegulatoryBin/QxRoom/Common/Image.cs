namespace QxRoom.Common
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;

    public sealed class Image
    {
        public static void CreatSmallPic(string pic_path, string pic_path0, int width, int height)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(pic_path);
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

        public static string SaveSmallImage(HtmlInputFile File1, string SaveFileFolder)
        {
            string str = string.Empty;
            if (File1.Value != "")
            {
                string extension = Path.GetExtension(File1.Value);
                string str3 = Guid.NewGuid().ToString("n");
                string str4 = str3 + extension;
                string str5 = str3 + "_s" + extension;
                string path = HttpContext.Current.Server.MapPath(SaveFileFolder) + str4;
                string str7 = HttpContext.Current.Server.MapPath(SaveFileFolder) + str5;
                string str8 = SaveFileFolder + str5;
                if (File.Exists(path))
                {
                    Public.Show("已存在相同文件名,请重新上传JPG图片!");
                    return str;
                }
                ReadXML dxml = new ReadXML();
                string str9 = HttpContext.Current.Server.MapPath(SaveFileFolder);
                if (!Directory.Exists(str9))
                {
                    Directory.CreateDirectory(str9);
                }
                File1.PostedFile.SaveAs(path);
                CreatSmallPic(path, str7, dxml.smallPicWidth, dxml.smallPicHeight);
                str = str8;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            return str;
        }

        public static DataTable UpImages(HttpFileCollection hfc, string[] picMess)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("PicType", Type.GetType("System.String")));
            table.Columns.Add(new DataColumn("PicUrl", Type.GetType("System.String")));
            table.Columns.Add(new DataColumn("middlePicPath", Type.GetType("System.String")));
            table.Columns.Add(new DataColumn("smallPicPath", Type.GetType("System.String")));
            foreach (HtmlInputFile file in hfc)
            {
                if (file.PostedFile.FileName != string.Empty)
                {
                    if (Public.IsAllowedExtension(file))
                    {
                        string path = file.Value;
                        string str2 = Path.GetExtension(path).ToLower();
                        string str3 = Guid.NewGuid().ToString("b");
                        string str4 = str3 + str2;
                        string str5 = str3 + "_m" + str2;
                        string str6 = str3 + "_s" + str2;
                        string str7 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\" + picMess[0];
                        file.PostedFile.SaveAs(str7 + str4);
                        CreatSmallPic(path, str7 + str5, int.Parse(picMess[1]), int.Parse(picMess[2]));
                        CreatSmallPic(path, str7 + str6, int.Parse(picMess[3]), int.Parse(picMess[4]));
                        DataRow row = table.NewRow();
                        row["PicType"] = str2;
                        row["PicUrl"] = picMess[0] + str4;
                        row["middlePicPath"] = picMess[0] + str5;
                        row["smallPicPath"] = picMess[0] + str6;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        Public.Show("图片格式不正确！");
                    }
                }
            }
            return table;
        }
    }
}

