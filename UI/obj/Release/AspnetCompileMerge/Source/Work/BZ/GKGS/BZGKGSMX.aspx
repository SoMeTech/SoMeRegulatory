<%@ page language="C#" masterpagefile="~/Master/MainMX_cs.master" autoeventwireup="true" CodeBehind="BZGKGSMX.aspx.cs" inherits="Work_BZ_GKGS_BZGKGSMX" title=" 补助性资金公开公示" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX_cs.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <%--
    
    <script src="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.css") %>"
        type="text/javascript"></script>--%>
    <%--  <script src="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.js") %>"
        type="text/javascript"></script>
--%>
    <link href="../../../WebControls/UserControl/fileup.css" rel="stylesheet" type="text/css" />

    <script src="../../../WebControls/UserControl/fileup.js" type="text/javascript"></script>

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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <link href="../../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/imgload/demo.css" rel="stylesheet" type="text/css" />

    <script src="../../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../../../jquery.easyui/imgload/jQuery.blockUI.js" type="text/javascript"></script>

    <%--    <script src="../../../jquery.easyui/imgload/jquery.pack.js" type="text/javascript"></script>--%>

    <script src="../../../jquery.easyui/imgload/jquery.SuperSlide.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {
            if ($("input[id='ibtcontrol_ibtsave']").length <= 0) {
                if ($("input[uid='json_btData']").get(0).value != "")
                    Bind_tbHeadNotDel(eval(decodeURIComponent($("input[uid='json_btData']").get(0).value))[0], 10000, 'zxzb_bt', 5);

            } else {
                if ($("input[uid='json_btData']").get(0).value != "")
                    Bind_tbHead(eval(decodeURIComponent($("input[uid='json_btData']").get(0).value))[0], 10000, 'zxzb_bt', 5);

            }

        })
        function imgup(obj) {
            var location = $('#InputFile').val();
            var point = location.lastIndexOf(".");
            var type = location.substr(point);
            if (type == ".jpg" || type == ".gif" || type == ".JPG" || type == ".GIF" || type == ".PNG" || type == ".png" || type == ".bmp" || type == ".BMP" || type == ".jpeg") {
                ImgFileUp(obj, $('#InputFile').get(0), "?filepath=UserImages", "");
                setTimeout(backCall, 5);
            }
            else {
                alert("上传的格式不正确！请重新上传保存！");
            }

        }
        function backCall() {
            if ($('#InputFile').attr('uid') == undefined)
                setTimeout(backCall, 5)
            else {

                document.getElementById('<%=txt_file.ClientID%>').value = $('#InputFile').val() + "||" + $('#InputFile').attr('uid');
            }
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $('#button1').click(function () {
                document.getElementById('<%=txt_file.ClientID%>').value = $('#InputFile').val();
            })

             //初始值
             var strHtml = $(".tempWrap ul li").eq(0).find('#imgPreview').html();
             var values = $(strHtml).attr("title");
             $("#inp_discript").attr("value", values);

             var strHtml = $(".tempWrap ul li").eq(0).find('#imgPreview').html();
             var valuescsz = $(strHtml).attr("title");
             $("#inp_discript").attr("value", values);
             var imgidcsz = $(strHtml).attr("imgid");
             //inp_discript_inp
             $("#inp_discript_inp").attr("value", valuescsz);
             $("#inp_discript_id").val(imgidcsz);

             //删除图片
             $('#img_delete').click(function () {
                 var strHtml = $(".tempWrap ul li").eq(1).html();
                 var descript = $('#inp_discript_id').val();

                 try {
                     $.ajax({
                         type: "POST",   //访问WebService使用Post方式请求
                         contentType: "application/json", //WebService 会返回Json类型
                         url: "BZGKGSMX.aspx/DelImg", //调用WebService的地址和方法名称组合 ---- WsURL/方法
                         data: "{value1:'" + descript + "'}",    //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到       
                         dataType: 'json',
                         success: function (result) {     //回调函数，result，返回值
                             $("#ulimg").load(location.href + '#ulimg>*');
                             //                        alert(result.d);
                         }
                     });
                 } catch (e) { alert(e) }
                 //                var strHtml=$(".tempWrap ul li").eq(1).html();
                 //                var truthBeTold = window.confirm("您是否是要删除此图片！","友情提示！"); 
                 //                if (truthBeTold) { 
                 //                    $(".tempWrap ul li").eq(1).remove();
                 //                } 
                 //                if(strHtml==null)
                 //                {
                 //                    var strimg="<li class='li1'><div class='pic' <a href='#' target='_self'>><img src='../../../jquery.easyui/imgload/images/no_img.png'  title='信息公示'/></a></div></li>";
                 //                    $(".tempWrap ul li").append(strimg);
                 //                }
             })

             //查看图片
             $('#img_look').click(function () {
                 var lujing = $("#upimg").attr("src");
                 //alert(lujing);  
                 //window.open(lujing);
                 var olmg = new Image();
                 olmg.src = lujing;
                 window.open(lujing, 'newwindow', 'width=' + (olmg.width + 10) + ',height=' + (olmg.height + 18) + ',toolbar=no,menubar=no,scrollbars=no,resizable=yes,location=no,status=no')
             })

             //修改图片描述<a href="proBZGKGSMX.aspx">proBZGKGSMX.aspx</a>
             $('#btn_save').click(function () {

                 try {
                     var strHtml = $(".tempWrap ul li").eq(1).html();
                     var descript = $('#inp_discript').val();
                     var descript_inp = $('#inp_discript_inp').val();
                     var values = $(strHtml).attr("src");
                 } catch (e) {

                 }

                 try {
                     $.ajax({
                         type: "POST",   //访问WebService使用Post方式请求
                         contentType: "application/json", //WebService 会返回Json类型
                         url: "BZGKGSMX.aspx/UpdateImgDscript", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                         data: "{value1:'" + descript + "',value2:'" + values + "',value3:'" + descript_inp + "'}",          //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到       
                         dataType: 'json',
                         success: function (result) {     //回调函数，result，返回值
                             try {
                                 $("#ulimg").load(location.href + '#ulimg>*');

                             } catch (e) { alert(e) }
                             //                        alert(result.d);
                         }
                     });
                 } catch (e) { alert(e) }
             })

             //向右点击
             $('.next').click(function () {

                 var strHtml = $(".tempWrap ul li").eq(1).find('#imgPreview').html();
                 var values = $(strHtml).attr("title");
                 $("#inp_discript").attr("value", values);
                 //inp_discript_inp
                 var imgid = $(strHtml).attr("imgid");
                 $("#inp_discript_inp").attr("value", values);
                 $("#inp_discript_id").val(imgid);
             })
             //向左点击
             $('.prev').click(function () {

                 var counts = $(".tempWrap ul li").length / 3;
                 var strHtml = $(".tempWrap ul li").find('#imgPreview').html();
                 var values = $(strHtml).attr("title");
                 $("#inp_discript").attr("value", values);

             })

         })
        function IsSubmit() {
            return true;
        }

        function gvResultClientClick() {

            $("input[uid='ibtid']").get(0).value = 'gvResult_Click';
            IsSubmit();
        }

    </script>

    <script type="text/javascript">
        $(function () {
            $('#img_delete').click(function () {
                var strHtml = $(".tempWrap ul li").eq(1).html();

                var truthBeTold = window.confirm("您是否是要删除此图片！", "友情提示！");
                if (truthBeTold) {
                    $(".tempWrap ul li").eq(1).remove();
                }
                if (strHtml == null) {
                    var strimg = "<li class='li1'><div class='pic' <a href='#' target='_self'>><img src='../../../jquery.easyui/imgload/images/no_img.png'  title='信息公开公示'/></a></div></li>";
                    $(".tempWrap ul li").append(strimg);
                }
            })
        })

    </script>

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

            }
        }
    </script>

    <script type="text/javascript">

        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        function findwindow(val, obj) {
            var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val + "&pd_year=" + $("select[uid='txtPD_YEAR']").get(0).value + "&ProjectType=02";
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
    </script>

    <!--[if lt IE 7]>
<script type="text/javascript" src="jquery.easyui/ie_png.js"></script>
<script type="text/javascript">
	 ie_png.fix('.png, div img, #contacts-form input, #contacts-form textarea');
</script>
<![endif]-->
    <div style="text-align: left;">
        <div style="border: thin solid #8db2e3; margin-top: 15px; margin-left: 10px; margin-right: 5px;">
            <p style="margin-top: -8px; _margin-top: 5px; margin-left: 15px; background-color: White;
                width: 90px;">
                项目基本信息：</p>
            <table border="0" style="width: auto;">
                <tr style="display: none;">
                    <td align="right" style="width: 130px; height: 40px;">
                        自动编号 ：
                    </td>
                    <td align="left" colspan="5" style="width: ">
                        <asp:Label ID="lblAUTO_NO" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        项目年度 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_YEAR" uid='txtPD_YEAR' runat="server" style="width: 200px;"
                            disabled="disabled" />
                    </td>
                    <td align="right">
                        项目名称 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPD_PROJECT_NAME" runat="server" Style="width: 200px;" ReadOnly="true"
                            Enabled="false"></asp:TextBox>
                        <input type="text" id="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server"
                            style="width: 200px; display: none;" />
                    </td>
                    <td align="right" style="width: 130px; height: 40px;">
                        政策依据 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPD_PROJECT_FILENO_JG" runat="server" Style="width: 200px;" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        补助对象 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPD_PROJECT_BZDX" runat="server" Style="width: 200px;" Enabled="false"></asp:TextBox>
                    </td>
                    <td align="right">
                        补助标准 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPD_PROJECT_BZSTAND_NUM" uid="txtPD_PROJECT_BZSTAND_NUM" runat="server"
                            Enabled="false" Style="width: 200px;"></asp:TextBox>
                    </td>
                    <td align="right">
                        补助数量 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_PROJECT_BZNUM" uid="txtPD_PROJECT_BZNUM" runat="server"
                            disabled="disabled" style="width: 200px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 40px;">
                        补助金额 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_PROJECT_BZMONEY" uid="txtPD_PROJECT_BZMONEY" runat="server"
                            disabled="disabled" style="width: 200px;" />
                    </td>
                    <td align="right" style="width: 130px; height: 40px;">
                        举报电话 ：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_JB_TELEPHONE" uid="txtPD_JB_TELEPHONE" runat="server"
                            disabled="disabled" style="width: 200px;" />
                    </td>
                    <td align="right" style="width: 130px; height: 40px;">
                    </td>
                    <td align="left">
                    </td>
                </tr>
            </table>
        </div>
        <div style=" width:69%; border: thin solid #8db2e3; margin-top: 15px; margin-left: 10px; _margin-left: 0px;
            margin-right: 5px; float: left;">
            <p style="margin-top: -8px; _margin-top: 5px; margin-left: 15px; background-color: White;
                width: 90px;">
                公开公示信息：</p>
            <table border="0" style="width: 100%;">
                <tr style="display: none;">
                    <td align="right" style="width: 130px; height: 30px;">
                        公开公示编号 ：
                    </td>
                    <td align="left" colspan="5" style="width: ">
                        <asp:Label ID="lblGKGSAUTO_NO" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 25px;">
                        公示类型：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="txtPD_GS_TYPE" uid="txtPD_GS_TYPE" runat="server" Style="width: 206px;">
                            <asp:ListItem Value="1">事前</asp:ListItem>
                            <asp:ListItem Value="2">事中</asp:ListItem>
                            <asp:ListItem Value="3">事后</asp:ListItem>
                        </asp:DropDownList><span style="color: Red">*</span>
                    </td>
                    <td align="right">
                        公示形式：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_GS_STYLE" uid="txtPD_GS_STYLE" runat="server" style="width: 200px;" />
                    </td>
                    <td align="left" rowspan="6" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 25px;">
                        公示主体：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_GS_ZHUTI" uid="txtPD_GS_ZHUTI" runat="server" style="width: 200px;" />
                    </td>
                    <td align="right">
                        公示开始时间：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_GS_DATE" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" uid='txtPD_GS_DATE' readonly="readonly" runat="server"
                            style="width: 205px;"/><span style="color: Red">*</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        公示结束时间：
                    </td>
                    <td align="left">
                        <input type="text" id="txtPD_GS_DATE_END" data-options="formatter:myformatter,parser:myparser"
                            class="easyui-datebox" uid='txtPD_GS_DATE_End' readonly="readonly" runat="server"
                            style="width: 205px;" /><span style="color: Red">*</span>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 25px;">
                        公示地点 ：
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="txtPD_GS_ADDR" uid='txtPD_GS_ADDR' runat="server" style="width: 580px;" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 25px;">
                        附件 ：
                    </td>
                    <td colspan="3" align="left">
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
                            <div>
                                <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                            </div>
                        </div>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 25px;">
                        备注 ：
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="txtPD_GS_DETAIL" uid='txtPD_GS_DETAIL' runat="server" style="width: 580px;" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 130px; height: 25px;">
                    </td>
                    <td align="left" colspan="3">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <input type="hidden" id="json_btData" uid="json_btData" runat="server" />
        </div>
        <div style="float: right; margin-right: 10px; width:27%; margin-top:10px;">
            <div style="width: 100%; height: 270px; border: thin solid #8db2e3; margin-top: 5px; ">
                <p style="margin-top: -7px; _margin-top: 5px; margin-left: 70px; background-color: White;
                    color: #333; font-weight: bold; width: 105px;">
                    公开公示照片：</p>
                <div id="demoContent">
                    <div class="ms" >
                        描述：<input type="text" id="inp_discript" value="描述" />&nbsp;&nbsp;&nbsp;&nbsp;  <div style="display:none;"><input type="text" id="inp_discript_inp" value="描述" /><input type="text" id="inp_discript_id" value="描述" /></div>
                        <input type="button" id="btn_save" value="保存" /></div>
                    <div class="effect">
                        <div id="focusAd" class="tv-slideBox">
                            <a class="prev"></a><a class="next"></a>
                            <div class="bd">
                                <ul id="ulimg" runat="server">
                                    <%-- <li class="li1">
                                                <div class="pic">
                                                    <a href="#" target="_self">
                                                        <img src="../../../jquery.easyui/imgload/images/sgt.jpg"  title="信息公示1"/></a></div>
                                            </li>
                                            <li class="li1">
                                                <div class="pic">
                                                    <a href="#" target="_self">
                                                        <img src="../../../jquery.easyui/imgload/images/u42_normal.jpg" title="信息公开2"/></a></div>
                                            </li>
                                            <li class="li1">
                                                <div class="pic">
                                                    <a href="#" target="_self">
                                                        <img src="../../../jquery.easyui/imgload/images/sgt.jpg" / title="信息公开3"></a></div>
                                            </li>
                                            <li class="li1">
                                                <div class="pic">
                                                    <a href="#" target="_self">
                                                        <img src="../../../jquery.easyui/imgload/images/u42_normal.jpg" title="信息公开4"/></a></div>
                                            </li>  --%>
                                    <li class="li1" lid="ssXCMX_001">
                                        <div class="pic" img="no_imgs">
                                            <a href="#" target="_self">
                                                <img src="../../../jquery.easyui/imgload/images/no_img.png" title="信息公开5" /></a></div>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <script language="javascript"> jQuery("#focusAd").slide({ mainCell: ".bd ul", effect: "leftLoop", autoPlay: false, titOnClassName: "on" });</script>

                        <!--[if IE 6]>
				<script type="text/javascript" src="../DD_belatedPNG.js"></script>
				<script type="text/javascript">DD_belatedPNG.fix('#focusAd .bg,#focusAd .con,#focusAd .prev,#focusAd .next');</script>
				<![endif]-->
                    </div>
                    <div style="clear: both;">
                        <%--    <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                        columnindex='0' rowindex='10000' onmouseover="MouseOnRowIndex=10000" /> --%>
                        <input id="InputFile" name="file1" style="width: 239px; margin-bottom: 5px;" type="file"
                            onchange='PreviewImage(this)' />
                        <div style="display: none;">
                            <asp:TextBox ID="txt_file" runat="server"></asp:TextBox></div>
                        <input type="button" id="button1" class="up_imgsinput" value="上传图片" onclick="imgup(this)" /><%--
                                      <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClientClick="$(input[uid='ibtid'].get(0).value='UploadButton')"  OnClick="UploadButton_Click" />--%>
                        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <input type="button" id="img_delete" class="del_imgsinput" value="图片删除" />
                        <input type="button" id="img_look" class="look_imgsinput" value="查看大图" /></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
        Visible="true">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="公开公示列表" Width="200px">
            <HeaderTemplate>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                公开公示列表 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </HeaderTemplate>
            <ContentTemplate>
                <input type="hidden" id="txtindex" runat="server" />
                <input type="hidden" id="txttitle" runat="server" />
                <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                    ContextMenuCssClass="RightMenu" DataKeyNames="AUTO_NO" AllowSorting="True" OnSorting="gvResult_Sorting"
                    OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select" CssClass="tKeepAll"
                    BoundRowDoubleClickCommandName="Two" IfUserMouseOverCssClass="False" onClick="gvResultClientClick()"
                    RowDoubleClickDoed="False" TimeSpan="0">
                    <Columns>
                        <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_YEAR" HeaderText="项目年度" SortExpression="PD_YEAR">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--  <asp:BoundField DataField="PD_GS_TYPE" HeaderText="公示类型" SortExpression="PD_GS_TYPE"
                            ItemStyle-HorizontalAlign="Left" />--%>
                        <asp:TemplateField HeaderText="公示类型" SortExpression="PD_GS_TYPE" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="labPD_GS_TYPE" runat="server" Text='<%# getComfirm(Eval("PD_GS_TYPE")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PD_GS_STYLE" HeaderText="公示形式" SortExpression="PD_GS_STYLE"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_ZHUTI" HeaderText="公示主体" SortExpression="PD_GS_ZHUTI"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_DATE" HeaderText="公示开始时间" SortExpression="PD_GS_DATE"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_DATE_END" HeaderText="公示结束时间" SortExpression="PD_GS_DATE_END"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_ADDR" HeaderText="公示地点" SortExpression="PD_GS_ADDR"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_FILENAME" HeaderText="附件文件名" SortExpression="PD_GS_FILENAME"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_FILENAME_SYSTEM" HeaderText="附件系统文件名" SortExpression="PD_GS_FILENAME_SYSTEM"
                            Visible="false" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_GS_DETAIL" HeaderText="备注" SortExpression="PD_GS_DETAIL"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
