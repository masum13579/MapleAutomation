using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace MapleAutomation.Admin
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        private string role;

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
                    Response.Redirect("Login.aspx");
                }
                else if (roles == "Master")
                {
                    
                }

            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            

            if (PermissionCheck.SelectedValue != null)
            {
                if (PermissionCheck.SelectedValue == "Master")
                {
                    role = "Master";
                }
                else if(PermissionCheck.SelectedValue == "Order")
                {
                    role = "Order";
                }
                else if(PermissionCheck.SelectedValue == "Product")
                {
                    role = "Product";
                }
            }
            else
            {
                Response.Redirect("AddAdmin.aspx");
            }

            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT UserName FROM AdminData WHERE UserName = @UserName", con);
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
                        SqlCommand cmd = new SqlCommand("INSERT INTO AdminData VALUES(@FirstName, @LastName, @UserName, @Password, @Role, @Address, @MobileNo, @Email, GETDATE())", con);
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("FirstName", FirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("LastName", LastName.Text.Trim());
                        cmd.Parameters.AddWithValue("UserName", UserName.Text.Trim());
                        cmd.Parameters.AddWithValue("Password", Encrypt(TextBoxPassword.Text.Trim()));
                        cmd.Parameters.AddWithValue("Role", role);
                        cmd.Parameters.AddWithValue("Address", textArea.Text.Trim());
                        cmd.Parameters.AddWithValue("MobileNo", TextBoxPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("Email", Email.Text.Trim());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/Admin/AddAdmin.aspx");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add Sucess')</script>");
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