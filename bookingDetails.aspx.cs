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
    public partial class bookingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAllBookDetails();
        }
        private void getAllBookDetails()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter adr;
            DataTable dt = new DataTable();
            string conStr;

            try
            {
                conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("ny_getbookingdata", con))
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
                string message = "An error occurred while retrieving the booking details: " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }
    }
}