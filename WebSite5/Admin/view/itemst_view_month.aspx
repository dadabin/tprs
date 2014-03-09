<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_view_month.aspx.cs" Inherits="Admin_view_itemst_view_month" %>

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
 </style>

 <link rel="stylesheet" href="js/css/lrtk.css" />
<script type="text/javascript" src="js/js/jquery.min.js"></script>
<script type="text/javascript" src="js/js/jquery.imgbox.pack.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $(".imagePro").imgbox({
	            'speedIn': 0,
	            'speedOut': 0,
	            'alignment': 'center',
	            'overlayShow': true,
	            'allowMultiple': false
	        });
	    });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%"bgcolor="#F6F7F9">
        <tr>
            <td colspan="6" align="center"
                style="font-family: 微软雅黑; color: #000000; font-weight: bold; font-size: medium;" 
                valign="middle">重大项目月报</td>
              
        </tr>
        <tr>
            <td width="5%" rowspan="17" align="right"></td>
            <td width="20%" align="right">所属区县：</td>
            <td width="25%"> 
                <asp:Label ID="Label1" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                </td>

                <td style="font-size: medium;" class="style18" 
                align="right"width="20%">项目名称：</td>
                <td class="style5"width="25%">
                    <asp:Label ID="Label2" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
            <td width="5%" rowspan="17%"></td>

        </tr>
        <tr>
           <td align="right">
               建设地址：</td>
            <td> 
                <asp:Label ID="Label3" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>

                <td style="font-size: medium;" class="style18" 
                align="right">建设年限：</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>

        </tr>
        <tr>
            <td align="right">建设性质：</td>
            <td colspan="3">
                <asp:Label ID="Label5" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">建设内容及规模：</td>
            <td colspan="3"> 
                <asp:Label ID="Label6" runat="server" Text="" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="right">项目图片展示：</td>
            <td colspan="3">&nbsp;&nbsp;
               &nbsp;<asp:DataList ID="DataList1"  RepeatColumns="5" Width="100%" Height="155px"  runat="server">
    <ItemTemplate>
    <a class="imagePro" href='../<%#Eval("path") %>'><img style="height: 155px; width: 152px" alt="图片" src='../<%#Eval("path") %>'  /></a>
    </ItemTemplate>
    </asp:DataList>
                
           </td>
        </tr>
        <tr>
            <td align="right">总投资：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label12" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">中央资金：</td>
            <td style="font-size: 13px">
                <asp:Label ID="Label13" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
         <tr>
            <td align="right">省级资金：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label14" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">市级资金：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label15" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
         </tr>
         <tr>

        `   <td align="right">区县资金：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label16" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">银行贷款：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label17" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">企业自筹：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label18" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">截至<%=reportTime.Year -1 %>年底完成投资：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label19" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right"><%=reportTime.Year %> 年计划投资：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label20" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td  align="right">目前为止项目形象进度：</td>
            <td colspan="3"> 
                <asp:Label ID="Label21" runat="server" Text="" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">开工(计划开工)时间：</td>
            <td>
                <asp:Label ID="Label22" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
            <td align="right">计划竣工时间：</td>
            <td>
                <asp:Label ID="Label23" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">四个一批范畴：</td>
            <td>
                <asp:Label ID="Label24" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
            <td align="right">已取得土地指标：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label25" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
        </tr>
        <tr>
            <td align="right">拟申请土地指标：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label26" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
            <td align="right">是否政府投资项目：</td>
            <td> 
                <asp:Label ID="Label27" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  align="right"><%=reportTime.Month%>月完成投资额：</td>
            <td style="font-size: 13px"><asp:Label ID="Label29" runat="server" Text="" Height="20px" Width="200px"></asp:Label>(万元)</td>
            <td align="right">1-<%=reportTime.Month %>月完成投资额：</td>
            <td style="font-size: 13px"><asp:Label ID="Label28" runat="server" Text="" Height="20px" Width="200px"></asp:Label>(万元)</td>
            
        </tr>
        <tr>
            <td  align="right">需协调解决的问题：</td>
            <td colspan="3"> 
                <asp:Label ID="Label30" runat="server" Text="" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">备注：</td>
            <td colspan="3"> 
                <asp:Label ID="Label31" runat="server" Text="" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

