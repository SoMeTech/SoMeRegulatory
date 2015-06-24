<%@ page language="C#" masterpagefile="~/Master/MainMX_cs.master" autoeventwireup="true" CodeBehind="ssXCMx.aspx.cs" inherits="Work_projectGL_ssProjectCCXC_ssXCMx" title="项目建设资金巡查" enableEventValidation="false" stylesheettheme="Default" %>
 
<%@ MasterType VirtualPath="~/Master/MainMX_cs.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <link href="../../../WebControls/UserControl/fileup.css" rel="stylesheet" type="text/css" />

    <script src="../../../WebControls/UserControl/fileup.js" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/resources/css/ext-all.css") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <link href="../../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/imgload/demo.css" rel="stylesheet" type="text/css" />

    <script src="../../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../../../jquery.easyui/imgload/jQuery.blockUI.js" type="text/javascript"></script>

    <%--    <script src="../../../jquery.easyui/imgload/jquery.pack.js" type="text/javascript"></script>
--%>

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

                setTimeout(backCall, 5)
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
                //alert($('#InputFile').attr('uid'));
                //document.getElementById('<%=txt_file.ClientID%>').value=$('#InputFile').val(); 
            })

             //初始值
             //初始值
             var strHtml = $(".tempWrap ul li").eq(0).find('#imgPreview').html();
             var values = $(strHtml).attr("title");
             $("#inp_discript").attr("value", values);

             var strHtml = $(".tempWrap ul li").eq(1).find('#imgPreview').html();
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
                         url: "ssXCMx.aspx/DelImg", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                         data: "{value1:'" + descript + "'}",      //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到       
                         dataType: 'json',
                         success: function (result) {     //回调函数，result，返回值
                             $("#ulimg").load(location.href + '#ulimg>*');
                             //                        alert(result.d);
                         }
                     });
                 } catch (e) { alert(e) }

             })

             //修改图片描述
             $('#btn_save').click(function () {
                 var strHtml = $(".tempWrap ul li").eq(1).html();
                 var descript = $('#inp_discript').val();
                 var strHtmls = $(".tempWrap ul li").eq(1).find('#imgPreview').html();
                 var descript_inp = $('#inp_discript_inp').val();
                 var values = $(strHtmls).attr("src");

                 try {
                     $.ajax({
                         type: "POST",   //访问WebService使用Post方式请求
                         contentType: "application/json", //WebService 会返回Json类型
                         url: "ssXCMx.aspx/UpdateImgDscript", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                         data: "{value1:'" + descript + "',value2:'" + values + "',value3:'" + descript_inp + "'}",        //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到       
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
                 var imgid = $(strHtml).attr("imgid");
                 //inp_discript_inp
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
        var MAXSIZE = 50 * 1024; //限制上传图片大小50K       
        var ERROR_IMGSIZE = "图片大小不能超过50K"; //图片大小限制信息        
        var isImg = true; //图片是否合格
        /**Input file onchange事件* @params obj file对象* @return void**/
        function checkFileChange(obj) {

            var img = $(".img")[0];
            var file = obj.value;
            var exp = /.\.jpg|.\.gif|.\.png|.\.bmp/i;
            if (exp.test(file)) {
                $('.img').attr("src", file);

            }
            else {
                alert("图片格式不正确");
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
    <div style="text-align: left; float:left; width:70%;  ">
        <table cellspacing="0" cellpadding="0" style="width:100%;" border="0">
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    &nbsp;
                    <%-- <img src="close.png" class="img" alt="头像" /> --%>
                </td>
                <td align="left" colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="width: 130px; height: 30px;">
                    自动序号 ：
                </td>
                <td align="left" colspan="5">
                    <asp:Label ID="lblAUTO_NO" runat="server"></asp:Label>
                    <asp:Label ID="txtPD_DB_LOOP" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    项目年度：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_YEAR" uid="ddlPD_YEAR" runat="server" Width="206px" onchange="csPD_PROJECT_CODE()"
                        Enabled="false">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    项目名称 ：
                </td>
                <td align="left">
                    <input type="text" id="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server"
                        style="width: 200px; display: none;" />
                    <%--onclick="javascript:findwindow('proj_bianma2&amp;pd_found_xz=01',this);"--%>
                    <input type="text" id='txtPD_PROJECT_Name' uid='txtPD_PROJECT_Name' runat="server"
                        style="width: 200px;" rdonly="1" />
                    <span style="color: Red">*</span>
                </td>
                <td align="left" colspan="3" rowspan="8">
                  
                </td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    项目过程 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="txtPD_INSPECTION_PROCESS" uid="txtPD_INSPECTION_PROCESS" runat="server"
                        Width="206px">
                        <asp:ListItem>事前</asp:ListItem>
                        <asp:ListItem>事中</asp:ListItem>
                        <asp:ListItem>事后</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    巡查地点 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_INSPECTION_ADDR" uid="txtPD_INSPECTION_ADDR" runat="server"
                        Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    监管时间 ：
                </td>
                <td align="left">
                    <input type="text" id="txtPD_INSPECTION_DATE" uid='txtPD_INSPECTION_DATE' data-options="formatter:myformatter,parser:myparser"
                        class="easyui-datebox" readonly="readonly" runat="server" style="width: 205px;" />
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    监管人员 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_INSPECTION_MANS" uid="txtPD_INSPECTION_MANS" runat="server"
                        Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    <%--监管地点 ：--%>
                </td>
                <td align="left">
                    <%--<asp:TextBox ID="txtPD_INSPECTION_ADDR" uid="txtPD_INSPECTION_ADDR" runat="server"
                        Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>--%>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    项目总投资额(元) ：
                </td>
                <td align="left">
                    <input type="text" id="txtPD_PROJECT_TOTAL_MONEY" disabled="disabled" readonly="readonly"
                        runat="server" style="width: 200px;" onkeypress="myKeyDown(this,event,0)" maxlength='20' />
                </td>
                <td align="right">
                    累计拨付总<span style="width: 130px; height: 30px;">额</span>(元) ：
                </td>
                <td align="left">
                    <input type="text" disabled="disabled" id="txtPD_MONITOR_TOTAL_MONEY_PAY" runat="server"
                        style="width: 200px;" readonly="readonly" onkeypress="myKeyDown(this,event,0)"
                        maxlength='20' />
                </td>
                <td align="left" colspan="3">
                    <%--  <input type="text" disabled="disabled" id="txtPD_MONITOR_TOTAL_MONEY_WCL" readonly="readonly"
                        runat="server" style="width: 200px;" onkeypress="myKeyDown(this,event,0)" maxlength='6' />--%>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    项目形象进度：
                </td>
                <td align="left">
                    <input name="text" type="text" id="txtPD_MONITOR_PROCEED_WCL" style="width: 200px;"
                        onkeypress="myKeyDown(this,event,0)" maxlength='6' runat="server" />% <span style="color: Red">
                            *</span>
                </td>
                <td align="right" style="width: 130px; height: 30px;">
                    总投资完成比例(%) ：
                </td>
                <td align="left" colspan="3">
                    <input type="text" disabled="disabled" id="txtPD_MONITOR_TOTAL_MONEY_WCL" readonly="readonly"
                        runat="server" style="width: 200px;" onkeypress="myKeyDown(this,event,0)" maxlength='6' />
                </td>
                <%-- <td  align="left" style="width: 130px; height: 30px;">
                   项目工程图：
                </td>        --%>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 80px;">
                    监管内容 ：
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txtPD_INSPECTION_CONTENT" uid="txtPD_INSPECTION_CONTENT" runat="server" Height="60px" TextMode="MultiLine"
                        Width="567px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td colspan="2" align="left">
                    <%--<img src="../../../userImages/sgt.jpg" style="width: 230px; height: 230px;" />--%>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 80px;">
                    监管意见 ：
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txtPD_INSPECTION_SUGGEST" runat="server" Width="567px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 80px;">
                    监管结论 ：
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txtPD_INSPECTION_CONCLUSION" runat="server" Width="567px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    监管资料 ：
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
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    &nbsp;
                </td>
                <td colspan="2" align="left">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    &nbsp;
                </td>
                <td colspan="2" align="left">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    <%--<input type="button" name="button_upImage" value="图片上传" />--%>
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
        </table>
        <input type="hidden" id="json_btData" uid="json_btData" runat="server" />
        <br />
        <br />
    </div>
    <div style="float:right; margin-right:10px;width: 27%; " >
      <div style="width: 100%; height: 270px; border: 1px solid #c0daf9; margin-top: 10px;">
                        <p style="margin-top: -7px;_margin-top: 5px; margin-left: 70px; background-color: White; color: #333;
                            font-weight: bold; width: 90px;">
                            项目施工照片</p>
                        <div id="demoContent">
                            <div class="ms">
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
                                                        <%-- <img src="../../../jquery.easyui/imgload/images/no_img.png" class="img" title="信息公开5"/>--%>
                                                        <div id="imgPreview" style="width: 230px; height: 230px;">
                                                            <img id="upimg" src="../../../jquery.easyui/imgload/images/no_img.png" style="width: 230px;
                                                                height: 230px;" />
                                                        </div>
                                                    </a>
                                                </div>
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
                            <%--  <div class="js">
                        </div>
                        <div class="css">
                        </div>--%>
                            <div style="clear: both;">
                                <%--    <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                        columnindex='0' rowindex='10000' onmouseover="MouseOnRowIndex=10000" /> --%>
                                <input id="InputFile" style="width: 239px; margin-bottom: 5px;" type="file" name="file"
                                     onchange='PreviewImage(this)'/>
                                <div style="display: none;">
                                    <asp:TextBox ID="txt_file" runat="server"></asp:TextBox></div>
                                <input type="button" id="button1" class="up_imgsinput" value="上传图片" onclick="imgup(this)" /><%--
                                      <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClientClick="$(input[uid='ibtid'].get(0).value='UploadButton')"  OnClick="UploadButton_Click" />--%>
                                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                <input type="button" class="del_imgsinput" id="img_delete" value="图片删除" /></div>
                        </div>
                    </div>
    
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
        Visible="true">
        <cc1:TabPanel ID="Panel_ccxc" runat="server" HeaderText="项目巡查记录列表">
            <HeaderTemplate>
                项目巡查记录列表
            </HeaderTemplate>
            <ContentTemplate>
                <input type="hidden" id="txtindex" runat="server" />
                <input type="hidden" id="txttitle" runat="server" />
                <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                    ContextMenuCssClass="RightMenu" Width="300%" DataKeyNames="AUTO_NO" AllowSorting="true"
                    OnSorting="gvResult_Sorting" OnRowCommand="gvResult_RowCommand" BoundRowClickCommandName="Select"
                    CssClass="tKeepAll" BoundRowDoubleClickCommandName="Two" onClick="gvResultClientClick()">
                    <Columns>
                        <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center"
                            Visible="false" />
                        <asp:BoundField DataField="PD_YEAR" HeaderText="年度" SortExpression="PD_YEAR" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_PROCESS" HeaderText="项目过程" SortExpression="PD_INSPECTION_PROCESS"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_DATE" HeaderText="监管时间" SortExpression="PD_INSPECTION_DATE"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_MANS" HeaderText="监管人员" SortExpression="PD_INSPECTION_MANS"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_ADDR" HeaderText="监管地点" SortExpression="PD_INSPECTION_ADDR"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_CONTENT" HeaderText="监管内容" SortExpression="PD_INSPECTION_CONTENT"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_SUGGEST" HeaderText="监管意见" SortExpression="PD_INSPECTION_SUGGEST"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_CONCLUSION" HeaderText="监管结论" SortExpression="PD_INSPECTION_CONCLUSION"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_FILENAME" HeaderText="监管资料" SortExpression="PD_INSPECTION_FILENAME"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_INSPECTION_FILENAME_SYSTEM" HeaderText="监管资料系统名" SortExpression="PD_INSPECTION_FILENAME_SYSTEM"
                            ItemStyle-HorizontalAlign="Left" />
                        <%--		            <asp:BoundField DataField="PD_INSPECTION_PEASANT" HeaderText="农户名称" SortExpression="PD_INSPECTION_PEASANT" ItemStyle-HorizontalAlign="Left"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_IDNO" HeaderText="身份证号码" SortExpression="PD_INSPECTION_IDNO" ItemStyle-HorizontalAlign="Left"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_FFNUM" HeaderText="补贴数量" SortExpression="PD_INSPECTION_FFNUM" ItemStyle-HorizontalAlign="Left"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_FFSTAND" HeaderText="补贴标准" SortExpression="PD_INSPECTION_FFSTAND" ItemStyle-HorizontalAlign="Left"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_FFMONEY" HeaderText="补贴金额" SortExpression="PD_INSPECTION_FFMONEY" ItemStyle-HorizontalAlign="Left"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_ACCOUNTNO" HeaderText="发放账号" SortExpression="PD_INSPECTION_ACCOUNTNO" ItemStyle-HorizontalAlign="Left"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_PEASANT_ADDR" HeaderText="农户家庭住址" SortExpression="PD_INSPECTION_PEASANT_ADDR" ItemStyle-HorizontalAlign="Left"  /> --%>
                        <asp:BoundField DataField="PD_MONITOR_PROCEED_WCL" HeaderText="项目进度完成比例" SortExpression="PD_MONITOR_PROCEED_WCL"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_PROJECT_TOTAL_MONEY" HeaderText="项目总投资额" SortExpression="PD_PROJECT_TOTAL_MONEY"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_MONITOR_TOTAL_MONEY_PAY" HeaderText="累计拨付总金额" SortExpression="PD_MONITOR_TOTAL_MONEY_PAY"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PD_MONITOR_TOTAL_MONEY_WCL" HeaderText="总投资完成比例" SortExpression="PD_MONITOR_TOTAL_MONEY_WCL"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>

