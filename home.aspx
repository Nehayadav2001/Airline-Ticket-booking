<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AirlineProject.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
		<link href="\Content\home.css" rel="stylesheet" type="text/css" />
			
    <title>Home page</title>
</head>
<body>
<div class="container">
		<header class="header">
			<div class="logo">
				<img src="\assest\img\logo.png" alt="Airline Booking Logo" />
			</div>
			<nav class="nav">
				<a href="#">Home</a>
				<a href="booking.aspx">Flights</a>
				<a href="#">About Us</a>
				<a href="#">Contact</a>
				<a href="login.aspx">log out</a>
			</nav>
		</header>
		<section class="hero">
			<h1>Welcome to Airline Booking</h1>
			<p>Book your flights with ease.</p>
			<a href="booking.aspx" class="btn">Book Now</a>
		</section>
		<section class="featured">
			<div class="featured-image">
				<img src="\assest\img\banner1.jpg" alt="Destination 1" />
			</div>
			<div class="featured-content">
				<h2>    Destination 1</h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla laoreet velit ac nisl pulvinar hendrerit.</p>
				<a href="#" class="btn">Learn More</a>
			</div>
		</section>
		<section class="featured">
			<div class="featured-content">
				<h2> Destination 2</h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla laoreet velit ac nisl pulvinar hendrerit.</p>
				<a href="#" class="btn">Learn More</a>
			</div>
			<div class="featured-image">
				<img src="\assest\img\g4.jpg" alt="Featured Destination 2" />
			</div>
		</section>
	</div>
	<footer class="footer">
		<p>&copy; 2023 Airline Booking. All rights reserved.</p>
		<ul>
			<li><a href="#">Home</a></li>
			<li><a href="#">Flights</a></li>
			<li><a href="#">About Us</a></li>
		</ul>
	</footer>
</body>
</html>
