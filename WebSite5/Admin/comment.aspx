<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="comment.aspx.cs" Inherits="Admin_comment" %>

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
<table width="60%"bgcolor="#F6F7F9" align=center>
    <tr>
        <td><h3 align="center">请输入点评内容</h3></td>    
    </tr>
    <tr>  
        <td align="center">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="237px" 
                Width="604px"></asp:TextBox></td>    
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="Button2" runat="server" Text="提交" onclick="Button2_Click" 
            BackColor="#1C60EC" ForeColor="White"    Height="35px" Width="87px" /></td>    
    </tr>
</td></table>

</asp:Content>

