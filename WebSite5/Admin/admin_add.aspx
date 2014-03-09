<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="admin_add.aspx.cs" Inherits="Admin_admin_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 body{font-size:15px;}
 td
 {
      border: 1px #2042eb solid;
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
      margin-bottom: 0px;
    }

 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="50%"align="center" bgcolor="#F6F7F9">
<tr><td width="30%" align="right">账号：</td><td>
    <asp:TextBox ID="loginusername" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ValidationGroup="add"  ControlToValidate="loginusername" 
            ErrorMessage="账号不能为空！" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">密码：</td><td>
    <asp:TextBox ID="login_password" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
        ControlToValidate="login_password"  ValidationGroup="add" ForeColor="Red" 
        runat="server" ErrorMessage="密码不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right" class="style1">姓名：</td><td class="style1">
    <asp:TextBox ID="username" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  
        ErrorMessage="姓名不能为空！" ValidationGroup="add" ForeColor="Red" 
        ControlToValidate="username" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">办公室电话：</td><td>
    <asp:TextBox ID="tel" runat="server" CssClass="text"></asp:TextBox></td></tr>
<tr><td colspan="2" align="center">
    <asp:Button ID="add_admin_but" runat="server" ValidationGroup="add" Text="添加" 
        onclick="add_admin_but_Click" Height="31px" Width="77px" 
        BackColor="#1C60EC" ForeColor="White" /></td></tr>
</table>
</asp:Content>

