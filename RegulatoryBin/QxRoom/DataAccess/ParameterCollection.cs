namespace QxRoom.DataAccess
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Reflection;

    [Serializable]
    public sealed class ParameterCollection : MarshalByRefObject
    {
        private int _intitialCapacity;
        private System.Collections.ArrayList _items;

        public ParameterCollection()
        {
            this._intitialCapacity = 10;
        }

        public ParameterCollection(int _initCapacity)
        {
            this._intitialCapacity = 10;
            this._intitialCapacity = _initCapacity;
        }

        public Parameter Add(Parameter param)
        {
            this.ArrayList().Add(param);
            return param;
        }

        public Parameter Add(string ParameterName, object Value)
        {
            return this.Add(new Parameter(ParameterName, Value));
        }

        public Parameter Add(string ParameterName, object Value, MyDataType dbType, ParameterDirection paramDirection)
        {
            return this.Add(new Parameter(ParameterName, Value, dbType, paramDirection));
        }

        public Parameter Add(string ParameterName, object Value, MyDataType dbType, ParameterDirection paramDirection, int size)
        {
            return this.Add(new Parameter(ParameterName, Value, dbType, paramDirection, size));
        }

        private System.Collections.ArrayList ArrayList()
        {
            if (this._items == null)
            {
                this._items = new System.Collections.ArrayList(this._intitialCapacity);
            }
            return this._items;
        }

        public void Clear()
        {
            this.ArrayList().Clear();
        }

        public int IndexOf(string ParameterName)
        {
            if (this._items != null)
            {
                for (int i = 0; i < this._items.Count; i++)
                {
                    if (((Parameter) this._items[i]).ParameterName.Equals(ParameterName))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void RangeCheck(int index)
        {
            if ((index < 0) || (this.Count <= index))
            {
                throw new IndexOutOfRangeException("索引 " + index.ToString() + " 超出范围！");
            }
        }

        private int RangeCheck(string ParameterName)
        {
            int index = this.IndexOf(ParameterName);
            if (index < 0)
            {
                throw new IndexOutOfRangeException("参数名 " + ParameterName + " 不存在！");
            }
            return index;
        }

        private void Replace(int index, Parameter newValue)
        {
            this.Validate(index, newValue);
            this._items[index] = newValue;
        }

        private void Validate(int index, Parameter Value)
        {
        }

        private void ValidateType(object Value)
        {
        }

        public int Count
        {
            get
            {
                if (this._items == null)
                {
                    return 0;
                }
                return this._items.Count;
            }
        }

        public Parameter this[string ParameterName]
        {
            get
            {
                int num = this.RangeCheck(ParameterName);
                return (Parameter) this._items[num];
            }
            set
            {
                int index = this.RangeCheck(ParameterName);
                this.Replace(index, value);
            }
        }

        public Parameter this[int index]
        {
            get
            {
                this.RangeCheck(index);
                return (Parameter) this._items[index];
            }
            set
            {
                this.RangeCheck(index);
                this.Replace(index, value);
            }
        }
    }
}

