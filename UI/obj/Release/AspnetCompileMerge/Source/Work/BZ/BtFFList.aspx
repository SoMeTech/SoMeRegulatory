<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="BtFFList.aspx.cs" inherits="Work_BZ_projBtFFList" title="补贴发放列表" enableEventValidation="false" stylesheettheme="Default" %>

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
                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="AUTO_NO" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                BoundRowDoubleClickCommandName="Two" >
                <Columns>
		<asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center"  Visible="false" /> 
		<asp:BoundField DataField="PD_BZFFLIST_DATE" HeaderText="补贴发放时间" SortExpression="PD_BZFFLIST_DATE" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_COMPANY" HeaderText="补贴发放单位" SortExpression="PD_BZFFLIST_COMPANY" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_COUNTRY" HeaderText="所属乡镇" SortExpression="PD_BZFFLIST_COUNTRY" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_PEASANT_CODE" HeaderText="农户代码" SortExpression="PD_BZFFLIST_PEASANT_CODE" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_PEASANT_NAME" HeaderText="农户姓名" SortExpression="PD_BZFFLIST_PEASANT_NAME" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_IDNO" HeaderText="身份证号码" SortExpression="PD_BZFFLIST_IDNO" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_FFNUM" HeaderText="补贴数量" SortExpression="PD_BZFFLIST_FFNUM" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_FFSTAND" HeaderText="补贴标准" SortExpression="PD_BZFFLIST_FFSTAND" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_FFMONEY" HeaderText="补贴金额" SortExpression="PD_BZFFLIST_FFMONEY" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_ACCOUNTNO" HeaderText="发放账号" SortExpression="PD_BZFFLIST_ACCOUNTNO" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PD_BZFFLIST_PEASANT_ADDR" HeaderText="农户家庭住址" SortExpression="PD_BZFFLIST_PEASANT_ADDR" ItemStyle-HorizontalAlign="Center"  /> 

                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

