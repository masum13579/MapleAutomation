<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DCDrive.aspx.cs" Inherits="MapleAutomation.ProductPage.DCDrive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .tab-content {
            border-left: 0px solid #ddd;
            border-right: 0px solid #ddd;
            border-top: 1px solid #ddd;
            padding: 10px;
        }

        .nav-tabs {
            margin-bottom: 0;
        }
    </style>
    <div class="container">
        <div class="row">&nbsp;</div>
        <div class="row">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#DCDrive1" data-toggle="tab" aria-expanded="true">DC Motor Drives</a></li>
                <li class=""><a href="#DCDrive2" data-toggle="tab" aria-expanded="false">DC Thyristor Drives (1ph/2ph Input)</a></li>
                <li class=""><a href="#DCDrive3" data-toggle="tab" aria-expanded="true">DC Thyristor Drives (3ph Input)</a></li>
                <li class=""><a href="#DCDrive4" data-toggle="tab" aria-expanded="false">DC to DC Drives</a></li>
                <li class=""><a href="#DCDrive5" data-toggle="tab" aria-expanded="false">Spare Parts for DC Drives</a></li>
            </ul>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade active in" id="DCDrive1">
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="130px" Height="150px" PostBackUrl='<%#"ProductDescription.aspx?ProductID="+Eval("ProductID") %>' />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductNameLabe" runat="server" Text='<%# Eval("ProductName") %>' />
                                        <br />
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductCodeLabe" runat="server" Text='<%# Eval("ProductCode") %>' />
                                        <hr />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="121" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="DCDrive2">
                    <asp:DataList ID="DataList2" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource2" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="130px" Height="150px" PostBackUrl='<%#"ProductDescription.aspx?ProductID="+Eval("ProductID") %>' />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductNameLabe" runat="server" Text='<%# Eval("ProductName") %>' />
                                        <br />
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductCodeLabe" runat="server" Text='<%# Eval("ProductCode") %>' />
                                        <hr />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="122" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="DCDrive3">
                    <asp:DataList ID="DataList3" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource3" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="130px" Height="150px" PostBackUrl='<%#"ProductDescription.aspx?ProductID="+Eval("ProductID") %>' />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductNameLabe" runat="server" Text='<%# Eval("ProductName") %>' />
                                        <br />
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductCodeLabe" runat="server" Text='<%# Eval("ProductCode") %>' />
                                        <hr />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="123" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="DCDrive4">
                    <asp:DataList ID="DataList4" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource4" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="130px" Height="150px" PostBackUrl='<%#"ProductDescription.aspx?ProductID="+Eval("ProductID") %>' />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductNameLabe" runat="server" Text='<%# Eval("ProductName") %>' />
                                        <br />
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductCodeLabe" runat="server" Text='<%# Eval("ProductCode") %>' />
                                        <hr />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="124" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="DCDrive5">
                    <asp:DataList ID="DataList5" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource5" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("BrandImage"))%>' Width="130px" Height="150px" PostBackUrl='<%#"ProductDescription.aspx?ProductID="+Eval("ProductID") %>' />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductNameLabe" runat="server" Text='<%# Eval("ProductName") %>' />
                                        <br />
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ProductCodeLabe" runat="server" Text='<%# Eval("ProductCode") %>' />
                                        <hr />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="125" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
