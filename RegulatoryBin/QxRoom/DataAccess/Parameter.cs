namespace QxRoom.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.OracleClient;
    using System.Data.SqlClient;

    [Serializable]
    public sealed class Parameter : MarshalByRefObject, IDbDataParameter, IDataParameter, ICloneable
    {
        private MyDataType m_dbType;
        private ParameterDirection m_direction;
        private bool m_forceSize;
        private bool m_isNullable;
        private string m_name;
        private int m_offset;
        private byte m_precision;
        private IDbDataParameter m_realParameter;
        private byte m_scale;
        private int m_size;
        private string m_sourceColumn;
        private bool m_suppress;
        private object m_value;
        private DataRowVersion m_version;

        public Parameter()
        {
            this.m_value = null;
            this.m_direction = ParameterDirection.Input;
            this.m_size = -1;
            this.m_version = DataRowVersion.Current;
            this.m_forceSize = false;
            this.m_offset = 0;
            this.m_suppress = false;
        }

        public Parameter(string parameterName, MyDataType dbType)
        {
            this.m_name = parameterName;
            this.m_dbType = dbType;
        }

        public Parameter(string parameterName, object Value)
        {
            this.m_name = parameterName;
            this.m_value = Value;
        }

        public Parameter(string parameterName, MyDataType dbType, int size)
        {
            this.m_name = parameterName;
            this.m_dbType = dbType;
            this.m_size = size;
        }

        public Parameter(string parameterName, object Value, MyDataType dbType, ParameterDirection paramDirection)
        {
            this.m_name = parameterName;
            this.m_dbType = dbType;
            this.m_value = Value;
            this.m_direction = paramDirection;
        }

        public Parameter(string parameterName, object Value, MyDataType dbType, ParameterDirection paramDirection, int size)
        {
            this.m_name = parameterName;
            this.m_dbType = dbType;
            this.m_value = Value;
            this.m_direction = paramDirection;
            this.m_size = size;
        }

        public Parameter(string parameterName, MyDataType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object Value)
        {
            this.m_name = parameterName;
            this.m_dbType = dbType;
            this.m_size = size;
            this.m_direction = direction;
            this.m_isNullable = isNullable;
            this.m_precision = precision;
            this.m_scale = scale;
            this.m_sourceColumn = sourceColumn;
            this.m_version = sourceVersion;
            this.m_value = Value;
        }

        public object Clone()
        {
            Parameter parameter = new Parameter();
            parameter.SetProperties(this.m_name, this.m_sourceColumn, this.m_version, this.m_precision, this.m_scale, this.m_size, this.m_forceSize, this.m_offset, this.m_direction, this.m_value, this.m_dbType, this.m_suppress);
            return parameter;
        }

        internal void InitRealParameter(DataBaseType databaseType)
        {
            if (object.Equals(this.m_realParameter, null))
            {
                switch (databaseType)
                {
                    case DataBaseType.SqlServer:
                        this.m_realParameter = new SqlParameter("@" + this.ParameterName, (SqlDbType) DBType.GetMyDataType(this.DbType));
                        this.m_realParameter.Direction = this.Direction;
                        this.m_realParameter.Precision = this.Precision;
                        this.m_realParameter.Scale = this.Scale;
                        this.m_realParameter.SourceColumn = this.SourceColumn;
                        this.m_realParameter.Value = this.Value;
                        return;

                    case DataBaseType.Oracle:
                        this.m_realParameter = new OracleParameter(":" + this.ParameterName, (OracleType) DBType.GetMyDataType(this.DbType));
                        this.m_realParameter.Direction = this.Direction;
                        this.m_realParameter.Precision = this.Precision;
                        this.m_realParameter.Scale = this.Scale;
                        this.m_realParameter.SourceColumn = this.SourceColumn;
                        this.m_realParameter.Value = this.Value;
                        return;

                    case DataBaseType.OleDB:
                        this.m_realParameter = new OleDbParameter("@" + this.ParameterName, (OleDbType) DBType.GetMyDataType(this.DbType));
                        this.m_realParameter.Direction = this.Direction;
                        this.m_realParameter.Precision = this.Precision;
                        this.m_realParameter.Scale = this.Scale;
                        this.m_realParameter.SourceColumn = this.SourceColumn;
                        this.m_realParameter.Value = this.Value;
                        return;
                }
                this.m_realParameter = new SqlParameter("@" + this.ParameterName, (SqlDbType) DBType.GetMyDataType(this.DbType));
                this.m_realParameter.Direction = this.Direction;
                this.m_realParameter.Precision = this.Precision;
                this.m_realParameter.Scale = this.Scale;
                this.m_realParameter.SourceColumn = this.SourceColumn;
                this.m_realParameter.Value = this.Value;
            }
        }

        internal void SetProperties(string name, string column, DataRowVersion version, byte precision, byte scale, int size, bool forceSize, int offset, ParameterDirection direction, object Value, MyDataType type, bool suppress)
        {
            this.ParameterName = name;
            this.m_sourceColumn = column;
            this.SourceVersion = version;
            this.Precision = precision;
            this.m_scale = scale;
            this.m_size = size;
            this.m_forceSize = forceSize;
            this.m_offset = offset;
            this.Direction = direction;
            if (Value is ICloneable)
            {
                Value = ((ICloneable) Value).Clone();
            }
            this.m_value = Value;
            this.Suppress = suppress;
        }

        public override string ToString()
        {
            return this.ParameterName;
        }

        public MyDataType DbType
        {
            get
            {
                return this.m_dbType;
            }
            set
            {
                this.m_dbType = value;
            }
        }

        public ParameterDirection Direction
        {
            get
            {
                return this.m_direction;
            }
            set
            {
                this.m_direction = value;
            }
        }

        public bool IsNullable
        {
            get
            {
                return this.m_isNullable;
            }
            set
            {
                this.m_isNullable = value;
            }
        }

        public int Offset
        {
            get
            {
                return this.m_offset;
            }
            set
            {
                this.m_offset = value;
            }
        }

        public string ParameterName
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        public byte Precision
        {
            get
            {
                return this.m_precision;
            }
            set
            {
                this.m_precision = value;
            }
        }

        internal IDbDataParameter RealParameter
        {
            get
            {
                return this.m_realParameter;
            }
            set
            {
                this.m_realParameter = value;
            }
        }

        public byte Scale
        {
            get
            {
                return this.m_scale;
            }
            set
            {
                this.m_scale = value;
            }
        }

        public int Size
        {
            get
            {
                if (this.m_forceSize)
                {
                    return this.m_size;
                }
                return 0;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception(value.ToString());
                }
                if (value != 0)
                {
                    this.m_forceSize = true;
                    this.m_size = value;
                }
                else
                {
                    this.m_forceSize = false;
                    this.m_size = -1;
                }
            }
        }

        public string SourceColumn
        {
            get
            {
                if (this.m_sourceColumn == null)
                {
                    return string.Empty;
                }
                return this.m_sourceColumn;
            }
            set
            {
                this.m_sourceColumn = value;
            }
        }

        public DataRowVersion SourceVersion
        {
            get
            {
                return this.m_version;
            }
            set
            {
                this.m_version = value;
            }
        }

        internal bool Suppress
        {
            get
            {
                return this.m_suppress;
            }
            set
            {
                this.m_suppress = value;
            }
        }

        System.Data.DbType IDataParameter.DbType
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        ParameterDirection IDataParameter.Direction
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IDataParameter.IsNullable
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IDataParameter.ParameterName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IDataParameter.SourceColumn
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DataRowVersion IDataParameter.SourceVersion
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        object IDataParameter.Value
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        byte IDbDataParameter.Precision
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        byte IDbDataParameter.Scale
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IDbDataParameter.Size
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object Value
        {
            get
            {
                if (object.Equals(this.m_value, null))
                {
                    return DBNull.Value;
                }
                return this.m_value;
            }
            set
            {
                this.m_value = value;
            }
        }
    }
}

