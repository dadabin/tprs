<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itembh_view_project.aspx.cs" Inherits="Admin_view_itembh_view_project" %>

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
  <link rel="stylesheet" href="js/css/lrtk.css" />
<script type="text/javascript" src="js/js/jquery.min.js"></script>
<script type="text/javascript" src="js/js/jquery.imgbox.pack.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $(".imagePro").imgbox({
	            'speedIn': 0,
	            'speedOut': 0,
	            'alignment': 'center',
	            'overlayShow': true,
	            'allowMultiple': false
	        });
	    });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%"bgcolor="#F6F7F9">
<tr> <td colspan="4" align="center" class="style3" style="font-size: 16px"> 基本信息</td></tr>
<tr><td align="right" width="20%" >所属区县：</td><td width="30%" 
        class="style2">
    <asp:Label ID="Label2" runat="server" Text="区县" Height="20px" Width="200px"></asp:Label>
   </td>
<td align="right" class="style2" width="20%">工程名称：</td><td class="style2">
    <asp:Label ID="Label3" runat="server" Height="20px" Width="300px"></asp:Label>
    </td></tr>
<tr><td align="right">建设地址：</td><td>
    <asp:Label ID="Label4" runat="server" Height="20px" Width="200px"></asp:Label>
    </td>
<td align="right" class="style2">完工时间：</td><td>
    <asp:Label ID="Label5" runat="server" Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td class="style1" align="right">水域面积：</td><td class="style1" style="font-size: 13px">
    <asp:Label ID="Label6" runat="server" Height="20px" Width="200px"></asp:Label>
    （亩）</td>
<td class="style2" align="right">省级以上财政：</td><td class="style1" style="font-size: 13px">
    <asp:Label ID="Label7" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td></tr>
<tr><td align="right">市级财政：</td><td style="font-size: 13px">
    <asp:Label ID="Label8" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td>
<td align="right" class="style2">县级财政：</td><td style="font-size: 13px">
    <asp:Label ID="Label9" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td></tr>
<tr><td align="right">财政融资：</td><td style="font-size: 13px">
    <asp:Label ID="Label10" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td>
<td align="right" class="style2">社会投入：</td><td style="font-size: 13px">
    <asp:Label ID="Label11" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td></tr>
<tr><td align="right">群众投入：</td><td style="font-size: 13px">
    <asp:Label ID="Label12" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td>
<td align="right" class="style2">其它：</td><td style="font-size: 13px">
    <asp:Label ID="Label13" runat="server" Height="20px" Width="200px"></asp:Label>
    （万元）</td></tr>
<tr><td align="right">占用土地面积：</td><td style="font-size: 13px">
    <asp:Label ID="Label14" runat="server" Height="20px" Width="200px"></asp:Label>
    （亩）</td>
<td align="right" class="style2">占用方式：</td><td>
    <asp:Label ID="Label15" runat="server" Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td align="right">单价：</td><td colspan="3" style="font-size: 13px">
    <asp:Label ID="Label16" runat="server" Height="20px" Width="200px"></asp:Label>
    （元/年*亩）
        </td></tr><tr>
<td align="right">目前工程的形象进度：</td><td colspan="3">
        <asp:Label ID="Label17" runat="server" Height="70px" Width="680px"></asp:Label>
    </td></tr>
<tr><td align="right">管护主体：</td><td>
    <asp:Label ID="Label18" runat="server" Height="20px" Width="200px"></asp:Label>
    </td><td align="right">四个一批范畴：</td><td>
    <asp:Label ID="Label19" runat="server" Height="20px" Width="200px"></asp:Label>
    </td>
</tr>

<tr ><td align="right">图片列表：</td><td colspan="3">
&nbsp;&nbsp;&nbsp; 
    &nbsp;<asp:DataList ID="DataList1"  RepeatColumns="5" Width="100%" Height="155px"  runat="server">
    <ItemTemplate>
   <a class="imagePro" href='../<%#Eval("path") %>'> <img style="height: 155px; width: 152px" alt="图片" src='../<%#Eval("path") %>'  /></a>
    </ItemTemplate>
    </asp:DataList>
&nbsp;</td></tr>
</table>
</asp:Content>

