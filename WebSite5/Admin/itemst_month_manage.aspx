<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_month_manage.aspx.cs" Inherits="Admin_itemst_month_manage" Theme="style" %>

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
<table width="100%">
    <tr><td align="center"><h3>重大项目月报汇总</h3></td></tr>
    <tr>
        <td>
            <hr style="border: 1px solid #1739E6"/>
        </td>
   </tr>
   <tr>
        <td align="center">
            <!--table控件-->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" SkinID="gridviewSkin">
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
    </asp:GridView><br />
        </td>
   </tr>
   <tr>
        <td align="right"> <!--分页控件-->
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" align="right" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页"
        onpagechanged="AspNetPager1_PageChanged" Font-Size="14px">
    </webdiyer:AspNetPager></td>
   </tr>
   <tr>
        <td align="center"><%= newReportUrl%></td>
   </tr>
</table>
</asp:Content>

