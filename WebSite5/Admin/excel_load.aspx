<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excel_load.aspx.cs" Inherits="Admin_excel_load" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
 body{font-size:13px;}
 td
 {
      border: 1px #2042eb solid;
      width:200px;
      height:25px;
  }
 </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="导出Excel" 
            onclick="Button1_Click" Height="30px" />&nbsp;<asp:DropDownList 
            ID="DropDownList1" runat="server" Height="25px" Width="160px">
            <asp:ListItem Value="0" Text="==选择区县==" ></asp:ListItem>
            <asp:ListItem Value="lqy" Text="龙泉驿"></asp:ListItem>
            <asp:ListItem Value="sl" Text="双流"></asp:ListItem>
            <asp:ListItem Value="jt" Text="金堂"></asp:ListItem>
            <asp:ListItem Value="qbj" Text="青白江"></asp:ListItem>
            <asp:ListItem Value="xj" Text="新津"></asp:ListItem>
            </asp:DropDownList>&nbsp;<asp:Button ID="Button2" runat="server" Text="查看" 
            onclick="Button2_Click" Height="30px" Width="73px" />&nbsp;<asp:Button 
            ID="Button3" runat="server" 
            Text="导出Excel" Visible="false" oncommand="Button3_Command" Height="30px" />
    <br />
    <asp:label ID="Label1" runat="server" text=""></asp:label>
    </div>
    </form>
</body>

</html>
