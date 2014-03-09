<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="updatePassword.aspx.cs" Inherits="Admin_updatePassword" %>

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
<table width="0%" bgcolor="#F6F7F9" align="center">
<tr><td colspan="2"style="font-size: 18px;font-weight: bold;" align="center">密码修改</td></tr>
<tr><td align="right"width="40%">旧密码：</td><td><asp:TextBox ID="TextBox1" runat="server" TextMode="Password" 
        CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="旧密码不能为空！" ForeColor="Red" ControlToValidate="TextBox1" 
        ValidationGroup="update" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right" class="style2">新密码：</td><td class="style2"><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
        CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  
        ForeColor="Red" ControlToValidate="TextBox2"
            ErrorMessage="新密码不能为空！" ValidationGroup="update" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">密码确认：</td><td><asp:TextBox ID="TextBox3" runat="server" TextMode="Password" 
        CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="密码确认不能为空！"  ControlToValidate="TextBox3" ForeColor="Red" 
        ValidationGroup="update" Font-Size="Small" ></asp:RequiredFieldValidator >
    <asp:CompareValidator
                ID="CompareValidator1" runat="server" ErrorMessage="新密码和确认密码不一致!" 
            ControlToCompare="TextBox2" ForeColor="Red" ControlToValidate="TextBox3" 
            ValidationGroup="update" Font-Size="Small"></asp:CompareValidator>
    </td></tr>
<tr><td colspan="2" style="padding-left:350px;">
    <asp:Button ID="Button1" runat="server" Text="确认修改" onclick="Button1_Click"  Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White"
        ValidationGroup="update" Height="36px" Width="88px" />
</td>
</tr>

</table>

</asp:Content>

