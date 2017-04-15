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
using System.Data;
using System.Security.Cryptography;

namespace MapleAutomation.Account
{
    public partial class EditProfile : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        string Role { get; set; }
        string UserId { get; set; }


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

        private string Encrypt(string clearText)
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
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/UserLogin.aspx");
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE UserID = @UserID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                UserId = Decrypt(Request.Cookies["UserID"].Value);
                cmd.Parameters.AddWithValue("UserID", UserId);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!IsPostBack)
                {
                    if (dt.Rows.Count > 0)
                    {
                        FirstName.Text = dt.Rows[0]["FirstName"].ToString();
                        LastName.Text = dt.Rows[0]["LastName"].ToString();
                        UserName.Text = dt.Rows[0]["UserName"].ToString();
                        TextBoxPassword.Text = Decrypt(dt.Rows[0]["Password"].ToString());
                        Email.Text = dt.Rows[0]["Email"].ToString();
                        TextBoxPhone.Text = dt.Rows[0]["MobileNo"].ToString();
                        textArea.Text = dt.Rows[0]["Address"].ToString();
                    }
                }
                Role = dt.Rows[0]["Role"].ToString();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UserData] SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password, Role = @Role, Address = @Address, MobileNo = @MobileNo, Email = @Email WHERE (UserID = @UserID)", con);
                    cmd.Parameters.AddWithValue("FirstName", FirstName.Text);
                    cmd.Parameters.AddWithValue("LastName", LastName.Text);
                    cmd.Parameters.AddWithValue("UserName", UserName.Text);
                    cmd.Parameters.AddWithValue("Password", Encrypt(TextBoxPassword.Text));
                    cmd.Parameters.AddWithValue("Role", Role);
                    cmd.Parameters.AddWithValue("Address", textArea.Text);
                    cmd.Parameters.AddWithValue("MobileNo", TextBoxPhone.Text);
                    cmd.Parameters.AddWithValue("Email", Email.Text);
                    cmd.Parameters.AddWithValue("UserID", UserId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Massage.Text = "Account Edited Sucessfully";
                    //Response.Redirect("~/Account/EditProfile.aspx");
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}