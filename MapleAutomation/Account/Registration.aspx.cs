using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace MapleAutomation.Account
{
    public partial class Registration : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;

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
            if (Session["Role"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }

        }



        public void SandEmail()
        {
            MailMessage massage = new MailMessage();
            SmtpClient clint = new SmtpClient();
            clint.Host = "smtp.gmail.com";
            clint.Port = 587;

            string useractivation = "http://maengineeringltd.com/Account/UserActivation.aspx?Email=" + Email.Text;

            massage.From = new MailAddress("mapleautomationandengineering@gmail.com");
            massage.To.Add(Email.Text);
            massage.Subject = "Account Activation";
            massage.Body = "hello " + UserName.Text + "Your Email Confermation Link is....<br /><br /> <a href='" + useractivation + "'> click here</a>";
            massage.IsBodyHtml = true;
            clint.EnableSsl = true;
            clint.UseDefaultCredentials = true;
            clint.Credentials = new System.Net.NetworkCredential("mapleautomationandengineering@gmail.com", "mapleautomation12345");
            clint.Send(massage);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string role = "User";
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT UserName FROM UserData WHERE UserName = @UserName", con);
                    cmd1.Parameters.AddWithValue("UserName", UserName.Text);
                    con.Open();
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        ErrorMassage.Text = "UserName already taken";
                        UserName.Text = null;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand("SELECT Email FROM UserData WHERE Email = @Email", con);
                        cmd2.Parameters.AddWithValue("Email", Email.Text);
                        con.Open();
                        SqlDataReader sdr1 = cmd2.ExecuteReader();
                        if (sdr1.HasRows)
                        {
                            ErrorMassage.Text = "Email already taken";
                            Email.Text = null;
                            con.Close();
                        }
                        else
                        {
                            con.Close();
                            SqlCommand cmd = new SqlCommand("INSERT INTO UserData VALUES(@FirstName, @LastName, @UserName, @Password, @Role, @Address, @MobileNo, @Email, GETDATE(), @Activated)", con);
                            cmd.Parameters.AddWithValue("FirstName", FirstName.Text);
                            cmd.Parameters.AddWithValue("LastName", LastName.Text);
                            cmd.Parameters.AddWithValue("UserName", UserName.Text);
                            cmd.Parameters.AddWithValue("Password", Encrypt(TextBoxPassword.Text));
                            cmd.Parameters.AddWithValue("Role", role);
                            cmd.Parameters.AddWithValue("Address", textArea.Text);
                            cmd.Parameters.AddWithValue("MobileNo", TextBoxPhone.Text);
                            cmd.Parameters.AddWithValue("Email", Email.Text);
                            cmd.Parameters.AddWithValue("Activated", 0);
                            con.Open();
                            int no = cmd.ExecuteNonQuery();
                            if (no > 0)
                            {
                                //SandEmail();
                            }
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('A verification link send to your email')</script>");
                            Response.Redirect("~/Account/UserLogin.aspx");
                        }
                        
                    }
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}