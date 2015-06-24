<%@ page language="C#" masterpagefile="~/Master/One.master" CodeBehind="DictionaryStep.aspx.cs" autoeventwireup="true" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="DictionaryStep" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="../../images/extanim32.gif" alt="" width="32" height="32" style="margin-right:8px;" align="absmiddle"/>
                正在获取数据,请稍候.....
        </div>
    </div>
    <div id="loading-mask"></div>
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
            //if(w>1000){
            //    var grid = document.getElementById('<%=gvResult.ClientID %>');
        //    grid.style.width=w;
        //}
        //母版页panel宽度重定义

        var panel = document.getElementById('<%=Master.PanelID %>');
        panel.style.width = w;
    }
    </script>

    <input type="hidden" id="txtindex" runat="server" />
    <input type="hidden" id="txttitle" runat="server" />
    
    <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="100%" 
        BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two" DataKeyNames="PK"
        AllowSorting="True" OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand">
    
        <Columns>
            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="30px" ItemStyle-Width="30px">
                <ItemTemplate>
                    <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>' id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'><%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="BH" HeaderText="编号" SortExpression="BH" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
            <asp:TemplateField HeaderText="名称" SortExpression="Name">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    <asp:TextBox ID="txtPK" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PK") %>'
                        Visible="false"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="上级名称" SortExpression="FatherPK">
                <ItemTemplate>
                    <asp:TextBox ID="txtPKPath" runat="server" Text='<%# Bind("PKPath") %>' Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtFatherPK" runat="server" Text='<%# Bind("FatherPK") %>' Visible="false"></asp:TextBox>
                    <asp:Label ID="lbFatherPK" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FatherName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="等级" SortExpression="Grade" HeaderStyle-Width="30px">
                <ItemTemplate>
                    <asp:Label ID="lbGrade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否有下级" SortExpression="IsHasBaby" HeaderStyle-Width="75px">
                <ItemTemplate>
                    <asp:Label ID="lbIsHasBaby" runat="server" Text='<%# Common.Str_GetIsHave(DataBinder.Eval(Container, "DataItem.IsHasBaby").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="说明" SortExpression="Discription" HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:TextBox ID="txtDiscription1" runat="server" Text='<%# Bind("Discription") %>' Visible="false"></asp:TextBox>
                    <asp:Label ID="lbDiscription" runat="server" Text='<%# Common.Str_Myleft(DataBinder.Eval(Container, "DataItem.Discription").ToString(), 8) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Two" Visible="False" />
            <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
        <FixRowColumn FixColumns="0,1,2" FixRows="" FixRowType="Header,Pager" />
    </yyc:SmartGridView>

    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
    
    <input type="text" id="tn" name="tn" visible="false" runat="server" value="" style="width: 35px" />
    <input type="text" id="ifadd" name="ifadd" visible="false" runat="server" value="1" style="width: 35px" />
</asp:Content>
