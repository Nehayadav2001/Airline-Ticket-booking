<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="AirlineProject.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="\Content\registation.css" rel="stylesheet" type="text/css" />
     <script src="Scripts\register.js" type="text/javascript"> </script>

    <title></title>
</head>
<body>
   <form id="form1" runat="server" method="post">
    <div class="form-container">
        <h2 class="label">Registration form</h2>      
            <div>
                <div class="textbox">
                    <asp:label runat="server" for="txt_Name">Name:</asp:label>
                    <asp:TextBox type="text" id="txt_Name" runat="server" ToolTip="Name" />
                    <div id="error-messagename" style="color: red"></div>
                </div>
                <div class="textbox">
                    <asp:label runat="server" for="txt_user">Username:</asp:label>
                    <asp:TextBox type="text" id="txt_user" runat="server" ToolTip="Username" />
                    <div id="error-messageusername" style="color: red"></div>
                </div>
                <div class="textbox">
                    <asp:label runat="server" for="txt_Email">Email:</asp:label>
                    <asp:TextBox type="email" id="txt_Email" runat="server" ToolTip="Email" />
                     <span id="email_error" style="color: red;"></span>
                </div>
                <div class="textbox">
                    <asp:label runat="server" for="txt_mobile">Mobile:</asp:label>
                    <asp:TextBox type="text" id="txt_mobile" runat="server" ToolTip="mobile" />
                      <span id="mobile_error" style="color: red;"></span>
                </div>
                <div class="textbox">  
                    <asp:Label runat="server">Select Gender:</asp:Label> 
                    <asp:RadioButtonList ID="rd_gender" runat="server" name="genderg"> 
                    </asp:RadioButtonList>
                      <span id="gender_error" style="color: red;"></span>
                </div>
                <div class="textbox">
                    <asp:label runat="server" for="txt_pass">Password:</asp:label>
                    <asp:TextBox type="password" id="txt_pass" runat="server" tooltip="password" /> 
                    <span id="pass_error" style="color: red;"></span>
               </div>  
              <br/>
                
              
                <div class="button">
                   <asp:Button ID="btn_btn" runat="server" type="submit" Text="Registration" OnClick="btn_btn_Click" OnClientClick="return userValid()" />                   
                </div>

                <div class="links">
                   <a href="login.aspx">Already registered? Login here</a> 
                </div>         
            </div>
        </div>
     </form>
</body>
</html>
