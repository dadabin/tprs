<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itembh_view_season.aspx.cs" Inherits="Admin_view_itembh_view_season" %>

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
 <table width="100%" align="center"bgcolor="#F6F7F9">
        <tr>
            <td colspan="4" align="right" class="style1"><h3 align="center">百湖工程季度报告表</h3></td>
            <td class="style1"> <!--隐藏表单--->
            <asp:HiddenField ID="HiddenField1" runat="server" /></td>
           
        </tr>
        <tr>
            <td align="right">所属区县:</td>
            <td> 
                <asp:Label ID="Label23" runat="server" Height="20px" Text="Label" Width="200px"></asp:Label>
            </td>
            <td width="20%" align="right">工程名称:</td>
            <td width="25%">
                <asp:Label ID="Label1" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label></td>
            <td width="5%" rowspan="11"></td>
        </tr>
        <tr>
            
            <td width="20%" align="right">建设地址:</td>
            <td width="25%"><asp:Label ID="Label2" runat="server" Text="Label" Height="20px" 
                    Width="200px"></asp:Label></td>
            <td align="right"> 完工时间:</td>
            <td> 
                <asp:Label ID="Label3" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
             <td align="right"> 水域面积:</td>
             <td style="font-size: 13px"> 
                <asp:Label ID="Label4" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>（亩）</td>
             <td align="right">省级以上财政:</td>
             <td style="font-size: 13px"> 
                <asp:Label ID="Label5" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
             <td align="right"> 市级财政:</td>
             <td style="font-size: 13px">
                    <asp:Label ID="Label6" runat="server" Height="20px" Width="200px" Text="Label"></asp:Label>
                (万元)</td>
             <td align="right">县级财政:</td>
             <td style="font-size: 13px"> 
                           <asp:Label ID="Label7" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                            (万元)</td>
        </tr>
        <tr>
          
               <td align="right">财政融资:</td>
               <td style="font-size: 13px">
                   <asp:Label ID="Label8" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
                <td align="right">社会投入:</td>
                <td style="font-size: 13px"> 
                                <asp:Label ID="Label9" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                                (万元)</td>
        </tr>
        <tr>
            
                <td align="right"> 群总投入:</td>
                <td style="font-size: 13px"> 
                    <asp:Label ID="Label10" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
                <td align="right"> 其它:</td>
                <td style="font-size: 13px"> 
                        <asp:Label ID="Label11" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                        (万元)</td>
        </tr>
        <tr>
           
                <td align="right">占用土地面积:</td>
                <td style="font-size: 13px"> 
                    <asp:Label ID="Label12" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                    （亩）</td>
                <td align="right" class="style2"> 占用方式:</td>
                <td class="style2"> 
                     <asp:Label ID="Label13" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label></td>
        </tr>
        <tr>
                <td align="right" class="style2"> 单价: </td>
                <td class="style2" style="font-size: 13px"> 
                        <asp:Label ID="Label14" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
                        （元/亩*年）</td>
                <td align="right"> 管护主体:</td>
                            <td>
                         <asp:Label ID="Label15" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label></td>
        </tr>
        
        <tr>
            
                <td align="right">四个一批范畴:</td><td colspan="3">
            <asp:Label ID="Label16" runat="server" Text="Label" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right"> 目前工程形象进度:</td>
            <td colspan="3"> 
                <asp:Label ID="Label17" runat="server" Text="Label" Height="70px" Width="680px"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="right">图片列表：</td>
            <td colspan="3"> 
                &nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:DataList ID="DataList1"  RepeatColumns="5" Width="100%" Height="155px"  runat="server">
    <ItemTemplate>
   <a class="imagePro" href='../<%#Eval("path") %>'> <img style="height: 155px; width: 152px" alt="图片" src='../<%#Eval("path") %>'  /></a>
    </ItemTemplate>
    </asp:DataList>
                </td>
        </tr>

</table>
</asp:Content>

