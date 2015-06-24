 
var yskm_code=null;
var yskm_name=null;
var ysxm_code=null;
var ysxm_name=null;
var ysdw_code=null;
var ysdw_name=null;
var state="";
var setting = {
	data: {
		key: {
			 
		},
		simpleData: {
			enable: true
		}
	},
	callback: {
		beforeClick: beforeClick
	}
};

function beforeClick(treeId, treeNode, clickFlag) {
    var code=treeNode.id;
    var name=treeNode.title;
 
    if(treeId=="treeDemo")
    {   
    alert(code+"|"+name);
//        $('#ysdw').val(name);
//        $('#ysdw_code').val(code);
//        NcManage.bindnc(code);	
    }   
	return (treeNode.click != false);
}

$(function() {
        NcManage.GetModule();
    });

    /*
    * @desc: area info manegement class
    */
    var NcManage = {
      
    /*获取菜单*/
    GetModule: function() {
	    var zNodes_s=null; 
	    $.ajax({
        type: 'post',
        async: false,
        url: '../../WebService/WebService.asmx/GetTreeDW?ParentId=141020',
        success: function(si) {
            zNodes_s=eval(si);
            $.fn.zTree.init($("#treeDemo"), setting, zNodes_s);
        },
        error: function() {
            alert("error");
        }
        });	
        }
  }