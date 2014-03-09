<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="statistics_admin1.aspx.cs" Inherits="Admin_statistics" Theme="style" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
  table
  { border-collapse:collapse; }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%">
<tr><td  width="10%"></td><td width="80%">
    <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
    <Columns>
    <asp:TemplateField HeaderText="项目编号">
    <ItemTemplate>
    <%#Eval("num")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("name") %>
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField HeaderText="所属区县">
    <ItemTemplate>
    <%#Eval("address") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("reporttime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="业主信息">
    <ItemTemplate>
     <%#Eval("onwer") %>
    </ItemTemplate>
    </asp:TemplateField>
  
 

    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td>
    <webdiyer:AspNetPager ID="AspNetPager1" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server" 
        onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>
</td><td></td></tr>
<tr><td></td><td></td></tr>
</table>

</asp:Content>

