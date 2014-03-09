<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="view_admin1Info.aspx.cs" Inherits="Admin_view_view_admin1Info" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="50%"align="center" bgcolor="#F6F7F9">
<tr><td align="right"width="30%">姓名：</td><td width="50%" align="left">
    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="lable" 
        Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td align="right" class="style1">帐号：</td><td align="left" class="style1" >
    <asp:Label ID="Label2" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td align="right" class="style1">密码：</td><td class="style1" align="left">
    <asp:Label ID="Label3" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td align="right">电话：</td><td align="left">
    <asp:Label ID="Label4" runat="server" Text="Label" EnableTheming="False" 
        Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td align="right">邮件：</td><td align="left">
    <asp:Label ID="Label5" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
    </td></tr>
<tr><td align="right">所属地区：</td><td align="left">
    <asp:Label ID="Label6" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
</td></tr>
</table>

</asp:Content>

