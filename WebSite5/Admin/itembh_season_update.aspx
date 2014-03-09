<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/index.master" AutoEventWireup="true" CodeFile="itembh_season_update.aspx.cs" Inherits="Admin_itembh_season_update" %>

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
    <table bgcolor="#F6F7F9">
        <tr>
            <td colspan="6" align="right"><h3 align="center">百湖工程季度报告表</h3></td>
        </tr>
        <tr><td width="10%" rowspan="15" align="right"></td>
            <td align="right">所属区县:</td>
            <td>
                <asp:Label ID="Label1" runat="server" Height="20px" Text="Label" Width="200px"></asp:Label>
            </td>
            <td align="right" width="15%">工程名称:</td>
            <td width="25%">
                <asp:Label ID="ProjectNameText" runat="server" Text="Label" Height="20px" 
                    Width="200px"></asp:Label></td>
            <td width="10%" rowspan="15"> <!--隐藏表单---><asp:HiddenField ID="HiddenField1" runat="server" /></td>
        </tr>
        <tr>
            
            <td width="15%" align="right">建设地址:</td>
            <td width="25%"><asp:Label ID="ProjectAddressText" runat="server" Height="20px" 
                    Width="200px"></asp:Label></td>
             <td align="right"> 完工时间:</td>
             <td> 
                <asp:Label ID="FinishTimeText" runat="server" CssClass="text"></asp:Label></td>
        </tr>
        <tr>
           
              <td align="right"> 水域面积:</td>
              <td style="font-size: 13px"> 
                 <asp:Label ID="warterAreaText" runat="server" Height="20px" Width="200px"></asp:Label>（亩）</td>
              <td align="right">省级以上财政:</td>
              <td style="font-size: 13px"> 
                 <asp:Label ID="ProvinciaLevelFiscalText" runat="server" Height="20px" 
                    Width="200px"></asp:Label>（万元）</td>
        </tr>
        <tr>
            
               <td align="right"> 市级财政:</td>
               <td style="font-size: 13px">
                    <asp:Label ID="MunicipalFinanceText" runat="server" Height="20px" Width="200px"></asp:Label>（万元）</td>
                
               <td align="right">县级财政:</td>
               <td style="font-size: 13px"> 
                     <asp:Label ID="CountyFinanceText" runat="server" Height="20px" Width="200px"></asp:Label>（万元）</td>
        </tr>
        <tr>
           
               <td align="right">财政融资:</td>
               <td style="font-size: 13px">
                   <asp:Label ID="FinanceFinanceText" runat="server" Height="20px" Width="200px"></asp:Label> （万元）</td>
               <td align="right">社会投入:</td>
                        <td style="font-size: 13px"> 
                            <asp:Label ID="SocialInvestmentText" runat="server" Height="20px" Width="200px"></asp:Label>（万元）</td>
        </tr>
        <tr>
           
                <td align="right"> 群总投入:</td>
                <td style="font-size: 13px"> 
                    <asp:Label ID="PublicInvestmentText" runat="server" Height="20px" Width="200px"></asp:Label>（万元）</td>
                <td align="right"> 其它:</td>
                <td style="font-size: 13px"> 
                    <asp:Label ID="OtherText" runat="server" Height="20px" Width="200px"></asp:Label>（万元）</td>
        </tr>
        <tr>
           
                <td align="right">占用土地面积:</td>
                <td style="font-size: 13px"> 
                    <asp:Label ID="occupiedAreaText" runat="server" Height="20px" Width="200px"></asp:Label>（亩）</td>
                <td align="right"> 占用方式:</td>
                <td> 
                     <asp:Label ID="occupiedTypeText" runat="server" Height="20px" Width="200px" ></asp:Label></td>
        </tr>
        <tr>
            
                    <td align="right"> 单价: </td>
                    <td style="font-size: 13px"> 
                        <asp:Label ID="UnitPriceText" runat="server" Height="20px" Width="200px"></asp:Label>（元/亩*年）</td>
                    <td align="right"> 管护主体:</td>
                    <td>
                        <asp:Label ID="ManageSubjectText" runat="server" Height="20px" Width="200px"></asp:Label> </td>
        </tr>
        
        <tr>
           
                <td align="right">四个一批范畴:</td><td style="font-size: 13px">
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="15px" 
                Height="25px" Width="205px">
            <asp:ListItem Text="在建" Value="zj"></asp:ListItem>
            <asp:ListItem Text="已成" Value="yc"></asp:ListItem>
            <asp:ListItem Text="规划" Value="gh"></asp:ListItem>
         
            </asp:DropDownList>
            （可修改）</td>
        <td align="right">总投资:</td>
        <td style="color: #FF0000">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>*</td>
        </tr>
        <tr>
            <td align="right"> 目前工程形象进度:</td>
            
            <td colspan="3"> 
                <asp:TextBox ID="ImageProgressText" runat="server" Height="70px" Width="680px" 
                    TextMode="MultiLine"></asp:TextBox>（可修改）</td>
        </tr>
        <tr ><td align="right"> 
                    图片列表:</td>
                    <td colspan="3" style="font-size: 13px"> 
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
                        
                        
                        </td></tr>
         <tr>
                <td colspan="4" align="center"> 
                    <asp:Button ID="Button4" runat="server" Text="保存" onclick="Button4_Click" Font-Size="14px" ForeColor="White"
                     BackColor="#2480F1"   Height="39px" Width="90px" /></td>
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

