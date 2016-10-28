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

namespace MapleAutomation.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        public string ProductPic { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }

        private DataSet GetData(string GetTag, SqlParameter MaParameter)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(GetTag, con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MaParameter != null)
            {
                sda.SelectCommand.Parameters.Add(MaParameter);
            }
            DataSet DS = new DataSet();
            sda.Fill(DS);

            return DS;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownTypeOfProduct.DataSource = GetData("MaGetTag", null);
                DropDownTypeOfProduct.DataBind();

                ListItem liTag = new ListItem("Select Product Type", "-1");
                DropDownTypeOfProduct.Items.Insert(0, liTag);

                ListItem liCatagory = new ListItem("Select Product Catagory", "-1");
                DropDownCatagory.Items.Insert(0, liCatagory);

                DropDownCatagory.Enabled = false;
            }
        }

        protected void DropDownTypeOfProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownTypeOfProduct.SelectedIndex == 0)
            {
                DropDownCatagory.SelectedIndex = 0;
                DropDownCatagory.Enabled = false;
            }
            else
            {
                DropDownCatagory.Enabled = true;
                SqlParameter paramiter = new SqlParameter("@TagID", DropDownTypeOfProduct.SelectedValue);
                DataSet DS = GetData("MaGetProductCatagoryByTagID", paramiter);

                DropDownCatagory.DataSource = DS;
                DropDownCatagory.DataBind();

                ListItem liCatagory = new ListItem("Select Product Catagory", "-1");
                DropDownCatagory.Items.Insert(0, liCatagory);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //-----Product Picture-----//
            HttpPostedFile postedfileProPic = FileUploadProImage.PostedFile;
            string filenameProPic = Path.GetFileName(postedfileProPic.FileName);
            string fileextentionProPic = Path.GetExtension(filenameProPic);

            if (fileextentionProPic.ToLower() == ".jpg" || fileextentionProPic.ToLower() == ".bmp" ||
                fileextentionProPic.ToLower() == ".jpeg" || fileextentionProPic.ToLower() == ".png")
            {
                string str = FileUploadProImage.FileName;
                FileUploadProImage.PostedFile.SaveAs(Server.MapPath("~/Content/Product/") + str);
                ProductPic = ("~/Content/Product/") + str.ToString();
            }
            else
            {
                Massage.Visible = true;
                Massage.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
            }
            //-----Product Picture End-----//

            //-----Image Path 1-----//
            HttpPostedFile postedfileImgPath1 = FileUploadImgPath1.PostedFile;
            string filenameImgPath1 = Path.GetFileName(postedfileImgPath1.FileName);
            string fileextentionImgPath1 = Path.GetExtension(filenameImgPath1);

            if (fileextentionImgPath1.ToLower() == ".jpg" || fileextentionImgPath1.ToLower() == ".bmp" ||
                fileextentionImgPath1.ToLower() == ".jpeg" || fileextentionImgPath1.ToLower() == ".png")
            {
                string str = FileUploadImgPath1.FileName;
                FileUploadImgPath1.PostedFile.SaveAs(Server.MapPath("~/Content/Product_Image/") + str);
                ImagePath1 = ("~/Content/Product_Image/") + str.ToString();
            }
            else
            {
                Massage1.Visible = true;
                Massage1.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
            }
            //-----Image Path 1 End-----//

            //-----Image Path 2-----//
            HttpPostedFile postedfileImgPath2 = FileUploadImgPath2.PostedFile;
            string filenameImgPath2 = Path.GetFileName(postedfileImgPath2.FileName);
            string fileextentionImgPath2 = Path.GetExtension(filenameImgPath2);

            if (fileextentionImgPath2.ToLower() == ".jpg" || fileextentionImgPath2.ToLower() == ".bmp" ||
                fileextentionImgPath2.ToLower() == ".jpeg" || fileextentionImgPath2.ToLower() == ".png")
            {
                string str = FileUploadImgPath2.FileName;
                FileUploadImgPath2.PostedFile.SaveAs(Server.MapPath("~/Content/Product_Image/") + str);
                ImagePath2 = ("~/Content/Product_Image/") + str.ToString();
            }
            else
            {
                Massage2.Visible = true;
                Massage2.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
            }
            //-----Image Path 2 End-----//

            //-----Image Path 3-----//
            HttpPostedFile postedfileImgPath3 = FileUploadImgPath3.PostedFile;
            string filenameImgPath3 = Path.GetFileName(postedfileImgPath3.FileName);
            string fileextentionImgPath3 = Path.GetExtension(filenameImgPath3);

            if (fileextentionImgPath3.ToLower() == ".jpg" || fileextentionImgPath3.ToLower() == ".bmp" ||
                fileextentionImgPath3.ToLower() == ".jpeg" || fileextentionImgPath3.ToLower() == ".png")
            {
                string str = FileUploadImgPath3.FileName;
                FileUploadImgPath3.PostedFile.SaveAs(Server.MapPath("~/Content/Product_Image/") + str);
                ImagePath3 = ("~/Content/Product_Image/") + str.ToString();
            }
            else
            {
                Massage3.Visible = true;
                Massage3.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
            }
            //-----Image Path 3 End-----//

            //-----Image Path 4-----//
            HttpPostedFile postedfileImgPath4 = FileUploadImagePath4.PostedFile;
            string filenameImgPath4 = Path.GetFileName(postedfileImgPath4.FileName);
            string fileextentionImgPath4 = Path.GetExtension(filenameImgPath4);

            if (fileextentionImgPath4.ToLower() == ".jpg" || fileextentionImgPath4.ToLower() == ".bmp" ||
                fileextentionImgPath4.ToLower() == ".jpeg" || fileextentionImgPath4.ToLower() == ".png")
            {
                string str = FileUploadImagePath4.FileName;
                FileUploadImagePath4.PostedFile.SaveAs(Server.MapPath("~/Content/Product_Image/") + str);
                ImagePath4 = ("~/Content/Product_Image/") + str.ToString();
            }
            else
            {
                Massage4.Visible = true;
                Massage4.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
            }
            //-----Image Path 4 End-----//


            string ddlBrand = DropDownTypeOfProduct.SelectedItem.Text;
            string ddlProduct = DropDownCatagory.SelectedItem.Text;
            string ddlProductIndex = DropDownCatagory.SelectedValue;


            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Product VALUES(GETDATE(), @ProductName, @ProductCode, @TypeOfProduct, @BrandImage, @Brand, @ImagePath1, @ImagePath2, @ImagePath3, @ImagePath4, @Specification, @Stock, @CatagoryID)", con);
                    cmd.Parameters.AddWithValue("ProductName", TextProName.Text);
                    cmd.Parameters.AddWithValue("ProductCode", TextProCode.Text);
                    cmd.Parameters.AddWithValue("Brand", ddlBrand);
                    cmd.Parameters.AddWithValue("BrandImage", ProductPic);
                    cmd.Parameters.AddWithValue("TypeOfProduct", ddlProduct);
                    cmd.Parameters.AddWithValue("ImagePath1", ImagePath1);
                    cmd.Parameters.AddWithValue("ImagePath2", ImagePath2);
                    cmd.Parameters.AddWithValue("ImagePath3", ImagePath3);
                    cmd.Parameters.AddWithValue("ImagePath4", ImagePath4);
                    cmd.Parameters.AddWithValue("Specification", TextSpecification.Text);
                    cmd.Parameters.AddWithValue("Stock", TextProQtt.Text);
                    cmd.Parameters.AddWithValue("CatagoryID", ddlProductIndex);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("~/Admin/AddProduct.aspx");
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}