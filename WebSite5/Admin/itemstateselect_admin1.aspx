<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" Theme="style" CodeFile="itemstateselect_admin1.aspx.cs" Inherits="Admin_itemselect_admin2" %>

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
<tr><td width="10%"></td><td width="80%" style="font-size: 15px" align="center">
  
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
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
   
    <asp:TemplateField HeaderText="是否竣工">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:return confirm('你确认将该项目设置成竣工?设置成竣工状态后，该项目将不会再出现在本系统中！！');" CommandArgument='<%#Eval("projectid")%>' CommandName='<%#Eval("itemType") %>'  runat="server" oncommand="LinkButton1_Command">设置竣工</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        onpagechanged="AspNetPager1_PageChanged" PageSize="10" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
    </webdiyer:AspNetPager>
    </td><td></td></tr>
</table>
</asp:Content>

