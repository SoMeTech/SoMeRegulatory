namespace QxRoom.Common
{
    using System;

    public sealed class DoNumber
    {
        private static string GetUpperChinaBehindPart(string num)
        {
            return "";
        }

        private static string GetUpperChinaFrontPart(string num)
        {
            string str = "";
            int length = str.Length;
            return str;
        }

        public static string GetUpperChinaNum(decimal num)
        {
            string str = num.ToString();
            if (str.IndexOf('.') > 0)
            {
                string[] strArray = str.Split(new char[] { '.' });
                str = "";
                return (str + GetUpperChinaFrontPart(strArray[0]) + GetUpperChinaBehindPart(strArray[1]));
            }
            return "该数字不是带小数点的数字";
        }

        public static string GetUpperChinaNum(int num)
        {
            return GetUpperChinaFrontPart(num.ToString());
        }

        public static string GetUpperChinaNum(string strnum)
        {
            switch (strnum)
            {
                case "0":
                    strnum = "零";
                    return strnum;

                case "1":
                    strnum = "壹";
                    return strnum;

                case "2":
                    strnum = "贰";
                    return strnum;

                case "3":
                    strnum = "叁";
                    return strnum;

                case "4":
                    strnum = "肆";
                    return strnum;

                case "5":
                    strnum = "伍";
                    return strnum;

                case "6":
                    strnum = "陆";
                    return strnum;

                case "7":
                    strnum = "柒";
                    return strnum;

                case "8":
                    strnum = "捌";
                    return strnum;

                case "9":
                    strnum = "玖";
                    return strnum;
            }
            return strnum;
        }

        public static string GetUpperChinaNum(string strnum, bool type, int state)
        {
            if (strnum.IndexOf('.') > 0)
            {
                string[] strArray = strnum.Split(new char[] { '.' });
                if (type)
                {
                    strnum = GetUpperChinaNum(strArray[1].Substring(state, 1));
                    return strnum;
                }
                strnum = strArray[0].Remove(0, strArray[0].Length - state);
                strnum = GetUpperChinaNum(strnum.Substring(0, 1));
                return strnum;
            }
            strnum = strnum.Remove(0, strnum.Length - state);
            strnum = GetUpperChinaNum(strnum.Substring(0, 1));
            return strnum;
        }

        public static double HDtoJD(double hd)
        {
            return (hd / 0.017453292519943295);
        }

        public static double JDtoHD(double jd)
        {
            return (0.017453292519943295 * jd);
        }
    }
}

