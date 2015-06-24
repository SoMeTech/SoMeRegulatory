using System;
using System.Web.UI;

public class MainPageClass : Page
{
    public virtual string SayHello()
    {
        return "这是页面基类返回的欢迎信息！";
    }
}

