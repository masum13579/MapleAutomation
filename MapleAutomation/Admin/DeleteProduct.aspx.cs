using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;

namespace MapleAutomation.Admin
{
    public partial class DeleteProduct : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    ByDate.Visible = false;
                    ByName.Visible = false;
                    ByCode.Visible = false;
                    Massage.Visible = false;
                }
            }
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

        //protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(cs);
        //    ProductID = gridView.DataKeys[e.RowIndex].Values["ProductID"].ToString();
        //    //File Delete start//
        //    using (SqlConnection con1 = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd1 = new SqlCommand("SELECT PDF1, PDF2, PDF3 FROM Product WHERE ProductID = @ProductID", con1);
        //        cmd1.Parameters.AddWithValue("ProductID", ProductID);

        //        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);

        //        try
        //        {
        //            string pdf1 = dt.Rows[0]["PDF1"].ToString();
        //            string pdf2 = dt.Rows[0]["PDF2"].ToString();
        //            string pdf3 = dt.Rows[0]["PDF3"].ToString();
        //            try
        //            {
        //                string path = Server.MapPath(pdf1);
        //                FileInfo fi = new FileInfo(path);
        //                fi.Delete();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //            try
        //            {
        //                string path1 = Server.MapPath(pdf2);
        //                FileInfo fi1 = new FileInfo(path1);
        //                fi1.Delete();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //            try
        //            {
        //                string path2 = Server.MapPath(pdf3);
        //                FileInfo fi2 = new FileInfo(path2);
        //                fi2.Delete();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }

        //    }
        //    //File delete End//
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("delete from Product where ProductID=" + ProductID, con);
        //    SqlCommand cmd2 = new SqlCommand("delete from CartProduct where ProductID=" + ProductID, con);
        //    cmd2.ExecuteNonQuery();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    if (result == 1)
        //    {
        //        LoadStores();
        //        lblmsg.BackColor = Color.Red;
        //        lblmsg.ForeColor = Color.White;
        //        lblmsg.Text = ProductID + "      Deleted successfully.......    ";
        //    }
        //}

        //protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string ProductID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ProductID"));
        //        Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
        //        if (lnkbtnresult != null)
        //        {
        //            lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ProductID + "')");
        //        }
        //    }
        //}

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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ProductID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ProductID"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ProductID + "')");
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ProductID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ProductID"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ProductID + "')");
                }
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ProductID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ProductID"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ProductID + "')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string productid = GridView1.DataKeys[e.RowIndex].Values["ProductID"].ToString();
            //File Delete start//
            using (SqlConnection con1 = new SqlConnection(cs))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT PDF1, PDF2, PDF3 FROM Product WHERE ProductID = @ProductID", con1);
                cmd1.Parameters.AddWithValue("ProductID", productid);

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                try
                {
                    string pdf1 = dt.Rows[0]["PDF1"].ToString();
                    string pdf2 = dt.Rows[0]["PDF2"].ToString();
                    string pdf3 = dt.Rows[0]["PDF3"].ToString();
                    try
                    {
                        string path = Server.MapPath(pdf1);
                        FileInfo fi = new FileInfo(path);
                        fi.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        string path1 = Server.MapPath(pdf2);
                        FileInfo fi1 = new FileInfo(path1);
                        fi1.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        string path2 = Server.MapPath(pdf3);
                        FileInfo fi2 = new FileInfo(path2);
                        fi2.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //File delete End//
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Product where ProductID=" + productid, con);
            SqlCommand cmd2 = new SqlCommand("delete from CartProduct where ProductID=" + productid, con);
            cmd2.ExecuteNonQuery();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                LoadStores();
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = ProductID + "      Deleted successfully.......    ";
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string productid = GridView2.DataKeys[e.RowIndex].Values["ProductID"].ToString();
            //File Delete start//
            using (SqlConnection con1 = new SqlConnection(cs))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT PDF1, PDF2, PDF3 FROM Product WHERE ProductID = @ProductID", con1);
                cmd1.Parameters.AddWithValue("ProductID", productid);

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                try
                {
                    string pdf1 = dt.Rows[0]["PDF1"].ToString();
                    string pdf2 = dt.Rows[0]["PDF2"].ToString();
                    string pdf3 = dt.Rows[0]["PDF3"].ToString();
                    try
                    {
                        string path = Server.MapPath(pdf1);
                        FileInfo fi = new FileInfo(path);
                        fi.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        string path1 = Server.MapPath(pdf2);
                        FileInfo fi1 = new FileInfo(path1);
                        fi1.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        string path2 = Server.MapPath(pdf3);
                        FileInfo fi2 = new FileInfo(path2);
                        fi2.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //File delete End//
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Product where ProductID=" + productid, con);
            SqlCommand cmd2 = new SqlCommand("delete from CartProduct where ProductID=" + productid, con);
            cmd2.ExecuteNonQuery();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                LoadStorByCatagory();
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = ProductID + "      Deleted successfully.......    ";
            }
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string productid = GridView3.DataKeys[e.RowIndex].Values["ProductID"].ToString();
            //File Delete start//
            using (SqlConnection con1 = new SqlConnection(cs))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT PDF1, PDF2, PDF3 FROM Product WHERE ProductID = @ProductID", con1);
                cmd1.Parameters.AddWithValue("ProductID", productid);

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                try
                {
                    string pdf1 = dt.Rows[0]["PDF1"].ToString();
                    string pdf2 = dt.Rows[0]["PDF2"].ToString();
                    string pdf3 = dt.Rows[0]["PDF3"].ToString();
                    try
                    {
                        string path = Server.MapPath(pdf1);
                        FileInfo fi = new FileInfo(path);
                        fi.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        string path1 = Server.MapPath(pdf2);
                        FileInfo fi1 = new FileInfo(path1);
                        fi1.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        string path2 = Server.MapPath(pdf3);
                        FileInfo fi2 = new FileInfo(path2);
                        fi2.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //File delete End//
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Product where ProductID=" + productid, con);
            SqlCommand cmd2 = new SqlCommand("delete from CartProduct where ProductID=" + productid, con);
            cmd2.ExecuteNonQuery();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                LoadStorByCode();
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = ProductID + "      Deleted successfully.......    ";
            }
        }
    }
}