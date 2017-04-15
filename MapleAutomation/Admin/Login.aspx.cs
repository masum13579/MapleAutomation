using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace MapleAutomation.Admin
{
    public partial class Login : System.Web.UI.Page
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

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Roles"] != null)
            {
                    Response.Redirect("~/Admin/AdminHome.aspx");
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AdminData", con);
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            if (sdr[3].ToString().Equals(UserName.Text.Trim()) && Decrypt(sdr[4].ToString()).Equals(Password.Text.Trim()))
                            {
                                Response.Cookies["AdminName"].Value = Encrypt(sdr[3].ToString());
                                Response.Cookies["AdminID"].Value = Encrypt(sdr[0].ToString());
                                //Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes("AdminName")));
                                Session["Roles"] = sdr[5].ToString();
                                FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
                                Response.Redirect("~/Admin/AdminHome.aspx");
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