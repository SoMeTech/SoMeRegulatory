namespace BHSoft.BHWeb.Common.Data
{
    using System;
    using System.Collections;
    using System.Data;

    public class DBTableData
    {
        private ArrayList keys = new ArrayList();
        private ArrayList types = new ArrayList();
        private ArrayList values = new ArrayList();

        public void Add(string argKey, object argValue)
        {
            this.Add(argKey, argValue, DbType.Object);
        }

        public void Add(string argKey, object argValue, DbType argType)
        {
            this.keys.Add(argKey);
            this.values.Add(argValue);
            this.types.Add(argType);
        }

        public string GetKeys(int i)
        {
            return (string) this.keys[i];
        }

        public DbType GetTypes(int i)
        {
            return (DbType) this.types[i];
        }

        public DbType GetTypes(string key)
        {
            int num = -1;
            for (int i = 0; i < this.keys.Count; i++)
            {
                if (key.Equals(this.keys[i]))
                {
                    num = i;
                }
            }
            if (num < 0)
            {
                return DbType.Object;
            }
            return (DbType) this.types[num];
        }

        public object GetValues(int i)
        {
            return this.values[i];
        }

        public object GetValues(string key)
        {
            int num = -1;
            for (int i = 0; i < this.keys.Count; i++)
            {
                if (key.Equals(this.keys[i]))
                {
                    num = i;
                }
            }
            if (num < 0)
            {
                return null;
            }
            return this.values[num];
        }

        public int Count
        {
            get
            {
                return this.keys.Count;
            }
        }
    }
}

