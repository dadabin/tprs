<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemjg_season.aspx.cs" Inherits="Admin_preview_itemjg_season" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

body
{
    font-size:13px;
    }

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr><td align="center" style="font-size: 15px; font-weight: bold">龙泉办景观农业项目二季度推进情况表</td></tr>
    <tr><td colspan="13">龙泉办项目组   &nbsp;填报时间：</td></tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                EnableModelValidation="True">
            <Columns>
                <asp:TemplateField  HeaderText="序号">
                <ItemTemplate>
                <%#Eval("row_number") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="区县">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="项目名称">
                <ItemTemplate>
                <%#Eval("PROJECTNAME") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="建设地址">
                <ItemTemplate>
                <%#Eval("ADDRESS") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="建设起止年限">
                <ItemTemplate>
                <%#Eval("STARTENDTIME") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="项目建设规模">
                <ItemTemplate>
                <%#Eval("CONTENTSCALE") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="计划总投资">
                <ItemTemplate>
                <%#Eval("PLANTOTALMONEY") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2012年计划投资">
                <ItemTemplate>
                <%#Eval("XYEARPLAN") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2012年底工程应达形象进度">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="至2011年已累计完成投资">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2012年6月完成投资">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2012年1-6月完成投资">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="目前形象进度">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="项目业主">
                <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </td>
    </tr>

</table>
</asp:Content>

