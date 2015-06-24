namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.OracleClient;

    public sealed class DBType
    {
        public static object GetMyDataType(MyDataType mdt)
        {
            new object();
            switch (mdt)
            {
                case MyDataType.Int:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (DataConfig.nDatabaseType == DataBaseType.SqlServer)
                    {
                        return SqlDbType.Int;
                    }
                    return OleDbType.Integer;

                case MyDataType.Int16:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Int16;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Single;
                    }
                    return SqlDbType.SmallInt;

                case MyDataType.Int32:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Int32;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.BigInt;
                    }
                    return SqlDbType.BigInt;

                case MyDataType.Double:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Double;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Double;
                    }
                    return SqlDbType.Real;

                case MyDataType.Float:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Float;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Currency;
                    }
                    return SqlDbType.Float;

                case MyDataType.Number:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Number;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Numeric;
                    }
                    return SqlDbType.Decimal;

                case MyDataType.Money:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        throw new Exception("OleDb中无此参数类型");
                    }
                    return SqlDbType.Float;

                case MyDataType.SmallMoney:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        throw new Exception("OleDb中无此参数类型");
                    }
                    return SqlDbType.SmallMoney;

                case MyDataType.Char:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Char;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Char;
                    }
                    return SqlDbType.Char;

                case MyDataType.VarChar:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.VarChar;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.VarChar;
                    }
                    return SqlDbType.VarChar;

                case MyDataType.NVarChar:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.NVarChar;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.VarChar;
                    }
                    return SqlDbType.NVarChar;

                case MyDataType.Clob:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Clob;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.LongVarChar;
                    }
                    return SqlDbType.Text;

                case MyDataType.NChar:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.NChar;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.BSTR;
                    }
                    return SqlDbType.NChar;

                case MyDataType.NClob:
                    if (DataConfig.nDatabaseType != DataBaseType.Oracle)
                    {
                        if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                        {
                            throw new Exception("OleDb中无此参数类型");
                        }
                        return SqlDbType.NText;
                    }
                    return OracleType.NClob;

                case MyDataType.DateTime:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.DateTime;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Date;
                    }
                    return SqlDbType.DateTime;

                case MyDataType.Timestamp:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Timestamp;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.DBTimeStamp;
                    }
                    return SqlDbType.Timestamp;

                case MyDataType.Boolean:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (DataConfig.nDatabaseType == DataBaseType.SqlServer)
                    {
                        return SqlDbType.Bit;
                    }
                    return OleDbType.Boolean;

                case MyDataType.Blob:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Blob;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.LongVarBinary;
                    }
                    return SqlDbType.Image;

                case MyDataType.Byte:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Byte;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Binary;
                    }
                    return SqlDbType.TinyInt;

                case MyDataType.Raw:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Raw;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Binary;
                    }
                    return SqlDbType.Binary;

                case MyDataType.RowId:
                    if (DataConfig.nDatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.RowId;
                    }
                    if (DataConfig.nDatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Guid;
                    }
                    return SqlDbType.UniqueIdentifier;

                case MyDataType.Cursor:
                    if (DataConfig.nDatabaseType != DataBaseType.Oracle)
                    {
                        if (DataConfig.nDatabaseType == DataBaseType.SqlServer)
                        {
                            throw new Exception("SqlServer无此参数类型");
                        }
                        throw new Exception("OleDb无此参数类型");
                    }
                    return OracleType.Cursor;
            }
            throw new Exception("QxRoom类库未知的参数类型");
        }

        public static object GetMyDataType(MyDataType mdt, DataConfig _config)
        {
            new object();
            switch (mdt)
            {
                case MyDataType.Int:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Number;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Integer;
                    }
                    return SqlDbType.Int;

                case MyDataType.Int16:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Int16;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Single;
                    }
                    return SqlDbType.SmallInt;

                case MyDataType.Int32:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Int32;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.BigInt;
                    }
                    return SqlDbType.BigInt;

                case MyDataType.Double:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Double;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Double;
                    }
                    return SqlDbType.Real;

                case MyDataType.Float:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Float;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Currency;
                    }
                    return SqlDbType.Float;

                case MyDataType.Number:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Number;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Numeric;
                    }
                    return SqlDbType.Decimal;

                case MyDataType.Money:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        throw new Exception("OleDb中无此参数类型");
                    }
                    return SqlDbType.Float;

                case MyDataType.SmallMoney:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        throw new Exception("OleDb中无此参数类型");
                    }
                    return SqlDbType.SmallMoney;

                case MyDataType.Char:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Char;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Char;
                    }
                    return SqlDbType.Char;

                case MyDataType.VarChar:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.VarChar;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.VarChar;
                    }
                    return SqlDbType.VarChar;

                case MyDataType.NVarChar:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.NVarChar;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.VarChar;
                    }
                    return SqlDbType.NVarChar;

                case MyDataType.Clob:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Clob;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.LongVarChar;
                    }
                    return SqlDbType.Text;

                case MyDataType.NChar:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.NChar;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.BSTR;
                    }
                    return SqlDbType.NChar;

                case MyDataType.NClob:
                    if (_config.DatabaseType != DataBaseType.Oracle)
                    {
                        if (_config.DatabaseType != DataBaseType.SqlServer)
                        {
                            throw new Exception("OleDb中无此参数类型");
                        }
                        return SqlDbType.NText;
                    }
                    return OracleType.NClob;

                case MyDataType.DateTime:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.DateTime;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Date;
                    }
                    return SqlDbType.DateTime;

                case MyDataType.Timestamp:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Timestamp;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.DBTimeStamp;
                    }
                    return SqlDbType.Timestamp;

                case MyDataType.Boolean:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        throw new Exception("Oracle中无此参数类型");
                    }
                    if (_config.DatabaseType == DataBaseType.SqlServer)
                    {
                        return SqlDbType.Bit;
                    }
                    return OleDbType.Boolean;

                case MyDataType.Blob:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Blob;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.LongVarBinary;
                    }
                    return SqlDbType.Image;

                case MyDataType.Byte:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Byte;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Binary;
                    }
                    return SqlDbType.TinyInt;

                case MyDataType.Raw:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.Raw;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Binary;
                    }
                    return SqlDbType.Binary;

                case MyDataType.RowId:
                    if (_config.DatabaseType == DataBaseType.Oracle)
                    {
                        return OracleType.RowId;
                    }
                    if (_config.DatabaseType != DataBaseType.SqlServer)
                    {
                        return OleDbType.Guid;
                    }
                    return SqlDbType.UniqueIdentifier;

                case MyDataType.Cursor:
                    if (_config.DatabaseType != DataBaseType.Oracle)
                    {
                        if (_config.DatabaseType == DataBaseType.SqlServer)
                        {
                            throw new Exception("SqlServer无此参数类型");
                        }
                        throw new Exception("OleDb无此参数类型");
                    }
                    return OracleType.Cursor;
            }
            throw new Exception("QxRoom类库未知的参数类型");
        }
    }
}

