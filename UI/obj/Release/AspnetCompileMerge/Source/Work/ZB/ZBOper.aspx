<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" validaterequest="false" CodeBehind="ZBOper.aspx.cs" inherits="Work_ZB_ZBOper" title="指标信息" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.css") %>"
        type="text/css" rel="stylesheet" />
    <script src="../../jss/jquery-1.4.2.min.js" type="text/javascript"></script>
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
        type="text/css" />   <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>
 
   
    <link href="../../css/QiPao.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />

    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    <script src="ZB.js" type="text/javascript"></script>
 
    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />


    
    <asp:Label runat="server" ID="lblAUTO_ID" Visible="false"></asp:Label>

    <script type="text/jscript">
        var pd_quota_zbxdzhID = "<%=txtPD_QUOTA_ZBXDZH.ClientID %>";
        function chg() {
            var cot = document.getElementById("<%=ddlzjly.ClientID %>").value;
          var ddlzgkj = document.getElementById("<%=ddlzgkj.ClientID %>");
          if (cot == "01") {
              ddlzgkj.value = "-1";
              ddlzgkj.options[0].text = "";
              ddlzgkj.disabled = true;
              $("input[uid='txtPD_QUOTA_ZGBM']").get(0).value = '乡镇人民政府';
              document.getElementById("<%=ddlzgkj.ClientID %>").style.backgroundColor = "#e9e9e9";

      }
      else {
          ddlzgkj.disabled = false;
          ddlzgkj.value = "-1";
          ddlzgkj.options[0].text = " ==选择科局== ";
          document.getElementById("<%=ddlzgkj.ClientID %>").style.backgroundColor = "#ffffff";
          document.getElementById("<%=ddlzgkj.ClientID %>").style.color = "#000000";
      }

  }
  function openLog() {
      window.open('<%=LogUrl %>', '', 'toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no,left=150,top=50');
     }

     function findwindow(val, obj) {
         var webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&ye=" + document.getElementById("<%=ddlPD_YEAR.ClientID %>").value + "&branch=" + $("input[uid='branch']").get(0).value;
           //alert(webFileUrl);
           //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
           var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
           _xmlhttp.open("POST", webFileUrl, false);
           _xmlhttp.send("");

           var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
           //alert(arr);
           if (arr != null && arr != "false") {
               helpMess(arr, obj);
           }
       }


       function helpMess(val, num) {
           if (val.indexOf("~") > 0) {
               ss = val.split("~");
               if (num == "1") {
                   document.getElementById("<%=txtPD_QUOTA_BASIS_JG.ClientID %>").value = ss[1];
                }
                else if (num == "4") {
                    document.all['<%=txtPD_QUOTA_GLLX.ClientID %>'].value = ss[1].split('-')[1];
                    document.all['<%=hgl.ClientID %>'].value = ss[1].split('-')[1];
                }
                else if (num == "5") {
                    document.all['<%=txtPD_QUOTA_JJLX.ClientID %>'].value = ss[1].split('-')[1];
                    document.all['<%=hjj.ClientID %>'].value = ss[1].split('-')[1];
                }
                else if (num == "6") {
                    windowFull();
                    window.location.href = "ZBOper.aspx?CreatePK=" + ss[0] + "&PiCi=" + ss[4];
                    return false;
                }
    }
}




    </script>

    <%--
    <script type="text/javascript">
		function formatItem(row){
		   
			var s = '<span style="font-weight:bold">' + row.指标文号 + '</span><br/>' +
					'<span style="color:#888">' + row.PK + '</span>';
			return s;
		}
    </script>--%>
    <div class="container" id="D_ShowText" style="position: absolute;  top: 1px; left: 1px;
        display: none;">
        <div class="content">
            <br />
            点击“放大镜”可参照指标结余库中选择生成</div>
        <s><i></i></s>
    </div>
    <input type="hidden" runat="server" id="hgl" />
    <input type="hidden" runat="server" id="hjj" />
    <div id="top1" style="text-align: left; margin-top: 10px;">
        <table width="100%">
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    指标文号 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_ZBWH" uid="txtPD_QUOTA_ZBWH" QiPao='true' runat="server" Width="178px" _Width="175px"
                        Height="17px"  Style="border-right-style: none; float: left;" onblur="t_change_zbwh(this)"></asp:TextBox>
                    <img  id="imgSearch" runat="server" class="search-img" src="../../jquery.easyui/css/images/search.png" style="float: left; _height:20px; margin-left: -3px;
                        cursor: pointer;" onclick="findwindow('ZhiBiaoJYK','6');" />
                    <span style="color: Red">*</span>
                    <input type="hidden" id="txtPD_QUOTA_CODE" uid="txtPD_QUOTA_CODE" runat="server"
                        style="display: none;" />
                    <div id="div_showZBK" runat="server">
                        <%-- <a href="###" onclick="findwindow('ZhiBiaoJYK','6');">从指标结余库中选择</a>--%>
                    </div>
                    <input type="hidden" id="PD_QUOTA_PICI" uid="PD_QUOTA_PICI" runat="server" value="1" />
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    文件名称 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_NAME" uid="txtPD_QUOTA_NAME" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    文件年度 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_YEAR" uid="ddlPD_YEAR" runat="server" Width="206px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 30px;">
                    来文机关 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="txtPD_QUOTA_LWJG" runat="server" Width="206px">
                        <asp:ListItem Value="0">省</asp:ListItem>
                        <asp:ListItem Value="1">市</asp:ListItem>
                        <asp:ListItem Value="2">县</asp:ListItem>
                        <asp:ListItem Value="3">乡</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtPD_QUOTA_LWJG_NAME" runat="server" Visible="false" Width="200px"
                        rdonly="1" onclick="javascript:findwindow('XiangZhen',this);"></asp:TextBox>
                    <%--  <asp:TextBox ID="txtPD_QUOTA_LWJG" Text="11" runat="server" Width="200px" CssClass="noneDisplay"></asp:TextBox>--%>
                </td>
                <td align="right">
                    预算类型：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_QUOTA_IFUP" uid="ddlPD_QUOTA_IFUP" runat="server" Width="206px"
                        disabled="disabled" Visible="false">
                    </asp:DropDownList>
                     <asp:DropDownList ID="ddlPD_QUOTA_YSLX" runat="server" Width="206px">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    资金性质 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_QUOTA_ZJXZ" uid="ddlPD_QUOTA_ZJXZ" onchange="chglx()"
                        runat="server" Width="206px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="bzid" style="display: none">
                <td align="right" style="height: 30px;">
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
                    补助人数 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_BASIS" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 30px;">
                    发文日期 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_FWDATA" uid="txtPD_QUOTA_FWDATA"  class="Wdate"  onclick="WdatePicker({firstDayOfWeek:1})" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <%-- <input type="button" value="查询" id="btn" />--%>
                </td>
               
<%--                 <td align="right">
                    资金来源：
                </td>
                <td align="left" style="z-index:0;">
                    <asp:DropDownList ID="ddlzjly" uid="ddlzjly" runat="server" onchange="chg()" Width="206px">
                        <asp:ListItem Value="01">财政部门直接下达</asp:ListItem>
                        <asp:ListItem Value="02">财政与主管部门共同下达</asp:ListItem>
                        <asp:ListItem Value="03">主管部门直接下达</asp:ListItem>
                    </asp:DropDownList>
                </td>--%>
                                <td align="right">
                    资金使用单位 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_COMPANY" uid="txtPD_QUOTA_COMPANY" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    监管依据 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_BASIS_JG" runat="server" Width="200px" rdonly="1" onclick="javascript:findwindow('FG','1');"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    指标额度 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_MONEY_TOTAL" uid="txtPD_QUOTA_MONEY_TOTAL" runat="server"
                        Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>元
                </td>
                <td align="right">
                    归口部门 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_QUOTA_DEPART" runat="server" Width="206px">
                    </asp:DropDownList>
                </td>
                <td align="right" style="height: 30px;">
                    指标下达总额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_ZBXDZH" uid="txtPD_QUOTA_ZBXDZH" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                    <span style="color: Red">*</span>元
                </td>
            </tr>
            <tr>
                <td align="right">
                    财政资金用途：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_ZBYT" uid="txtPD_QUOTA_ZBYT" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    功能分类科目：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_GLLX" uid="txtPD_QUOTA_GLLX" runat="server" Width="200px"
                        rdonly="1" onclick="javascript:findwindow('GLLX','4');"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="height: 30px;">
                    经济分类科目：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_JJLX" uid="txtPD_QUOTA_JJLX" runat="server" Width="200px"
                        rdonly="1" onclick="javascript:findwindow('JJLX','5');"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
<%--                <td align="right">
                    资金使用单位 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_COMPANY" uid="txtPD_QUOTA_COMPANY" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>--%>
                 <td align="right">
                    资金来源：
                </td>
                <td align="left" style="z-index:0;">
                    <asp:DropDownList ID="ddlzjly" uid="ddlzjly" runat="server" onchange="chg()" Width="206px">
                        <asp:ListItem Value="01">财政部门直接下达</asp:ListItem>
                        <asp:ListItem Value="02">财政与主管部门共同下达</asp:ListItem>
                        <asp:ListItem Value="03">主管部门直接下达</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    主管科局：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlzgkj" uid="ddlzgkj" runat="server" Width="206px" onchange="addZGBM(this)" OnSelectedIndexChanged="ddlzgkj_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" style="height: 30px;">
                    项目主管部门：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_ZGBM" uid="txtPD_QUOTA_ZGBM" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    监管要求：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_JGYQ" uid="txtPD_QUOTA_JGYQ" runat="server" Width="200px"
                        TextMode="MultiLine" Rows="2"></asp:TextBox><span style="color: Red"> *</span>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    指标批次：
                </td>
                <td lign="left">
                    <asp:TextBox ID="lblPD_QUOTA_PICI" uid="lblPD_QUOTA_PICI" runat="server" Width="200px" Enabled="false" ></asp:TextBox>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    结余额度：
                </td>
                <td lign="left">
                    <asp:TextBox ID="lbl_MONEY" uid="lbl_MONEY" runat="server" Width="200px" rdonly="1" Enabled="false" ></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
                <td align="right" style="width: 130px; height: 30px;">
                    预算类型：
                </td>
                <td lign="left">
                    <asp:DropDownList ID="ddlPD_QUOTA_YSLX" runat="server" Width="206px">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                </td>
                <td lign="left">
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                </td>
                <td lign="left">
                </td>
            </tr>--%>
            <tr >
                <td colspan='6' align="left">
                    <table runat="server" id="tr_wjzl">
                        <tr>
                            <td align="right" style="width: 125px; height: 30px;">
                                文件资料 ：
                            </td>
                            <td align="left" id="wj" rowspan="5">
                                <%-- <asp:FileUpload ID="myFile" Style="width: 170px;" type="file" name="myFile" runat="server" />
                                <asp:Button ID="Button1" OnClick="UploadFile" runat="server" Text="上传"></asp:Button>
                                <asp:TextBox ID="txtPD_QUOTA_FILE" runat="server" Width="170px" Visible="false"></asp:TextBox>--%>
                                <%-- <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" Visible="false" />--%>
                                <table>
                                    <tr>
                                        <td>
                                            <%--          <div style="border:thin solid #ccc; width:200px; height:21px;   float:left;"></div>--%>
                                            <div id='upfile10000' style='border: thin solid #899aa1; width: auto; height: 25px;'
                                                onmouseover="MouseOnRowIndex=10000">
                                                <div id='ShowDIV10000' class="filetxt">
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            
                                            <div class="fileUpArea" onmouseover="MouseOnRowIndex=10000" style="margin-bottom: -10px;">
                                                <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                                    columnindex='0' rowindex='10000' onmouseover="MouseOnRowIndex=10000" /></div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="height: 30px;">
                    项目审核状态 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_PROJ_STATUS" runat="server" Width="206px" Visible="false">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    上一次审核状态:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_PROJ_LAST_AUDIT_STATUS" runat="server" Width="206px"
                        Visible="false">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    是否退回 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_IS_RETURN" runat="server" Width="206px" Visible="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="height: 30px;">
                    是否立项:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_ISOUT_QUOTA" runat="server" Width="206px" Visible="false">
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
    <cc1:TabContainer ID="TabContainer11" runat="server" ActiveTabIndex="0" Height="350px"
        Visible="true">
        <%--
        <cc1:TabPanel ID="Panel_JBXX" runat="server" HeaderText="基本信息">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            传递单位：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_PASS_COMPANY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 130px; height: 30px;">
                            接收单位：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_ACCEPT_COMPANY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 130px; height: 30px;">
                            下发单位：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_UP_COMPANY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            传递部门：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_PASS_DEPART" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            接收部门：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_ACCEPT_DEPART" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            下发部门：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_UP_DEPART" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            传递时间：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_PASS_DATE" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            接收时间：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_ACCEPT_DATE" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            下发时间：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_UP_DATE" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            传递人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_PASS_MAN" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            接收人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_ACCEPT_MAN" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            下发人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_UP_MAN" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            是否已传递：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_IFPASS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            是否已接收：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_IFLLYQS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            是否已下发：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_ISUP" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            是否乡镇已签收：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ddlPD_QUOTA_IFXZQS" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            是否乡镇已回执：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="PD_QUOTA_IFXZHZ" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>--%>
        <!--1-->
        <cc1:TabPanel ID="Panel_xzxx" runat="server" HeaderText="分配方案">
            <HeaderTemplate>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                分配方案 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </HeaderTemplate>
            <ContentTemplate>
                <div id='div_PasteData' uid='div_PasteData' onkeydown="KeyDown('table_xzxx')">
                    <div style="text-align: left; padding: 5px 10px;">
                        <a href="javascript:void(0)" id="table_xzxx_add" onclick='loadTable_add("table_xzxx",json_xzxx,"bz_xzxx")'
                            style="display: none;">增行</a> <a href="javascript:void(0)" id="table_xzxx_del" onclick="tableJDdel('table_xzxx',5);"
                                style="display: none;">删行</a> <a>注：数据先从Excel复制后按Ctrl+V进行数据快速录入</a></div>
                    <div uname="div_file">
                        <table id="table_xzxx" style="width: 500px; text-align: center;" border="1" cellpadding="0"
                            cellspacing="0" bordercolor="#CCCCCC">
                            <tr style="background: #E9E9E9;">
                                <td style="display: none;">
                                    自动ID
                                </td>
                                <td style="display: none;">
                                    选择
                                </td>
                                <td style="display: none;">
                                    项目编码
                                </td>
                                <td style="width: 200px; height: 30px;">
                                    乡镇名称
                                </td>
                                <td style="width: 300px">
                                    下达金额(元)
                                </td>
                                <td style="display: none;">
                                    附件名称
                                </td>
                                <td style="display: none;">
                                    操作
                                </td>
                                <td style="display: none;">
                                    是否已签收
                                </td>
                                <td style="display: none;">
                                    签收人
                                </td>
                                <td style="display: none;">
                                    是否已回执
                                </td>
                                <td style="display: none;">
                                    回执人
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <script type="text/javascript">
                    chglx();
                    function chglx() {
                        var cot = document.getElementById("<%=ddlPD_QUOTA_ZJXZ.ClientID %>").value;
          if (cot == "01")
              document.getElementById("bzid").style.display = "none";
          else
              document.getElementById("bzid").style.display = "";
      }


                </script>

            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <div>
        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
    </div>
    <input type="hidden" id="buttonTxt" uid="buttonTxt" runat="server" />
    <input type="hidden" id="IsQianShou" uid="IsQianShou" runat="server" />
    <input type="hidden" id="json_xzxx" uid="json_xzxx" runat="server" />
    <input type="hidden" id="json_xzxxData" uid="json_xzxxData" runat="server" />
    <input type="hidden" id="json_btData" uid="json_btData" runat="server" />
    <input type="hidden" id="serverPK" uid="serverPK" runat="server" />
    <input type="hidden" id="serverXFPK" uid="serverXFPK" runat="server" />
    <input type="hidden" id="branch" uid="branch" runat="server" />
    <input type="hidden" id="LoginCompany" uid="LoginCompany" runat="server" />
</asp:Content>
