namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;

    public class PicOperate
    {
        public void zzsCutImg(string ImgFile, string sImgPath, int PointX, int PointY, int CutWidth, int CutHeight)
        {
            try
            {
                FileStream input = new FileStream(ImgFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(input);
                byte[] buffer = reader.ReadBytes((int) input.Length);
                reader.Close();
                input.Close();
                MemoryStream stream = new MemoryStream(buffer);
                Image image = Image.FromStream(stream);
                Bitmap bitmap = new Bitmap(CutWidth, CutHeight, PixelFormat.Format24bppRgb);
                bitmap.SetResolution(72f, 72f);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, CutWidth, CutHeight), new Rectangle(PointX, PointY, CutHeight, CutHeight), GraphicsUnit.Pixel);
                bitmap.Save(sImgPath, ImageFormat.Jpeg);
                image.Dispose();
                graphics.Dispose();
                bitmap.Dispose();
            }
            catch
            {
            }
        }

        public void zzsImgTextWater(string ImgFile, string WaterImg, string TextFont, string sImgPath, float ImgAlpha, float imgiScale, int intimgDistance, float texthScale, float textwidthFont, int textAlpha)
        {
            try
            {
                FileStream input = new FileStream(ImgFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(input);
                byte[] buffer = reader.ReadBytes((int) input.Length);
                reader.Close();
                input.Close();
                MemoryStream stream = new MemoryStream(buffer);
                Image image = Image.FromStream(stream);
                int width = image.Width;
                int height = image.Height;
                Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bitmap.SetResolution(72f, 72f);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
                int[] numArray = new int[] { 
                    0x3e8, 800, 700, 650, 600, 560, 540, 500, 450, 400, 380, 360, 340, 320, 300, 280, 
                    260, 240, 220, 200, 180, 160, 140, 120, 100, 80, 0x48, 0x40, 0x30, 0x20, 0x1c, 0x1a, 
                    0x18, 20, 0x1c, 0x10, 14, 12, 10, 8, 6, 4, 2
                 };
                Font font = null;
                SizeF ef = new SizeF();
                for (int i = 0; i < 0x2b; i++)
                {
                    font = new Font("arial", (float) numArray[i], FontStyle.Bold);
                    ef = graphics.MeasureString(TextFont, font);
                    if (((ushort) ef.Width) < (((ushort) width) * textwidthFont))
                    {
                        break;
                    }
                }
                int num4 = (int) (height * texthScale);
                float y = (height - num4) - (ef.Height / 2f);
                float x = width / 2;
                StringFormat format = new StringFormat {
                    Alignment = StringAlignment.Center
                };
                SolidBrush brush = new SolidBrush(Color.FromArgb(textAlpha, 0, 0, 0));
                graphics.DrawString(TextFont, font, brush, new PointF(x + 1f, y + 1f), format);
                SolidBrush brush2 = new SolidBrush(Color.FromArgb(textAlpha, 0xff, 0xff, 0xff));
                graphics.DrawString(TextFont, font, brush2, new PointF(x, y), format);
                Image image2 = new Bitmap(WaterImg);
                int num7 = image2.Width;
                int num8 = image2.Height;
                decimal num9 = Convert.ToDecimal(imgiScale);
                decimal num10 = 0.05M;
                decimal num11 = num9 - num10;
                decimal num12 = num9 + num10;
                int num13 = num7;
                int num14 = num8;
                if (((width >= num7) && (height >= num8)) && (width >= height))
                {
                    if (num7 > num8)
                    {
                        if ((num11 > Math.Round((decimal) (Convert.ToDecimal(num7) / Convert.ToDecimal(width)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num7) / Convert.ToDecimal(width)), 7) > num12))
                        {
                            num13 = Convert.ToInt32((decimal) (width * num9));
                            num14 = Convert.ToInt32((decimal) (((width * num9) / num7) * num8));
                        }
                    }
                    else if ((num11 > Math.Round((decimal) (Convert.ToDecimal(num8) / Convert.ToDecimal(height)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num8) / Convert.ToDecimal(height)), 7) > num12))
                    {
                        num14 = Convert.ToInt32((decimal) (height * num9));
                        num13 = Convert.ToInt32((decimal) (((height * num9) / num8) * num7));
                    }
                }
                if (((num7 >= width) && (num8 >= height)) && (num7 >= num8))
                {
                    num13 = Convert.ToInt32((decimal) (width * num9));
                    num14 = Convert.ToInt32((decimal) (((width * num9) / num7) * num8));
                }
                if (((num7 >= width) && (num8 <= height)) && (width >= height))
                {
                    num13 = Convert.ToInt32((decimal) (width * num9));
                    num14 = Convert.ToInt32((decimal) (((width * num9) / num7) * num8));
                }
                if (((num7 <= width) && (num8 >= height)) && (width >= height))
                {
                    num14 = Convert.ToInt32((decimal) (height * num9));
                    num13 = Convert.ToInt32((decimal) (((height * num9) / num8) * num7));
                }
                if (((width >= num7) && (height >= num8)) && (width <= height))
                {
                    if (num7 > num8)
                    {
                        if ((num11 > Math.Round((decimal) (Convert.ToDecimal(num7) / Convert.ToDecimal(width)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num7) / Convert.ToDecimal(width)), 7) > num12))
                        {
                            num13 = Convert.ToInt32((decimal) (width * num9));
                            num14 = Convert.ToInt32((decimal) (((width * num9) / num7) * num8));
                        }
                    }
                    else if ((num11 > Math.Round((decimal) (Convert.ToDecimal(num8) / Convert.ToDecimal(height)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num8) / Convert.ToDecimal(height)), 7) > num12))
                    {
                        num14 = Convert.ToInt32((decimal) (height * num9));
                        num13 = Convert.ToInt32((decimal) (((height * num9) / num8) * num7));
                    }
                }
                if (((num7 >= width) && (num8 >= height)) && (num7 <= num8))
                {
                    num14 = Convert.ToInt32((decimal) (height * num9));
                    num13 = Convert.ToInt32((decimal) (((height * num9) / num8) * num7));
                }
                if (((num7 >= width) && (num8 <= height)) && (width <= height))
                {
                    num13 = Convert.ToInt32((decimal) (width * num9));
                    num14 = Convert.ToInt32((decimal) (((width * num9) / num7) * num8));
                }
                if (((num7 <= width) && (num8 >= height)) && (width <= height))
                {
                    num14 = Convert.ToInt32((decimal) (height * num9));
                    num13 = Convert.ToInt32((decimal) (((height * num9) / num8) * num7));
                }
                Bitmap bitmap2 = new Bitmap(bitmap);
                bitmap2.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                Graphics graphics2 = Graphics.FromImage(bitmap2);
                graphics2.InterpolationMode = InterpolationMode.High;
                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                ImageAttributes imageAttr = new ImageAttributes();
                ColorMap map = new ColorMap {
                    OldColor = Color.FromArgb(0xff, 0, 0xff, 0),
                    NewColor = Color.FromArgb(0, 0, 0, 0)
                };
                ColorMap[] mapArray = new ColorMap[] { map };
                imageAttr.SetRemapTable(mapArray, ColorAdjustType.Bitmap);
                float[][] numArray2 = new float[5][];
                float[] numArray3 = new float[5];
                numArray3[0] = 1f;
                numArray2[0] = numArray3;
                numArray3 = new float[5];
                numArray3[1] = 1f;
                numArray2[1] = numArray3;
                numArray3 = new float[5];
                numArray3[2] = 1f;
                numArray2[2] = numArray3;
                numArray3 = new float[5];
                numArray3[3] = ImgAlpha;
                numArray2[3] = numArray3;
                numArray3 = new float[5];
                numArray3[4] = 1f;
                numArray2[4] = numArray3;
                float[][] newColorMatrix = numArray2;
                ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                int num15 = width - num13;
                int num16 = height - num14;
                int num17 = 0;
                int num18 = 0;
                if (num15 > intimgDistance)
                {
                    num17 = num15 - intimgDistance;
                }
                else
                {
                    num17 = num15;
                }
                if (num16 > intimgDistance)
                {
                    num18 = num16 - intimgDistance;
                }
                else
                {
                    num18 = num16;
                }
                graphics2.DrawImage(image2, new Rectangle(num17, num18, num13, num14), 0, 0, num7, num8, GraphicsUnit.Pixel, imageAttr);
                image = bitmap2;
                image.Save(sImgPath, ImageFormat.Jpeg);
                graphics.Dispose();
                graphics2.Dispose();
                bitmap.Dispose();
                image.Dispose();
                image2.Dispose();
            }
            catch
            {
            }
        }

        public void zzsImgWater(string ImgFile, string WaterImg, string sImgPath, float Alpha, float iScale, int intDistance)
        {
            try
            {
                FileStream input = new FileStream(ImgFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(input);
                byte[] buffer = reader.ReadBytes((int) input.Length);
                reader.Close();
                input.Close();
                MemoryStream stream = new MemoryStream(buffer);
                Image image = Image.FromStream(stream);
                int width = image.Width;
                int height = image.Height;
                Image image2 = new Bitmap(WaterImg);
                int num3 = image2.Width;
                int num4 = image2.Height;
                decimal num5 = Convert.ToDecimal(iScale);
                decimal num6 = 0.05M;
                decimal num7 = num5 - num6;
                decimal num8 = num5 + num6;
                int num9 = num3;
                int num10 = num4;
                if (((width >= num3) && (height >= num4)) && (width >= height))
                {
                    if (num3 > num4)
                    {
                        if ((num7 > Math.Round((decimal) (Convert.ToDecimal(num3) / Convert.ToDecimal(width)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num3) / Convert.ToDecimal(width)), 7) > num8))
                        {
                            num9 = Convert.ToInt32((decimal) (width * num5));
                            num10 = Convert.ToInt32((decimal) (((width * num5) / num3) * num4));
                        }
                    }
                    else if ((num7 > Math.Round((decimal) (Convert.ToDecimal(num4) / Convert.ToDecimal(height)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num4) / Convert.ToDecimal(height)), 7) > num8))
                    {
                        num10 = Convert.ToInt32((decimal) (height * num5));
                        num9 = Convert.ToInt32((decimal) (((height * num5) / num4) * num3));
                    }
                }
                if (((num3 >= width) && (num4 >= height)) && (num3 >= num4))
                {
                    num9 = Convert.ToInt32((decimal) (width * num5));
                    num10 = Convert.ToInt32((decimal) (((width * num5) / num3) * num4));
                }
                if (((num3 >= width) && (num4 <= height)) && (width >= height))
                {
                    num9 = Convert.ToInt32((decimal) (width * num5));
                    num10 = Convert.ToInt32((decimal) (((width * num5) / num3) * num4));
                }
                if (((num3 <= width) && (num4 >= height)) && (width >= height))
                {
                    num10 = Convert.ToInt32((decimal) (height * num5));
                    num9 = Convert.ToInt32((decimal) (((height * num5) / num4) * num3));
                }
                if (((width >= num3) && (height >= num4)) && (width <= height))
                {
                    if (num3 > num4)
                    {
                        if ((num7 > Math.Round((decimal) (Convert.ToDecimal(num3) / Convert.ToDecimal(width)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num3) / Convert.ToDecimal(width)), 7) > num8))
                        {
                            num9 = Convert.ToInt32((decimal) (width * num5));
                            num10 = Convert.ToInt32((decimal) (((width * num5) / num3) * num4));
                        }
                    }
                    else if ((num7 > Math.Round((decimal) (Convert.ToDecimal(num4) / Convert.ToDecimal(height)), 7)) || (Math.Round((decimal) (Convert.ToDecimal(num4) / Convert.ToDecimal(height)), 7) > num8))
                    {
                        num10 = Convert.ToInt32((decimal) (height * num5));
                        num9 = Convert.ToInt32((decimal) (((height * num5) / num4) * num3));
                    }
                }
                if (((num3 >= width) && (num4 >= height)) && (num3 <= num4))
                {
                    num10 = Convert.ToInt32((decimal) (height * num5));
                    num9 = Convert.ToInt32((decimal) (((height * num5) / num4) * num3));
                }
                if (((num3 >= width) && (num4 <= height)) && (width <= height))
                {
                    num9 = Convert.ToInt32((decimal) (width * num5));
                    num10 = Convert.ToInt32((decimal) (((width * num5) / num3) * num4));
                }
                if (((num3 <= width) && (num4 >= height)) && (width <= height))
                {
                    num10 = Convert.ToInt32((decimal) (height * num5));
                    num9 = Convert.ToInt32((decimal) (((height * num5) / num4) * num3));
                }
                Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bitmap.SetResolution(72f, 72f);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.Clear(Color.White);
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
                Bitmap bitmap2 = new Bitmap(bitmap);
                bitmap2.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                Graphics graphics2 = Graphics.FromImage(bitmap2);
                graphics2.InterpolationMode = InterpolationMode.High;
                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                ImageAttributes imageAttr = new ImageAttributes();
                ColorMap map = new ColorMap {
                    OldColor = Color.FromArgb(0xff, 0, 0xff, 0),
                    NewColor = Color.FromArgb(0, 0, 0, 0)
                };
                ColorMap[] mapArray = new ColorMap[] { map };
                imageAttr.SetRemapTable(mapArray, ColorAdjustType.Bitmap);
                float[][] numArray = new float[5][];
                float[] numArray2 = new float[5];
                numArray2[0] = 1f;
                numArray[0] = numArray2;
                numArray2 = new float[5];
                numArray2[1] = 1f;
                numArray[1] = numArray2;
                numArray2 = new float[5];
                numArray2[2] = 1f;
                numArray[2] = numArray2;
                numArray2 = new float[5];
                numArray2[3] = Alpha;
                numArray[3] = numArray2;
                numArray2 = new float[5];
                numArray2[4] = 1f;
                numArray[4] = numArray2;
                float[][] newColorMatrix = numArray;
                ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                int num11 = width - num9;
                int num12 = height - num10;
                int x = 0;
                int y = 0;
                if (num11 > intDistance)
                {
                    x = num11 - intDistance;
                }
                else
                {
                    x = num11;
                }
                if (num12 > intDistance)
                {
                    y = num12 - intDistance;
                }
                else
                {
                    y = num12;
                }
                graphics2.DrawImage(image2, new Rectangle(x, y, num9, num10), 0, 0, num3, num4, GraphicsUnit.Pixel, imageAttr);
                image = bitmap2;
                image.Save(sImgPath, ImageFormat.Jpeg);
                graphics.Dispose();
                graphics2.Dispose();
                image.Dispose();
                image2.Dispose();
            }
            catch
            {
            }
        }

        public void zzsResizeImg(string ImgFile, string sImgPath, int ResizeWidth, int ResizeHeight, string BgColor)
        {
            try
            {
                FileStream input = new FileStream(ImgFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(input);
                byte[] buffer = reader.ReadBytes((int) input.Length);
                reader.Close();
                input.Close();
                MemoryStream stream = new MemoryStream(buffer);
                Image image = Image.FromStream(stream);
                int width = image.Width;
                int height = image.Height;
                int x = 0;
                int y = 0;
                int num5 = 0;
                int num6 = 0;
                if ((width >= ResizeWidth) && (height >= ResizeHeight))
                {
                    num5 = ResizeWidth;
                    num6 = Convert.ToInt32((decimal) (height * Math.Round((decimal) (Convert.ToDecimal(ResizeWidth) / Convert.ToDecimal(width)), 10)));
                    x = 0;
                    y = (ResizeHeight - num6) / 2;
                }
                if ((ResizeWidth > width) && (ResizeHeight < height))
                {
                    num6 = ResizeHeight;
                    num5 = Convert.ToInt32((decimal) (width * Math.Round((decimal) (Convert.ToDecimal(ResizeHeight) / Convert.ToDecimal(height)), 10)));
                    x = (ResizeWidth - num5) / 2;
                    y = 0;
                }
                if ((ResizeWidth < width) && (ResizeHeight > height))
                {
                    num5 = ResizeWidth;
                    num6 = Convert.ToInt32((decimal) (height * Math.Round((decimal) (Convert.ToDecimal(ResizeWidth) / Convert.ToDecimal(width)), 10)));
                    x = 0;
                    y = (ResizeHeight - num6) / 2;
                }
                if ((width < ResizeWidth) && (height < ResizeHeight))
                {
                    num5 = width;
                    num6 = height;
                    x = (ResizeWidth - width) / 2;
                    y = (ResizeHeight - height) / 2;
                }
                Bitmap bitmap = new Bitmap(ResizeWidth, ResizeHeight, PixelFormat.Format24bppRgb);
                bitmap.SetResolution(72f, 72f);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.FromName(BgColor));
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(x, y, num5, num6), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                bitmap.Save(sImgPath, ImageFormat.Jpeg);
                image.Dispose();
                graphics.Dispose();
                bitmap.Dispose();
            }
            catch
            {
            }
        }

        public void zzsTextWater(string ImgFile, string TextFont, string sImgPath, float hScale, float widthFont, int Alpha)
        {
            try
            {
                FileStream input = new FileStream(ImgFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(input);
                byte[] buffer = reader.ReadBytes((int) input.Length);
                reader.Close();
                input.Close();
                MemoryStream stream = new MemoryStream(buffer);
                Image image = Image.FromStream(stream);
                int width = image.Width;
                int height = image.Height;
                Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bitmap.SetResolution(72f, 72f);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
                int[] numArray = new int[] { 
                    0x3e8, 800, 700, 650, 600, 560, 540, 500, 450, 400, 380, 360, 340, 320, 300, 280, 
                    260, 240, 220, 200, 180, 160, 140, 120, 100, 80, 0x48, 0x40, 0x30, 0x20, 0x1c, 0x1a, 
                    0x18, 20, 0x1c, 0x10, 14, 12, 10, 8, 6, 4, 2
                 };
                Font font = null;
                SizeF ef = new SizeF();
                for (int i = 0; i < 0x2b; i++)
                {
                    font = new Font("arial", (float) numArray[i], FontStyle.Bold);
                    ef = graphics.MeasureString(TextFont, font);
                    if (((ushort) ef.Width) < (((ushort) width) * widthFont))
                    {
                        break;
                    }
                }
                int num4 = (int) (height * hScale);
                float y = (height - num4) - (ef.Height / 2f);
                float x = width / 2;
                StringFormat format = new StringFormat {
                    Alignment = StringAlignment.Center
                };
                SolidBrush brush = new SolidBrush(Color.FromArgb(Alpha, 0, 0, 0));
                graphics.DrawString(TextFont, font, brush, new PointF(x + 1f, y + 1f), format);
                SolidBrush brush2 = new SolidBrush(Color.FromArgb(Alpha, 0xff, 0xff, 0xff));
                graphics.DrawString(TextFont, font, brush2, new PointF(x, y), format);
                bitmap.Save(sImgPath, ImageFormat.Jpeg);
                graphics.Dispose();
                image.Dispose();
                bitmap.Dispose();
            }
            catch
            {
            }
        }
    }
}

