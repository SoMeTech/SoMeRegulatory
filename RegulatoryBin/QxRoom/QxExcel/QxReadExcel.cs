namespace QxRoom.QxExcel
{
    using excel;
    using QxRoom.QxFunctionLog;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class QxReadExcel : IDisposable
    {
        private string _exsheets = "";
        private string _filepath;
        public Worksheet appCurSheet;
        public excel.Application appExcel = new ApplicationClass();
        public Sheets appSheets;
        public Workbook appWork;
        private int k;
        private Missing oMissing = Missing.Value;

        public QxReadExcel()
        {
            IntPtr hwnd = new IntPtr(this.appExcel.Hwnd);
            GetWindowThreadProcessId(hwnd, out this.k);
        }

        public void Dispose()
        {
            if (this.appSheets != null)
            {
                Marshal.ReleaseComObject(this.appSheets);
                this.appSheets = null;
            }
            if (this.appWork != null)
            {
                Marshal.ReleaseComObject(this.appWork);
                this.appWork = null;
            }
            if (this.appExcel != null)
            {
                Marshal.ReleaseComObject(this.appExcel);
                try
                {
                    Process.GetProcessById(this.k).Kill();
                }
                catch (Exception)
                {
                }
                this.appExcel = null;
            }
        }

        ~QxReadExcel()
        {
            this.Dispose();
        }

        public virtual string GetCell(int nrow, int ncolumn)
        {
            return ((excel.Range) this.appCurSheet.Cells[nrow, ncolumn]).Text.ToString();
        }

        public virtual Bitmap GetCellImage(int _rowleft, int _columntop)
        {
            Bitmap data = null;
            this.appCurSheet.get_Range(this.appCurSheet.Cells[_rowleft, _columntop], this.oMissing).CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.Bitmap))
            {
                data = (Bitmap) dataObject.GetData(DataFormats.Bitmap);
            }
            return data;
        }

        public virtual System.Data.DataTable GetCells(DataColumn[] ncolnums, int nbeginrow, int nbegincolumn, int nendrow, int nendcolumn)
        {
            if (ncolnums.Length != Math.Abs((int) (nendrow - nbeginrow)))
            {
                throw new ExcelException("字段名应与数据列数相等");
            }
            System.Data.DataTable table = new System.Data.DataTable();
            for (int i = 0; i < Math.Abs((int) (nendrow - nbeginrow)); i++)
            {
                table.Columns.Add(ncolnums[i]);
            }
            for (int j = 0; j < Math.Abs((int) (nendrow - nbeginrow)); j++)
            {
                DataRow row = table.NewRow();
                for (int k = 0; k < Math.Abs((int) (nendcolumn - nbegincolumn)); k++)
                {
                    row[k] = ((excel.Range) this.appCurSheet.Cells[nbeginrow + j, nbegincolumn + k]).Text.ToString();
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public virtual DataSet GetOleDataSet(string vsheetname)
        {
            DataSet dataSet = null;
            OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this._filepath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"");
            OleDbDataAdapter adapter = null;
            try
            {
                selectConnection.Open();
                adapter = new OleDbDataAdapter("select * from [" + vsheetname + "$]", selectConnection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                adapter.Dispose();
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "GetOleDataSet(string vsheetname)", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("打开Excel失败");
            }
            finally
            {
                adapter.Dispose();
                selectConnection.Close();
                selectConnection.Dispose();
            }
            return dataSet;
        }

        public virtual DataSet GetOleDataSet(string vfilepath, string vsheetname)
        {
            this.FilePath = vfilepath;
            return this.GetOleDataSet(vsheetname);
        }

        public virtual void GetSheet(int nindex)
        {
            try
            {
                this.appSheets = this.appWork.Worksheets;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "GetSheet(int nindex)", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("获得工作区集合失败");
            }
            if (nindex > this.appSheets.Count)
            {
                throw new ExcelException("不存在的工作区");
            }
            try
            {
                this.appCurSheet = (Worksheet) this.appSheets[nindex];
            }
            catch (Exception exception2)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "Open()", ErrContent = exception2.Message }.WriteLog();
                throw new ExcelException("获取工作区失败");
            }
        }

        public virtual void GetSheet(string nsheetname)
        {
            try
            {
                this.appSheets = this.appWork.Worksheets;
                for (int i = 1; i <= this.appSheets.Count; i++)
                {
                    if (((Worksheet) this.appSheets[i]).Name == nsheetname)
                    {
                        this.appCurSheet = (Worksheet) this.appSheets[i];
                    }
                }
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "GetSheet(string nsheetname)", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("获取工作区失败");
            }
        }

        public virtual string[] GetSheets()
        {
            string[] strArray = null;
            try
            {
                this.appSheets = this.appWork.Worksheets;
                strArray = new string[this.appSheets.Count];
                for (int i = 1; i <= this.appSheets.Count; i++)
                {
                    strArray[i - 1] = ((Worksheet) this.appSheets[i]).Name;
                }
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "GetSheets()", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException(exception.Message);
            }
            return strArray;
        }

        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public virtual bool Open()
        {
            bool flag = false;
            try
            {
                this.appWork = this.appExcel.Workbooks.Open(this._filepath, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing);
                flag = true;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "Open()", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("Excel文件打开失败");
            }
            return flag;
        }

        public virtual bool Open(string vfilepath)
        {
            this.FilePath = vfilepath;
            return this.Open();
        }

        public string FilePath
        {
            get
            {
                return this._filepath;
            }
            set
            {
                this._filepath = value;
            }
        }

        public string WorkName
        {
            get
            {
                this._exsheets = this.appCurSheet.Name;
                return this._exsheets;
            }
        }
    }
}

