<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="viewComment.aspx.cs" Inherits="Admin_viewComment" %>

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
<table bgcolor="#F6F7F9" width="80%"align="center">
        <tr>
            <td class="style1"><h3 align="center">领导点评内容</h3></td>
        </tr>
        <tr> <td align="center"> 
            <asp:TextBox ID="TextBox1" runat="server" Height="164px" TextMode="MultiLine" 
                Width="881px"></asp:TextBox></td>
        </tr>
    
        <tr>
            <td class="style1"><h3 align="center">回复点评</h3></td>
        </tr>
        <tr> 
           <td align="center"> 
               <asp:TextBox ID="TextBox2" runat="server" Height="154px" TextMode="MultiLine" 
                   Width="886px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="Button2" runat="server"
                 BackColor="#1C60EC" ForeColor="White"   Text="提交" onclick="Button2_Click" Height="35px" Width="106px" /></td>
        </tr>
    </table>
</asp:Content>

