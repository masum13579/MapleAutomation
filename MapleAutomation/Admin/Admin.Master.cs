using System;
using System.Collections.Generic;
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
    public partial class Admin : System.Web.UI.MasterPage
    {

        public string Decrypt(string cipherText)
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
            if (Session["Roles"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string roles = Session["Roles"].ToString();
                //LabelName.Text = "Welcome  " + Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String("your cookie value")));
                LabelName.Text = "Welcome  " + Decrypt(Request.Cookies["AdminName"].Value);

                OrderPanel.Visible = false;
                ProductPanel.Visible = false;
                MasterPanel.Visible = false;

                if (roles == "Order")
                {
                    OrderPanel.Visible = true;
                }
                else if (roles == "Product")
                {
                    ProductPanel.Visible = true;
                }
                else if (roles == "Master")
                {
                    MasterPanel.Visible = true;
                    OrderPanel.Visible = true;
                    ProductPanel.Visible = true;
                }

            }
        }
    }
}