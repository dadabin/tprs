<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="excel_report_admin2.aspx.cs" Inherits="Admin_excel_report_admin2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 body{font-size:13px;}
 td
 {
      border: 1px #2042eb solid;
      height:30px;
  }
   table 
   {
      border-collapse:collapse;
      margin-bottom: 0px;
    }
    .style1
    {
        width: 249px;
    }
 </style>
<script type="text/javascript">
    function openExcelLoad(url) {
        window.open(url);
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" runat="server" id="season">

<tr><td align="center" width="10%" style="font-weight: bold; font-size: 15px;">序号</td>
    <td align="center" width="30%" style="font-weight: bold; font-size: 15px;">季度</td>
    <td align="center" 
        class="style1" width="30%" style="font-weight: bold; font-size: 15px;">项目类型</td>
    <td align="center"  width="30%" style="font-weight: bold; font-size: 15px;">点击查看</td></tr>
<tr><td align="center">1.</td><td align="center"><%=myNowYear %>年第一季度季报</td><td align="center" 
        class="style1">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    <td align="center">
        <asp:Button ID="Button1" runat="server" Text="点击查看" Height="30px"  BackColor="#3889ee"/></td></tr>
<tr><td align="center">2.</td><td align="center"><%=myNowYear %>年第二季度季报</td><td align="center" 
        class="style1">
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    <td align="center">
        <asp:Button ID="Button2" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee" /></td></tr>
<tr><td align="center">3.</td><td align="center"><%=myNowYear %>年第三季度季报</td><td align="center" 
        class="style1">
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
    <td align="center">
        <asp:Button ID="Button3" runat="server" Text="点击查看" Height="30px"  BackColor="#3889ee" /></td></tr>
<tr><td align="center">4.</td><td align="center"><%=myNowYear %>年第四季度季报</td><td align="center" 
        class="style1">
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
    <td align="center">
        <asp:Button ID="Button4" runat="server" Text="点击查看" Height="30px"  BackColor="#3889ee"/></td></tr>
</table>

<br />
<table runat="server" width="100%" id="month">
<tr><td style="font-weight: bold; font-size: 15px;" align="center" width="10%">序号</td>
    <td style="font-weight: bold; font-size: 15px;" align="center" width="30%">月份</td>
    <td style="font-weight: bold; font-size: 15px;" align="center" width="30%">报告名称</td>
    <td style="font-weight: bold; font-size: 15px;" align="center" width="30%">点击查看</td></tr>
<tr><td align="center">1.</td><td align="center"><%=myNowYear %>年第一月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年一月份月报</td>
    <td align="center">
    <asp:Button ID="Button5" runat="server" Text="点击查看" BackColor="#3889ee" 
            Height="30px"/></td></tr>
<tr><td align="center">2.</td><td align="center"><%=myNowYear %>年第二月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年二月份月报</td>
    <td align="center">
    <asp:Button ID="Button6" runat="server" Text="点击查看" BackColor="#3889ee" 
            Height="30px" /></td></tr>
<tr><td align="center">3.</td><td align="center"><%=myNowYear %>年第三月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年三月份月报</td>
    <td align="center">
    <asp:Button ID="Button7" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee"/></td></tr>
<tr><td align="center">4.</td><td align="center"><%=myNowYear %>年第四月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年四月份月报</td>
    <td align="center">
    <asp:Button ID="Button8" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee" /></td></tr>
<tr><td align="center">5.</td><td align="center"><%=myNowYear %>年第五月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年五月份月报</td>
    <td align="center">
    <asp:Button ID="Button9" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee" /></td></tr>
<tr><td align="center">6.</td><td align="center"><%=myNowYear %>年第六月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年六月份月报</td>
    <td align="center">
    <asp:Button ID="Button10" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee"/></td></tr>
<tr><td align="center">7.</td><td align="center"><%=myNowYear %>年第七月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年七月份月报</td>
    <td align="center">
    <asp:Button ID="Button11" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee"/></td></tr>
<tr><td align="center">8.</td><td align="center"><%=myNowYear %>年第八月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年八月份月报</td>
    <td align="center">
    <asp:Button ID="Button12" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee"/></td></tr>
<tr><td align="center">9.</td><td align="center"><%=myNowYear %>年第九月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年九月份月报</td>
    <td align="center">
    <asp:Button ID="Button13" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee" />
</td></tr>
<tr><td align="center">10.</td><td align="center"><%=myNowYear %>年第十月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年十月份月报</td>
    <td align="center">
    <asp:Button ID="Button14" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee"/></td></tr>
<tr><td align="center">11.</td><td align="center"><%=myNowYear %>年第十一月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年十一月份月报</td>
    <td align="center">
    <asp:Button ID="Button15" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee" /></td></tr>
<tr><td align="center">12.</td><td align="center"><%=myNowYear %>年第十二月</td><td align="center">龙泉山生态旅游功能区重大项目<%=myNowYear %>年十二月份月报</td>
    <td align="center">
    <asp:Button ID="Button16" runat="server" Text="点击查看" Height="30px" BackColor="#3889ee" /></td></tr>
</table>

</asp:Content>

