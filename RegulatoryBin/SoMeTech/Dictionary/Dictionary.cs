namespace SoMeTech.Dictionary
{
    using System;

    [Serializable]
    public class Dictionary
    {
        private int _id;
        private string _name;
        protected SoMeTech.Dictionary.Dictionary[] Mss;

        public Dictionary()
        {
            this.Mss = new SoMeTech.Dictionary.Dictionary[] { new SoMeTech.Dictionary.Dictionary(-1, "") };
        }

        public Dictionary(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public virtual SoMeTech.Dictionary.Dictionary[] GetAll()
        {
            return this.Mss;
        }

        public virtual SoMeTech.Dictionary.Dictionary Select(int id)
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

        public virtual SoMeTech.Dictionary.Dictionary Select(string name)
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

