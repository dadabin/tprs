<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/index.master" AutoEventWireup="false" CodeFile="ownerInformation.aspx.vb" Inherits="Admin_ownerInformation" %>

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
<table width="50%" align="center"bgcolor="#F6F7F9">
    <tr>
        <td align="right">单位名称：</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right"> 法人代表：</td>
        <td> 
            <asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right"> 业务联系人：</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="text"></asp:TextBox> </td>
    </tr>
    <tr>
        <td align="right"> 联系电话：</td>
        <td> 
            <asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">所属区县：</td>
        <td> 
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr> 
        <td align="right">注册资金：</td>
        <td> 
            <asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">注册地址：</td>
        <td> 
            <asp:TextBox ID="TextBox6" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr> 
        <td align="right">电子邮件：</td>
        <td> 
            <asp:TextBox ID="TextBox7" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr> 
        <td align="right">营业范围：</td>
        <td> 
            <asp:TextBox ID="TextBox8" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr> 
       <td align="center" colspan="2"> 
           <asp:Button ID="Button1" runat="server"  Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White"  Text="保存" Height="31px" Width="98px" /></td>
    </tr>


</table>
</asp:Content>

