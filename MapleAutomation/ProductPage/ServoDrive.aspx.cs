using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapleAutomation.ProductPage
{
    public partial class ServoDrive : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void ButtonASD_Click(object sender, EventArgs e)
        //{
        //    Panel1.Visible = true;
        //    Panel2.Visible = false;
        //    Panel3.Visible = false;

        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        string catagoryid = "131";
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)", con);
        //        cmd.Parameters.AddWithValue("CatagoryID", catagoryid);
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //        DataSet DS = new DataSet();
        //        sda.Fill(DS);

        //        DataList1.DataSource = DS;
        //        DataList1.DataBind();

        //    }
        //}

        //protected void ButtonPFC_Click(object sender, EventArgs e)
        //{
        //    Panel1.Visible = false;
        //    Panel2.Visible = true;
        //    Panel3.Visible = false;
        //}

        //protected void ButtonCSD_Click(object sender, EventArgs e)
        //{
        //    Panel1.Visible = false;
        //    Panel2.Visible = false;
        //    Panel3.Visible = true;
        //}
    }
}