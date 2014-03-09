<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" Theme="style" CodeFile="itemreportselect_admin1.aspx.cs" Inherits="itemreportselect_admin1" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
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
<table width="100%"><tr><td width="10%"></td><td width="80%"align="center">
<h3 style="font-size: 14px">未审核的报告</h3>
</td><td></td></tr>
<tr><td></td><td align="center">
       <asp:GridView ID="GridView1" SkinID="gridviewSkin" Width="100%" 
        AutoGenerateColumns="false" runat="server" >
    <Columns>
    
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate>
    <%#Eval("projectType")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("projectName")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="所属地区">
    <ItemTemplate>
    <%#Eval("zone") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="业主">
    <ItemTemplate><%#Eval("owner")%></ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="报送时间">
    <ItemTemplate>
    <%#Eval("reportTime")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="是否审核通过">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:return confirm('你确认通过审核?');" CommandArgument='<%#Eval("reportType")%>' CommandName='<%#Eval("ID") %>'  runat="server" oncommand="LinkButton1_Command"><%#Eval("audit")%></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="修改">
    <ItemTemplate>
   <%#Eval("modify")%>
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


<table width="100%"><tr><td width="10%"></td><td width="80%"align="center">
<h3 style="font-size: 14px">已经通过审核的报告</h3>
</td><td></td></tr>

<tr><td></td><td align="center">
    <asp:GridView ID="GridView2" SkinID="gridviewSkin" Width="100%" 
        AutoGenerateColumns="false" runat="server" >
    <Columns>
   
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate>
    <%#Eval("projectType")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("projectName")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="所属地区">
    <ItemTemplate>
    <%#Eval("zone") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="业主">
    <ItemTemplate><%#Eval("owner")%></ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="报送时间">
    <ItemTemplate>
    <%#Eval("reportTime")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="修改">
    <ItemTemplate>
   <%#Eval("modify")%>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="领导点评">
    <ItemTemplate>
   <%#Eval("comment")%>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" 
        onpagechanged="AspNetPager2_PageChanged" PageSize="10" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
    </webdiyer:AspNetPager>
    </td><td></td></tr>
    
    </table>


    <br />
</asp:Content>

