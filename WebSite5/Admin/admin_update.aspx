<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="admin_update.aspx.cs" Inherits="Admin_admin_update" %>

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
    <div style="border-width:10px">
<table width="50%" align="center"bgcolor="#F6F7F9" >
<tr><td width="50%"><table  width="100%">
<tr><td width="30%" align="right">账号：</td><td width="0%"><asp:TextBox ID="loginusername" 
        runat="server" ReadOnly="true" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ValidationGroup="add"  ControlToValidate="loginusername" 
            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">密码：</td><td><asp:TextBox ID="TextBox1" runat="server" 
        TextMode="Password" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox1"  ValidationGroup="add" ForeColor="Red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right" class="style1">姓名：</td><td class="style1">
    <asp:TextBox ID="username" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="add" ForeColor="Red" ControlToValidate="username"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">办公室电话：</td><td>
<asp:TextBox ID="tel" runat="server" CssClass="text"></asp:TextBox></td></tr>
<tr><td align="center" colspan="2">
    <asp:Button ID="update_admin_but" runat="server" ValidationGroup="add" Text="修改"  BackColor="#1C60EC" ForeColor="White"
        onclick="update_admin_but_Click" Height="34px" Width="85px" /></td></tr>
</table></td></tr>
    </table>

</div>
</asp:Content>

