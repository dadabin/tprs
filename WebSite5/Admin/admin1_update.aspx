<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="admin1_update.aspx.cs" Inherits="Admin_admin1_update" %>

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
<table width="60%" align="center" bgcolor="#F6F7F9">
<tr><td align="right">&nbsp;帐号：</td><td><asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
        ValidationGroup="update" ForeColor="Red" ControlToValidate="TextBox2" 
        runat="server" ErrorMessage="帐号不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
        <tr><td align="right">&nbsp;所属区县：</td><td><asp:DropDownList 
                ID="DropDownList1" runat="server" Height="25px" Width="205px">
    <asp:ListItem Value="lq" Text="龙泉驿区"></asp:ListItem>
    <asp:ListItem Value="qbj" Text="青白江区"></asp:ListItem>
    <asp:ListItem Value="xj" Text="新津县"></asp:ListItem>
    <asp:ListItem Value="jt" Text="金堂县" ></asp:ListItem>
    <asp:ListItem Value="sl" Text="双流县"></asp:ListItem>
    </asp:DropDownList></td></tr>
        <tr><td align="right" class="style1">&nbsp;姓名：</td><td class="style1"><asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="update" 
                ForeColor="Red" ControlToValidate="TextBox1" runat="server" 
                ErrorMessage="姓名不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">&nbsp;密码：</td><td><asp:TextBox ID="TextBox3" runat="server" TextMode="Password" 
        CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
        ValidationGroup="update" ForeColor="Red" ControlToValidate="TextBox3" 
        runat="server" ErrorMessage="密码不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">&nbsp;电话：</td><td><asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
        ValidationGroup="update" ForeColor="Red" ControlToValidate="TextBox4" 
        runat="server" ErrorMessage="电话不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right"> &nbsp;邮箱：</td><td><asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
        ControlToValidate="TextBox5" ForeColor="Red" runat="server" 
        ErrorMessage="邮箱不能为空！" ValidationGroup="update" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td colspan="2" style="padding-left:150px;">
    <asp:Button ID="Button1" runat="server" Text="修改" ValidationGroup="update" 
           BackColor="#1C60EC" ForeColor="White"  onclick="Button1_Click" Height="35px" Width="82px" /></td></tr>
</table>

</asp:Content>

