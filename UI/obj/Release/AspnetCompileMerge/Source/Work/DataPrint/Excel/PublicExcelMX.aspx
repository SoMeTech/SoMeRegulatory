<%@ page language="C#" autoeventwireup="true" inherits="Work_DataPrint_Excel_PublicExcelMX"  CodeBehind="PublicExcelMX.aspx.cs" enableEventValidation="false" stylesheettheme="Default" %>

<%@ Register Src="~/WebControls/Buttons1.ascx" TagName="Buttons1" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script src="../../../jss/jquery-1.4.2.min.js" type="text/javascript"></script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
    body
    {
    	background-color:#EEE;
    	}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var tbName = null;
            if ($("input[uid='auto_id']").eq(0).val() != "") {
                $.ajax({
                    url: "PublicExcel.ashx?type=GetIDTable&auto_id=" + $("input[uid='auto_id']").eq(0).val(),
                    contentType: "application/json",
                    type: "post",
                    dataType: 'text',
                    async: true,
                    error: function (e) { alert("error!"); },
                    success: function (msg) {
                        var arr = msg.split("|");
                        $("input[uid='auto_id']").get(0).tbName = tbName = arr[0];
                        $("select[uid='ddlCompany']").eq(0).val(arr[1]);
                        var ddlBranch = $("select[uid='ddlBranch']").get(0);
                        var op = document.createElement("option");
                        op.value = "-1"; op.innerHTML = " ==请选择== ";
                        ddlBranch.appendChild(op);
                        $(eval(arr[3])).each(function () {
                            var option = document.createElement("option");
                            option.value = this.BH;
                            option.innerHTML = this.NAME;
                            ddlBranch.appendChild(option);
                        });
                        ddlBranch.value = arr[2];
                        $("input[uid='ModelName']").eq(0).val(arr[4]);
                    }
                });
            }
            else {
                var ddlBranch = $("select[uid='ddlBranch']").get(0);
                var op = document.createElement("option");
                op.value = "-1"; op.innerHTML = " ==请选择== ";
                ddlBranch.appendChild(op);
            }
            getTableAll(tbName);
        });
        //获取所有用户表，但必须要有注释
        function getTableAll(tbName) {
            $.ajax({
                url: "PublicExcel.ashx?type=gettable",
                contentType: "application/json",
                type: "post",
                dataType: 'text',
                async: true,
                error: function (e) { alert("error!"); },
                success: function (msg) {//msg为返回的数据，在这里做数据绑定
                    var json = eval(msg);
                    //                var ListBox1 = $("select#lb_table").get(0);
                    var Div_One = $("div#Div_One").get(0);
                    var ShowDiv = null;
                    $(json).each(function () {
                        //创建外围DIV
                        var div_father = document.createElement("div");
                        //创建内部DIV,选中后背景为蓝色，以后改成图片美化
                        var div = document.createElement("div");
                        div.name = "d_option";
                        div.title = this.TABLE_NAME;
                        div_father.style.cssText = "float:left;text-align:center; width:140px; height:70px;";
                        div_father.appendChild(div);
                        //创建IMG，名称等
                        var img = document.createElement("img");
                        img.src = "../../../images/new/table.png"
                        img.style.cssText = "width:40px; height:40px;"

                        var a = document.createElement("a");
                        var br = document.createElement("br");
                        img.value = this.TABLE_NAME;
                        a.innerHTML = this.COMMENTS;
                        div.appendChild(img);
                        div.appendChild(br);
                        div.appendChild(a);
                        div.style.cssText = "float:left;text-align:center; width:100px; height:60px;cursor:hand";
                        //内围DIV单击事件,取消其他所有内围DIV的颜色，后设置自己的选中颜色
                        div.onclick = function () {
                            $("div[name='d_option']").each(function () {
                                this.style.backgroundColor = "";
                                this.select = 0;
                            });

                            div.style.backgroundColor = "#83b2f8";
                            //                        div.style.backgroundImage="url(../../../images/new/ba.jpg)";
                            div.select = 1;
                            $("input[uid='ModelDataTable']").eq(0).val($("img", div).eq(0).val());
                        }
                        if (tbName != null && tbName != "" && tbName == this.TABLE_NAME) {
                            div.style.backgroundColor = "#83b2f8";
                            div.select = 1;
                            $("input[uid='ModelDataTable']").eq(0).val(this.TABLE_NAME);
                            ShowDiv = div;
                        }
                        Div_One.appendChild(div_father)
                    });
                    $("#Div_One").animate({ scrollTop: $(ShowDiv).offset().top - 80 }, 300);
                }
            });
        }
        //选择或取消选择所有列
        function CheckedAll(obj) {
            $("input[name='checkbox1']").each(function () {
                this.checked = obj.checked;
            });
        }
        //获取选择表的所有列
        function selectColumns(tbName, tbCName) {
            var _url1 = "";
            if ($("input[uid='auto_id']").get(0).tbName != null && $("input[uid='auto_id']").get(0).tbName != "") {
                _url1 = "&upTbName=" + $("input[uid='auto_id']").get(0).tbName;
            }

            $.ajax({
                url: "PublicExcel.ashx?type=selectColumns&tbName=" + tbName + _url1,
                contentType: "application/json",
                type: "post",
                dataType: 'text',
                async: true,
                error: function (e) { alert("error!"); },
                success: function (msg) {//msg为返回的数据，在这里做数据绑定
                    var json = eval(msg);
                    var tb_Two = $("#tb_Two").get(0);
                    //清空行
                    tb_Two.firstChild.removeNode(true);
                    //创建行
                    var _tr = tb_Two.insertRow();
                    _tr.style.background = "#E9E9E9";

                    //创建第一列
                    var _td = _tr.insertCell();
                    _td.innerHTML = "选择";
                    _td.style.width = "50px";
                    var _chkb = document.createElement("input");
                    _chkb.type = "checkbox";
                    _chkb.onclick = function () { CheckedAll(this); }
                    _td.appendChild(_chkb);

                    //创建第二列
                    var _td = _tr.insertCell();
                    _td.innerHTML = "表名";
                    //创建第三列
                    var _td = _tr.insertCell();
                    _td.innerHTML = "列名";
                    //创建第四列
                    var _td = _tr.insertCell();
                    _td.innerHTML = "参数类型";
                    //创建第五列
                    var _td = _tr.insertCell();
                    _td.innerHTML = "值";

                    $(json).each(function () {
                        var _tr = tb_Two.insertRow();
                        var _td_CK = _tr.insertCell();
                        var _input = document.createElement("input");
                        _input.type = "checkbox";
                        _input.name = "checkbox1";
                        _td_CK.appendChild(_input);
                        if (this.CHECKED == "1")
                            _input.setAttribute("checked", "checked");

                        var _td_TbName = _tr.insertCell();
                        var _a_TbName = document.createElement("a");
                        _a_TbName.name = "a_TbName";
                        _a_TbName.innerHTML = tbCName;
                        _a_TbName.ename = tbName;
                        _td_TbName.appendChild(_a_TbName);

                        var _td_text = _tr.insertCell();
                        var _a_text = document.createElement("a");
                        _a_text.name = "a_text";
                        _a_text.innerHTML = this.COMMENTS;
                        _a_text.ename = this.COLUMN_NAME;
                        _td_text.appendChild(_a_text);

                        var _td_select = _tr.insertCell();
                        _td_select.innerHTML = "<select name=\"select\" onchange='parameType(this)'>  <option value=\"0\">无默认值</option>  <option value=\"1\">固定值</option>  <option value=\"4\">所属业务</option>  <option value=\"2\">系统参数</option>  <option value=\"3\">当时值</option></select>"

                        var _td_txt = _tr.insertCell(); _td_txt.style.width = "150px";
                        var _input_txt = document.createElement("input"); _input_txt.name = "input_txt"; _input_txt.style.display = "none"; _input_txt.style.width = "145px";
                        var _sysInput_txt = document.createElement("input"); _sysInput_txt.name = "sysInput_txt"; _sysInput_txt.style.display = "none"; _sysInput_txt.style.width = "145px";
                        _sysInput_txt.onclick = function () { getSysParame(this); }

                        var _select_txt = document.createElement("select"); _select_txt.name = "select1_txt"; _select_txt.style.display = "none"; _select_txt.style.width = "145px";
                        var _option_txt = document.createElement("option"); _option_txt.value = "date"; _option_txt.innerHTML = "日期";
                        _select_txt.appendChild(_option_txt);

                        var _select_serverpk = $("select[uid='ddlServerPK']").get(0).cloneNode(true); _select_serverpk.id = ""; _select_serverpk.name = "ddlServerPK";

                        _td_txt.appendChild(_input_txt);
                        _td_txt.appendChild(_sysInput_txt);
                        _td_txt.appendChild(_select_txt);
                        _td_txt.appendChild(_select_serverpk);
                        //此时是修改数据状态
                        if (_url1 != "") {
                            _td_select.firstChild.value = (this.UpT == "" ? "0" : this.UpT);
                            switch (this.UpT) {
                                case "":
                                case "0":
                                    break;
                                case "1":
                                    _input_txt.value = this.UpV;
                                    _input_txt.style.display = "block";
                                    break;
                                case "2":
                                    _sysInput_txt.value = this.UpV;
                                    _sysInput_txt.style.display = "block";
                                    break;
                                case "3":
                                    _select_txt.value = this.UpV;
                                    _select_txt.style.display = "block";
                                    break;
                                case "4":
                                    _select_serverpk.value = this.UpV;
                                    _select_serverpk.style.display = "block";
                            }
                        }
                    });
                }
            });

        }
        function getSysParame(obj) {
            var shMod_cs = "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0";
            obj.value = window.showModalDialog("GetSystemParame.aspx", obj, shMod_cs);
        }
        function parameType(obj) {
            _td = obj.parentNode;
            _tr = obj.parentNode.parentNode;
            switch (obj.value) {
                case "0":
                    $("input[name=input_txt]", _tr).get(0).style.display = "none";
                    $("select[name='select1_txt']", _tr).get(0).style.display = "none";
                    $("select[name='ddlServerPK']", _tr).get(0).style.display = "none";
                    $("input[name='sysInput_txt']", _tr).get(0).style.display = "none";
                    break;
                case "1":
                    $("input[name=input_txt]", _tr).get(0).style.display = "block";
                    $("select[name='select1_txt']", _tr).get(0).style.display = "none";
                    $("select[name='ddlServerPK']", _tr).get(0).style.display = "none";
                    $("input[name='sysInput_txt']", _tr).get(0).style.display = "none";
                    break;
                case "2":
                    $("input[name=input_txt]", _tr).get(0).style.display = "none";
                    $("select[name='select1_txt']", _tr).get(0).style.display = "none";
                    $("select[name='ddlServerPK']", _tr).get(0).style.display = "none";
                    $("input[name='sysInput_txt']", _tr).get(0).style.display = "block";

                    break;
                case "3":
                    $("input[name=input_txt]", _tr).get(0).style.display = "none";
                    $("select[name='select1_txt']", _tr).get(0).style.display = "block";
                    $("select[name='ddlServerPK']", _tr).get(0).style.display = "none";
                    $("input[name='sysInput_txt']", _tr).get(0).style.display = "none";
                    break;
                case "4":
                    $("input[name=input_txt]", _tr).get(0).style.display = "none";
                    $("select[name='select1_txt']", _tr).get(0).style.display = "none";
                    $("select[name='ddlServerPK']", _tr).get(0).style.display = "block";
                    $("input[name='sysInput_txt']", _tr).get(0).style.display = "none";
                    break;
            }
        }
        //下一步
        function next() {
            switch (ShowDivID) {
                case "Div_One":
                    var tbName = "", tbCName = "";
                    $("div[name='d_option']").each(function () {
                        if (this.select == 1) {
                            tbName = $("img", this).eq(0).val();
                            tbCName = $("a", this).eq(0).html();
                            return false;
                        }
                    });
                    if (tbName == "") {
                        alert("请先选择一个表，以进行下一步操作！");
                        return;
                    }
                    //                if(confirm("是否需要选择Excel来与系统数据表进行绑定？"))
                    //                {
                    //                    UpFile(null);
                    //                }
                    //                else
                    {
                        selectColumns(tbName, tbCName);
                        ShowDivID = "Div_Two";
                        $("#btn_roll").removeAttr("disabled");
                        $("#btn_next").removeAttr("disabled");
                        $("#btn_next").eq(0).val(" 完  成 ");
                        $("#Div_One").hide();
                        $("#Div_Two").show();
                        $("#Div_Three").hide();
                        $("#Div_Over").hide();
                    }
                    //selectColumns(tbName)
                    break;
                case "Div_Excel":

                    break;
                case "Div_Two":
                    if ($("input[uid='ModelName']").eq(0).val() == "" && !confirm("确定不给此模板命名吗？"))
                        return;
                    var IsOK = false;
                    $("input[name='checkbox1']").each(function () {
                        if (this.checked) {
                            IsOK = true;
                            return false;
                        }
                    });
                    if (!IsOK) {
                        alert("请选择至少一列来进行模板的创建！");
                        return;
                    }

                    if (confirm("系统已准备就绪，确定后将保存此模板！")) {
                        SubmitForm();
                    }


                    //                ShowDivID="Div_Three";
                    ////                $("#btn_roll").removeAttr("disabled");
                    ////                $("#btn_next").removeAttr("disabled");
                    //                $("#btn_roll").removeAttr("disabled");
                    //                $("#btn_next").removeAttr("disabled");
                    ////                $("#btn_next").attr("disabled","disabled");
                    //                $("#Div_One").hide();
                    //                $("#Div_Two").hide();
                    //                $("#Div_Three").show();
                    //                $("#Div_Over").hide();
                    break;

                    //            case "Div_Three":
                    //                
                    //                
                    //                break;



                    //            case "Div_Three":
                    //                ShowDivID="Div_Over";
                    //                $("#btn_roll").removeAttr("disabled");
                    //                $("#btn_next").attr("disabled","disabled");
                    //                
                    //                $("#Div_One").hide();
                    //                $("#Div_Two").hide();
                    //                $("#Div_Three").hide();
                    //                $("#Div_Over").show();
                    //                break;
            }
        }
        //上一步
        function rollback() {
            switch (ShowDivID) {
                //            case "Div_Over":
                //                ShowDivID="Div_Three"; 
                //                $("#btn_roll").removeAttr("disabled");
                //                $("#btn_next").removeAttr("disabled");
                //                $("#Div_One").hide();
                //                $("#Div_Two").hide();
                //                $("#Div_Three").show();
                //                $("#Div_Over").hide();
                //                break;
                case "Div_Three":
                    ShowDivID = "Div_Two";
                    $("#btn_roll").removeAttr("disabled");
                    $("#btn_next").removeAttr("disabled");

                    $("#Div_One").hide();
                    $("#Div_Two").show();
                    $("#Div_Three").hide();
                    $("#Div_Over").hide();
                    break;
                case "Div_Two":
                    ShowDivID = "Div_One";
                    $("#btn_roll").attr("disabled", "disabled");
                    $("#btn_next").removeAttr("disabled");
                    $("#btn_next").eq(0).val("下一步");

                    $("#Div_One").show();
                    $("#Div_Two").hide();
                    $("#Div_Three").hide();
                    $("#Div_Over").hide();
                    break;
            }
        }
        var ShowDivID = "Div_One";

        function pbExcelMx_ok() {

        }
        function pbExcelMx_center() {

        }
        /*
        
                        _td_select.innerHTML="<select name=\"select\" onchange='parameType(this)'>  <option value=\"0\">无默认值</option>  <option value=\"1\">固定值</option>  <option value=\"1.1\">固定值服务</option>  <option value=\"2\">系统参数</option>  <option value=\"3\">当时值</option></select>"
                        
                        var _td_txt = _tr.insertCell();_td_txt.style.width="150px";
                        var _input_txt = document.createElement("input");_input_txt.name="input_txt"; _input_txt.style.display="none";_input_txt.style.width="145px";
                        var _sysInput_txt = document.createElement("input");_sysInput_txt.name="sysInput_txt"; _sysInput_txt.style.display="none";_sysInput_txt.style.width="145px";
                        _sysInput_txt.onclick=function(){ getSysParame(this); }
                        
                        var _select_txt = document.createElement("select");_select_txt.name="select1_txt"; _select_txt.style.display="none";_select_txt.style.width="145px";
                        var _option_txt = document.createElement("option"); _option_txt.value="date";_option_txt.innerHTML="日期";
                        _select_txt.appendChild(_option_txt);
                        
                        var _select_serverpk = $("select[uid='ddlServerPK']").get(0).cloneNode(true);_select_serverpk.id="";_select_serverpk.name="ddlServerPK";
                        
        */
        function SubmitForm() {
            var columns = "";
            //        var columns= [];
            $("input[name='checkbox1']").each(function (i) {
                if (this.checked) {
                    var _tr = this.parentNode.parentNode;
                    var _type = $("select[name='select']", _tr).eq(0).val()
                    var _column = $("a[name='a_text']", _tr).get(0).ename;
                    var _Ecolumn = $("a[name='a_text']", _tr).get(0).innerHTML;
                    var _data = "";

                    switch ($("select[name='select']", _tr).eq(0).val()) {
                        case "0":
                            break;
                        case "1":
                            _data = $("input[name='input_txt']", _tr).eq(0).val()
                            break;
                            break;
                        case "2":
                            _data = $("input[name='sysInput_txt']", _tr).eq(0).val()
                            break;
                        case "3":
                            _data = $("select[name='select1_txt']", _tr).eq(0).val()
                            break;
                        case "4":
                            _data = $("select[name='ddlServerPK']", _tr).eq(0).val()
                    }

                    columns += ",{column:\"" + encodeURIComponent(_column) + "\", Ccolumn:\"" + encodeURIComponent(_Ecolumn) + "\", type:\"" + encodeURIComponent(_type) + "\", data:\"" + encodeURIComponent(_data) + "\"}";
                    //                columns += ",t"+i+":[{column:\""+encodeURIComponent(_column)+"\", type:\""+encodeURIComponent(_type)+"\", data:\""+encodeURIComponent(_data)+"\"}]";

                    //                var column = {column:_column, type:_type, data:_data};
                    //                columns.push(column);
                }
            });
            $("input[uid='ModelDataColumns']").eq(0).val("{t1:[" + columns.substring(1) + "]}");
            $("input[uid='ibtid']").eq(0).val("sava");
            $("input[uid='hBranch']").eq(0).val($("select[uid='ddlBranch']").eq(0).val());

            $("form[uid='form1']").get(0).submit();
            //        alert($("input[uid='ModelDataColumns']").eq(0).val());
        }
        function GetBranch(obj) {
            if (obj.value != "-1") {
                $.ajax({
                    url: "PublicExcel.ashx?type=GetBranch&Company=" + obj.value,
                    contentType: "application/json",
                    type: "post",
                    dataType: 'text',
                    async: true,
                    error: function (e) { alert("error!"); },
                    success: function (msg) {
                        var ddlBranch = $("select[uid='ddlBranch']").get(0);
                        ddlBranch.options.length = 0;
                        var op = document.createElement("option");
                        op.value = "-1"; op.innerHTML = " ==请选择== ";

                        $(eval(msg)).each(function () {
                            var option = document.createElement("option");
                            option.value = this.BH;
                            option.innerHTML = this.NAME;
                            ddlBranch.appendChild(option);
                        });
                    }
                });
            }
            else {
                var ddlBranch = $("select[uid='ddlBranch']").get(0);
                ddlBranch.options.length = 0;
                var op = document.createElement("option");
                op.value = "-1"; op.innerHTML = " ==请选择== ";
                ddlBranch.appendChild(op);
            }
        }
    </script>

</head>
<body>
    <form id="form1" uid="form1" runat="server">
    <uc1:Buttons1 ID="Buttons1_1" runat="server" />
    <input type="hidden" id="ibtid" name="ibtid" uid='ibtid' runat="server" />
    <input type="hidden" id="auto_id" name="auto_id" uid='auto_id' runat="server" />
    <input type="hidden" id="ModelDataTable" uid="ModelDataTable" runat="server" />
    <input type="hidden" id="ModelDataColumns" uid="ModelDataColumns" runat="server" />
    <input type="hidden" id="hBranch" uid="hBranch" runat="server" />
    
    <div id="Div_One" style="padding:5px 5px 5px 5px;width:590px; height:315px; overflow:auto;">
        <div style="padding:5px 5px 5px 5px;"><a >请选择一个表进行导入模板的设置：</a></div>
    </div>
    <div id="Div_Two" style=" width:600px; height:325px; overflow:auto; display:none;">
        <div style="padding:5px 5px 5px 5px;">
            <a>新建模板名称：</a><asp:TextBox  ID="ModelName" uid="ModelName" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlCompany" uid="ddlCompany" runat="server" onchange="GetBranch(this)" ></asp:DropDownList>
            <asp:DropDownList ID="ddlBranch" uid="ddlBranch" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddlServerPK" uid="ddlServerPK" runat="server" style="display:none; width:145px"></asp:DropDownList>
            
        </div>
        
        <div style="padding:5px 5px 5px 5px;">
            <table id="tb_Two" style="width: 98%; text-align: center;" border="1" cellpadding="4" cellspacing="0">
            <tr><td></td></tr>
            </table>
        </div>
    </div>
    <div id="Div_Three" style=" width:600px; height:325px; overflow:auto; display:none; text-align:center; vertical-align:middle;">
        <a style=" width:600px; height:325px;">准备就绪！请点击完成进行保存。</a>
    </div>
    
    <div style="width:600px; height:25px;  text-align:right; vertical-align:middle">
        <input type="button" id="btn_roll" onclick="rollback()" disabled="disabled" value="上一步" />
        <input type="button" id="btn_next" onclick="next()" value="下一步" />
    </div>
    </form>
</body>
</html>
