<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>成都市龙泉山生态旅游综合功能区重大项目申报系统</title>
    <link href="css/login.css" rel="stylesheet" />
   

    <script type="text/javascript">
     function div_load(loadurl,titleStr){
         document.getElementById("content").src = loadurl;
         document.getElementById("title_str").innerHTML = titleStr;
      }
    </script>
</head>
<body style="background:#2d8cd8;">
<form runat="server">
<div class="container">
<!--header-->
<div class="header">
     <div class="logo"></div>
     <div class="message">欢迎:<% Response.Write(((System.Data.DataTable)Session["userEntity_logined"]).Rows[0]["USERNAME"]); %> | &nbsp;登陆系统|<a href="javascript:div_load('Admin/updatePassword.aspx');">修改密码</a>|<asp:LinkButton
         ID="LinkButton1" runat="server" onclick="LinkButton1_Click">退出</asp:LinkButton>|<a href="#">帮助</a></div>
     <div class="clr"></div>
</div>
<!--header end-->
<!--top-->
<div class="top">
     <div id="div4" class="core">
      <a href="javascript:"><% Response.Write(System.DateTime.Now.ToString()); %></a>
	</div> 
    <script type="text/javascript">
        function myGod(id, w, n) {
            var box = document.getElementById(id), can = true, w = w || 1500, fq = fq || 10, n = n == -1 ? -1 : 1;
            box.innerHTML += box.innerHTML;
            box.onmouseover = function () { can = false };
            box.onmouseout = function () { can = true };
            var max = parseInt(box.scrollHeight / 2);
            new function () {
                var stop = box.scrollTop % 18 == 0 && !can;
                if (!stop) {
                    var set = n > 0 ? [max, 0] : [0, max];
                    box.scrollTop == set[0] ? box.scrollTop = set[1] : box.scrollTop += n;
                };
                setTimeout(arguments.callee, box.scrollTop % 18 ? fq : w);
            };
        };
        myGod('div4', 800);
</script>
</div>
<!--top end-->
<!--main-->
<div class="main">
<!--left-->
    <div class="left">
           <div id="levelmenu">
           <%loadMenu();%>
</div>

<script type="text/javascript">
    function init() {
        if (!document.getElementById || !document.getElementsByTagName) { retun; }
        var arrayDiv = document.getElementById("levelmenu");
        if (!arrayDiv) { return; }
        var divObj = arrayDiv.getElementsByTagName("div");
        var length = divObj.length;
        var agreeDiv = new Array();
        for (var i = 0; i < length; i++) {
            if (divObj[i].className.indexOf("unit") >= 0) {
                agreeDiv.push(divObj[i]);
                divObj[i].onclick = function (event) {
                    showCurrentMenu(agreeDiv, this, event);
                }
            }
        }
    }
    function showCurrentMenu(agreeDiv, currentObj, event) {
        if (!event) { event = window.event; }
        var eventObj = event.srcElement ? event.srcElement : event.target;
        //先隐藏所有ul
        var length = agreeDiv.length;
        for (var i = 0; i < length; i++) {
            if (eventObj.parentNode == agreeDiv[i] || eventObj.nodeName != "H5") { continue; }
            agreeDiv[i].className = "unit";
        }
        if (eventObj.nodeName == "H5") {
            if (eventObj.parentNode.className == "unit") {
                eventObj.parentNode.className = "unit current"
            } else {
                eventObj.parentNode.className = "unit"
            }
        }
    }
    init();
</script>
    </div>
<!--left end-->
<!--right-->
    <div class="right">
      <div class="right-title"><dic id="title_str">管理界面</dic><span><a href="javascript:history.go(-1);">返回</a></span></div>
      <iframe  frameborder="no" border="0" framespacing="0" width="100%" height="500px" scrolling="auto" id="content" src="<%=currentPage %>"></iframe>
    </div>
<!--right end-->
<div class="clr"></div>
</div>
<!--main end-->
<div class="footer">
     
     版权所有 2001- 2011 Copyright © &nbsp;&nbsp;&nbsp;&nbsp; 技术支持：隆晖科技
</div>
</div>
</form>
</body>
</html>
