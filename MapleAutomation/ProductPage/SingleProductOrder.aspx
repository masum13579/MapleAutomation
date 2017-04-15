<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingleProductOrder.aspx.cs" Inherits="MapleAutomation.ProductPage.SingleProductOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <h2 class="text-primary">Order Summary</h2>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="100px" Height="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="TypeOfProduct" HeaderText="Product Type" SortExpression="TypeOfProduct" />
                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT [BrandImage], [TypeOfProduct], [ProductName], [ProductCode] FROM [Product] WHERE ([ProductID] = @ProductID)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-2"></div>
        </div>
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-5">
            <h2>Select Shipping Address</h2>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="TextBoxName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Name is Required" ControlToValidate="TextBoxName" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Email is Required" ControlToValidate="TextBoxEmail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Mobile-No"></asp:Label>
                <asp:TextBox ID="TextBoxMoblieNo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Mobile-No is Required" ControlToValidate="TextBoxMoblieNo" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" Columns="35"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Address is Required" ControlToValidate="TextBoxAddress" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <asp:Label ID="ErrorMassage" runat="server" Font-Size="Small" CssClass="text-danger"></asp:Label><br />
            <asp:Button ID="ButtonOrder" runat="server" Text="Order" CssClass="btn btn-primary" OnClick="ButtonOrder_Click" />
                </div>
        </div>
    </div>
</asp:Content>
