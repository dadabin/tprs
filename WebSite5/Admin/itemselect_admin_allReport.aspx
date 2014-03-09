<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" Theme="style" CodeFile="itemselect_admin_allReport.aspx.cs" Inherits="Admin_itemselect_admin_allReport" %>
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
 <script type="text/javascript">
　　<!--
　　     function openwin(url) {
        // window.open("" + url, "", "width=500,height=500,top=100, left=200");
         window.open(url, "", "width=500,height=600,top=100, left=200,status=yes,toolbar=no,scrollbars=yes,resizable=yes");
     }
　　//-->
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%"><tr><td width="100%" align="center">

<tr><td width="80%" align="center">
   
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

   </td></tr>

</td></tr>
<tr>
    <td align="center">
    <asp:GridView ID="GridView1" SkinID="gridviewSkin" Width="100%" 
        AutoGenerateColumns="false" runat="server">
    <Columns>
    <asp:TemplateField HeaderText="项目编号">  
    <ItemTemplate>
     <%#Eval("projectNum")%>
    </ItemTemplate>
    </asp:TemplateField>
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

   
    <asp:TemplateField HeaderText="是否点评">
    <ItemTemplate>
   <%#Eval("comment")%>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td>

</tr>
<tr>
        <td align="right"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            onpagechanged="AspNetPager1_PageChanged" PageSize="10" PrevPageText="上一页" 
            NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
           </webdiyer:AspNetPager>
       </td>
</tr>
    
</table>



</asp:Content>

