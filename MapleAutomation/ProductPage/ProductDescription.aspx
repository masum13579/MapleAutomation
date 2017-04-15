<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDescription.aspx.cs" Inherits="MapleAutomation.ProductPage.ProductDescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/etalage.css" rel="stylesheet" />
    <link href="../Content/magnific-popup.css" rel="stylesheet" />
    <script src="../Scripts/jquery.etalage.min.js"></script>
    <script src="../Scripts/jquery.magnific-popup.js"></script>
    <link href="../Content/ProductDescription.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $('.popup-with-zoom-anim').magnificPopup({
                type: 'inline',
                fixedContentPos: false,
                fixedBgPos: true,
                overflowY: 'auto',
                closeBtnInside: true,
                preloader: false,
                midClick: true,
                removalDelay: 200,
                mainClass: 'my-mfp-zoom-in'
            });
        });
    </script>
    
    <script>
        jQuery(document).ready(function ($) {

            $('#etalage').etalage({
                thumb_image_width: 230,
                thumb_image_height: 350,
                show_hint: true,
                click_callback: function (image_anchor, instance_id) {
                    alert('Callback example:\nYou clicked on an image with the anchor: "' + image_anchor + '"\n(in Etalage instance: "' + instance_id + '")');
                }
            });


        });

    </script>
    
    <div class="container">
        <div class="row"></div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-4">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
                        <ItemTemplate>
                            <ul id="etalage">
                                <li>
                                    <img ID="Img1" runat="server" class="etalage_thumb_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath1"))%>' />
                                    <img ID="Img2" runat="server" class="etalage_source_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath1"))%>' />
                                    
                                </li>
                                <li>
                                    <img ID="Image3" runat="server" class="etalage_thumb_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath2"))%>' />
                                    <img ID="Image4" runat="server" class="etalage_source_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath2"))%>' />
                                </li>
                                <li>
                                    <img ID="Image5" runat="server" class="etalage_thumb_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath3"))%>' />
                                    <img ID="Image6" runat="server" class="etalage_source_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath3"))%>' />
                                </li>
                                <li>
                                    <img ID="Image7" runat="server" class="etalage_thumb_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath4"))%>' />
                                    <img ID="Image8" runat="server" class="etalage_source_image" src='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImagePath4"))%>' />
                                </li>
                            </ul>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
            </div>
            
            <div class="col-lg-6">
                <asp:DataList ID="DataList2" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <div id="product_name_width">
                                <asp:Label ID="ProductNameLabel" runat="server" CssClass="product_name" Text='<%# Eval("ProductName") %>' />
                                <br />
                            </div>
                            <asp:Label ID="ProductCodeLabel" runat="server" Text='<%# Eval("ProductCode") %>' />
                            <br />
                            <br />
                            <span id="brand_name">Brand</span>
                            <asp:Label ID="BrandLabel" runat="server" Text='<%# Eval("Brand") %>' />
                            <br />
                            <div id="buy_now_css">
                                <ul>
                                    <li>
                                        <asp:Button ID="AddToCart" runat="server" CssClass="btn btn-primary" Text="ADD TO CART" OnClick="AddToCart_OnClick" />
                                    </li>
                                    <li>
                                        <asp:Button ID="BuyNow" CssClass="btn btn-success" runat="server" Text="BUY NOW" OnClick="BuyNow_OnClick" />
                                    </li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                <asp:DataList ID="DataList3" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <h2>Specification</h2>
                            <div id="Description_width">
                                <asp:Label ID="SpecificationLabel" CssClass="description" runat="server" Text='<%# Eval("Specification") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("File") %>' CommandName="Download" Text='<%# Eval("File") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                
            </div>
            <div class="col-lg-2"></div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([ProductID] = @ProductID)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4] FROM [Product] WHERE ([ProductID] = @ProductID)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
    </div>
</asp:Content>
