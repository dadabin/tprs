<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_season_manage.aspx.cs" Inherits="Admin_itemst_season_manage" Theme="style" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <h3 align="center">重大项目季度报汇总</h3>

</hr>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gridviewSkin" Width="100%">
      <Columns>
   <asp:TemplateField HeaderText="项目编号">
    <ItemTemplate>
    <%#Eval("PROJECTID")%>
    </ItemTemplate>
    </asp:TemplateField>


   <asp:TemplateField HeaderText="是否通过审核">
    <ItemTemplate>
    <%#Eval("PASS")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="填报时间">
    <ItemTemplate>
    <%#Eval("reportTime")%>
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="查看">
    <ItemTemplate>
    <%#Eval("Detail")%>
    </ItemTemplate>                               
    </asp:TemplateField>
    <asp:TemplateField HeaderText="修改">
    <ItemTemplate>
    <%#Eval("MODIFY")%>
    </ItemTemplate>                               
    </asp:TemplateField>


    </Columns>

    </asp:GridView> 

    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  PrevPageText="上一页" align="right"
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
    </webdiyer:AspNetPager>

<br /><br /><br /><br />

<%= newReportUrl%>


</asp:Content>
