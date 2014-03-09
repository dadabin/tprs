<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemselect_admin_allProject.aspx.cs" Inherits="Admin_itemselect_admin_allProject" Theme="style" %>
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
<tr><td width="10%"></td><td width="80%" align="center">
   选择项目类型：&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
   <asp:ListItem Selected="True" Text="==选择项目类型==" Value="0"></asp:ListItem>
   <asp:ListItem Text="生态旅游重大项目" Value="1"></asp:ListItem>
   <asp:ListItem Text="景观农业项目" Value="2"></asp:ListItem>
   <asp:ListItem Text="百湖工程项目" Value="3"></asp:ListItem>
    </asp:DropDownList>
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


<tr><td  width="10%"></td><td width="80%" align="center">

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
    <asp:TemplateField HeaderText="项目申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>

   

    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager1" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server"
       onpagechanged="AspNetPager1_PageChanged" PageSize="12" Font-Size="14px" >
    </webdiyer:AspNetPager>
</td><td></td></tr>
<tr><td></td><td>
  
    </td><td></td></tr>

</table>
</asp:Content>