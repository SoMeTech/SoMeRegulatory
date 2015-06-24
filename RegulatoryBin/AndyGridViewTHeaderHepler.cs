using System;
using System.Web.UI.WebControls;

public class AndyGridViewTHeaderHepler
{
    private string[,] ConvertList(string newHeaders, int row, int col)
    {
        string[] strArray = newHeaders.Split(new char[] { '#' });
        string[,] strArray2 = new string[col, row];
        string str = "";
        for (int i = 0; i < col; i++)
        {
            string[] strArray3 = strArray[i].ToString().Split(new char[] { ' ' });
            for (int j = 0; j < row; j++)
            {
                if ((strArray3.Length - 1) >= j)
                {
                    if (strArray3[j].Contains(","))
                    {
                        if (strArray3.Length != row)
                        {
                            if (str == "")
                            {
                                strArray2[i, j] = strArray2[i, j - 1];
                                str = strArray3[j].ToString();
                            }
                            else
                            {
                                strArray2[i, j + 1] = str;
                                str = "";
                            }
                        }
                        else
                        {
                            strArray2[i, j] = strArray3[j].ToString();
                        }
                    }
                    else
                    {
                        strArray2[i, j] = strArray3[j].ToString();
                    }
                }
                else if (str == "")
                {
                    strArray2[i, j] = strArray2[i, j - 1];
                }
                else
                {
                    strArray2[i, j] = str;
                    str = "";
                }
            }
        }
        return strArray2;
    }

    private int GetColCount(string newHeaders)
    {
        return newHeaders.Split(new char[] { '#' }).Length;
    }

    private int GetRowCount(string newHeaders)
    {
        string[] strArray = newHeaders.Split(new char[] { '#' });
        int num = 0;
        foreach (string str in strArray)
        {
            int length = str.Split(new char[] { ' ' }).Length;
            if (length > num)
            {
                num = length;
            }
        }
        return num;
    }

    private int GetSpanColCount(string[,] ColumnList, int row, int col, int rowIndex, int colIndex)
    {
        string str = ColumnList[colIndex, rowIndex];
        int length = ColumnList[colIndex, row - 1].Split(new char[] { ',' }).Length;
        length = (length == 1) ? 0 : length;
        for (int i = colIndex + 1; i < col; i++)
        {
            if (ColumnList[i, rowIndex] == str)
            {
                length += ColumnList[i, row - 1].Split(new char[] { ',' }).Length;
            }
            else
            {
                str = ColumnList[i, rowIndex];
                return length;
            }
        }
        return length;
    }

    private int GetSpanRowCount(string[,] ColumnList, int row, int rowIndex, int colIndex)
    {
        string str = "";
        int num = 1;
        for (int i = rowIndex; i < row; i++)
        {
            if (ColumnList[colIndex, i] == str)
            {
                num++;
            }
            else
            {
                str = ColumnList[colIndex, i];
            }
        }
        return num;
    }

    private int IsVisible(string[,] ColumnList, int rowIndex, int colIndex, string CurrName)
    {
        if (rowIndex != 0)
        {
            if (ColumnList[colIndex, rowIndex - 1] == CurrName)
            {
                return 0;
            }
            if (ColumnList[colIndex, rowIndex].Contains(","))
            {
                return -1;
            }
        }
        return 1;
    }

    public void SplitTableHeader(DataGridItem targetHeader, string newHeaderNames)
    {
        TableCellCollection cells = targetHeader.Cells;
        cells.Clear();
        int rowCount = this.GetRowCount(newHeaderNames);
        int colCount = this.GetColCount(newHeaderNames);
        string[,] columnList = this.ConvertList(newHeaderNames, rowCount, colCount);
        int num3 = 0;
        int num4 = 0;
        for (int i = 0; i < rowCount; i++)
        {
            string currName = "";
            for (int j = 0; j < colCount; j++)
            {
                string str2;
                string[] strArray3;
                int num9;
                if ((currName == columnList[j, i]) && (i != (rowCount - 1)))
                {
                    currName = columnList[j, i];
                }
                else
                {
                    currName = columnList[j, i];
                    switch (this.IsVisible(columnList, i, j, currName))
                    {
                        case -1:
                            strArray3 = currName.Split(new char[] { ',' });
                            num9 = 0;
                            goto Label_018A;

                        case 1:
                            num3 = this.GetSpanRowCount(columnList, rowCount, i, j);
                            num4 = this.GetSpanColCount(columnList, rowCount, colCount, i, j);
                            cells.Add(new TableHeaderCell());
                            cells[cells.Count - 1].RowSpan = num3;
                            cells[cells.Count - 1].ColumnSpan = num4;
                            cells[cells.Count - 1].HorizontalAlign = HorizontalAlign.Center;
                            cells[cells.Count - 1].Text = currName;
                            break;
                    }
                }
                continue;
            Label_0148:
                str2 = strArray3[num9];
                cells.Add(new TableHeaderCell());
                cells[cells.Count - 1].HorizontalAlign = HorizontalAlign.Center;
                cells[cells.Count - 1].Text = str2;
                num9++;
            Label_018A:
                if (num9 < strArray3.Length)
                {
                    goto Label_0148;
                }
            }
            if (i != (rowCount - 1))
            {
                cells[cells.Count - 1].Text = cells[cells.Count - 1].Text + "</th></tr><tr class=\"" + targetHeader.CssClass + "\">";
            }
        }
    }

    public void SplitTableHeader(GridViewRow targetHeader, string newHeaderNames)
    {
        TableCellCollection cells = targetHeader.Cells;
        cells.Clear();
        int rowCount = this.GetRowCount(newHeaderNames);
        int colCount = this.GetColCount(newHeaderNames);
        string[,] columnList = this.ConvertList(newHeaderNames, rowCount, colCount);
        int num3 = 0;
        int num4 = 0;
        for (int i = 0; i < rowCount; i++)
        {
            string currName = "";
            for (int j = 0; j < colCount; j++)
            {
                string str2;
                string[] strArray3;
                int num9;
                if ((currName == columnList[j, i]) && (i != (rowCount - 1)))
                {
                    currName = columnList[j, i];
                }
                else
                {
                    currName = columnList[j, i];
                    switch (this.IsVisible(columnList, i, j, currName))
                    {
                        case -1:
                            strArray3 = currName.Split(new char[] { ',' });
                            num9 = 0;
                            goto Label_018A;

                        case 1:
                            num3 = this.GetSpanRowCount(columnList, rowCount, i, j);
                            num4 = this.GetSpanColCount(columnList, rowCount, colCount, i, j);
                            cells.Add(new TableHeaderCell());
                            cells[cells.Count - 1].RowSpan = num3;
                            cells[cells.Count - 1].ColumnSpan = num4;
                            cells[cells.Count - 1].HorizontalAlign = HorizontalAlign.Center;
                            cells[cells.Count - 1].Text = currName;
                            break;
                    }
                }
                continue;
            Label_0148:
                str2 = strArray3[num9];
                cells.Add(new TableHeaderCell());
                cells[cells.Count - 1].HorizontalAlign = HorizontalAlign.Center;
                cells[cells.Count - 1].Text = str2;
                num9++;
            Label_018A:
                if (num9 < strArray3.Length)
                {
                    goto Label_0148;
                }
            }
            if (i != (rowCount - 1))
            {
                cells[cells.Count - 1].Text = cells[cells.Count - 1].Text + "</th></tr><tr  class=\"HeaderTR\">";
            }
        }
    }

    public void SplitTableHeaderHTML(GridViewRow targetHeader, string newHeaderNames)
    {
        TableCellCollection cells = targetHeader.Cells;
        cells.Clear();
        cells.Add(new TableHeaderCell());
        int index = newHeaderNames.IndexOf("<tr", StringComparison.OrdinalIgnoreCase);
        int num2 = newHeaderNames.IndexOf(">", index);
        int num3 = newHeaderNames.LastIndexOf("</table>", StringComparison.OrdinalIgnoreCase);
        newHeaderNames = newHeaderNames.Substring(num2 + 1, (newHeaderNames.Length - (num2 + 1)) - (newHeaderNames.Length - num3));
        index = newHeaderNames.IndexOf("<td", StringComparison.OrdinalIgnoreCase);
        num2 = newHeaderNames.IndexOf(">", index);
        foreach (string str2 in newHeaderNames.Substring(index + 3, (num2 - index) - 3).Trim().Split(new char[] { ' ' }))
        {
            if ((str2.Trim().Length != 0) && (str2.IndexOf('=') != -1))
            {
                cells[0].Attributes.Add(str2.Split(new char[] { '=' })[0].Replace('"', ' '), str2.Split(new char[] { '=' })[1].Replace('"', ' '));
            }
        }
        newHeaderNames = newHeaderNames.Substring(num2 + 1);
        newHeaderNames = newHeaderNames.Replace("<td", "<th");
        newHeaderNames = newHeaderNames.Replace("</td", "</th");
        newHeaderNames = newHeaderNames.Replace("<tr", "<tr class=\"HeaderRow\" ");
        cells[0].Text = newHeaderNames;
    }
}

