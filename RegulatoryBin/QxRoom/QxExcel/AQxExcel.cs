namespace QxRoom.QxExcel
{
    using System;

    public abstract class AQxExcel
    {
        protected AQxExcel()
        {
        }

        public abstract bool DelExcel();
        public abstract bool OpenExcel();
        public abstract void SaveExcel();

        public abstract string FilePath { get; set; }
    }
}

