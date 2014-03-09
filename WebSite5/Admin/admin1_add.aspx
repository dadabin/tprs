<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="admin1_add.aspx.cs" Inherits="Admin_admin1_add" %>

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
<table width="60%"bgcolor="#F6F7F9" align="center">
<tr><td width="20%" align="right">&nbsp;姓名：</td><td width="40%"><asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" ValidationGroup="add" ErrorMessage="姓名不能为空！"  
        ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td class="style1" align="right">&nbsp;帐号：</td><td class="style1"><asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="账号不能为空！" ControlToValidate="TextBox2" ValidationGroup="add" 
        ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">&nbsp;密码：</td><td><asp:TextBox ID="TextBox3" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  
        ForeColor="Red" ControlToValidate="TextBox3" ValidationGroup="add" 
        ErrorMessage="密码不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">&nbsp;电话：</td><td><asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox>
        </td></tr>
<tr><td align="right">&nbsp;邮件：</td><td><asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox></td></tr>
<tr><td align="right" class="style1">&nbsp;所属地区：</td><td class="style1"><asp:DropDownList ID="DropDownList1" runat="server" Height="25px" 
        Width="205px">
    <asp:ListItem Value="lqy" Text="龙泉驿区"></asp:ListItem>
    <asp:ListItem Value="qbj" Text="青白江区"></asp:ListItem>
    <asp:ListItem Value="xj" Text="新津县"></asp:ListItem>
    <asp:ListItem Value="jt" Text="金堂县" ></asp:ListItem>
    <asp:ListItem Value="sl" Text="双流县"></asp:ListItem>
    </asp:DropDownList>
</td></tr>
<tr><td colspan="2" align="center">
    <asp:Button ID="Button1" runat="server" Text="添加" ValidationGroup="add" 
        onclick="Button1_Click" BackColor="#1C60EC" ForeColor="White" Height="34px" Width="90px" /></td></tr>
</table>

</asp:Content>

