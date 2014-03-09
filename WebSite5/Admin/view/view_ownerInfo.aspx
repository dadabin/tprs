<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="view_ownerInfo.aspx.cs" Inherits="Admin_view_view_ownerInfo" %>

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
    <table width="50%" align="center" bgcolor="#F6F7F9">
    <tr>
        <td width="30%" align="right">业主姓名：</td>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label> </td>
        
    </tr>
    <tr>
        <td width="30%" align="right">单位名称：</td>
        <td width="50%"> <asp:Label ID="Label1" runat="server" Text="" Height="20px" Width="200px"></asp:Label></td>
    </tr>
    <tr>
        <td align="right" class="style1"> 法人代表：</td>
        <td class="style1"> 
            <asp:Label ID="Label2" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" class="style1"> 业务联系人：</td>
        <td class="style1">
            <asp:Label ID="Label3" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">联系电话：</td>
        <td> 
            <asp:Label ID="Label4" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">所属区县：</td>
        <td> 
            <asp:Label ID="Label5" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr> 
        <td align="right">注册资金：</td>
        <td> 
            <asp:Label ID="Label6" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">注册地址：</td>
        <td> 
            <asp:Label ID="Label7" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr> 
        <td align="right">电子邮件：</td>
        <td> 
            <asp:Label ID="Label8" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr> 
        <td align="right">营业范围：</td>
        <td> 
            <asp:Label ID="Label9" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

