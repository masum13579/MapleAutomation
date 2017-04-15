using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SandEmail();
            Name.Text = null;
            Email.Text = null;
            Comment.Text = null;
            Mobile.Text = null;
            Subject.Text = null;
            Massage.Text = "Massage Send Secessfully";
        }
        public void SandEmail()
        {
            MailMessage massage = new MailMessage();
            SmtpClient clint = new SmtpClient();
            clint.Host = "smtp.gmail.com";
            clint.Port = 587;

            massage.From = new MailAddress("mapleautomationengineering@gmail.com");
            massage.To.Add("mapleautomationandengineering@gmail.com");
            massage.Subject = "Maple Automation ";
            massage.Body = "From <br /><br /> " + Name.Text + "<br /><br />" + Email.Text + "<br /><br />" + Mobile.Text + "<br /><br />" + Subject.Text + "<br /><br />" + Comment.Text;
            massage.IsBodyHtml = true;
            clint.EnableSsl = true;
            clint.UseDefaultCredentials = true;
            clint.Credentials = new System.Net.NetworkCredential("mapleautomationengineering@gmail.com", "mapleautomation12345");
            clint.Send(massage);
        }
    }
}