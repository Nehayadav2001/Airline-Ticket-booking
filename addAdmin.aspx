<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addAdmin.aspx.cs" Inherits="AirlineProject.addAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="\Content\flightAdd.css" />
     <script src="Scripts\addFlight.js" type="text/javascript"> </script>
    <title></title>
</head>
<body> 
    <div id="header">
		<h1>Admin Dashboard</h1>
		<nav>
			<ul>
				<li><a href="admin.aspx">Home</a></li>
                <li><a href="addAdmin.aspx">addFlight</a></li>
				<li><a href="bookingDetails.aspx">Bookings</a></li>				
                <li><a href="login.aspx">log Out</a></li>
			</ul>
		</nav>
	</div>
    <div class="form-container">
    <h2 class="label">Add New Flight Details</h2>
    <form id="form1" runat="server" method="post">
        <div>
            <div>
            <div>  
                <asp:Label runat="server">Flight-No: </asp:Label>  
                <asp:TextBox ID="txt_flight" runat="server" ToolTip="Name"></asp:TextBox>  
                 <div id="error-messageflight" style="color: red"></div>
            </div>  
              <br/>
              <div>  
                  <asp:Label runat="server">Airline Name: </asp:Label>                 
                <asp:DropDownList ID="drp_arline" runat="server" AppendDataBoundItems="true">   
                    <asp:ListItem Value="0">Select </asp:ListItem></asp:DropDownList>
                   <div id="error-messageAir" style="color: red"></div>
                   <asp:Label ID="error_airname" runat="server" Text="" Style="color: red;"></asp:Label>
              </div>  
              <br/>
            <div>  
                <asp:Label ID="Label3" runat="server" Text="From" Width="112px" ></asp:Label>
                    <asp:DropDownList ID="drp_from" runat="server" AppendDataBoundItems="true">   
                    <asp:ListItem Value="0">Select </asp:ListItem></asp:DropDownList>
                    <div id="error-messagedepart" style="color: red"></div>
                 <asp:Label ID="error_from" runat="server" Text="" Style="color: red;"></asp:Label>
               <br/>
            </div>
            <div>  
                <asp:Label runat="server" Text="Destination" Width="90px" ></asp:Label>
                <asp:DropDownList ID="drp_arrival" runat="server" AppendDataBoundItems="true">   
                    <asp:ListItem Value="0">Select </asp:ListItem></asp:DropDownList>  
                    <div id="error-messageArrival" style="color: red"></div>
                <asp:Label ID="error_Arrival" runat="server" Text="" Style="color: red;"></asp:Label>
            </div>
                 <br/><br/>
            <div>  
                <asp:Label runat="server">Date: </asp:Label>  
                <asp:TextBox ID="date_date" type="date" runat="server" ToolTip="Name"></asp:TextBox>    
                <span id="date_error" style="color: red;"></span>
            </div> 
              <br/><br/>
            <div class="class">
                 <asp:Label runat="server">Class </asp:Label>  
				    <asp:DropDownList ID="drp_class" runat="server" AppendDataBoundItems="true">
				    <asp:ListItem Value="0">Select </asp:ListItem></asp:DropDownList>
                <div id="error-messageClass" style="color: red"></div>
                <asp:Label ID="class_errortry" runat="server" Text="" Style="color: red;"></asp:Label>
		   </div>
            <br/><br/>
           <div>  
                <asp:Label runat="server">Price $: </asp:Label>  
                <asp:TextBox ID="txt_prc" runat="server" ToolTip="Name"></asp:TextBox>  
               <span id="price_error" style="color: red;"></span>
            </div>
        
                 <br/> <br/>
              <div class="button">
                  <asp:Button ID="btn_btn" runat="server" type="submit" Text="submit" CssClass="success" OnClick="btn_btn_Click" OnClientClick="return userValid()" /> 
                    <asp:Button ID="btn_reset" runat="server" Text="Cancel" OnClientClick="form1.reset(); return false;" />
             </div>
            </div>
        </div>
    </form>
</div>
</body>
</html>
