<%@ control language="C#" autoeventwireup="true" inherits="WebControls_TwoPageButtons" CodeBehind="TwoPageButtons.ascx.cs"%>
<%--<link rel="stylesheet" type="text/css" href="../Ext/resources/css/ext-all.css" />

<script src="../Ext/adapter/ext/ext-base.js" type="text/javascript"></script>

<script src="../Ext/ext-all.js" type="text/javascript"></script>

<style type="text/css">
    .btnCls
    {
        background-image: url(../images/add.gif);
    }
</style>--%>

<%--<script type="text/javascript">
    Ext.onReady(function() {
            new Ext.Button({
                text: '新 增',
                renderTo:'div1',
                iconCls:'btnCls',
                handler: function() {
                       var mytab = Ext.getCmp('TabContainer1');
                       if(mytab=='TabPanel1')
                       {
                        window.open('../Branch/BranchAdd.aspx', '', 'toolbar=no,status=no,resizable=no,width=800px,height=500px,scrollbars=no,location=no,left=200,top=100');
                        }
                }
            })
        });
</script>
<div id="div1"></div>--%>
<div runat="server" align="left" id="divbutton" style="background-image: url(~/images/new/backBar2.png);">
</div>
