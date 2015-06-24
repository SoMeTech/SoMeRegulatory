namespace BHSoft.BHWeb.Public
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class ErrLog
    {
        private string logFile = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-1.log");

        private void CreateFile(string strPath, out string err)
        {
            StreamWriter writer = null;
            err = "";
            try
            {
                if (!File.Exists(strPath))
                {
                    writer = File.CreateText(strPath);
                }
                else
                {
                    err = "文件已存在！";
                }
            }
            catch (Exception exception)
            {
                err = exception.Message;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        private void CreateLogFile(string strPath, out string err)
        {
            StreamWriter writer = null;
            err = "";
            try
            {
                if (DateTime.Now.Day == 1)
                {
                    if (!File.Exists(strPath))
                    {
                        writer = File.CreateText(strPath);
                    }
                    else
                    {
                        err = "文件已存在！";
                    }
                }
            }
            catch (Exception exception)
            {
                err = exception.Message;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        private void Write(string strText, string strPath, out string err)
        {
            StreamWriter writer = null;
            err = "";
            try
            {
                if (File.Exists(strPath))
                {
                    writer = new StreamWriter(strPath, true);
                    writer.WriteLine(strText);
                }
                else
                {
                    this.CreateFile(strPath, out err);
                }
            }
            catch (Exception exception)
            {
                err = exception.Message;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        public bool WriteLog(string strText, string strPath, out string err)
        {
            err = "";
            strPath = strPath + this.logFile;
            this.CreateLogFile(strPath, out err);
            this.Write(strText, strPath, out err);
            return true;
        }
    }
}

