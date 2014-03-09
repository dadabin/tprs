<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="updateInformation.aspx.cs" Inherits="Admin_updateInformation" %>

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
<tr><td align="center">修改个人资料</td></tr>  
<tr><td width="80%">
<table runat="server" id="table1" visible="false" width="100%">
<tr><td align="right" class="style5">姓名：</td><td>
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox></td></tr>
    <tr><td align="right" class="style6">登陆账号：</td><td class="style7">
        &nbsp;<asp:Label ID="Label2" runat="server" Height="20px" Width="200px"></asp:Label>
        </td></tr>
<tr><td align="right" class="style5">办公室电话：</td><td>
    &nbsp<asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="200px"></asp:TextBox></td></tr>
<tr><td style="padding-left:150px;"></td><td><asp:Button ID="Button1" runat="server" Text="保存"  Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White" 
        onclick="Button1_Click" Height="32px" Width="87px" /></td></tr>
</table>
<table runat="server" id="table2" visible="false" width="100%">
<tr><td align="right">姓名：</td><td>
    &nbsp<asp:TextBox ID="TextBox3" runat="server" Height="20px" Width="200px"></asp:TextBox></td></tr>
    <tr><td align="right">登陆账号：</td><td>
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Height="20px" 
            Width="200px"></asp:Label>
        </td></tr>
<tr><td align="right">电话：</td><td>
    &nbsp<asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="200px"></asp:TextBox></td></tr>
<tr><td align="right">邮箱：</td><td>
    &nbsp<asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="200px"></asp:TextBox></td></tr>
<tr><td style="padding-left:150px;"></td><td>
    <asp:Button ID="Button2" runat="server" Text="保存" onclick="Button2_Click" Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White" 
        Height="36px" Width="89px" /></td></tr>
</table>
<table runat="server" id="table3" visible="false" width="100%">
<tr><td align="right">姓名：</td><td>
    &nbsp<asp:TextBox ID="TextBox14" runat="server" Height="20px" Width="200px"></asp:TextBox>
    </td></tr>
    <tr><td align="right">登陆账号：</td><td>
        &nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Height="20px" 
            Width="200px"></asp:Label>
        </td></tr>
     <tr><td align="right">所属区县：</td><td>
         &nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Height="20px" 
             Width="200px"></asp:Label>
     </td></tr>
<tr><td align="right">电话号码：</td><td>
    &nbsp<asp:TextBox ID="TextBox15" runat="server" Height="20px" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right">电子邮箱：</td><td>
    &nbsp<asp:TextBox ID="TextBox16" runat="server" Height="20px" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td style="padding-left:150px;"></td><td><asp:Button ID="Button4" runat="server" Text="保存" onclick="Button4_Click" Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White" 
        Height="38px" Width="85px" />
    </td></tr>
</table>
<table runat="server" id="table4" visible="false" width="100%">
<tr><td align="right" class="style2">姓名：</td><td>
    &nbsp<asp:TextBox ID="TextBox6" runat="server" Height="20px" Width="200px"></asp:TextBox>
    </td></tr>
    <tr><td align="right" class="style2">登陆账号：</td><td>
        &nbsp<asp:TextBox ID="TextBox17" runat="server" ReadOnly="true" Height="20px" Width="200px"></asp:TextBox></td></tr>
    <tr><td align="right" class="style2">所属区县：</td><td>
        &nbsp;<asp:Label ID="Label1" runat="server" Height="20px" 
            Width="200px"></asp:Label>
        </td></tr>
<tr><td align="right" class="style2">单位名称：</td><td>
    &nbsp<asp:TextBox ID="TextBox7" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style2">法人代表：</td><td>
    &nbsp<asp:TextBox ID="TextBox8" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style2">业务联系人：</td><td>
    &nbsp<asp:TextBox ID="TextBox9" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style2">注册资金：</td><td>
    &nbsp<asp:TextBox ID="TextBox10" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style2">注册地址：</td><td>
    &nbsp<asp:TextBox ID="TextBox11" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style2">电子邮件：</td><td>
    &nbsp<asp:TextBox ID="TextBox12" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style4">营业范围：</td><td class="style1">
    &nbsp<asp:TextBox ID="TextBox13" runat="server" Width="200px"></asp:TextBox>
    </td></tr>
<tr><td align="right" class="style2">联系电话：</td><td> &nbsp<asp:TextBox ID="TextBox18" 
        runat="server" Height="21px" Width="200px"></asp:TextBox></td></tr>
<tr><td style="padding-left:150px;"></td><td>
    <asp:Button ID="Button3" runat="server" Text="保存" onclick="Button3_Click" Font-Size="14px"
     BackColor="#1C60EC" ForeColor="White" 
        Height="34px" Width="85px" /></td></tr>


</table>

</td></tr></table>

</asp:Content>

