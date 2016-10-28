using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.Account
{
    public partial class Registration : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string role = "User";
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT UserName FROM UserData WHERE UserName = @UserName",con);
                    cmd1.Parameters.AddWithValue("UserName", UserName.Text);
                    con.Open();
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        ErrorMassage.Text = "UserName already taken";
                        UserName.Text = null;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        SqlCommand cmd = new SqlCommand("INSERT INTO UserData VALUES(@FirstName, @LastName, @UserName, @Password, @Role, @Address, @MobileNo, @Email, GETDATE())",con);
                        cmd.Parameters.AddWithValue("FirstName", FirstName.Text);
                        cmd.Parameters.AddWithValue("LastName", LastName.Text);
                        cmd.Parameters.AddWithValue("UserName", UserName.Text);
                        cmd.Parameters.AddWithValue("Password", TextBoxPassword.Text);
                        cmd.Parameters.AddWithValue("Role", role);
                        cmd.Parameters.AddWithValue("Address", textArea.Text);
                        cmd.Parameters.AddWithValue("MobileNo", TextBoxPhone.Text);
                        cmd.Parameters.AddWithValue("Email", Email.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/Account/UserLogin.aspx");
                    }
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}