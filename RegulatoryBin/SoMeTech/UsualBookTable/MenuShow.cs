namespace SoMeTech.UsualBookTable
{
    using System;

    [Serializable]
    public sealed class MenuShow : QxDictionary
    {
        public MenuShow()
        {
            base.Mss = new MenuShow[] { new MenuShow(0, "不显示"), new MenuShow(1, "显示") };
        }

        public MenuShow(int id, string name) : base(id, name)
        {
        }
    }
}

