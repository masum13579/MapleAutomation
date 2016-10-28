using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.Account
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM UserData", con);
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            if (sdr[3].ToString().Equals(UserName.Text) && sdr[4].ToString().Equals(Password.Text))
                            {
                                Response.Cookies["UserName"].Value = sdr[3].ToString();
                                Response.Cookies["UserID"].Value = sdr[0].ToString();
                                Session["Role"] = sdr[5].ToString();
                                FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
                                Response.Redirect("~/Default.aspx");
                            }
                            else
                            {
                                ErrorMassage.Text = "username and password are invalid";
                            }
                        }
                    }
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Error";
            }
        }
    }
}