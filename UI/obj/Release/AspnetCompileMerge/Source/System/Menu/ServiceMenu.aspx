<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="ServiceMenu.aspx.cs" stylesheettheme="Default" inherits="SystemSetup_menu_ServiceMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1"
                            Height="244px" ImageSet="Arrows" ShowLines="True" Width="100%">
                            <ParentNodeStyle Font-Bold="False" ImageUrl="~/images/open2.gif" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                ImageUrl="~/images/open2.gif" VerticalPadding="0px" />
                            <RootNodeStyle ImageUrl="~/images/tree_root.gif" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                ImageUrl="~/images/file.gif" NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" SiteMapProvider="XmlSiteMapProvider" />

    </div>
    </form>
</body>
</html>
