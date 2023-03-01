<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="AirlineProject.adminlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="\Content\adminlogin.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<div class="login-box">
			<h1>Admin Login</h1>
			<div class="textbox">
				<i class="fas fa-user"></i>
				<asp:TextBox ID="txt_user" runat="server" placeholder="Username"></asp:TextBox>
			</div>
			<div class="textbox">
				<i class="fas fa-lock"></i>
				<asp:TextBox ID="txt_pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
			</div>
			<asp:Button ID="btn_btn1" runat="server" type="submit" Text="Login" CssClass="btn" />
			<div class="links">				
				<a href="admin.aspx">Admin Page</a>
			</div>
			<div align="center">
				<asp:Label ID="Label" runat="server" Text="" Visible="false" Width="316px" ForeColor="Red"></asp:Label>
			</div>
		</div>
	</form>
</body>
</html>
