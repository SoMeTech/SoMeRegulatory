<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" CodeBehind="SSMx.aspx.cs" inherits="Work_GL_SSMx" title="" enableEventValidation="false" stylesheettheme="Default" %>

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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/ImageFileUp.js") %>" type="text/javascript"></script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径

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
                    //alert(ss);
                    try {
                        obj.value = ss[0].split("|")[1];
                        obj.parentNode.parentNode.cells[7].firstChild.value = ss[0].split("|")[0];
                    } catch (e) { alert(e) };
                    SumCHANGE_ZJ(obj);
                }
            }
        }
    </script>

    <asp:TextBox Enabled="false" Visible="false" ID="_RowIndex" runat="server"></asp:TextBox>
    <div style="text-align: left;">
        <table width="100%" border="0" style="text-align: left;">
            <tr>
                <td height="30" align="right">
                    上级指标文号 ：
                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_FILENO_PF" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                    <input type="hidden" id="txtPD_PROJECT_FILENO_PF" uid="txtPD_PROJECT_FILENO_PF" runat="server" />
                    <asp:TextBox ID="lblPD_PROJECT_CODE" runat="server" Width="200px" Style="display: none;"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    &nbsp;
                </td>
                <td height="30" width="*" align="left">
                    &nbsp;
                </td>
                <td height="30" align="right">
                </td>
                <td height="30" width="*" align="left">
                </td>
            </tr>
            <tr>
                <td height="30" style="width: 130px;" align="right">
                    项目年度 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_YEAR" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    项目名称 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_NAME" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" style="width: 130px;" align="right">
                    归口部门 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_GK_DEPART" uid="lblPD_GK_DEPART" runat="server" Width="200px"
                        Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtPD_GK_DEPART" uid="txtPD_GK_DEPART" runat="server" Width="200px"
                        Style="display: none;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    资金性质 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_FOUND_XZ" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" style="width: 130px;" align="right">
                    项目类别 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_TYPE" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td style="width: 130px;" align="right">
                    资金来源 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_ZJLY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    主管科局 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="lblPD_PROJECT_ZGKJ" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    是否乡镇直接管理 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_IFXZGL" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    项目建设状态 ：
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_STATUS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    是否公示 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_IFGS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    是否事前公示 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_IFGS_BEFORE" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    公示主体 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_OPEN_BODY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    项目负责人 ：
                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_FZR" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    财务负责人 ：
                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_CWFZR" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    受益人数 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_SYRS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    开工日期 ：
                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_BEGIN_DATE" data-options="formatter:myformatter,parser:myparser"
                        class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    完工日期 ：
                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_END_DATE" data-options="formatter:myformatter,parser:myparser"
                        class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    项目建设时限 ：
                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_YEARS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    监管依据 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_FILENO_JG" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    所属乡镇：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="lblPD_PROJECT_COUNTRY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="30" align="right">
                </td>
                <td height="30" align="left">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="4" Visible="true">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="项目概况">
            <ContentTemplate>
                <table style="width: 100%; height: 200px; text-align: left;">
                    <tr>
                        <td style="text-align: right; width: 130px;">
                            项目建设地点：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_MONEY_ADDR" runat="server" Width="200"
                                CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目主要建设内容：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_CONTENT" runat="server" Width="200"
                                CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 130px;">
                            监管记录：
                        </td>
                        <td>
                            <asp:TextBox ID="PD_PROJECT_JGJL" runat="server" Width="200" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            监管结论：
                        </td>
                        <td>
                            <asp:TextBox ID="PD_PROJECT_JG_RESULT" runat="server" Width="200" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            财政所意见：
                        </td>
                        <td>
                            <asp:TextBox ID="PD_PROJECT_JG_SUGGEST" runat="server" Width="200" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目用途：
                        </td>
                        <td colspan='5'>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_XMYT" runat="server" Width="200" CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 130px;">
                            项目申报日期：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_INPUT_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="200" CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报单位：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_INPUT_COMPANY" runat="server" Width="200"
                                CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报经办人：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_INPUT_MAN" runat="server" Width="200"
                                CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目批复日期：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_REPLY_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="200" CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            项目批复单位：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_REPLY_COMPANY" runat="server" Width="200"
                                CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            项目批复经办人：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false" ID="lblPD_PROJECT_REPLY_MAN2" runat="server" Width="200"
                                CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_ztbgl" runat="server" HeaderText="招投标信息">
            <ContentTemplate>
                <div uname="div_file" style="text-align: left;">
                    <table style="width: 60%; height: 50px; text-align: left; vertical-align: bottom;">
                        <tr>
                            <td style="text-align: right; width: 20%; height: 30px;">
                                是否完成实施方案编制：
                            </td>
                            <td style="width: 70px;">
                                <asp:TextBox Enabled="false" ID="lblAUTO_NO" runat="server" Width="70" CssClass="label"
                                    Visible="false"></asp:TextBox>
                                <asp:DropDownList ID="ddlPD_PROJECT_ZTB_IF_SSFA" runat="server" Width="70px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 10%;">
                                &nbsp;
                            </td>
                            <td style="width: 230px">
                                实施情况图片：
                            </td>
                            <td style="width: 10%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px;">
                                是否招投标：
                            </td>
                            <td style="width: 70px;">
                                <asp:DropDownList ID="ddlPD_PROJECT_ZTB_IF_ZTB" runat="server" Width="70px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                &nbsp;
                            </td>
                            <td rowspan="5" style="width: 230px">
                                <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px;">
                                招标方式：
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPD_PROJECT_ZTB_STYLE" runat="server" Width="70px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px;">
                                是否有合同：
                            </td>
                            <td style="width: 70px;">
                                <asp:DropDownList ID="ddlPD_PROJECT_ISCONTRACT" runat="server" Width="70px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px;">
                                项目形象进度：
                            </td>
                            <td style="width: 70px;">
                                <asp:TextBox ID="txtPD_PROJECT_XXJD" runat="server" Width="70" CssClass="label" onKeyPress="myKeyDown(this,event,0)"></asp:TextBox>&nbsp;%
                            </td>
                            <td style="text-align: right;">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px;">
                                扶持项目工程量：
                            </td>
                            <td style="width: 70px;">
                                <asp:TextBox ID="txtPD_PROJECT_FCXMGCL" runat="server" Width="170px" CssClass="label"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px;">
                                工程质量情况：
                            </td>
                            <td style="width: 70px;">
                                <span style="text-align: left; height: 30px;">
                                    <asp:TextBox ID="txtPD_PROJECT_GCZLQK" runat="server" Width="170px" CssClass="label"
                                        TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </span>
                            </td>
                            <td style="text-align: left; height: 30px;">
                                &nbsp;
                            </td>
                            <td style="text-align: center;">
                                <%--<input type="button" name="upload" value="资料上传" />--%>上传图片：<input type="file"
                                    id="file1" name="file" onchange="LoadUp(this,'temp','UserImages')" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_htgl" runat="server" HeaderText="合同列表">
            <ContentTemplate>
                <div style="text-align: left; padding: 5px 10px; display: none;">
                    <a href="javascript:void(0)" onclick='loadTable_add("table_htgl",json_htgl,"ss_table_htgl")'>
                        <img src="../../images/AddRow.png" /></a> <a href="javascript:void(0)" onclick="tableJDdel('table_htgl',11);"><img src="../../images/DelRow.png" /></a></div>
                <div uname="div_file" style="text-align: left;">
                    <table id="table_htgl" style="width: 98%; text-align: center;" border="1" cellpadding="4"
                        cellspacing="0" bordercolor="#CCCCCC">
                        <tr style="background: #E9E9E9;">
                            <td style="width: 30px; height: 30px;">
                                选择
                            </td>
                            <td style="width: 6%">
                                合同编号
                            </td>
                            <td style="width: 6%">
                                合同名称
                            </td>
                            <td style="width: 8%">
                                合同日期
                            </td>
                            <td style="width: 8%">
                                合同签约单位
                            </td>
                            <td style="width: 6%">
                                合同金额
                            </td>
                            <td style="width: 8%">
                                合同变更后金额
                            </td>
                            <td style="width: 8%">
                                合同工期要求
                            </td>
                            <td style="width: 8%">
                                合同进度要求
                            </td>
                            <td style="width: 8%">
                                合同付款要求
                            </td>
                            <td style="width: 8%">
                                合同备注
                            </td>
                            <td>
                                合同相关资料
                            </td>
                            <td style="width: 5%">
                                操作
                            </td>
                        </tr>
                    </table>
                    <%-- <div>
                        <uc1:FilePostCtr ID="FilePostCtr2" runat="server" />
                    </div>--%>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_htbggl" runat="server" HeaderText="合同变更列表">
            <ContentTemplate>
                <div style="text-align: left; padding: 5px 10px; display: none;">
                    <a href="javascript:void(0)" onclick='loadTable_add("table_htbggl",json_htbggl,"ss_table_htbggl")'>
                        <img src="../../images/AddRow.png" /></a> <a href="javascript:void(0)" onclick="tableJDdel('table_htbggl',11);"><img src="../../images/DelRow.png" /></a></div>
                <div uname="div_file" style="text-align: left;">
                    <table id="table_htbggl" style="width: 98%; text-align: center;" border="1" cellpadding="4"
                        cellspacing="0" bordercolor="#CCCCCC">
                        <tr style="background: #E9E9E9;">
                            <td style="width: 30px; height: 30px;">
                                选择
                            </td>
                            <td style="width: 5%; display: none;">
                                批次管理
                            </td>
                            <td style="width: 3%; display: none;">
                                自动ID
                            </td>
                            <td style="width: 8%">
                                合同编号
                            </td>
                            <td style="width: 8%; display: none;">
                                项目代码
                            </td>
                            <td style="width: 8%">
                                变更时间
                            </td>
                            <td style="width: 8%">
                                变更原因
                            </td>
                            <td style="width: 8%">
                                合同金额
                            </td>
                            <td style="width: 8%">
                                调增调减
                            </td>
                            <td style="width: 8%">
                                变更金额
                            </td>
                            <td style="width: 5%; display: none;">
                                是否完成
                            </td>
                            <td>
                                变更资料
                            </td>
                            <td style="width: 5%">
                                操作
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <%--<cc1:TabPanel ID="Panel_xmssjk" runat="server" HeaderText="项目实施监控">
            <ContentTemplate>
            
               <div  style="text-align: left;">
                      <div style="text-align: left; padding:5px 10px;">
                        <a href="javascript:void(0)" onclick='loadTable_add("table_xmssjk",json_xmssjk,"ss_table_xmssjk")'>
                            增行</a> <a href="javascript:void(0)" onclick="tableJDdel('table_xmssjk',8);">删行</a></div>
                    <table id="table_xmssjk" style="width:98%" border="1" cellpadding="4" cellspacing="0"
                                bordercolor="#CCCCCC">
                        <tr>
                            <td style="width:30px;">
                                选择
                            </td>
                            <td style="width: 5%;display:none;">
                                自动ID
                            </td>
                            <td style="width: 3%; display:none;">
                                项目代码
                            </td>
                            <td style="width: 8%">
                                填报时间
                            </td>
                            <td style="width: 8%">
                                项目进度完成比例
                            </td>
                            <td style="width: 8%">
                                项目总投资额
                            </td>
                            <td style="width: 8%">
                                累计拨付总金额
                            </td>
                            <td style="width: 8%">
                                总投资完成比例
                            </td>
                            <td>
                                项目监控资料
                            </td>
                            <td style="width: 5%">
                                操作
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_xmccxc" runat="server" HeaderText="项目抽查巡查记录">
            <ContentTemplate>
                      <div style="text-align: left; padding:5px 10px; display:none;">
                        <a href="javascript:void(0)" onclick='loadTable_add("table_xmccxc",json_xmccxc,"ss_table_xmccxc")'>
                            增行</a> <a href="javascript:void(0)" onclick="tableJDdel('table_xmccxc',15);">删行</a></div>
            
               <div  uName="div_file" style="text-align: left;">
                    <table id="table_xmccxc" style="width:98%;text-align:center;" border="1" cellpadding="4" cellspacing="0"
                                bordercolor="#CCCCCC">
                        <tr style="background:#E9E9E9;">
                            <td style="width: 30px; height:30px;">
                                选择
                            </td>
                            <td style="width: 3%; display:none;">
                                自动ID
                            </td>
                            <td style="width: 8%;display: none;">
                                项目代码
                            </td>
                            <td style="width: 8%">
                                项目过程
                            </td>
                            <td style="width: 8%">
                                监管时间
                            </td>
                            <td style="width: 8%">
                                项目进度完成比例
                            </td>
                            <td style="width: 8%">
                                项目总投资额
                            </td>
                            <td style="width: 8%">
                                累计拨付总金额
                            </td>
                            <td style="width: 8%">
                                总投资完成比例
                            </td>
                            <td style="width: 8%">
                                监管人员
                            </td>
                            <td style="width: 8%">
                                监管地点
                            </td>
                            <td style="width: 8%">
                                监管内容
                            </td>
                            <td style="width: 8%">
                                监管意见
                            </td>
                            <td style="width: 5%;">
                                监管结论
                            </td>
                            <td>
                                监管资料
                            </td>
                            <td style="width: 5%">
                                操作
                            </td>
                        </tr>
                    </table>
                </div>
            
            </ContentTemplate>
        </cc1:TabPanel>--%>
        <cc1:TabPanel ID="Panel_xmsszl" runat="server" HeaderText="项目实施资料">
            <HeaderTemplate>
                项目实施资料
            </HeaderTemplate>
            <ContentTemplate>
                <div style="text-align: left; padding: 5px 10px;">
                    <a href="javascript:void(0)" onclick='loadTable_add("table_xmsszl",json_xmsszl,"xmss_5")'>
                        <img src="../../images/AddRow.png" /></a> <a href="javascript:void(0)" onclick="tableJDdel('table_xmsszl',3);"><img src="../../images/DelRow.png" /></a></div>
                <div uname="div_file" style="text-align: left;">
                    <div id="grid_xmsszl" style="height: 400px; overflow: auto; display: none;">
                    </div>
                    <table id="table_xmsszl" style="width: 98%; text-align: center;" border="1" bordercolor="#A3C0E8"
                        borderstyle="Solid" borderwidth="1px" gridlines="Both" cellpadding="4" cellspacing="0"
                        bordercolor="#cddbf0">
                        <tr style="background: #deecfd;">
                            <td style="display: none;">
                                自动ID
                            </td>
                            <td style="width: 30px; height: 30px; font-weight: bold; color: #15428b;">
                                选择
                            </td>
                            <td style="width: 200px; display: none;">
                                项目代码
                            </td>
                            <td style="width: 450px; font-weight: bold; color: #15428b;" colspan="2" align="center">
                                项目实施资料附件名称
                            </td>
                        </tr>
                    </table>
                    <div>
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_xcsgt" runat="server" HeaderText="现场施工图">
            <ContentTemplate>
                <div uname="div_file" style="text-align: left;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                事前现场施工图：
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                事中现场施工图：
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                事后现场施工图：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span style="width: 230px">
                                    <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" /></span>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span style="width: 230px">
                                    <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" /></span>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span style="width: 230px">
                                    <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="5">
                                现场施工资料上传：<span style="text-align: center;">
                                    <input type="button" name="upload" value="资料上传" />
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_gkgs" runat="server" HeaderText="公开公示">
            <ContentTemplate>
                <div uname="div_file" style="text-align: left;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                事前公示：
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                事中公示：
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                事后公示：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span style="width: 230px">
                                    <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" /></span>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span style="width: 230px">
                                    <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" /></span>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <span style="width: 230px">
                                    <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="5">
                                公开公示资料上传：<span style="text-align: center;">
                                    <input type="button" name="upload" value="资料上传" /><%--<input type="button" name="upload" value="资料上传" />--%>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>

    <script type="text/javascript">
        var json_xmsszl = "<%=json_xmsszl%>";
        var json_htgl = "<%=json_htgl%>";
        var json_htbggl = "<%=json_htbggl%>";
        //    var json_xmssjk="json_xmssjk";
        //    var json_xmccxc="<%=json_xmccxc%>";

        function PostLoadxmsszl(tableID, json, addLoop) {
            Loadxmsszl(tableID, json, addLoop);
        }
        function loadTable_add(tableID, data, loop) {
            loadTable_JD(tableID, eval(data)[0], loop);
        }
        $(document).ready(function () {
            try {
                PostLoadxmsszl('table_xmsszl', eval("<%=jsonData_xmsszl %>"), 'xmss_5');
        PostLoadxmsszl('table_htgl', eval("<%=jsonData_htgl %>"), 'ss_table_htgl');
        PostLoadxmsszl('table_htbggl', eval("<%=jsonData_htbggl %>"), 'ss_table_htbggl');
        //        PostLoadxmsszl('table_xmssjk',eval("<%=jsonData_xmssjk %>"),'ss_table_xmssjk');
        //PostLoadxmsszl('table_xmccxc',eval("<%=jsonData_xmccxc %>"),'ss_table_xmccxc');

        setHeight();
    } catch (e) { alert(e) }
    });
    </script>

</asp:Content>
