using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.Account
{
    public partial class EditProfile : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        string Role { get; set; }
        string UserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/UserLogin.aspx");
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE UserID = @UserID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                UserId = Request.Cookies["UserID"].Value;
                cmd.Parameters.AddWithValue("UserID", UserId);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!IsPostBack)
                {
                    if (dt.Rows.Count > 0)
                    {
                        FirstName.Text = dt.Rows[0]["FirstName"].ToString();
                        LastName.Text = dt.Rows[0]["LastName"].ToString();
                        UserName.Text = dt.Rows[0]["UserName"].ToString();
                        TextBoxPassword.Text = dt.Rows[0]["Password"].ToString();
                        Email.Text = dt.Rows[0]["Email"].ToString();
                        TextBoxPhone.Text = dt.Rows[0]["MobileNo"].ToString();
                        textArea.Text = dt.Rows[0]["Address"].ToString();
                    }
                }
                Role = dt.Rows[0]["Role"].ToString();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UserData] SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password, Role = @Role, Address = @Address, MobileNo = @MobileNo, Email = @Email WHERE (UserID = @UserID)", con);
                    cmd.Parameters.AddWithValue("FirstName", FirstName.Text);
                    cmd.Parameters.AddWithValue("LastName", LastName.Text);
                    cmd.Parameters.AddWithValue("UserName", UserName.Text);
                    cmd.Parameters.AddWithValue("Password", TextBoxPassword.Text);
                    cmd.Parameters.AddWithValue("Role", Role);
                    cmd.Parameters.AddWithValue("Address", textArea.Text);
                    cmd.Parameters.AddWithValue("MobileNo", TextBoxPhone.Text);
                    cmd.Parameters.AddWithValue("Email", Email.Text);
                    cmd.Parameters.AddWithValue("UserID", UserId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Account/EditProfile.aspx");
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}