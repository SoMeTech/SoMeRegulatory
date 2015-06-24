<%@ page language="C#" autoeventwireup="true" inherits="Work_FaGui_messback" CodeBehind="messback.aspx.cs" masterpagefile="~/Master/One.master" enableEventValidation="false" stylesheettheme="Default" %>
<%@ Register Src="../../WebControls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Register Src="../../WebControls/WebOrderControl.ascx" TagName="WebOrderControl" TagPrefix="uc2" %>
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

    <script type="text/javascript">
        //菜单收缩
        function menuCollapse(w) {
            setWidth(w);
        }
        //双击查看
        function gvResultClientClick() {
            document.getElementById("ibtcontrol_ibtdo").click();
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
        ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="MES_ID" AllowSorting="true"
       BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two" 
        TimeSpan="1000" ondblclick="gvResultClientClick()">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <HeaderStyle Width="30px" />
                <ItemTemplate>
                    <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>' id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'><%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="填报单位" SortExpression="mes_company_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labmes_company_name" runat="server" Text='<%#Eval("mes_company_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="填报日期" SortExpression="MES_DATE"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labMES_DATE" runat="server" Text='<%#Eval("MES_DATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="填报人员" SortExpression="MES_MAN"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="labMES_MAN" runat="server" Text='<%#Eval("MES_MAN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>        
            <asp:TemplateField HeaderText="存在的问题及困难" SortExpression="MES_TITLE"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="laMES_TITLE" runat="server" Text='<%#Eval("MES_KUNAN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>  
           
            <asp:ButtonField CommandName="two" Visible="False" />
            <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
    </yyc:SmartGridView>
    
    <%
        if (txtindex.Value != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "topage", "window.location.hash = 'maodian_" + txtindex.Value + "';", true);
        }
    %>
    
</asp:Content>
