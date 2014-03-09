<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" Theme="style" CodeFile="report_admin2.aspx.cs" Inherits="report_admin2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
  table
  { border-collapse:collapse; }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
　　<!--
　　    function openwin(url) {
        window.open("view_opinion.aspx?id=" + url, "", "width=500,height=500,top=100, left=200")
    }
　　//-->
　　</script>
<h3 align="center">报告历史记录列表</h3>
</ hr>
      <asp:GridView ID="GridView1" runat="server"  SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
         <Columns>

    <asp:TemplateField HeaderText="报告编号">
    <ItemTemplate>
    <%#Eval("ID")%>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="上报时间">
    <ItemTemplate>
    <%#Eval("RTIME")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="上报人">
    <ItemTemplate>
    <%#Eval("LOGINNAME")%>
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="概述">
    <ItemTemplate>
    <%#Eval("CONTENT")%>
    </ItemTemplate>            
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="详情">
    <ItemTemplate>
        <%#Eval("DETAIL")%>
    </ItemTemplate> 
    </asp:TemplateField>

    </Columns>
    </asp:GridView>

    <!--分页控件-->
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        onpagechanged="AspNetPager1_PageChanged" PageSize="8" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
    </webdiyer:AspNetPager>
    <br /><br /><br />

</asp:Content>

