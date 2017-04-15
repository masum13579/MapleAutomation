<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="MapleAutomation.ProductPage.SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row"></div>
        <div class="row">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" RepeatColumns="4" Width="100%"  Height="350px">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButtonBrandImage" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="130px" Height="150px" PostBackUrl='<%#"~/ProductPage/ProductDescription.aspx?ProductID="+Eval("ProductID")%>' />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ProductCodeLabel" runat="server" Text='<%# Eval("ProductCode") %>' />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BrandLabel" runat="server" Text='<%# Eval("Brand") %>' />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
