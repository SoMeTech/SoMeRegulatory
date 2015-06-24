<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="BzGKGSList.aspx.cs" inherits="Work_BZ_projBzGKGSList" title="补助性资金公开公示" enableEventValidation="false" stylesheettheme="Default" %>

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
                ContextMenuCssClass="RightMenu" Width="300%" DataKeyNames="AUTO_NO" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                BoundRowDoubleClickCommandName="Two">
                <Columns>
		            <asp:BoundField DataField="AUTO_NO" HeaderText="自动编号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center"  Visible="false"/> 
		            <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_PROJECT_NAME" HeaderText="项目名称" SortExpression="PD_PROJECT_NAME" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_TYPE" HeaderText="合同类型" SortExpression="PD_CONTRACT_TYPE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_NO" HeaderText="合同编号" SortExpression="PD_CONTRACT_NO" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_NAME" HeaderText="合同名称" SortExpression="PD_CONTRACT_NAME" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_DATE" HeaderText="合同日期" SortExpression="PD_CONTRACT_DATE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_COMPANY" HeaderText="合同签约单位" SortExpression="PD_CONTRACT_COMPANY" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_MOENY" HeaderText="合同金额" SortExpression="PD_CONTRACT_MOENY" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_MOENY_CHANGE" HeaderText="合同变更后金额" SortExpression="PD_CONTRACT_MOENY_CHANGE" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_ASK_LIMIT" HeaderText="合同工期要求" SortExpression="PD_CONTRACT_ASK_LIMIT" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_ASK_PROCEED" HeaderText="合同进度要求" SortExpression="PD_CONTRACT_ASK_PROCEED" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_ASK_PAYMENT" HeaderText="合同付款要求" SortExpression="PD_CONTRACT_ASK_PAYMENT" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_CONTRACT_NOTE" HeaderText="合同备注" SortExpression="PD_CONTRACT_NOTE" ItemStyle-HorizontalAlign="Center"  /> 
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

