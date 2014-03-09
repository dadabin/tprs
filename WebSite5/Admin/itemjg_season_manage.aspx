<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemjg_season_manage.aspx.cs" Inherits="Admin_itemjg_season_manage" Theme="style" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    body
    {
        font-size:14px;
    }
  table
  { border-collapse:collapse; }
  a
  {
      font-size:14px;
      text-decoration:none;
    }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%"><tr><td width="10%"></td><td width="80%" align="center">
<h3>景观季度报告汇总</h3>
<hr style="border: 1px solid #1739E6"/>
<asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
         <Columns>
   <asp:TemplateField HeaderText="项目编号">
    <ItemTemplate>
    <%#Eval("PROJECTNUMBER")%>
    </ItemTemplate>
    </asp:TemplateField>


   <asp:TemplateField HeaderText="是否通过审核">
    <ItemTemplate>
    <%#Eval("PASS")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="填报时间">
    <ItemTemplate>
    <%#Eval("reportTim")%>
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
</td><td></td></tr>
<tr><td width="10%"></td><td width="80%"align="right">
<webdiyer:AspNetPager ID="AspNetPager1" PageSize="12" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" runat="server" 
        Font-Size="14px" >
    </webdiyer:AspNetPager>
</td><td></td></tr> 
  <!--分页控件-->
<tr>
    <td colspan="3"c align="center">
         <%= newReportUrl %>
    </td>
</tr>
</table>




      

 

</asp:Content>

