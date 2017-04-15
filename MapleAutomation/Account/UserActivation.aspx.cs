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
    public partial class UserActivation : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString.Keys[0] == "Email")
                {
                    string Email = Request.QueryString["Email"].ToString();
                    string QuerryAcctivate = "Update UserData set Activated = 'true' where Email = '" + Email + "'";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(QuerryAcctivate,con);
                        int no = cmd.ExecuteNonQuery();
                        if (no > 0)
                        {
                            Response.Write("Account Acctivated Sucessfully");
                        }
                        else
                        {
                            Response.Write("Sorry unable to Acctivated");
                        }
                    }
                }
            }
        }
    }
}