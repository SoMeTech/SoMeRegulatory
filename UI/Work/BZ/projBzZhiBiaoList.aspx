<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="projBzZhiBiaoList.aspx.cs" inherits="Work_projectBZ_projBzZhiBiaoList" title="补助指标列表" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="PD_QUOTA_CODE" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                BoundRowDoubleClickCommandName="Two" >
                <Columns>
                    <asp:BoundField DataField="AUTO_NO" HeaderText="自增ID" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_CODE" HeaderText="文件编号" SortExpression="PD_QUOTA_CODE"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_NAME" HeaderText="文件名称" SortExpression="PD_QUOTA_NAME"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_YEAR" HeaderText="文件年度" SortExpression="PD_YEAR" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_LWJG" HeaderText="来文机关" SortExpression="PD_QUOTA_LWJG"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_IFUP" HeaderText="是否统一下发" SortExpression="PD_QUOTA_IFUP"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_ZJXZ" HeaderText="资金性质" SortExpression="PD_QUOTA_ZJXZ"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_TARGET" HeaderText="补助对象" SortExpression="PD_QUOTA_TARGET"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_STANDARD" HeaderText="补助标准" SortExpression="PD_QUOTA_STANDARD"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_BASIS" HeaderText="补助依据" SortExpression="PD_QUOTA_BASIS"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_IFXZQS" HeaderText="是否乡镇已签收" SortExpression="PD_QUOTA_IFXZQS"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_IFPASS" HeaderText="是否已传出" SortExpression="PD_QUOTA_IFPASS"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_BASIS_JG" HeaderText="监管依据" SortExpression="PD_QUOTA_BASIS_JG"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_INPUT_MAN" HeaderText="录入人员" SortExpression="PD_QUOTA_INPUT_MAN"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_PASS_DATE" HeaderText="传出日期" SortExpression="PD_QUOTA_PASS_DATE"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_ACCEPT_MAN" HeaderText="联络员签收经办人" SortExpression="PD_QUOTA_ACCEPT_MAN"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_PASS_MAN" HeaderText="传出经办人" SortExpression="PD_QUOTA_PASS_MAN"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_ACCEPT_COMPANY" HeaderText="联络员单位" SortExpression="PD_QUOTA_ACCEPT_COMPANY"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_ACCEPT_DATE" HeaderText="联络员签收日期" SortExpression="PD_QUOTA_ACCEPT_DATE"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_IFLLYQS" HeaderText="是否联络员已签收" SortExpression="PD_QUOTA_IFLLYQS"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_FILE" HeaderText="文件资料" SortExpression="PD_QUOTA_FILE"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_XZ_ACCEPT_COMPANY" HeaderText="乡镇签收单位" SortExpression="PD_QUOTA_XZ_ACCEPT_COMPANY"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_XZ_ACCEPT_DATE" HeaderText="乡镇签收日期" SortExpression="PD_QUOTA_XZ_ACCEPT_DATE"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_MONEY_TOTAL" HeaderText="预算资金" SortExpression="PD_QUOTA_MONEY_TOTAL"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_DEPART" HeaderText="归口部门" SortExpression="PD_QUOTA_DEPART"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_JGYQ" HeaderText="监管要求" SortExpression="PD_QUOTA_JGYQ"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_INPUT_DATE" HeaderText="录入日期" SortExpression="PD_QUOTA_INPUT_DATE"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_INPUT_COMPANY" HeaderText="录入单位" SortExpression="PD_QUOTA_INPUT_COMPANY"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_QUOTA_XZ_ACCEPT_MAN" HeaderText="乡镇签收经办人" SortExpression="PD_QUOTA_XZ_ACCEPT_MAN"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_PROJ_STATUS" HeaderText="项目审核状态" SortExpression="PD_PROJ_STATUS"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_PROJ_LAST_AUDIT_STATUS" HeaderText="上一次审核状态" SortExpression="PD_PROJ_LAST_AUDIT_STATUS"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_IS_RETURN" HeaderText="是否退回" SortExpression="PD_IS_RETURN"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PD_ISOUT_QUOTA" HeaderText="是否立项" SortExpression="PD_ISOUT_QUOTA"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
