namespace SoMeTech.UsualBookTable
{
    using System;

    [Serializable]
    public sealed class MenuNode : QxDictionary
    {
        public MenuNode()
        {
            base.Mss = new MenuNode[] { new MenuNode(0, "节点"), new MenuNode(1, "子项") };
        }

        public MenuNode(int id, string name) : base(id, name)
        {
        }
    }
}

