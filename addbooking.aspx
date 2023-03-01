<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addbooking.aspx.cs" Inherits="AirlineProject.addbooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
	<link rel="stylesheet" href="\Content\addbooking.css" />
    <script src="Scripts\addboking.js" type="text/javascript"> </script>
    <title></title>
</head>
<body>
    <div>
     <div id="header">
		<h1>Book Your Seat</h1>
		<nav>
			<ul>
				<li><a href="home.aspx">Home</a></li>
				<li><a href="booking.aspx">Bookings</a></li>			
                <li><a href="login.aspx">log Out</a></li>
			</ul>
		</nav>
	</div>
          <br/> 

    <form class="formid" runat="server" method="post">
        <h2 class="h2pass">Passenger Information</h2>
        <asp:FormView ID="FormView1" runat="server" method="post" >
            <ItemTemplate>
                <div class="row">
                    <div class="col">
                        <asp:label runat="server" for="txt_Name">Full Name:</asp:label>
                        <asp:TextBox runat="server" type="text" id="txt_Name" name="txt_Name" class="form-control" placeholder="Enter your full name" />
                        <div id="error-messagename" style="color: red"></div>
                    </div>
                    <div class="col">
                        <asp:label runat="server" for="txt_Email">Email:</asp:label>
                        <asp:TextBox runat="server" type="email" id="txt_Email" name="txt_Email" class="form-control" placeholder="Enter your email" />
                        <span id="email_error" style="color: red;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:label  runat="server" for="txt_mobile">Mobile:</asp:label>
                        <asp:TextBox runat="server" type="tel" id="txt_mobile" name="txt_mobile" class="form-control" placeholder="Enter your mobile number" />
                        <span id="mobile_error" style="color: red;"></span>
                    </div>
                    <div class="col">
                        <asp:label runat="server" for="txt_nation">Nationality:</asp:label>
                        <asp:TextBox runat="server" type="text" id="txt_nation" name="txt_nation" class="form-control" placeholder="Enter your nationality" />
                        <div id="error-messagenation" style="color: red"></div>
                    </div>
              </div>
                <div class="row">
                    <div class="col">
                        <asp:label runat="server" for="Label1">Flight Number:</asp:label>
                        <input type="text" id="Label1" name="Label1" class="form-control" value='<%# Eval("flight_no") %>' readonly="true"  />
                    </div>
                    <div class="col">
                        <asp:label runat="server" for="Label2">Airline Name:</asp:label>
                        <input type="text" id="Label2" name="Label2" class="form-control" value='<%# Eval("air_name") %>' readonly="true" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:label runat="server" for="Label3">From:</asp:label>
                        <input type="text" id="Label3" name="Label3" class="form-control" value='<%# Eval("dcity_name") %>' readonly="true" />
                    </div>
                    <div class="col">
                        <asp:label runat="server" for="Label4">To:</asp:label>
                        <input type="text" id="Label4" name="Label4" class="form-control" value='<%# Eval("acity_name") %>' readonly="true" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:label runat="server" for="Label5">Date:</asp:label>
                        <input type="text" id="Label5" name="Label5" class="form-control" value='<%# Eval("departure_time") %>' readonly="true" />
                    </div>
                    <div class="col">
                        <asp:label runat="server" for="Label6">Class Type:</asp:label>
                        <input type="text" id="Label6" name="Label6" class="form-control" value='<%# Eval("class_name") %>' readonly="true" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:label runat="server" for="Label7">Price:</asp:label>
                        <input type="text" id="Label7" name="Label7" class="form-control" value='<%# Eval("price") %>' readonly="true" />
                    </div>
                </div>              
                 <div>
                      <asp:Button ID="btn_btn" CssClass="btn-submit" runat="server" Text="Confirm Booking" OnClick="btn_btn_Click1" OnClientClick="return bookingValid()" /> 
                 </div>
            </ItemTemplate>         
        </asp:FormView>
        
    </form>
   </div>
  </body>
</html>