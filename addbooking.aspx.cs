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
    public partial class addbooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["flight_id"] != null)
                {
                    var id = Request.QueryString["flight_id"];                
                    FormView1.DataSource = GetFlightDetails();
                    FormView1.DataBind();
                }
            }
        }


        private DataTable GetFlightDetails()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter adr;
            DataTable dt = new DataTable();
            string conStr;

            var id = Request.QueryString["flight_id"];
            conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_flightbook", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@flight_id", id);
                        adr = new SqlDataAdapter(cmd);
                        adr.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An error occurred while retrieving flight booking data. Please try again later.')", true);
            }
            return dt;
        }

        protected void btn_btn_Click1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt_Name = (TextBox)FormView1.FindControl("txt_Name");
                TextBox txt_Email = (TextBox)FormView1.FindControl("txt_Email");
                TextBox txt_mobile = (TextBox)FormView1.FindControl("txt_mobile");
                TextBox txt_nation = (TextBox)FormView1.FindControl("txt_nation");

                DataSet ds = new DataSet();
                SqlConnection con;
                SqlCommand cmd = new SqlCommand();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString);
                cmd = new SqlCommand("neha_spbooking", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string flight_id = Request.QueryString["flight_id"];
                cmd.Parameters.Add("@flight_id", SqlDbType.VarChar).Value = flight_id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txt_Name.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txt_Email.Text;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = txt_mobile.Text;
                cmd.Parameters.Add("@nation", SqlDbType.VarChar).Value = txt_nation.Text;

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    string script = "alert('Your Airline Ticket has been successfully Booked.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Saved", script, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                string script = "alert('An error occurred while booking your ticket. Please try again later.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
            }
        }
    }
}