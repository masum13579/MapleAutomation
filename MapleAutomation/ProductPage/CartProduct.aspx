<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartProduct.aspx.cs" Inherits="MapleAutomation.ProductPage.CartProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row"></div>
        <div class="row">
            <h2 class="text-primary">Cart Product</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CartID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField SortExpression="Image">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="100px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" >
                    <ControlStyle CssClass="text-success" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Brand" HeaderText="Product Brand" SortExpression="Brand" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-default btn-sm" />
                    </asp:CommandField>
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
            &nbsp;&nbsp;&nbsp;
        </div>
        <div class="row" align="center">
            <asp:ImageButton ID="ImageButtonPlaceOrder" runat="server" ImageUrl="~/Content/img/place_order.png" OnClick="ImageButtonPlaceOrder_Click" />
        </div>
    </div>
</asp:Content>
