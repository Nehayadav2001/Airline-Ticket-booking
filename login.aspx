<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AirlineProject.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="\Content\login.css" />
    <title>Login page</title>
</head>
<body>
   <form id="form1" runat="server">
		<div class="login-box">
			<h1>User Login</h1>
			<div class="textbox">
				<i class="fas fa-user"></i>
				<asp:TextBox ID="txt_user" runat="server" placeholder="Username"></asp:TextBox>
			</div>
			<div class="textbox">
				<i class="fas fa-lock"></i>
				<asp:TextBox ID="txt_pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
			</div>
			<asp:Button ID="btn_btn1" runat="server" type="submit" Text="Login" CssClass="btn" OnClick="btn_btn1_Click" />
			<div class="links">
				<a href="registration.aspx">New User? Register Here</a>
				<a href="adminlogin.aspx">Admin Login</a>
			</div>
			<div align="center">
				<asp:Label ID="Label" runat="server" Text="" Visible="false" Width="316px" ForeColor="Red"></asp:Label>
			</div>
		</div>
	</form>
</body>
</html>
