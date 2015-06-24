using excel;

namespace QxRoom.Common.ControlDo
{
    
    using QxRoom.Common;
    using System;
    using System.Data;
    using System.Reflection;

    public sealed class DataSetDo
    {
        public static void ExportExcel(string titlename, char splitCol, DataSet ds)
        {
            if (ds != null)
            {
                excel.Range range;
                Application application = new ApplicationClass();
                if (application == null)
                {
                    throw new Exception("无法创建Excel对象，可能您的电脑未安装Excel");
                }
                Worksheet worksheet = (Worksheet) application.Workbooks.Add((XlWBATemplate) (-4167)).Worksheets[1];
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
                    range.HorizontalAlignment = 3;
                    range.Value2 = titlename;
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
                                SetStyle(strArray2[n], ref range);
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
                        SetStyle(ds.Tables[0].Columns[k].ColumnName, ref range);
                    }
                }
                num += length;
                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {
                    for (int num13 = 0; num13 < ds.Tables[0].Columns.Count; num13++)
                    {
                        worksheet.Cells[m + num, num13 + 1] = "'" + ds.Tables[0].Rows[m][num13];
                        ((excel.Range) worksheet.Cells[m + num, num13 + 1]).Borders.Weight = 2;
                    }
                    num4 += 1L;
                    float single1 = ((float) (100L * num4)) / ((float) count);
                }
                application.Visible = true;
            }
        }

        public void ExportExcel(string titlename, string filePath, string start, string end, string splitTime, char splitCol, DataSet ds)
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
                Application application = new ApplicationClass();
                if (application == null)
                {
                    throw new Exception("无法创建Excel对象，可能您的电脑未安装Excel");
                }
                Workbook workbook = application.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet worksheet = (Worksheet) workbook.Worksheets[1];
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
                    range.HorizontalAlignment = 3;
                    range.Value2 = titlename;
                    num++;
                }
                if (start != "")
                {
                    range = worksheet.get_Range(worksheet.Cells[num, 1], worksheet.Cells[num, ds.Tables[0].Columns.Count]);
                    range.Merge(across);
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
                                SetStyle(strArray2[n], ref range);
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
                        SetStyle(ds.Tables[0].Columns[k].ColumnName, ref range);
                    }
                }
                num += length;
                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {
                    for (int num13 = 0; num13 < ds.Tables[0].Columns.Count; num13++)
                    {
                        worksheet.Cells[m + num, num13 + 1] = "'" + ds.Tables[0].Rows[m][num13];
                        ((excel.Range) worksheet.Cells[m + num, num13 + 1]).Borders.Weight = 2;
                    }
                    num4 += 1L;
                    float single1 = ((float) (100L * num4)) / ((float) count);
                }
                object filename = new object();
                filename = filePath;
                workbook.SaveAs(filename, across, across, across, across, across, XlSaveAsAccessMode.xlShared, across, across, across, across, across);
                workbook.Close(false, across, across);
                application.Quit();
                GC.Collect();
            }
        }

        public static DataSet GetOnlyDataSet(string str, DataSet ds)
        {
            return GetOnlyDataSet(new string[] { str }, ds);
        }

        public static DataSet GetOnlyDataSet(string[] str, DataSet ds)
        {
            DataSet set = null;
            if (((str == null) || (str.Length <= 0)) || ((ds == null) || (ds.Tables[0].Rows.Count <= 1)))
            {
                return ds;
            }
            set = new DataSet();
            set = ds.Clone();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string filterExpression = "";
                for (int j = 0; j < str.Length; j++)
                {
                    string str3 = filterExpression;
                    filterExpression = str3 + str[j] + "='" + ds.Tables[0].Rows[i][str[j]].ToString().Trim() + "' and ";
                }
                filterExpression = filterExpression.Substring(0, filterExpression.Length - 4);
                if ((set != null) && (set.Tables[0].Select(filterExpression).Length == 0))
                {
                    DataRow row = set.Tables[0].NewRow();
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {
                        string name = ds.Tables[0].Columns[k].DataType.Name;
                        if (name != null)
                        {
                            if (!(name == "DateTime"))
                            {
                                if (!(name == "Decimal"))
                                {
                                    goto Label_02B9;
                                }
                            }
                            else
                            {
                                if ((ds.Tables[0].Rows[i][k].ToString().Trim() != "") && Public.IsDateTime(ds.Tables[0].Rows[i][k].ToString().Trim()))
                                {
                                    row[k] = DateTime.Parse(ds.Tables[0].Rows[i][k].ToString().Trim());
                                }
                                else
                                {
                                    row[k] = DBNull.Value;
                                }
                                continue;
                            }
                            if ((ds.Tables[0].Rows[i][k].ToString().Trim() != "") && Public.IsDecimal(ds.Tables[0].Rows[i][k].ToString().Trim()))
                            {
                                row[k] = decimal.Parse(ds.Tables[0].Rows[i][k].ToString().Trim());
                            }
                            else
                            {
                                row[k] = DBNull.Value;
                            }
                            continue;
                        }
                    Label_02B9:
                        row[k] = ds.Tables[0].Rows[i][k].ToString().Trim();
                    }
                    set.Tables[0].Rows.Add(row);
                }
            }
            return set;
        }

        public static DataSet GetOnlyDataSet(string str, string split, DataSet ds)
        {
            return GetOnlyDataSet(str.Split(new char[] { char.Parse(split) }), ds);
        }

        private static void SetStyle(string val, ref excel.Range range)
        {
            range.Borders.Weight = 2;
            range.Interior.ColorIndex = 15;
            range.Font.Bold = true;
            range.HorizontalAlignment = 3;
            range.ColumnWidth = val.Length * 5;
            range.Value2 = val;
        }
    }
}

