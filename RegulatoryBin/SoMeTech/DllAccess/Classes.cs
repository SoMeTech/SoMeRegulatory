namespace SoMeTech.DllAccess
{
    using System;
    using System.Reflection;

    public sealed class Classes
    {
        public static object InvokeClassMethod(object classObject, string methodName, bool methodIsAlone, Type[] methodParamsType, object[] methodParams)
        {
            Type type = classObject.GetType();
            MethodInfo method = type.GetMethod(methodName);
            if (methodIsAlone)
            {
                method = type.GetMethod(methodName);
            }
            else if (methodParamsType == null)
            {
                method = type.GetMethod(methodName, Type.EmptyTypes);
            }
            else
            {
                method = type.GetMethod(methodName, methodParamsType);
            }
            return method.Invoke(classObject, methodParams);
        }
    }
}

