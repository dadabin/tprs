<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true"  Theme="style" CodeFile="itemreport_user.aspx.cs" Inherits="Admin_itemselect1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
<tr><td  width="10%"></td><td width="80%" align="center">
    <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
    <Columns>
    <asp:TemplateField HeaderText="项目编号">
    <ItemTemplate>
    <%#Eval("itemNumber")%>
    </ItemTemplate>
    </asp:TemplateField>
       <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
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
    <asp:TemplateField HeaderText="当前月报季报">
    <ItemTemplate>
    <%#Eval("reporturl") %>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="当前月报季报是否通过审核">
    <ItemTemplate>
    <%#Eval("reportpass") %>
    </ItemTemplate>
    </asp:TemplateField>
 
    <asp:TemplateField HeaderText="历史报告管理">
    <ItemTemplate>
    <%#Eval("season") %>
    </ItemTemplate>
    </asp:TemplateField>

   

    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager1" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server" PageSize="12"
        onpagechanged="AspNetPager1_PageChanged" Font-Size="13px">
    </webdiyer:AspNetPager>
</td><td></td></tr>

</table>
</asp:Content>

