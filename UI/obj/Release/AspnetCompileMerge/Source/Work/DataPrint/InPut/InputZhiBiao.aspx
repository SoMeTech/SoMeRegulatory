<%@ page language="C#" masterpagefile="~/Master/One.master" autoeventwireup="true" inherits="Work_DataPrint_InPut_InputZhiBiao"  CodeBehind="InputZhiBiao.aspx.cs" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/One.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>
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
            <input id="StartDate" runat="server" uid="StartDate" /> 至 
            <input id="EndDate" runat="server" uid="EndDate" />
            <asp:DropDownList ID="data" runat="server" Visible="false" ></asp:DropDownList>
            <input type="hidden" runat="server" id="hiddDatabase" />
            <asp:Button id="ShowData_B" runat="server" onclick="ShowData_Click" Text="查询"  CssClass="mouthType"/></div>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <div id='div_table'> 
            <yyc:SmartGridView ID="gvResult" runat="server" MouseOverCssClass="OverRow"  AutoGenerateColumns="False" 
                ContextMenuCssClass="RightMenu" Width="100%"  AllowSorting="true" CssClass="tKeepAll">
                <Columns>
                    <asp:TemplateField AccessibleHeaderText="选择">
                    <HeaderTemplate>
                    <input type="checkbox" id="All_Checkbox" onclick="SelectAll(this)"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <asp:CheckBox ID="checkbox1" runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        $(document).ready(function () {
            try {
                bind();
                //        $("#DataList").css("height",$("div[uid='Panel1']").get(0).offsetHeight+34);
                //        $("#SelectList").css("display","none");

            } catch (e) { alert(e) }
        });
        function bind() {
            // $("input[uid='StartDate']").attr("readonly","readonly");
            // $("input[uid='EndDate']").attr("readonly","readonly");
            BindDate($("input[uid='StartDate']").get(0).id);
            BindDate($("input[uid='EndDate']").get(0).id);
            $('#SelectList').get(0).cells[0].innerHTML = "";
            $('#SelectList').get(0).cells[0].appendChild($('#div_select').get(0));
            $('#SelectList').get(0).cells[1].innerHTML = "";
            $('#SelectList').get(0).cells[2].innerHTML = "";
        }
        function SelectAll(obj) {
            $("input[type='checkbox']", $('#div_table').get(0)).attr("checked", obj.checked);
        }
        function ShowLoading(str) {
            $("#loadingTxt").innerHTML = str;
            $("#loading").css("display", "block");
        }
        function NoneLoading() {
            alert(2);
            $("#loading").css("display", "none");
        }
    </script>
</asp:Content>

