<%@ Page Language="C#" AutoEventWireup="true"   CodeBehind="YearKP.aspx.cs" Inherits="YearKP" %>
<html xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns="http://www.w3.org/TR/REC-html40">

<head runat="server">
    <title>2015－2016年度乡镇财政资金监管直接联系点督查要点</title>
<script  type="text/javascript">
    var HKEY_Root, HKEY_Path, HKEY_Key;
    HKEY_Root = "HKEY_CURRENT_USER";
    HKEY_Path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
    //设置网页打印的页眉页脚为空  
    function PageSetup_Null() {
        try {
            var Wsh = new ActiveXObject("WScript.Shell");
            HKEY_Key = "header";
            Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
            HKEY_Key = "footer";
            Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
        }
        catch (e)
        { }
    }
    function printpage(myDiv) { //DIV控制打印

        //var newstr = document.all.item(myDiv).innerHTML;  
        var newstr = document.getElementById(myDiv).innerHTML;
        // alert(newstr);
        var oldstr = document.body.innerHTML;
        document.body.innerHTML = newstr;
        window.print();
        document.body.innerHTML = oldstr;
        return false;
    }
    function preview() {
        PageSetup_Null();
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        window.print();
    }
    </script>
    <link href="../../css/xls.css" rel="stylesheet" />
    </head>
    <body style="overflow:auto;">
  <div id="divBtnPrint">
         <input type="button" name="print" value="预览并打印" onclick="preview()" 
            align="middle" /></div>
    </div>
    <br />
<!--startprint-->
<div id="mydiv"  style="overflow:auto;text-align:center">

<table border=0 cellpadding=0 cellspacing=0 width=865 class=xl67576
 style='border-collapse:collapse;table-layout:fixed;width:650pt'>
 <col class=xl67576 width=77 style='mso-width-source:userset;mso-width-alt:
 2464;width:58pt'>
 <col class=xl65576 width=85 style='mso-width-source:userset;mso-width-alt:
 2720;width:64pt'>
 <col class=xl66576 width="268" style='mso-width-source:userset;mso-width-alt:
 8576;width:201pt'>
 <col class=xl66576 width=297 style='mso-width-source:userset;mso-width-alt:
 9504;width:223pt'>
 <col class=xl67576 width="138" style='mso-width-source:userset;mso-width-alt:
 4416;width:104pt'>
 <tr height=75 style='mso-height-source:userset;height:56.25pt'>
  <td colspan=5 height=75 class=xl80576 width=865 style='height:56.25pt;
  width:650pt'>2015－2016年度乡镇财政资金监管直接联系点督查要点</td>
 </tr>
 <tr height=28 style='mso-height-source:userset;height:21.0pt'>
  <td colspan=4 height=28 class=xl87576 style='height:21.0pt'>　　　<font
  class="font6576">市（州）</font><font class="font7576">　　　　</font><font
  class="font6576">县（市区）</font></td>
  <td class=xl67576></td>
 </tr>
 <tr height=28 style='mso-height-source:userset;height:21.0pt'>
  <td colspan=5 height=28 class=xl81576 style='height:21.0pt'>乡镇（街道）财政所名称：</td>
 </tr>
 <tr height=28 style='mso-height-source:userset;height:21.0pt'>
  <td colspan=5 height=28 class=xl81576 style='height:21.0pt'>财政所长姓名：</td>
 </tr>
 <tr height=28 style='mso-height-source:userset;height:21.0pt'>
  <td colspan=5 height=28 class=xl81576 style='height:21.0pt'>联系电话：</td>
 </tr>
 <tr class=xl68576 height=45 style='mso-height-source:userset;height:33.75pt'>
  <td height=45 class=xl71576 width=77 style='height:33.75pt;border-top:none;
  width:58pt'>项目</td>
  <td class=xl71576 width=85 style='border-top:none;border-left:none;
  width:64pt'>内容</td>
  <td class=xl71576 width="268" style='border-top:none;border-left:none;
  width:201pt'>标准</td>
  <td class=xl71576 width=297 style='border-top:none;border-left:none;
  width:223pt'>督查重点</td>
  <td class=xl71576 width="138" style='border-top:none;border-left:none;
  width:104pt'>督查情况</td>
 </tr>
 <tr class=xl70576 height=42 style='mso-height-source:userset;height:31.5pt'>
  <td rowspan=6 height=399 class=xl82576 width=77 style='border-bottom:.5pt solid black;
  height:299.25pt;border-top:none;width:58pt'>组织机构<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </span>与制度建设<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl72576 width=85 style='border-top:none;border-left:none;
  width:64pt'>组织领导<span style='mso-spacerun:yes'>&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>成立了乡镇财政资金监管工作领导小组</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>文件中明确将相关职能部门、站所纳入领导小组</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=42 style='mso-height-source:userset;height:31.5pt'>
  <td height=42 class=xl72576 width=85 style='height:31.5pt;border-top:none;
  border-left:none;width:64pt'>人员配备<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>指定了专人为信息联络员。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>有相关文件明确信息联络员及职责。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=47 style='mso-height-source:userset;height:35.25pt'>
  <td height=47 class=xl74576 width=85 style='height:35.25pt;border-top:none;
  border-left:none;width:64pt'>总结计划</td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>半年度乡镇财政资金监管工作总结以及下半年工作计划</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>监管工作的亮点、特色并提出建设性意见、建议</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=136 style='mso-height-source:userset;height:102.0pt'>
  <td height=136 class=xl74576 width=85 style='height:102.0pt;border-left:none;
  width:64pt'>乡镇预算</td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>经人大审批的2015年本乡镇预算（包括预算编报说明及乡镇预算报表资料全套资料）；预算编制程序规范、内容完整、编制科学</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>乡镇所有收入支出是否纳入预算管理；是否制定乡镇人员经费定员定额标准；是否分类分档制定了确定保障乡镇正常运转的公用经费项目支出定额标准以及其他支出标准；支出科目按功能分类是否到项，按经济分类是否到款。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=44 style='mso-height-source:userset;height:33.0pt'>
  <td height=44 class=xl74576 width=85 style='height:33.0pt;border-left:none;
  width:64pt'>基本情况</td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>直接联系点基本情况表，填写内容真实完整。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>根据湘财乡函[2015]1号文件附件1要求填写</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=88 style='mso-height-source:userset;height:66.0pt'>
  <td height=88 class=xl74576 width=85 style='height:66.0pt;border-left:none;
  width:64pt'>资料归档</td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>相关资金监管资料归档</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>归档资料是否完整，装订是否美观整洁。包括乡镇财政资金信息传递登记表、乡镇财政资金信息接收回执、公开公示资料、抽查巡查资料、问题反馈等资料。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=96 style='mso-height-source:userset;height:72.0pt'>
  <td rowspan=3 height=383 class=xl82576 width=77 style='border-bottom:.5pt solid black;
  height:287.25pt;border-top:none;width:58pt'>信息通达<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl74576 width=85 style='border-left:none;width:64pt'>信息传递</td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>信息传递程序规范、项目齐全、金额准确、内容完整。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>查看是否及时登录财政内网，浏览监管信息专用文件夹，接收监管信息，定期报送“乡镇财政资金信息接收回执”。并及时整理、打印成存档纸质资料。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=110 style='mso-height-source:userset;height:82.5pt'>
  <td height=110 class=xl72576 width=85 style='height:82.5pt;border-left:none;
  width:64pt'>信息反馈<span style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>乡镇建立乡镇资金监管情况定期报告机制，及时向上级财政部门反馈监管情况。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>文件中明确定期报告期限。是否有将资金监管工作情况、发现的问题及建议通过财政内网专用电子文件夹向上级财政部门反馈的监管资料。并及时整理、打印成存档纸质资料。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=177 style='mso-height-source:userset;height:132.75pt'>
  <td height=177 class=xl72576 width=85 style='height:132.75pt;border-top:none;
  border-left:none;width:64pt'>台账</td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>乡镇财政资金监管台账分基本支出、补贴资金、项目资金三种类型分别填列。要求内容完整准确，登记及时。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>乡镇财政资金监管台账根据湘财乡函[2015]1号文件附件2要求填写；乡镇财政资金监管台账的基本支出、补助资金、项目资金根据县级财政部门传递的“乡镇财政资金住处传递登记表”分类进行登记；且项目类资金和补助类资金要与上报的2014年度乡镇财政基本信息表中“乡镇涉农专项资金使用情况表”相衔接；台账与资金信息传递资料相对应。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=53 style='mso-height-source:userset;height:39.75pt'>
  <td rowspan=2 height=105 class=xl85576 width=77 style='height:78.75pt;
  border-top:none;width:58pt'>公开公示<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td rowspan=2 class=xl72576 width=85 style='border-top:none;width:64pt'>公开公示<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>覆盖面<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>下达乡镇的补助性资金全部实行了公开公示。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>与台账相对应。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=52 style='mso-height-source:userset;height:39.0pt'>
  <td height=52 class=xl73576 width="268" style='height:39.0pt;border-top:none;
  border-left:none;width:201pt'>下达乡镇的项目资金全部实行了公开公示。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>与台账相对应。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=144 style='page-break-before:always;mso-height-source:
  userset;height:108.0pt'>
  <td height=144 class=xl79576 width=77 style='height:108.0pt;border-top:none;
  width:58pt'>公开公示</td>
  <td class=xl72576 width=85 style='border-top:none;border-left:none;
  width:64pt'>公开公示<span style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;
  </span>情况<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>各类资金公开公示内容完整、公开形式、时限符合要求。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>补助类资金公示内容是否包括补贴种类、标准、数量金额、对象、依据、举报电话等信息；项目类资金是否包括项目名称、立项依据、实施范围、建设单位、承建单位、建设内容、责任人和受益人、资金来源及数量、建设时限等信息。公示期不少于七个工作日。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=89 style='mso-height-source:userset;height:66.75pt'>
  <td rowspan=3 height=210 class=xl83576 width=77 style='border-bottom:.5pt solid black;
  height:157.5pt;width:58pt'>公开公示</td>
  <td class=xl75576 width=85 style='border-left:none;width:64pt'>上访处理<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;</span></td>
  <td class=xl78576 width="268" style='border-left:none;width:201pt'>对群众反映的问题进行接访和记录，并会同相关单位及时向来访人员进行回复处理。及时整理保存好各项接访、回复处理材料。</td>
  <td class=xl77576 width=297 style='border-left:none;width:223pt'>有接待来访记录本，及接访回复文字资料。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=76 style='mso-height-source:userset;height:57.0pt'>
  <td rowspan=2 height=121 class=xl72576 width=85 style='height:90.75pt;
  border-top:none;width:64pt'>监督管理<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>每项资金公开公示情况有照片等备查记录。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>要有照片等备查依据。查看公开公示内容是否完整，公开形式是否符合要求，公开公示是否切实实行。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=45 style='mso-height-source:userset;height:33.75pt'>
  <td height=45 class=xl73576 width="268" style='height:33.75pt;border-top:none;
  border-left:none;width:201pt'>乡镇财政所设立了监督举报电话和举报箱，并对外公布。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>　</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=47 style='mso-height-source:userset;height:35.25pt'>
  <td rowspan=6 height=402 class=xl85576 width=77 style='height:301.5pt;
  border-top:none;width:58pt'>抽查巡查<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl72576 width=85 style='border-top:none;border-left:none;
  width:64pt'>补助性资金<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>对所有补助性资金都进行了抽查</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>与公开公示资料相对应。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=51 style='mso-height-source:userset;height:38.25pt'>
  <td rowspan=2 height=100 class=xl74576 width=85 style='border-bottom:.5pt solid black;
  height:75.0pt;border-top:none;width:64pt'>项目资金<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>对所有项目资金都进行了巡查</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>与公开公示资料相对应。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=49 style='mso-height-source:userset;height:36.75pt'>
  <td height=49 class=xl78576 width="268" style='height:36.75pt;border-left:none;
  width:201pt'>是否按规定于事前、事中、事后开展巡查</td>
  <td class=xl77576 width=297 style='border-left:none;width:223pt'>是否有事前、事中、事后巡查的通知、照片、监管记录等纸质资料。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height="81" style='mso-height-source:userset;height:60.75pt'>
  <td rowspan=2 height=168 class=xl74576 width=85 style='border-bottom:.5pt solid black;
  height:126.0pt;border-top:none;width:64pt'>抽查巡查<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp; </span>方式方法<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>每次抽查巡查工作由2人以上的工作小组完成</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>工作小组成员可由财政所单独组成，也可由财政所联合其他基层站所组成，是否为2人以上。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=87 style='mso-height-source:userset;height:65.25pt'>
  <td height=87 class=xl73576 width="268" style='height:65.25pt;border-top:none;
  border-left:none;width:201pt'>填写了抽查巡查记录表，有相关文件和照片等佐证材料。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>每次抽查巡查是否有抽查巡查通知、抽查巡查对象照片、监管记录表（工作小组为2人以上，并在监管记录表上签名）。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=87 style='mso-height-source:userset;height:65.25pt'>
  <td height=87 class=xl72576 width=85 style='height:65.25pt;border-top:none;
  border-left:none;width:64pt'>问题反馈<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl73576 width="268" style='border-top:none;border-left:none;
  width:201pt'>对抽查巡查过程中发现的问题提出处理的意见和建议并及时向县级财政部门报告，无自行处理的情况。</td>
  <td class=xl76576 width=297 style='border-top:none;border-left:none;
  width:223pt'>对抽查巡查过程中发现的问题向县级财政部上报抽查巡查检查报告。是否有抽查巡查检查报告以及县级财政部门书面处理资料。</td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr class=xl70576 height=38 style='mso-height-source:userset;height:28.5pt'>
  <td colspan=4 height=38 class=xl86576 width=727 style='height:28.5pt;
  width:546pt'>督查组成员（签名）：<span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
  <td class=xl69576 width="138" style='border-top:none;border-left:none;
  width:104pt'>　</td>
 </tr>
 <tr height=90 style='mso-height-source:userset;height:67.5pt'>
  <td height=90 class=xl67576 style='height:67.5pt'></td>
  <td class=xl65576></td>
  <td class=xl67576></td>
  <td class=xl67576></td>
  <td class=xl67576></td>
 </tr>
 <tr height=29 style='mso-height-source:userset;height:21.75pt'>
  <td height=29 class=xl67576 style='height:21.75pt'></td>
  <td class=xl67576></td>
  <td class=xl67576></td>
  <td class=xl67576></td>
  <td class=xl67576></td>
 </tr>
 <![if supportMisalignedColumns]>
 <tr height=0 style='display:none'>
  <td width=77 style='width:58pt'></td>
  <td width=85 style='width:64pt'></td>
  <td width="268" style='width:201pt'></td>
  <td width=297 style='width:223pt'></td>
  <td width="138" style='width:104pt'></td>
 </tr>
 <![endif]>
</table>

</div>
<!--endprint-->
</body>
    </html>