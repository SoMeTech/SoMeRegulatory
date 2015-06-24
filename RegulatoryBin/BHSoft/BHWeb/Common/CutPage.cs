namespace BHSoft.BHWeb.Common
{
    using System;

    public class CutPage
    {
        public static int CutPages(float int1, float int2)
        {
            int num = 0;
            if ((int1 / int2) <= 1f)
            {
                return 1;
            }
            if (((int1 / int2) > 1f) & (((int1 % int2) / int2) >= 0.5))
            {
                return Convert.ToInt32((float) (int1 / int2));
            }
            if (((int1 / int2) > 1f) & ((int1 % int2) == 0f))
            {
                return Convert.ToInt32((float) (int1 / int2));
            }
            if ((int1 != 0.0) && (int2 != 0.0))
            {
                num = Convert.ToInt32((float) ((int1 / int2) + 1f));
            }
            return num;
        }
    }
}

