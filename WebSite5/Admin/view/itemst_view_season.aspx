<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_view_season.aspx.cs" Inherits="Admin_view_itemst_view_season" %>

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
            <td colspan="4" align="center" 
                style="font-family: 微软雅黑; color: #000000; font-weight: bold; font-size: medium;" 
                valign="middle">生态旅游重大项目季报 <!--隐藏表单---></td>
        </tr>
        <tr>
            <td width="20%" align="right">所属区县：</td>
            <td width="25%">
                <asp:Label ID="Label1" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                </td>
                <td width="20%" align="right">项目名称：</td>
                <td width="25%">
                    <asp:Label ID="Label2" runat="server" Height="20px" Width="351px"></asp:Label>
            </td>

        </tr>
        <tr>
           <td align="right" >建设地址：</td>
           <td > 
              <asp:Label ID="Label3" runat="server" Height="20px" Width="345px"></asp:Label>
            </td>

                <td align="right">建设年限：</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Height="20px" Width="331px"></asp:Label>
            </td>

        </tr>
        <tr>
            <td align="right">建设性质：</td>
            <td colspan="3"> 
                <asp:Label ID="Label5" runat="server" Height="20px" Width="264px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">建设内容及规模：</td>
            <td colspan="3"> 
                <asp:Label ID="Label6" runat="server" Text="" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
        <tr style="display:none"> 
            <td align="right">项目图片展示：</td>
            <td colspan="3"> 
                <asp:Label ID="Label7" runat="server" Text="" Height="100px" Width="100px"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="" Height="100px" Width="100px"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="" Height="100px" Width="100px"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text="" Height="100px" Width="100px"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server" Text="" Height="100px" Width="100px"></asp:Label>
           </td>
        </tr>
        <tr>
            <td align="right">总投资：</td>
            <td> 
                <asp:Label ID="Label12" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">中央资金：</td>
                <td> 
                    <asp:Label ID="Label13" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                    (万元)</td>
        </tr>
        <tr>
            <td align="right">省级资金：</td>
            <td> 
                <asp:Label ID="Label14" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">市级资金：</td>
            <td> 
                <asp:Label ID="Label15" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">区县资金：</td>
            <td> 
                <asp:Label ID="Label16" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">银行贷款：</td>
            <td> 
                <asp:Label ID="Label17" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">企业自筹：</td>
            <td> 
                <asp:Label ID="Label18" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">截至2011年底完成投资：</td>
            <td> 
                <asp:Label ID="Label19" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">2012年计划投资：</td>
            <td colspan="3"> 
                <asp:Label ID="Label20" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">目前为止项目形象进度：</td>
            <td colspan="3"> 
                <asp:Label ID="Label21" runat="server" Text="" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">开工（计划开工）时间：</td>
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
            <td>
                <asp:Label ID="Label25" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
        </tr>
        <tr>
            <td align="right">拟申请土地指标：</td>
            <td>
                <asp:Label ID="Label26" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
            <td align="right">是否政府投资项目：</td>
            <td>
                <asp:Label ID="Label27" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">1-7月完成投资额：</td>
            <td>
                <asp:Label ID="Label28" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">7月完成投资额：</td>
            <td>
                <asp:Label ID="Label29" runat="server" Text="" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
                <td align="right">需协调解决的问题：</td>
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
        <tr><td> <asp:HiddenField ID="HiddenField1" runat="server" />  <!--ID--></td>
            <td colspan="3"><asp:HiddenField ID="HiddenField2" runat="server" Value="<%=projNum %>" /></td>
        </tr>  
    </table>
</asp:Content>

