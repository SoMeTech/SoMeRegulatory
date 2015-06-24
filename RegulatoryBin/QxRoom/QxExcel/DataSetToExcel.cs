namespace QxRoom.QxExcel
{
    using excel;
    
    using QxRoom.Common;
    using System;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public sealed class DataSetToExcel
    {
        public string ExcelHeader()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\"?>\n");
            builder.Append("<?mso-application progid=\"Excel.Sheet\"?>\n");
            builder.Append("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
            builder.Append("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
            builder.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
            builder.Append("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
            builder.Append("xmlns:html=\"http://www.w3.org/TR/REC-html40\">\n");
            builder.Append("<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
            builder.Append("</DocumentProperties>");
            builder.Append("<ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">\n");
            builder.Append("<ProtectStructure>False</ProtectStructure>\n");
            builder.Append("<ProtectWindows>False</ProtectWindows>\n");
            builder.Append("</ExcelWorkbook>\n");
            return builder.ToString();
        }

        public void ExportExcel(string titlename, string filePath, string start, string end, string splitTime, char splitCol, DataSet ds)
        {
            this.ExportExcel(titlename, filePath, start, end, splitTime, splitCol, ds, null);
        }

        public void ExportExcel(string titlename, string filePath, string start, string end, string splitTime, char splitCol, DataSet ds, DataSet ds_com)
        {
            string path = "";
            path = filePath.Substring(0, filePath.LastIndexOf("/")) + "/set.ini";
            if (!Files.ExsitFile(path))
            {
                Files.CreateFolder(filePath.Substring(0, filePath.LastIndexOf("/")));
                Files.CreateFile(path);
            }
            if (ds != null)
            {
                excel.Range range;
                excel.Application application = new excel.ApplicationClass();
                if (application == null)
                {
                    throw new Exception("无法创建Excel对象，可能您的电脑未安装Excel");
                }
                excel.Workbook workbook = application.Workbooks.Add(excel.XlWBATemplate.xlWBATWorksheet);
                excel.Worksheet worksheet = (excel.Worksheet) workbook.Worksheets[1];
                object across = Missing.Value;
                int num = 1;
                int length = 1;
                long count = ds.Tables[0].Rows.Count;
                long num4 = 0L;
                if (titlename != "")
                {
                    range = worksheet.get_Range(worksheet.Cells[num, 1], worksheet.Cells[num, ds.Tables[0].Columns.Count]);
                    range.Merge(across);
                    range.Font.Bold = true;
                    range.Font.Size = 0x18;
                    range.RowHeight = 60;
                    range.HorizontalAlignment = 3;
                    range.Value2 = titlename;
                    num++;
                }
                if (start != "")
                {
                    range = worksheet.get_Range(worksheet.Cells[num, 1], worksheet.Cells[num, ds.Tables[0].Columns.Count]);
                    range.Merge(across);
                    range.Font.Size = 12;
                    range.RowHeight = 30;
                    range.HorizontalAlignment = 3;
                    range.Value2 = start + splitTime + end;
                    num++;
                }
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    string[] strArray = ds.Tables[0].Columns[i].ColumnName.Split(new char[] { splitCol });
                    if ((strArray.Length > 1) && (strArray.Length > length))
                    {
                        length = strArray.Length;
                    }
                }
                int[] numArray = new int[length];
                for (int j = 0; j < length; j++)
                {
                    numArray[j] = 0;
                }
                for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                {
                    string[] strArray2 = ds.Tables[0].Columns[k].ColumnName.Split(new char[] { splitCol });
                    if (strArray2.Length > 1)
                    {
                        for (int n = 0; n < strArray2.Length; n++)
                        {
                            int num9 = 1;
                            if ((numArray[n] == k) || (numArray[n] == 0))
                            {
                                for (int num10 = k + 1; num10 < ds.Tables[0].Columns.Count; num10++)
                                {
                                    string[] strArray3 = ds.Tables[0].Columns[num10].ColumnName.Split(new char[] { splitCol });
                                    if (strArray3.Length > n)
                                    {
                                        if (!(strArray2[n] == strArray3[n]))
                                        {
                                            break;
                                        }
                                        num9++;
                                    }
                                }
                                numArray[n] = num9 + k;
                                if (num9 == 1)
                                {
                                    range = (excel.Range) worksheet.Cells[num + n, k + 1];
                                }
                                else
                                {
                                    range = worksheet.get_Range(worksheet.Cells[num + n, k + 1], worksheet.Cells[num + n, k + num9]);
                                    range.Merge(across);
                                }
                                this.SetStyle(strArray2[n], ref range);
                            }
                        }
                        for (int num11 = 0; num11 < length; num11++)
                        {
                            numArray[num11] = 0;
                        }
                    }
                    else
                    {
                        range = worksheet.get_Range(worksheet.Cells[num, k + 1], worksheet.Cells[(num + length) - 1, k + 1]);
                        range.Merge(across);
                        this.SetStyle(ds.Tables[0].Columns[k].ColumnName, ref range);
                    }
                }
                num += length;
                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {
                    for (int num13 = 0; num13 < ds.Tables[0].Columns.Count; num13++)
                    {
                        worksheet.Cells[m + num, num13 + 1] = "'" + ds.Tables[0].Rows[m][num13];
                        range = (excel.Range) worksheet.Cells[m + num, num13 + 1];
                        this.SetRowStyle(filePath, ds.Tables[0].Rows[m][num13].ToString(), ref range, ds, ds_com, m, num13);
                    }
                    num4 += 1L;
                    float single1 = ((float) (100L * num4)) / ((float) count);
                }
                object filename = new object();
                filename = filePath;
                workbook.SaveAs(filename, across, across, across, across, across, excel.XlSaveAsAccessMode.xlShared, across, across, across, across, across);
                workbook.Close(false, across, across);
                application.Quit();
                GC.Collect();
            }
        }

        public void ExportToExcel(DataSet source, Stream memoryStream)
        {
            StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8) {
                AutoFlush = true
            };
            string str = this.ExcelHeader() + "<Styles>\r\n <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n <Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n <Protection/>\r\n </Style>\r\n <Style ss:ID=\"BoldColumn\">\r\n <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n <Interior ss:Color=\"#C0C0C0\" ss:Pattern=\"Solid\"/>\r\n </Style>\r\n <Style ss:ID=\"StringLiteral\">\r\n <NumberFormat ss:Format=\"@\"/>\r\n </Style>\r\n <Style ss:ID=\"Decimal\">\r\n <NumberFormat ss:Format=\"0.0000\"/>\r\n </Style>\r\n <Style ss:ID=\"Integer\">\r\n <NumberFormat ss:Format=\"0\"/>\r\n </Style>\r\n <Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n </Styles>\r\n ";
            int num = 0;
            int num2 = 1;
            writer.Write(str);
            writer.Write("<Worksheet ss:Name=\"Sheet" + num2 + "\">");
            writer.Write("<Table>");
            writer.Write("<Row>");
            int num3 = 0;
            for (int i = 0; i < source.Tables[0].Columns.Count; i++)
            {
                writer.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                writer.Write(source.Tables[0].Columns[i].ColumnName);
                num3 += source.Tables[0].Columns[i].ColumnName.Length;
                writer.Write("</Data></Cell>");
            }
            writer.Write("</Row>");
            foreach (DataRow row in source.Tables[0].Rows)
            {
                num++;
                if (num == 0xfa00)
                {
                    num = 0;
                    num2++;
                    writer.Write("</Table>");
                    writer.Write(" </Worksheet>");
                    writer.Write("<Worksheet ss:Name=\"Sheet" + num2 + "\">");
                    writer.Write("<Table>");
                }
                writer.Write("<Row>");
                for (int j = 0; j < source.Tables[0].Columns.Count; j++)
                {
                    System.Type type = row[j].GetType();
                    switch (type.ToString())
                    {
                        case "System.String":
                        {
                            string str2 = row[j].ToString().Trim().Replace("&", "&").Replace(">", ">").Replace("<", "<");
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(str2);
                            writer.Write("</Data></Cell>");
                            num3 += str2.Length;
                            break;
                        }
                        case "System.DateTime":
                        {
                            DateTime time = (DateTime) row[j];
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(time.ToString("yyyy-MM-dd"));
                            writer.Write("</Data></Cell>");
                            break;
                        }
                        case "System.Boolean":
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            writer.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.Decimal":
                        case "System.Double":
                            writer.Write("<Cell ss:StyleID=\"Decimal\"><Data ss:Type=\"Number\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.DBNull":
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write("");
                            writer.Write("</Data></Cell>");
                            break;

                        default:
                            throw new Exception(type.ToString() + " not handled.");
                    }
                }
                writer.WriteLine("</Row>");
            }
            writer.WriteLine("</Table>");
            writer.WriteLine(" </Worksheet>");
            writer.WriteLine("</Workbook>");
        }

        public void ExportToExcel(DataSet source, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            string str = this.ExcelHeader() + "<Styles>\r\n <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n <Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n <Protection/>\r\n </Style>\r\n <Style ss:ID=\"BoldColumn\">\r\n <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n <Style ss:ID=\"StringLiteral\">\r\n <NumberFormat ss:Format=\"@\"/>\r\n </Style>\r\n <Style ss:ID=\"Decimal\">\r\n <NumberFormat ss:Format=\"0.0000\"/>\r\n </Style>\r\n <Style ss:ID=\"Integer\">\r\n <NumberFormat ss:Format=\"0\"/>\r\n </Style>\r\n <Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n </Styles>\r\n ";
            int num = 0;
            int num2 = 1;
            writer.Write(str);
            writer.Write("<Worksheet ss:Name=\"Sheet" + num2 + "\">");
            writer.Write("<Table>");
            writer.Write("<Row>");
            for (int i = 0; i < source.Tables[0].Columns.Count; i++)
            {
                writer.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                writer.Write(source.Tables[0].Columns[i].ColumnName);
                writer.Write("</Data></Cell>");
            }
            writer.Write("</Row>");
            foreach (DataRow row in source.Tables[0].Rows)
            {
                num++;
                if (num == 0xfa00)
                {
                    num = 0;
                    num2++;
                    writer.Write("</Table>");
                    writer.Write(" </Worksheet>");
                    writer.Write("<Worksheet ss:Name=\"Sheet" + num2 + "\">");
                    writer.Write("<Table>");
                }
                writer.Write("<Row>");
                for (int j = 0; j < source.Tables[0].Columns.Count; j++)
                {
                    System.Type type = row[j].GetType();
                    switch (type.ToString())
                    {
                        case "System.String":
                        {
                            string str2 = row[j].ToString().Trim().Replace("&", "&").Replace(">", ">").Replace("<", "<");
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(str2);
                            writer.Write("</Data></Cell>");
                            break;
                        }
                        case "System.DateTime":
                        {
                            DateTime time = (DateTime) row[j];
                            string str3 = "";
                            str3 = time.Year.ToString() + "-" + ((time.Month < 10) ? ("0" + time.Month.ToString()) : time.Month.ToString()) + "-" + ((time.Day < 10) ? ("0" + time.Day.ToString()) : time.Day.ToString()) + "T" + ((time.Hour < 10) ? ("0" + time.Hour.ToString()) : time.Hour.ToString()) + ":" + ((time.Minute < 10) ? ("0" + time.Minute.ToString()) : time.Minute.ToString()) + ":" + ((time.Second < 10) ? ("0" + time.Second.ToString()) : time.Second.ToString()) + ".000";
                            writer.Write("<Cell ss:StyleID=\"DateLiteral\"><Data ss:Type=\"DateTime\">");
                            writer.Write(str3);
                            writer.Write("</Data></Cell>");
                            break;
                        }
                        case "System.Boolean":
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            writer.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.Decimal":
                        case "System.Double":
                            writer.Write("<Cell ss:StyleID=\"Decimal\"><Data ss:Type=\"Number\">");
                            writer.Write(row[j].ToString());
                            writer.Write("</Data></Cell>");
                            break;

                        case "System.DBNull":
                            writer.Write("<Cell ss:StyleID=\"StringLiteral\"><Data ss:Type=\"String\">");
                            writer.Write("");
                            writer.Write("</Data></Cell>");
                            break;

                        default:
                            throw new Exception(type.ToString() + " not handled.");
                    }
                }
                writer.Write("</Row>");
            }
            writer.Write("</Table>");
            writer.Write(" </Worksheet>");
            writer.Write("</Workbook>");
            writer.Close();
        }

        public static void ExportToExcel(string filePath, DataSet ds)
        {
            object updateLinks = Missing.Value;
            excel.ApplicationClass o = new excel.ApplicationClass();
            try
            {
                excel.Workbook workbook = o.Workbooks.Open(filePath, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    excel.Worksheet worksheet = (excel.Worksheet) workbook.Worksheets.Add(updateLinks, updateLinks, 1, updateLinks);
                    worksheet.Name = ds.Tables[i].TableName;
                    string data = "";
                    for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    {
                        for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                        {
                            data = data + ds.Tables[i].Rows[j][k].ToString();
                            if (k < (ds.Tables[i].Columns.Count - 1))
                            {
                                data = data + "\t";
                            }
                        }
                        data = data + "\n";
                    }
                    Clipboard.SetDataObject("");
                    Clipboard.SetDataObject(data);
                    ((excel.Range) worksheet.Cells[1, 1]).Select();
                    worksheet.Paste(updateLinks, updateLinks);
                    Clipboard.SetDataObject("");
                }
                workbook.Close(excel.XlSaveAction.xlSaveChanges, updateLinks, updateLinks);
                Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                o.Quit();
                Marshal.ReleaseComObject(o);
                o = null;
                GC.Collect();
            }
        }

        public void PumpToExcel(string xlsPath, string txtPath, DataSet ds)
        {
            DataRow[] rowArray = ds.Tables[0].Select("1=1");
            System.Data.DataTable table = ds.Tables[0];
            StreamWriter writer = new StreamWriter(txtPath, false, Encoding.Default);
            string str = "";
            foreach (DataColumn column in table.Columns)
            {
                str = str + column.Caption + "\t";
            }
            writer.WriteLine(str + "\a");
            int count = table.Rows.Count;
            int num2 = table.Columns.Count;
            for (int i = 2; i < (2 + count); i++)
            {
                str = "";
                for (int j = 1; j < (num2 + 1); j++)
                {
                    str = str + rowArray[i - 2][j - 1].ToString() + "\t";
                }
                writer.WriteLine(str + "\a");
            }
            writer.Flush();
            File.Copy(txtPath, xlsPath, true);
            writer.Close();
        }

        private void SetRowStyle(string filePath, string val, ref excel.Range range, DataSet ds, DataSet ds_com, int r, int i)
        {
            range.Borders.Weight = 2;
            range.Value2 = val;
            range.Font.Size = 9;
            range.RowHeight = 30;
            range.HorizontalAlignment = -4152;
            range.WrapText = true;
            if ((filePath.IndexOf("一体化中心收入") > 0) && (ds_com != null))
            {
                string str = ds.Tables[0].Rows[r]["单位名称"].ToString();
                if (ds_com.Tables[0].Select("name='" + str + "'").Length > 0)
                {
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                    if (i == 0)
                    {
                        range.HorizontalAlignment = -4131;
                    }
                }
                if (i == 1)
                {
                    range.HorizontalAlignment = -4131;
                }
            }
            if ((filePath.IndexOf("地税局基建环节征收") > 0) && (i < 7))
            {
                range.HorizontalAlignment = -4131;
            }
            if ((filePath.IndexOf("地税局销售环节征收") > 0) && (i < 7))
            {
                range.HorizontalAlignment = -4131;
            }
            if ((filePath.IndexOf("耕地占用税征收") > 0) && (i < 4))
            {
                range.HorizontalAlignment = -4131;
            }
            if ((filePath.IndexOf("国税局建筑环节征收") > 0) && (i < 6))
            {
                range.HorizontalAlignment = -4131;
            }
            if ((filePath.IndexOf("契税征收") > 0) && (i < 5))
            {
                range.HorizontalAlignment = -4131;
            }
            if ((filePath.IndexOf("土地出让金宗地收入") > 0) && (i < 5))
            {
                range.HorizontalAlignment = -4131;
            }
            if ((filePath.IndexOf("一体化征收") > 0) && (i < 7))
            {
                range.HorizontalAlignment = -4131;
            }
        }

        private void SetStyle(string val, ref excel.Range range)
        {
            range.Borders.Weight = 2;
            range.Interior.ColorIndex = 15;
            range.Font.Bold = true;
            range.Font.Size = 12;
            range.RowHeight = 40;
            range.HorizontalAlignment = 3;
            range.ColumnWidth = 12;
            range.WrapText = true;
            range.Value2 = val;
        }
    }
}

