namespace QxRoom.Common
{
    using System;

    public sealed class NumberToChina
    {
        public static string Convert2Digit(string str)
        {
            string str2 = str.Substring(0, 1);
            string str3 = str.Substring(1, 1);
            string str4 = "";
            return (str4 + ConvertChinese(str2) + "拾" + ConvertChinese(str3)).Replace("零拾", "零").Replace("零零", "零");
        }

        public static string Convert3Digit(string str)
        {
            string str2 = str.Substring(0, 1);
            string str3 = str.Substring(1, 1);
            string str4 = str.Substring(2, 1);
            string str5 = "";
            return (str5 + ConvertChinese(str2) + "佰" + ConvertChinese(str3) + "拾" + ConvertChinese(str4)).Replace("零佰", "零").Replace("零拾", "零").Replace("零零", "零").Replace("零零", "零");
        }

        public static string Convert4Digit(string str)
        {
            string str2 = str.Substring(0, 1);
            string str3 = str.Substring(1, 1);
            string str4 = str.Substring(2, 1);
            string str5 = str.Substring(3, 1);
            string str6 = "";
            return (str6 + ConvertChinese(str2) + "仟" + ConvertChinese(str3) + "佰" + ConvertChinese(str4) + "拾" + ConvertChinese(str5)).Replace("零仟", "零").Replace("零佰", "零").Replace("零拾", "零").Replace("零零", "零").Replace("零零", "零").Replace("零零", "零");
        }

        public static string ConvertChinese(string str)
        {
            switch (str)
            {
                case "0":
                    return "零";

                case "1":
                    return "壹";

                case "2":
                    return "贰";

                case "3":
                    return "叁";

                case "4":
                    return "肆";

                case "5":
                    return "伍";

                case "6":
                    return "陆";

                case "7":
                    return "柒";

                case "8":
                    return "捌";

                case "9":
                    return "玖";
            }
            return "";
        }

        public static string ConvertData(string str)
        {
            string str2;
            string str3 = "";
            int length = str.Length;
            if (length <= 4)
            {
                str3 = ConvertDigit(str);
            }
            else if (length <= 8)
            {
                str3 = ConvertDigit(str.Substring(length - 4, 4));
                str3 = (ConvertDigit(str.Substring(0, length - 4)) + "萬" + str3).Replace("零萬", "萬").Replace("零零", "零");
            }
            else if (length <= 12)
            {
                str3 = ConvertDigit(str.Substring(length - 4, 4));
                str3 = ConvertDigit(str.Substring(length - 8, 4)) + "萬" + str3;
                str3 = (ConvertDigit(str.Substring(0, length - 8)) + "億" + str3).Replace("零億", "億").Replace("零萬", "零").Replace("零零", "零").Replace("零零", "零");
            }
            length = str3.Length;
            if ((length < 2) || ((str2 = str3.Substring(length - 2, 2)) == null))
            {
                return str3;
            }
            if (str2 == "佰零")
            {
                return (str3.Substring(0, length - 2) + "佰");
            }
            if (!(str2 != "仟零"))
            {
                return (str3.Substring(0, length - 2) + "仟");
            }
            if (str2 == "萬零")
            {
                return (str3.Substring(0, length - 2) + "萬");
            }
            if (str2 != "億零")
            {
                return str3;
            }
            return (str3.Substring(0, length - 2) + "億");
        }

        public static string ConvertDigit(string str)
        {
            int length = str.Length;
            string str2 = "";
            switch (length)
            {
                case 1:
                    str2 = ConvertChinese(str);
                    break;

                case 2:
                    str2 = Convert2Digit(str);
                    break;

                case 3:
                    str2 = Convert3Digit(str);
                    break;

                case 4:
                    str2 = Convert4Digit(str);
                    break;
            }
            str2 = str2.Replace("拾零", "拾");
            length = str2.Length;
            return str2;
        }

        public static string ConvertPart(string str, int len)
        {
            string[] strArray = str.Split(new char[] { '.' });
            if (len >= 0)
            {
                if (strArray[0].Length >= (len + 1))
                {
                    return strArray[0].Substring((strArray[0].Length - len) - 1, 1);
                }
                return "0";
            }
            if ((len == -1) && (strArray[1].Length >= 1))
            {
                strArray[1].Substring(0, 1);
            }
            if ((len == -2) && (strArray[1].Length >= 2))
            {
                return strArray[1].Substring(1, 1);
            }
            return "0";
        }

        public static string ConvertPartChinese(string str, int len)
        {
            return ConvertChinese(ConvertPart(str, len));
        }

        public static string ConvertPartNum(string str, int len)
        {
            if (str.Split(new char[] { '.' })[0].Length < (len + 1))
            {
                return ConvertPart(str, len);
            }
            return "￥";
        }

        public static string ConvertSum(string str, bool numbj)
        {
            if (!IsPositveDecimal(str))
            {
                return "输入的不是正数字！";
            }
            if (double.Parse(str) > 999999999999.99)
            {
                return "数字太大，无法换算，请输入一万亿以下的数字";
            }
            char[] chArray = new char[] { '.' };
            string[] strArray = null;
            strArray = str.Split(new char[] { chArray[0] });
            if (strArray.Length == 1)
            {
                if (numbj)
                {
                    return (ConvertData(str) + "圆整");
                }
                return ConvertData(str);
            }
            string str2 = ConvertData(strArray[0]);
            if (numbj)
            {
                str2 = str2 + "圆";
            }
            else
            {
                str2 = str2 + "点";
            }
            return (str2 + ConvertXiaoShu(strArray[1], numbj));
        }

        public static string ConvertXiaoShu(string str, bool numbj)
        {
            string str2;
            if (str.Length == 1)
            {
                str2 = ConvertChinese(str);
                if (numbj)
                {
                    str2 = str2 + "角";
                }
                return str2;
            }
            str2 = ConvertChinese(str.Substring(0, 1));
            if (numbj)
            {
                str2 = str2 + "角";
            }
            string str3 = str.Substring(1, 1);
            str2 = str2 + ConvertChinese(str3);
            if (numbj)
            {
                str2 = str2 + "分";
            }
            return str2.Replace("零分", "").Replace("零角", "");
        }

        public static bool IsPositveDecimal(string str)
        {
            decimal num;
            try
            {
                num = decimal.Parse(str);
            }
            catch (Exception)
            {
                return false;
            }
            return (num > 0M);
        }
    }
}

