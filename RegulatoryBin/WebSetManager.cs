using Synv.Common;
using System;

public class WebSetManager
{
    private static object lockHelper = new object();

    public WebSetInfo LoadConfig(string configFilePath)
    {
        return (WebSetInfo) SerializationHelper.Load(typeof(WebSetInfo), configFilePath);
    }

    public WebSetInfo SaveConfig(WebSetInfo wsi, string configFilePath)
    {
        lock (lockHelper)
        {
            SerializationHelper.Save(wsi, configFilePath);
        }
        return wsi;
    }
}

