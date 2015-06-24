namespace SoMeTech.UsualBookTable
{
    using System;

    [Serializable]
    public sealed class MenuPopedom : QxDictionary
    {
        public MenuPopedom()
        {
            base.Mss = new MenuPopedom[] { new MenuPopedom(0, "无需验证"), new MenuPopedom(1, "需要验证") };
        }

        public MenuPopedom(int id, string name) : base(id, name)
        {
        }
    }
}

