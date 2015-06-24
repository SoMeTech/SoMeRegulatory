namespace SoMeTech.DllAccess
{
    using System;

    public sealed class Property
    {
        public static string GetClassProperty(object classObject, string propertyName)
        {
            return classObject.GetType().GetProperty(propertyName).GetValue(classObject, null).ToString();
        }

        public static void SetClassProperty(object classObject, string propertyName, object setValue)
        {
            classObject.GetType().GetProperty(propertyName).SetValue(classObject, setValue, null);
        }
    }
}

