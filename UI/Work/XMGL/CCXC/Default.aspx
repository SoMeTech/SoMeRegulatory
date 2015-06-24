<%@ page language="C#" autoeventwireup="true" CodeBehind="Default.aspx.cs" inherits="Work_projectGL_ssProjectCCXC_Default" enableEventValidation="false" stylesheettheme="Default" %>


 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery.easyui/imgload/demo.css" rel="stylesheet" type="text/css" />
        <script src="../../../jquery.easyui/jquery-1.8.0.min.js" type="text/javascript"></script> 
     <%--   <script src="../../../jss/jquery-1.4.2.min.js" type="text/javascript"></script>--%>
    <script src="../../../jquery.easyui/jquery.easyui.min.js" type="text/javascript"></script>



  <%--  <link href="../../../WebControls/UserControl/fileup.css" rel="stylesheet" type="text/css" />

    <script src="../../../WebControls/UserControl/fileup.js" type="text/javascript"></script>--%>
    
    
    
 <%--   <link href="../../../jquery.easyui/imgload/demo.css" rel="stylesheet" type="text/css" />

    <script src="../../../jquery.easyui/imgload/jQuery.blockUI.js" type="text/javascript"></script>

    <script src="../../../jquery.easyui/imgload/jquery.pack.js" type="text/javascript"></script>

    <script src="../../../jquery.easyui/imgload/jquery.SuperSlide.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(function () {

            function imgup(obj) {
                var location = $('#InputFile').val();
                var point = location.lastIndexOf(".");
                var type = location.substr(point);
                if (type == ".jpg" || type == ".gif" || type == ".JPG" || type == ".GIF" || type == ".PNG" || type == ".png" || type == ".bmp" || type == ".BMP" || type == ".jpeg") {
                    ImgFileUp(obj, $('#InputFile').get(0), "?filepath=UserImages", "");
                    try {
                        alert($('#InputFile').attr('className') + "abc");
                    } catch (e) { alert(e) }
                }
                else {
                    alert("上传的格式不正确！请重新上传保存！");
                }

            }

            //验证控件
            function PublicYanZheng() {
                var _return = true;
                $($("span")).each(function () {
                    if (trim(this.outerText) == '*') {
                        if ($(this).prev().attr('name') == null)   //普通控件
                        {
                            // alert($("span+input").attr('name'));
                            //alert($("input[name='"+$("span+input").attr('name')+"']").val());
                            if ($("input[name='" + $("span+input").attr('name') + "']").val() == "") {
                                alert("1不能为空");
                                return false;
                            }
                        }
                        else  //日历控件
                        {
                            //alert($(this).prev().attr('name'));
                            //alert($("input[name='"+$(this).prev().attr('name')+"']").val());
                            if ($("input[name='" + $(this).prev().attr('name') + "']").val() == "") {
                                alert("2不能为空");
                                return false;
                            }
                        }
                    }
                });

            }


            function trim(str) { //删除左右两端的空格
                if (str != null) {
                    str = str.replace(/(^\s*)|(\s*$)/g, "");
                    return str;
                }
                else
                    return "";
            }


            $('#Button2').click(function () {
                PublicYanZheng();
                //alert($("input[name='txtPD_QUOTA_FWDATA']").val());
            })
            $('#btn').click(function () {
                alert($("input[name='txtPD_INSPECTION_DATE']").val());

            })


            //初始值
            var strHtml = $(".tempWrap ul li").eq(0).find('a').html();
            var values = $(strHtml).attr("title");
            $("#inp_discript").attr("value", values);

            //删除图片
            $('#img_delete').click(function () {
                var strHtml = $(".tempWrap ul li").eq(1).html();

                var truthBeTold = window.confirm("您是否是要删除此图片！", "友情提示！");
                if (truthBeTold) {
                    $(".tempWrap ul li").eq(1).remove();
                }
                if (strHtml == null) {
                    var strimg = "<li class='li1'><div class='pic' <a href='#' target='_self'>><img src='../../../jquery.easyui/imgload/images/no_img.png'  title='信息公示'/></a></div></li>";
                    $(".tempWrap ul li").append(strimg);
                }
            })

            //向右点击
            $('.next').click(function () {
                var strHtml = $(".tempWrap ul li").eq(1).find('a').html();
                var values = $(strHtml).attr("title");
                $("#inp_discript").attr("value", values);
            })
            //向左点击
            $('.prev').click(function () {
                alert($(".tempWrap ul li").length / 3)

                //                var strHtml=$(".tempWrap ul li").eq(1).find('a').html();
                //                alert(strHtml);
                //                var values=  $(strHtml).attr("title");
                //                $("#inp_discript").attr("value",values);
            })

        })
    </script>

 
</head>
<body>
    <form id="form1" runat="server">
    
    <p>
      <asp:TextBox ID="TextBox1" uid="txtPD_QUOTA_FWDATA" 
                            class="easyui-datebox" runat="server" dateid="date" Width="200px"></asp:TextBox>
    </p>
    <p>
     <asp:DropDownList ID="ddlzjly" uid="ddlzjly" runat="server" onchange="chg()" Width="206px">
                        <asp:ListItem Value="01">财政部门直接下达</asp:ListItem>
                        <asp:ListItem Value="02">财政与主管部门共同下达</asp:ListItem>
                        <asp:ListItem Value="03">主管部门直接下达</asp:ListItem>
                    </asp:DropDownList>
    </p>
 
        <table width="100%" id="tb">
       
            <tr>
               <td align="right">
                    资金使用单位 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_COMPANY" uid="txtPD_QUOTA_COMPANY" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red" udi="fdsafa">*</span>
                </td>
                <td align="right" style="height: 30px;">
                    发文日期 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_QUOTA_FWDATA" uid="txtPD_QUOTA_FWDATA" 
                            class="easyui-datebox" runat="server" dateid="date" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <input type="button" value="查询" id="Button2" />
                </td>
                
             
                <td align="right">
                    监管依据 ：
                </td>
                <td align="left">
                 
                    <asp:TextBox ID="txtPD_QUOTA_BASIS_JG" runat="server" Width="200px" rdonly="1" ></asp:TextBox>
                      <span style="color: Red">*</span>
                </td>
            </tr>
            
        </table>
    <br />
    
    
    
    <input type="text" id="txtPD_INSPECTION_DATE" uid='txtPD_INSPECTION_DATE' 
                                class="easyui-datebox" readonly="readonly"
                        runat="server" style="width: 205px;" />
                        <input type="button"  id="btns" value="查询"/>
    <br />
    <%--  <div>
        <table>
            <tr>
                <td colspan="2" style="height: 21px">
                    使用标准HTML来进行图片上传
                </td>
            </tr>
            <tr>
                <td style="width: 400px">
                    <input id="InputFile" style="width: 399px" type="file" runat="server" />
                </td>
                <td style="width: 80px">
                    <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClick="UploadButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Lb_Info" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <input type="text" id="txtPD_CONTRACT_DATE" data-options="formatter:myformatter,parser:myparser"
        class="easyui-datebox" uid='txtPD_CONTRACT_DATE' readonly="readonly" runat="server"
        style="width: 200px;" /><span style="color: Red">*</span>--%>
    <br />
    <br />
    <table id="zxzb_bt" runat="server">
        <tr>
            <td>
                <div id='upfile10000' style='width: 100%' onmouseover="MouseOnRowIndex=10000">
                    <div id='ShowDIV10000' class="filetxt" style="background-color: Red;">
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
    <div style='width: auto; margin-left: -10px; height: 21px; border: thin solid #899aa1;'>
        <a style='cursor: hand; float:left;' uid="ImgDeleteFile" href="\"javascript:void(0);\" onclick='DownFile(this);'>
            fdsaf</a>
            <div style="background:red; width:30px; height:21px; float:left;" ></div>
            </div>
            <img  src="" onclick=""  style="cursor:pointer; float:left; margin-top:3px; margin-left:5px;"/>
            
            
            <br />
            <br />
                 <div style="width: 263px; height: 270px; border: 1px solid #c0daf9; margin-top: 5px;">
                        <p style="margin-top: -7px; margin-left: 70px;  background-color: White; color:#333;  font-weight:bold; width: 90px;">
                            项目施工照片</p>
                        <div id="demoContent">
                            <div class="ms">
                                描述：<input type="text" id="inp_discript" value="描述" />&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <input type="button"  id="btn_save" value="保存" /></div>
                            <div class="effect">
                                <div id="focusAd" class="tv-slideBox">
                                    <a class="prev"></a><a class="next"></a>
                                    <div class="bd">
                                        <ul>
                                            <li class="li1">
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
                                            </li>
                                                                                        <li class="li1">
                                                <div class="pic" img="no_imgs">
                                                    <a href="#" target="_self">
                                                        <img src="../../../jquery.easyui/imgload/images/no_img.png" title="信息公开5"/></a></div>
                                            </li>
                                            
                                                                                        <li class="li1">
                                                <div class="pic" img="no_imgs">
                                                    <a href="#" target="_self">
                                                        <img src="../../../jquery.easyui/imgload/images/no_img.png" title="信息公开5"/></a></div>
                                            </li>
                                         
                                        </ul>
                                    </div>
                                </div>

                                <script language="javascript"> jQuery("#focusAd").slide({ mainCell: ".bd ul", effect: "leftLoop", autoPlay: false, titOnClassName: "on" });</script>

                                <!--[if IE 6]>
				<script type="text/javascript" src="DD_belatedPNG.js"></script>
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
                                        
                                        <input id="InputFile" name ="file1" style="width:239px;  margin-bottom:5px;" type="file" />
                                        <input type="button" id="button1" value="上传图片" onclick="imgup(this)" /><%--
                                      <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClientClick="$(input[uid='ibtid'].get(0).value='UploadButton')"  OnClick="UploadButton_Click" />--%>
                                        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                <input type="button" id="img_delete" value="图片删除" /></div>
                        </div>
                    </div>
    </form>
</body>
</html>
