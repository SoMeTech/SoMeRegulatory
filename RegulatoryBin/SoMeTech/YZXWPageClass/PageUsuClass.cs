namespace SoMeTech.YZXWPageClass
{
    using ExceptionLog;
    using SoMeTech.DataAccess;
    using SoMeTech.Dictionary.SFProCountStandard;
    using SoMeTech.Dictionary.SFProject;
    using SoMeTech.DllAccess;
    using SoMeTech.Menu;
    using SoMeTech.ServicesClass.Operation;
    using SoMeTech.ServicesClass.Services;
    using SoMeTech.User;
    using QxRoom.Common;
    using QxRoom.Common.ControlDo;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Xml;

    public sealed class PageUsuClass
    {
  

        public static DataSet GetPageSizeData(string strlist, string strtablename, string strwhere, string strorderid, string strorder, int strno, int pagesize, out string ii)
        {
            DB_OPT db_opt = new DB_OPT();
            object parameters = GetPara(strlist, strtablename, strwhere, strorderid, strorder, strno, pagesize);
            DataSet set = db_opt.SqlSelectProcPar("GETDATASETBYNUM.GetListByNum", parameters);
            if (DB_OPT.DBT == DataBaseType.SqlServer)
            {
                ii = ((SqlParameter[])parameters)[7].Value.ToString();
                return set;
            }
            ii = ((OracleParameter[])parameters)[7].Value.ToString();
            return set;
        }



        private static object GetPara(string strlist, string strtablename, string strwhere, string strorderid, string strorder, int strno, int pagesize)
        {
            if (DB_OPT.DBT == DataBaseType.SqlServer)
            {
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("TableList", SqlDbType.NVarChar), new SqlParameter("TableName", SqlDbType.NVarChar), new SqlParameter("SelectWhere", SqlDbType.NVarChar), new SqlParameter("SelectOrderId", SqlDbType.NVarChar), new SqlParameter("SelectOrder", SqlDbType.NVarChar), new SqlParameter("intPageNo", SqlDbType.Int), new SqlParameter("intPageSize", SqlDbType.Int), new SqlParameter("RecordCount", SqlDbType.Int) };
                parameterArray[0].Value = strlist;
                parameterArray[0].Direction = ParameterDirection.Input;
                parameterArray[1].Value = strtablename;
                parameterArray[1].Direction = ParameterDirection.Input;
                parameterArray[2].Value = strwhere;
                parameterArray[2].Direction = ParameterDirection.Input;
                parameterArray[3].Value = strorderid;
                parameterArray[3].Direction = ParameterDirection.Input;
                parameterArray[4].Value = strorder;
                parameterArray[4].Direction = ParameterDirection.Input;
                parameterArray[5].Value = strno.ToString();
                parameterArray[5].Direction = ParameterDirection.Input;
                parameterArray[6].Value = pagesize.ToString();
                parameterArray[6].Direction = ParameterDirection.Input;
                parameterArray[7].Direction = ParameterDirection.Output;
                return parameterArray;
            }
            OracleParameter[] parameterArray2 = new OracleParameter[] { new OracleParameter("TableList", OracleType.VarChar), new OracleParameter("TableName", OracleType.VarChar), new OracleParameter("SelectWhere", OracleType.VarChar), new OracleParameter("SelectOrderId", OracleType.VarChar), new OracleParameter("SelectOrder", OracleType.VarChar), new OracleParameter("intPageNo", OracleType.Number), new OracleParameter("intPageSize", OracleType.Number), new OracleParameter("RecordCount", OracleType.Number), new OracleParameter("p_cursor", OracleType.Cursor) };
            parameterArray2[0].Value = strlist;
            parameterArray2[0].Direction = ParameterDirection.Input;
            parameterArray2[1].Value = strtablename;
            parameterArray2[1].Direction = ParameterDirection.Input;
            parameterArray2[2].Value = strwhere;
            parameterArray2[2].Direction = ParameterDirection.Input;
            parameterArray2[3].Value = strorderid;
            parameterArray2[3].Direction = ParameterDirection.Input;
            parameterArray2[4].Value = strorder;
            parameterArray2[4].Direction = ParameterDirection.Input;
            parameterArray2[5].Value = strno.ToString();
            parameterArray2[5].Direction = ParameterDirection.Input;
            parameterArray2[6].Value = pagesize.ToString();
            parameterArray2[6].Direction = ParameterDirection.Input;
            parameterArray2[7].Direction = ParameterDirection.Output;
            parameterArray2[8].Direction = ParameterDirection.Output;
            return parameterArray2;
        }

        public static void PageChangControl(int nPageIndex, string pageid, Page page)
        {
            if ((int.Parse(Property.GetClassProperty(page.Master, "ControlsPush")) == 2) || !page.IsPostBack)
            {
                if (!page.IsPostBack)
                {
                    if ((page.Request.Cookies[pageid + "_PageIndex"] != null) && (page.Request.Cookies[pageid + "_PageSize"] != null))
                    {
                        nPageIndex = int.Parse(page.Request.Cookies[pageid + "_PageIndex"].Value);
                        Property.SetClassProperty(page.Master, "PageSize", int.Parse(page.Request.Cookies[pageid + "_PageSize"].Value));
                    }
                    HttpCookie cookie1 = page.Request.Cookies[pageid + "_StrSelect"];
                }
                Property.SetClassProperty(page.Master, "PageIndex", nPageIndex);
                Type[] methodParamsType = new Type[] { Property.GetClassProperty(page.Master, "StrSelect").GetType() };
                object[] methodParams = new object[] { Property.GetClassProperty(page.Master, "StrSelect") };
                Classes.InvokeClassMethod(page, "ShowData", false, methodParamsType, methodParams);
                page.Response.Cookies[pageid + "_StrSelect"].Value = page.Server.UrlEncode(Property.GetClassProperty(page.Master, "StrSelect"));
                page.Response.Cookies[pageid + "_PageIndex"].Value = nPageIndex.ToString();
                page.Response.Cookies[pageid + "_PageSize"].Value = Property.GetClassProperty(page.Master, "PageSize");
            }
        }

        
       

        public static void ReadSqlIp(TextBox txtServer, Page page)
        {
            try
            {
                string filename = HttpContext.Current.Server.MapPath("web.config");
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                foreach (XmlElement element in document.DocumentElement.ChildNodes)
                {
                    if (element.Name == "appSettings")
                    {
                        XmlNodeList childNodes = element.ChildNodes;
                        if (childNodes.Count > 0)
                        {
                            foreach (XmlElement element2 in childNodes)
                            {
                                if (element2.Attributes["key"].Value.ToLower() == "dataconn")
                                {
                                    string str2 = element2.Attributes["value"].Value;
                                    txtServer.Text = str2.Substring(str2.IndexOf("=") + 1, (str2.IndexOf(";") - str2.IndexOf("=")) - 1);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                new ExceptionLog { ErrClassName = page.GetType().ToString(), ErrMessage = exception.Message.ToString(), ErrMethod = "HR.YZXWPageClass.PageUsuClass.ReadSqlIp()" }.WriteExceptionLog(true);
                PageShowText.OpenErrorPage("读取文件失败，请联系管理员！", page);
            }
        }




        public static void SearchControl(string strselect, string strcloname, string strsql, int pageind, string pageid, Page page)
        {
            if (int.Parse(Property.GetClassProperty(page.Master, "ControlsPush")) == 2)
            {
                if (!page.IsPostBack)
                {
                    if ((page.Request.Cookies[pageid + "_PageIndex"] != null) && (page.Request.Cookies[pageid + "_PageSize"] != null))
                    {
                        pageind = int.Parse(page.Request.Cookies[pageid + "_PageIndex"].Value);
                        Property.SetClassProperty(page.Master, "PageSize", int.Parse(page.Request.Cookies[pageid + "_PageSize"].Value));
                    }
                    HttpCookie cookie1 = page.Request.Cookies[pageid + "_StrSelect"];
                }
                Property.SetClassProperty(page.Master, "StrSelect", strselect);
                Property.SetClassProperty(page.Master, "StrClomun", strcloname);
                Property.SetClassProperty(page.Master, "StrSql", strsql);
                Type[] methodParamsType = new Type[] { Property.GetClassProperty(page.Master, "StrSelect").GetType() };
                object[] methodParams = new object[] { Property.GetClassProperty(page.Master, "StrSelect") };
                Classes.InvokeClassMethod(page, "ShowData", false, methodParamsType, methodParams);
                Property.SetClassProperty(page.Master, "PageIndex", pageind);
                page.Response.Cookies[pageid + "_StrSelect"].Value = page.Server.UrlEncode(strselect);
                page.Response.Cookies[pageid + "_PageIndex"].Value = pageind.ToString();
                page.Response.Cookies[pageid + "_PageSize"].Value = Property.GetClassProperty(page.Master, "PageSize");
            }
        }
    

    }
}

