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
    public partial class addAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                {
                    getdepartureCity();
                    getArrivalCity();
                    getAirline();
                    getClass();
                   

                }

            }
        }

        public void getClass()
        {
            try
            {
                SqlConnection con;
                SqlCommand cmd;
                SqlDataAdapter adr;
                DataTable dt;
                string conStr;

                conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_sp_spgetclass", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@class_name", "All");
                        adr = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        adr.Fill(dt);
                    }
                }

                drp_class.DataSource = dt;
                drp_class.DataTextField = "class_name";
                drp_class.DataValueField = "class_id";
                drp_class.DataBind();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                class_errortry.Text = "An error occurred while retrieving Class Type Data. Please try again later.";
            }

        }

        public void getdepartureCity()
        {
            try
            {

                SqlConnection con;
                SqlCommand cmd;
                SqlDataAdapter adr;
                DataTable dt;
                string conStr;

                conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_getdeparture_airport", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@dcity_name", "All");
                        adr = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        adr.Fill(dt);
                    }
                }

                drp_from.DataSource = dt;
                drp_from.DataTextField = "dcity_name";
                drp_from.DataValueField = "depart_id";
                drp_from.DataBind();

            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                error_from.Text = "An error occurred while retrieving Departure City. Please try again later.";
            }
        }

        public void getArrivalCity()
        {
            try { 

                SqlConnection con;
                SqlCommand cmd;
                SqlDataAdapter adr;
                DataTable dt;
                string conStr;

                conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_getarrival_airport", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@acity_name", "All");
                        adr = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        adr.Fill(dt);
                    }
                }

                drp_arrival.DataSource = dt;
                drp_arrival.DataTextField = "acity_name";
                drp_arrival.DataValueField = "arrival_id";
                drp_arrival.DataBind();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                error_from.Text = "An error occurred while retrieving Arrival City. Please try again later.";
            }

        }

        public void getAirline()
        {
            try
            {
                SqlConnection con;
                SqlCommand cmd;
                SqlDataAdapter adr;
                DataTable dt;
                string conStr;

                conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_spgetAirline", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@air_name", "All");
                        adr = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        adr.Fill(dt);
                    }
                }

                drp_arline.DataSource = dt;
                drp_arline.DataTextField = "air_name";
                drp_arline.DataValueField = "air_id";
                drp_arline.DataBind();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                error_Arrival.Text = "An error occurred while retrieving Arrival City. Please try again later.";
            }

        }

        protected void btn_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con;
                SqlCommand cmd = new SqlCommand();


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString);
                cmd = new SqlCommand("neha_saveflights", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@flight_no", SqlDbType.VarChar).Value = txt_flight.Text;
                cmd.Parameters.Add("@air_id", SqlDbType.VarChar).Value = drp_arline.Text;
                cmd.Parameters.Add("@depart_id", SqlDbType.VarChar).Value = drp_from.Text;
                cmd.Parameters.Add("@arrival_id", SqlDbType.VarChar).Value = drp_arrival.Text;
                cmd.Parameters.Add("@departure_time", SqlDbType.VarChar).Value = date_date.Text;
                cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = drp_class.Text;
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = txt_prc.Text;

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    string script = "alert('Flight data saved successfully.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Saved", script, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                string script = "alert('An error occurred while saving the Flight information. Please try again later.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
            }
        }
    }
}