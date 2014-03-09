<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemselect_admin1.aspx.cs" Inherits="Admin_itemselect_admin1" Theme="style" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style  type="text/css">
   a
 {
     text-decoration:none;
  }
  body
  {
      font-size:14px;
      }
</style>
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  width="100%">

<tr><td width="10%"></td><td width="80%">

选择项目类型：&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
<asp:ListItem Selected="True" Value="0" Text="==选择项目类型=="></asp:ListItem>
<asp:ListItem Value="1" Text="生态旅游重大项目"></asp:ListItem>
<asp:ListItem Value="2" Text="景观农业项目"></asp:ListItem>
<asp:ListItem Value="3" Text="百湖工程项目"></asp:ListItem>
    </asp:DropDownList>
   &nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="查询" 
        onclick="Button1_Click" />
</td><td>
   </td></tr>
<tr><td></td><td align="center">
    <asp:GridView ID="GridView1" SkinID="gridviewSkin" Width="100%" AutoGenerateColumns="false" runat="server">

    <Columns>
    <asp:TemplateField HeaderText="项目编号">
    <ItemTemplate>
    <%#Eval("itemNumber") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="历史报告管理">
    <ItemTemplate><%#Eval("season")%></ItemTemplate>
    </asp:TemplateField>
   
   
    <asp:TemplateField HeaderText="修改项目">
    <ItemTemplate>
   <%#Eval("itemid")%>
    </ItemTemplate>
    </asp:TemplateField>

    
    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        onpagechanged="AspNetPager1_PageChanged" PageSize="12" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
    </webdiyer:AspNetPager>
</td><td></td></tr>
</table>
</asp:Content>