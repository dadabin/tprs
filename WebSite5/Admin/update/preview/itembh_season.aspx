<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itembh_season.aspx.cs" Inherits="Admin_preview_itembh_season" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    body{font-size:13px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr><td align="center">龙泉办“百湖”工程（二）季度情况表</td></tr>
<tr><td colspan="18">龙泉办项目组  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;填报时间:</td></tr>
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
            <asp:TemplateField HeaderText="工程名称">
                <ItemTemplate>
                <%#Eval("PROJECTNAME") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="建设地址">
                <ItemTemplate>
                <%#Eval("ADDRESS") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="完工时间">
                <ItemTemplate>
                <%#Eval("FINISHTIME") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="水域面积(亩)">
                <ItemTemplate>
                <%#Eval("ZONEAREA") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="小计(万元)">
                 <ItemTemplate>
                <%#Eval("") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="省级以上财政">
                 <ItemTemplate>
                <%#Eval("PROVINCIALEVELFISCAL") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="市级财政">
                  <ItemTemplate>
                <%#Eval("MUNICIPALFINANCE") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="县级财政">
                 <ItemTemplate>
                <%#Eval("COUNTYFINANCE") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="财政融资">
                <ItemTemplate>
                <%#Eval("FINANCEFINANCE") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="社会投入">
                <ItemTemplate>
                <%#Eval("SOCIALINVESTMENT") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="群众投入">
                <ItemTemplate>
                <%#Eval("PUBLICINVESTMENT") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="其它">
                <ItemTemplate>
                <%#Eval("OTHER") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="占用土地面积(亩)">
                <ItemTemplate>
                <%#Eval("OCCUPIEDAREA") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="占用方式">
                <ItemTemplate>
                <%#Eval("OCCUPIEDTYPE") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="单价(元/亩•年)">
                <ItemTemplate>
                <%#Eval("UNITPRICE") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目前工程形象进度 ">
                <ItemTemplate>
                <%#Eval("IMAGEPROGRESS") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="管护主体">
                <ItemTemplate>
                <%#Eval("MANAGESUBJECT") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</td>
</tr>

</table>
</asp:Content>

