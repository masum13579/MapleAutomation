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
    public partial class EditProduct : System.Web.UI.Page
    {
        string ProductID { get; set; }
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
                LoadStorByCatagory();
            }
            else
            {
                GridView2.Visible = false;
            }
        }

        protected void LoadStorByCatagory()
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

        protected void ButtonCode_Click(object sender, EventArgs e)
        {
            LoadStorByCode();
        }

        protected void LoadStorByCode()
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadStores();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadStores();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ProductID = GridView1.DataKeys[e.RowIndex].Values["ProductID"].ToString();
            TextBox ProductName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox ProductCode = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox Stock = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4");

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Product SET ProductName = @ProductName, ProductCode = @ProductCode, Stock = @Stock WHERE ProductID =" + ProductID, con);
            cmd.Parameters.AddWithValue("ProductName", ProductName.Text);
            cmd.Parameters.AddWithValue("ProductCode", ProductCode.Text);
            cmd.Parameters.AddWithValue("Stock", Stock.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Visible = true;
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = ProductID + "        Updated successfully........    ";
            GridView1.EditIndex = -1;
            LoadStores();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            LoadStorByCatagory();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            LoadStorByCatagory();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string productid = GridView2.DataKeys[e.RowIndex].Values["ProductID"].ToString();
            TextBox ProductName = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox ProductCode = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox Stock = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox6");

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Product SET ProductName = @ProductName, ProductCode = @ProductCode, Stock = @Stock WHERE ProductID =" + productid, con);
            cmd.Parameters.AddWithValue("ProductName", ProductName.Text);
            cmd.Parameters.AddWithValue("ProductCode", ProductCode.Text);
            cmd.Parameters.AddWithValue("Stock", Stock.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Labelmassage.Visible = true;
            Labelmassage.BackColor = Color.Blue;
            Labelmassage.ForeColor = Color.White;
            Labelmassage.Text = productid + "        Updated successfully........    ";
            GridView2.EditIndex = -1;
            LoadStorByCatagory();
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            LoadStorByCode();
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            LoadStorByCode();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string productid = GridView3.DataKeys[e.RowIndex].Values["ProductID"].ToString();
            TextBox ProductName = (TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox ProductCode = (TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox Stock = (TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBox6");

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Product SET ProductName = @ProductName, ProductCode = @ProductCode, Stock = @Stock WHERE ProductID =" + productid, con);
            cmd.Parameters.AddWithValue("ProductName", ProductName.Text);
            cmd.Parameters.AddWithValue("ProductCode", ProductCode.Text);
            cmd.Parameters.AddWithValue("Stock", Stock.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            LblMassage.Visible = true;
            LblMassage.BackColor = Color.Blue;
            LblMassage.ForeColor = Color.White;
            LblMassage.Text = productid + "        Updated successfully........    ";
            GridView3.EditIndex = -1;
            LoadStorByCode();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
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
                lblmsg.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "By Name")
            {
                ByName.Visible = true;
                ByDate.Visible = false;
                ByCode.Visible = false;
                Massage.Visible = false;
                GridView2.Visible = false;
                Labelmassage.Visible = false;
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
                LblMassage.Visible = false;
            }
        }
    }
}