namespace SoMeTech.UsualBookTable
{
    using System;

    [Serializable]
    public class QxDictionary
    {
        private int _id;
        private string _name;
        protected QxDictionary[] Mss;

        public QxDictionary()
        {
            this.Mss = new QxDictionary[] { new QxDictionary(-1, "") };
        }

        public QxDictionary(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public virtual QxDictionary[] GetAll()
        {
            return this.Mss;
        }

        public virtual QxDictionary Select(int id)
        {
            for (int i = 0; i < this.Mss.Length; i++)
            {
                if (this.Mss[i].Id == id)
                {
                    return this.Mss[i];
                }
            }
            return null;
        }

        public virtual QxDictionary Select(string name)
        {
            for (int i = 0; i < this.Mss.Length; i++)
            {
                if (this.Mss[i].Name == name)
                {
                    return this.Mss[i];
                }
            }
            return null;
        }

        public override string ToString()
        {
            return this._name;
        }

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                value = this._id;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                value = this._name;
            }
        }
    }
}

