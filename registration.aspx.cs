using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;


namespace AirlineProject
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getgender();
            }
        }

        public void getgender()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Select * from brj_gender_master", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                rd_gender.DataSource = dt;
                rd_gender.DataTextField = "gen_name";
                rd_gender.DataValueField = "gen_mas_id";
                rd_gender.DataBind();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                gender_errortry.Text = "An error occurred while retrieving gender Data. Please try again later.";
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
                cmd = new SqlCommand("neha_save_spcutomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txt_Name.Text;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txt_user.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txt_Email.Text;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = txt_mobile.Text;
                cmd.Parameters.Add("@gen_mas_id", SqlDbType.VarChar).Value = rd_gender.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txt_pass.Text;

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    string script = "alert('Registration done succesfully');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Saved", script, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: " + ex.ToString();
                string script = "alert('An error occurred while saving the Registor information. Please try again later.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
            }
        }

    }
}