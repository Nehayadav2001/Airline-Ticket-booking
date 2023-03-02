using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices.CompensatingResourceManager;
using Microsoft.Ajax.Utilities;
using System.Web.Services.Description;

namespace AirlineProject
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetFlightDetails();
                getdepartureCity();
                getArrivalCity();

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
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_flighgetdata", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        adr = new SqlDataAdapter(cmd);
                        adr.Fill(dt);
                    }
                }

                getdata.DataSource = dt;
                getdata.DataBind();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                string script = "alert('An error occurred while retrieving flight details. Please try again later.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }


        private void BindGrid()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter adr;
            DataTable dt = new DataTable();
            string conStr;

            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_flighgetdataSearch", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@depart_id", drp_from.Text.Trim());
                        cmd.Parameters.AddWithValue("@arrival_id", drp_arrival.Text.Trim());
                        cmd.Parameters.AddWithValue("@departure_time", txtSearch3.Text.Trim());

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            adr = new SqlDataAdapter(cmd);
                            adr.Fill(dt);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        getdata.DataSource = dt;
                        getdata.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NoData", "alert('No flight data found for the selected search criteria.')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An error occurred while retrieving flight Search Data. Please try again later.')", true);
            }
        }

        protected void OnRow_Commands(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    string id = Convert.ToString(e.CommandArgument.ToString());
                    Response.Redirect("addbooking.aspx?flight_id=" + id);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An error occurred while retrieving Selected flight. Please try again later.')", true);

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            getdata.PageIndex = e.NewPageIndex;
            getdata.DataBind();
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An error occurred while retrieving Deaprture City. Please try again later.')", true);

            }


        }

        public void getArrivalCity()
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An error occurred while retrieving Arrival City. Please try again later.')", true);

            }

        }

    }
}


