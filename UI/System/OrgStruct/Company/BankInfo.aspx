<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" CodeBehind="BankInfo.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_BankInfo" %>
<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    
    <script type="text/javascript">
        //菜单收缩
        function menuCollapse() {
        }
        //菜单打开
        function menuExpand() {
        }
    </script>
    <input type="hidden" id="txttitle" runat="server" />
    <yyc:SmartGridView ID="gvResult" runat="server" Width="100%" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" AllowSorting="true" DataKeyNames="BankPK"
        BoundRowDoubleClickCommandName="two" BoundRowClickCommandName="Select" OnSorting="gvResult_Sorting"
         OnRowCommand="gvResult_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <itemtemplate>
                    <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>
                </itemtemplate>
                <headerstyle width="6%" />
            </asp:TemplateField>
            <asp:TemplateField Visible="False">
                <itemtemplate>
                    <asp:Label ID="labBankPK" runat="server" Text='<%#Eval("BankPK") %>'></asp:Label>
                </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="公司名称" SortExpression="Name"/>
            <asp:BoundField DataField="BankName" HeaderText="银行名称" SortExpression="BankName"/>
            <asp:BoundField DataField="BankNum" HeaderText="帐户号码" SortExpression="BankNum"/>
            <asp:BoundField DataField="BankNumMan" HeaderText="帐户所属人" SortExpression="BankNumMan"/>
            <asp:ButtonField CommandName="two" Visible="False" />
            <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
    </yyc:SmartGridView>
</asp:Content>
