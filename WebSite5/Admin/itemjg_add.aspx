<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemjg_add.aspx.cs" Inherits="Admin_itemjg_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript">
       
        function displayCalendar()
         {
             var datePicker = document.getElementById('datePicker');
            datePicker.style.display = 'block';
       }
     
     </script>
    <style type="text/css">
        #datePicker
        {
             display:none;
             position:absolute;
            border:solid 2px black;
            background-color:white;
         }
  </style>
 
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
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" bgcolor="#F6F7F9">
    <tr> <td colspan="4" align="center" style="color: #FF0000; font-size: small;">注意：*项为必填项！</td></tr>
    <tr><td width="15%"align="right">所属区县：</td><td width="35%">
        <asp:Label ID="Label2" runat="server" Height="20px" Width="200px"></asp:Label></td>
    <td  align="right" class="style1"width="15%">项目名称：</td>
    <td class="style1" style="color: #FF0000"width="35%">
    <asp:TextBox ID="TextBox2" runat="server" CssClass="text" AutoPostBack="True" OnTextChanged="TxtName_TextChanged" EnableTheming="True"></asp:TextBox>
        <asp:Label ID="checkresult" runat="server" ></asp:Label>

        <asp:RequiredFieldValidator ControlToValidate="TextBox2" ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="项目名称不能为空！" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td width="15%"align="right">建设地址：</td>
    <td width="35%"style="color: #FF0000"><asp:TextBox ID="TextBox4" runat="server" CssClass="text"></asp:TextBox>*
        <asp:RequiredFieldValidator ControlToValidate="TextBox4"  ID="RequiredFieldValidator2" 
        ForeColor="Red" runat="server" ErrorMessage="建设地址该项不能为空！" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator></td>
    <td class="style1" align="right"width="15%">建设起止年限：</td>
    <td class="style1"width="35%"><asp:TextBox ID="TextBox7" runat="server" CssClass="text"> </asp:TextBox>
      <!---  <img src="../image/Calendar_scheduleHS.png" onclick="displayCalendar()" 
            style="height: 34px; width: 33px" />
        <div id="datePicker">
            <asp:Calendar id="calEventDate" OnSelectionChanged="calEventDate_SelectionChanged" Runat="server"  ></asp:Calendar>
        </div>-->
        <asp:RequiredFieldValidator ControlToValidate="TextBox7"  ID="RequiredFieldValidator1" 
        ForeColor="Red" runat="server" ErrorMessage="建设起止年限不能为空！" Font-Size="Small" ValidationGroup="add"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">项目建设规模：</td><td colspan="3"width="90%">
    <asp:TextBox ID="TextBox9" runat="server" TextMode="MultiLine" 
        CssClass="textarea" Height="70px" Width="765px"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="TextBox9"  ID="RequiredFieldValidator3" 
        ForeColor="Red" runat="server" ErrorMessage="建设内容及规模不能为空！" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator></td></tr>
<tr><td align="right">计划总投资：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox10" runat="server" CssClass="text"></asp:TextBox>(万元)<span 
        style="color: #FF0000">*</span>
    <asp:RequiredFieldValidator ControlToValidate="TextBox10"  ID="RequiredFieldValidator4" 
        ForeColor="Red" runat="server" ErrorMessage="总投资不能为空！" ValidationGroup="add" Font-Size="Small"></asp:RequiredFieldValidator></td>
    <td align="right" class="style1"><%=DateTime.Now.Year %>年计划投资：</td><td style="font-size: 13px">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
       (万元) </td></tr>
<tr><td align="right" ><%=DateTime.Now.Year %>年底工程应达形象进度：</td><td colspan="3" style="color: #FF0000">
    <asp:TextBox ID="TextBox3" runat="server" Height="86px" TextMode="MultiLine" 
        Width="765px"></asp:TextBox>*</td></tr>
<tr> <td class="style1" align="right">至<%=DateTime.Now.Year-1 %>年已累计完成投资：</td><td style="font-size: 13px">
        <asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="200px"></asp:TextBox>
        (万元)</td>
        <td align="right"><%=DateTime.Now.Year %> 年 <%=DateTime.Now.Month %> 月完成投资：</td><td style="font-size: 13px">
    <asp:TextBox ID="TextBox6" runat="server"   AutoPostBack="True" EnableTheming="True"
        Height="20px" Width="200px" ontextchanged="TextBox6_TextChanged"></asp:TextBox>
            （万元）<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TextBox6" ValidationGroup="add" runat="server" 
                ErrorMessage="*"></asp:RequiredFieldValidator>
            </td></tr>
<tr>
    <td align="right"><%=DateTime.Now.Year %>年1-<%=DateTime.Now.Month%>月完成投资：</td>
    <td style="font-size: 13px"><asp:Label ID="TextBox11" runat="server" CssClass="text"></asp:Label>
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
                    Height="77px" TextMode="MultiLine" Width="760px"></asp:TextBox></td></tr>


<tr><td align="center"colspan="4">
    <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" BackColor="#2480F1"
        Height="34px" Width="91px" Font-Size="14px" ForeColor="White" ValidationGroup="add" /></td>
</tr>

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

