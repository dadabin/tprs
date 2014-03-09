<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_season_add.aspx.cs" Inherits="Admin_itemst_season_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 body{font-size:15px;}
 td
 {
      border: 1px #2042eb solid;
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
      margin-bottom: 0px;
    }

 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%"bgcolor="#F6F7F9">
        <tr>
            <td colspan="4" align="center" 
                style="font-family: 微软雅黑; color: #000000; font-weight: bold; font-size: medium;" 
                valign="middle" class="style1">重大项目季报</td>
               <%-- <td>
                <!--隐藏表单--->
                    <!--ID-->
                    <!--项目编号--->
                </td>--%>
        </tr>
        <tr>
            <td width="15%" align="right">所属区县：</td>
            <td width="25%"><asp:Label ID="Label1" runat="server" Height="20px" Width="200px"></asp:Label></td>
            <td width="15%"align="right">项目名称：</td>
            <td width="25%"><asp:Label ID="Label2" runat="server" Height="20px" Width="200px"></asp:Label></td>
        </tr>
        <tr>
           <td align="right">
               建设地址：</td>
            <td> 
                <asp:Label ID="Label3" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>

                <td style="font-size: medium;" class="style18" 
                align="right">建设年限：</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>

        </tr>
        <tr>
            <td align="right">建设性质：</td>
            <td colspan="3">
                <asp:Label ID="Label5" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">建设内容及规模：</td>
            <td colspan="3"> 
                <asp:Label ID="Label6" runat="server" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
       <tr>

            <td align="right">请上传图片：</td>
            <td colspan="3"><input id="File1" type="file"  />
                <asp:Button ID="Button3" runat="server" Text="上传" Height="33px" Width="67px" />（可修改）</td>
        </tr>
        <tr>
            <td align="right">项目图片展示：</td>
            <td colspan="3"> 
                <asp:Image ID="Image1" runat="server" Height="68px" Width="100px" />&nbsp;
                <asp:Image ID="Image2" runat="server" Height="68px" Width="100px" />&nbsp;
                <asp:Image ID="Image3" runat="server" Height="68px" Width="100px" />&nbsp;
                <asp:Image ID="Image4" runat="server" Height="68px" Width="100px" />&nbsp;
                <asp:Image ID="Image5" runat="server" Height="68px"  Width="100px"/>&nbsp;
           </td>
        </tr>
        <tr>
            <td align="right">总投资：</td>
            <td> 
                <asp:Label ID="Label7" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">中央资金：</td>
            <td>
                <asp:Label ID="Label8" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
         <tr>
            <td align="right">省级资金：</td>
            <td> 
                <asp:Label ID="Label9" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">市级资金：</td>
            <td> 
                <asp:Label ID="Label10" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
         </tr>
         <tr>

        `   <td align="right">区县资金：</td>
            <td> 
                <asp:Label ID="Label11" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">银行贷款：</td>
            <td> 
                <asp:Label ID="Label12" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">企业自筹：</td>
            <td> 
                <asp:Label ID="Label13" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">截至2011年底完成投资：</td>
            <td> 
                <asp:Label ID="Label14" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">2012年计划投资：</td>
            <td colspan="3"> 
                <asp:Label ID="Label15" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">目前为止项目形象进度：</td>
            <td colspan="3"> 
                <asp:TextBox ID="TextBox21" runat="server" TextMode="MultiLine" Height="70px" 
                    Width="680px"></asp:TextBox>
                （可修改）</td>
        </tr>
        <tr>
            <td align="right">开工(计划开工)时间：</td>
            <td>
                <asp:Label ID="Label16" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
            <td>计划竣工时间：</td>
            <td>
                <asp:Label ID="Label17" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">四个一批范畴：</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="205px">
                    <asp:ListItem Value="tcdc">投产达产</asp:ListItem>
                    <asp:ListItem Value="qqcb">前期储备</asp:ListItem>
                    <asp:ListItem Value="jkjs">加快建设</asp:ListItem>
                    <asp:ListItem Value="cjkg">促进开工</asp:ListItem>
                </asp:DropDownList>
                (可修改)</td>
            <td> 已取得土地指标:</td>
            <td> 
                <asp:Label ID="Label18" runat="server" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
        </tr>
        <tr>
            <td align="right">拟申请土地指标：</td>
            <td> 
                <asp:Label ID="Label19" runat="server" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
            <td>是否政府投资项目：</td>
            <td> 
                <asp:Label ID="Label20" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" ><%=DateTime.Now.Month-1%>月完成的投资额：</td>
                <td class="style14">
                    <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                    (万元)(可修改)<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="TextBox22"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>1-<%=DateTime.Now.Month -1%>月完成投资额：</td>
            <td id="()"> 
                <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>(万元)</td>
        </tr>
        <tr>
            <td align="right">需协调解决的问题：</td>
            <td colspan="3"> 
                <asp:TextBox ID="DevelopDirectionText" runat="server" Height="70px" TextMode="MultiLine" 
                    Width="680px"></asp:TextBox>(可修改)</td>
        </tr>
        <tr>
            <td align="right">备注:</td>
            <td colspan="3"> 
                <asp:TextBox ID="TextBox16" runat="server" TextMode="MultiLine" Height="70px" 
                    Width="680px"></asp:TextBox>
                （可修改）</td>
        </tr>
        
        <tr>
            <td colspan="4" align="center" colspan="3">
                <asp:Button ID="Button1" 
                    runat="server" Text="保存" BackColor="#1C60EC" ForeColor="White"
                    Height="37px" Width="84px" onclick="Button1_svae" Font-Size="14px" /></td>
           <%--<asp:Button ID="Button2" 
                    runat="server" Text="提交"
                    Height="29px" Width="77px" onclick="Button2_Click" />--%></td>
        </tr>
    
    </table>
</asp:Content>

