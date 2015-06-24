<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" validaterequest="false" CodeBehind="SbMx.aspx.cs" inherits="Work_GL_SbMx" title="" enableEventValidation="false" stylesheettheme="Default" %>

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

    <script src="../../jss/ImageFileUp.js" type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="../../jss/XMGL/projSbMx.js" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <link href="../../css/QiPao.css" rel="stylesheet" type="text/css" />

    <script src="../../Ext/j/jquery.scrollfollow.js" type="text/javascript"></script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../jquery.easyui/css/icon.css" />

    <script src="../../Ext/j/jquery.tmpl.min.js" type="text/javascript"></script>

    <script id="myTemplate" type="text/x-jquery-tmpl"> 
        <tr><td>{{html CHECKBOX}}</td><td>{{html PD_BASE_TZJGC}}</td><td>{{html TB_QUOTA_CODE}}</td><td>{{html PD_PROJECT_MONEY_CZ_SJ}}</td><td>{{html PD_GK_DEPART}}&nbsp;</td><td>{{html PD_PROJECT_FILENO_JG}}&nbsp;</td><td>{{html PD_PROJECT_ZJLY}}&nbsp;</td><td>{{html PD_PROJECT_ZGKJ}}&nbsp;</td></tr> 
    </script>

    <script id="getZjgcSelect" type="text/x-jquery-tmpl"> 
        <option value="${Id}">${Name}</option>
    </script>

    <script type="text/javascript">
        function checkFileChange(obj) {
            var img = $(".img")[0];
            var file = obj.value;
            var exp = /.\.jpg|.\.gif|.\.png|.\.bmp/i;
            try {
                if (exp.test(file)) {
                    $('.img').attr("src", file);
                }
                else {
                    alert("图片格式不正确");
                }
            } catch (e) {
                // alert(e);
            }

        }
        //wr
        function Img_FileUp(obj, input, TempFile, Pk, Temclass_id)//选取值后的file控件，第几个，选取的文件名称
        {
            try {
                var inputFather = input.parentNode;
                input.style.display = "block";
                var body = document.body; //页面body
                var name = input.id;//fileName
                var iframename = "iframe" + name;//框架iframe的名称
                var iframe;//框架
                var form = document.createElement('form');//创建表单
                var upedfilename;//上传后文件名称
                var file_name = '';

                //创建iframe
                iframe = document.createElement(info.ie ? "<iframe name=\"" + iframename + "\">" : "iframe");
                if (info.ie) {
                    document.createElement("<iframe name=\"" + iframename + "\">");
                }
                else {
                    document.createElement("iframe");
                }
                iframe.name = iframename;
                iframe.style.display = "none";
                //插入body
                body.insertBefore(iframe, body.childNodes[0]);

                //设置form
                var UrlZX = "";
                if (TempFile != null && TempFile != "")
                    UrlZX = TempFile;
                form.name = "form" + name;//表单名称
                form.target = iframename;
                form.method = "post";
                form.encoding = "multipart/form-data";
                form.action = "/WebControls/UserControl/Fileup.ashx" + UrlZX;

                body.insertBefore(form, body.childNodes[0]);
                //添加控件进form
                form.appendChild(input);

                //定义iframe 的onload事件
                if (info.ie)//IE 需要注册onload事件
                {
                    iframe.attachEvent("onload", CallBack);
                }
                else {
                    iframe.onload = CallBack;
                }
                //提交 --------------------------------------------------
                form.submit();
                //提交完毕-----------------------------------------------
            } catch (e) { alert(e); }
            function CallBack()//iframe加载完成，返回结果处理
            {
                try {
                    var jsLang = Temclass_id;
                    switch (jsLang) {
                        case 'app1':
                            $(".app1").append(input);
                            input.style.display = "block";
                            break;
                        case 'app2':
                            $(".app2").append(input);
                            input.style.display = "block";
                            break;
                        case 'app3':
                            $(".app3").append(input);
                            input.style.display = "block";
                            break;
                        default:
                    }


                } catch (e) { alert(e) }

                try {
                    var value = iframe.contentWindow.document.body.innerHTML;
                    upedfilename = value.substring(value.indexOf("@returnstart@") + 13, value.indexOf("@returnend@"));
                    file_name = upedfilename;
                    if (upedfilename == "000") {
                        //alert("图片路径不能为空。请先上传图片！");
                        return;
                    }
                    if (upedfilename.length > 3)//正常上传，返回上传后文件名
                    {
                        finished();
                        file_name = upedfilename;
                        return upedfilename;
                    }
                    else//停止上传，从StopUpLoad.ashx页面返回空值，也可能是返回错误001，000
                    {
                        alert('上传完成');
                        if (Temclass_id == "app1") {
                            //   alert(file_name+"11");
                            document.getElementById('<%=txt_InputFile1.ClientID%>').value = $('#InputFile1').val() + "||" + file_name;

                }
                if (Temclass_id == "app2") {
                    document.getElementById('<%=txt_InputFile2.ClientID%>').value = $('#InputFile2').val() + "||" + file_name;

                }
                if (Temclass_id == "app3") {
                    document.getElementById('<%=txt_InputFile3.ClientID%>').value = $('#InputFile3').val() + "||" + file_name;

                }
            }
        }
        catch (msg) {
            alert("上传失败");
        }
    }
    function finished()//上传完毕
    {
        alert('上传完成');
        file_name = upedfilename;
        if (Temclass_id == "app1") {
            // alert(file_name+"11");
            document.getElementById('<%=txt_InputFile1.ClientID%>').value = $('#InputFile1').val() + "||" + file_name;

        }
        if (Temclass_id == "app2") {
            document.getElementById('<%=txt_InputFile2.ClientID%>').value = $('#InputFile2').val() + "||" + file_name;

        }
        if (Temclass_id == "app3") {
            document.getElementById('<%=txt_InputFile3.ClientID%>').value = $('#InputFile3').val() + "||" + file_name;

        }

    }




}



//图片预览2013-4-1 【wr】
function Preview_Image(imgFile, id, input_id, class_id) {

    var filextension = imgFile.value.substring(imgFile.value.lastIndexOf("."), imgFile.value.length);
    filextension = filextension.toLowerCase();
    if ((filextension != '.jpg') && (filextension != '.gif') && (filextension != '.jpeg') && (filextension != '.png') && (filextension != '.bmp')) {
        alert("对不起，系统仅支持标准格式的照片，请您调整格式后重新上传，谢谢 !");
        imgFile.focus();
    }
    else {
        var path;
        if (document.all)//IE
        {
            imgFile.select();
            path = document.selection.createRange().text;

            try {

                document.getElementById(id).innerHTML = "";
                document.getElementById(id).style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled='true',sizingMethod='scale',src=\"" + path + "\")";//使用滤镜效果
                Img_FileUp(imgFile, $("#" + input_id + "").get(0), "?filepath=UserImages", "", class_id);
            }
            catch (e) {
                alert(e);
            }

        }
        else//FF
        {
            path = imgFile.files[0].getAsDataURL();
            //document.getElementById("imgPreview").innerHTML = "<img id='upimg' width='120px' height='100px' src='"+path+"'/>";
            document.getElementById("upimg2").src = path;
        }

    }
}
    </script>

    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        var selectPD_YEAR_id = "<%=ddlPD_YEAR.ClientID %>";
        var selectPD_FOUND_XZ_id = "<%=ddlPD_FOUND_XZ.ClientID %>";
        var selectPD_PROJECT_TYPE_id = "<%=ddlPD_PROJECT_TYPE.ClientID %>";
        var txtPD_PROJECT_BEGIN_DATE = "<%=txtPD_PROJECT_BEGIN_DATE.ClientID %>";
        var txtPD_PROJECT_END_DATE = "<%=txtPD_PROJECT_END_DATE.ClientID %>";
        var txtPD_PROJECT_YEARS = "<%=txtPD_PROJECT_YEARS.ClientID %>";
    </script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script type="text/javascript">
        function findwindow(val, obj) {
            var webFileUrl = "";
            var shMod_cs = "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0";
            var _td = obj.parentNode;
            var _tr = _td.parentNode;
            switch (val.toString()) {
                case "1":
                    var PD_BASE_TZJGC = $("#PD_BASE_TZJGC", _tr).eq(0).val();
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=pd_DuoZhiBiao&xz=01&company_code=true&TZJGC=" + PD_BASE_TZJGC;
                    break;
                case "open_pd_quotaAddMoney":
                case "ProjectBXK":
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&xz=01&company_code=true";
                    //shMod_cs = "dialogWidth:400px; dialogHeight:400px;resizable:0; help:0; status:0";
                    break;
                case "FG":
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                    break;
                default:
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                    break;
            }
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, shMod_cs);
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    switch (val.toString()) {
                        case "1":
                            ss = arr.split("~");
                            var IsContinue = false;
                            $("input#TB_QUOTA_CODE", _tr.parentNode).each(function () {
                                if (this.value == ss[0]) {
                                    IsContinue = true;
                                    return false;
                                }
                            });
                            if (IsContinue) {
                                alert("此指标已经选择过，不能重复选择！");
                                return;
                            }

                            obj.value = ss[1];
                            $("input#TB_QUOTA_CODE", _td).eq(0).val(ss[0]);
                            $("input#PD_PROJECT_MONEY_CZ_SJ", _tr).eq(0).val(ss[2]);
                            $("a#PD_GK_DEPART_A", _tr).get(0).innerHTML = ss[4];
                            $("a#PD_PROJECT_FILENO_JG_A", _tr).get(0).innerHTML = ss[5];
                            $("a#PD_PROJECT_ZJLY_A", _tr).get(0).innerHTML = ss[6];
                            $("a#PD_PROJECT_ZGKJ_A", _tr).get(0).innerHTML = ss[7];

                            //	                            $("input#PD_GK_DEPART",_tr).get(0).innerHTML=ss[4];
                            //	                            $("input#PD_PROJECT_FILENO_JG",_tr).get(0).innerHTML=ss[5];
                            //	                            $("input#PD_PROJECT_ZJLY",_tr).get(0).innerHTML=ss[6];
                            //	                            $("a#PD_PROJECT_ZGKJ",_tr).get(0).innerHTML=ss[7];

                            //求和
                            setTimeout(SumMoney_TZGC(), 0);
                            //alert(arr);
                            break;
                            //                            case "open_pd_quotaAddMoney":
                            //	                            ss=arr.split("~");
                            //	                            obj.value=ss[1];
                            //	                            $("input[uid='txtPD_PROJECT_FILENO_PF']").get(0).value=ss[0];
                            //	                            
                            //	                            if(ss[2]=='')
                            //	                                ss[2]=0;
                            //	                            $("input[uid='txtPD_PROJECT_MONEY_CZ_SJ']").get(0).value=$("input[uid='txtPD_PROJECT_MONEY_CZ_SJ_PF']").get(0).value=ss[2];
                            //                                $("select[uid='ddlPD_GK_DEPART']").get(0).value=ss[3];
                            //                                $("input[uid='txtPD_PROJECT_FILENO_JG']").get(0).value=ss[5];
                            //                                $("select[uid='ddlPD_PROJECT_ZJLY']").get(0).value=ss[6];
                            //                                $("select[uid='ddlPD_PROJECT_ZGKJ']").get(0).value=ss[7];
                            //                                
                            //	                            Sum_sqzjze();
                            break;
                        case "FG":
                            ss = arr.split("~");
                            $("input[uid='txtPD_PROJECT_FILENO_JG']").get(0).value = ss[1];
                            break;
                        case "ProjectBXK":
                            ss = arr.split("~");
                            windowFull();
                            window.location.href = "SbMx.aspx?CreatePK=" + ss[0];
                            return false;
                    }
                }
            }
        }
        function imgup(obj) {
            ImgFileUp(obj, $('#InputFile').get(0), "?filepath=UserImages", 0);
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

        //乡镇,村,组三级联动 var xmlhttp = null;
        function province(va) {

            checkName("Handler.ashx?type=Xiang&id=" + va, processCity);



        }
        function areaTmp(vArea) {

            checkName("Handler.ashx?type=Cun&id=" + vArea, processArea);
        }


        function checkName(url, method) {
            createHttpReq();
            xmlhttp.onreadystatechange = method;
            xmlhttp.open("get", url, true);
            xmlhttp.send(null)
        }
        function createHttpReq() {
            if (window.XMLHttpRequest) {
                xmlhttp = new XMLHttpRequest();
            }
            else {
                if (window.ActiveXObject) {
                    try {
                        xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
                    }
                    catch (e) {
                        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                    }
                }
            }

        }
        function processArea() {
            if (xmlhttp.readyState == 4) {
                if (xmlhttp.status == 200) {
                    var f = document.getElementById("<%=ddlPD_PROJECT_GROUP.ClientID %>");
                var list = xmlhttp.responseText;
                var classList = list.split("|");
                f.options.length = 0;
                for (var i = 0; i < classList.length; i++) {
                    var tmp = classList[i].split(",");
                    f.add(new Option(tmp[0], tmp[1]));
                }


            }
        }
    }
    function processCity() {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                var f = document.getElementById("<%=ddlPD_PROJECT_VILLAGE.ClientID %>");
            var list = xmlhttp.responseText;
            var classList = list.split("|");
            f.options.length = 0;
            for (var i = 0; i < classList.length; i++) {
                var tmp = classList[i].split(",");
                f.add(new Option(tmp[0], tmp[1]));
            }

        }
    }
}
    </script>

    <input type="hidden" id="txtPD_PROJECT_MONEY_CZ_SJ" uid="txtPD_PROJECT_MONEY_CZ_SJ"
        runat="server" />
    <input type="hidden" id="txtPD_PROJECT_MONEY_CZ_BJ" uid="txtPD_PROJECT_MONEY_CZ_BJ"
        runat="server" />
    <input type="hidden" id="txtPD_PROJECT_MONEY_ZC" uid="txtPD_PROJECT_MONEY_ZC" runat="server" />
    <input type="hidden" id="txtPD_PROJECT_MONEY_QT" uid="txtPD_PROJECT_MONEY_QT" runat="server" />
    <input type="hidden" id="HdFree1" uid="HdFree1" runat="server" />
    <div class="container" id="D_ShowText" style="position: absolute; top: 1px; left: 1px;display: none; z-index:999999999999; ">
        <div class="content">
            <br />
            点击“放大镜”可参照项目备选库中选择生成</div>
        <s><i></i></s>
    </div>
    <div id="top1" style="text-align: left;">
        <!--上级指标文号 ：-->
        <input id="lblPD_PROJECT_FILENO_PF" readonly="readonly" uid="lblPD_PROJECT_FILENO_PF"
            runat="server" style="width: 200px; display: none;" rdonly="1" onclick="javascript: findwindow('open_pd_quotaAddMoney', this);" />
        <input type="hidden" id="txtPD_PROJECT_FILENO_PF" uid="txtPD_PROJECT_FILENO_PF" runat="server" />
        <asp:TextBox ID="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server" Width="200px"
            Style="display: none;" onchange="findcompany(this)"></asp:TextBox>
        <table id="tb_top" border="0" style="text-align: left;">
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    项目年度 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_YEAR" runat="server" Width="206">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    项目名称 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_NAME" uid="txtPD_PROJECT_NAME" QiPao="true" runat="server"
                        Width="182px" Height="17px" Style="border-right-style: none; float: left;"></asp:TextBox>
                    <img id="imgSearch" runat="server" class="search-img" src="../../jquery.easyui/css/images/search.png" style="float: left;
                        margin-left: -3px; cursor: pointer;" onclick="findwindow('ProjectBXK',this);" />
                    <span style="color: Red">*</span>
                    <div id="div_showBXK" runat="server">
                        <%--  <a href="###" onclick="findwindow('ProjectBXK',this);">从项目备选库中选择</a>--%>
                    </div>
                </td>
                <td style="width: 130px;" align="right">
                    <%--资金来源 ：              --%>
                    项目建设状态 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_STATUS" runat="server" Width="206">
                    </asp:DropDownList>
                    <%--
                    <asp:DropDownList ID="ddlPD_PROJECT_ZJLY" uid="ddlPD_PROJECT_ZJLY" runat="server"
                        Width="206">
                        <asp:ListItem Value="01">财政部门直接下达</asp:ListItem>
                        <asp:ListItem Value="02">财政与主管部门共同下达</asp:ListItem>
                        <asp:ListItem Value="03">主管部门直接下达</asp:ListItem>
                    </asp:DropDownList>                --%>
                </td>
            </tr>
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    项目类别 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_TYPE" runat="server" Width="206">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    是否乡镇直接管理 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFXZGL" runat="server" Width="206">
                    </asp:DropDownList>
                </td>
                <td style="width: 130px;" align="right">
                    资金性质 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_FOUND_XZ" uid='ddlPD_FOUND_XZ' runat="server" Width="206"
                        Enabled="false">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <%--
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                     主管科局 ：              </td>
                <td align="left"> 
                    <asp:DropDownList ID="ddlPD_PROJECT_ZGKJ" uid="ddlPD_PROJECT_ZGKJ" runat="server"
                        Width="206">                    </asp:DropDownList>                </td>
                <td height="30" align="right">&nbsp;</td>
                <td height="30" align="left">&nbsp;</td>
                <td height="30" align="right">&nbsp;</td>
                <td height="30" align="left">&nbsp;</td>
            </tr>--%>
            <tr>
                <td height="30" align="right">
                    是否公示 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFGS" runat="server" Width="206">
                    </asp:DropDownList>
                </td>
                <td height="30" align="right">
                    是否事前公示 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFGS_BEFORE" runat="server" Width="206">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    公示主体 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_PROJECT_OPEN_BODY" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    项目负责人 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_FZR" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    财务负责人 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_CWFZR" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    受益人数 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_SYRS" runat="server" Width="200px" onkeydown="return onlyNum3(this);"
                        onKeyPress="myKeyDown(this,event,1)" CssClass="NumTextCss"></asp:TextBox>
                    <asp:TextBox ID="txtPD_PROJECT_FILENO_LX" runat="server" Width="200px" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    计划开工日期 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_BEGIN_DATE" data-options="formatter:myformatter,parser:myparser"  rdonly='1'
                        class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    计划完工日期 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_END_DATE" data-options="formatter:myformatter,parser:myparser"  rdonly='1'
                        class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>
                    <%--<input type="button" value="ceshi" onclick="alert(this.parentNode.innerHTML)" />--%>
                </td>
                <td height="30" align="right">
                    项目建设时限 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_YEARS" runat="server" Enabled="false" Width="200px"></asp:TextBox>
                    &nbsp;月
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    村名：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="pd_project_cm" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    投资总额：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_MONEY_TOTAL" uid='txtPD_PROJECT_MONEY_TOTAL_PF' runat="server"
                        Width="200px" Enabled="false" onKeyPress="myKeyDown(this,event,0)" CssClass="NumTextCss"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    财政资金总额：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_MONEY_CZ_TOTAL" uid='txtPD_PROJECT_MONEY_CZ_TOTAL_PF'
                        runat="server" Width="200px" Enabled="false" onKeyPress="myKeyDown(this,event,0)" CssClass="NumTextCss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    项目结算金额：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="FREE8" runat="server" Width="200px" Text="0"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    资金到位率：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="pd_project_jsje" runat="server" Width="200px" rdonly=1></asp:TextBox>
                </td>
                <td height="30" align="right">
                </td>
                <td height="30" align="left">
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    <%-- 监管依据 ：                --%>
                </td>
                <td height="30" align="left" colspan="5">
                    <%-- <asp:TextBox ID="txtPD_PROJECT_FILENO_JG" uid="txtPD_PROJECT_FILENO_JG" runat="server"
                        Width="600px" rdonly="1" onclick="javascript:findwindow('FG',1);"></asp:TextBox>                 --%>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="项目概况">
            <HeaderTemplate>
                项概目况
            </HeaderTemplate>
            <ContentTemplate>
                <table cellpadding="4" style="width: 100%;">
                    <tr>
                        <td height="30" style="text-align: right;">
                            项目建设地点：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="ddlPD_PROJECT_COUNTRY" runat="server" Width="600px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <%--  <asp:DropDownList ID="ddlPD_PROJECT_COUNTRY"   runat="server" onchange="province(this.value)" Visible=false
                                Width="150px">
                            </asp:DropDownList>--%>
                            <select id="ddlPD_PROJECT_VILLAGE" runat="server" onchange="areaTmp(this.value)"
                                visible="false" style="width: 150px">
                            </select>
                            <select id="ddlPD_PROJECT_GROUP" runat="server" style="width: 150px" visible="false">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top;">
                            主要建设内容：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="txtPD_PROJECT_CONTENT" runat="server" Width="93%" Height="50px"
                                TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top;">
                            实施范围：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="txtPD_PROJECT_SSFW" runat="server" Width="93%" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top;">
                            项目用途：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="txtPD_PROJECT_XMYT" runat="server" Width="93%" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 130px;">
                            项目申报日期：
                        </td>
                        <td align="left" style="height: 30px;">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_DATE" runat="server" Width="200px" data-options="formatter:myformatter,parser:myparser"
                        class="easyui-datebox"  rdonly='1'></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报单位：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_COMPANY" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="ShowPD_PROJECT_INPUT_COMPANY" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报经办人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_MAN" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="ShowPD_PROJECT_INPUT_MAN" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目申报部门 ：
                        </td>
                        <td align="left" style="height: 30px;">
                            <asp:TextBox ID="txtdepart" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                        </td>
                        <td align="left">
                        </td>
                        <td style="text-align: right; width: 130px;">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="投资及构成">
            <ContentTemplate>
                <div uid='add_del_button' style="text-align: left; padding: 5px 10px;">
                    <a href="javascript:void(0)" onclick='tb_tzgc_Add("tb_tzjgc_1")'>
                        <img src="../../images/AddRow.png" /></a> &nbsp;&nbsp;&nbsp;&nbsp; <a href="javascript:void(0)"
                            onclick='tb_tzgc_Del("tb_tzjgc_1");'>
                            <img src="../../images/DelRow.png" /></a>
                </div>
                <div id="div1" uname="div_file">
                    <table id="tb_tzjgc_1" style="text-align: center;" border="1" cellpadding="4" cellspacing="0">
                        <tr style="background: #E9E9E9; height: 31px;">
                            <th style="width: 30px; text-align: center;">
                                选择
                            </th>
                            <th style="width: 150px; text-align: center;">
                                投资构成
                            </th>
                            <th style="width: 150px; text-align: center;">
                                上级指标文号
                            </th>
                            <th style="width: 150px; text-align: center;">
                                下达金额
                            </th>
                            <th style="width: 150px; text-align: center;">
                                归口部门
                            </th>
                            <th style="width: 150px; text-align: center;">
                                监管依据
                            </th>
                            <th style="width: 150px; text-align: center;">
                                资金来源
                            </th>
                            <th style="width: 150px; text-align: center;">
                                主管科局
                            </th>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_ztbgl" runat="server" HeaderText="项目实施监控">
            <ContentTemplate>
                <div id="div2" uname="div_file">
                    <div style="text-align: left; float: left; width: 400px;">
                        <table style="text-align: left; vertical-align: top; width: auto">
                            <tr>
                                <td style="text-align: right; width: 200px; height: 30px;">
                                    是否完成实施方案编制：
                                </td>
                                <td style="width: 70px;">
                                    <asp:TextBox Enabled="false" ID="lblAUTO_NO" runat="server" Width="70" CssClass="label"
                                        Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="ddlPD_PROJECT_ZTB_IF_SSFA" runat="server" Width="170px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; height: 30px;">
                                    是否招投标：
                                </td>
                                <td style="width: 70px;">
                                    <asp:DropDownList ID="ddlPD_PROJECT_ZTB_IF_ZTB" runat="server" Width="170px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;">
                                    &nbsp;
                                </td>
                                <td rowspan="6">
                                    <%-- <ul style="list-style: none;" id="ulimg" runat="server">
                                        <li>
                                            <div id="imgPreview" style="width: 230px; height: 230px;">
                                                <img id="upimg" src="../../userImages/sgt.jpg" style="width: 230px; height: 230px;" />
                                            </div>
                                        </li>
                                    </ul>--%>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; height: 30px;">
                                    招标方式：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPD_PROJECT_ZTB_STYLE" runat="server" Width="170px">
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
                                    <asp:DropDownList ID="ddlPD_PROJECT_ISCONTRACT" runat="server" Width="170px">
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
                                    <asp:TextBox ID="txtPD_PROJECT_XXJD" runat="server" Width="150px" onKeyPress="myKeyDown(this,event,0)" CssClass="NumTextCss"></asp:TextBox>&nbsp;%
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
                                <td align="center" colspan="2">
                                    <%--  <div style="clear: both;">
                                        <input id="InputFile" name="file1" style="width: 239px; margin-bottom: 5px;" type="file"
                                            onchange='PreviewImage(this)' />
                                        <div style="display: none;">
                                            <asp:TextBox ID="txt_file" runat="server"></asp:TextBox></div>
                                        <input type="button" id="button1" class="up_imgsinput"  value="上传图片" onclick="imgup(this)" /></div>--%>
                                    <asp:TextBox ID="txt_file" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; width: auto; height: auto; margin-top: 8px; overflow: auto;">
                        <div style="float: left; width: 250px; height: 250px;">
                            <p style="text-align: left; margin-left: 7px;">
                                现场施工照片(一)：</p>
                            <div>
                                <div id="imgPreview1" style="width: 230px; height: 230px;">
                                    <div runat="server" id="img_p1">
                                        <img id="upimg1" src="../../jquery.easyui/imgload/images/no_img.png" style="width: 230px;
                                            height: 230px;" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:TextBox ID="txt_InputFile1" runat="server"></asp:TextBox></div>
                            <div class="app1">
                                <input id="InputFile1" name="file1" style="width: 230px; margin-top: 5px;" type="file"
                                    onchange='Preview_Image(this,"imgPreview1","InputFile1","app1")' />
                            </div>
                        </div>
                        <div style="float: left; width: 250px; height: 250px;">
                            <p style="text-align: left; margin-left: 7px;">
                                现场施工照片(二)：</p>
                            <div>
                                <div id="imgPreview2" style="width: 230px; height: 230px;">
                                    <div runat="server" id="img_p2">
                                        <img id="upimg2" src="../../jquery.easyui/imgload/images/no_img.png" style="width: 230px;
                                            height: 230px;" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:TextBox ID="txt_InputFile2" runat="server"></asp:TextBox></div>
                            <div class="app2">
                                <input id="InputFile2" name="file1" style="width: 230px; margin-top: 5px;" type="file"
                                    onchange='Preview_Image(this,"imgPreview2","InputFile2","app2")' />
                            </div>
                        </div>
                        <div style="float: left; width: 250px; height: 250px;">
                            <p style="text-align: left; margin-left: 7px;">
                                现场施工照片(三)：</p>
                            <div>
                                <div id="imgPreview3" style="width: 230px; height: 230px;">
                                    <div runat="server" id="img_p3">
                                        <img id="upimg3" src="../../jquery.easyui/imgload/images/no_img.png" style="width: 230px;
                                            height: 230px;" /></div>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:TextBox ID="txt_InputFile3" runat="server"></asp:TextBox></div>
                            <div class="app3">
                                <input id="InputFile3" name="file1" style="width: 230px; margin-top: 5px;" type="file"
                                    onchange='Preview_Image(this,"imgPreview3","InputFile3","app3")' />
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div style="height: 50px; width: 500px;">
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <!--项目竣工验收-->
        <cc1:TabPanel ID="Panel_jgys" runat="server" closable="False" HeaderText="项目竣工验收情况">
            <HeaderTemplate>
                项目竣工验收情况
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Label ID="lblAUTO_NO_JGYS" runat="server" Visible="false" CssClass="label"></asp:Label>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right" style="height: 40px;">
                            项目竣工日期：
                        </td>
                        <td align="left">
                            <input id="txtPD_PROJECT_COMPLETE_DATE" readonly="readonly" style="width: 200px"
                                data-options="formatter:myformatter,parser:myparser" class="easyui-datebox" runat="server"
                                uid="txtPD_PROJECT_COMPLETE_DATE" runat="server" />
                        </td>
                        <td align="right">
                            项目验收申请日期：
                        </td>
                        <td align="left">
                            <input id="txtPD_PROJECT_YSSQ_DATE" uid="txtPD_PROJECT_YSSQ_DATE" runat="server"
                                data-options="formatter:myformatter,parser:myparser" class="easyui-datebox" style="width: 200px;"
                                readonly="readonly" />
                        </td>
                        <td align="right" style="width: 130px; height: 30px;">
                            项目验收日期：
                        </td>
                        <td align="left">
                            <input id="txtPD_PROJECT_YS_DATE" uid="txtPD_PROJECT_YS_DATE" runat="server" style="width: 200px;"
                                data-options="formatter:myformatter,parser:myparser" class="easyui-datebox" readonly="readonly" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 130px; height: 30px;">
                            项目验收单位：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlPD_PROJECT_YS_COMPANY" uid="ddlPD_PROJECT_YS_COMPANY" runat="server"
                                disabled="disabled" Style="width: 206px;">
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 130px; height: 30px;">
                            项目验收责任人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_YS_ZRR" uid="txtPD_PROJECT_YS_ZRR" runat="server"
                                Style="width: 200px;"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 130px; height: 30px;">
                            项目验收结论：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlPD_PROJECT_YS_RESULT" uid="ddlPD_PROJECT_YS_RESULT" runat="server"
                                Style="width: 206px;">
                                <asp:ListItem Text="合格" Value="合格"></asp:ListItem>
                                <asp:ListItem Text="不合格" Value="不合格"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 40px;">
                            项目验收人员名单：
                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox ID="txtPD_PROJECT_YS_NAME" uid="txtPD_PROJECT_YS_NAME" runat="server"
                                Width="100%"></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 40px;">
                            项目验收意见：
                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox ID="txtPD_PROJECT_YS_SUGGEST" uid="txtPD_PROJECT_YS_SUGGEST" runat="server"
                                Width="100%" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td align="right" style="height: 40px;">
                            <%--项目验收结论：--%>
                        </td>
                        <td align="left">
                            <%--<asp:DropDownList ID="ddlPD_PROJECT_YS_RESULT" uid="ddlPD_PROJECT_YS_RESULT" runat="server"
                                Style="width: 206px;">
                                <asp:ListItem Text="合格" Value="合格"></asp:ListItem>
                                <asp:ListItem Text="不合格" Value="不合格"></asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 40px;">
                            存在主要问题整改：
                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox ID="txtPD_PROJECT_YS_CONDITION" uid="txtPD_PROJECT_YS_CONDITION" runat="server"
                                Width="100%" Rows="4" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_HeTong" runat="server" HeaderText="合同信息列表" Width="200px">
            <HeaderTemplate>
                合同信息列表
            </HeaderTemplate>
            <ContentTemplate>
                <yyc:SmartGridView ID="gvResult_HeTong" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" CssClass="tKeepAll">
                    <Columns><%--
                        <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="PD_CONTRACT_TYPE_NAME" HeaderText="合同类型" SortExpression="PD_CONTRACT_TYPE">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="PD_CONTRACT_NO" HeaderText="合同编号" SortExpression="PD_CONTRACT_NO">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="PD_CONTRACT_MONEY" HeaderText="合同金额" SortExpression="PD_CONTRACT_MONEY"
                            Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_CHANGE_MONEY" HeaderText="合同金额" SortExpression="PD_CONTRACT_CHANGE_MONEY">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_CHANGE_DATE" HeaderText="变更时间" SortExpression="PD_CONTRACT_CHANGE_DATE">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_CHANGE_TYPE_NAME" HeaderText="变更类型" SortExpression="PD_CONTRACT_CHANGE_TYPE">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_CHANGE_REASON" HeaderText="变更原因" SortExpression="PD_CONTRACT_CHANGE_REASON">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PD_CONTRACT_CHANGE_ZJ" HeaderText="调增调减" SortExpression="PD_CONTRACT_CHANGE_ZJ"
                            Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_zjbf" runat="server" HeaderText="资金拨付列表">
            <HeaderTemplate>
                资金拨付列表
            </HeaderTemplate>
            <ContentTemplate>
                <yyc:SmartGridView ID="gvResult_zjbf" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" CssClass="tKeepAll">
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_gkgs" runat="server" HeaderText="项目建设资金公开公示列表" Width="200px">
            <HeaderTemplate>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                项目建设资金公开公示列表 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </HeaderTemplate>
            <ContentTemplate>
                <yyc:SmartGridView ID="gvResult_gkgs" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" CssClass="tKeepAll">
                    <Columns><%--
                        <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center"
                            Visible="false" />--%>
                        <%-- <asp:TemplateField HeaderText="自动序号" Visible="true" SortExpression="KPDETAILID"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="AUTO_NO" runat="server" Text='<%#Eval("AUTO_NO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%><%--
                        <asp:BoundField DataField="PD_PROJECT_CODE" HeaderText="项目编码" SortExpression="PD_PROJECT_CODE"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_YEAR" HeaderText="项目年度" SortExpression="PD_YEAR">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                        <%--  <asp:BoundField DataField="PD_GS_TYPE" HeaderText="公示类型" SortExpression="PD_GS_TYPE"
                            ItemStyle-HorizontalAlign="Center" />--%>
                        <asp:TemplateField HeaderText="公示类型" SortExpression="PD_GS_TYPE" ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="labPD_GS_TYPE" runat="server" Text='<%# getComfirm(Eval("PD_GS_TYPE")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PD_GS_STYLE" HeaderText="公示形式" SortExpression="PD_GS_STYLE"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_GS_ZHUTI" HeaderText="公示主体" SortExpression="PD_GS_ZHUTI"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_GS_DATE" HeaderText="公示时间" SortExpression="PD_GS_DATE"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_GS_ADDR" HeaderText="公示地点" SortExpression="PD_GS_ADDR"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_GS_FILENAME" HeaderText="附件文件名" SortExpression="PD_GS_FILENAME"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_GS_FILENAME_SYSTEM" HeaderText="附件系统文件名" SortExpression="PD_GS_FILENAME_SYSTEM"
                            Visible="false" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_GS_DETAIL" HeaderText="备注" SortExpression="PD_GS_DETAIL"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_xmxc" runat="server" HeaderText="项目建设资金巡查列表">
            <HeaderTemplate>
                项目建设资金巡查列表
            </HeaderTemplate>
            <ContentTemplate>
                <yyc:SmartGridView ID="gvResult_xmxc" runat="server" AutoGenerateColumns="False"
                    MouseOverCssClass="OverRow" CssClass="tKeepAll">
                    <Columns><%--
                        <asp:BoundField DataField="AUTO_NO" HeaderText="自动序号" SortExpression="AUTO_NO" ItemStyle-HorizontalAlign="Center"
                            Visible="false" />
                        <asp:BoundField DataField="PD_YEAR" HeaderText="年度" SortExpression="PD_YEAR" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="pd_project_name" HeaderText="项目名称" SortExpression="pd_project_name"
                            ItemStyle-HorizontalAlign="Center" />--%>
                        <asp:BoundField DataField="PD_INSPECTION_PROCESS" HeaderText="项目过程" SortExpression="PD_INSPECTION_PROCESS"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_DATE" HeaderText="监管时间" SortExpression="PD_INSPECTION_DATE"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_MANS" HeaderText="监管人员" SortExpression="PD_INSPECTION_MANS"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_ADDR" HeaderText="监管地点" SortExpression="PD_INSPECTION_ADDR"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_CONTENT" HeaderText="监管内容" SortExpression="PD_INSPECTION_CONTENT"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_SUGGEST" HeaderText="监管意见" SortExpression="PD_INSPECTION_SUGGEST"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_CONCLUSION" HeaderText="监管结论" SortExpression="PD_INSPECTION_CONCLUSION"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_FILENAME" HeaderText="监管资料" SortExpression="PD_INSPECTION_FILENAME"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_INSPECTION_FILENAME_SYSTEM" HeaderText="监管资料系统名" SortExpression="PD_INSPECTION_FILENAME_SYSTEM"
                            ItemStyle-HorizontalAlign="Center" />
                        <%--		            <asp:BoundField DataField="PD_INSPECTION_PEASANT" HeaderText="农户名称" SortExpression="PD_INSPECTION_PEASANT" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_IDNO" HeaderText="身份证号码" SortExpression="PD_INSPECTION_IDNO" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_FFNUM" HeaderText="补贴数量" SortExpression="PD_INSPECTION_FFNUM" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_FFSTAND" HeaderText="补贴标准" SortExpression="PD_INSPECTION_FFSTAND" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_FFMONEY" HeaderText="补贴金额" SortExpression="PD_INSPECTION_FFMONEY" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_ACCOUNTNO" HeaderText="发放账号" SortExpression="PD_INSPECTION_ACCOUNTNO" ItemStyle-HorizontalAlign="Center"  /> 
		            <asp:BoundField DataField="PD_INSPECTION_PEASANT_ADDR" HeaderText="农户家庭住址" SortExpression="PD_INSPECTION_PEASANT_ADDR" ItemStyle-HorizontalAlign="Center"  /> --%>
                        <asp:BoundField DataField="PD_MONITOR_PROCEED_WCL" HeaderText="项目进度完成比例" SortExpression="PD_MONITOR_PROCEED_WCL"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_PROJECT_TOTAL_MONEY" HeaderText="项目总投资额" SortExpression="PD_PROJECT_TOTAL_MONEY"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_MONITOR_TOTAL_MONEY_PAY" HeaderText="累计拨付总金额" SortExpression="PD_MONITOR_TOTAL_MONEY_PAY"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="PD_MONITOR_TOTAL_MONEY_WCL" HeaderText="总投资完成比例" SortExpression="PD_MONITOR_TOTAL_MONEY_WCL"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:ButtonField CommandName="two" Visible="False" />
                        <asp:ButtonField CommandName="Select" Visible="False" />
                    </Columns>
                </yyc:SmartGridView>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="Panel_xmpj" runat="server" closable="False" HeaderText="项目评价">
            <HeaderTemplate>
            </HeaderTemplate>
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr style="display: none;">
                        <td align="right" style="height: 30px; width: 130px;">
                            自动序号 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAUTO_NO_APPRAISE" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 30px; width: 130px;">
                            项目评价日期 ：
                        </td>
                        <td align="left">
                            <input id="txtPD_PROJECT_APP_DATE" runat="server" readonly="readonly" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 30px; width: 130px;">
                            评价组织单位 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_APP_COMPANY" runat="server" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 30px; width: 130px;">
                            评价参与单位 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_APP_COMPANY_LIST" runat="server" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 30px; width: 130px;">
                            评价参与人员 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_APP_MAN_LIST" runat="server" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="display: none;" style="height: 30px; width: 130px;">
                        <td align="right">
                            评价报告附件序号 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_APPRAISE_FILENO" runat="server" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <%--
        <cc1:TabPanel ID="Panel_xcsgt" runat="server" HeaderText="现场施工图">
            <ContentTemplate>
                 <div  uName="div_file" style="text-align: left;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width:750px">
                      
                      <tr>
                        <td>&nbsp;</td>
                        <td>事前现场施工图：</td>
                        <td>&nbsp;</td>
                        <td align="left">事中现场施工图：</td>
                        <td>&nbsp;</td>
                        <td>事后现场施工图：</td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td><span style="width:230px"><img src="../../userImages/sgt.jpg" style="width:230px; height:230px;" /></span></td>
                        <td>&nbsp;</td>
                        <td><span style="width:230px"><img src="../../userImages/sgt.jpg" style="width:230px; height:230px;" /></span></td>
                        <td>&nbsp;</td>
                        <td><span style="width:230px"><img src="../../userImages/sgt.jpg" style="width:230px; height:230px;" /></span></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td colspan="5">现场施工资料上传：<span style="text-align:center;">
                          <input type="button" name="upload" value="资料上传" />
                        </span></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="Panel_xmtzsq" runat="server" HeaderText="项目投资申请">
            <ContentTemplate>
                <table style="width: 100%; text-align: left;" cellpadding="4">
                    <tr>
                        <td style="width: 130px; height:30px; text-align: right;">
                            申请投资总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_TOTAL" runat="server" Width="200px" Text="0"
                                Enabled="false"></asp:TextBox>&nbsp;元
                        <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            申请财政资金总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_TOTAL" runat="server" Width="200px" Text="0"
                                Enabled="false"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            &nbsp;&nbsp;&nbsp;&nbsp;申请上级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_SJ" uid='txtPD_PROJECT_MONEY_CZ_SJ' runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_SJ_PF" uid='txtPD_PROJECT_MONEY_CZ_SJ_PF' runat="server" Width="200px" style="display:none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            &nbsp;&nbsp;&nbsp;&nbsp;申请本级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_BJ" runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            申请自筹资金：
                        </td>
                        <td>
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_ZC" runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            申请其他资金：
                        </td>
                        <td>
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_QT" runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>--%>
        <cc1:TabPanel ID="Panel_xmsbzl" runat="server" HeaderText="项目附件资料归档">
            <ContentTemplate>
                <div uid='add_del_button' style="text-align: left; padding: 5px 10px;">
                    <a href="javascript:void(0)" onclick='loadTable_add()'>
                        <img src="../../images/AddRow.png" /></a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="javascript:void(0)"
                            onclick="tableJDdel('table_xmsbzl',3);">
                            <img src="../../images/DelRow.png" /></a>
                </div>
                <div id="div_file" uname="div_file">
                    <table id="table_xmsbzl" style="width: 98%; text-align: center;" border="1" cellpadding="4"
                        cellspacing="0">
                        <tr style="background: #E9E9E9;">
                            <td style="display: none; text-align: center;">
                                自动ID
                            </td>
                            <td height="30" style="width: 50px; text-align: center;">
                                序号
                            </td>
                            <td style="width: 200px; text-align: center;">
                                附件资料类型
                            </td>
                            <td style="text-align: center;">
                                附件名称
                            </td>
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
            loadTable_JD("table_xmsbzl", eval("<%=jsonStrNull%>")[0], 'xmss_5');
    }

    $(document).ready(function () {
        try {
            PostLoadxmsszl('table_xmsbzl', eval("<%=jsonStr %>"), 'xmss_5');

            RunBindData();
            $("#" + selectPD_YEAR_id).change(function () { getPD_PROJECT_TYPE(); })
            $("#" + selectPD_FOUND_XZ_id).change(function () { getPD_PROJECT_TYPE(); })
            //        $("#"+txtPD_PROJECT_BEGIN_DATE).blur(function(){  try{js_dateYear();}catch(e){alert(e)}; })
            //        $("#"+txtPD_PROJECT_END_DATE).blur(function(){ try{js_dateYear();}catch(e){alert(e)}; })

            //调用母版页中的方法
            setHeight();
            //绑定弹出气泡
            BindQiPao();

            $('#button1').click(function () {
                document.getElementById('<%=txt_file.ClientID%>').value = $('#InputFile').val();
            })

            //绑定投资及构成
            ShowTZGCAll();
            //            $('#InputFile').onchange(function(){
            //                //document.getElementByIdx_x_x("div_1").filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = document.getElementByIdx_x_x("file").value;
            //                alert("dsaffa");
            //            })
        } catch (e) { alert(e) }
    });
    function RunBindData() {
        if (!$("input[id='ibtcontrol_ibtsave']").length <= 0) {
            //            BindDate("<%=txtPD_PROJECT_BEGIN_DATE.ClientID%>");
            //            BindDate("<%=txtPD_PROJECT_END_DATE.ClientID%>");
            //            
            //            BindDate("<%=txtPD_PROJECT_COMPLETE_DATE.ClientID%>");
            //            BindDate("<%=txtPD_PROJECT_YSSQ_DATE.ClientID%>");
            //            BindDate("<%=txtPD_PROJECT_APP_DATE.ClientID%>");
            //            BindDate("<%=txtPD_PROJECT_YS_DATE.ClientID%>");
        }
    }
    </script>

</asp:Content>
