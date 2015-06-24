using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

public class ExcelToDataset
{
    public static DataSet GetDataSet(string FilePath)
    {
        DataSet set2;
        OleDbConnection selectConnection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + FilePath + "';Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", new object[0]));
        ArrayList list = new ArrayList();
        try
        {
            if (selectConnection.State == ConnectionState.Closed)
            {
                selectConnection.Open();
            }
            object[] restrictions = new object[4];
            restrictions[3] = "TABLE";
            DataTable oleDbSchemaTable = selectConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
            string str2 = "";
            for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
            {
                str2 = oleDbSchemaTable.Rows[i]["TABLE_NAME"].ToString();
                list.Add(str2);
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            selectConnection.Close();
        }
        DataSet set = new DataSet();
        try
        {
            for (int j = 0; j < list.Count; j++)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [" + ((string) list[j]) + "]", selectConnection);
                DataTable dataTable = new DataTable((string) list[j]);
                adapter.Fill(dataTable);
                set.Tables.Add(dataTable);
            }
            set2 = set;
        }
        catch (Exception exception2)
        {
            throw exception2;
        }
        return set2;
    }
}

