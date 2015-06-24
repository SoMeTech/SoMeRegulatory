namespace QxRoom.Common
{
    using IWshRuntimeLibrary;
    using System;
    using System.Reflection;

    public class Shortcut : IDisposable
    {
        private string description;
        private string icolocation;
        private WshShell shell = new WshShellClass();
        private string targetpath;
        private WindowStyle windowstyle;
        private string workingDirectory;

        public bool Create()
        {
            IWshShortcut shortcut = (IWshShortcut) this.shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Allen’s Application.lnk");
            shortcut.TargetPath = Assembly.GetExecutingAssembly().Location;
            shortcut.WorkingDirectory = Environment.CurrentDirectory;
            shortcut.WindowStyle = 1;
            shortcut.Description = "Launch Allen’s Application";
            shortcut.IconLocation = Environment.SystemDirectory + @"\shell32.dll, 165";
            shortcut.Save();
            return true;
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string IcoLocation
        {
            get
            {
                return this.icolocation;
            }
            set
            {
                this.icolocation = value;
            }
        }

        public WindowStyle Style
        {
            get
            {
                return this.windowstyle;
            }
            set
            {
                this.windowstyle = value;
            }
        }

        public string TargetPath
        {
            get
            {
                return this.targetpath;
            }
            set
            {
                this.targetpath = value;
            }
        }

        public string WorkingDirectory
        {
            get
            {
                return this.workingDirectory;
            }
            set
            {
                this.workingDirectory = value;
            }
        }
    }
}

