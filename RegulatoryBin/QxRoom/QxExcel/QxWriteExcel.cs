namespace QxRoom.QxExcel
{
    using excel;
    using Microsoft.Office.Core;
    using QxRoom.QxFunctionLog;
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class QxWriteExcel : IDisposable
    {
        private string _exsheets = "";
        private string _filepath;
        public Range appCurRange;
        public Worksheet appCurSheet;
        public Application appExcel = new ApplicationClass();
        public Sheets appSheets;
        public Workbook appWork;
        private int k;
        private Missing oMissing = Missing.Value;

        public QxWriteExcel()
        {
            this.appExcel.DisplayAlerts = false;
            this.appExcel.Visible = false;
            IntPtr hwnd = new IntPtr(this.appExcel.Hwnd);
            GetWindowThreadProcessId(hwnd, out this.k);
        }

        public virtual bool AddSheet()
        {
            bool flag = false;
            try
            {
                this.appWork.Sheets.Add(this.oMissing, this.oMissing, this.oMissing, this.oMissing);
                flag = true;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "AddSheet()", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("新增工作区失败");
            }
            return flag;
        }

        public virtual bool AddWork(Worksheet _sheet)
        {
            bool flag = false;
            try
            {
                this.appSheets.Add(_sheet, this.oMissing, 1, QxSheetType.xlWorksheet);
                flag = true;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "AddWork()", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("新增工作区失败");
            }
            return flag;
        }

        public virtual bool ClearPic()
        {
            int count = this.appCurSheet.Shapes.Count;
            for (int i = this.appCurSheet.Shapes.Count; i < 0; i--)
            {
                this.appCurSheet.Shapes.Item(i).Delete();
            }
            return false;
        }

        private void Close()
        {
            this.appWork.Close(true, this.oMissing, this.oMissing);
            this.appExcel.Quit();
        }

        public virtual bool DeletePicByIndex(int _index)
        {
            if (((Picture) this.appCurSheet.Pictures(_index)) != null)
            {
                ((Picture) this.appCurSheet.Pictures(_index)).Delete();
            }
            return false;
        }

        public virtual bool DelSheet(int _index)
        {
            bool flag = false;
            try
            {
                ((Worksheet) this.appWork.Sheets[_index]).Delete();
                flag = true;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "DelSheet(int _index)", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("删除工作区失败");
            }
            return flag;
        }

        public virtual bool DelSheet(string _name)
        {
            bool flag = false;
            try
            {
                for (int i = 1; i <= this.appSheets.Count; i++)
                {
                    if (((Worksheet) this.appSheets[i]).Name == _name)
                    {
                        ((Worksheet) this.appSheets[i]).Delete();
                        return true;
                    }
                }
                flag = true;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "DelSheet(string _name)", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("删除工作区失败");
            }
            return flag;
        }

        public void Dispose()
        {
            this.ReleaseObj(this.appCurRange);
            this.ReleaseObj(this.appCurSheet);
            this.ReleaseObj(this.appSheets);
            this.ReleaseObj(this.appWork);
            this.ReleaseObj(this.appExcel);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            try
            {
                Process.GetProcessById(this.k).Kill();
            }
            catch (Exception)
            {
            }
        }

        ~QxWriteExcel()
        {
            this.Dispose();
        }

        public virtual void GetSheet(int _index)
        {
            if (this.appSheets == null)
            {
                this.appSheets = this.appWork.Sheets;
            }
            if (_index > this.appSheets.Count)
            {
                throw new ExcelException("超出现有的工作区");
            }
            this.appCurSheet = (Worksheet) this.appSheets[_index];
        }

        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public virtual bool InsertImage(int _rowleft, int _columntop, string _imagepath, RangeStyle _rs)
        {
            return this.InsertImage(_rowleft, _columntop, _rowleft, _columntop, false, _imagepath, _rs);
        }

        public virtual bool InsertImage(int _rowleft, int _columntop, int _rowright, int _columnbottom, bool _ismerge, string _imagepath, RangeStyle _rs)
        {
            bool flag = false;
            try
            {
                this.appCurRange = this.appCurSheet.get_Range(this.appCurSheet.Cells[_rowleft, _columntop], this.appCurSheet.Cells[_rowright, _columnbottom] as Range);
                if (_ismerge)
                {
                    this.appCurRange.Merge(this.oMissing);
                }
                if (_rs != null)
                {
                    _rs.SetStyle(ref this.appCurRange);
                }
                this.appCurRange.Select();
                ((Pictures) this.appCurSheet.Pictures(this.oMissing)).Insert(_imagepath, this.oMissing);
                flag = true;
            }
            catch (Exception exception)
            {
                new QxClassErrLog { ErrClass = base.GetType().ToString(), MethodName = "InsertImage(int _rowleft, int _columntop, int _rowright, int _columnbottom, bool _ismerge, string _imagepath, RangeStyle _rs)", ErrContent = exception.Message }.WriteLog();
                throw new ExcelException("设置单元格的图片失败");
            }
            return flag;
        }

        public virtual bool InsertImage(int _rowleft, int _columntop, string _imagepath, float _left, float _top, float _imageheight, float _imagewidth, RangeStyle _rs)
        {
            return this.InsertImage(_rowleft, _columntop, _rowleft, _columntop, false, _imagepath, _left, _top, _imageheight, _imagewidth, _rs);
        }

        public virtual bool InsertImage(int _rowleft, int _columntop, int _rowright, int _columnbottom, bool _ismerge, string _imagepath, float _left, float _top, float _imageheight, float _imagewidth, RangeStyle _rs)
        {
            bool flag = false;
            try
            {
                this.appCurRange = this.appCurSheet.get_Range(this.appCurSheet.Cells[_rowleft, _columntop], this.appCurSheet.Cells[_rowright, _columnbottom] as Range);
                if (_ismerge)
                {
                    this.appCurRange.Merge(this.oMissing);
                }
                if (_rs != null)
                {
                    _rs.SetStyle(ref this.appCurRange);
                }
                this.appCurRange.Select();
                this.appCurSheet.Shapes.AddPicture(_imagepath, MsoTriState.msoFalse, MsoTriState.msoTrue, _left, _top, _imagewidth, _imageheight);
                flag = true;
            }
            catch (Exception exception)
            {
                throw new ExcelException("设置单元格的图片失败", exception);
            }
            return flag;
        }

        public virtual bool NewOpen()
        {
            this.appWork = this.appExcel.Workbooks.Add(this.oMissing);
            this.appSheets = this.appWork.Sheets;
            return true;
        }

        public virtual bool Open()
        {
            bool flag = false;
            try
            {
                this.appWork = this.appExcel.Workbooks.Open(this._filepath, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing);
                this.appSheets = this.appWork.Sheets;
                this.GetSheet(1);
                flag = true;
            }
            catch (Exception exception)
            {
                throw new ExcelException("Excel文件打开失败", exception);
            }
            return flag;
        }

        public virtual bool Open(string vfilepath)
        {
            this.FilePath = vfilepath;
            return this.Open();
        }

        private void ReleaseObj(object o)
        {
            try
            {
                Marshal.ReleaseComObject(o);
            }
            catch
            {
            }
            finally
            {
                o = null;
            }
        }

        public void RunExcelMacro(string[] macroName, object[] parameters)
        {
            try
            {
                if (macroName == null)
                {
                    throw new Exception("请输入宏的名称");
                }
                for (int i = 0; i < macroName.Length; i++)
                {
                    object[] objArray;
                    if (parameters == null)
                    {
                        objArray = new object[] { macroName[i] };
                    }
                    else
                    {
                        int length = 0;
                        if (parameters[i] != null)
                        {
                            length = ((object[]) parameters[i]).Length;
                        }
                        objArray = new object[length + 1];
                        objArray[0] = macroName[i];
                        for (int j = 0; j < length; j++)
                        {
                            objArray[j + 1] = ((object[]) parameters[i])[j];
                        }
                    }
                    this.RunMacro(this.appExcel, objArray);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void RunExcelMacro(string macroName, object[] parameters, out object rtnValue)
        {
            try
            {
                object[] objArray;
                if (string.IsNullOrEmpty(macroName))
                {
                    throw new Exception("请输入宏的名称");
                }
                if (parameters == null)
                {
                    objArray = new object[] { macroName };
                }
                else
                {
                    int length = parameters.Length;
                    objArray = new object[length + 1];
                    objArray[0] = macroName;
                    for (int i = 0; i < length; i++)
                    {
                        objArray[i + 1] = parameters[i];
                    }
                }
                rtnValue = this.RunMacro(this.appExcel, objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object RunMacro(object oApp, object[] oRunArgs)
        {
            object obj2;
            try
            {
                obj2 = oApp.GetType().InvokeMember("Run", BindingFlags.InvokeMethod, null, oApp, oRunArgs);
            }
            catch (Exception exception)
            {
                if (exception.InnerException.Message.ToString().Length > 0)
                {
                    throw exception.InnerException;
                }
                throw exception;
            }
            return obj2;
        }

        public void Save()
        {
            this.appWork.SaveAs(this.FilePath, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing, XlSaveAsAccessMode.xlNoChange, this.oMissing, this.oMissing, this.oMissing, this.oMissing, this.oMissing);
            this.Close();
        }

        public virtual bool SetCell(int _irow, int _icolumn, object _value, RangeStyle _rs)
        {
            return this.SetCell(_irow, _icolumn, _irow, _icolumn, false, _value, _rs);
        }

        public virtual bool SetCell(int _rowleft, int _columntop, int _rowright, int _columnbottom, bool _ismerge, object _value, RangeStyle _rs)
        {
            bool flag = false;
            try
            {
                this.appCurRange = this.appCurSheet.get_Range(this.appCurSheet.Cells[_rowleft, _columntop], this.appCurSheet.Cells[_rowright, _columnbottom] as Range);
                if (_ismerge)
                {
                    this.appCurRange.Merge(this.oMissing);
                }
                if (_rs != null)
                {
                    _rs.SetStyle(ref this.appCurRange);
                }
                this.appCurRange.Value2 = _value;
                flag = true;
            }
            catch (Exception exception)
            {
                throw new ExcelException("设置单元格内容失败", exception);
            }
            return flag;
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
            set
            {
                this._exsheets = value;
                this.appCurSheet.Name = this._exsheets;
            }
        }
    }
}

