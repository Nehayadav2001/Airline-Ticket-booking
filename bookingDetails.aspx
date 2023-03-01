<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookingDetails.aspx.cs" Inherits="AirlineProject.bookingDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
	<link href="\Content\bookingDetails.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
	<div id="header">
		<h1>Admin Dashboard</h1>
		<nav>
			<ul>
				<li><a href="admin.aspx">Home</a></li>
                <li><a href="addAdmin.aspx">addFlight</a></li>
				<li><a href="#">Bookings</a></li>				
                <li><a href="login.aspx">log Out</a></li>
			</ul>
		</nav>
	</div>
	<div id="content">
		
	</div>

	<h3>All booking Detials </h3>
	<div>
	<form id="form" runat="server">
     <div>
         <br/><br/>
          <div style="text-align:center">
         <asp:GridView class="grid-container" ID="getdata" runat="server" AutoGenerateColumns="false"
             BorderWidth="3px" RowStyle-Height="40px" HeaderStyle-CssClass="headerrow" HeaderStyle-Height="50px" DataKeyNames="flight_id">
         <Columns>
             <asp:TemplateField HeaderText = "SR. No" ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Flight-Id">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("flight_id") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="flight_name" Text='<%# Bind("flight_id") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Passanger Name">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="departure" Text='<%# Bind("name") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Email-Id">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("email") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="arrival" Text='<%# Bind("email") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>
 
             <asp:TemplateField HeaderText="Mobile No">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" type="date" ID="departure" Text='<%# Bind("mobile") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

            
             <asp:TemplateField HeaderText="Nationality">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="class_type" Text='<%# Eval("nation") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>                       
                     <asp:TextBox runat="server" type="date" ID="class_id" Text='<%# Bind("nation") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="Flight No">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("flight_no") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="flight_no" Text='<%# Bind("flight_no") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Airline Name">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("air_name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                      <asp:DropDownList  ID="flight_name"  runat="server" DataTextField="air_name" 
                        DataValueField="air_id"></asp:DropDownList> 
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="departure_airport">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("dcity_name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:DropDownList  ID="departure"  runat="server" DataTextField="dcity_name" 
                        DataValueField="depart_id"></asp:DropDownList>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="arrival_airport">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("acity_name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:DropDownList  ID="arrival"  runat="server" DataTextField="acity_name" 
                        DataValueField="arrival_id"></asp:DropDownList>
                 </EditItemTemplate>
             </asp:TemplateField>
 
             <asp:TemplateField HeaderText="departure_time">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("departure_time","{0:d}") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" type="date" ID="departure_time" Text='<%# Bind("departure_time") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

            
             <asp:TemplateField HeaderText="Class Type">
                 <ItemTemplate>
                     <asp:Label runat="server" ID="class_type" Text='<%# Eval("class_name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                      <asp:DropDownList  ID="emp_type"  runat="server" DataTextField="class_name" 
                        DataValueField="class_id"></asp:DropDownList>                     
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="price">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("price") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="price" Text='<%# Bind("price") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>
      
           
             <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="remove Record"/>
             <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-warning" HeaderText="Edit Record" />              

         </Columns>
        </asp:GridView>
               </div>
     </div>
    </form> 
	</div>
    <br/>  <br/>  <br/>

</body>
</html>
