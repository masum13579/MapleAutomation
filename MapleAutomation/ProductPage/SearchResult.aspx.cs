using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace MapleAutomation.ProductPage
{
    public partial class SearchResult : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        private string ProductName { get; set; }

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
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM[Product] WHERE([ProductName] LIKE '%' + @ProductName + '%')", con);
               SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ProductName = Decrypt(Request.QueryString["ProductName"]);
                cmd.Parameters.AddWithValue("ProductName", ProductName);
                //SqlDataReader sdr = cmd.ExecuteReader();


                DataTable dt = new DataTable();
                sda.Fill(dt);
                string data = dt.Rows[0][6].ToString();

                con.Close();

                con.Open();

                SqlCommand cmd1 =
                    new SqlCommand("SELECT * FROM[Product] WHERE([Brand] = '"+data+"')", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                DataList1.DataSource = dt1;
                DataList1.DataBind();

            }
        }
    }
}