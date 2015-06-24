namespace SoMeTech.Data
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Runtime.CompilerServices;

    public class CommandInfo
    {
        public string CommandText;
        public SoMeTech.Data.EffentNextType EffentNextType;
        public object OriginalData;
        public DbParameter[] Parameters;
        public object ShareObject;

        private event EventHandler _solicitationEvent;


        public CommandInfo()
        {
        }

        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }

        public CommandInfo(string sqlText, SqlParameter[] para, SoMeTech.Data.EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }

        public void OnSolicitationEvent()
        {
            if (this._solicitationEvent != null)
            {
                this._solicitationEvent(this, new EventArgs());
            }
        }
    }
}

