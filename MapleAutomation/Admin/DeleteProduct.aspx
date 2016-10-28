<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="MapleAutomation.Admin.DeleteProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <div class="row" align="center">
        <h2>Product Delete Page</h2>
        <div class="jumbotron"> 
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                    <asp:BoundField DataField="InsertDate" HeaderText="Insert Date" SortExpression="InsertDate" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                    <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                    <asp:BoundField DataField="TypeOfProduct" HeaderText="Type Of Product" SortExpression="TypeOfProduct" />
                    <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" DeleteCommand="DELETE FROM [Product] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Product] ([InsertDate], [ProductName], [ProductCode], [TypeOfProduct], [BrandImage], [Brand], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [Specification], [Stock], [CatagoryID]) VALUES (@InsertDate, @ProductName, @ProductCode, @TypeOfProduct, @BrandImage, @Brand, @ImagePath1, @ImagePath2, @ImagePath3, @ImagePath4, @Specification, @Stock, @CatagoryID)" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [InsertDate] = @InsertDate, [ProductName] = @ProductName, [ProductCode] = @ProductCode, [TypeOfProduct] = @TypeOfProduct, [BrandImage] = @BrandImage, [Brand] = @Brand, [ImagePath1] = @ImagePath1, [ImagePath2] = @ImagePath2, [ImagePath3] = @ImagePath3, [ImagePath4] = @ImagePath4, [Specification] = @Specification, [Stock] = @Stock, [CatagoryID] = @CatagoryID WHERE [ProductID] = @ProductID">
                <DeleteParameters>
                    <asp:Parameter Name="ProductID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="InsertDate" Type="DateTime" />
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="ProductCode" Type="String" />
                    <asp:Parameter Name="TypeOfProduct" Type="String" />
                    <asp:Parameter Name="BrandImage" Type="String" />
                    <asp:Parameter Name="Brand" Type="String" />
                    <asp:Parameter Name="ImagePath1" Type="String" />
                    <asp:Parameter Name="ImagePath2" Type="String" />
                    <asp:Parameter Name="ImagePath3" Type="String" />
                    <asp:Parameter Name="ImagePath4" Type="String" />
                    <asp:Parameter Name="Specification" Type="String" />
                    <asp:Parameter Name="Stock" Type="Int32" />
                    <asp:Parameter Name="CatagoryID" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="InsertDate" Type="DateTime" />
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="ProductCode" Type="String" />
                    <asp:Parameter Name="TypeOfProduct" Type="String" />
                    <asp:Parameter Name="BrandImage" Type="String" />
                    <asp:Parameter Name="Brand" Type="String" />
                    <asp:Parameter Name="ImagePath1" Type="String" />
                    <asp:Parameter Name="ImagePath2" Type="String" />
                    <asp:Parameter Name="ImagePath3" Type="String" />
                    <asp:Parameter Name="ImagePath4" Type="String" />
                    <asp:Parameter Name="Specification" Type="String" />
                    <asp:Parameter Name="Stock" Type="Int32" />
                    <asp:Parameter Name="CatagoryID" Type="Int32" />
                    <asp:Parameter Name="ProductID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="row"></div>
</asp:Content>
