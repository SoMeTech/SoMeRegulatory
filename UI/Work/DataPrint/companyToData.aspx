<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" inherits="Work_DataPrint_companyToData" CodeBehind="companyToData.aspx.cs"  title="无标题页" enableEventValidation="false" stylesheettheme="Default" %>

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
                ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="PK" AllowSorting="true"
                OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                BoundRowDoubleClickCommandName="Two" >
                <Columns>
		            <asp:BoundField DataField="PK" HeaderText="PK" SortExpression="PK" ItemStyle-HorizontalAlign="Center" Visible="false"/> 
		            <asp:BoundField DataField="SHOWNAME" HeaderText="帐套名" SortExpression="DATANAME" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="COMPANYNAME" HeaderText="单位名称" SortExpression="COMPANYBH" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="COMPANYBH" HeaderText="单位编码" SortExpression="COMPANYBH" ItemStyle-HorizontalAlign="Center"  /> 
                    <asp:ButtonField CommandName="two" Visible="False" />
                    <asp:ButtonField CommandName="Select" Visible="False" />
                </Columns>
            </yyc:SmartGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

