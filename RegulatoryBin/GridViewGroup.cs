using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public class GridViewGroup
{
    public static DataTable AddGurop(DataTable olDtable, string bjName)
    {
        if (olDtable == null)
        {
            return olDtable;
        }
        DataTable table = TableSort(olDtable, bjName);
        Dictionary<int, DataRow> rows = new Dictionary<int, DataRow>();
        IList<string> numColumns = GetNumColumns(table);
        string str = table.Rows[0][bjName].ToString();
        int startRowIndex = 0;
        int endRowIndex = -1;
        foreach (DataRow row in table.Rows)
        {
            endRowIndex++;
            if ((row[bjName].ToString() != str) || (endRowIndex == (table.Rows.Count - 1)))
            {
                if (endRowIndex == (table.Rows.Count - 1))
                {
                    if (row[bjName].ToString() != str)
                    {
                        DataRow row2 = CreateGroupRow(table, numColumns, startRowIndex, endRowIndex);
                        rows.Add(endRowIndex + rows.Count, row2);
                        DataRow row3 = table.NewRow();
                        foreach (string str2 in numColumns)
                        {
                            row3[str2] = row[str2];
                        }
                        rows.Add((endRowIndex + rows.Count) + 1, row3);
                    }
                    else
                    {
                        DataRow row4 = CreateGroupRow(table, numColumns, startRowIndex, endRowIndex);
                        rows.Add((endRowIndex + rows.Count) + 1, row4);
                    }
                }
                else
                {
                    str = row[bjName].ToString();
                    DataRow row5 = CreateGroupRow(table, numColumns, startRowIndex, endRowIndex);
                    startRowIndex = endRowIndex;
                    rows.Add(endRowIndex + rows.Count, row5);
                }
            }
        }
        DataRow row6 = CreateSumRow(table, rows, numColumns);
        foreach (int num3 in rows.Keys)
        {
            table.Rows.InsertAt(rows[num3], num3);
        }
        table.Rows.Add(row6);
        return table;
    }

    public static DataTable AddGurop(DataTable olDtable, string bjName, string numColumsStr)
    {
        if (olDtable == null)
        {
            return olDtable;
        }
        DataTable table = TableSort(olDtable, bjName);
        Dictionary<int, DataRow> rows = new Dictionary<int, DataRow>();
        IList<string> numColumns = new List<string>();
        if (numColumsStr == null)
        {
            numColumns = GetNumColumns(table);
        }
        else
        {
            foreach (string str in numColumsStr.Split(new char[] { '#' }))
            {
                numColumns.Add(str);
            }
        }
        string str2 = table.Rows[0][bjName].ToString();
        int startRowIndex = 0;
        int endRowIndex = -1;
        foreach (DataRow row in table.Rows)
        {
            endRowIndex++;
            if ((row[bjName].ToString() != str2) || (endRowIndex == (table.Rows.Count - 1)))
            {
                if (endRowIndex == (table.Rows.Count - 1))
                {
                    if (row[bjName].ToString() != str2)
                    {
                        DataRow row2 = CreateGroupRow(table, numColumns, startRowIndex, endRowIndex);
                        rows.Add(endRowIndex + rows.Count, row2);
                        DataRow row3 = table.NewRow();
                        foreach (string str3 in numColumns)
                        {
                            row3[str3] = row[str3];
                        }
                        rows.Add((endRowIndex + rows.Count) + 1, row3);
                    }
                    else
                    {
                        DataRow row4 = CreateGroupRow(table, numColumns, startRowIndex, endRowIndex);
                        rows.Add((endRowIndex + rows.Count) + 1, row4);
                    }
                }
                else
                {
                    str2 = row[bjName].ToString();
                    DataRow row5 = CreateGroupRow(table, numColumns, startRowIndex, endRowIndex);
                    startRowIndex = endRowIndex;
                    rows.Add(endRowIndex + rows.Count, row5);
                }
            }
        }
        DataRow row6 = null;
        if (numColumsStr != null)
        {
            row6 = CreateSumRow(table, rows, numColumns);
            foreach (int num3 in rows.Keys)
            {
                table.Rows.InsertAt(rows[num3], num3);
            }
            table.Rows.Add(row6);
        }
        return table;
    }

    private static DataRow CreateGroupRow(DataTable table, IList<string> numColumns, int startRowIndex, int endRowIndex)
    {
        DataRow row = table.NewRow();
        for (int i = startRowIndex; i < (endRowIndex + 1); i++)
        {
            foreach (string str in numColumns)
            {
                if (str != "")
                {
                    object obj2 = row[str];
                    object obj3 = table.Rows[i][str];
                    if ((obj2 == null) || (obj2.ToString().Trim() == ""))
                    {
                        obj2 = 0;
                    }
                    if ((obj3 == null) || (obj3.ToString().Trim() == ""))
                    {
                        obj3 = 0;
                    }
                    row[str] = decimal.Parse(obj2.ToString()) + decimal.Parse(obj3.ToString());
                }
            }
        }
        return row;
    }

    private static DataRow CreateSumRow(DataTable table, Dictionary<int, DataRow> rows, IList<string> numColumns)
    {
        DataRow row = table.NewRow();
        row[0] = "合计";
        foreach (string str in numColumns)
        {
            foreach (int num in rows.Keys)
            {
                object obj2 = row[str];
                if ((obj2 == null) || (obj2.ToString().Trim() == ""))
                {
                    obj2 = 0;
                }
                row[str] = decimal.Parse(obj2.ToString()) + decimal.Parse(rows[num][str].ToString());
            }
        }
        return row;
    }

    private static IList<string> GetNumColumns(DataTable table)
    {
        IList<string> list = new List<string>();
        foreach (DataColumn column in table.Columns)
        {
            if (((column.DataType == typeof(decimal)) || (column.DataType == typeof(int))) || (((column.DataType == typeof(long)) | (column.DataType == typeof(float))) || ((column.DataType == typeof(long)) | (column.DataType == typeof(double)))))
            {
                list.Add(column.ColumnName);
            }
        }
        return list;
    }

    public static void GropCell(GridView gv, int cells, int sRow, int eRow)
    {
        TableCell cell = gv.Rows[sRow].Cells[cells];
        cell.RowSpan = (eRow - sRow) + 1;
        for (int i = sRow + 1; i <= eRow; i++)
        {
            gv.Rows[i].Cells[cells].Visible = false;
        }
    }

    public static void GroupRow(GridView gridView, int rows, int sCol, int eCol)
    {
        TableCell cell = gridView.Rows[rows].Cells[sCol];
        for (int i = 1; i < (eCol - sCol); i++)
        {
            TableCell cell2 = gridView.Rows[rows].Cells[i + sCol];
            cell2.Visible = false;
            if (cell.ColumnSpan == 0)
            {
                cell.ColumnSpan = 1;
            }
            cell.ColumnSpan++;
            cell.VerticalAlign = VerticalAlign.Middle;
        }
    }

    public static DataTable TableSort(DataTable olDtable, string bjName)
    {
        DataTable table = olDtable.Clone();
        foreach (DataRow row in olDtable.Select(null, bjName))
        {
            table.ImportRow(row);
        }
        return table;
    }
}

