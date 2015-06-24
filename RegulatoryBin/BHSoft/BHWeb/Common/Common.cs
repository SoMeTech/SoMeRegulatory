namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Text;
    using System.Web;

    public class Common
    {
        private static string connStr;

        public static string AccessConnStr()
        {
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("./AlternativeDB.mdb");
            return connStr;
        }

        public static string bConnString()
        {
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("../AlternativeDB.mdb") + ";Jet OLEDB:Database Password=Rock2007";
            return connStr;
        }

        public static string Extract_HZ(string HZ)
        {
            byte[] bytes = new byte[2];
            bytes = Encoding.Default.GetBytes(HZ);
            int num = bytes[0];
            int num2 = bytes[1];
            long num3 = (num * 0x100) + num2;
            if ((num3 >= 0xb0a1L) && (num3 <= 0xb0c4L))
            {
                return "A";
            }
            if ((num3 >= 0xb0c5L) && (num3 <= 0xb2c0L))
            {
                return "B";
            }
            if ((num3 >= 0xb2c1L) && (num3 <= 0xb4edL))
            {
                return "C";
            }
            if ((num3 >= 0xb4eeL) && (num3 <= 0xb6e9L))
            {
                return "D";
            }
            if ((num3 >= 0xb6eaL) && (num3 <= 0xb7a1L))
            {
                return "E";
            }
            if ((num3 >= 0xb7a2L) && (num3 <= 0xb8c0L))
            {
                return "F";
            }
            if ((num3 >= 0xb8c1L) && (num3 <= 0xb9fdL))
            {
                return "G";
            }
            if ((num3 >= 0xb9feL) && (num3 <= 0xbbf6L))
            {
                return "H";
            }
            if ((num3 >= 0xbbf7L) && (num3 <= 0xbfa5L))
            {
                return "J";
            }
            if ((num3 >= 0xbfa6L) && (num3 <= 0xc0abL))
            {
                return "K";
            }
            if ((num3 >= 0xc0acL) && (num3 <= 0xc2e7L))
            {
                return "L";
            }
            if ((num3 >= 0xc2e8L) && (num3 <= 0xc4c2L))
            {
                return "M";
            }
            if ((num3 >= 0xc4c3L) && (num3 <= 0xc5b5L))
            {
                return "N";
            }
            if ((num3 >= 0xc5b6L) && (num3 <= 0xc5bdL))
            {
                return "O";
            }
            if ((num3 >= 0xc5beL) && (num3 <= 0xc6d9L))
            {
                return "P";
            }
            if ((num3 >= 0xc6daL) && (num3 <= 0.51386))
            {
                return "Q";
            }
            if ((num3 >= 0xc8bbL) && (num3 <= 0xc8f5L))
            {
                return "R";
            }
            if ((num3 >= 0xc8f6L) && (num3 <= 0xcbf9L))
            {
                return "S";
            }
            if ((num3 >= 0xcbfaL) && (num3 <= 0xcdd9L))
            {
                return "T";
            }
            if ((num3 >= 0xcddaL) && (num3 <= 0xcef3L))
            {
                return "W";
            }
            if ((num3 >= 0xcef4L) && (num3 <= 0xd188L))
            {
                return "X";
            }
            if ((num3 >= 0xd1b9L) && (num3 <= 0xd4d0L))
            {
                return "Y";
            }
            if ((num3 >= 0xd4d1L) && (num3 <= 0xd7f9L))
            {
                return "Z";
            }
            return "";
        }

        public static string SQLConnStr()
        {
            ReadXML dxml = new ReadXML();
            return ("server=" + dxml.DBserver + ";database=" + dxml.Dbase + ";Pooling=true;Min Pool Size=0;Max Pool Size=1000;packet size=4096;uid=" + dxml.DbUserId + ";pwd=" + dxml.DbUserPSW + ";");
        }
    }
}

