<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itembh_add.aspx.cs" Inherits="Admin_itembh_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.datepicker-zh-CN.js" type="text/javascript"/>
    <script>
    $(function () {

        $("#<%=TextBox4.ClientID %>").datepicker({
            showButtonPanel: true
        });
    });
	</script>

<style type="text/css">
 body{font-size:14px;}
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
    <table width="100%" bgcolor="#F6F7F9">
<tr><td align="center" class="style3" colspan="4">基本信息</td></tr>
<tr> <td  colspan="4"align="center" style="color: #FF0000; font-size: small">注意：*项为必填选项</td></tr>
<tr><td align="right"width="15%">所属区县：</td><td width="35%">
    <asp:Label ID="Label2" runat="server" Height="20px" Width="200px"></asp:Label>
   </td>
<td align="right" class="style2" width="15%">工程名称：</td><td style="color: #FF0000"width="35%">
    <asp:TextBox ID="TextBox2" runat="server" CssClass="text" AutoPostBack="True" OnTextChanged="TxtName_TextChanged" EnableTheming="True"></asp:TextBox>
        <asp:Label ID="checkresult" runat="server" ></asp:Label>*
        <asp:RequiredFieldValidator ControlToValidate="TextBox2" 
        ValidationGroup="add"  ID="RequiredFieldValidator2" ForeColor="Red" 
        runat="server" ErrorMessage="工程名称不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">建设地址：</td><td style="color: #FF0000">
    <asp:TextBox ID="TextBox3" runat="server" CssClass="text"></asp:TextBox>*
        <asp:RequiredFieldValidator ControlToValidate="TextBox3" 
        ValidationGroup="add"  ForeColor="Red" ID="RequiredFieldValidator3" 
        runat="server" ErrorMessage="建设地址不为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
<td align="right" class="style2">完工时间：</td><td>
    <asp:TextBox ID="TextBox4" runat="server" CssClass="text" ></asp:TextBox></td></tr>
<tr><td class="style1" align="right">水域面积：</td><td class="style1" style="font-size: 13px">
    <asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox>（亩）<span 
        style="color: #FF0000">*</span>
        <asp:RequiredFieldValidator ControlToValidate="TextBox5" 
        ValidationGroup="add"  ID="RequiredFieldValidator5" runat="server" 
        ForeColor="Red" ErrorMessage="水域面积不为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
<td class="style2" align="right">省级以上财政：</td><td class="style1" style="font-size: 13px">
    <asp:TextBox ID="TextBox6" runat="server" CssClass="text" Font-Size="Small"></asp:TextBox>
        （万元）</td></tr>
<tr><td align="right">市级财政：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox7" runat="server" CssClass="text"></asp:TextBox>
        （万元）</td>
<td align="right" class="style2">县级财政：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox8" runat="server" CssClass="text"></asp:TextBox>
        （万元）</td></tr>
<tr><td align="right">财政融资：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox9" runat="server" CssClass="text"></asp:TextBox>
        （万元）</td>
<td align="right" class="style2">社会投入：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox10" runat="server" CssClass="text"></asp:TextBox>
        （万元）</td></tr>
<tr><td align="right">群众投入：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox11" runat="server" CssClass="text"></asp:TextBox>
    （万元）</td>
<td align="right" class="style2">其它：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox12" runat="server" CssClass="text"></asp:TextBox>
    （万元）</td></tr>
<tr><td align="right">占用土地面积：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox13" runat="server" CssClass="text"></asp:TextBox>（亩）</td>
<td align="right" class="style2">占用方式：</td><td>
    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="select" 
        Font-Size="15px" Height="25px" Width="205px">
        <asp:ListItem Value="null" Text="==现在占用方式=="></asp:ListItem>
    <asp:ListItem Value="lz" Text="流转"></asp:ListItem>
    <asp:ListItem Value="zy" Text="征用"></asp:ListItem>
    <asp:ListItem Value="lz&amp;zy" Text="流转及征用"></asp:ListItem>
    </asp:DropDownList>
    </td></tr>
<tr><td align="right">单价：</td><td colspan="3" style="font-size: 13px">
    <asp:TextBox ID="TextBox15" runat="server" CssClass="text"></asp:TextBox>（元/年*亩）
        </td></tr>
        <tr ><td align="right">图片列表：</td><td colspan="3">
  <div>
        <asp:DataList ID="DataList1" RepeatColumns="5"   runat="server" EditItem Height="131px" 
            Width="705px" oneditcommand="DataList1_EditCommand" 
            onupdatecommand="DataList1_UpdateCommand" 
            oncancelcommand="DataList1_CancelCommand">
            <EditItemTemplate>
                上传文件名<asp:FileUpload ID="FileUpload1" runat="server" Height="23px" 
                    Width="265px" />
        <br />
            <asp:LinkButton ID="LinkButton2" CommandName="Cancel" runat="server">取消修改</asp:LinkButton>
        
            <asp:LinkButton ID="LinkButton1" CommandName="Update" runat="server">修改取消</asp:LinkButton>
        
            </EditItemTemplate>
        <ItemTemplate>
       
            <img alt="" onclick='javascript:showImage(<%#Eval("id")%>);'  id='<%#Eval("id") %>' src='<%#Eval("picPath")%>' style="height: 130px; width: 150px" />
            <br />
           
            <asp:LinkButton CommandName="Edit"
              ID="Edit_But" ForeColor="#003366" runat="server">编辑</asp:LinkButton>
        </ItemTemplate>
        <EditItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='' ></asp:Label>
        <asp:Label ID="Label3" runat="server" Text='<%#Eval("picPath")%>' ></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            上传图片的格式只能是（jpg、png、jpng、gif）；
        <br />
            <asp:LinkButton ID="LinkButton1" CommandName="Update" runat="server">修改</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" CommandName="Cancel" runat="server">取消</asp:LinkButton>
        </EditItemTemplate>
        
        </asp:DataList>
    </div>
</td></tr>
        <tr>
<td align="right">目前工程的形象进度：</td><td colspan="3">
    <asp:TextBox ID="TextBox16" runat="server" TextMode="MultiLine" Height="70px" 
            Width="80%" ></asp:TextBox>
    </td></tr>
<tr><td align="right">管护主体：</td><td style="color: #FF0000">
    <asp:TextBox ID="TextBox17" runat="server" CssClass="text"></asp:TextBox>
    </td><td align="right">四个一批范畴：</td><td><asp:DropDownList ID="DropDownList1" 
        runat="server" Font-Size="15px" Height="25px" Width="205px">
            <asp:ListItem Text="在建" Value="zj"></asp:ListItem>
            <asp:ListItem Text="已成" Value="yc"></asp:ListItem>
            <asp:ListItem Text="规划" Value="gh"></asp:ListItem>
            </asp:DropDownList></td>
</tr>


<tr><td align="center" colspan="4">
    <asp:Button ID="Button1" runat="server" Text="保存"  ValidationGroup="add"  
        BackColor="#1C60EC" ForeColor="White"
        onclick="Button1_Click" CssClass="button" Height="36px" Width="102px" 
        Font-Size="14px" /></td></tr>
</table>
<br />
    <asp:Label ID="Lab_Image1_new" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Lab_Image2_new" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Lab_Image3_new" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Lab_Image4_new" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Lab_Image5_new" runat="server" Text="" Visible="false"></asp:Label>

     <asp:Label ID="Lab_Image1_old" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="Lab_Image2_old" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="Lab_Image3_old" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="Lab_Image4_old" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="Lab_Image5_old" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>

