<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" Theme="style" CodeFile="itemselect_admin2_report.aspx.cs" Inherits="Admin_itemselect_admin2_report" %>

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
<tr><td width="10%"></td><td width="80%" align="center">
   
    &nbsp;&nbsp;&nbsp;选择地区：<asp:DropDownList ID="DropDownList3" runat="server" 
        Height="20px" Width="150px">
        <asp:ListItem Value="0" Text="==请选择地区=="></asp:ListItem>
        <asp:ListItem Value="lqy" Text="龙泉驿区"></asp:ListItem>
    <asp:ListItem Value="qbj" Text="青白江区"></asp:ListItem>
    <asp:ListItem Value="xj" Text="新津县"></asp:ListItem>
    <asp:ListItem Value="jt" Text="金堂县" ></asp:ListItem>
    <asp:ListItem Value="sl" Text="双流县"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;<asp:Button ID="Button5" runat="server" Text="查询" BackColor="#2480F1" Font-Size="13px" ForeColor="White"
        onclick="Button5_Click" Height="25px" Width="64px" />
</td><td>
   </td></tr>
<tr><td></td><td align="center">
<h3>未通过审核的报告</h3>

    <asp:GridView ID="GridView1" SkinID="gridviewSkin" Width="100%" 
        AutoGenerateColumns="false" runat="server">
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

<tr><td></td><td align="center">

<h3>已经通过审核的报告</h3>
</td><td></td></tr>

<tr><td></td><td>
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
</asp:Content>

