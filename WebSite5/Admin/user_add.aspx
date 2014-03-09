<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="user_add.aspx.cs" Inherits="Admin_user_add" %>

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
<table width="60%" align="center">
<tr><td align="right" width="30%">&nbsp;姓名：</td><td>
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="姓名不能为空！"  
        ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">&nbsp;登陆名：</td><td>
    &nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
        ControlToValidate="TextBox2" runat="server" ForeColor="Red" 
        ErrorMessage="登陆名不能为空！" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">&nbsp;密码：</td><td>
    &nbsp;<asp:TextBox ID="TextBox3" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="密码不能为空！" ValidationGroup="add" 
        ControlToValidate="TextBox3" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>

<tr><td colspan="2" align="center">
    <asp:Button ID="Button1" runat="server" Text="添加" ValidationGroup="add" Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White" onclick="Button1_Click1" Height="35px" Width="91px" /></td></tr>
</table>

</asp:Content>

