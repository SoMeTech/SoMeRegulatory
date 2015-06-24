namespace QxRoom.DataAccess
{
    using System;

    public class DbFunction
    {
        public static string GetLongDateTimeString(DateTime _datetime, DataConfig _config)
        {
            switch (_config.DatabaseType)
            {
                case DataBaseType.SqlServer:
                    return ("'" + _datetime.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                case DataBaseType.Oracle:
                    return ("to_date('" + _datetime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')");

                case DataBaseType.OleDB:
                    return ("#" + _datetime.ToString("yyyy-MM-dd HH:mm:ss") + "#");
            }
            return "";
        }

        public static string GetShortDateTimeString(DateTime _datetime, DataConfig _config)
        {
            switch (_config.DatabaseType)
            {
                case DataBaseType.SqlServer:
                    return ("'" + _datetime.ToString("yyyy-MM-dd") + "'");

                case DataBaseType.Oracle:
                    return ("to_date('" + _datetime.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')");

                case DataBaseType.OleDB:
                    return ("#" + _datetime.ToString("yyyy-MM-dd") + "#");
            }
            return "";
        }
    }
}

