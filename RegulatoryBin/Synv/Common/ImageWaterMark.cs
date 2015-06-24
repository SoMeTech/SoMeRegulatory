namespace Synv.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;

    public class ImageWaterMark
    {
        public static void AddImageSignPic(string imgPath, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {
            Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(HttpContext.Current.Server.MapPath(imgPath))));
            filename = HttpContext.Current.Server.MapPath(filename);
            if (!watermarkFilename.StartsWith("/"))
            {
                watermarkFilename = "/" + watermarkFilename;
            }
            watermarkFilename = HttpContext.Current.Server.MapPath(watermarkFilename);
            if (File.Exists(watermarkFilename))
            {
                Graphics graphics = Graphics.FromImage(image);
                Image image2 = new Bitmap(watermarkFilename);
                if ((image2.Height < image.Height) && (image2.Width < image.Width))
                {
                    ImageAttributes imageAttr = new ImageAttributes();
                    ColorMap map = new ColorMap {
                        OldColor = Color.FromArgb(0xff, 0, 0xff, 0),
                        NewColor = Color.FromArgb(0, 0, 0, 0)
                    };
                    ColorMap[] mapArray = new ColorMap[] { map };
                    imageAttr.SetRemapTable(mapArray, ColorAdjustType.Bitmap);
                    float num = 0.5f;
                    if ((watermarkTransparency >= 1) && (watermarkTransparency <= 10))
                    {
                        num = ((float) watermarkTransparency) / 10f;
                    }
                    float[][] numArray3 = new float[5][];
                    float[] numArray4 = new float[5];
                    numArray4[0] = 1f;
                    numArray3[0] = numArray4;
                    float[] numArray5 = new float[5];
                    numArray5[1] = 1f;
                    numArray3[1] = numArray5;
                    float[] numArray6 = new float[5];
                    numArray6[2] = 1f;
                    numArray3[2] = numArray6;
                    float[] numArray7 = new float[5];
                    numArray7[3] = num;
                    numArray3[3] = numArray7;
                    float[] numArray8 = new float[5];
                    numArray8[4] = 1f;
                    numArray3[4] = numArray8;
                    float[][] newColorMatrix = numArray3;
                    ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                    imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    int x = 0;
                    int y = 0;
                    switch (watermarkStatus)
                    {
                        case 1:
                            x = (int) (image.Width * 0.01f);
                            y = (int) (image.Height * 0.01f);
                            break;

                        case 2:
                            x = ((int) (image.Width * 0.5f)) - (image2.Width / 2);
                            y = (int) (image.Height * 0.01f);
                            break;

                        case 3:
                            x = ((int) (image.Width * 0.99f)) - image2.Width;
                            y = (int) (image.Height * 0.01f);
                            break;

                        case 4:
                            x = (int) (image.Width * 0.01f);
                            y = ((int) (image.Height * 0.5f)) - (image2.Height / 2);
                            break;

                        case 5:
                            x = ((int) (image.Width * 0.5f)) - (image2.Width / 2);
                            y = ((int) (image.Height * 0.5f)) - (image2.Height / 2);
                            break;

                        case 6:
                            x = ((int) (image.Width * 0.99f)) - image2.Width;
                            y = ((int) (image.Height * 0.5f)) - (image2.Height / 2);
                            break;

                        case 7:
                            x = (int) (image.Width * 0.01f);
                            y = ((int) (image.Height * 0.99f)) - image2.Height;
                            break;

                        case 8:
                            x = ((int) (image.Width * 0.5f)) - (image2.Width / 2);
                            y = ((int) (image.Height * 0.99f)) - image2.Height;
                            break;

                        case 9:
                            x = ((int) (image.Width * 0.99f)) - image2.Width;
                            y = ((int) (image.Height * 0.99f)) - image2.Height;
                            break;
                    }
                    graphics.DrawImage(image2, new Rectangle(x, y, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttr);
                    ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo encoder = null;
                    foreach (ImageCodecInfo info2 in imageEncoders)
                    {
                        if (info2.MimeType.IndexOf("jpeg") > -1)
                        {
                            encoder = info2;
                        }
                    }
                    EncoderParameters encoderParams = new EncoderParameters();
                    long[] numArray2 = new long[1];
                    if ((quality < 0) || (quality > 100))
                    {
                        quality = 80;
                    }
                    numArray2[0] = quality;
                    EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray2);
                    encoderParams.Param[0] = parameter;
                    if (encoder != null)
                    {
                        image.Save(filename, encoder, encoderParams);
                    }
                    else
                    {
                        image.Save(filename);
                    }
                    graphics.Dispose();
                    image.Dispose();
                    image2.Dispose();
                    imageAttr.Dispose();
                }
            }
        }

        public static void AddImageSignText(string imgPath, string filename, string watermarkText, int watermarkStatus, int quality, string fontname, int fontsize)
        {
            Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(HttpContext.Current.Server.MapPath(imgPath))));
            filename = HttpContext.Current.Server.MapPath(filename);
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font(fontname, (float) fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF ef = graphics.MeasureString(watermarkText, font);
            float x = 0f;
            float y = 0f;
            switch (watermarkStatus)
            {
                case 1:
                    x = image.Width * 0.01f;
                    y = image.Height * 0.01f;
                    break;

                case 2:
                    x = (image.Width * 0.5f) - (ef.Width / 2f);
                    y = image.Height * 0.01f;
                    break;

                case 3:
                    x = (image.Width * 0.99f) - ef.Width;
                    y = image.Height * 0.01f;
                    break;

                case 4:
                    x = image.Width * 0.01f;
                    y = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 5:
                    x = (image.Width * 0.5f) - (ef.Width / 2f);
                    y = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 6:
                    x = (image.Width * 0.99f) - ef.Width;
                    y = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 7:
                    x = image.Width * 0.01f;
                    y = (image.Height * 0.99f) - ef.Height;
                    break;

                case 8:
                    x = (image.Width * 0.5f) - (ef.Width / 2f);
                    y = (image.Height * 0.99f) - ef.Height;
                    break;

                case 9:
                    x = (image.Width * 0.99f) - ef.Width;
                    y = (image.Height * 0.99f) - ef.Height;
                    break;
            }
            graphics.DrawString(watermarkText, font, new SolidBrush(Color.White), (float) (x + 1f), (float) (y + 1f));
            graphics.DrawString(watermarkText, font, new SolidBrush(Color.Black), x, y);
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            foreach (ImageCodecInfo info2 in imageEncoders)
            {
                if (info2.MimeType.IndexOf("jpeg") > -1)
                {
                    encoder = info2;
                }
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] numArray = new long[1];
            if ((quality < 0) || (quality > 100))
            {
                quality = 80;
            }
            numArray[0] = quality;
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray);
            encoderParams.Param[0] = parameter;
            if (encoder != null)
            {
                image.Save(filename, encoder, encoderParams);
            }
            else
            {
                image.Save(filename);
            }
            graphics.Dispose();
            image.Dispose();
        }
    }
}

