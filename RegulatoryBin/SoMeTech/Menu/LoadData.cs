namespace SoMeTech.Menu
{
    using QxRoom.QxXml;
    using System;
    using System.Data;
    using System.Xml;

    [Serializable]
    public sealed class LoadData
    {
        private DataTable columnmess;
        private string tablename;
        private string textname;
        private string type;

        public static LoadData[] LoadXml(string strpath)
        {
            LoadData[] dataArray = null;
            LoadData[] dataArray2;
            string str = strpath;
            QxXmlDocument document = new QxXmlDocument();
            try
            {
                document.Filepath = str;
                document.OpenXml();
                int depth = document.GetDepth("/DataMessage/DataTableItem");
                if (depth > 0)
                {
                    int num2 = 0;
                    dataArray = new LoadData[depth];
                    for (int i = 0; i < depth; i++)
                    {
                        dataArray[i] = new LoadData();
                        dataArray[i].TableName = document.SearchAttribute("/DataMessage/DataTableItem", i, null, "TableName");
                        dataArray[i].TextName = document.SearchAttribute("/DataMessage/DataTableItem", i, null, "Text");
                        dataArray[i].Type = "Table";
                        DataTable table = new DataTable();
                        table.Columns.Add(new DataColumn("列英文名"));
                        table.Columns.Add(new DataColumn("数据类型"));
                        table.Columns.Add(new DataColumn("列中文名"));
                        table.Columns.Add(new DataColumn("列英文名和数据类型"));
                        table.Columns.Add(new DataColumn("Column"));
                        XmlNode xn = document.GetNode("/DataMessage/DataTableItem", i);
                        int num4 = document.GetDepth(xn);
                        for (int j = 0; j < num4; j++)
                        {
                            DataRow row = table.NewRow();
                            row["列英文名"] = document.SearchAttribute("/DataMessage/DataTableItem/DataColumnItem", num2 + j, null, "ColumnName");
                            row["数据类型"] = document.SearchAttribute("/DataMessage/DataTableItem/DataColumnItem", num2 + j, null, "ColumnType");
                            row["列中文名"] = document.GetNodeString("/DataMessage/DataTableItem/DataColumnItem", num2 + j);
                            row["列英文名和数据类型"] = document.SearchAttribute("/DataMessage/DataTableItem/DataColumnItem", num2 + j, null, "ColumnName") + "|" + document.SearchAttribute("/DataMessage/DataTableItem/DataColumnItem", num2 + j, null, "ColumnType");
                            row["Column"] = "Column";
                            table.Rows.Add(row);
                        }
                        num2 += num4;
                        dataArray[i].ColumnMess = table;
                    }
                }
                dataArray2 = dataArray;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataArray2;
        }

        public DataTable ColumnMess
        {
            get
            {
                return this.columnmess;
            }
            set
            {
                this.columnmess = value;
            }
        }

        public string TableName
        {
            get
            {
                return this.tablename;
            }
            set
            {
                this.tablename = value;
            }
        }

        public string TextName
        {
            get
            {
                return this.textname;
            }
            set
            {
                this.textname = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

