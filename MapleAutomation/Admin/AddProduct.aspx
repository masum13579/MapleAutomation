<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="MapleAutomation.Admin.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h1>Add Product</h1>
                    <div class="form-group">
                        <asp:Label ID="LabelProName" runat="server" Text="Product Name" Font-Underline="True"></asp:Label>
                        <asp:TextBox ID="TextProName" CssClass="form-control" placeholder="Product Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ErrorMessage="Product Name Required" ControlToValidate="TextProName" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelProCode" runat="server" Text="Product Code" Font-Underline="True"></asp:Label>
                        <asp:TextBox ID="TextProCode" CssClass="form-control" placeholder="Product Code" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextProCode"
                                                    ErrorMessage="Product Code Required" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelTypeOfProduct" runat="server" Text="Type Of Product" Font-Underline="True"></asp:Label>
                        <asp:DropDownList ID="DropDownTypeOfProduct" AutoPostBack="True" DataTextField="ProductTag" DataValueField="TagID" 
                            CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownTypeOfProduct_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownTypeOfProduct"
                                                    ErrorMessage="Product Type Required" InitialValue="-1" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelProImg" runat="server" Text="Product Image" Font-Underline="True"></asp:Label>
                        <asp:FileUpload ID="FileUploadProImage" runat="server"/>
                        <asp:Label ID="LableProInf" runat="server" Text="125 X 125, Only image (jpg, bmp, gif, png) can be uploaded" Font-Size="X-Small" CssClass="text-success"></asp:Label><br/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUploadProImage"
                                                    ErrorMessage="Product Image Required" Display="Dynamic" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:Label ID="Massage" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelBrand" runat="server" Text="Catagory" Font-Underline="True"></asp:Label>
                        <asp:DropDownList ID="DropDownCatagory" CssClass="form-control"
                            DataTextField="CatagoryName" DataValueField="CatagoryID" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="-1"
                            ControlToValidate="DropDownCatagory" ErrorMessage="Product Catagory Required" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelImgPath1" runat="server" Text="Image Path 1" Font-Underline="True"></asp:Label>
                        <asp:FileUpload ID="FileUploadImgPath1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text="400 X 400, Only image (jpg, bmp, gif, png) can be uploaded" Font-Size="X-Small" CssClass="text-success"></asp:Label><br/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="FileUploadImgPath1" 
                            ErrorMessage="Image Path 1 Required" Display="Dynamic" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:Label ID="Massage1" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelImgPath2" runat="server" Text="Image Path 2" Font-Underline="True"></asp:Label>
                        <asp:FileUpload ID="FileUploadImgPath2" runat="server" />
                        <asp:Label ID="Label2" runat="server" Font-Size="X-Small" Text="400 X 400, Only image (jpg, bmp, gif, png) can be uploaded" CssClass="text-success"></asp:Label>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="FileUploadImgPath2" 
                            ErrorMessage="Image Path 2 Required" Display="Dynamic" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:Label ID="Massage2" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelImgPath3" runat="server" Text="Image Path 3" Font-Underline="True"></asp:Label>
                        <asp:FileUpload ID="FileUploadImgPath3" runat="server" />
                        <asp:Label ID="Label3" runat="server" Font-Size="X-Small" Text="400 X 400, Only image (jpg, bmp, gif, png) can be uploaded" CssClass="text-success"></asp:Label>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="FileUploadImgPath3" 
                            ErrorMessage="Image Path 3 Required" Display="Dynamic" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:Label ID="Massage3" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelImgPath4" runat="server" Text="Image Path 4" Font-Underline="True"></asp:Label>
                        <asp:FileUpload ID="FileUploadImagePath4" runat="server" />
                        <asp:Label ID="Label4" runat="server" Font-Size="X-Small" Text="400 X 400, Only image (jpg, bmp, gif, png) can be uploaded" CssClass="text-success"></asp:Label>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="FileUploadImagePath4" 
                            ErrorMessage="Image Path 4 Required" Display="Dynamic" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:Label ID="Massage4" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelSpecification" runat="server" Text="Details" Font-Underline="True"></asp:Label>
                        <asp:TextBox ID="TextSpecification" placeholder="Product Details" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" Columns="65"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextSpecification" ErrorMessage="Product Details is Required" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelQtt" runat="server" Text="Quantity" Font-Underline="True"></asp:Label>
                        <asp:TextBox ID="TextProQtt" runat="server" placeholder="Product Quantity" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextProQtt" ErrorMessage="Product Quantity is Required" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelPDF1" runat="server" Text="PDF 1"></asp:Label>
                        <asp:FileUpload ID="FileUploadPDF1" runat="server" />
                    </div>
                     <div class="form-group">
                        <asp:Label ID="LabelPDF2" runat="server" Text="PDF 2"></asp:Label>
                        <asp:FileUpload ID="FileUploadPDF2" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelPDF3" runat="server" Text="PDF 3"></asp:Label>
                        <asp:FileUpload ID="FileUploadPDF3" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="ErrorMassage" runat="server" Font-Size="Small" CssClass="text-danger"></asp:Label><br/>
                        <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Submit_Click" />
                    </div>
        </div>
        <div class="col-md-4"></div>
    </div>
</asp:Content>
