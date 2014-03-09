<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true"  Theme="style" CodeFile="user_manage.aspx.cs" Inherits="Admin_admin_manage" %>

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
<table width="100%"><tr><td width="10%"></td><td width="80%" align="center">
<br />
<a href="user_add.aspx">添加业主</a>
<br />
 <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="gridviewSkin"  AutoGenerateColumns="false">
    <Columns>
    <asp:TemplateField  HeaderText="序号">
    <ItemTemplate>
   &nbsp; <%#Eval("row_number") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="账号">
    <ItemTemplate>
    &nbsp;&nbsp;<%#Eval("LOGINNAME") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="姓名">
    <ItemTemplate>
    &nbsp; <%#Eval("USERNAME") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="公司">
    <ItemTemplate>
    &nbsp;&nbsp;<%#Eval("UnitName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="所属区县">
    <ItemTemplate>
    &nbsp; <%#Eval("ADDRESS")%>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="查看/修改">
    <ItemTemplate>
       &nbsp;  <asp:LinkButton ID="LinkButton1" runat="server" 
            CommandArgument='<%#Eval("LOGINNAME") %>' oncommand="LinkButton1_Command" >查看/修改</asp:LinkButton>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="删除">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton2" oncommand="LinkButton2_Command" CommandArgument='<%#Eval("LOGINNAME") %>' OnClientClick="javascript:return confirm('你确认要删除吗?');" runat="server">删除</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>

</td><td></td></tr>
<tr><td width="10%"></td><td width="80%" align="right">
 &nbsp;
<webdiyer:AspNetPager ID="AspNetPager1" PrevPageText="上一页" PageSize="10" 
        FirstPageText="首页" runat="server"  LastPageText="尾页" NextPageText="下一页"
        onpagechanged="AspNetPager1_PageChanged" Font-Size="14px">
    </webdiyer:AspNetPager>
</td><td></td></tr>
</table>
   
    <br />
    
</asp:Content>

