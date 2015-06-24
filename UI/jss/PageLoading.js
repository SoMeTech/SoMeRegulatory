// JScript 文件

//页面全屏
//moveTo(0,0);
//resizeTo(window.screen.availWidth,window.screen.availHeight);

//加载效果
setTimeout(function() {
	Ext.get('loading').remove();
	Ext.get('loading-mask').fadeOut({remove:true});
	Ext.get('pagemain').show();
}, 1500); 
