namespace SoMeTech.UsualBookTable
{
    using System;

    [Serializable]
    public sealed class MenuType : QxDictionary
    {
        public MenuType()
        {
            base.Mss = new MenuType[] { new MenuType(2, "前台菜单"), new MenuType(1, "后台菜单") };
        }

        public MenuType(int id, string name) : base(id, name)
        {
        }
    }
}

