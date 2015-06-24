<%@ page language="C#" autoeventwireup="true" CodeBehind="UpLoadImg.aspx.cs" inherits="UpLoadImg" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" type="text/css" href="jquery.easyui/themes/default/easyui.css" />
    <link href="jquery.easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="jquery.easyui/imgload/demo_update.css" rel="stylesheet" type="text/css" />

    <script src="jquery.easyui/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="jquery.easyui/imgload/jQuery.blockUI.js" type="text/javascript"></script>

    <script src="jquery.easyui/imgload/jquery.pack.js" type="text/javascript"></script>

    <script src="jquery.easyui/imgload/jquery.SuperSlide_update.js" type="text/javascript"></script>

    <script src="jss/PublicJS.js" type="text/javascript"></script>

    <script src="images/new/add.png" type="text/javascript"></script>

    <!--[if lt IE 7]>
<script type="text/javascript" src="jquery.easyui/ie_png.js"></script>
<script type="text/javascript">
	 ie_png.fix('.png, div img, #contacts-form input, #contacts-form textarea');
</script>
<![endif]-->
    <style type="text/css">
        .style1
        {
            height: 44px;
        }
        .table tr td
        {
            border: 1px #ff000 solid;
            
        }
        .auto-style1 {
            height: 20px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $('#btn').click(function () {

                $("#file").attr("value", "nihao");

            })
        })
    </script>

    <script type="text/javascript">
        var MAXSIZE = 210 * 199; //限制上传图片大小50K       
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
    function runSave() {
        if (imgFrame.location != "about:blank") {
            window.imgFrame.document.execCommand("SaveAs");
        }
    }
    function saveFace(url) {
        if (window.imgFrame && url) window.imgFrame.location = url;
        return false;
    }
  </script>  
</head>
<body>
    <form id="form1" runat="server">
  <img   src="images/add.png"  id="imgIn" alt="添加"/>   
  <a href="#" onclick="return saveFace(imgIn.src);">保存到电脑</a>   
  <iframe name="imgFrame" onload="runSave()" style="display:none;"></iframe>
            <br />
            <br />
            <div>
                <table>
                    <tr>
                        <td class="style1">
                            上传图片文件：<img src="images/new/add.png" />
                        </td>
                        <td class="style1">
                            <select style="height: 21px;" id="type">
                                <option value="SQGS">事前公示</option>
                                <option value="SZGS">事中公示</option>
                                <option value="SHGS">事后公示</option>
                            </select>
                        </td>
                        <td class="style1">
                            <input id="txtImgUrl" type="text" name="txtImgUrl" readonly="readonly" style='width: 268px;'
                                missingmessage='请上传图片' invalidmessage='不能为空！' required="true" />
                            <input id="InputFile" name="file1" style="width: 239px; margin-bottom: 5px;" type="file" />
                            <input type="button" value="上传" runat="server" />
                            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                        </td>
                        <td class="style1">
                            <a href="javascript:void(0);" class="files">
                                <input type="file" id="FileUpload" name="FileUpload" /></a> <span class="uploading">
                                    正在上传，请稍候...</span>
                        </td>
                    </tr>
                </table>
                <table style="border: 1px solid red;">
                    <tr style="border-bottom: 1px solid red;">
                        <td class="auto-style1">
                            fdsa
                        </td>
                        <td class="auto-style1">
                            fdsa
                        </td>
                        <td class="auto-style1">
                            fdsa
                        </td>
                        <td class="auto-style1">
                            fdsa
                        </td>
                    </tr>
                    <tr>
                        <td>
                            fdsa
                        </td>
                        <td>
                            fdsa
                        </td>
                        <td>
                            fdsa
                        </td>
                        <td>
                            fdsa
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" cellpadding="0" cellspacing="1" bgcolor="#A3C0E8">
                    <tr bgcolor="#ccc">
                        <td>
                            fdsf
                        </td>
                        <td>
                            fsdf
                        </td>
                    </tr>
                    <tr bgcolor="#fff">
                        <td>
                            fdsf
                        </td>
                        <td>
                            fsdf
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <table id="table_xmsszl" border="0" width="100%" cellpadding="0" cellspacing="1"
                bgcolor="#A3C0E8">
                <tr style="background: #E9E9E9;">
                    <td style="display: none;">
                        自动ID
                    </td>
                    <td style="width: 30px; height: 30px;">
                        选择
                    </td>
                    <td style="width: 200px; display: none;">
                        项目实施资料项目代码
                    </td>
                    <td style="width: 450px" colspan="2">
                        附件名称
                    </td>
                </tr>
                <tr style="background: #ffffff;">
                    <td style="display: none;">
                        自动ID
                    </td>
                    <td style="width: 30px; height: 30px;">
                        选择
                    </td>
                    <td style="width: 200px; display: none;">
                        项目实施资料项目代码
                    </td>
                    <td style="width: 450px" colspan="2">
                        附件名称
                    </td>
                </tr>
            </table>
            <br />
            <table id="table1" border="0" width="100%" cellpadding="0" cellspacing="1" bgcolor="#A3C0E8">
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
            <!-- content S -->
            <div style="width: 263px; height: 270px; border: thin solid #8db2e3; margin-top: 5px;">
                <p style="margin-top: -7px; _margin-top: 5px; margin-left: 70px; background-color: White;
                    color: #333; font-weight: bold; width: 105px;">
                    公开公示照片：</p>
                <div id="demoContent">
                    <div class="ms">
                        描述：<input type="text" id="inp_discript" value="描述" />&nbsp;&nbsp;&nbsp;&nbsp;
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
                                                <img src="jquery.easyui/imgload/images/no_img.png" title="信息公开5" /></a></div>
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
                        <input id="File2" name="file1" style="width: 239px; margin-bottom: 5px;" type="file"
                            onchange='PreviewImage(this)' />
                        <div style="display: none;">
                            <asp:TextBox ID="txt_file" runat="server"></asp:TextBox></div>
                        <input type="button" id="button3" class="up_imgsinput" value="上传图片" onclick="imgup(this)" /><%--
                                      <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClientClick="$(input[uid='ibtid'].get(0).value='UploadButton')"  OnClick="UploadButton_Click" />--%>
                        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <input type="button" id="img_delete" class="del_imgsinput" value="图片删除" /></div>
                </div>
            </div>
            <input id="File1" name="file1" style="width: 239px; margin-bottom: 5px;" type="file"
                onchange="Javascript:checkFileChange(this);" />
        </div>
        <br />
        <br />
        <table>
            <tr bgcolor="#f5f5f5">
                <td height="30" align="center" valign="middle">
                    图片链接
                </td>
                <td height="35" align="center" valign="middle">
                    <input type="file" name="uploadfile1" runat="server" id="uploadfile1" onpropertychange="document.all.imgID.src=file:///+this.value">
                    &nbsp;
                </td>
            </tr>
            <tr bgcolor="#f5f5f5">
                <td height="70" align="center" valign="middle">
                    缩略图
                </td>
                <td height="70" align="center" valign="middle">
                    <img id="imgID" width="82" height="65" border="0">&nbsp;
                </td>
            </tr>
        </table>
        <br />
        <br />
        <input type="file" onchange='PreviewImage(this)' />
        <br />
        <!-- content E -->

        <script src="jquery.easyui/jquery-1.7.1.min.js" type="text/javascript"></script>

        <script src="jquery.easyui/jquery.easyui.min.js" type="text/javascript"></script>

        <script src="jquery.easyui/jquery.form.js" type="text/javascript"></script>

        <script src="jquery.easyui/eachport.upload.js" type="text/javascript"></script>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>
    </form>
</body>
</html>
