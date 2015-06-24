<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="HeTongBGList.aspx.cs" inherits="Work_projectGL_HeTongBG_HeTongBGList" title="无标题页" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt="" width="355" height="127" style="margin-right:8px;" align="absmiddle"/>
                正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask"></div>
    <%} %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" DataKeyNames="AUTO_NO" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                BoundRowDoubleClickCommandName="Two">
                <Columns>
		            <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center"  Visible="false"/> 
		            <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_CHANGE_DATE" HeaderText="变更时间" SortExpression="PD_CONTRACT_CHANGE_DATE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_CHANGE_TYPE_NAME" HeaderText="变更类型" SortExpression="PD_CONTRACT_CHANGE_TYPE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_CHANGE_REASON" HeaderText="变更原因" SortExpression="PD_CONTRACT_CHANGE_REASON" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_TYPE_NAME" HeaderText="合同类型" SortExpression="PD_CONTRACT_TYPE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_NO" HeaderText="合同编号" SortExpression="PD_CONTRACT_NO" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_MONEY" HeaderText="合同金额" SortExpression="PD_CONTRACT_MONEY" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_CHANGE_ZJ" HeaderText="调增调减" SortExpression="PD_CONTRACT_CHANGE_ZJ" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_CHANGE_MONEY" HeaderText="变更金额" SortExpression="PD_CONTRACT_CHANGE_MONEY" ItemStyle-HorizontalAlign="Center"  /> 
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

