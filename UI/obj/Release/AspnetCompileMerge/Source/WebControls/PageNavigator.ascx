<%@ control language="C#" autoeventwireup="true" inherits="PageNavigator" CodeBehind="PageNavigator.ascx.cs"%>
<!-- PageNavigator V1.0 for VS2005 & VS2008  Author:dnawo Web:http://www.mzwu.com/ -->

<!-- 1.分页控件各属性(总记录数、每页记录数、当前页数、总页数),可根据需要选择显示与否 -->
<table border="0" cellpadding="0" cellspacing="0" style="width:300px">
    <tr>
        <td style="width: 602px">
            <asp:Label runat="server" ID="LblRecordCount" Font-Bold="True" ForeColor="Red" Visible="False" />[<asp:Label runat="server" ID="LblPageIndex" Font-Bold="True" ForeColor="Red" />/<asp:Label runat="server" ID="LblPageCount" Font-Bold="True" ForeColor="Red"/>]

            <asp:ImageButton ID="LnkBtnFirst" name="LnkBtnFirst" runat="server" ImageUrl="~/Ext/resources/images/default/grid/page-first.gif" ToolTip="首页" OnClick="LnkBtnFirst_Click" CssClass="page_img"/>&nbsp;
            <asp:ImageButton ID="LnkBtnPrevious" name="LnkBtnPrevious" runat="server" ImageUrl="~/Ext/resources/images/default/grid/page-prev.gif" ToolTip="上一页" OnClick="LnkBtnPrevious_Click" CssClass="page_img"/>&nbsp;
            <asp:ImageButton ID="LnkBtnNext" name="LnkBtnNext" runat="server" ImageUrl="~/Ext/resources/images/default/grid/page-next.gif" ToolTip="下一页" OnClick="LnkBtnNext_Click" CssClass="page_img"/>
            <asp:ImageButton ID="LnkBtnLast" name="LnkBtnLast" runat="server" ImageUrl="~/Ext/resources/images/default/grid/page-last.gif" ToolTip="最后一页" OnClick="LnkBtnLast_Click" CssClass="page_img"/>
            &nbsp;&nbsp;页行数<asp:textbox ID="TextBox1" name="TextBox1" runat="server" 
                width="21px" TabIndex="1" CssClass="page_input"/>
            转到<asp:textbox ID="txtNewPageIndex" name="txtNewPageIndex" runat="server" 
                width="22px" TabIndex="2" CssClass="page_input"/>&nbsp;<asp:ImageButton
                ID="BtnGoto" name="BtnGoto" runat="server" ImageUrl="~/images/go.gif" CommandName="Page" OnClick="BtnGoto_Click" />

            <asp:Label runat="server" ID="LblPageSize" Visible="False" />
        </td>
    </tr>
</table>
<!-- 按钮完毕 -->

<!-- PageNavigator V1.0 for VS2005 & VS2008 End -->

