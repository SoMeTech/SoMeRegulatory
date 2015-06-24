using System;
using System.Management;

public class GetServerInfo
{
    public static string GetCpuIndex()
    {
        string str = "";
        ManagementClass class2 = new ManagementClass("Win32_Processor");
        foreach (ManagementObject obj2 in class2.GetInstances())
        {
            str = obj2.Properties["ProcessorId"].Value.ToString();
        }
        return str;
    }

    public static string GetHDIndex()
    {
        string str = "";
        ManagementClass class2 = new ManagementClass("Win32_DiskDrive");
        foreach (ManagementObject obj2 in class2.GetInstances())
        {
            str = (string) obj2.Properties["Model"].Value;
        }
        return str;
    }

    public string GetInfo()
    {
        SymmetricMethod method = new SymmetricMethod();
        string cpuIndex = GetCpuIndex();
        cpuIndex = method.Encrypto(cpuIndex);
        string hDIndex = GetHDIndex();
        hDIndex = method.Encrypto(hDIndex);
        string macAddress = GetMacAddress();
        macAddress = method.Encrypto(macAddress);
        return (cpuIndex + "&" + hDIndex + "&" + macAddress);
    }

    public static string GetMacAddress()
    {
        string str = "";
        ManagementClass class2 = new ManagementClass("Win32_NetworkAdapterConfiguration");
        foreach (ManagementObject obj2 in class2.GetInstances())
        {
            if ((bool) obj2["IPEnabled"])
            {
                str = obj2["MacAddress"].ToString();
            }
            obj2.Dispose();
        }
        return str;
    }
}

