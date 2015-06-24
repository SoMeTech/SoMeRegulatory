namespace ExceptionLog
{
    using QxRoom.Common;
    using System;

    public class ExceptionLog : Exception
    {
        private string errClassName;
        private string errMessage;
        private string errMethod;
        public static string strLogFileName = ("err" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        public static string strLogFilePath = (AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "/log/");

        public ExceptionLog()
        {
            new Files().writeFile(strLogFilePath + strLogFileName, "", true);
        }

        public void WriteExceptionLog(bool IfCover)
        {
            try
            {
                string strValue = "时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "。类：" + this.errClassName + "，方法：" + this.errMethod + "，信息：" + this.errMessage + "。";
                new Files().writeFile(strLogFilePath + strLogFileName, strValue, IfCover);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string ErrClassName
        {
            set
            {
                this.errClassName = value;
            }
        }

        public string ErrMessage
        {
            set
            {
                this.errMessage = value;
            }
        }

        public string ErrMethod
        {
            set
            {
                this.errMethod = value;
            }
        }

        public string LogFileName
        {
            set
            {
                strLogFileName = value;
            }
        }

        public string LogFilePath
        {
            set
            {
                strLogFilePath = value;
            }
        }
    }
}

