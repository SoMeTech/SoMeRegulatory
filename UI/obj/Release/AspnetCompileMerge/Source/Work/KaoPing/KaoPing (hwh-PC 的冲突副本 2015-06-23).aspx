<%@ page language="C#" masterpagefile="~/Master/KP.master" autoeventwireup="true"  CodeBehind="KaoPing.aspx.cs" inherits="Work_KaoPing_KaoPing" title="评分管理" enableEventValidation="false" stylesheettheme="Default" %>
<%@ MasterType VirtualPath="~/Master/KP.master" %>
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

    <script src="../../jss/jquery-1.7.2.js" type="text/javascript"></script>

    <script type="text/javascript">


        //验证不能输入单引号
        function onlyNum4() {
            if (event.keyCode == 222) {
                return false;
            }
            else {
                return true;
            }
        }

        function findwindow(val, num) {
            window.parent.frames["topFrame"].findwindow(helpMess);
            return;


            var webFileUrl = "";
            webFileUrl = "../../PublicMode/DiagList/GetSession.aspx?tn=" + val + "";

            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            if (arr != null) {
                if (arr != "false")
                    helpMess(arr, num);
            }
        }
        function helpMess(val, num) {
            if (val.indexOf("~") > 0) {
                ss = val.split("~");
                document.all['<%=txtKPCompany.ClientID %>'].value = ss[1];
                document.all['<%=hCompanyPK.ClientID %>'].value = ss[0];
            }
        }


    </script>

    <style type="text/css">
        #popupcontent
        {
            position: absolute;
            visibility: hidden;
            overflow: scroll;
            border: 1px solid #CCC;
            background-color: #F9F9F9;
            border: 1px solid #333;
            padding: 5px;
            width:500px;
        }
    </style>

    <script type="text/javascript">
        var baseText = null;
        var msgBoxBackDiv = null;
        function showPopup(w, h) {
            var popUp = document.getElementById("popupcontent");
            //        msgBox_getBackDiv();
            popUp.style.top = "0px";
            popUp.style.left = "0px";
            popUp.style.width = "100%"; //w + "px";   
            popUp.style.height = h + "px";
            popUp.style.zIndex = "9999";
            if (baseText == null) baseText = popUp.innerHTML;
            popUp.innerHTML = baseText + "<div id=\"statusbar\"></div>";
            var sbar = document.getElementById("statusbar");
            popUp.style.visibility = "visible";
        }
        function hidePopup() {
            var popUp = document.getElementById("popupcontent");
            popUp.style.visibility = "hidden";
            //  window.location.reload();
        }
        function closeWindow() {
            //    alert(window.location.search);
            window.location.href = window.location.href;
            $("popupcontent").style.display = "none";

        }

        function submit() {

        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="txtindex" runat="server" />
            <input type="hidden" id="txtcor" runat="server" />
            <input type="hidden" id="txttitle" runat="server" />
            <input id="txtKP_Year" type="hidden" runat="server" />
            <input id="username" type="hidden" runat="server" />
            <input id="hCompanyPK" runat="server" type="hidden" />
            <input id="hKH_Type" runat="server" type="hidden" />
            <input id="hAuto_ID" runat="server" type="hidden" />
            <table border="0" cellpadding="0" cellspacing="0" style="width: auto">
                <tr>
                    <td>
                        &nbsp; &nbsp;年度：
                    </td>
                    <td style="width: 40px; text-align: left;">
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp; 考评单位：
                    </td>
                    <td>
                        <asp:TextBox ID="txtKPCompany" onclick="javascript:findwindow('company','4');" runat="server"
                            Width="150px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                        <span style="color: Red;">*</span>
                    </td>
                    <td>
                        &nbsp; &nbsp;考核类型：
                    </td>
                    <td style="width: 40px; text-align: left;">
                        <asp:DropDownList ID="ddlKHType" runat="server">
                            <asp:ListItem Value="0">日常考核</asp:ListItem>
                            <asp:ListItem Value="1">年度考评</asp:ListItem>
                            <asp:ListItem Value="2">专项检查</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center" style="width: 50px;">
                        <asp:Button ID="lbtnOk" runat="server" CssClass="mouthType" Text="查 询" OnClick="lbtnOk_OnClick" />
                    </td>
                </tr>
            </table>
            <div style=" height: 100%">
                <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                    ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="AUTO_ID" AllowSorting="true"
                    BoundRowClickCommandName="Select" BoundRowDoubleClickCommandName="Two" GridLines="Both">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <a name='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'
                                    id='maodian_<%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%>'>
                                    <%# this.gvResult.PageIndex * this.gvResult.PageSize + this.gvResult.Rows.Count + 1%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="考评内容" SortExpression="KHTYPENAME" HeaderStyle-Width="260px"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="labKHTYPENAME" runat="server" Text='<%#Eval("KHTYPENAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="KHTYPEPER" HeaderText="分值" SortExpression="KHTYPEPER"
                            ItemStyle-HorizontalAlign="Center" Visible="false" />
                        <asp:TemplateField HeaderText="基础分" SortExpression="KHTYPEPER" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="labKHTYPEPER" runat="server" Text='<%#Eval("KHTYPEPER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="扣分" SortExpression="KP_SCORE" HeaderStyle-Width="80px"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="labKP_SCORE" runat="server" Text='<%#Eval("KP_SCORE")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="综合分" SortExpression="Score" HeaderStyle-Width="80px"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="labSCORE" runat="server" Text='<%#Eval("Score")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                    <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                </yyc:SmartGridView>
            </div>
            <div id="popupcontent" >
                <div>
                    <br />
                    <div align="left" style="border-bottom-width: 1px; width: 90%;">
                        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                        <asp:Button ID="btnClose" runat="server" OnClientClick="closeWindow()" Text="关闭" />
                      <%--  <asp:Button ID="btnExcel" runat="server" Text="导出Excel" />--%>
                    </div>
                </div>
                <div style="font-size: 16px; border: 1px; font-weight: bold;" align="center">
                    乡镇财政资金监管工作考核评价指标量化评分表</div>
                <br />
                <div style="font-size: 12px; border-style: ridge; border: 1px solid #CCC; width: 100%;">
                    <table>
                        <tr>
                            <td width="200px">
                                考评单位：<asp:Label ID="lblKP_Company" runat="server"></asp:Label>
                            </td>
                            <td width="200px">
                                考核类型：<asp:Label ID="lblKH_Type" runat="server"></asp:Label>
                            </td>
                            <td width="200px">
                                年度：<asp:Label ID="lblYear" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left">
                                下列考核总分值：
                                <asp:Label ID="lbKHFZ" runat="server" Font-Size="Medium" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 100%;">
                    <asp:GridView ID="gvBiaoZhun" runat="server" AutoGenerateColumns="False" DataKeyNames="AUTO_ID"
                        ContextMenuCssClass="RightMenu" MouseOverCssClass="OverRow" Width="100%" AllowSorting="true"
                        GridLines="Both">
                        <Columns>
                            <asp:TemplateField HeaderText="序号" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%# gvBiaoZhun.PageIndex * gvBiaoZhun.PageSize + gvBiaoZhun.Rows.Count + 1 %>"
                                        Width="15px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="考评明细编号" Visible="false" SortExpression="KPDETAILID"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="KPDETAILID" runat="server" Text='<%#Eval("KPDETAILID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--     <asp:TemplateField HeaderText="考评明细编号" SortExpression="KPDETAILID" HeaderStyle-Width="60px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="KPDETAILID" type="text" runat="server" Style="width: 70px" value='<%#Eval("KPDETAILID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%-- <asp:BoundField DataField="kpDetailID" HeaderText="考评明细编号" HeaderStyle-Width="80px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />--%>
                            <asp:BoundField DataField="KP_CONTENT" HeaderText="考评内容" HeaderStyle-Width="200px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                            <%--  <asp:BoundField DataField="KP_BASECODE" HeaderText="分值" HeaderStyle-Width="60px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />--%>
                            <asp:BoundField DataField="KP_BIAOZHUN" HeaderText="扣分标准" HeaderStyle-Width="150px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                            <%-- <asp:BoundField DataField="KP_Score" HeaderText="扣分值" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />--%>
                            <asp:TemplateField HeaderText="扣分值" SortExpression="KP_Score" HeaderStyle-Width="60px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtKP_Score" type="text" runat="server" Style="width: 70px" value='<%#Eval("KP_Score") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:BoundField DataField="KP_REMARK" HeaderText="备注" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />--%>
                            <%-- <asp:TemplateField HeaderText="评分" SortExpression="Score" HeaderStyle-Width="80px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtScore" type="text" runat="server" Style="width: 70px" value='<%#Eval("Score") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
