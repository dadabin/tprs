<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemsubmitreport_admin1.aspx.cs" Inherits="Admin_itemsubmitreport_admin1" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
审核报告
<table>
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>
    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>
    </td><td></td></tr>
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td></td><td></td></tr>
</table>
</asp:Content>

