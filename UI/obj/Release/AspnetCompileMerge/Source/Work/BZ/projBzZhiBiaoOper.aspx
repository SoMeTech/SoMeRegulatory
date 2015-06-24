<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" CodeBehind="projBzZhiBiaoOper.aspx.cs" inherits="Work_projectBZ_projBzZhiBiaoOper" title="补助指标管理" enableEventValidation="false" stylesheettheme="Default" %>


<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server" ID="lblAUTO_ID" Visible="false"></asp:Label>
    
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

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script type="text/jscript">
        function findwindow(val, obj) {
            var webFileUrl = "/Shared/DiagList/GetSession.aspx?tn=" + val;
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("/Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ss = arr.split("~");
                    obj.value = ss[1];
                    document.getElementsByName("<%=txtPD_QUOTA_LWJG.ClientID %>")[0].value = ss[0];
                    }
                }
            }

    </script>
    
    <div style="margin-top:10px;">
    <table cellspacing="0" cellpadding="0" width="100%" border="0" >
        <tr>
            <td align="right" style="width:130px; height:30px;">
                文件编号 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_CODE" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                文件名称 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_NAME" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                文件年度 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_YEAR" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:130px; height:30px;">
                来文机关 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_LWJG_NAME" runat="server" Width="200px" onclick="javascript:findwindow('XiangZhen',this);"></asp:TextBox>
                <asp:TextBox ID="txtPD_QUOTA_LWJG" runat="server" Width="200px" CssClass="noneDisplay"></asp:TextBox>
            </td>
            <td align="right" style="width:130px; height:30px;">
                是否统一下发 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_QUOTA_IFUP" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="right" style="width:130px; height:30px;">
                资金性质 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_QUOTA_ZJXZ" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:130px; height:30px;">
                补助对象 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_TARGET" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                补助标准 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_STANDARD" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                补助依据 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_BASIS" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:130px; height:30px;">
                是否乡镇已签收 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_QUOTA_IFXZQS" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="right">
                是否已传出 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_QUOTA_IFPASS" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="right">
                监管依据 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_BASIS_JG" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:130px; height:30px;">
                传出日期 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_PASS_DATE" runat="server" Width="180px"></asp:TextBox>
                <%--<asp:ImageButton ID="ImageButton1" runat="server" AlternateText="日期" ImageUrl="~/images/dtpicker.bmp" />
                <cc2:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPD_QUOTA_PASS_DATE"
                    PopupButtonID="ImageButton1" Format="yyyy-MM-dd">
                </cc2:CalendarExtender>--%>
            </td>
            <td align="right">
                传出经办人 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_PASS_MAN" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                是否联络员已签收 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_QUOTA_IFLLYQS" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:130px; height:30px;">
                文件资料 ：
            </td>
            <td align="left" id="wj" runat="server">
               <%-- <asp:FileUpload ID="myFile" Style="width: 170px;" type="file" name="myFile" runat="server" />
                <asp:Button ID="Button1" OnClick="UploadFile" runat="server" Text="上传"></asp:Button>
                <asp:TextBox ID="txtPD_QUOTA_FILE" runat="server" Width="170px" Visible="false"></asp:TextBox>
                <div>
                    <uc1:filepostctr id="FilePostCtr1" runat="server" />
                </div>
               <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" Visible="false" />--%>
                <table id="zxzb_bt">
              <tr><td>
              <div id='upfile10000' style='Width:100%' onmouseover="MouseOnRowIndex=10000"><div id='ShowDIV10000' class="filetxt"></div></div>
              </td><td>
              <div class="fileUpArea"  onmouseover="MouseOnRowIndex=10000"><input type="file"  class="fileinput" name="filesupload"  onchange="BindUpLoad(this,'zxzb_bt',0)" ColumnIndex='0' rowIndex='10000' onmouseover="MouseOnRowIndex=10000" /></div>
              </td></tr>
              </table>
              <div>
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
            </td>
            <td align="right">
                预算资金 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPD_QUOTA_MONEY_TOTAL" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                归口部门 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_QUOTA_DEPART" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right">
                <!--项目审核状态 ：-->
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_PROJ_STATUS" runat="server" Width="200px" Visible="false">
                </asp:DropDownList>
            </td>
            <td align="right">
                <!--上一次审核状态:-->
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_PROJ_LAST_AUDIT_STATUS" runat="server" Width="200px"
                    Visible="false">
                </asp:DropDownList>
            </td>
            <td align="right">
                <!--是否退回 ：-->
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_IS_RETURN" runat="server" Width="200px" Visible="false">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right">
                <!--是否立项:-->
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlPD_ISOUT_QUOTA" runat="server" Width="200px" Visible="false">
                </asp:DropDownList>
            </td>
            <td align="right">
            </td>
            <td align="left">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer11" runat="server" ActiveTabIndex="0" Height="270px"
        Visible="true">
        <!--1-->
        <cc1:TabPanel ID="Panel_JBXX" runat="server" HeaderText="基本信息">
            <HeaderTemplate>
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td align="right">
                            监管要求：
                        </td>
                        <td colspan='5' align="left">
                            <asp:TextBox ID="txtPD_QUOTA_JGYQ" runat="server" Width="600" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            录入日期：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_QUOTA_INPUT_DATE" runat="server" Width="180px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            录入单位 ：
                        </td>
                        <td align="left">
                        
                            <asp:DropDownList ID="ddlPD_QUOTA_INPUT_COMPANY" runat="server" Width="200px"></asp:DropDownList>
                        </td>
                        <td align="right">
                            录入经办人 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_QUOTA_INPUT_MAN" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            联络员签收日期：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_QUOTA_ACCEPT_DATE" runat="server" Width="180px" EnableViewState="False"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="日期" ImageUrl="~/images/dtpicker.bmp" />
                            <cc2:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPD_QUOTA_ACCEPT_DATE"
                                PopupButtonID="ImageButton2" Format="yyyy-MM-dd" Enabled="True">
                            </cc2:CalendarExtender>
                        </td>
                        <td align="right">
                            联络员签收单位：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlPD_QUOTA_ACCEPT_COMPANY" runat="server" Width="200px"></asp:DropDownList>
                        </td>
                        <td align="right">
                            联络员：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_QUOTA_ACCEPT_MAN" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            乡镇签收日期：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_QUOTA_XZ_ACCEPT_DATE" runat="server" Width="180px"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="日期" ImageUrl="~/images/dtpicker.bmp" />
                            <cc2:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtPD_QUOTA_XZ_ACCEPT_DATE"
                                PopupButtonID="ImageButton3" Format="yyyy-MM-dd" Enabled="True">
                            </cc2:CalendarExtender>
                        </td>
                        <td align="right">
                            乡镇签收单位：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlPD_QUOTA_XZ_ACCEPT_COMPANY" runat="server" Width="200px"></asp:DropDownList>
                            
                        </td>
                        <td align="right">
                            乡镇签收经办人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_QUOTA_XZ_ACCEPT_MAN" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <!--2-->
        <cc1:TabPanel ID="Panel_xzxx" runat="server" HeaderText="乡镇信息">
            <ContentTemplate>
            
            <div style="text-align: left;">
                        <a href="javascript:void(0)" onclick='alert(getfiledName().value)' style>getName</a> 
                        <a href="javascript:void(0)" onclick='loadTable_add("table_xzxx",json_xzxx,"bz_xzxx")'>增行</a>
                        <a href="javascript:void(0)" onclick="tableJDdel('table_xzxx',4);">删行</a></div>
                    <table id="table_xzxx" style="width: 800px" border="1" cellpadding="0" cellspacing="0"
                        bordercolor="#666666">
                        <tr>
                            <td style="display: none;">
                                自动ID
                            </td>
                            <td style="width: 50px">
                                选择
                            </td>
                            <td style="width: 200px; display:none;">
                                项目编码
                            </td>
                            <td style="width: 200px">
                                乡镇名称
                            </td>
                            <td style="width: 450px">
                                附件名称
                            </td>
                            <td style="width: 100px">
                                操作
                            </td>
                        </tr>
                    </table>
            
                <%--<div style="text-align: left;">
                    <asp:LinkButton ID="lbtnAdd_xmzl" runat="server" Width="80px" OnClick="lbtnAddRow_Click">添加行</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDel_xmzl" runat="server" OnClick="btnDeleteRow_Click" OnClientClick="return confirm('确定要删除选中行吗？');">删除选中行</asp:LinkButton>
                </div>
                <yyc:SmartGridView ID="gvResult_xzxx" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" ContextMenuCssClass="RightMenu" DataKeyNames="AUTO_NO"
                    AllowSorting="true"  OnRowCommand="gvResult_RowCommand"
                    OnSorting="gvResult_Sorting" HeaderStyle-BackColor="#EBEBEB">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <div style="text-align: center; width:20px">
                                    <asp:CheckBox ID="CheckBoxF" runat="server" />
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxNode" Width="20px" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                自动ID</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="AUTO_NO" Text='<%#Bind("AUTO_NO") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                项目编码</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_QUOTA_CODE" Text='<%#Bind("PD_QUOTA_CODE") %>'
                                    ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="乡镇名称" SortExpression="COMPANY_CODE" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlPD_Company_NAME" runat="server" DataSource='<%# ddlxzbind()%>'
                                    DataValueField="PK_CORP" DataTextField="NAME" AutoPostBack="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                附件名称</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="FILE_NAME" Text='<%#Bind("FILE_NAME") %>'
                                   ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </yyc:SmartGridView>--%>
               <%-- <input type="button" value="开始上传" id="idBtnupload" disabled="disabled" />
                &nbsp;&nbsp;&nbsp;
                <input type="button" value="全部取消" id="idBtndel" disabled="disabled" />  --%>            
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <script type="text/javascript">
        var json_xzxx = "<%=json_xzxx%>";

        function PostLoadxmsszl(tableID, json, addLoop) {
            Loadxmsszl(tableID, json, addLoop);
        }
        function loadTable_add(tableID, data, loop) {
            loadTable_JD(tableID, eval(data)[0], loop);
        }
        $(document).ready(function () {
            try {
                PostLoadxmsszl('table_xzxx', eval("<%=json_xzxxData %>"), 'bz_xzxx');
        Bind_tbHead(eval("<%=json_btData %>")[0], 10000, 'zxzb_bt', 5);
    } catch (e) { alert(e) }
    });

    BindDate('<%=txtPD_QUOTA_PASS_DATE.ClientID %>');
    </script>
</asp:Content>
