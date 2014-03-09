<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true"    Theme="style" CodeFile="admin_manage.aspx.cs" Inherits="Admin_admin_manage" %>

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
<table style="width:100%" ><tr><td width="10%"></td><td align="center">
<br />
<a href="admin_add.aspx">添加市领导账号</a>

<br />
 <asp:GridView ID="GridView1" SkinID="gridviewSkin" runat="server" Width="100%" AutoGenerateColumns="false">
    <Columns>
    <asp:TemplateField  HeaderText="序号">
    <ItemTemplate>
     &nbsp;  <%#Eval("row_number") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="账号">
    <ItemTemplate>
    &nbsp;&nbsp;<%#Eval("LOGINNAME") %>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="姓名">
    <ItemTemplate>
     <%#Eval("USERNAME") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="查看/修改">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            CommandArgument='<%#Eval("LOGINNAME") %>' oncommand="LinkButton1_Command" >查看/修改</asp:LinkButton>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="删除">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="javascript:return confirm('你确认删除?');" oncommand="LinkButton2_Command" CommandArgument='<%#Eval("LOGINNAME") %>'>删除</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView></td><td></td></tr>
    
    <tr><td></td><td align="right"> <webdiyer:AspNetPager ID="AspNetPager1" 
            PrevPageText="上一页" PageSize="20" FirstPageText="首页" runat="server"  
            LastPageText="尾页" NextPageText="下一页"
        onpagechanged="AspNetPager1_PageChanged" Font-Size="14px">
    </webdiyer:AspNetPager></td><td></td></tr></table>
   
   
   
</asp:Content>

