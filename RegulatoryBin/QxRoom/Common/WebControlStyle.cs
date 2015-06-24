namespace QxRoom.Common
{
    using System;

    public class WebControlStyle
    {
        public static string DropDownListDataStyle(string navigationPath, string ShowTest, int babyCount)
        {
            string[] strArray = null;
            strArray = navigationPath.Split(new char[] { '|' });
            if ((strArray.Length - 1) == 1)
            {
                return ShowTest;
            }
            string str = null;
            for (int i = 0; i < (strArray.Length - 2); i++)
            {
                str = str + "　";
            }
            return (str + "└ " + ShowTest);
        }
    }
}

