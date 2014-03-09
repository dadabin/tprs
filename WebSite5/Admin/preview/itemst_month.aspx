<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_month.aspx.cs" Inherits="Admin_preview_itemst_month" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    body
    {
        font-size:12px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
    <tr>
        <td align="center" style="font-size: 18px; font-weight: bold;">2012年龙泉山生态旅游功能区重大项目表</td>
    </tr>
    <tr>
        <td>此表统计时间截至？？？？？</td>
        <td>1-?月总完成额为？？？万元</td>
        <td>单位：万元</td>
    </tr>
    <tr>
        <td colspan="31">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                EnableModelValidation="True" Width="1340px" Height="201px">
            <Columns>
                <asp:TemplateField  HeaderText="序号">
                    <ItemTemplate>
                        <%#Eval("row_number") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="所属区县">
                    <ItemTemplate>
                        <%#Eval("COUNTRY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="项目名称">
                    <ItemTemplate>
                        <%#Eval("PROJECTNAME") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="建设地址">
                    <ItemTemplate>
                        <%#Eval("ADDRESS") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="建设年限">
                    <ItemTemplate>
                        <%#Eval("CONSTRUCTIONAGE") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="建设性质">
                    <ItemTemplate>
                        <%#Eval("CONSTRUCTIONTYPE") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="建设内容及规模">
                    <ItemTemplate>
                        <%#Eval("CONTENTSCALE") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="总投资">
                    <ItemTemplate>
                        <%#Eval("TOTLEMONEY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="中央资金">
                    <ItemTemplate>
                        <%#Eval("CENTRALMONEY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="省级资金">
                    <ItemTemplate>
                        <%#Eval("PROVINCIALMONEY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="市级资金">
                    <ItemTemplate>
                        <%#Eval("MUNICIPALMONEY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="区县资金">
                    <ItemTemplate>
                        <%#Eval("DISTRICTMONEY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="银行贷款">
                    <ItemTemplate>
                        <%#Eval("BANKLOAN") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="企业自筹">
                    <ItemTemplate>
                        <%#Eval("COMPANYSELF") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="至2011年底累计完成投资">
                    <ItemTemplate>
                        <%#Eval("") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="2012年计划投资">
                    <ItemTemplate>
                        <%#Eval("") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="目前为止项目形象进度">
                    <ItemTemplate>
                        <%#Eval("PROGRESSNOW") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="单位名称">
                    <ItemTemplate>
                        <%#Eval("") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="法人代表">
                    <ItemTemplate>
                        <%#Eval("") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="业主联系人">
                    <ItemTemplate>
                        <%#Eval("") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="联系电话">
                    <ItemTemplate>
                        <%#Eval("") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="开工(计划开工)时间">
                    <ItemTemplate>
                        <%#Eval("STARTTIME") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="计划竣工时间">
                    <ItemTemplate>
                        <%#Eval("FINISHTIME") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="四个一批范畴">
                    <ItemTemplate>
                        <%#Eval("PROGRESSCATEGORY") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="已取得土地指标（亩）">
                    <ItemTemplate>
                        <%#Eval("GETLANDTARGETS") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="拟申请土地指标(亩)">
                    <ItemTemplate>
                        <%#Eval("PLANLANDTARGETS") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="是否政府投资项目">
                    <ItemTemplate>
                        <%#Eval("GOVERMENTPROJE") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="1-7月累计完成投资额">
                    <ItemTemplate>
                        <%#Eval("row_number") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="7月累计完成投资额">
                    <ItemTemplate>
                        <%#Eval("row_number") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="需协调解决问题">
                    <ItemTemplate>
                        <%#Eval("PROBLEMS") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="备注">
                    <ItemTemplate>
                        <%#Eval("REMARK") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

