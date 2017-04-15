﻿using System;
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
    public partial class SingleProductOrder : System.Web.UI.Page
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
            if (productid == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/UserLogin.aspx");
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE UserID = @UserID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                string id = Decrypt(Request.Cookies["UserID"].Value);
                cmd.Parameters.AddWithValue("UserID", id);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!IsPostBack)
                {
                    if (dt.Rows.Count > 0)
                    {
                        TextBoxName.Text = dt.Rows[0]["UserName"].ToString();
                        TextBoxEmail.Text = dt.Rows[0]["Email"].ToString();
                        TextBoxMoblieNo.Text = dt.Rows[0]["MobileNo"].ToString();
                        TextBoxAddress.Text = dt.Rows[0]["Address"].ToString();
                    }
                }
            }
        }

        protected void ButtonOrder_Click(object sender, EventArgs e)
        {
            string productid = Request.QueryString["ProductID"];
            string userid = Decrypt(Request.Cookies["UserID"].Value);

            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Order] VALUES(@UserID, @UserName, @ProductID, @EmailAddress, @MobileNo, @Address, GETDATE())", con);
                    cmd.Parameters.AddWithValue("UserID", userid);
                    cmd.Parameters.AddWithValue("UserName", TextBoxName.Text);
                    cmd.Parameters.AddWithValue("ProductID", productid);
                    cmd.Parameters.AddWithValue("EmailAddress", TextBoxEmail.Text);
                    cmd.Parameters.AddWithValue("MobileNo", TextBoxMoblieNo.Text);
                    cmd.Parameters.AddWithValue("Address", TextBoxAddress.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Order is successfull')", true);
                    //Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}