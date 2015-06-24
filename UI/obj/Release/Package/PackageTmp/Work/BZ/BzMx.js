function openLog()
{
    var txtPD_PROJECT_CODE = $("input[uid='txtPD_PROJECT_CODE']").get(0);
    if(!isNaN(txtPD_PROJECT_CODE.value))
    {
        window.open("ShowHD.aspx?code="+txtPD_PROJECT_CODE.value,'','toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no,left=150,top=50');
    }
}