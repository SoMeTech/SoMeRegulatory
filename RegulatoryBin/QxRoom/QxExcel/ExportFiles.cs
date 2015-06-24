using Microsoft.Office.Interop.Owc11;

namespace QxRoom.QxExcel
{
    using System;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Web;

    public sealed class ExportFiles
    {
        public void DataSetToExcel(DataSet ds, string FileName)
        {
            try
            {
                HttpResponse response = HttpContext.Current.Response;
                response.ContentEncoding = Encoding.GetEncoding("GB2312");
                response.AppendHeader("Content-disposition", "attachment;filename=" + FileName + ".xls");
                response.ContentType = "application/ms-excel";
                string str = null;
                string str2 = null;
                StringWriter writer = new StringWriter();
                DataTable table = ds.Tables[0];
                DataRow[] rowArray = table.Select();
                int num = 0;
                int count = table.Columns.Count;
                num = 0;
                while (num < count)
                {
                    str = str + table.Columns[num].Caption.ToString() + "t";
                    num++;
                }
                writer.WriteLine(str);
                foreach (DataRow row in rowArray)
                {
                    for (num = 0; num < count; num++)
                    {
                        str2 = str2 + row[num].ToString() + "t";
                    }
                    writer.WriteLine(str2);
                    str2 = null;
                }
                response.Write(writer);
                response.End();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DataSetToExcel(DataSet ds, string FileName, string titlename)
        {
            string str = null;
            if ((FileName == null) || (FileName == ""))
            {
                str = "DFSOFT";
            }
            else
            {
                str = FileName;
            }
            if ((titlename == "") || (titlename == null))
            {
                titlename = "添加标题处(高级报表)";
            }
            DataTable table = ds.Tables[0];
            DataRow[] rowArray = table.Select();
            int num = 0;
            int count = table.Columns.Count;
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ContentEncoding = Encoding.GetEncoding("utf-8");
            response.AppendHeader("Content-disposition", "attachment;filename=" + str + ".xls");
            response.ContentType = "application/vnd.ms-excel";
            string str2 = "<table border='0' cellpadding='0' cellspacing='0' style='border-right:#000000 0.1pt solid;border-top:#000000 0.1pt solid;'>";
            string str3 = "</table>";
            string str4 = null;
            string str5 = null;
            string str6 = string.Concat(new object[] { "<tr><td colspan='", count, "' style='font-size:30px;' align='center'><b>", titlename, "</b></td></tr><tr><td colspan='", count, "' align='right' style='font-size:15px;'>", DateTime.Now.Year.ToString(), "年", DateTime.Now.Month.ToString(), "月", DateTime.Now.Day.ToString(), "日&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>" });
            string str7 = "<tr>";
            string str8 = "</tr>";
            num = 0;
            while (num < count)
            {
                str4 = str4 + "<td style='border-left:#000000 0.1pt solid; border-bottom:#000000 1.0pt solid; font-size:15px;' align='center'><b>" + table.Columns[num].Caption.ToString() + "</b></td>";
                num++;
            }
            str4 = str7.ToString() + str4.ToString() + str8.ToString();
            foreach (DataRow row in rowArray)
            {
                string str9 = null;
                for (num = 0; num < count; num++)
                {
                    str9 = str9 + "<td style='border-left:#000000 0.1pt solid; border-bottom:#000000 1.0pt solid; font-size:15px;' align='center'>" + row[num].ToString() + "</td>";
                }
                str5 = str5 + str7.ToString() + str9.ToString() + str8.ToString();
            }
            response.Write(("<center><table>" + str6.ToString() + "<tr>" + str2.ToString() + str4.ToString() + str5.ToString() + str3.ToString() + "</tr></table></center>").ToString());
            response.End();
        }

        public void DataSetToExcel(DataSet ds, string Duser, string titlename, string filepath)
        {
            SpreadsheetClass class2 = new SpreadsheetClass();
            DataTable table = ds.Tables[0];
            DataRow[] rowArray = table.Select();
            int num = 0;
            int num2 = 1;
            int num3 = num2 + 1;
            int num4 = num3 + 1;
            int num5 = num4 + 1;
            int count = table.Columns.Count;
            string str = null;
            
            
            //class2.get_Range(class2.Cells[num2, num2], class2.Cells[num2, count]).MergeCells = 1;
            if ((titlename == "") || (titlename == null))
            {
                class2.ActiveSheet.Cells[num2, num2] = "添加标题处(高级报表)";
            }
            class2.ActiveSheet.Cells[num2, num2] = titlename.Trim();
            if ((Duser == "") || (Duser == null))
            {
                str = "DFSOFT";
            }
            else
            {
                str = Duser;
            }
           
            /*class2.get_Range(class2.Cells[num2, num2], class2.Cells[num2, count]).Font.Size = 13.0;
            class2.get_Range(class2.Cells[num2, num2], class2.Cells[num2, count]).Font.Bold = 1;
            class2.get_Range(class2.Cells[num4, num2], class2.Cells[num4, count]).Font.Bold = 1;
            class2.get_Range(class2.Cells[num3, num2], class2.Cells[num3, count]).MergeCells = 1;*/
            class2.ActiveSheet.Cells[num3, num2] = "日期:" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日　";
            num = 0;
            while (num < count)
            {
                class2.ActiveSheet.Cells[num4, num + 1] = table.Columns[num].Caption.ToString();
                num++;
            }
            foreach (DataRow row in rowArray)
            {
                for (num = 0; num < count; num++)
                {
                    class2.ActiveSheet.Cells[num5, num + 1] = row[num].ToString().Trim();
                }
                num5++;
            }
            //class2.get_Range(class2.Cells[num4, num2], class2.Cells[num5 - 1, count]).Borders.LineStyle = 1;
            try
            {
                class2.Export(filepath + "//exportfiles//~$" + str + ".xls", SheetExportActionEnum.ssExportActionNone, SheetExportFormat.ssExportXMLSpreadsheet);
            }
            catch (Exception exception)
            {
                throw new Exception("系统调用错误或有打开的Excel文件！" + exception);
            }
            HttpResponse response = HttpContext.Current.Response;
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.AppendHeader("Content-disposition", "attachment;filename=" + str + ".xls");
            response.ContentType = "application/ms-excel";
            FileInfo info = new FileInfo(filepath + "//exportfiles//~$" + str + ".xls");
            response.Clear();
            response.AddHeader("content-length", info.Length.ToString());
            response.WriteFile(info.FullName);
            response.End();
        }

        public void DataSetToWord(DataSet ds, string FileName)
        {
            try
            {
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Buffer = true;
                response.Charset = "utf-8";
                response.ContentEncoding = Encoding.GetEncoding("utf-8");
                response.AppendHeader("Content-disposition", "attachment;filename=" + FileName + ".doc");
                response.ContentType = "application/ms-word";
                string str = null;
                string str2 = null;
                StringWriter writer = new StringWriter();
                DataTable table = ds.Tables[0];
                DataRow[] rowArray = table.Select();
                int num = 0;
                int count = table.Columns.Count;
                num = 0;
                while (num < count)
                {
                    str = str + table.Columns[num].Caption.ToString() + "t";
                    num++;
                }
                writer.WriteLine(str);
                foreach (DataRow row in rowArray)
                {
                    for (num = 0; num < count; num++)
                    {
                        str2 = str2 + row[num].ToString() + "t";
                    }
                    writer.WriteLine(str2);
                    str2 = null;
                }
                response.Write(writer);
                response.End();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DataSetToWord(DataSet ds, string FileName, string titlename)
        {
            string str = null;
            if ((FileName == null) || (FileName == ""))
            {
                str = "DFSOFT";
            }
            else
            {
                str = FileName;
            }
            if ((titlename == "") || (titlename == null))
            {
                titlename = "添加标题处(高级报表)";
            }
            DataTable table = ds.Tables[0];
            DataRow[] rowArray = table.Select();
            int num = 0;
            int count = table.Columns.Count;
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ContentEncoding = Encoding.GetEncoding("utf-8");
            response.AppendHeader("Content-disposition", "attachment;filename=" + str + ".doc");
            response.ContentType = "application/vnd.ms-word";
            string str2 = "<table border='0' cellpadding='0' cellspacing='0' style='border-right:#000000 0.1pt solid;border-top:#000000 0.1pt solid;'>";
            string str3 = "</table>";
            string str4 = null;
            string str5 = null;
            string str6 = "<tr><td style='font-size:13px;' align='center'><b>" + titlename + "</b></td></tr><tr><td align='right' style='font-size:15px;'>" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>";
            string str7 = "<tr>";
            string str8 = "</tr>";
            num = 0;
            while (num < count)
            {
                str4 = str4 + "<td style='border-left:#000000 0.1pt solid; border-bottom:#000000 1.0pt solid; font-size:15px;' align='center'><b>" + table.Columns[num].Caption.ToString() + "</b></td>";
                num++;
            }
            str4 = str7.ToString() + str4.ToString() + str8.ToString();
            foreach (DataRow row in rowArray)
            {
                string str9 = null;
                for (num = 0; num < count; num++)
                {
                    str9 = str9 + "<td style='border-left:#000000 0.1pt solid; border-bottom:#000000 1.0pt solid; font-size:15px;' align='center'>" + row[num].ToString() + "</td>";
                }
                str5 = str5 + str7.ToString() + str9.ToString() + str8.ToString();
            }
            response.Write(("<center><table>" + str6.ToString() + "<tr>" + str2.ToString() + str4.ToString() + str5.ToString() + str3.ToString() + "</tr></table></center>").ToString());
            response.End();
        }
    }
}

