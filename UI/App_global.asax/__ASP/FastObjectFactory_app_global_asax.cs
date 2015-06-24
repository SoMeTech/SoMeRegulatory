namespace __ASP
{
    using ASP;
    using System;

    internal class FastObjectFactory_app_global_asax
    {
        private FastObjectFactory_app_global_asax()
        {
        }

        private static object Create_ASP_global_asax()
        {
            return new global_asax();
        }
    }
}
