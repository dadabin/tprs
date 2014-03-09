<%@ Page Language="C#" AutoEventWireup="true" CodeFile="season_select.aspx.cs" Inherits="season_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
　　<!--
        function sss() {

            window.moveTo(-4, -4)
            window.resizeTo(screen.availWidth + 9, screen.availHeight + 9)

        }
　　        function openwin(url) {
            // window.open("season_select.aspx?reportid=" + url, "", "top=100, left=200");
            window.open("season_select.aspx?reportid=" + url, "", "width=500,height=600,top=100, left=200,status=yes,toolbar=no,scrollbars=yes,resizable=yes");
        }

　　//-->
　　</script>
<style type="text/css">
<%-- body{font-size:15px;}
 td
 {
  border: 1px #2042eb solid;
  height:30px;
  }
  table
  {
      border-collapse:collapse;
  }--%>
 </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
    <tr><td></td><td>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label><br />
        <hr  style="  border: 1px #2042eb solid; height:0px"/></td><td></td></tr>
    <tr><td width="10%"></td><td width="80%" align="center" 
            style="font-size: 16px; font-weight: bold">
        <asp:Label ID="Label1" runat="server" 
            Text="Label" Height="20px" Width="566px"></asp:Label>
        <asp:Button ID="Button1" 
            runat="server" Text="导出word" onclick="Button1_Click" Height="30px" /></td><td>
            &nbsp;</td></tr>
    
    <tr><td width="10%"></td><td width="80%"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
            <br />
    </td><td></td></tr>
    </table>
        
        <br />
        <br />
        
    </div>
    </form>
</body>
</html>
