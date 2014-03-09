<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true"  Theme="style" CodeFile="itemsubmitselect_admin1.aspx.cs" Inherits="Admin_itemselect1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script  type="text/javascript">
　　<!--
　　     function openwin(id,type) {
         window.open("reback_admin1.aspx?id=" + id +"&type="+ type, "", "width=650,height=400,top=100, left=200")
     }
　　//-->
</script>



<table width="100%">
<tr><td colspan="3" align="center" style="font-size: 15px; font-weight: bold">新建项目审核</td></tr>
<tr><td  width="10%"></td><td width="80%" align="center">
    <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
    <Columns>
  
  
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="业主">
    <ItemTemplate>
    <%#Eval("loginusername") %>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="修改项目">
    <ItemTemplate>
   <%#Eval("itemid")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="审核">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:return confirm('你确认通过审核?');" CommandArgument='<%#Eval("projectid")%>' CommandName='<%#Eval("itemType") %>'  runat="server" oncommand="LinkButton1_Command">审核通过</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="退回">
    <ItemTemplate>
        <a href="#" onclick="openwin('<%#Eval("projectid")  %>','<%#Eval("itemType")%>')">退回</a>
    </ItemTemplate>
    </asp:TemplateField>


    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td>
    <webdiyer:AspNetPager ID="AspNetPager1" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server"  PageSize="12"
        onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>
</td><td></td></tr>
<tr><td></td><td>
    &nbsp;</td><td></td></tr>

</table>

</asp:Content>

