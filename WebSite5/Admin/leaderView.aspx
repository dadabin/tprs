<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="leaderView.aspx.cs" Inherits="Admin_leaderView" %>


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
    <%#Eval("itemNumber")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate>
    <%#Eval("itemType") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="所属区县">
    <ItemTemplate>
    <%#Eval("address") %>
    </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="进展类别">
    <ItemTemplate>
    <%#Eval("ProgressCategory")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="季度报">
    <ItemTemplate>
    <%#Eval("season") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="月报">
    <ItemTemplate>
   <%#Eval("month") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="点评">
    <ItemTemplate>
   <%#Eval("comments")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="回复状态">
    <ItemTemplate>
   <%#Eval("replay")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="需要协调的问题">
    <ItemTemplate>
   <%#Eval("problems")%>
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

