<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="reback_admin1.aspx.cs" Inherits="Admin_reback_admin1" %>

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
<script language="javascript"  type="text/javascript">
    function getconfirm() {
        if (confirm("您是否要关闭？") == true) {

            window.open('', '_parent', '');
            window.top.opener = null;
            window.close();
            return true;
        }
        else {
            return false;
        }
    }
    </script>

<table bgcolor="#F6F7F9" width="50%"align="center">
        <tr>
            <td class="style1"><h3 align="center">退回原因</h3></td>
        </tr>
          <tr align="right">
                  <td><asp:Button ID="Btn_Close" runat="server" Text="关闭" Width="39px" 
                          BackColor="#1C60EC" ForeColor="White"  OnClick="Btn_Close_Click" 
                          OnClientClick="return getconfirm()" Height="24px" Font-Size="14px" /></td>
          </tr>
        <tr> 
           <td> 
               <asp:TextBox ID="reason" runat="server" Height="175px" TextMode="MultiLine" 
                   Width="655px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="Button2" runat="server" BackColor="#1C60EC" ForeColor="White"   
                    Text="提交" onclick="Button2_Click" Height="35px" Width="77px" 
                    Font-Size="14px" /></td>

        </tr>
    </table>

</asp:Content>

