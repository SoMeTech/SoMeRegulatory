<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" title="考核内容大类设置" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="KaoPingTypeSet.aspx.cs" inherits="Work_KaoPing_KaoPingTypeSet" %>

<%@ Register Src="../../WebControls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Register Src="../../WebControls/WebOrderControl.ascx" TagName="WebOrderControl"
    TagPrefix="uc2" %>
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

    <script type="text/javascript">
        //菜单收缩
        function menuCollapse(w) {
            setWidth(w);
        }

        //菜单打开
        function menuExpand(w) {
            setWidth(w);
        }

        function setWidth(w) {
            //alert(w);

            //列表宽度重定义
            if (w > 1000) {
                var grid = document.getElementById('<%=gvResult.ClientID %>');
            grid.style.width = w;
        }
        //母版页panel宽度重定义
        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>

    <input type="hidden" id="txtindex" runat="server" />
    <input type="hidden" id="txttitle" runat="server" />
    <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="AUTO_ID" AllowSorting="true"
        OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two"
        OnSorting="gvResult_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <HeaderStyle Width="30px" />
                <ItemTemplate>
                    <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                        id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                        <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="考核内容" SortExpression="KHTYPENAME" HeaderStyle-Width="200px"
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labKHTYPENAME" runat="server" Text='<%#Eval("KHTYPENAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="权重" SortExpression="KHTYPEPER" HeaderStyle-Width="40px"
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labKHTYPEPER" runat="server" Text='<%#Eval("KHTYPEPER") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排序号" SortExpression="ORDERID" HeaderStyle-Width="40px"  Visible="false"
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labORDERID" runat="server" Text='<%#Eval("ORDERID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="确认状态" SortExpression="ISCOMFIRM" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labISCOMFIRM" runat="server" Text='<%# getComfirm(Eval("ISCOMFIRM")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="考核年度" SortExpression="khyear" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labkhyear" runat="server" Text='<%# Eval("khyear") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注" SortExpression="REMARK" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labREMARK" runat="server" Text='<%#Eval("REMARK") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="two" Visible="False" />
            <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
        <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
    </yyc:SmartGridView>
    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
</asp:Content>
