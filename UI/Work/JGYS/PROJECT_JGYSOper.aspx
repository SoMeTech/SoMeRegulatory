<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" inherits="Work_JGYS_PROJECT_JGYS" CodeBehind="PROJECT_JGYSOper.aspx.cs" title="项目竣工验收" enableEventValidation="false" stylesheettheme="Default" %>

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

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    

    <div style="text-align: center;">
        <table width="100%" border="0" style="text-align:left;">
            <tr>
                <td height="30" align="right">
                    上级指标文号 ：                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox   ID="lblPD_PROJECT_FILENO_PF" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                     <input type="hidden" id="txtPD_PROJECT_FILENO_PF" uid="txtPD_PROJECT_FILENO_PF"  runat="server" />
                    <asp:TextBox   ID="lblPD_PROJECT_CODE" runat="server" Width="200px"  style="display:none;"></asp:TextBox>                </td>
                <td height="30" align="right">&nbsp;</td>
                <td height="30" width="*" align="left">&nbsp;</td>
                <td height="30" align="right">                </td>
                <td height="30" width="*" align="left">                </td>
            </tr>
            <tr>
              <td height="30" style="width:130px;" align="right"> 项目年度 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_YEAR" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" align="right"> 项目名称 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_NAME" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" style="width:130px;" align="right"> 归口部门 ： </td>
              <td height="30" align="left"><asp:TextBox ID="lblPD_GK_DEPART" uid="lblPD_GK_DEPART" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                  <asp:TextBox ID="txtPD_GK_DEPART" uid="txtPD_GK_DEPART" runat="server" Width="200px" style="display:none;"></asp:TextBox>              </td>
            </tr>
            <tr>
              <td height="30" align="right"> 资金性质 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_FOUND_XZ" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" style="width:130px;" align="right"> 项目类别 ： </td>
              <td height="30" align="left"><asp:TextBox      ID="lblPD_PROJECT_TYPE" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td style="width:130px;" align="right">资金来源 ：</td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_ZJLY" runat="server" Width="200px" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
              <td style="width:130px; height:30px;" align="right">主管科局 ：</td>
              <td align="left"><asp:TextBox   ID="lblPD_PROJECT_ZGKJ" runat="server" Width="200px" Enabled="false"></asp:TextBox></td>
              <td height="30" align="right"> 是否乡镇直接管理 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_IFXZGL" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" align="right"> 项目建设状态 ： </td>
              <td height="25" align="left"><asp:TextBox   ID="lblPD_PROJECT_STATUS" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
            </tr>
            
            <tr>
              <td height="30" align="right"> 是否公示 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_IFGS" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" align="right"> 是否事前公示 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_IFGS_BEFORE" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" align="right"> 公示主体 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_OPEN_BODY" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
            </tr>
            
            <tr>
                <td height="30" align="right">
                    项目负责人 ：                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox   ID="lblPD_PROJECT_FZR" runat="server" Width="200px" Enabled="false"></asp:TextBox>                </td>
                <td height="30" align="right">
                    财务负责人 ：                </td>
                <td height="30" width="*" align="left">
                     <asp:TextBox   ID="lblPD_PROJECT_CWFZR" runat="server" Width="200px" Enabled="false"></asp:TextBox>                </td>
                <td height="30" align="right"> 受益人数 ： </td>
                <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_SYRS" runat="server" Width="200px" Enabled="false"></asp:TextBox>                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    开工日期 ：                </td>
                <td height="30" width="*" align="left">
                     <asp:TextBox   ID="lblPD_PROJECT_BEGIN_DATE" runat="server" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" Width="200px" Enabled="false"></asp:TextBox>                </td>
                <td height="30" align="right">
                    完工日期 ：                </td>
                <td height="30" width="*" align="left">
                      <asp:TextBox   ID="lblPD_PROJECT_END_DATE" runat="server" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" Width="200px" Enabled="false"></asp:TextBox>                </td>
                <td height="30" align="right">
                    项目建设时限 ：                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox   ID="lblPD_PROJECT_YEARS" runat="server" Width="200px" Enabled="false"></asp:TextBox>                </td>
            </tr>
            <tr>
              <td height="30" align="right"> 监管依据 ： </td>
              <td height="30" align="left"><asp:TextBox   ID="lblPD_PROJECT_FILENO_JG" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" align="right"> 所属乡镇： </td>
              <td height="30" align="left" ><asp:TextBox   ID="lblPD_PROJECT_COUNTRY" runat="server" Width="200px" Enabled="false"></asp:TextBox>              </td>
              <td height="30" align="right"></td>
              <td height="30" align="left"></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer11" runat="server" Width="100%" ActiveTabIndex="0"
        Height="300px" Visible="true">
        <!--项目概况-->
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="项目概况">
            <ContentTemplate>
                <table style="width: 100%; height: 200px; text-align: left;">
                    <tr>
                        <td style="text-align: right;">
                            项目建设地点：
                        </td>
                        <td colspan='5'>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_MONEY_ADDR" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目主要建设内容：
                        </td>
                        <td colspan='5'>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_CONTENT" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目用途：
                        </td>
                        <td colspan='5'>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_XMYT" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 130px;">
                            项目申报日期：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_INPUT_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报单位：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_INPUT_COMPANY"
                                runat="server" Width="200" CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报经办人：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_INPUT_MAN" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目批复日期：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_REPLY_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            项目批复单位：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_REPLY_COMPANY"
                                runat="server" Width="200" CssClass="label"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            项目批复经办人：
                        </td>
                        <td>
                            <asp:TextBox Enabled="false"  ID="lblPD_PROJECT_REPLY_MAN2" runat="server"
                                Width="200" CssClass="label"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <!--项目竣工验收-->
        <cc1:TabPanel ID="Panel_jgys" runat="server" closable="False" HeaderText="项目竣工验收">
            <ContentTemplate>
                <asp:Label ID="lblAUTO_NO_JGYS" runat="server" Visible="false" CssClass="label"></asp:Label>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right" style="height:40px;">
                            项目竣工日期：                        </td>
                        <td align="left">
                            <input ID="txtPD_PROJECT_COMPLETE_DATE" readonly="readonly" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" style="width:200px"  uid="txtPD_PROJECT_COMPLETE_DATE" runat="server" />                        </td>
                        <td align="right">
                            项目验收申请日期：                        </td>
                        <td align="left">
                            <input ID="txtPD_PROJECT_YSSQ_DATE" uid="txtPD_PROJECT_YSSQ_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox"  runat="server" style="width:200px;"  readonly="readonly" />                        </td>
                        <td align="right" style=" width: 130px; height:30px;">
                            项目验收日期：                        </td>
                        <td align="left">
                            <input ID="txtPD_PROJECT_YS_DATE" uid="txtPD_PROJECT_YS_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox"  runat="server"  style="width:200px;" readonly="readonly" />                        </td>
                    </tr>
                    <tr>
                      <td align="right" style=" width: 130px; height:30px;"> 项目验收单位： </td>
                      <td align="left"><asp:DropDownList ID="ddlPD_PROJECT_YS_COMPANY" uid="ddlPD_PROJECT_YS_COMPANY" runat="server"  disabled="disabled"  style="width:206px;"> </asp:DropDownList>                      </td>
                      <td align="right" style=" width: 130px; height:30px;"> 项目验收责任人： </td>
                      <td align="left"><asp:TextBox  ID="txtPD_PROJECT_YS_ZRR" uid="txtPD_PROJECT_YS_ZRR" runat="server"  style="width:200px;"></asp:TextBox>                      </td>
                        <td align="right" style=" width: 130px; height:30px;">&nbsp;</td>
                        <td align="left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="height:40px;">
                            项目验收人员名单：                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_YS_NAME" uid="txtPD_PROJECT_YS_NAME" runat="server" Width="100%"></asp:TextBox>                        </td>
                        <td align="left">&nbsp;</td>
                        <td align="left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="height:40px;">
                            项目验收意见：                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_YS_SUGGEST" uid="txtPD_PROJECT_YS_SUGGEST" runat="server" Width="100%"
                                Rows="3" TextMode="MultiLine"></asp:TextBox>                        </td>
                        <td align="right" style="height:40px;"> 项目验收结论： </td>
                        <td align="left"><asp:DropDownList ID="ddlPD_PROJECT_YS_RESULT" uid="ddlPD_PROJECT_YS_RESULT" runat="server" style="width:206px;">
                            <asp:ListItem Text="合格" Value="合格"></asp:ListItem>
                            <asp:ListItem Text="不合格" Value="不合格"></asp:ListItem>
                        </asp:DropDownList></td>
                    </tr>
                    
                    <tr>
                        <td align="right" style="height:40px;">
                            存在主要问题整改：                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_YS_CONDITION" uid="txtPD_PROJECT_YS_CONDITION" runat="server" Width="100%" Rows="3" TextMode="MultiLine"></asp:TextBox>                        </td>
                        <td align="left">&nbsp;</td>
                        <td align="left">&nbsp;</td>
                    </tr>
                </table>


            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="项目验收资料">
            <ContentTemplate>
                    <div uid='add_del_button' style="text-align: left; padding: 5px 10px;">
                        <a href="javascript:void(0)" onclick='loadTable_add("table_xmyszl",json_xmyszl,"xmss_5")'>
                            增行</a> <a href="javascript:void(0)" onclick="tableJDdel('table_xmyszl',3);">删行</a></div>
                <div id="div_file" uName="div_file">
                    <table id="table_xmyszl" style="width: 98%; text-align:center;" border="1" cellpadding="4" cellspacing="0"
                        bordercolor="#CCCCCC">
                        <tr style="background:#E9E9E9;">
                            <td style="display: none;">
                                自动ID
                            </td>
                            <td style="width: 50px; height:30px;">
                                选择
                            </td>
                            <td style="width: 200px; display: none;">
                                项目代码
                            </td>
                            <td colspan="2">
                                附件名称
                            </td>
                          <%--  <td style="width: 100px">
                                操作
                            </td>--%>
                        </tr>
                    </table>
                    <div>
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_xmpj" runat="server" closable="False" HeaderText="项目评价">
            <HeaderTemplate>
            </HeaderTemplate>
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr style="display: none;">
                        <td align="right"  style="height:40px; width:130px;">
                            自动序号 ：
                        </td>
                        <td align="left">
                            <asp:TextBox  ID="txtAUTO_NO_APPRAISE" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  style="height:40px; width:130px;">
                            项目评价日期 ：
                        </td>
                        <td align="left">
                            <input ID="txtPD_PROJECT_APP_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox"  runat="server" readonly="readonly" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  style="height:40px; width:130px;">
                            评价组织单位 ：
                        </td>
                        <td align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_APP_COMPANY" runat="server" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  style="height:40px; width:130px;">
                            评价参与单位 ：
                        </td>
                        <td align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_APP_COMPANY_LIST" runat="server"
                                Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  style="height:40px; width:130px;">
                            评价参与人员 ：
                        </td>
                        <td align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_APP_MAN_LIST" runat="server" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="display:none;"  style="height:40px; width:130px;">
                        <td align="right">
                            评价报告附件序号 ：
                        </td>
                        <td align="left">
                            <asp:TextBox  ID="txtPD_PROJECT_APPRAISE_FILENO" runat="server"
                                Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>

    <script type="text/javascript">
        var json_xmyszl = "<%=json_xmyszl%>";

        function PostLoadxmsszl(tableID, json, addLoop) {
            Loadxmsszl(tableID, json, addLoop);
        }
        function loadTable_add(tableID, data, loop) {
            loadTable_JD(tableID, eval(data)[0], loop);
        }
        function BindDateAll() {
            if (!$("input[id='ibtcontrol_ibtsave']").length <= 0) {
                BindDate("<%=txtPD_PROJECT_COMPLETE_DATE.ClientID%>");
            BindDate("<%=txtPD_PROJECT_YSSQ_DATE.ClientID%>");
            BindDate("<%=txtPD_PROJECT_APP_DATE.ClientID%>");
            BindDate("<%=txtPD_PROJECT_YS_DATE.ClientID%>");
        }
    }
    $(document).ready(function () {
        try {
            PostLoadxmsszl('table_xmyszl', eval("<%=jsonData_xmyszl %>"), 'xmss_5');
        BindDateAll();
    } catch (e) { alert(e) }
    });
    </script>

</asp:Content>
