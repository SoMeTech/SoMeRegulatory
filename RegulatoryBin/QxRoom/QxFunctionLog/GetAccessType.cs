namespace QxRoom.QxFunctionLog
{
    using System;

    public class GetAccessType
    {
        public static AccessType accesstype;
        public static string DataBaseName = "";
        public static string LogPath = "";

        public AccessType accessType
        {
            get
            {
                return accesstype;
            }
            set
            {
                accesstype = value;
            }
        }
    }
}

