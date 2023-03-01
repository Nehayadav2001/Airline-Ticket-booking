using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineProject
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetFlightDetails();


            }
        }
        private void GetFlightDetails()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter adr;
            DataTable dt = new DataTable();
            string conStr;

            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            using (con = new SqlConnection(conStr))
            {
                using (cmd = new SqlCommand("ny_flighgetdata", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    adr = new SqlDataAdapter(cmd);
                    //dt = new DataTable();
                    adr.Fill(dt);
                }
            }
            getdata.DataSource = dt;
            getdata.DataBind();
        }

        protected void getdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString);
            cmd = new SqlCommand("ny_deleteflights", con);
            cmd.CommandType = CommandType.StoredProcedure;
            var id = getdata.DataKeys[e.RowIndex].Value;

            cmd.Parameters.AddWithValue("flight_id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void getdata_RowEditing(object sender, GridViewEditEventArgs e)
        {
            getdata.EditIndex = e.NewEditIndex;
            GetFlightDetails();
        }

        protected void empgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            getdata.EditIndex = -1;
            GetFlightDetails();
        }

        protected void empgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection con;
            SqlCommand cmd;
            GridViewRow row = getdata.Rows[e.RowIndex];
            int flight_id = Convert.ToInt32(getdata.DataKeys[e.RowIndex].Values[0]);
            string flightNo = (row.FindControl("flight_no") as TextBox).Text;
           // string airlineName = (row.FindControl("flight_name") as TextBox).Text;
            //string departurecity = (row.FindControl("departure") as TextBox).Text;
           // string arrivalcity = (row.FindControl("arrival") as TextBox).Text;
            string depart_time = (row.FindControl("departure_time") as TextBox).Text;
           // string class_type = (row.FindControl("emp_type") as TextBox).Text;
            string price = (row.FindControl("price") as TextBox).Text;

            DropDownList designation = (DropDownList)getdata.Rows[e.RowIndex].FindControl("flight_name");
            string airlineName = designation.SelectedValue;

            DropDownList Experience = (DropDownList)getdata.Rows[e.RowIndex].FindControl("departure");
            string departurecity = Experience.SelectedValue;

            DropDownList arrival = (DropDownList)getdata.Rows[e.RowIndex].FindControl("arrival");
            string arrivalcity = arrival.SelectedValue;

            DropDownList class_type = (DropDownList)getdata.Rows[e.RowIndex].FindControl("class_type");
            string classty = class_type.SelectedValue;


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString);
            {
                using (cmd = new SqlCommand("ny_flightUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flight_id", flight_id);
                    cmd.Parameters.AddWithValue("@flight_no", flightNo);
                    cmd.Parameters.AddWithValue("@air_id", airlineName);
                    cmd.Parameters.AddWithValue("@depart_id", departurecity);
                    cmd.Parameters.AddWithValue("@arrival_id", arrivalcity);
                    cmd.Parameters.AddWithValue("@departure_time", depart_time);
                    cmd.Parameters.AddWithValue("@class_id", classty);
                    cmd.Parameters.AddWithValue("@price", price);



                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            getdata.EditIndex = -1;
            GetFlightDetails();

        }

        protected void Emp_dropdowns(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //For Airline Names
                if (this.getdata.EditIndex >= 0 && e.Row.RowIndex == this.getdata.EditIndex)
                {
                    var airline_name = e.Row.FindControl("flight_name") as DropDownList;
                    DataTable dt = GetDropDownAirline();
                    airline_name.DataSource = dt;
                    airline_name.DataTextField = "air_name";
                    airline_name.DataValueField = "air_id";
                    airline_name.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    airline_name.SelectedValue = dr["air_id"].ToString();

                }

                //For Departure city Names
                if (this.getdata.EditIndex >= 0 && e.Row.RowIndex == this.getdata.EditIndex)
                {
                    var depart_city = e.Row.FindControl("departure") as DropDownList;
                    DataTable dt = GetDepartureCity();
                    depart_city.DataSource = dt;
                    depart_city.DataTextField = "dcity_name";
                    depart_city.DataValueField = "depart_id";
                    depart_city.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    depart_city.SelectedValue = dr["depart_id"].ToString();

                }

                //For Arrival city Names
                if (this.getdata.EditIndex >= 0 && e.Row.RowIndex == this.getdata.EditIndex)
                {
                    var arrival_city = e.Row.FindControl("arrival") as DropDownList;
                    DataTable dt = GetArrivalCity();
                    arrival_city.DataSource = dt;
                    arrival_city.DataTextField = "acity_name";
                    arrival_city.DataValueField = "arrival_id";
                    arrival_city.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    arrival_city.SelectedValue = dr["arrival_id"].ToString();

                }

                //For Class Type Names
                if (this.getdata.EditIndex >= 0 && e.Row.RowIndex == this.getdata.EditIndex)
                {
                    var class_type = e.Row.FindControl("class_type") as DropDownList;
                    DataTable dt = GetClassType();
                    class_type.DataSource = dt;
                    class_type.DataTextField = "class_name";
                    class_type.DataValueField = "class_id";
                    class_type.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    class_type.SelectedValue = dr["class_id"].ToString();

                }
            }
        }

        private DataTable GetDropDownAirline()
        {
            SqlConnection con;
            SqlCommand cmd;
            string conStr;
            DataTable Experience;
            SqlDataAdapter adr;

            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            using (con = new SqlConnection(conStr))

            {
                using (cmd = new SqlCommand("ny_spgetAirline", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@air_name", "All");
                    adr = new SqlDataAdapter(cmd);
                    Experience = new DataTable();
                    adr.Fill(Experience);
                    return Experience;
                }
            }
        }

        private DataTable GetDepartureCity()
        {
            SqlConnection con;
            SqlCommand cmd;
            string conStr;
            DataTable Experience;
            SqlDataAdapter adr;

            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            using (con = new SqlConnection(conStr))

            {
                using (cmd = new SqlCommand("ny_getdeparture_airport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dcity_name", "All");
                    adr = new SqlDataAdapter(cmd);
                    Experience = new DataTable();
                    adr.Fill(Experience);
                    return Experience;
                }
            }
        }

        private DataTable GetArrivalCity()
        {
            SqlConnection con;
            SqlCommand cmd;
            string conStr;
            DataTable Experience;
            SqlDataAdapter adr;

            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            using (con = new SqlConnection(conStr))

            {
                using (cmd = new SqlCommand("ny_getarrival_airport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acity_name", "All");
                    adr = new SqlDataAdapter(cmd);
                    Experience = new DataTable();
                    adr.Fill(Experience);
                    return Experience;
                }
            }
        }

        private DataTable GetClassType()
        {
            SqlConnection con;
            SqlCommand cmd;
            string conStr;
            DataTable Experience;
            SqlDataAdapter adr;

            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            using (con = new SqlConnection(conStr))

            {
                using (cmd = new SqlCommand("ny_sp_spgetclass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@class_name", "All");
                    adr = new SqlDataAdapter(cmd);
                    Experience = new DataTable();
                    adr.Fill(Experience);
                    return Experience;
                }
            }
        }
    }
}