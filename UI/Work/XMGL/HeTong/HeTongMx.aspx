<%@ page language="C#" masterpagefile="~/Master/MainMX.master" title=" " autoeventwireup="true" CodeBehind="HeTongMx.aspx.cs" inherits="Work_projectGL_HeTong_HeTongMx" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.css") %>"
        type="text/css" rel="stylesheet" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script src="HeTong.js" type="text/javascript"></script>

    <script src="../../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        function findwindow(val, obj) {
            var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val + "&pd_year=" + $("select[uid='ddlPD_YEAR']").get(0).value + "&ProjectType=01";
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ss = arr.split("~");
                    //alert(ss);
                    try {
                        document.getElementById("<%=txtPD_PROJECT_CODE.ClientID %>").value = ss[0];
                        obj.value = ss[1];
                    } catch (e) { alert(e) };
                }
            }
        }
        function gvResultClientClick() {
            $("input[uid='ibtid']").get(0).value = 'gvResult_Click';
            IsSubmit();
        }


        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function ClientSubmit() {
            //alert($("#txtPD_PROJECT_CODE").value);
            var xmcode = $('input[uid="txtPD_PROJECT_CODE"]').eq(0).val();
            var htje = $('input[uid="txtPD_CONTRACT_MOENY"]').eq(0).val();

            var updatepk = getQueryString("UpdatePK");

            var ref = null;

            try {
                $.ajax({
                    type: "POST",   //访问WebService使用Post方式请求
                    contentType: "application/json", //WebService 会返回Json类型
                    url: "HeTongMx.aspx/PanDuanHeTongJinE", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                    async: false,
                    data: "{PD_PROJECT_CODE:'" + xmcode + "',PD_CONTRACT_MOENY:'" + htje + "',Contract_Code:'" + updatepk + "'}",         //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到       
                    dataType: 'json',
                    success: function (result) {     //回调函数，result，返回值
                        ref = result.d;
                        return false;
                        //                        alert(result.d);
                    }
                });
            } catch (e) { alert(e) }

            if (ref != true) {
                alert('累计合同金额大于项目投资额,不能保存!');
                removeWindowFull();
                return false;
            }
            try {
                return PublicYanZheng();
            } catch (e) { }
        }
    </script>

    <div style="text-align: left;">
        <div style="border: thin solid #8db2e3; margin-top: 15px; margin-left: 10px; margin-right: 5px;">
            <p style="margin-top: -8px; margin-left: 15px; background-color: White; width: 70px;">
                合同信息：</p>
            <table border="0" style="width: auto;">
                <tr style="display: none;">
                    <td align="right" style="width: 130px; height: 40px;">
                        自动编号 ：
                    </td>
                    <td align="left" colspan="6">
                        <asp:Label ID="lblAUTO_NO" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        项目年度 ：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPD_YEAR" uid="ddlPD_YEAR" runat="server" Style="width: 206px;"
                            Enabled="false" onchange="csPD_PROJECT_CODE()">
                        </asp:DropDownList>
                        <span style="color: Red">*</span>
                    </td>
                    <td align="right" style="width: 130px; height: 40px;">
                        项目名称 ：
                    </td>
                    <td align="left">
                        <input type="text" id='txtPD_PROJECT_Name' uid='txtPD_PROJECT_Name' runat="server"
                            disabled="disabled" style="width: 200px;" onclick="javascript: findwindow('proj_bianma2&pd_found_xz=01', this);"
                            readonly="readonly" />
                        <input type="text" id="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server"
                            style="width: 200px; display: none;" readonly="readonly" />
                        <span style="color: Red">*</span>
                    </td>
                    <td align="right">
                        合同名称 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPD_CONTRACT_NAME" runat="server" Style="width: 200px;" ></asp:TextBox>
                        <span style="color: Red">*</span>
                        <input type="text" id="txtPD_CONTRACT_NO" uid='txtPD_CONTRACT_NO' runat="server" style="width: 200px;display:none;" />
                    </td>
                    <%--<td align="right" style="width:130px; height:40px;"> 合同变更后金额
	  ：</td>
	<td align="left"><input type="text" id="txtPD_CONTRACT_MOENY_CHANGE" uid="txtPD_CONTRACT_MOENY_CHANGE" runat="server" style="width:200px;" disabled="disabled"/>    </td>--%>
                </tr>
                <tr><%--
                    <td align="right" style="width: 130px; height: 40px;">
                        合同编号 ：
                    </td>
                    <td align="left">
                        <span style="color: Red">*</span>
                    </td>--%>
                    <td align="right" style="width: 130px; height: 40px;">
                        合同日期 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_CONTRACT_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" uid='txtPD_CONTRACT_DATE' readonly="readonly" runat="server"
                            style="width: 200px;" /><span style="color: Red">*</span>
                    </td>
                    <td align="right" style="width: 130px; height: 40px;">
                        合同类型 ：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="txtPD_CONTRACT_TYPE" uid="txtPD_CONTRACT_TYPE" runat="server"
                            Style="width: 206px;">
                        </asp:DropDownList>
                        <span style="color: Red">*</span>
                    </td>
                    <td align="right">
                        合同签约单位 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPD_CONTRACT_COMPANY" uid="txtPD_CONTRACT_COMPANY" runat="server"
                            Style="width: 200px;"></asp:TextBox>
                        <span style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同金额 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_CONTRACT_MOENY_IsFull" uid="txtPD_CONTRACT_MOENY_IsFull" runat= "server" visible="false" />
                        <input type="text" id="txtPD_CONTRACT_MOENY" uid="txtPD_CONTRACT_MOENY" runat="server"
                            style="width: 200px;" onkeypress="myKeyDown(this,event,0);" onchange="setBGJE(this)"
                            maxlength='10' />
                        <span style="color: Red">*</span>
                    </td>
                    <td align="right">
                    </td>
                    <td align="left">
                    </td>
                    <td align="right">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 40px;">
                        合同工期要求 ：
                    </td>
                    <td colspan="5" align="left">
                        <asp:TextBox ID="txtPD_CONTRACT_ASK_LIMIT" uid="txtPD_CONTRACT_ASK_LIMIT" runat="server"
                            Style="width: 618px;"></asp:TextBox>
                        <span style="color: Red">*</span>
                    </td>
                
                </tr>
                <tr>
                    <td align="right" style="height: 40px;">
                        合同进度要求 ：
                    </td>
                    <td colspan="5" align="left">
                        <input type="text" id="txtPD_CONTRACT_ASK_PROCEED" uid="txtPD_CONTRACT_ASK_PROCEED"
                            runat="server" style="width: 618px;" />
                        <span style="color: Red">*</span>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        合同付款要求 ：
                    </td>
                    <td colspan="5" align="left">
                        <asp:TextBox ID="txtPD_CONTRACT_ASK_PAYMENT" uid="txtPD_CONTRACT_ASK_PAYMENT" runat="server"
                            Style="width: 618px;"></asp:TextBox>
                        <span style="color: Red">*</span>
                    </td>
                  
                </tr>
                <tr>
                    <td align="right" style="height: 40px;">
                        合同备注 ：
                    </td>
                    <td colspan="5" align="left">
                        <asp:TextBox ID="txtPD_CONTRACT_NOTE" runat="server" Style="width: 618px;"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        合同相关资料 ：
                    </td>
                    <td align="left" colspan="5">
                        <table id="zxzb_bt" runat="server">
                            <tr>
                                <td>
                                    <div id='upfile10000' style='border: thin solid #899aa1; width: auto; height: 25px;'
                                        onmouseover="MouseOnRowIndex=10000">
                                        <div id='ShowDIV10000' class="filetxt">
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="fileUpArea" onmouseover="MouseOnRowIndex=10000">
                                        <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                            columnindex='0' rowindex='10000' onmouseover="MouseOnRowIndex=10000" /></div>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: thin solid #8db2e3; margin-top: 15px; margin-left: 10px; margin-right: 5px;" runat="server" id="div_ht_change" visible="false" >
            <p style="margin-top: -8px; margin-left: 15px; background-color: White; width: 90px;">
                合同变更说明：</p>
            <table border="0" style="width:auto;">
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        变更原因 ：
                    </td>
                    <td align="left" colspan="5">
                        <input type="text" id="txtPD_CONTRACT_CHANGE_REASON" uid='txtPD_CONTRACT_CHANGE_REASON'
                            runat="server" style="width: 615px;" />
                        <span style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        变更时间 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_CONTRACT_CHANGE_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" uid='txtPD_CONTRACT_CHANGE_DATE' runat="server" style="width: 200px;" />
                        <span style="color: Red">*</span>
                    </td>
                    <td align="right">
                        变更类型 ：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="txtPD_CONTRACT_CHANGE_TYPE" runat="server" Width="206px">
                            <asp:ListItem Value="">----请选择---</asp:ListItem>
                            <asp:ListItem Value="01">一般变更</asp:ListItem>
                            <asp:ListItem Value="02">重大变更</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 130px; height: 40px;">
                        变更批复文号 ：
                    </td>
                    <td align="left">
                        <input type='text' runat="server" id='txtPD_CONTRACT_CHANGE_WH' uid='txtPD_CONTRACT_CHANGE_WH'
                            style="width: 200px;">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        合同变更资料 ：
                    </td>
                    <td colspan="5" align="left">
                        <table id="Table1" runat="server">
                            <tr>
                                <td>
                                    <div id='upfile10001' style='border: thin solid #899aa1; width: auto; height: 25px;'
                                        onmouseover="MouseOnRowIndex=10001">
                                        <div id='ShowDIV10001' class="filetxt">
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="fileUpArea" onmouseover="MouseOnRowIndex=10001">
                                        <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                            columnindex='0' rowindex='10001' onmouseover="MouseOnRowIndex=10001" /></div>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <uc1:FilePostCtr ID="FilePostCtr2" runat="server" />
                        </div>
                    </td>
                </tr>
            </table>
            <input type="hidden" id="json_btData" uid="json_btData" runat="server" />
            <input type="hidden" id="json_btData2" uid="json_btData2" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0" Visible="false">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="合同及变更记录列表" Width="200px">
            <HeaderTemplate>
                合同及变更记录列表
            </HeaderTemplate>
            <ContentTemplate>
                <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="AUTO_NO" AllowSorting="True" OnSorting="gvResult_Sorting"
                    OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                    BoundRowDoubleClickCommandName="Two" IfUserMouseOverCssClass="False" onClick="gvResultClientClick()"
                    RowDoubleClickDoed="False" TimeSpan="0" >
                    <Columns>
                        <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" Visible="False">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_TYPE_NAME" HeaderText="合同类型" SortExpression="PD_CONTRACT_TYPE" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_NO" HeaderText="合同编号" SortExpression="PD_CONTRACT_NO">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_MONEY" HeaderText="合同金额" SortExpression="PD_CONTRACT_MONEY"
                            Visible="False">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_CHANGE_MONEY" HeaderText="合同金额" SortExpression="PD_CONTRACT_CHANGE_MONEY">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                            <asp:BoundField DataField="PD_CONTRACT_CHANGE_DATE" HeaderText="变更时间" SortExpression="PD_CONTRACT_CHANGE_DATE">
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PD_CONTRACT_CHANGE_TYPE_NAME" HeaderText="变更类型" SortExpression="PD_CONTRACT_CHANGE_TYPE">
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PD_CONTRACT_CHANGE_REASON" HeaderText="变更原因" SortExpression="PD_CONTRACT_CHANGE_REASON">
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PD_CONTRACT_CHANGE_ZJ" HeaderText="调增调减" SortExpression="PD_CONTRACT_CHANGE_ZJ"
                                Visible="False">
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
<script type="text/javascript">
    setTimeout(Bing_Data(), 0);
</script>
</asp:Content>