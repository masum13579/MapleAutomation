using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.Admin
{
    public partial class ViewProduct : System.Web.UI.Page
    {
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
                    Response.Redirect("Login.aspx");
                }
                else if (roles == "Product")
                {
                    
                }
                else if (roles == "Master")
                {

                }

            }

            if (!IsPostBack)
            {
                ByDate.Visible = false;
                ByName.Visible = false;
                ByCode.Visible = false;
                Massage.Visible = false;
            }
        }

        protected void ButtonClick_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "-1")
            {
                Massage.Visible = true;
                ByDate.Visible = false;
                ByName.Visible = false;
                ByCode.Visible = false;
                Massage.Text = "Please Select a Continent";
            }
            else if (DropDownList1.SelectedValue == "By Date")
            {
                ByDate.Visible = true;
                ByName.Visible = false;
                ByCode.Visible = false;
                Massage.Visible = false;
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                GridView1.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "By Name")
            {
                ByName.Visible = true;
                ByDate.Visible = false;
                ByCode.Visible = false;
                Massage.Visible = false;
                GridView2.Visible = false;
                LodaCatagory();
            }
            else if (DropDownList1.SelectedValue == "By Code")
            {
                ByCode.Visible = true;
                ByDate.Visible = false;
                ByName.Visible = false;
                Massage.Visible = false;
                TextBoxProCode.Text = null;
                GridView3.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadStores();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridView1.Visible = false;
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
            GridView1.Visible = false;
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

        protected void LoadStores()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE InsertDate BETWEEN '" + StartDate.Text + "' AND '" + EndDate.Text + "'", con);
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

        protected void LodaCatagory()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT CatagoryID, CatagoryName FROM ProductCatagory", con);
                con.Open();
                DropDownListCatagory.DataSource = cmd.ExecuteReader();
                DropDownListCatagory.DataTextField = "CatagoryName";
                DropDownListCatagory.DataValueField = "CatagoryID";
                DropDownListCatagory.DataBind();
                ListItem liCatagory = new ListItem("Select Product Catagory", "-1");
                DropDownListCatagory.Items.Insert(0, liCatagory);
            }
        }

        protected void DropDownListCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCatagory.SelectedValue != "-1")
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE CatagoryID = @CatagoryID", con);
                    cmd.Parameters.AddWithValue("CatagoryID", DropDownListCatagory.SelectedValue);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No record found')</script>");
                        GridView2.Visible = false;
                    }
                }
            }
            else
            {
                GridView2.Visible = false;
            }
        }

        protected void ButtonCode_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ProductCode = @ProductCode", con);
                cmd.Parameters.AddWithValue("ProductCode", TextBoxProCode.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                    GridView3.Visible = true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No record found')</script>");
                    GridView3.Visible = false;
                }
            }
        }
    }
}