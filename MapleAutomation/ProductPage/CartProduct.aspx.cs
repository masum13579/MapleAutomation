using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    public partial class CartProduct : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        int Result { get; set; }

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
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/UserLogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadData();
                } 
            }
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                int userid = Convert.ToInt32(Decrypt(Request.Cookies["UserID"].Value));
                SqlCommand cmd = new SqlCommand(@"SELECT CartProduct.CartID, CartProduct.ProductName, CartProduct.Brand, Product.BrandImage FROM CartProduct INNER JOIN Product ON CartProduct.ProductID = Product.ProductID
WHERE CartProduct.UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                GridView1.DataSource = sdr;
                GridView1.DataBind();
            }
        }

        protected void ImageButtonPlaceOrder_Click(object sender, ImageClickEventArgs e)
        {
            int userid = Convert.ToInt32(Decrypt(Request.Cookies["UserID"].Value));

            if (userid > 0)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ProductID FROM CartProduct WHERE UserID = @UserID", con);
                    cmd.Parameters.AddWithValue("@UserID", userid);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    Result = sda.Fill(dt);

                    if (Result > 0)
                    {
                        string[] test = new string[Result];

                        for (int i = 0; i < Result; i++)
                        {
                            test[i] = dt.Rows[i][0].ToString();
                        }
                        string productid = string.Join(",", test);
                        Response.Redirect("~/ProductPage/OrderSummary.aspx?ProductID=" + productid);
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cartId = GridView1.DataKeys[e.RowIndex].Values["CartID"].ToString();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("delete from CartProduct where CartID=" + cartId, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
        }
    }
}