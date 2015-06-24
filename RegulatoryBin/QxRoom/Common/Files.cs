namespace QxRoom.Common
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;

    public class Files
    {
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
        }

        public static void CreateFileIn(string path)
        {
            string str = HttpContext.Current.Server.MapPath(path);
            if (!File.Exists(str))
            {
                File.CreateText(str);
            }
        }

        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void CreateFolderIn(string path)
        {
            string str = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(str))
            {
                Directory.CreateDirectory(str);
            }
        }

        public static void DelImgFile(string FilePath)
        {
            try
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(FilePath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(FilePath));
                }
            }
            catch
            {
            }
        }

        public static bool ExsitFile(string path)
        {
            bool flag = false;
            if (File.Exists(path))
            {
                flag = true;
            }
            return flag;
        }

        public static bool ExsitFileIn(string path)
        {
            try
            {
                bool flag = false;
                if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                {
                    flag = true;
                }
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void readFile(string strPath, string strValue)
        {
            try
            {
                FileStream stream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("GB2312"));
                reader.BaseStream.Seek(0L, SeekOrigin.Begin);
                strValue = " ";
                for (string str = reader.ReadToEnd(); str != null; str = reader.ReadLine())
                {
                    strValue = strValue + str + "\n";
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
        }

        public void writeFile(string strPath, string strValue, bool IfCover)
        {
            try
            {
                StreamWriter writer = new StreamWriter(strPath, IfCover);
                writer.Flush();
                writer.WriteLine(strValue);
                writer.Flush();
                writer.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}

