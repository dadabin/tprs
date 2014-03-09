<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemjg_update.aspx.cs" Inherits="Admin_itemjg_add" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="center"bgcolor="#F6F7F9">
<tr><td colspan="4" align="center" class="style2">基本信息</td></tr>
<tr> <td colspan="4" align="center" style="color: #FF0000; font-size: small;">注意：*项为必填项！</td></tr>
<tr><td width="20%" align="right">所属区县：</td><td class="style1">
    <asp:Label ID="Label2" runat="server" Text="区县"></asp:Label>
    </td><td width="20%" align="right">项目名称：</td>
    <td class="style1" style="color: #FF0000">
    <asp:TextBox ID="TextBox2" runat="server" 
        CssClass="text"></asp:TextBox>*
    <asp:RequiredFieldValidator ControlToValidate="TextBox2" 
        ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="项目名称不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
</tr>
<tr><td class="style1" align="right">建设地址：</td>
    <td class="style1"style="color: #FF0000"><asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox>*
        <asp:RequiredFieldValidator ControlToValidate="TextBox4"  ID="RequiredFieldValidator2" 
        ForeColor="Red" runat="server" ErrorMessage="建设地址该项不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
    <td class="style1" align="right">建设起止年限：</td>
    <td class="style1"><asp:TextBox ID="TextBox7" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="TextBox7"  ID="RequiredFieldValidator1" 
        ForeColor="Red" runat="server" ErrorMessage="建设起止年限不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
</tr>
<tr><td align="right">项目建设规模：</td><td colspan="3">
    <asp:TextBox ID="TextBox9" runat="server" TextMode="MultiLine" 
        CssClass="textarea" Height="70px" Width="790px"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="TextBox9"  ID="RequiredFieldValidator3" 
        ForeColor="Red" runat="server" ErrorMessage="建设内容及规模不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
</tr>
<tr><td align="right">计划总投资：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox10" runat="server" CssClass="text"></asp:TextBox>（万元）<span style="color: #FF0000">*</span>
    <asp:RequiredFieldValidator ControlToValidate="TextBox10"  ID="RequiredFieldValidator4" 
        ForeColor="Red" runat="server" ErrorMessage="计划总投资不能为空！" Font-Size="Small"></asp:RequiredFieldValidator></td>
    <td align="right"><%=submitTime.Year%>年计划投资：</td><td style="font-size: 13px">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
       (万元) </td>
</tr>
<tr><td align="right"><%=submitTime.Year %>年底工程应达形象进度：</td><td colspan="3">
    <asp:TextBox ID="TextBox3" runat="server" Height="86px" TextMode="MultiLine" 
        Width="790px"></asp:TextBox><span style="color: #FF0000">*</span></td></tr>
<tr><td align="right">至<%=submitTime.Year-1 %>年已累计完成投资：</td><td style="font-size: 13px">
        <asp:TextBox ID="TextBox5" runat="server" CssClass="text"></asp:TextBox>（万元）</td><td align="right"><%=submitTime.Year%>年<%=nowMonth %>月完成投资：</td><td colspan="3" style="font-size: 13px">
    <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True"  EnableTheming="True" 
                CssClass="text" ontextchanged="TextBox6_TextChanged"></asp:TextBox>
            （万元）<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TextBox6" runat="server" 
                ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
</tr>
<tr><td align="right"><%=submitTime.Year %>年1-<%=nowMonth %>月完成投资：</td><td style="font-size: 13px"> 
    <asp:Label ID="TextBox11" runat="server" Height="20px" Width="200px"></asp:Label>
    (万元)</td>
    <td align="right">四个一批范畴：</td>
    <td> 
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="205px">
            <asp:ListItem Value="yc">已成</asp:ListItem>
            <asp:ListItem Value="zj">在建</asp:ListItem>
            <asp:ListItem Value="gh">规划</asp:ListItem>
        </asp:DropDownList>
    </td>
    
</tr>
<tr  ><td align="right">图片列表：</td><td colspan="3">
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
<tr><td align="right">目前形象进度：</td><td colspan="3">
    <asp:TextBox ID="TextBox8" runat="server" 
                    Height="102px" TextMode="MultiLine" Width="790px"></asp:TextBox></td></tr>


<tr><td align="center"colspan="4">
    <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" 
        BackColor="#2480F1" ForeColor="White" 
        CssClass="button" Height="35px" Width="97px" Font-Size="14px" />
    </td>
</tr>
</table>
<br />
    <asp:Label ID="Lab_Image1_new" runat="server" Text="" Visible="false" 
        ></asp:Label>
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