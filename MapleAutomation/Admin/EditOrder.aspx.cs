using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.Admin
{
    public partial class EditOrder : System.Web.UI.Page
    {
        string OrderId { get; set; }
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Roles"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string roles = Session["Roles"].ToString();

                if (roles == "Order")
                {
                    
                }
                else if (roles == "Product")
                {
                    Response.Redirect("Login.aspx");
                }
                else if (roles == "Master")
                {
                    
                }

            }

            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                GridView1.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            StartDate.Text = Calendar1.SelectedDate.ToString("d");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            EndDate.Text = Calendar2.SelectedDate.ToString("d");
            Calendar2.Visible = false;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadStores();
        }

        protected void LoadStores()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Order] WHERE OrderDate BETWEEN '" + StartDate.Text + "' AND '" + EndDate.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No record found')</script>");
                    GridView1.Visible = false;
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadStores();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OrderId = GridView1.DataKeys[e.RowIndex].Values["OrderID"].ToString();
            TextBox UserName = (TextBox) GridView1.Rows[e.RowIndex].FindControl("TextBoxUserName");
            TextBox ProductID = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxProductId");
            TextBox EmailAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxEmail");
            TextBox MobileNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxMobile");
            TextBox Address = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxAddress");

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Order] SET UserName = @UserName, ProductID = @ProductID, EmailAddress = @EmailAddress, MobileNo = @MobileNo, Address = @Address, OrderDate = GETDATE() WHERE OrderID =" + OrderId, con);
            cmd.Parameters.AddWithValue("UserName", UserName.Text);
            cmd.Parameters.AddWithValue("ProductID", ProductID.Text);
            cmd.Parameters.AddWithValue("EmailAddress", EmailAddress.Text);
            cmd.Parameters.AddWithValue("MobileNo", MobileNo.Text);
            cmd.Parameters.AddWithValue("Address", Address.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = OrderId + "        Updated successfully........    ";
            GridView1.EditIndex = -1;
            LoadStores();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadStores();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string OrderID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OrderID"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + OrderID + "')");
                }
            }
        }
    }
}