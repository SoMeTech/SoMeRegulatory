namespace ASP
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Web;
    using System.Web.Profile;

    [CompilerGlobalScope]
    public class global_asax : HttpApplication
    {
        private static bool __initialized;

        [DebuggerNonUserCode]
        public global_asax()
        {
            if (!__initialized)
            {
                __initialized = true;
            }
        }

        private void Application_End(object sender, EventArgs e)
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/"))
            {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "/temp/", true);
            }
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/temp/");
            }
        }

        private void Application_Error(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            if (((context != null) && (context.Error != null)) && (context.Error.InnerException != null))
            {
                string path = context.Server.MapPath("~/log/SystemRunErrLog/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string contents = "时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " 出错页面：" + context.Request.Path + "  信息：" + context.Error.InnerException.Message + "\r\n详细堆栈信息：\r\n" + context.Error.InnerException.StackTrace + "\r\n\r\n\r\n ";
                File.AppendAllText(path + "/SystemMessage[" + DateTime.Now.ToString("yyyy-MM-dd") + "].log", contents);
            }
        }

        private void Application_Start(object sender, EventArgs e)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/temp/");
            }
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/WebControls/UserControl/upfile/"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/WebControls/UserControl/upfile/");
            }
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/UserImages/"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/UserImages/");
            }
        }

        private void Session_End(object sender, EventArgs e)
        {
        }

        private void Session_Start(object sender, EventArgs e)
        {
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)base.Context.Profile;
            }
        }
    }
}
