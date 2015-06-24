namespace QxRoom.Common
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public sealed class CodeBar39
    {
        private Hashtable CheckCode;
        private Hashtable Decode = new Hashtable();
        private int Height;
        public int LineHeight = 60;
        private string SPARATOR = "0";
        private int Width;
        public int WidthCU = 3;
        public int WidthXI = 1;
        public int xCoordinate = 10;

        public CodeBar39()
        {
            this.Decode.Add("0", "000110100");
            this.Decode.Add("1", "100100001");
            this.Decode.Add("2", "001100001");
            this.Decode.Add("3", "101100000");
            this.Decode.Add("4", "000110001");
            this.Decode.Add("5", "100110000");
            this.Decode.Add("6", "001110000");
            this.Decode.Add("7", "000100101");
            this.Decode.Add("8", "100100100");
            this.Decode.Add("9", "001100100");
            this.Decode.Add("A", "100001001");
            this.Decode.Add("B", "001001001");
            this.Decode.Add("C", "101001000");
            this.Decode.Add("D", "000011001");
            this.Decode.Add("E", "100011000");
            this.Decode.Add("F", "001011000");
            this.Decode.Add("G", "000001101");
            this.Decode.Add("H", "100001100");
            this.Decode.Add("I", "001001101");
            this.Decode.Add("J", "000011100");
            this.Decode.Add("K", "100000011");
            this.Decode.Add("L", "001000011");
            this.Decode.Add("M", "101000010");
            this.Decode.Add("N", "000010011");
            this.Decode.Add("O", "100010010");
            this.Decode.Add("P", "001010010");
            this.Decode.Add("Q", "000000111");
            this.Decode.Add("R", "100000110");
            this.Decode.Add("S", "001000110");
            this.Decode.Add("T", "000010110");
            this.Decode.Add("U", "110000001");
            this.Decode.Add("V", "011000001");
            this.Decode.Add("W", "111000000");
            this.Decode.Add("X", "010010001");
            this.Decode.Add("Y", "110010000");
            this.Decode.Add("Z", "011010000");
            this.Decode.Add("-", "010000101");
            this.Decode.Add(".", "110000100");
            this.Decode.Add(" ", "011000100");
            this.Decode.Add("*", "010010100");
            this.Decode.Add("$", "010101000");
            this.Decode.Add("/", "010100010");
            this.Decode.Add("+", "010001010");
            this.Decode.Add("%", "000101010");
            this.CheckCode = new Hashtable();
            this.CheckCode.Add("0", "0");
            this.CheckCode.Add("1", "1");
            this.CheckCode.Add("2", "2");
            this.CheckCode.Add("3", "3");
            this.CheckCode.Add("4", "4");
            this.CheckCode.Add("5", "5");
            this.CheckCode.Add("6", "6");
            this.CheckCode.Add("7", "7");
            this.CheckCode.Add("8", "8");
            this.CheckCode.Add("9", "9");
            this.CheckCode.Add("A", "10");
            this.CheckCode.Add("B", "11");
            this.CheckCode.Add("C", "12");
            this.CheckCode.Add("D", "13");
            this.CheckCode.Add("E", "14");
            this.CheckCode.Add("F", "15");
            this.CheckCode.Add("G", "16");
            this.CheckCode.Add("H", "17");
            this.CheckCode.Add("I", "18");
            this.CheckCode.Add("J", "19");
            this.CheckCode.Add("K", "20");
            this.CheckCode.Add("L", "21");
            this.CheckCode.Add("M", "22");
            this.CheckCode.Add("N", "23");
            this.CheckCode.Add("O", "24");
            this.CheckCode.Add("P", "25");
            this.CheckCode.Add("Q", "26");
            this.CheckCode.Add("R", "27");
            this.CheckCode.Add("S", "28");
            this.CheckCode.Add("T", "29");
            this.CheckCode.Add("U", "30");
            this.CheckCode.Add("V", "31");
            this.CheckCode.Add("W", "32");
            this.CheckCode.Add("X", "33");
            this.CheckCode.Add("Y", "34");
            this.CheckCode.Add("Z", "35");
            this.CheckCode.Add("-", "36");
            this.CheckCode.Add(".", "37");
            this.CheckCode.Add(" ", "38");
            this.CheckCode.Add("*", "39");
            this.CheckCode.Add("$", "40");
            this.CheckCode.Add("/", "41");
            this.CheckCode.Add("+", "42");
            this.CheckCode.Add("%", "43");
        }

        private void DrawBarCode39(string Code39, string Title, Graphics g)
        {
            int num = 1;
            if (Title.Trim().Equals(""))
            {
                num = 0;
            }
            new Pen(Color.White, 1f);
            Pen pen = new Pen(Color.Black, 1f);
            int xCoordinate = this.xCoordinate;
            if (num == 1)
            {
                Font font = new Font("宋体", 16f, FontStyle.Bold);
                SizeF ef = g.MeasureString(Title, font);
                g.DrawString(Title, font, Brushes.Black, (float) ((this.Width - ef.Width) / 2f), (float) 5f);
            }
            for (int i = 0; i < Code39.Length; i++)
            {
                if ("0".Equals(Code39.Substring(i, 1)))
                {
                    for (int j = 0; j < this.WidthXI; j++)
                    {
                        g.DrawLine(pen, xCoordinate + j, 30, xCoordinate + j, 30 + this.LineHeight);
                    }
                    xCoordinate += this.WidthXI;
                }
                else
                {
                    for (int k = 0; k < this.WidthCU; k++)
                    {
                        g.DrawLine(pen, xCoordinate + k, 30, xCoordinate + k, 30 + this.LineHeight);
                    }
                    xCoordinate += this.WidthCU;
                }
                i++;
                if ("0".Equals(Code39.Substring(i, 1)))
                {
                    xCoordinate += this.WidthXI;
                }
                else
                {
                    xCoordinate += this.WidthCU;
                }
            }
        }

        private string Encode39(string Code, int UseCheck)
        {
            int num = 1;
            if ((Code == null) || Code.Trim().Equals(""))
            {
                return null;
            }
            Code = Code.ToUpper();
            Regex regex = new Regex(@"[^0-9A-Z%$\-*]");
            if (regex.IsMatch(Code))
            {
                return "编码中包含非法字符，目前仅支持字母,数字及%$-*符号!!";
            }
            if (UseCheck == 1)
            {
                int num2 = 0;
                for (int k = 0; k < Code.Length; k++)
                {
                    num2 += int.Parse((string) this.CheckCode[Code.Substring(k, 1)]);
                }
                num2 = num2 % 0x2b;
                foreach (DictionaryEntry entry in this.CheckCode)
                {
                    if (((string) entry.Value) == num2.ToString())
                    {
                        Code = Code + ((string) entry.Key);
                        break;
                    }
                }
            }
            if (num == 1)
            {
                if (Code.Substring(0, 1) != "*")
                {
                    Code = "*" + Code;
                }
                if (Code.Substring(Code.Length - 1, 1) != "*")
                {
                    Code = Code + "*";
                }
            }
            string str = "";
            for (int i = 0; i < Code.Length; i++)
            {
                str = str + ((string) this.Decode[Code.Substring(i, 1)]) + this.SPARATOR;
            }
            int num5 = 30 + this.LineHeight;
            int xCoordinate = this.xCoordinate;
            for (int j = 0; j < str.Length; j++)
            {
                if ("0".Equals(str.Substring(j, 1)))
                {
                    xCoordinate += this.WidthXI;
                }
                else
                {
                    xCoordinate += this.WidthCU;
                }
            }
            this.Width = xCoordinate + this.xCoordinate;
            this.Height = num5;
            return str;
        }

        public bool saveFile(string Code, string Title, int UseCheck, string strpath, out System.Drawing.Image img, out string strpicpath)
        {
            img = null;
            strpicpath = "";
            string str = this.Encode39(Code, UseCheck);
            if (str != null)
            {
                System.Drawing.Image image = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(image);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
                this.DrawBarCode39(str, Title, g);
                string filename = strpath + Code + ".jpg";
                img = image;
                strpicpath = filename;
                image.Save(filename, ImageFormat.Jpeg);
                image.Dispose();
                return true;
            }
            return false;
        }
    }
}

