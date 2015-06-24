namespace SoMeTech.User
{
    using SoMeTech.Menu;
    using System;

    public class PowerClass
    {
        public static string GetPowerString(string power)
        {
            power = power.Replace("|", "','");
            power = "'" + power + "'";
            return power;
        }

        public static bool IfHasPower(string username, string strpower, PowerNum pn)
        {
            if (username != "admin")
            {
                return IsTrue(strpower, pn.GetHashCode().ToString());
            }
            return true;
        }

        public static bool IfHasPower(string username, string strpower, string powercode)
        {
            if (username != "admin")
            {
                return IsTrue(strpower, powercode);
            }
            return true;
        }

        public static bool IfHasPowerUs(string username, string strpower, string powercode)
        {
            bool flag = false;
            if (username != "admin")
            {
                flag = IsTrue(strpower, powercode);
            }
            return flag;
        }

        private static bool IsTrue(string strpower, string powercode)
        {
            if (strpower != null)
            {
                string[] strArray = strpower.Split(new char[] { '|' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == powercode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string SubTwoPower(string userpower, string otherpower, string split)
        {
            string str = "";
            if (!(otherpower != ""))
            {
                return userpower;
            }
            string[] strArray = userpower.Split(new char[] { char.Parse(split) });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (otherpower.IndexOf(split + strArray[i] + split) < 0)
                {
                    str = str + strArray[i] + split;
                }
            }
            return str;
        }
    }
}

