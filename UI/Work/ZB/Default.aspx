<%@ page language="C#" autoeventwireup="true" CodeBehind="Default.aspx.cs" inherits="Work_ZB_Default" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <%--  <link href="../../jquery.easyui/lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />

    <script src="../../jquery.easyui/lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>

   <script src="../../jquery.easyui/lib/ligerUI/js/core/base.js" type="text/javascript"></script>

    <script src="../../jquery.easyui/lib/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>

    <script src="../../jquery.easyui/lib/ligerUI/js/plugins/ligerResizable.js" type="text/javascript"></script>--%>

    <script src="../../jquery.easyui/js/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="../../jss/PublicJS.js" type="text/javascript"></script>

 
    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    
    
        <link href="../../jquery.easyui/imgload/demo.css" rel="stylesheet" type="text/css" />    
     <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />  

    

</head>
<body>
    <form id="form1" runat="server">
            <asp:TextBox ID="TextBox1" class="Wdate" runat="server" onfocus="WdatePicker({firstDayOfWeek:1})"
            Enabled="true" />
  <asp:TextBox ID="txtPD_QUOTA_FWDATA" uid="txtPD_QUOTA_FWDATA" data-options="formatter:myformatter,parser:myparser"
                        class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>    <br />
    <br />
    <br />
                   <table style="width: 60%;   text-align: left; vertical-align: top;">
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
                            <td rowspan="6" style="width: 230px">
                                <img src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;">
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
                                上传图片：<input type="file"
                                    id="file1" name="file" onchange="LoadUp(this,'temp','UserImages')" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
    </form>
</body>
</html>
