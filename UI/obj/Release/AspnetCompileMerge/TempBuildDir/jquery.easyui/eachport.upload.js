/*
*
* Http File Upload Library
* Version: 1.0.0  (Feb 14, 2012)
* @requires: jQuery v1.2.6+
* @project:  Eachport Reserve Platform Management System 
* http://www.eachport.com, 
* http://www.eachport.net
*
*/


$(function() {

    $("#FileUpload").bind("change", function() {
 
         
        //start submit
        $("#form1").ajaxSubmit({
            type: "post",
            timeout: 600000,
            dataType:'json',   
            async: false,         
            url: "../../FileUploadService.asmx/Upload",
            data:{name:'FileUpload',ImgType:$('#type').val()},
            beforeSubmit: function(formData, jqForm, options) {
                //隐藏上传按钮
                $(".files").hide();
                //显示LOADING图片
                $(".uploading").show();
            },
            success: function(d, textStatus) {
                if (d.State == 1) {
                        $("#txtImgUrl").val(d.Info.replace('../../', ''));
                        $("#txtOrignalUrl").val(d.Info.replace('../../', ''));
                    }
                 else {
                    alert(d.Info);
                }
                $(".files").show();
                $(".uploading").hide();
            },
            error: function(data, status, e) {
                alert("上传失败，错误信息：" + e);
                $(".files").show();
                $(".uploading").hide();
            }
        });
    });

    $(".FileUpload").bind("change", function() {
        var strName=$(this).attr('name');
        //start submit
        $("#form1").ajaxSubmit({
            type: "post",
            timeout: 600000,
            dataType:'json',   
            async: false,         
             url: "../../FileUploadService.asmx/Upload",
            data:{name:strName},
            beforeSubmit: function(formData, jqForm, options) {
                //隐藏上传按钮
                $(".files").hide();
                //显示LOADING图片
                $(".uploading").show();
            },
            success: function(d, textStatus) {
                if (d.State == 1) {
                    if(strName=="FileUpload")
                    {
                        $("#txtImgUrl").val(d.Info.replace('../../', ''));
                        $("#txtOrignalUrl").val(d.Info.replace('../../', ''));
                    }
                    else
                    {
                        $("#txtImgUrl1").val(d.Info.replace('../../', ''));
                        $("#txtOrignalUrl1").val(d.Info.replace('../../', ''));
                    }
                } else {
                    alert(d.Info);
                }
                $(".files").show();
                $(".uploading").hide();
            },
            error: function(data, status, e) {
                alert("上传失败，错误信息：" + e);
                $(".files").show();
                $(".uploading").hide();
            }
        });
    });
});