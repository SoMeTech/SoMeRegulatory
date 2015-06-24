<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" CodeBehind="BtFFMx.aspx.cs" inherits="Work_BZ_projBtFFMx" title="新增补贴发放信息" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../jquery.easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    <div style="text-align: center; margin-top:10px;">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr style="display: none;">
                <td style="width: 130px; height: 30px;" align="right">
                    自动序号 ：
                </td>
                <td align="left">
                    <asp:Label ID="lblAUTO_NO" runat="server" CssClass="label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    补贴发放单位 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_COMPANY" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 130px; height: 30px;" align="right">
                    所属乡镇 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_BZFFLIST_COUNTRY" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="width: 130px; height: 30px;" align="right">
                    农户代码 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_PEASANT_CODE" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    农户姓名 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_PEASANT_NAME" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="right">
                    身份证号码 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_IDNO" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 130px; height: 30px;" align="right">
                    补贴数量 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_FFNUM" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    补贴标准 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_FFSTAND" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="right">
                    补贴金额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_FFMONEY" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 130px; height: 30px;" align="right">
                    发放账号 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_ACCOUNTNO" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    补贴发放时间 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td align="right">
                    农户家庭住址 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_BZFFLIST_PEASANT_ADDR" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
