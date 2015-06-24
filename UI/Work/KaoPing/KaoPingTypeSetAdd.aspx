<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" title="新增考评大类" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="KaoPingTypeSetAdd.aspx.cs" inherits="Work_KaoPing_KaoPingTypeSetAdd" %>
    
<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitOpen.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            Loading.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Shared/jss/Check.js")%>"
        type="text/javascript" charset="gb2312"></script>

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <script src="../../Shared/jss/Check.js" type="text/javascript"></script>
             <br />
            <table cellpadding="0" cellspacing="0" class="menutext" cellspacing="0" cellpadding="0"
                width="100%" align="center" border="0">
                <tbody>                    
                    <tr height="40">
                        <td style="width: 113px" align="right" height="30">
                            年度：
                        </td>
                        <td align="left" height="30">
                        <asp:DropDownList ID="ddlKH_Year" runat="server">
                                <asp:ListItem Value="2013">2013</asp:ListItem>
                                <asp:ListItem Value="2014">2014</asp:ListItem>
                                <asp:ListItem Value="2015">2015</asp:ListItem>
                                <asp:ListItem Value="2016">2016</asp:ListItem>
                                <asp:ListItem Value="2017">2017</asp:ListItem>
                                <asp:ListItem Value="2018">2018</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 117px" align="right" height="30">
                            考核内容：
                        </td>
                        <td style="width: 248px; text-align: left" height="30">
                            <asp:TextBox ID="txtKHTypeName" runat="server" Width="200px" Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;"></asp:TextBox>  <font color="red">*</font>
                        </td>
                    </tr>
                    <tr height="40">
                        <td style="width: 113px" align="right" height="30">
                            分值：
                        </td>
                        <td style="width: 196px" align="left" height="30">
                            <asp:TextBox ID="txtKHTypePer" runat="server" Width="200px" Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;"></asp:TextBox><font color="red">*</font>
                        </td>
                        <td style="width: 117px" align="right" height="30">
                            排序号：
                        </td>
                        <td style="width: 248px; text-align: left" height="30">
                            <asp:TextBox ID="txtOrderID" runat="server" Width="200px" Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 117px; height: 30px" align="right">
                            备注：
                        </td>
                        <td style="width: 248px; height: 30px; text-align: left" colspan="3">
                            <asp:TextBox ID="txtRemark" runat="server" Width="595px" Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;" BorderColor="#CCCCCC"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td style="width: 117px; height: 30px" align="right">
                            确认状态：
                        </td>
                        <td style="width: 248px; height: 30px; text-align: left" colspan="3">
                            <asp:DropDownList ID="ddlIsComfirm" runat="server">
                                <asp:ListItem Value="0">未确认</asp:ListItem>
                                <asp:ListItem Value="1">已确认</asp:ListItem>                               
                            </asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
