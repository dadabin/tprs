<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="season_report.aspx.cs" Inherits="Admin_season_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 body{font-size:15px;}
 td
 {border: 1px #2042eb solid;
  height:30px;
  }
  .text
  {
      width:200px;
      height:20px;
  }
  table
  {
      border-collapse:collapse;
  }
 </style>
 <script type="text/javascript">
　　<!--
　　     function openwin(url) {
         //window.open("../season_select.aspx?reportid=" + url, "", "width=500,height=900,top=100, left=200")
         window.open("../season_select.aspx?reportid=" + url, "", "width=500,height=600,top=100, left=200,status=yes,toolbar=no,scrollbars=yes,resizable=yes");
     }
　　//-->
　　</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="center">
<tr><td></td><td><%bindlist();%></td><td></td></tr>
<tr><td width="10%">



</td><td width="80%" align="center"> 
    <asp:Label ID="Label1" 
        runat="server" Text="Label" Height="25px" Width="242px"></asp:Label><br />
        <asp:TextBox ID="TextBox1" runat="server"  Height="433px" 
        TextMode="MultiLine" Width="802px"></asp:TextBox><br />
         <asp:Button ID="Button1" runat="server"  BackColor="#2480F1" Font-Size="14px" 
        ForeColor="White" Text="保存" onclick="Button1_Click" Height="31px" 
        Width="93px" />
        </td><td></td></tr>

</table>
</asp:Content>

