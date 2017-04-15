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
        public string Pdf1 = null;
        public string Pdf2 = null;
        public string Pdf3 = null;
        byte[] Bytespropic { get; set; }
        byte[] Bytesmage1 { get; set; }
        byte[] Bytesmage2 { get; set; }
        byte[] Bytesmage3 { get; set; }
        byte[] Bytesmage4 { get; set; }

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
                    
                }
                else if (roles == "Master")
                {
                    
                }

            }

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
            string ddlBrand = DropDownTypeOfProduct.SelectedItem.Text;
            string ddlProduct = DropDownCatagory.SelectedItem.Text;
            string ddlProductIndex = DropDownCatagory.SelectedValue;


            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd2 = new SqlCommand(
                        "SELECT ProductName FROM Product WHERE ProductName = @ProductName", con);
                    cmd2.Parameters.AddWithValue("ProductName", TextProName.Text);
                    con.Open();
                    SqlDataReader sdr1 = cmd2.ExecuteReader();
                    if (sdr1.HasRows)
                    {
                        ErrorMassage.Text = "Product Already Exist";
                        TextProName.Text = null;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        SqlCommand cmd1 =
                            new SqlCommand("SELECT ProductCode FROM Product WHERE ProductCode = @ProductCode", con);
                        cmd1.Parameters.AddWithValue("ProductCode", TextProCode.Text);
                        con.Open();
                        SqlDataReader sdr = cmd1.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            ErrorMassage.Text = "Product Already Exist";
                            TextProCode.Text = null;
                            con.Close();
                        }
                        else
                        {
                            con.Close();
                            //-----Product Picture-----//
                            HttpPostedFile postedfileProPic = FileUploadProImage.PostedFile;
                            string filenameProPic = Path.GetFileName(postedfileProPic.FileName);
                            string fileextentionProPic = Path.GetExtension(filenameProPic);

                            if (fileextentionProPic.ToLower() == ".jpg" || fileextentionProPic.ToLower() == ".bmp" ||
                                fileextentionProPic.ToLower() == ".jpeg" || fileextentionProPic.ToLower() == ".png")
                            {
                                //string str = FileUploadProImage.FileName;
                                //FileUploadProImage.PostedFile.SaveAs(Server.MapPath("~/Content/Product/") + str);
                                //ProductPic = ("~/Content/Product/") + str.ToString();
                                Stream stream = postedfileProPic.InputStream;
                                BinaryReader binaryReader = new BinaryReader(stream);
                                Bytespropic = binaryReader.ReadBytes((int) stream.Length);

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
                                Stream stream = postedfileImgPath1.InputStream;
                                BinaryReader binaryReader = new BinaryReader(stream);
                                Bytesmage1 = binaryReader.ReadBytes((int)stream.Length);
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
                                Stream stream = postedfileImgPath2.InputStream;
                                BinaryReader binaryReader = new BinaryReader(stream);
                                Bytesmage2 = binaryReader.ReadBytes((int)stream.Length);
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
                                Stream stream = postedfileImgPath3.InputStream;
                                BinaryReader binaryReader = new BinaryReader(stream);
                                Bytesmage3 = binaryReader.ReadBytes((int)stream.Length);
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
                                Stream stream = postedfileImgPath4.InputStream;
                                BinaryReader binaryReader = new BinaryReader(stream);
                                Bytesmage4 = binaryReader.ReadBytes((int)stream.Length);
                            }
                            else
                            {
                                Massage4.Visible = true;
                                Massage4.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
                            }
                            //-----Image Path 4 End-----//

                            //-----PDF 1-----//
                            HttpPostedFile postedfilePdf1 = FileUploadPDF1.PostedFile;
                            string filenamePdf1 = Path.GetFileName(postedfilePdf1.FileName);
                            string fileextentionPdf1 = Path.GetExtension(filenamePdf1);

                            if (fileextentionPdf1.ToLower() == ".pdf")
                            {
                                string str = FileUploadPDF1.FileName;
                                FileUploadPDF1.PostedFile.SaveAs(Server.MapPath("~/Content/Data/") + str.ToString());
                                Pdf1 = ("~/Content/Data/") + str.ToString();
                            }
                            else
                            {
                                Massage4.Visible = true;
                                Massage4.Text = "Only PDF file can be uploaded";
                            }
                            //-----PDF 1 End-----//

                            //-----PDF 3-----//
                            HttpPostedFile postedfilePdf3 = FileUploadPDF2.PostedFile;
                            string filenamePdf3 = Path.GetFileName(postedfilePdf3.FileName);
                            string fileextentionPdf3 = Path.GetExtension(filenamePdf3);

                            if (fileextentionPdf3.ToLower() == ".pdf")
                            {
                                string str = FileUploadPDF3.FileName;
                                FileUploadPDF3.PostedFile.SaveAs(Server.MapPath("~/Content/Data/") + str.ToString());
                                Pdf3 = ("~/Content/Data/") + str.ToString();
                            }
                            else
                            {
                                Massage4.Visible = true;
                                Massage4.Text = "Only PDF file can be uploaded";
                            }
                            //-----PDF 3 End-----//

                            //-----PDF 2-----//
                            HttpPostedFile postedfilePdf2 = FileUploadPDF2.PostedFile;
                            string filenamePdf2 = Path.GetFileName(postedfilePdf2.FileName);
                            string fileextentionPdf2 = Path.GetExtension(filenamePdf2);

                            if (fileextentionPdf2.ToLower() == ".pdf")
                            {
                                string str = FileUploadPDF2.FileName;
                                FileUploadPDF2.PostedFile.SaveAs(Server.MapPath("~/Content/Data/") + str.ToString());
                                Pdf2 = ("~/Content/Data/") + str.ToString();
                            }
                            else
                            {
                                Massage4.Visible = true;
                                Massage4.Text = "Only PDF file can be uploaded";
                            }
                            //-----PDF 3 End-----//

                            SqlCommand cmd =
                                new SqlCommand(
                                    @"INSERT INTO Product VALUES(GETDATE(), @ProductName, @ProductCode, @TypeOfProduct, @BrandImage, @Brand, @ImagePath1, @ImagePath2, @ImagePath3, @ImagePath4, @Specification, @Stock, @CatagoryID, @PDF1, @PDF2, @PDF3)",
                                    con);
                            cmd.Parameters.AddWithValue("ProductName", TextProName.Text);
                            cmd.Parameters.AddWithValue("ProductCode", TextProCode.Text);
                            cmd.Parameters.AddWithValue("Brand", ddlBrand);
                            cmd.Parameters.AddWithValue("BrandImage", Bytespropic);
                            cmd.Parameters.AddWithValue("TypeOfProduct", ddlProduct);
                            cmd.Parameters.AddWithValue("ImagePath1", Bytesmage1);
                            cmd.Parameters.AddWithValue("ImagePath2", Bytesmage2);
                            cmd.Parameters.AddWithValue("ImagePath3", Bytesmage3);
                            cmd.Parameters.AddWithValue("ImagePath4", Bytesmage4);
                            cmd.Parameters.AddWithValue("Specification", TextSpecification.Text);
                            cmd.Parameters.AddWithValue("Stock", TextProQtt.Text);
                            cmd.Parameters.AddWithValue("CatagoryID", ddlProductIndex);
                            cmd.Parameters.AddWithValue("PDF1", String.IsNullOrEmpty(Pdf1) ? DBNull.Value : (object) Pdf1);
                            cmd.Parameters.AddWithValue("PDF2", String.IsNullOrEmpty(Pdf2) ? DBNull.Value : (object)Pdf2);
                            cmd.Parameters.AddWithValue("PDF3", String.IsNullOrEmpty(Pdf3) ? DBNull.Value : (object)Pdf3);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("~/Admin/AddProduct.aspx");

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