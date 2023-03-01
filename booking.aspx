<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="AirlineProject.booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
	<link rel="stylesheet" href="\Content\booking.css" />
    <title>booking page</title>
</head>
<body>
      <div>
     <div id="header">
		<h1>Book Your Destination</h1>
		<nav>
			<ul>
				<li><a href="home.aspx">Home</a></li>
				<li><a href="#">Bookings</a></li>			
                <li><a href="login.aspx">log Out</a></li>
			</ul>
		</nav>
	</div>
          <br/> 
	<div>
	<form id="form" runat="server">
             <div>                
                 <div class="search_form">
                    <asp:Label ID="city_from" Text="From" runat="server" />
                    <asp:DropDownList ID="drp_from" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="Label1" Text="To" runat="server" />
                    <asp:DropDownList ID="drp_arrival" Width="150px" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="Label2" Text="Date" Width="150px" runat="server" />
                    <asp:TextBox ID="txtSearch3" type="date" runat="server" />

                    <asp:Button Text="Search" CssClass="btn-style" runat="server" OnClick="btn_Click" />
               </div>
         <br/><br/> 
          <div style="text-align:center">
         <asp:GridView class="grid-container" ID="getdata" runat="server"
             AutoGenerateColumns="false" BorderWidth="3px" OnRowCommand="OnRow_Commands" DataKeyNames="flight_id"
             RowStyle-Height="50px" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" font-size="18px"
            AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
         <Columns>
             <asp:TemplateField  HeaderText = "SR. No" ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
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
                     <asp:TextBox runat="server" ID="flight_name" Text='<%# Bind("air_name") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="departure_airport">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("dcity_name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="departure" Text='<%# Bind("dcity_name") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="arrival_airport">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("acity_name") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" ID="arrival" Text='<%# Bind("acity_name") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="departure_time">
                 <ItemTemplate>
                     <asp:Label runat="server" Text='<%# Eval("departure_time","{0:d}") %>'></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox runat="server" type="date" ID="departure" Text='<%# Bind("departure_time") %>'></asp:TextBox>
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

             <asp:TemplateField HeaderText="Booking">
            <ItemTemplate>              
                <asp:Button ID="btnSelect" runat="server" cssClass="btn btn-success"  width="100px" Text="Book" CommandArgument='<%#Eval("flight_id")%>' CommandName = "Select" />
            </ItemTemplate>
        </asp:TemplateField>

         </Columns>
        </asp:GridView>
      </div>
     </div>
    </form> 
          
             
    </div>
		<footer>
			<p>&copy; 2023 Airline Booking</p>
		</footer>				
	</div>
</body>
</html>
