<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_add.aspx.cs" Inherits="Admin_itemst_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
 body{font-size:14px;}
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
    .textarea
    {}
 </style>
   <style type='text/css'> 
#demo{overflow:hidden;width:180px;text-align:center;padding:10px;} 
#demo img{border:none;width:167px;height:62px;border:5px solid #f4f4f4} 
#enlarge_images{position:absolute;display:none;z-index:2;border:5px solid #f4f4f4} 
</style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table width="100%"bgcolor="#F6F7F9"><tr>
    <td colspan="4" align="center" class="style23">1.基本信息</td></tr>
<tr><td colspan="4" align="center" style="font-size: small; color: #FF0000">
    注意：*项为必填项</td></tr>
<tr><td align="right"width="15%">所属区县：</td>
    <td width="35%"><asp:Label ID="Label1" runat="server" Height="20px" Width="200px" ></asp:Label>&nbsp;</td>
    <td align="right"width="15%">项目名称：</td>
    <td style="color: #FF0000"width="30%">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="text" AutoPostBack="True" OnTextChanged="TxtName_TextChanged" EnableTheming="True"></asp:TextBox>
        <asp:Label ID="checkresult" runat="server" ></asp:Label>*
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="项目名称不能为空！" ControlToValidate="TextBox1" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td align="right">建设地址：</td>
    <td style="color: #FF0000">
    <asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox>*
        <asp:RequiredFieldValidator ControlToValidate="TextBox2" 
        ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="建设地址不能为空！" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator>
    </td>
    <td align="right">建设年限：</td><td class="style20">
        <asp:TextBox ID="TextBox11" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ValidationGroup="add" ErrorMessage="建设年限不能为空！" 
            ControlToValidate="TextBox11" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
    <tr><td align="right">建设性质：</td><td colspan="3">
        <asp:DropDownList ID="DropDownList6" runat="server" CssClass="select" 
            Font-Size="Small" Height="26px" Width="205px">
        <asp:ListItem Text="新建" Value="1"></asp:ListItem>
        <asp:ListItem Text="续建" Value="2"></asp:ListItem>
        </asp:DropDownList>
        </td></tr>
           <tr><td align="right">建设内容及规模：</td><td colspan="3"> 
               <asp:TextBox ID="TextBox15" runat="server" TextMode="MultiLine" 
                   CssClass="textarea" Height="80px" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                       runat="server" ValidationGroup="add" ErrorMessage="建设内容及规模不能为空！" 
                   ControlToValidate="TextBox15" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
               

<tr ><td align="right">项目图片展示：</td><td colspan="3">
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
     
            <img alt=""  id='<%#Eval("id") %>' src='<%#Eval("picPath")%>' style="height: 130px; width: 150px" />
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
<tr><td width="15%" align="right">总投资：</td><td width="35%" style="font-size: 13px">
    <asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox>（万元）<span 
                style="color: #FF0000">*</span>
    <asp:RequiredFieldValidator ControlToValidate="TextBox4" 
        ID="RequiredFieldValidator5" runat="server"  ValidationGroup="add"
            ErrorMessage="总投资不为空！" Font-Size="Small"></asp:RequiredFieldValidator>
    </td><td align="right"width="15%">中央资金：</td><td width="35%" style="font-size: 13px">
        <asp:TextBox ID="TextBox9" runat="server" CssClass="text"></asp:TextBox>（万元）</td></tr>
<tr><td align="right">省级资金：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox>（万元）</td>
    <td align="right">市级资金：</td>
    <td style="font-size: 13px">
    <asp:TextBox ID="TextBox19" runat="server" CssClass="text"></asp:TextBox>（万元）</td></tr>
<tr><td align="right">区县资金：</td><td class="style14" style="font-size: 13px">
    <asp:TextBox ID="TextBox6" runat="server" CssClass="text"></asp:TextBox>（万元）</td>
    <td align="right">银行贷款：</td>
    <td style="font-size: 13px">
    <asp:TextBox ID="TextBox20" runat="server" CssClass="text"></asp:TextBox>（万元）</td></tr>
<tr><td align="right" >企业自筹：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox8" runat="server" CssClass="text"></asp:TextBox>（万元）</td>
    <td align="right">截至<%=DateTime.Now.Year - 1%>年底累计完成投资：</td>
    <td class="style9" style="font-size: 13px">
        <asp:TextBox ID="TextBox21" runat="server" CssClass="text"></asp:TextBox>（万元）</td></tr>
<tr><td align="right"><%=DateTime.Now.Year%>年计划投资：</td><td colspan="3" style="font-size: 13px">
    <asp:TextBox ID="TextBox7" runat="server" CssClass="text"></asp:TextBox>（万元）</td></tr>
    <tr><td align="right">目前为止项目形象进度：</td><td colspan="3"> 


        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" 
            CssClass="textarea" Height="95px" Width="80%"></asp:TextBox></td></tr>
<tr><td  width="15%" align="right" >开工(计划开工)时间：</td>
    <td width="35%"><asp:TextBox ID="TextBox13" 
        runat="server" CssClass="text"></asp:TextBox></td>
    <td align="right" class="style4" width="15%">计划竣工时间：</td><td class="style4"width="35%">
    <asp:TextBox ID="TextBox16" runat="server" CssClass="text" ></asp:TextBox></td></tr>
    <tr><td align="right" >四个一批范畴：</td><td colspan="3"> 
        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="select" 
            Font-Size="Small" Height="26px" Width="205px">
            <asp:ListItem Value="tcdc">投产达产</asp:ListItem>
            <asp:ListItem Value="qqcb">前期储备</asp:ListItem>
            <asp:ListItem Value="jkjs">加快建设</asp:ListItem>
            <asp:ListItem Value="cjkg">促进开工</asp:ListItem>
        </asp:DropDownList>
        </td></tr>
<tr>
    <td align="right" width="15%">已取得土地指标：</td><td class="style11"width="35%" style="font-size: 13px">
    <asp:TextBox ID="TextBox10" runat="server" CssClass="text"></asp:TextBox>（亩）</td>
    <td align="right"width="15%" class="style7" >拟申请土地指标：</td><td class="style7" width="35%"  style="font-size: 13px">
    <asp:TextBox ID="TextBox22" runat="server" CssClass="text"></asp:TextBox>（亩）</td></tr>
    <tr> <td align="right">是否政府投资项目：</td><td class="style10">
        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="select" 
            Font-Size="Small" Height="26px" Width="205px">
            <asp:ListItem Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:DropDownList></td>
         <td align="right"><%=DateTime.Now.Month%>月完成投资额：</td><td style="font-size: 13px">
                    <asp:TextBox ID="TextBox12" runat="server" CssClass="text"></asp:TextBox>(万元)<span 
                style="color: #FF0000">*</span><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6" runat="server" ErrorMessage="不能为空" 
                        ControlToValidate="TextBox12" Font-Size="Small" ValidationGroup="add" ></asp:RequiredFieldValidator></td>
   </tr>
   <tr>
  
   <td align="right">1月-<%=DateTime.Now.Month%>月完成投资额：</td>
        <td colspan="3" style="font-size: 13px"><asp:TextBox ID="TextBox17" runat="server" CssClass="text"></asp:TextBox>(万元)<span 
                style="color: #FF0000">*</span><asp:RequiredFieldValidator
                ID="RequiredFieldValidator7" ControlToValidate="TextBox17" ValidationGroup="add" runat="server" ErrorMessage="不能为空！"></asp:RequiredFieldValidator></td>
   
   </tr>
   <tr><td align="right">需要协调解决的问题：</td><td colspan ="3">
        <asp:TextBox ID="TextBox18" runat="server" 
            TextMode="MultiLine" Height="98px" Width="80%"></asp:TextBox></td> </tr><tr><td align="right">备注：</td><td colspan="3"> 
                <asp:TextBox ID="TextBox14" runat="server" TextMode="MultiLine" 
                    CssClass="textarea" Height="104px" Width="80%"></asp:TextBox></td></tr>
<tr><td colspan="4" align="center"><asp:Button ID="Button1" runat="server" 
        Text="保存" onclick="Button1_Click" CssClass="button" ValidationGroup="add" Height="35px" 
        BackColor="#2480F1" Font-Size="14px" ForeColor="White"
        Width="86px" /> </td></tr>
</table>
<br />
    <asp:Label ID="Lab_Image1_new" runat="server" Text="" Visible="false" 
        AutoPostBack="true"></asp:Label>
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

