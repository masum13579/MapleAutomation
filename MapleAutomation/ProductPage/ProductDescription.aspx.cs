using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.ProductPage
{
    public partial class ProductDescription : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

                string productid = Request.QueryString["ProductID"];
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT PDF1, PDF2, PDF3 FROM Product WHERE ProductID = @ProductID", con);
                    cmd.Parameters.AddWithValue("ProductID", productid);
 
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        sda.Fill(dt1);

                        string pdf2 = dt1.Rows[0]["PDF2"].ToString();
                        string pdf3 = dt1.Rows[0]["PDF3"].ToString();
                        string pdf1 = dt1.Rows[0]["PDF1"].ToString();

                    if (pdf1.Length > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("File", typeof(string));

                        FileInfo fi1 = new FileInfo(pdf1);
                        dt.Rows.Add(fi1.Name);

                        if (pdf2.Length > 0)
                            {
                                FileInfo fi2 = new FileInfo(pdf2);
                                dt.Rows.Add(fi2.Name);

                            if (pdf3.Length > 0)
                                {
                                    FileInfo fi3 = new FileInfo(pdf3);
                                    dt.Rows.Add(fi3.Name);
                                }
                            }

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                        
                }   
        }

        protected void BuyNow_OnClick(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/UserLogin.aspx");
            }
            else
            {
                string productid = Request.QueryString["ProductID"];
                Response.Redirect("~/ProductPage/SingleProductOrder.aspx?ProductID=" + productid);
            }
            
        }

        protected void AddToCart_OnClick(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/UserLogin.aspx");
            }
            else
            {
                string productid = "", userid = "";
                string UserID = "", UserName = "", ProductID = "", ProductName = "", Brand = "";

                try
                {
                    productid = Request.QueryString["ProductID"];
                    userid = Decrypt(Request.Cookies["UserID"].Value);
                }
                catch
                {

                }

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE UserID = @UserID", con);
                    cmd.Parameters.AddWithValue("UserID", userid);

                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Product WHERE ProductID = @ProductID", con);
                    cmd1.Parameters.AddWithValue("ProductID", productid);

                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        UserID = sdr["UserID"].ToString();
                        UserName = sdr["UserName"].ToString();
                    }
                    con.Close();

                    con.Open();
                    SqlDataReader sdr1 = cmd1.ExecuteReader();
                    while (sdr1.Read())
                    {
                        ProductID = sdr1["ProductID"].ToString();
                        ProductName = sdr1["ProductName"].ToString();
                        Brand = sdr1["Brand"].ToString();
                    }
                    con.Close();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO [dbo].[CartProduct] VALUES(@UserID, @UserName, @ProductID, @ProductName, @Brand)", con);
                    cmd2.Parameters.AddWithValue("UserID", UserID);
                    cmd2.Parameters.AddWithValue("UserName", UserName);
                    cmd2.Parameters.AddWithValue("ProductID", ProductID);
                    cmd2.Parameters.AddWithValue("ProductName", ProductName);
                    cmd2.Parameters.AddWithValue("Brand", Brand);

                    con.Open();
                    cmd2.ExecuteNonQuery();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Product added to Cart')</script>");
                }
            } 
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Content/Data/") + e.CommandArgument);
                Response.End();
            }
        }
    }
}