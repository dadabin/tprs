<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="view_opinion.aspx.cs" Inherits="Admin_view_opinion" %>

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
<table width="100%"bgcolor="#F6F7F9">
<tr> <td colspan="4" align="center" class="style3" style="font-size: 16px"> 点评详情</td></tr>

<tr>
<td align="right" width="20%">点评人：</td>
<td class="style1"><asp:Label ID="Label1" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="20%">点评时间：</td>
<td class="style1"><asp:Label ID="Label2" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="20%">详情：</td>
<td class="style1"><asp:Label ID="Label3" runat="server" ></asp:Label>
</td>
</tr>

<tr>
<td align="right" width="20%">回复人：</td>
<td class="style1"><asp:Label ID="Label4" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="20%">回复时间：</td>
<td class="style1"><asp:Label ID="Label5" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="20%">回复详情：</td>
<td class="style1"><asp:Label ID="Label6" runat="server" ></asp:Label>
</td>
</tr>



</table>



</asp:Content>

