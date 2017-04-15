<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSummary.aspx.cs" Inherits="MapleAutomation.ProductPage.OrderSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <h2 class="text-primary">Order Summary</h2>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField SortExpression="Image">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="100px" Height="100px"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="Brand" HeaderText="Product Brand" SortExpression="Brand" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-5">
                <h2 class="text-primary">Select Shipping Address</h2>
                
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName"
                          ForeColor="red" ErrorMessage="Name is Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmail"
                          ForeColor="red" ErrorMessage="Email is Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Mobile-No"></asp:Label>
                    <asp:TextBox ID="TextBoxMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxMobile"
                          ForeColor="red" ErrorMessage="Mobile-No is Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxAddress"
                          ForeColor="red" ErrorMessage="Address is Required"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="ErrorMassage" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><br/>
                <asp:Button ID="ButtonOrder" runat="server" Text="Order" CssClass="btn btn-success btn-sm" OnClick="ButtonOrder_Click" />

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonCancel" runat="server" CssClass="btn btn-danger disabled btn-sm" Text="cancel" OnClick="ButtonCancel_Click" />

            </div>
        </div>
    </div>
</asp:Content>
