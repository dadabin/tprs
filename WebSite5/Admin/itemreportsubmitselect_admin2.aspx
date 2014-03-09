<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" Theme="style" CodeFile="itemreportsubmitselect_admin2.aspx.cs" Inherits="Admin_itemselect_admin2" %>

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
<tr><td width="10%"></td><td width="80%" style="font-size: 15px" align="center">
    项目类别：&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" 
        Height="20px">
    <asp:ListItem Value="0" Text="==选择项目类型=="></asp:ListItem>
    <asp:ListItem Value="st" Text="生态旅游重大项目"></asp:ListItem>
    <asp:ListItem Value="jg" Text="景观农业" ></asp:ListItem>
    <asp:ListItem Value="bh" Text="百湖工程"></asp:ListItem>
    <asp:ListItem Value="zb" Text="生态植被与恢复"></asp:ListItem>
    <asp:ListItem Value="ts" Text="特色旅游村"></asp:ListItem>
    <asp:ListItem Value="xc" Text="乡村度假区或A级景区"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;进展类型：<asp:DropDownList ID="DropDownList2" runat="server" 
        Height="20px" Width="108px">
    <asp:ListItem Value="1" Text="前期储备"></asp:ListItem>
    <asp:ListItem Value="2" Text="促进开工"></asp:ListItem>
    <asp:ListItem Value="3" Text="加快建设"></asp:ListItem>
    <asp:ListItem Value="4" Text="投产达产"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;选择地区：<asp:DropDownList ID="DropDownList3" runat="server" 
        Height="23px" Width="105px">
        <asp:ListItem Value="lqy" Text="龙泉驿区"></asp:ListItem>
    <asp:ListItem Value="qbj" Text="青白江区"></asp:ListItem>
    <asp:ListItem Value="xj" Text="新津县"></asp:ListItem>
    <asp:ListItem Value="jt" Text="金堂县" ></asp:ListItem>
    <asp:ListItem Value="sl" Text="双流县"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;<asp:Button ID="Button5" runat="server" Text="查询" 
        BackColor="#2480F1" Font-Size="13px" ForeColor="White"
        onclick="Button5_Click" Height="25px" Width="58px" />&nbsp;&nbsp;<br />
    
</td><td>
   </td></tr>
<tr><td></td><td align="center">
    <asp:GridView ID="GridView1" SkinID="gridviewSkin" Width="100%" AutoGenerateColumns="false" runat="server">
    <Columns>
    <asp:TemplateField HeaderText="项目编号">
    <ItemTemplate>
    <%#Eval("itemNumber") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目名称">
    <ItemTemplate>
    <%#Eval("itemName") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="业主">
    <ItemTemplate>
    <%#Eval("loginusername") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="申报时间">
    <ItemTemplate>
    <%#Eval("submitTime") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="项目类型">
    <ItemTemplate><%#Eval("itemType") %></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="季度报">
    <ItemTemplate>
    <%#Eval("season") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="月报">
    <ItemTemplate>
   <%#Eval("month") %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="修改项目">
    <ItemTemplate>
   <%#Eval("itemid")%>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td><td></td></tr>
<tr><td></td><td align="right">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
        onpagechanged="AspNetPager1_PageChanged" PageSize="8" PrevPageText="上一页" 
        NextPageText="下一页" LastPageText="尾页" FirstPageText="首页" Font-Size="14px">
    </webdiyer:AspNetPager>
    </td><td></td></tr>

    <tr><td></td><td></td><td></td></tr>
    <tr><td></td><td align="center"><h3>填报本月总结</h3></td><td></td></tr>
<tr><td></td><td align="center">
        <asp:TextBox ID="TextBox1" runat="server" Height="232px" TextMode="MultiLine" 
            Width="792px"></asp:TextBox>
            
        </td><td></td></tr>
<tr><td align="center" colspan="3"><asp:Button ID="Button6" runat="server" 
        Text="提交报告" onclick="Button6_Click" BackColor="#2480F1" Font-Size="14px" 
        ForeColor="White" Height="32px" /></td></tr>
</table>
</asp:Content>

