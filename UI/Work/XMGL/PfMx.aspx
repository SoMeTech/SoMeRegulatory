<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" CodeBehind="PfMx.aspx.cs" inherits="Work_GL_PfMx" title="项目批复管理" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr" TagPrefix="uc1" %>
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
        <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>
    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
    </script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript">

        function findwindow(val, obj) {
            var webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&xz=01&company_code=true";
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ss = arr.split("~");
                    if (ss[2] == '')
                        ss[2] = 0;

                    obj.value = ss[1];
                    $("input[uid='txtPD_PROJECT_FILENO_PF']").get(0).value = ss[0];

                    $("input[uid='txtPD_PROJECT_MONEY_CZ_SJ_PF']").get(0).value = ss[2];
                    $("input[uid='txtPD_GK_DEPART']").get(0).value = ss[3];
                    $("input[uid='lblPD_GK_DEPART']").get(0).value = ss[4];
                }
            }
        }

        function Sum_sqzjze() {
            var sqtzze = document.getElementById('<%=txtPD_PROJECT_MONEY_TOTAL_PF.ClientID %>');
        var czzjze = document.getElementById('<%=txtPD_PROJECT_MONEY_CZ_TOTAL_PF.ClientID %>');
        var sj = document.getElementById('<%=txtPD_PROJECT_MONEY_CZ_SJ_PF.ClientID %>');
        var bj = document.getElementById('<%=txtPD_PROJECT_MONEY_CZ_BJ_PF.ClientID %>');
        var zc = document.getElementById('<%=txtPD_PROJECT_MONEY_ZC_PF.ClientID %>');
        var Otherzj = document.getElementById('<%=txtPD_PROJECT_MONEY_QT_PF.ClientID %>');
        if (sj.value != '' && bj.value != '')
            czzjze.value = parseFloat(sj.value) + parseFloat(bj.value);
        else
            czzjze.value = '';

        if (czzjze.value != '' && zc.value != '' && Otherzj.value != '')
            sqtzze.value = parseFloat(czzjze.value) + parseFloat(zc.value) + parseFloat(Otherzj.value);
        else
            sqtzze.value = '';

    }

    function getCursorPos(obj) {
        var rngSel = document.selection.createRange();//建立选择域
        var rngTxt = obj.createTextRange();//建立文本域
        var flag = rngSel.getBookmark();//用选择域建立书签
        rngTxt.collapse();//瓦解文本域到开始位,以便使标志位移动
        rngTxt.moveToBookmark(flag);//使文本域移动到书签位
        rngTxt.moveStart('character', -obj.value.length);//获得文本域左侧文本
        str = rngTxt.text.replace(/\r\n/g, '');//替换回车换行符
        return (str.length);//返回文本域文本长度
    }

    function myKeyDown(obj, oEvent, loop) {
        var k = oEvent.keyCode;
        //	alert(String.fromCharCode(oEvent.keyCode))
        if ((k == 8) || (k == 45) || (k == 46) || (k >= 48 && k <= 57))
        { }
        else {
            oEvent.returnValue = false;
        }
        //eval("var Res=/(.{"+getCursorPos(obj)+"})/g")
        //obj.value.replace(Res,'$1'+String.fromCharCode(oEvent.keyCode)),loop)
        //alert(obj.value.replace(Res,'$1'+String.fromCharCode(oEvent.keyCode)));
        var insertIndex = getCursorPos(obj);
        var objValue = obj.value.substring(0, insertIndex) + String.fromCharCode(oEvent.keyCode) + obj.value.substring(insertIndex)
        if (!_Number(objValue, loop))
            oEvent.returnValue = false;
    }
    //loop=0两位小数，否则无小数
    function _Number(ssn, loop) {
        var re;
        if (loop == 0)
            re = /^\-?[0-9]+\.?[0-9]{0,2}$/i;
        else
            //re=/^\-?[0-9]+\.?[0-9]*$/i;
            re = /^\-?[0-9]+$/i;
        if (ssn == '' || re.test(ssn))
            return true;
        else
            return false;
    }
    </script>

    <div style="text-align: center;">
        <table width="100%" border="0" style="text-align:left;">
            <tr>
                <td height="30" align="right">
                    上级指标文号 ：                </td>
                <td height="30" width="*" align="left">
                    <asp:TextBox   ID="lblPD_PROJECT_FILENO_PF" runat="server" Width="200px" rdonly=1 onclick="javascript:findwindow('open_pd_quotaAddMoney',this);"></asp:TextBox>
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
                     <asp:TextBox   ID="lblPD_PROJECT_BEGIN_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>                </td>
                <td height="30" align="right">
                    完工日期 ：                </td>
                <td height="30" width="*" align="left">
                      <asp:TextBox   ID="lblPD_PROJECT_END_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>                </td>
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
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="2" Visible="true">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="项目概况">
            <ContentTemplate>
                <table cellpadding="4" style="width: 100%;">
                    <tr>
                        <td height="30" style="text-align: right;">
                            项目建设地点：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox   ID="lblPD_PROJECT_MONEY_ADDR" runat="server" Width="200px" Enabled="false"></asp:TextBox>                         
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align:top;">
                            项目主要建设内容：
                        </td>
                        <td colspan='5' style="text-align: left; height:80px">
                           <asp:TextBox   ID="lblPD_PROJECT_CONTENT" runat="server" Width="80%" Height="70px"
                                TextMode="MultiLine" Enabled="false"></asp:TextBox>                         
                        </td>
                    </tr>
                    <tr style="line-height:50px">
                        <td style="text-align: right; vertical-align:top;">
                            项目用途：
                        </td>
                        <td colspan='5' style="text-align: left;">
                             <asp:TextBox   ID="lblPD_PROJECT_XMYT" runat="server" Width="80%" Height="50px" Enabled="false"></asp:TextBox>                          
                        </td>
                    </tr>
                    <tr style="line-height:30px">
                        <td style="text-align: right;width:130px;">
                            项目申报日期：
                        </td>
                        <td style="text-align: left;">
                             <asp:TextBox   ID="lblPD_PROJECT_INPUT_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>                         
                        </td>
                        <td style="text-align: right;width:130px;">
                            项目申报单位：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="lblPD_PROJECT_INPUT_COMPANY" runat="server" Width="200px" Enabled="false"></asp:TextBox> 
                        </td>
                        <td style="text-align: right;width:130px;">
                            项目申报经办人：
                        </td>
                        <td style="text-align: left;">
                             <asp:TextBox   ID="lblPD_PROJECT_INPUT_MAN" runat="server" Width="200px" Enabled="false"></asp:TextBox> 
                         </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目批复日期：
                        </td>
                        <td style="text-align: left;">
                              <asp:TextBox   ID="lblPD_PROJECT_REPLY_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            项目批复单位：
                        </td>
                        <td style="text-align: left;">
                           <asp:TextBox   ID="lblPD_PROJECT_REPLY_COMPANY" runat="server" Width="200px" Enabled="false"></asp:TextBox> 
                        </td>
                        <td style="text-align: right;">
                            项目批复经办人：
                        </td>
                        <td style="text-align: left;">
                             <asp:TextBox   ID="lblPD_PROJECT_REPLY_MAN2" runat="server" Width="200px" Enabled="false"></asp:TextBox> 
                        </td>
                    </tr>
                </table>
            
            
        </ContentTemplate>
        
</cc1:TabPanel>
        <cc1:TabPanel ID="Panel_xmtzsq" runat="server" HeaderText="项目投资申请">
            <ContentTemplate>
                <table style="width: 100%; text-align: left;">
                    <tr>
                        <td style="text-align: right; height:30px; width:130px;">
                            申请投资总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPD_PROJECT_MONEY_TOTAL" runat="server" Width="200" CssClass="label" 
                                ReadOnly="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            申请财政资金总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPD_PROJECT_MONEY_CZ_TOTAL" runat="server" Width="200" CssClass="label"
                                 ReadOnly="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;申请上级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPD_PROJECT_MONEY_CZ_SJ" runat="server" Width="200" CssClass="label"
                                ReadOnly="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;申请本级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPD_PROJECT_MONEY_CZ_BJ" runat="server" Width="200" CssClass="label"
                                ReadOnly="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            申请自筹资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPD_PROJECT_MONEY_ZC" runat="server" Width="200" CssClass="label"
                                ReadOnly="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            申请其他资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPD_PROJECT_MONEY_QT" runat="server" Width="200" CssClass="label"
                                ReadOnly="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            
            
        </ContentTemplate>
        
</cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="项目投资批复">
            <ContentTemplate>
                <table style="width: 100%; text-align: left;">
                    <tr>
                        <td style="text-align: right; width:130px;height:30px;">
                            批复投资总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_TOTAL_PF" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            批复财政资金总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_TOTAL_PF" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;height:30px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;批复上级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_SJ_PF" uid='txtPD_PROJECT_MONEY_CZ_SJ_PF' runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:30px; text-align: right;">
                            &nbsp;&nbsp;&nbsp;&nbsp;批复本级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_BJ_PF" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            批复自筹资金：
                        </td>
                        <td style="text-align: left;height:30px;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_ZC_PF" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:30px;text-align: right;">
                            批复其他资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_QT_PF" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            
            
        </ContentTemplate>
        
</cc1:TabPanel>
        <cc1:TabPanel ID="Panel_xmsbzl" runat="server" HeaderText="项目申报资料">
            <ContentTemplate>
                   <div style="text-align: left; padding:5px 10px;">
                        <a href="javascript:void(0)" onclick='alert(getfiledName().value)' style="display:none;">getName</a>
                        <a href="javascript:void(0)" onclick='loadTable_add()' style="display:none;"><img src="../../images/AddRow.png" /></a>
                        <a href="javascript:void(0)" onclick="tableJDdel('table_xmsbzl',3);" style="display:none;"><img src="../../images/DelRow.png" /></a></div>
                 <div uName="div_file">
                    <table id="table_xmsbzl" style="width:98% ;text-align:center;" border="1" cellpadding="4" cellspacing="0"
                                bordercolor="#CCCCCC">
                        <tr style="background:#E9E9E9;">
                            <td style="display: none;">
                                自动ID
                            </td>
                            <td style="width: 50px;height:30px;">
                                序号
                            </td>
                            <td style="width: 200px;display: none">
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
                </div>
            
            
        </ContentTemplate>
        
</cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="项目批复资料">
            <ContentTemplate>
                      <div style="text-align: left; padding:5px 10px;">
                        <a href="javascript:void(0)" onclick='loadTable_add()'><img src="../../images/AddRow.png" /></a>
                        <a href="javascript:void(0)" onclick="tableJDdel('table_xmpfzl',3);"><img src="../../images/DelRow.png" /></a></div>
                 <div uName="div_file">
                    <table id="table_xmpfzl" style="width:98% ;text-align:center;" border="1" cellpadding="4" cellspacing="0"
                                bordercolor="#CCCCCC">
                        <tr style="background:#E9E9E9;">
                            <td style="display: none;">
                                自动ID
                            </td>
                            <td style="width: 50px; height:30px;">
                                序号
                            </td>
                            <td style="width: 200px;display: none">
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
    </cc1:TabContainer>
    <script type="text/javascript">
        function PostLoadxmsszl(tableID, json, addLoop) {
            Loadxmsszl(tableID, json, addLoop);
        }
        function loadTable_add() {
            loadTable_JD("table_xmpfzl", eval("<%=jsonStrNull%>")[0], 'xmss_5');
    }

    $(document).ready(function () {
        try {
            PostLoadxmsszl("table_xmsbzl", eval("<%=jsonStr_sb %>"), 'xmpf_4');
        PostLoadxmsszl("table_xmpfzl", eval("<%=jsonStr_pf %>"), 'xmss_5');

        setHeight();
        Sum_sqzjze();
    } catch (e) { alert(e) }
    });
    </script>
</asp:Content>
