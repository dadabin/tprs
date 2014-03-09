<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="season_list.aspx.cs" Inherits="Admin_season_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 body{font-size:15px;}
 td
 {
    border: 1px #2042eb solid;
  height:30px;
  }
  table
  {
      border-collapse:collapse;
  }
 </style>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" align="center" id="admin1_admin2">
 <tr><td align="center" colspan="5" style="font-size: 20px; font-weight: bold;">报告列表</td></tr>
 <tr><td width="20%" align="center"><asp:Label ID="Label5" runat="server" Height="20px" Width="200px"></asp:Label></td>
     <td align="center"><%=myNowyear %>第一季度季报(填报时间：<asp:Label ID="Label1" runat="server" Text=""></asp:Label>)</td>
     <td align="center"><asp:Button ID="Button1" runat="server" Text="填报"  Font-Size="13px" BackColor="#2480F1" oncommand="Button1_Command"  Height="30px"  Width="70px" /></td>
     <td align="center"><asp:Button ID="Button5" runat="server" Font-Size="13px" 
             Text="提交" BackColor="#2480F1" OnClientClick="javascript:return confirm('提交后无法修改，是否提交？')&&confirm('请再次确认，是否提交？');"    Height="30px"  Width="70px" 
             oncommand="Button5_Command" /></td>
     <td align="center"><asp:Button ID="Button9" runat="server" Font-Size="13px" Text="查看" oncommand="Button9_Command" Height="30px" BackColor="#2480F1"  Width="70px" /></td>
</tr>
<tr><td align="center"><asp:Label ID="Label6" runat="server" Height="20px" Width="200px"></asp:Label></td>
    <td align="center"><%=myNowyear %>第二季度季报(填报时间：<asp:Label ID="Label2" runat="server" Text=""></asp:Label>)</td>
    <td align="center"><asp:Button ID="Button2" runat="server" BackColor="#2480F1"  Text="填报"   Font-Size="13px" oncommand="Button2_Command" Height="30px" Width="70px" /></td>
    <td align="center"><asp:Button ID="Button6" runat="server" Text="提交" OnClientClick="javascript:return confirm('提交后无法修改，是否提交？')&&confirm('请再次确认，是否提交？');"  
            BackColor="#2480F1" Height="30px" Width="70px"  Font-Size="13px" 
            oncommand="Button6_Command"/></td>                 
    <td align="center"><asp:Button ID="Button10"   Font-Size="13px" runat="server"  Height="30px" Width="70px" Text="查看" BackColor="#2480F1" oncommand="Button10_Command" /></td>
</tr>
<tr><td align="center"><asp:Label ID="Label7" runat="server" Height="20px" Width="200px"></asp:Label></td>
    <td align="center"><%=myNowyear %>第三季度季报(填报时间：<asp:Label ID="Label3" runat="server" Text=""></asp:Label>)</td>
    <td align="center"><asp:Button ID="Button3" runat="server" Text="填报" Height="30px" Width="70px" Font-Size="13px" BackColor="#2480F1" oncommand="Button3_Command" /></td>
    <td align="center"><asp:Button ID="Button7" runat="server" Height="30px" OnClientClick="javascript:return confirm('提交后无法修改，是否提交？')&&confirm('请再次确认，是否提交？');"  
            Width="70px" BackColor="#2480F1"  Text="提交"  Font-Size="13px" 
            oncommand="Button7_Command" /></td>
    <td align="center"><asp:Button ID="Button11" Height="30px" Width="70px" runat="server"  Text="查看"  oncommand="Button11_Command" BackColor="#2480F1"  Font-Size="13px"/></td>
</tr>
<tr><td align="center"><asp:Label ID="Label8" runat="server" Height="20px" Width="200px"></asp:Label></td>
    <td align="center"><%=myNowyear %>第四季度季报(填报时间：<asp:Label ID="Label4" runat="server" Text=""></asp:Label>)</td>
    <td align="center"><asp:Button ID="Button4" runat="server" Text="填报" Height="30px" Width="70px" Font-Size="13px" BackColor="#2480F1" oncommand="Button4_Command" /></td>
    <td align="center"><asp:Button ID="Button8" runat="server" Height="30px"  OnClientClick="javascript:return confirm('提交后无法修改，是否提交？')&&confirm('请再次确认，是否提交？');" 
            Width="70px" Text="提交"  BackColor="#2480F1"   Font-Size="13px" 
            oncommand="Button8_Command"/></td>
    <td align="center">
        <asp:Button ID="Button12" Height="30px" Width="70px" 
            runat="server" Text="查看" oncommand="Button12_Command" Font-Size="13px" 
            BackColor="#2480F1" /></td>
</tr>
</table>
</asp:Content>

