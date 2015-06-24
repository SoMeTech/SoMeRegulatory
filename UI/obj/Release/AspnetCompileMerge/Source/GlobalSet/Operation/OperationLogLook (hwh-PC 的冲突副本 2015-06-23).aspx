<%@ page title="" language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="OperationLogLook.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="GlobalSet_Operation_OperationLogLook" %><%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitUpdate.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt="" width="355" height="127" style="margin-right:8px;" align="absmiddle"/>
                Loading.....
        </div>
    </div>
    <div id="loading-mask"></div>
    <%} %>
    <script src="../../PublicMode/jss/Check.js" type="text/javascript" ></script>
    <script type="text/javascript">
        //菜单收缩
        function menuCollapse(w) {
            setWidth(w);
        }

        //菜单打开
        function menuExpand(w) {
            setWidth(w);
        }

        function setWidth(w) {
            //alert(w);
        }
    </script>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr style="height:15px;">
                    <td></td>
                </tr>
                <tr height="30px">
                    <td align="right">
                        操作用户
                    </td>
                    <td>
                        <asp:TextBox ID="txtuser" runat="server" Width="200px" style="border-color: #000080; border-style: none none groove none; border-width: 1px; "></asp:TextBox>
                    </td>
                    <td align="right">
                        操作性质
                    </td>
                    <td>
                        <asp:TextBox ID="txttype" runat="server" Width="200px" style="border-color: #000080; border-style: none none groove none; border-width: 1px; "></asp:TextBox>
                    </td>
                </tr>
                <tr height="30px">
                    <td align="right">
                        操作业务
                    </td>
                    <td>
                        <asp:TextBox ID="txtyw" runat="server" Width="200px" style="border-color: #000080; border-style: none none groove none; border-width: 1px; "></asp:TextBox>
                    </td>
                    <td align="right">
                        操作时间
                    </td>
                    <td>
                        <asp:TextBox ID="txttime" runat="server" Width="200px" style="border-color: #000080; border-style: none none groove none; border-width: 1px; "></asp:TextBox>
                    </td>
                </tr>
                <tr style="height:5px;">
                    <td></td>
                </tr>
                <tr height="30px">
                    <td align="right" valign="top">
                        操作内容
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtnr" runat="server" Width="600px" Height="150px" TextMode="MultiLine" style="border-color: #000080; border-style: none none groove none; border-width: 1px; "></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

