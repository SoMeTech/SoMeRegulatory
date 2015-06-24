<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" CodeBehind="setup.aspx.cs" autoeventwireup="true" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="setup" %>

<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitOpen.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="../images/extanim32.gif" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>
    <input type="hidden" id="txttitle" runat="server" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <table width="100%" align="left">
        <tr height="30">
            <td align="right">
                服务器IP地址(<span style="text-decoration: underline">S</span>)<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtServiceIP" runat="server" Width="200px" onkeypress="return fifteenth(this, event)" onkeyup="return onlyNum3()"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                数据库对象名(<span style="text-decoration: underline">S</span>)<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtServiceName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td align="right">
                用户名(<span style="text-decoration: underline">U</span>)<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtUserName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                密码(<span style="text-decoration: underline">P</span>)
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassWord" runat="server" Width="200px" TextMode="Password" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td align="right">
                确认密码(<span style="text-decoration: underline">P</span>)
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtAginPD" runat="server" Width="200px" TextMode="Password" onkeypress="return fifteenth(this, event)"></asp:TextBox><asp:CompareValidator
                    ID="CompareValidator1" runat="server" ControlToCompare="txtAginPD" ControlToValidate="txtPassWord"
                    ErrorMessage="*"></asp:CompareValidator>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                菜单根节点
            </td>
            <td align="left">
                <asp:TextBox ID="txtMenuNodeName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td align="right">
                菜单根节点值
            </td>
            <td align="left">
                <asp:TextBox ID="txtMenuNodeValue" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                是否开启错误日志
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rbtifOpenExceptionLog" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
                是否开启操作日志
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rbtifOpenOpLog" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <%--<tr height="30">
            <td align="right">
                是否允许办理过程中修改表单
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rbtischangelist" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
                是否限制证件只能打印一次
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rbtisprint" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>--%>
       <%-- <tr height="30">
            <td align="right">
                是否需要手动核销
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rbtisgathering" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
                是否自动生成内部循环表
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rbtisautotable" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>--%> 
        <tr height="30">
            <td align="right">
                是否乡镇能看到总指标文件
            </td>
            <td align="left">
                <asp:RadioButtonList ID="db_quota_fileIsShow" runat="server" Width="100px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="right">
                错误日志路径
            </td>
            <td width="400" colspan="3">
                <%--<input id="FileErrMessPath" type="file" style="width: 400px" runat="server" />--%>
                <%--<asp:FileUpload id="FileErrMessPath" runat="server" style="width: 400px" />--%>
                <asp:TextBox ID="FileErrMessPath" runat="server" style="width: 400px"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                单列表窗体的列表行数
            </td>
            <td align="left">
                <asp:TextBox ID="txtPageSizeOne" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td align="right">
                双列表窗体的列表行数
            </td>
            <td align="left">
                <asp:TextBox ID="txtPageSizeTwo" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
