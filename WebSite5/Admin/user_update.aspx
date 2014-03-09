<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="user_update.aspx.cs" Inherits="Admin_user_add" %>

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
<table width="50%"  align="center">
<tr><td align="right">姓名：</td><td>
     &nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="姓名不能为空！"  ValidationGroup="add"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">登陆名：</td><td>
     &nbsp;<asp:Label ID="Label2" runat="server" Text="Label" 
         EnableTheming="False" Height="20px" Width="200px"></asp:Label>
    </td></tr>
    <tr><td align="right">密码：</td><td>&nbsp;<asp:TextBox
                ID="TextBox3" runat="server" CssClass="text"></asp:TextBox></td></tr>

<tr><td align="right" width="30%">单位名称：</td><td>
     &nbsp;<asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="单位名称不能为空！" ControlToValidate="TextBox4" ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">法人代表：</td><td>
     &nbsp;<asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="法人代表不能为空！" ControlToValidate="TextBox5" ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">业务联系人：</td><td>
     &nbsp;<asp:TextBox ID="TextBox6" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ErrorMessage="业务联系人不能为空！" ControlToValidate="TextBox6" ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">联系电话：</td><td>
     &nbsp;<asp:TextBox ID="TextBox7" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="add" runat="server" 
            ErrorMessage="联系电话不能为空！" ControlToValidate="TextBox7" ForeColor="Red"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">所属区县：</td><td>
 &nbsp;<asp:Label ID="Label1" runat="server" Text="Label" Height="20px" 
        Width="200px"></asp:Label>
    &nbsp;</td></tr>
<tr><td align="right">注册资金：</td><td>
     &nbsp;<asp:TextBox ID="TextBox9" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
            ErrorMessage="注册资金不能为空！" ControlToValidate="TextBox9" 
         ValidationGroup="add" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">注册地址：</td><td>
     &nbsp;<asp:TextBox ID="TextBox10" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
            ErrorMessage="注册地址不能为空！" ControlToValidate="TextBox10" 
         ValidationGroup="add" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">电子邮件：</td><td>
     &nbsp;<asp:TextBox ID="TextBox11" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
            ErrorMessage="电子邮件不能为空！" ControlToValidate="TextBox11" 
         ValidationGroup="add" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">营业范围：</td><td>
     &nbsp;<asp:TextBox ID="TextBox12" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
            ErrorMessage="营业范围不能为空！" ControlToValidate="TextBox12" 
         ValidationGroup="add" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td colspan="2" style="padding-left:200px;">
    <asp:Button ID="Button1" runat="server" Text="修改" ValidationGroup="add"  Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White" onclick="Button1_Click1" Height="31px" Width="96px" /></td></tr>
</table>

</asp:Content>

