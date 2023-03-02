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
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        protected void btn_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con;
                SqlCommand cmd;
                string conStr;

                conStr = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
                using (con = new SqlConnection(conStr))
                {
                    using (cmd = new SqlCommand("my_Checkadmin", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p1 = new SqlParameter("username", txt_user.Text);
                        SqlParameter p2 = new SqlParameter("password", txt_pass.Text);
                        cmd.Parameters.Add(p1);
                        cmd.Parameters.Add(p2);
                        con.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            rd.Read();
                            Response.Redirect("admin.aspx");
                        }
                        else
                        {
                            txt_wrongpass.Text = "Invalid username or password.";
                            txt_wrongpass.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                errorMessage_login.Visible = true;
                errorMessage_login.Text = "An error occurred while login In Website.Please try again later.";
            }
        }
    }
}