
<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" inherits="Work_DataPrint_InPut_InputBuTieFF"  CodeBehind="InputBuTieFF.aspx.cs" enableEventValidation="false" stylesheettheme="Default" %>

<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.css") %>"
        type="text/css" rel="stylesheet" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.js") %>"
        type="text/javascript"></script>
        
    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/resources/css/ext-all.css") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>
    <%if (!Page.IsPostBack) %>
    <%{ %>
    
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowait.js") %>" type="text/javascript"></script>
    
    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt="" width="355" height="127" style="margin-right:8px;" align="absmiddle"/>
                <label id="loadingTxt">正在获取数据,请稍候.....</label>
        </div>
    </div>
    <div id="loading-mask"></div>
    <%} %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id='div_select' style="height:30px;"> 
            <table id="zxzb_bt" runat="server">
              <tr><td>
              <div id='upfile10000' style='Width:100%' onmouseover="MouseOnRowIndex=10000"><div id='ShowDIV10000' class="filetxt"></div></div>
              </td><td>
              <div class="fileUpArea"  onmouseover="MouseOnRowIndex=10000"><input type="file"  class="fileinput" name="filesupload"  onchange="BindUpLoad(this,'zxzb_bt',0,'?temp=temp')" ColumnIndex='0' rowIndex='10000' onmouseover="MouseOnRowIndex=10000" /></div>
              </td><td>
                <a href="javascript:void(0)" onclick="DownModel()" >补贴发放导入模板</a>
              </td></tr>
              </table>
            <div>
                 <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
            </div>
            </div>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <div id='div_table'> 
            <yyc:SmartGridView ID="gvResult" runat="server" MouseOverCssClass="OverRow"  AutoGenerateColumns="False" 
                ContextMenuCssClass="RightMenu" Width="100%"  AllowSorting="true" CssClass="tKeepAll">
                <Columns>
                </Columns>
            </yyc:SmartGridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        $(document).ready(function () {
            try {
                bind();
            } catch (e) { alert(e) }
        });
        function bind() {
            $('#SelectList').get(0).cells[0].innerHTML = "";
            $('#SelectList').get(0).cells[1].innerHTML = "";
            $('#SelectList').get(0).cells[2].innerHTML = "";
            $('#SelectList').get(0).cells[0].appendChild($('#div_select').get(0));
        }
    </script>
</asp:Content>

