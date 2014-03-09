<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemst_month_add.aspx.cs" Inherits="Admin_itemst_month_add" %>

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
    <table  width="100%" bgcolor="#F6F7F9">
        <tr>
            <td colspan="4" align="center" 
                style="font-family: 微软雅黑; color: #000000; font-weight: bold; font-size: medium;" 
                valign="middle" class="style1">生态旅游重大项目月报</td>
        </tr>
        <tr>
            <td width="15%" align="right">所属区县：</td>
            <td width="25%"> 
                <asp:Label ID="Label1" runat="server" Height="20px" Width="200px"></asp:Label>
                </td>

                <td width="15%" align="right">项目名称:</td>
                <td width="25%"><asp:Label ID="Label2" runat="server" Height="20px" Width="386px"></asp:Label>
            </td>
        </tr>
        <tr>
           <td align="right">
               建设地址：</td>
            <td> 
                <asp:Label ID="Label3" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>

                <td  align="right">建设年限:</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>

        </tr>
        <tr>
            <td align="right" colspan="">建设性质：</td>
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
   
        <tr >
            <td align="right">项目图片展示：</td>
            <td colspan="3"> 
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
       
            <img alt="" onclick='javascript:showImage(<%#Eval("id")%>);'  id='<%#Eval("id") %>' src='<%#Eval("picPath")%>' style="height: 147px; width: 160px" />
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

           </td>
        </tr>
        <tr>
            <td align="right">总投资：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label7" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">中央资金：</td>
            <td style="font-size: 13px">
                <asp:Label ID="Label8" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
         <tr>
            <td align="right">省级资金：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label9" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">市级资金：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label10" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
         </tr>
         <tr>

        `   <td align="right">区县资金：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label11" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td align="right">银行贷款：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label12" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right" class="style2">企业自筹：</td>
            <td class="style2" style="font-size: 13px"> 
                <asp:Label ID="Label13" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
            <td class="style2" align="right">截至<%=DateTime.Now.Year %>年底完成投资：</td>
            <td class="style2" style="font-size: 13px"> 
                <asp:Label ID="Label14" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right"><%=DateTime.Now.Year %>年计划投资：</td>
            <td colspan="3" style="font-size: 13px"> 
                <asp:Label ID="Label15" runat="server" Height="20px" Width="200px"></asp:Label>
                (万元)</td>
        </tr>
        <tr>
            <td align="right">目前为止项目形象进度：</td>
            <td colspan="3" style="font-size: 13px"> 
                <asp:TextBox ID="TextBox21" runat="server" TextMode="MultiLine" Height="70px" 
                    Width="680px"></asp:TextBox>
                （可修改）</td>
        </tr>
        <tr>
            <td align="right">开工(计划开工)时间：</td>
            <td>
                <asp:Label ID="Label16" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
            <td align="right">计划竣工时间：</td>
            <td>
                <asp:Label ID="Label17" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">四个一批范畴：</td>
            <td style="font-size: 13px">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="205px">
                    <asp:ListItem Value="tcdc">投产达产</asp:ListItem>
                    <asp:ListItem Value="qqcb">前期储备</asp:ListItem>
                    <asp:ListItem Value="jkjs">加快建设</asp:ListItem>
                    <asp:ListItem Value="cjkg">促进开工</asp:ListItem>
                </asp:DropDownList>
                (可修改)</td>
            <td align="right"> 已取得土地指标：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label18" runat="server" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
        </tr>
        <tr>
            <td align="right">拟申请土地指标：</td>
            <td style="font-size: 13px"> 
                <asp:Label ID="Label19" runat="server" Height="20px" Width="200px"></asp:Label>
                (亩)</td>
            <td align="right">是否政府投资项目：</td>
            <td> 
                <asp:Label ID="Label20" runat="server" Height="20px" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right"><%=DateTime.Now.Month%>月完成投资额：</td>
                <td class="style14" style="font-size: 13px">
                    <asp:TextBox ID="TextBox22" runat="server" CssClass="text" AutoPostBack="True" EnableTheming="True"
                        ontextchanged="TextBox22_TextChanged" ></asp:TextBox>
                    (万元)(可修改)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ErrorMessage="*" ControlToValidate="TextBox22"></asp:RequiredFieldValidator>
            </td>
            <td align="right">1-<%=DateTime.Now.Month%>月完成投资额：</td>
            <td style="font-size: 13px">
                <asp:Label ID="TextBox1" runat="server" CssClass="text"></asp:Label>(万元)</td>
        </tr>
        <tr>
            <td  align="right">需协调解决的问题：</td>
            <td colspan="3" style="font-size: 13px"> 
                <asp:TextBox ID="DevelopDirectionText" runat="server" Height="70px" TextMode="MultiLine" 
                    Width="680px"></asp:TextBox>(可修改)</td>
        </tr>
        <tr>
            <td align="right">备注:</td>
            <td colspan="3" style="font-size: 13px"> 
                <asp:TextBox ID="TextBox16" runat="server" TextMode="MultiLine" Height="70px" 
                    Width="680px"></asp:TextBox>
                （可修改）</td>
        </tr>
        
        <tr>
            <td class="style7" align="center" colspan="4">
                <asp:Button ID="Button1" 
                    runat="server" Text="保存" BackColor="#1C60EC" Font-Size="14px" ForeColor="White"
                    Height="35px" Width="87px" onclick="Button1_svae" /></td>
        </tr>
    
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

