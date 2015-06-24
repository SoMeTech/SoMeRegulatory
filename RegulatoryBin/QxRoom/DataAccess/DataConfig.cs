namespace QxRoom.DataAccess
{
    using System;

    public sealed class DataConfig
    {
        private DataBaseType databasetype;
        public static DataBaseType nDatabaseType;
        public static string nDataConString = "";
        private string str_con;

        public DataBaseType DatabaseType
        {
            get
            {
                return this.databasetype;
            }
            set
            {
                this.databasetype = value;
            }
        }

        public string DataCon
        {
            get
            {
                return this.str_con;
            }
            set
            {
                this.str_con = value;
            }
        }
    }
}

