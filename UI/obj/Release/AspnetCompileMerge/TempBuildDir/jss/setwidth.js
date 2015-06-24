function setWidth()
{
	var obj = window.top.mainFrame;
	var w = screen.availWidth;
	var h = screen.availHeight;
	
	if(obj.document!=null)
	{
		var cw=obj.document.body.offsetWidth;
		var ch=obj.document.body.offsetHeight;
		var i=w-cw;
	}
	else
	{
		var i=200;
	}

	if (obj.subMainFrame!=null)
	{
		if(i>100)
		{
			obj.subMainFrame.cols = "0,*";
		}
		else
		{
			obj.subMainFrame.cols = "180,*";
		}
	}
}

if ((window.name!="topFrame") && (window.name!="leftFrame"))
{
	window.top.leftFrame.Hidmenu(200);
}