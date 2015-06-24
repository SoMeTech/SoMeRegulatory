namespace SoMeTech.YZXWPageClass
{
    using ExceptionLog;
    using System;

    public sealed class WriteTimePass
    {
        private static int end;
        private static int start;

        public static void WriteLog_Time(string className, string methodName, string strLog, int startTime)
        {
            ExceptionLog log = new ExceptionLog {
                ErrClassName = className
            };
            log.ErrMessage = strLog + "。执行花费时间：" + ((End - startTime)).ToString();
            log.ErrMethod = methodName;
            log.WriteExceptionLog(true);
        }

        public static int End
        {
            get
            {
                return Environment.TickCount;
            }
            set
            {
                end = value;
            }
        }

        public static int Start
        {
            get
            {
                return Environment.TickCount;
            }
            set
            {
                start = value;
            }
        }
    }
}

