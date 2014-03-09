<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true"  Theme="style" CodeFile="itemselect_user.aspx.cs" Inherits="Admin_itemselect1" %>

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
  <script language="javascript">
　　<!--
　　      function openwin(id, type) {
          window.open("view_reback.aspx?id=" + id + "&type=" + type, "", "width=650,height=400,top=100, left=200")
      }
　　//-->
</script>
 

<table width="100%">
<tr><td align="center" colspan="3"><h3 style="font-size: 14px">尚未提交项目</h3> </td></tr>
<tr><td  width="10%"></td><td width="80%" align="center">
    <asp:GridView ID="GridView2" runat="server" SkinID="gridviewSkin" 
        AutoGenerateColumns="false" Width="100%" >
    <Columns>

        <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="修改项目">
    <ItemTemplate>
   <%#Eval("itemid")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="点击申报">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" CommandName ='<%#Eval("itemType") %>' CommandArgument ='<%#Eval("projectid") %>' oncommand="LinkButton1_Command">点击提交</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="是否通过审核">
    <ItemTemplate>
   <%#Eval("pass")%>
    </ItemTemplate>
     </asp:TemplateField>

   <asp:TemplateField HeaderText="删除">
    <ItemTemplate>
    <asp:LinkButton ID="LinkButton2" runat="server" CommandName ='<%#Eval("itemType") %>' OnClientClick="javascript:return confirm('你确认通删除吗?？删除后该项目信息将完全丢失！');" CommandArgument ='<%#Eval("projectid") %>' oncommand="LinkButton2_Command">删除</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>

    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager2" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server" 
        onpagechanged="AspNetPager2_PageChanged" PageSize="5" Font-Size="14px">
    </webdiyer:AspNetPager>
</td><td></td></tr>
<tr><td></td><td>
  
    </td><td></td></tr>

</table>


    <table width="100%">
<tr><td colspan="3" align="center"><h3 style="font-size: 14px">等待审核项目列表</h3></td></tr>
<tr><td  width="10%"></td><td width="80%" align="center">
    <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>

 
    <asp:TemplateField HeaderText="是否通过审核">
    <ItemTemplate>
   <%#Eval("pass")%>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager1" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server" 
        onpagechanged="AspNetPager1_PageChanged" PageSize="5" Font-Size="14px">
    </webdiyer:AspNetPager>
</td><td></td></tr>
<tr><td></td><td>
  
    </td><td></td></tr>
</table>



<table width="100%">
<tr><td colspan="3" align="center"> <h3 style="font-size: 14px">被退回的项目列表</h3></td></tr>
<tr><td  width="10%"></td><td width="80%" align="center">
    <asp:GridView ID="GridView3" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="修改项目">
    <ItemTemplate>
   <%#Eval("itemid")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="是否通过审核">
    <ItemTemplate>
   <%#Eval("pass")%>
    </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderText="点击申报">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton3" runat="server" CommandName ='<%#Eval("itemType") %>' CommandArgument ='<%#Eval("projectid") %>' oncommand="LinkButton3_Command">点击提交</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="打回缘由">
    <ItemTemplate>
        <a href="#" onclick="openwin('<%#Eval("projectid")  %>','<%#Eval("itemType")%>')">查看</a>
    </ItemTemplate>
    </asp:TemplateField>


    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager3" PrevPageText="上一页" LastPageText="尾页"  
        NextPageText ="下一页" FirstPageText="首页" runat="server" 
        onpagechanged="AspNetPager3_PageChanged" PageSize="5" Font-Size="14px">
    </webdiyer:AspNetPager>
</td><td></td></tr>
<tr><td></td><td>
  
    </td><td></td></tr>
</table>

</asp:Content>

