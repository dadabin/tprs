<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="log.aspx.cs" Inherits="Admin_log" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
 body{font-size:15px;}
 td
 {border: 1px #2042eb solid;
  height:30px;
 }
  .text
  {
      width:200px;
      height:20px;
  }
  table
  {
      border-collapse:collapse;
      }
        .style1
        {
            height: 30px;
        }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="80%" align="center">

<tr><td align="center" style="font-size: 20px; font-weight: bold;">日志记录文件</td></tr>
<tr><td align="center">

      <asp:GridView ID="GridView1" runat="server"  SkinID="gridviewSkin" AutoGenerateColumns="false" Width="100%">
         <Columns>

    <asp:TemplateField HeaderText="日志编号">
    <ItemTemplate>
    <%#Eval("logID")%>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="时间">
    <ItemTemplate>
    <%#Eval("logTime")%>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="内容">
    <ItemTemplate>
    <%#Eval("content")%>
    </ItemTemplate>
    </asp:TemplateField>

    </Columns>
    </asp:GridView>
</td></tr> 
<tr>
    <td align="center"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页" FirstPageText="首页"
        PageSize="12"  onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager></td>

</tr></table></asp:Content>