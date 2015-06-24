<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" validaterequest="false" CodeBehind="BzMx.aspx.cs" inherits="Work_BZ_projBzMx" title="补助性项目登记" enableEventValidation="false" stylesheettheme="Default" %>

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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <script src="BzMx.js" type="text/javascript"></script>
    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径    
    </script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
        

    <script type="text/javascript">
        function findwindow(val, obj) {

            var webFileUrl;
            switch (val) {
                case "FG":
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                    break;
                case "proj_bzwh":
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&xz=" + document.getElementById("<%=ddlPD_FOUND_XZ.ClientID %>").value;
                break;
            case "INSPECTION_BTFFID":
                webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                break;
            case "open_pd_quotaAddMoney":
                webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&xz=02&company_code=true";
                break;
        }
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
                switch (val) {
                    case "FG":
                        if (obj == 1)
                            $("input[uid='txtPD_PROJECT_FILENO_JG']").eq(0).val(ss[1]);
                        else if (obj == 2)
                            $("input[uid='txtPD_PROJECT_BZYJ']").eq(0).val(ss[1]);

                        break;
                    case "proj_bzwh":
                        document.getElementById("<%=txtPD_PROJECT_FILENO_ZB.ClientID %>").value = ss[1].split("-")[0];
                            break;
                        case "INSPECTION_BTFFID":
                            var BTFFID = $("input[uid='BTFFID" + obj.hiddenNum + "']").get(0);
                            BTFFID.value = BTFFID.value + "," + ss[0];
                            obj.value = ss[1];
                            break;
                        case "open_pd_quotaAddMoney":
                            $("input[uid='txtPD_PROJECT_FILENO_ZB']").get(0).value = ss[0];
                            $("input[uid='lblPD_PROJECT_FILENO_ZB']").get(0).value = ss[1];
                            $("select[uid='ddlPD_GK_DEPART']").get(0).value = ss[3];
                    }
                }
            }
        }

        function findcompany(obj) {
            $.ajax({
                url: "publicBll.ashx?loop=xmsb&value=" + obj.value + "&name=" + obj.id,
                type: "post",
                dataType: "text",
                error: function (e) { alert("load database error !!"); },
                success: function (msg) {//msg为返回的数据，在这里做数据绑定
                    if (msg != null && Trim(msg) != "") {
                        alert(msg);
                        obj.value = "";
                        obj.focus();
                    }
                }
            });

            //         if(this.value != "")
            //         {
            //            Work_projectGL_projSbMx.ExistsCodeAndName(obj.value,obj.id, ExistsCodeAndName_callback);
            //         }
        }

        function ExistsCodeAndName_callback(res) {
            if (res.value != null) {
                var value = res.value.split('|')[1]
                alert(value);
                document.getElementsByName(res.value.split('|')[0])[0].value = "";
                document.getElementsByName(res.value.split('|')[0])[0].focus();
            }
        }
        function project_type_change(obj) {
            $("input[uid='txtPD_PROJECT_NAME']").eq(0).val(obj.options[obj.selectedIndex].text);
        }
    </script>

    <div style="text-align: center; margin-top:10px;" >
        <table style="width:100%;">
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    上级指标文号 ：
                </td>
                <td align ="left">
                    <asp:TextBox   ID="lblPD_PROJECT_FILENO_ZB" uid="lblPD_PROJECT_FILENO_ZB"  runat="server" Width="200px" rdonly=1 onclick="javascript:findwindow('open_pd_quotaAddMoney',3);"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <input type="hidden" id="txtPD_PROJECT_FILENO_ZB" uid="txtPD_PROJECT_FILENO_ZB"  runat="server" />
                </td>
                <td align ="right">
                    项目名称 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_NAME" uid="txtPD_PROJECT_NAME" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <input type="text" id="lblPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server" style="width:200px; display:none;" />
                </td>
                <td height="30" align="right">
                </td>
                <td height="30" align="left">
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    项目年度 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_YEAR" runat="server" Width="205px">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td align ="right" style="width:130px; height:30px;">
                    项目类别 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_TYPE" runat="server" Width="205px" onchange="project_type_change(this)">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td align ="right" style="width:130px; height:30px;">
                    归口部门 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_GK_DEPART" uid="ddlPD_GK_DEPART" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    资金性质 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_FOUND_XZ" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
                <td align ="right">
                    补助依据 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZYJ" uid="txtPD_PROJECT_BZYJ" runat="server" Width="200px"  rdonly=1 onclick="javascript:findwindow('FG',2);"></asp:TextBox>
                </td>
                <td align ="right">
                    监管依据 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_FILENO_JG" uid="txtPD_PROJECT_FILENO_JG" runat="server" Width="200px" rdonly=1 onclick="javascript:findwindow('FG',1);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    是否一卡通发放 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFFF" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
                <td align ="right">
                    补助范围 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZFW" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align ="right">
                    补助对象 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZDX" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    补助数量 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZNUM" runat="server" Width="200px" onKeyPress="myKeyDown(this,event,2)"></asp:TextBox>
                </td>
                <td align ="right">
                    补助标准 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZSTAND_NUM" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align ="right">
                    补助金额 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZMONEY" runat="server" Width="200px" onKeyPress="myKeyDown(this,event,0)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    是否公示 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFGS" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
                <td align ="right">
                    是否事前公示 ：
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFGS_BEFORE" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
                <td align ="right">
                    公示主体 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_OPEN_BODY" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                    要求发放时间 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_BZFF_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td align ="right">
                    实际发放时间 ：
                </td>
                <td align ="left">
                    <asp:TextBox ID="txtPD_PROJECT_SJFF_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td align ="right">
                </td>
                <td align ="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_STATUS" runat="server" Width="200px" Visible="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align ="right" style="width:130px; height:30px;">
                </td>
                <td align ="left">
                </td>
                <td align ="right">
                    &nbsp;
                </td>
                <td align ="left">
                    &nbsp;
                </td>
                <td align ="right">
                    &nbsp;
                </td>
                <td align ="left">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0" Visible="true">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="基本信息">
            <ContentTemplate>
                <table  style="width:100%;">
                    <tr>
                        <td align ="right" style="width:130px; height:30px;">
                            监管要求 ：
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtPD_PROJECT_JGYQ" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td align ="right">
                            &nbsp;
                        </td>
                        <td align ="left">
                            &nbsp;
                        </td>
                        <td align ="right">
                            &nbsp;
                        </td>
                        <td align ="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align ="right" style="width:130px; height:30px;">
                            监管记录 ：
                        </td>
                        <td align ="left" colspan="5">
                            <asp:TextBox ID="txtPD_PROJECT_JGJL" runat="server" Width="93%" Height="60px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align ="right" style="width:130px; height:30px;">
                            监管结论 ：
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtPD_PROJECT_JG_RESULT" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td align ="right">
                            &nbsp;
                        </td>
                        <td align ="left">
                            &nbsp;
                        </td>
                        <td align ="right">
                            &nbsp;
                        </td>
                        <td align ="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align ="right" style="width:130px; height:30px;">
                            项目申报日期 ：
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align ="right" style="width:130px; height:30px;">
                            项目申报单位 ：
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_COMPANY" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align ="right" style="width:130px; height:30px;">
                            项目申报经办人 ：
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_MAN" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel><%--
        <cc1:TabPanel ID="Panel_jgxx" runat="server" HeaderText="监管信息">
            <ContentTemplate> 
                      <div style="text-align: left; padding:5px 10px; display:none;">
                        <a href="javascript:void(0)" onclick='loadTable_add("table_BzGGXX",json_BzGGXX,"bz_table_BzGGXX")'>
                            <img src="../../images/AddRow.png" /></a> <a href="javascript:void(0)" onclick="tbdel('table_BzGGXX');"><img src="../../images/DelRow.png" /></a></div>
                 <div uName="div_file">
                    <table id="table_BzGGXX" style="width:148%" border="1" cellpadding="4" cellspacing="0"
                                bordercolor="#CCCCCC">
                        <tr style="background:#E9E9E9;">
                            <td style="width: 2%; height:30px;">
                                选择
                            </td>
                            <td style="width: 6%;display: none;">
                                自动ID
                            </td>
                            <td style="width: 6%;display: none;">
                                项目编码
                            </td>
                            <td style="width: 3%">
                                项目过程
                            </td>
                            <td style="width: 5%">
                                监管时间
                            </td>
                            <td style="width: 6%">
                                监管人员
                            </td>
                            <td style="width: 6%">
                                监管地点
                            </td>
                            <td style="width: 6%">
                                监管内容
                            </td>
                            <td style="width: 6%">
                                监管意见
                            </td>
                            <td style="width: 6%">
                                监管结论
                            </td>
                            <td style="width: 6%">
                                监管资料
                            </td>
                            <td style="width: 6%">
                                农户名称
                            </td>
                            <td style="width: 6%">
                                身份证号码
                            </td>
                            <td style="width: 6%">
                                补贴数量
                            </td>
                            <td style="width: 6%">
                                补贴标准
                            </td>
                            <td style="width: 6%">
                                补贴金额
                            </td>
                            <td style="width: 6%">
                                发放账号
                            </td>
                            <td>
                                农户家庭住址
                            </td>
                            <td style="width: 5%;">
                                对应发放记录
                            </td>
                        </tr>
                    </table>
                    <div style="width:150%;"></div>
                </div>--%>
                <%--
                <div style="text-align: left;">
                    <asp:LinkButton ID="lbtnAdd_jgxx" runat="server" Width="80px" OnClick="lbtnAddRow_Click">添加行</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDel_jgxx" runat="server" OnClick="btnDeleteRow_Click" OnClientClick="return confirm('确定要删除选中行吗？');">删除选中行</asp:LinkButton>
                </div>
                <yyc:SmartGridView ID="gvResult_jgxx" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="AUTO_NO"
                    AllowSorting="true"  OnRowCommand="gvResult_RowCommand"
                    OnSorting="gvResult_Sorting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <div style="text-align: center; width: 100%;">
                                    <asp:CheckBox ID="CheckBoxF" runat="server" />
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxNode" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                自动ID</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="AUTO_NO" Text='<%#Bind("AUTO_NO") %>' Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                项目编码</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_PROJECT_CODE" Text='<%#Bind("PD_PROJECT_CODE") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                项目过程</HeaderTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlPD_INSPECTION_PROCESS" runat="server" Width="200px">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_PROCESS"  Text='<%#Bind("PD_INSPECTION_PROCESS") %>' Width="100%"></asp:TextBox>		
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管时间</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_DATE" Text='<%#Bind("PD_INSPECTION_DATE") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管人员</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_MANS" Text='<%#Bind("PD_INSPECTION_MANS") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管地点</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_ADDR" Text='<%#Bind("PD_INSPECTION_ADDR") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管内容</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_CONTENT" Text='<%#Bind("PD_INSPECTION_CONTENT") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管意见</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_SUGGEST" Text='<%#Bind("PD_INSPECTION_SUGGEST") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管结论</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_CONCLUSION" Text='<%#Bind("PD_INSPECTION_CONCLUSION") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                监管资料</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_FILENAME" Text='<%#Bind("PD_INSPECTION_FILENAME") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                农户名称</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_PEASANT" Text='<%#Bind("PD_INSPECTION_PEASANT") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                身份证号码</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_IDNO" Text='<%#Bind("PD_INSPECTION_IDNO") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                补贴数量</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_FFNUM" Text='<%#Bind("PD_INSPECTION_FFNUM") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                补贴标准</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_FFSTAND" Text='<%#Bind("PD_INSPECTION_FFSTAND") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                补贴金额</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_FFMONEY" Text='<%#Bind("PD_INSPECTION_FFMONEY") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                发放账号</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_ACCOUNTNO" Text='<%#Bind("PD_INSPECTION_ACCOUNTNO") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                农户家庭住址</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_INSPECTION_PEASANT_ADDR" Text='<%#Bind("PD_INSPECTION_PEASANT_ADDR") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </yyc:SmartGridView>--%>
<%--            </ContentTemplate>
        </cc1:TabPanel>--%>
        <cc1:TabPanel ID="Panel_xmsbzl" runat="server" HeaderText="项目资料">
            <ContentTemplate>
            
                      <div uid='add_del_button' style="text-align: left; padding:5px 10px;">
                        <a href="javascript:void(0)" onclick='loadTable_add("table_BzXmzl",json_BzXmzl,"xmss_5")'>
                            <img src="../../images/AddRow.png" /></a> <a href="javascript:void(0)" onclick="tableJDdel('table_BzXmzl',3);"><img src="../../images/DelRow.png" /></a></div>
                <div id="div_file" uname="div_file">
                    <table id="table_BzXmzl" style="width:98%" border="1" cellpadding="4" cellspacing="0"
                                bordercolor="#CCCCCC">
                        <tr style="background:#E9E9E9;">
                            <td style="display: none;">
                                自动ID
                            </td>
                            <td style="width: 50px; height:30px;" align="center">
                                选择
                            </td>
                            <td style="width: 200px;display: none;">
                                项目代码
                            </td>
                            <td style="width: 450px" colspan="2" align="center">
                                附件名称
                            </td>
                            <%--<td style="width: 100px">
                                操作
                            </td>--%>
                        </tr>
                    </table>
                    <div>
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
                </div>
            
            
            <%--
                <div style="text-align: left;">
                    <asp:LinkButton ID="lbtnAdd_xmzl" runat="server" Width="80px" OnClick="lbtnAddRow_Click">添加行</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDel_xmzl" runat="server" OnClick="btnDeleteRow_Click" OnClientClick="return confirm('确定要删除选中行吗？');">删除选中行</asp:LinkButton>
                </div>
                <yyc:SmartGridView ID="gvResult_xmzl" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" ContextMenuCssClass="RightMenu" Width="100%" DataKeyNames="AUTO_NO"
                    AllowSorting="true"  OnRowCommand="gvResult_RowCommand"
                    OnSorting="gvResult_Sorting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <div style="text-align: center; width: 100%;">
                                    <asp:CheckBox ID="CheckBoxF" runat="server" />
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxNode" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                自动ID</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="AUTO_NO" Text='<%#Bind("AUTO_NO") %>' Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                项目编码</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_PROJECT_CODE" Text='<%#Bind("PD_PROJECT_CODE") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="附件名称" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                附件名称</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="PD_PROJECT_ATTACH_NAME" Text='<%#Bind("PD_PROJECT_ATTACH_NAME") %>'
                                    Width="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </yyc:SmartGridView>--%>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
<input type="hidden" id="BTFFID" uid="BTFFID" runat="server" />
    <script type="text/javascript">
        var json_BzGGXX = "<%=json_BzGGXX%>";
        var json_BzXmzl = "<%=json_BzXmzl%>";
        var json_BzGGXX_Data = "<%=json_BzGGXX_Data %>";
        var json_BzXmzl_Data = "<%=json_BzXmzl_Data %>";


        function loadTable_add(tableID, data, loop) {
            loadTable_JD(tableID, eval(data)[0], loop);
        }
        function PostLoadxmsszl(tableID, json, addLoop) {
            Loadxmsszl(tableID, json, addLoop);
        }



        $(document).ready(function () {
            try {
                if (json_BzXmzl_Data != "")
                    PostLoadxmsszl('table_BzXmzl', eval(json_BzXmzl_Data), 'xmss_5');
                //        if(json_BzGGXX_Data!="")
                //            PostLoadxmsszl('table_BzGGXX',eval(json_BzGGXX_Data),'bz_table_BzGGXX');

                setHeight();
            } catch (e) { alert("deady error " + e) }
        });
    </script>

</asp:Content>
