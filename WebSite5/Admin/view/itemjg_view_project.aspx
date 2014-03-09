<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemjg_view_project.aspx.cs" Inherits="Admin_view_itemjg_view_project" %>

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
<tr><td colspan="4" align="center" class="style2" style="font-size: 16px">基本信息</td></tr>
<tr><td  align="right" width="20%">所属区县：</td><td class="style1" width="25%">
    <asp:Label ID="Label2" runat="server" Text="区县" Height="20px" Width="200px"></asp:Label>
    </td><td  width="20%" align="right">项目名称：</td>
    <td width="25%">
        <asp:Label ID="Label3" runat="server" Text="Label" Height="20px" Width="300px"></asp:Label>
    </td>
</tr>
<tr><td class="style1" align="right" >建设地址：</td>
    <td class="style1" >
        <asp:Label ID="Label4" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
    </td>
    <td class="style1" align="right" >建设起止年限：</td>
    <td class="style1">
        <asp:Label ID="Label5" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
    </td>
</tr>
<tr><td align="right" >项目建设规模：</td><td colspan="3">
    <asp:Label ID="Label6" runat="server" Text="Label" Height="70px" Width="680px"></asp:Label>
    </td>
</tr>
<tr><td align="right" >计划总投资：</td><td style="font-size: 13px">
    <asp:Label ID="Label7" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
    (万元)</td>
    <td align="right" ><%=submitTime.Year %>年计划投资：</td><td style="font-size: 13px">
        <asp:Label ID="Label8" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
       (万元) </td>
</tr>
<tr><td align="right"><%=submitTime.Year %>年底工程应达形象进度：</td><td colspan="3">
    <asp:Label ID="Label9" runat="server" Text="Label" Height="70px" Width="680px"></asp:Label>
    </td></tr>
<tr><td align="right">至<%=submitTime.Year-1 %>年已累计完成投资：</td><td style="font-size: 13px">
        <asp:Label ID="Label10" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
        (万元)</td>
        <td align="right"><%=submitTime.Year %>年<%if (submitTime.Month - 1 == 0) { Response.Write(1); } else { Response.Write(submitTime.Month - 1); } %>月完成投资：</td><td style="font-size: 13px">
            <asp:Label ID="Label11" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
            (万元)</td></tr>
<tr>
        <td align="right"> <%=submitTime.Year %>年1-<% if (submitTime.Month - 1 == 0) { Response.Write(1); } else { Response.Write(submitTime.Month - 1); } %>月完成投资：</td><td><asp:Label ID="Label12" 
            runat="server" Text="Label" Height="20px" Width="200px"> （万元）</asp:Label></td>
        <td align="right">四个一批范畴：</td>
        <td> 
            <asp:Label ID="DropDownList1" runat="server" Height="25px" Width="205px">
               
            </asp:Label>
        </td>
</tr>
            <tr><td align="right">目前形象进度：</td><td colspan="3">
                <asp:Label ID="Label13" runat="server" Text="Label" Height="70px" Width="680px"></asp:Label>
                </td></tr>
<tr>
    <td align="right">图片列表：</td><td colspan="3">&nbsp;&nbsp; 
       &nbsp; 
&nbsp;        &nbsp;<asp:DataList ID="DataList1"  RepeatColumns="5" Width="100%" Height="155px"  runat="server">
    <ItemTemplate>
   <a class="imagePro" href='../<%#Eval("path") %>'> <img style="height: 155px; width: 152px" alt="图片" src='../<%#Eval("path") %>'  /></a>
    </ItemTemplate>
    </asp:DataList>
    </td></tr>
    </table>
</asp:Content>

