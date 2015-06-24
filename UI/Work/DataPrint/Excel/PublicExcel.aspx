
<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" inherits="Work_DataPrint_Excel_PublicExcel" CodeBehind="PublicExcel.aspx.cs" title="无标题页" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/resources/css/ext-all.css") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="../../../jss/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../../../jss/PublicJS.js" type="text/javascript"></script>

    <script src="PublicExcel.js" type="text/javascript"></script>
    <script type="text/javascript">
    </script>
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
    <input type="hidden" id="txtindex" runat="server" />
    <input type="hidden" id="txttitle" runat="server" />
    <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
        ContextMenuCssClass="RightMenu" Width="70%"  DataKeyNames="AUTO_ID" AllowSorting="true"
        OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
        BoundRowDoubleClickCommandName="Two" >
        <Columns>
            <asp:BoundField DataField="所属单位" HeaderText="所属单位" SortExpression="所属单位" ItemStyle-HorizontalAlign="Center" /> 
            <asp:BoundField DataField="所属部门" HeaderText="所属部门" SortExpression="所属部门" ItemStyle-HorizontalAlign="Center" /> 
            <asp:BoundField DataField="名称" HeaderText="名称" SortExpression="名称" ItemStyle-HorizontalAlign="Center" /> 
        
        <asp:TemplateField  HeaderText="操作">
        <ItemTemplate>
        <input type="hidden" id="autoid" runat="server" value='<%#Eval("AUTO_ID") %>' />
        <button onclick="DownFile(this)">下载模板</button>
        <button onclick="UpFile(this)">上传数据</button>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="two" Visible="False" />
        <asp:ButtonField CommandName="Select" Visible="False" />
        </Columns>
    </yyc:SmartGridView>
</asp:Content>

