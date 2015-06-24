<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" title="新增考评细则" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="KaoPingTypeDetailSetOper.aspx.cs" inherits="Work_KaoPing_KaoPingTypeDetailSetOper" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitOpen.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            Loading.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>

    <script type="text/javascript">

        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        function findwindow(val, obj) {
            var webFileUrl = "../../../PublicMode/DiagList/GetSession.aspx?tn=pd_base_kaopingtype";
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ss = arr.split("~");
                    //alert(ss);
                    try {

                        //alert(txtKHTypeID.ClientID);
                        document.getElementById("<%=txtKHTypeID.ClientID %>").value = ss[0];
                        obj.value = ss[1];

                    } catch (e) { alert(e) };
                }
            }
        }

    </script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("PublicMode/jss/Check.js")%>"
        type="text/javascript" charset="gb2312"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <script src="../../PublicMode/jss/Check.js" type="text/javascript"></script>

            <br />
            <table cellpadding="0" cellspacing="0" class="menutext" cellspacing="0" cellpadding="0"
                width="100%" align="center" border="0">
                <tbody>
                    <tr height="40">
                        <td style="width: 113px" align="right" height="30">
                            年度：
                        </td>
                        <td style="width: 196px" align="left" height="30">
                            <asp:DropDownList ID="ddlKP_Year" runat="server" Width="205px">
                                <asp:ListItem Value="2013">2013</asp:ListItem>
                                <asp:ListItem Value="2014">2014</asp:ListItem>
                                <asp:ListItem Value="2015">2015</asp:ListItem>
                                <asp:ListItem Value="2016">2016</asp:ListItem>
                                <asp:ListItem Value="2017">2017</asp:ListItem>
                                <asp:ListItem Value="2018">2018</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 113px" align="right" height="30">
                            考核大类：
                        </td>
                        <td style="width: 196px" align="left" height="30">
                             <input type="text" id="txtKHTypeID" uid='txtKHTypeID' runat="server"
                            style="width: 200px; display: none;" readonly="readonly" />
                            <input type="text" id='txtKHType' uid='txtKHType' runat="server" style="width: 200px;"
                                rdonly="1" onclick="javascript: findwindow('pd_base_kaopingtype', this);" readonly="readonly" />
                            <span style="color: Red">*</span>
                        </td>
                    </tr> 
                     <tr height="40">
                     <td style="width: 196px; height: 30px" align="right">
                            确认状态：
                        </td>
                        <td style="width: 196px; height: 30px; text-align: left">
                            <asp:DropDownList ID="ddlIsComfirm" runat="server" Width="206px">
                                <asp:ListItem Value="0">未确认</asp:ListItem>
                                <asp:ListItem Value="1">已确认</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 117px" align="right" height="30">
                          扣分标准：
                        </td>
                        <td style="width: 196px; text-align: left" height="30">
                              <asp:TextBox ID="txtKP_BiaoZhun" runat="server" Width="200px" Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;"></asp:TextBox>    <font color="red">*</font>
                        </td>
                    </tr>
                    <tr height="40">
                        <td style="width: 117px" align="right" height="30">
                            考评内容：
                        </td>
                        <td style="width:608px; text-align: left" height="30" colspan="3">
                            <asp:TextBox ID="txtKPContent" runat="server" Width="580px"  Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;"></asp:TextBox>
                          
                        </td>
                       <%-- <td style="width: 113px" align="right" height="30">
                            扣分标准：
                        </td>
                        <td style="width: 196px" align="left" height="30">
                          <%--  <asp:TextBox ID="txtKP_BiaoZhun" runat="server" Width="200px" Style="border: 1px solid #CCCCCC;
                                background-color: #FFFFFF; padding: 2px;"></asp:TextBox>    <font color="red">*</font>
                        </td> --%>
                       
                    </tr>
                    
                   
                    <td style="width: 117px; height: 30px" align="right">
                      <%--备注：--%>
                    </td>
                    <td style="width: 248px; height: 30px; text-align: left" colspan="3">
                        <asp:TextBox ID="txtRemark" runat="server" Width="580px" Style="border: 1px solid #CCCCCC;
                            background-color: #FFFFFF; padding: 2px;" BorderColor="#CCCCCC" Visible=false></asp:TextBox>
                    </td>
                    
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
