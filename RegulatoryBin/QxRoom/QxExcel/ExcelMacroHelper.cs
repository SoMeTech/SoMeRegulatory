namespace QxRoom.QxExcel
{
    using excel;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public sealed class ExcelMacroHelper
    {
        public void RunExcelMacro(string excelFilePath, string[] macroName, object[] parameters, bool isShowExcel, bool isSave, bool isClose)
        {
            try
            {
                if (macroName == null)
                {
                    throw new Exception("请输入宏的名称");
                }
                object updateLinks = Missing.Value;
                ApplicationClass oApp = new ApplicationClass();
                if (isShowExcel)
                {
                    oApp.Visible = true;
                }
                Workbooks o = oApp.Workbooks;
                _Workbook workbook = null;
                workbook = o.Open(excelFilePath, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
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
                    this.RunMacro(oApp, objArray);
                }
                if (isSave)
                {
                    workbook.Save();
                }
                if (isClose)
                {
                    workbook.Close(false, updateLinks, updateLinks);
                }
                Marshal.ReleaseComObject(workbook);
                workbook = null;
                Marshal.ReleaseComObject(o);
                o = null;
                if (isClose)
                {
                    oApp.Quit();
                }
                Marshal.ReleaseComObject(oApp);
                oApp = null;
                GC.Collect();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void RunExcelMacro(string excelFilePath, string macroName, object[] parameters, out object rtnValue, bool isShowExcel, bool isSave, bool isClose)
        {
            try
            {
                object[] objArray;
                if (string.IsNullOrEmpty(macroName))
                {
                    throw new Exception("请输入宏的名称");
                }
                object updateLinks = Missing.Value;
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
                ApplicationClass oApp = new ApplicationClass();
                if (isShowExcel)
                {
                    oApp.Visible = true;
                }
                Workbooks o = oApp.Workbooks;
                _Workbook workbook = null;
                workbook = o.Open(excelFilePath, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                rtnValue = this.RunMacro(oApp, objArray);
                if (isSave)
                {
                    workbook.Save();
                }
                if (isClose)
                {
                    workbook.Close(false, updateLinks, updateLinks);
                }
                Marshal.ReleaseComObject(workbook);
                workbook = null;
                Marshal.ReleaseComObject(o);
                o = null;
                if (isClose)
                {
                    oApp.Quit();
                }
                Marshal.ReleaseComObject(oApp);
                oApp = null;
                GC.Collect();
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
    }
}

