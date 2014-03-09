<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>成都市龙泉山生态旅游综合功能区重大项目申报系统</title>
    <link href="css/login_.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <div class="content">
	<div class="content1">
     <form id="form1"  runat="server"><table>
     <tr><td style="font-size: 15px; color: #FFFFFF; font-weight:bold;">登陆名：</td><td> <asp:TextBox ID="LoginName" runat="server" Width="191px"></asp:TextBox></td><td>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
             ControlToValidate="LoginName" ValidationGroup="login"  ForeColor="Red" 
             ErrorMessage="登录名不能为空!" Font-Size="15px"></asp:RequiredFieldValidator></td></tr>
      <tr><td style="font-size: 15px;color: #FFFFFF; font-weight:bold;">密&nbsp;&nbsp;码：</td><td> <asp:TextBox ID="Password" runat="server" Width="191px" 
              TextMode="Password"></asp:TextBox></td><td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" 
                      ValidationGroup="login" ControlToValidate="Password" runat="server" 
                      ErrorMessage="密码不能为空!" Font-Size="15px"></asp:RequiredFieldValidator></td></tr>
      <tr><td style="font-size: 15px;color: #FFFFFF;  font-weight:bold;">验证码：</td><td>
           <asp:TextBox ID="TextBox1" runat="server" Width="191px"></asp:TextBox></td><td>
              <img src="Admin/CreateImage.aspx" height="20px" width="80px" align="left" alt="验证码"/></td></tr>
       <tr><td></td><td align="center">
           <asp:Button ID="Button1" runat="server" 
               ValidationGroup="login" Text="登 &nbsp;陆" onclick="Button1_Click" Height="35px" 
               Width="77px" Font-Size="15px" /></td><td></td></tr>
     </table>
       <br/>
        </form>
    </div>
    </div>
    

</body>
</html>
