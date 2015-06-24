namespace QxRoom.DataAccess
{
    using System;

    public sealed class GetDataBaseType
    {
        private static DataBase database = null;
        private static object obj = new object();

        private GetDataBaseType()
        {
        }

        public static DataBase GetDataBase()
        {
            switch (DataConfig.nDatabaseType)
            {
                case DataBaseType.SqlServer:
                    database = new SqlServerDataBase();
                    break;

                case DataBaseType.Oracle:
                    database = new OracleDataBase();
                    break;

                case DataBaseType.OleDB:
                    database = new OleDbDataBase();
                    break;

                default:
                    database = new SqlServerDataBase();
                    break;
            }
            return database;
        }

        public static DataBase GetDataBase(DataConfig _config)
        {
            switch (_config.DatabaseType)
            {
                case DataBaseType.SqlServer:
                    database = new SqlServerDataBase();
                    break;

                case DataBaseType.Oracle:
                    database = new OracleDataBase();
                    break;

                case DataBaseType.OleDB:
                    database = new OleDbDataBase();
                    break;

                default:
                    database = new SqlServerDataBase();
                    break;
            }
            return database;
        }

        public static DataBase GetSingleDataBase()
        {
            if (database == null)
            {
                lock (obj)
                {
                    if (database == null)
                    {
                        switch (DataConfig.nDatabaseType)
                        {
                            case DataBaseType.SqlServer:
                                database = new SqlServerDataBase();
                                goto Label_006B;

                            case DataBaseType.Oracle:
                                database = new OracleDataBase();
                                goto Label_006B;

                            case DataBaseType.OleDB:
                                database = new OleDbDataBase();
                                goto Label_006B;
                        }
                        database = new SqlServerDataBase();
                    }
                }
            }
        Label_006B:
            return database;
        }

        public static DataBase GetSingleDataBase(DataConfig _config)
        {
            if (database == null)
            {
                lock (obj)
                {
                    if (database == null)
                    {
                        switch (_config.DatabaseType)
                        {
                            case DataBaseType.SqlServer:
                                database = new SqlServerDataBase();
                                goto Label_006C;

                            case DataBaseType.Oracle:
                                database = new OracleDataBase();
                                goto Label_006C;

                            case DataBaseType.OleDB:
                                database = new OleDbDataBase();
                                goto Label_006C;
                        }
                        database = new SqlServerDataBase();
                    }
                }
            }
        Label_006C:
            return database;
        }
    }
}

