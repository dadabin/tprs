<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itemjg_season_add.aspx.cs" Inherits="Admin_itemjg_season_add" %>

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
    <table width="100%"bgcolor="#F6F7F9">
        <tr>
            <td colspan="4" class="style2" align="right"><h3 align="center">景观农业重大项目季度推进表</h3>
            <!--隐藏表单--->
            </td>
        </tr>
        <tr>
            <td width="20%" align="right">所属区县:</td>
            <td width="30%"> 
                <asp:Label ID="Label1" runat="server" Height="20px" Width="200px"></asp:Label></td>
                    <td width="20%" align="right">项目名称:</td>
                    <td width="25%">
                        <asp:Label ID="ProjectNameText" runat="server" Height="20px" Width="200px"></asp:Label></td>
        </tr>
        <tr>
            <td class="style1" align="right">建设地址:</td>
            <td> 
                <asp:Label ID="ConstructionAddressText" runat="server" Height="20px" 
                    Width="200px"></asp:Label></td>
                      <td align="right">建设起止年限:</td>
            <td> 
                <asp:Label ID="StartConstructionTimeText" runat="server" Height="20px" 
                    Width="200px"></asp:Label></td>
        
        </tr>
        <tr>
          
                    <td class="style1" align="right">项目建设规模:</td>
                    <td colspan="3"> 
                        <asp:Label ID="ContentScaleText" runat="server" Height="119px" Width="955px"></asp:Label></td>
        </tr>
        <tr>
             <td align="right">计划总投资:</td>
             <td style="font-size: 13px"><asp:Label ID="PlanTotalMoneyText" runat="server"></asp:Label>（万元）</td>
             <td class="style1" align="right"><%=submitTime.Year%>年计划投资:</td>
             <td style="font-size: 13px"><asp:TextBox ID="PlannedTimeText" runat="server" CssClass="text"></asp:TextBox>（万元）（可修改）</td>
        </tr>
        <tr>
           
                    <td align="right"><%=submitTime.Year%>年底工程应达形象进度:</td>
                    <td colspan="3"> 
                        <asp:Label ID="EndTimeText" runat="server" Height="70" Width="680"></asp:Label></td>
        </tr>
        <tr>
            <td class="style1" align="right">至<%=submitTime.Year-1%>年已累计完成投资:</td>
            <td style="font-size: 13px">
                <asp:Label ID="FinishTotalInvestmentText" runat="server" Height="19px" 
                    CssClass="text"></asp:Label>
                （万元）</td>
                    <td align="right"> <%=submitTime.Year%>年<%if (submitTime.Month - 1 == 0) { Response.Write("1"); } else { Response.Write(submitTime.Month - 1); }%>月完成投资:</td>
                    <td style="font-size: 13px"> 
                        <asp:TextBox ID="FinishInvestmentText" runat="server" CssClass="text"></asp:TextBox>（万元）（可修改）</td>
        </tr>
        <tr><td class="style1" align="right"><%=submitTime.Year%>年1-<%if (submitTime.Month - 1 == 0) { Response.Write("1"); } else { Response.Write(submitTime.Month - 1); }%>月完成投资：</td><td style="font-size: 13px">
                <asp:TextBox ID="XFINISHINVESTMENT" runat="server" CssClass="text"></asp:TextBox>
                （万元）（可修改）</td>
            <td align="right">四个一批范畴:</td>
            <td> 
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="205px">
                    <asp:ListItem Value="yc">已成</asp:ListItem>
                    <asp:ListItem Value="zj">在建</asp:ListItem>
                    <asp:ListItem Value="gh">规划</asp:ListItem>
                </asp:DropDownList>
            </td>
         </tr>
        <tr>
            <td class="style1" align="right" > 目前形象进目前形象进度:</td>
            <td colspan="3" style="font-size: 13px">
                <asp:TextBox ID="ImageProgressText" runat="server" Height="70px" Width="680px"></asp:TextBox>
                    （可修改）</td>
        </tr>
    
        <tr  >
            <td class="style1" align="right"> 图片预览：</td>
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
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" BackColor="#2480F1" ForeColor="White" 
                   Font-Size="14px" Height="36px" Width="94px" /></td>
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

