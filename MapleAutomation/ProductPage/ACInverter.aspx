<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ACInverter.aspx.cs" Inherits="MapleAutomation.ProductPage.ACInverter" %>

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
                <li class="dropdown active">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">AC Inverter <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li class="active"><a href="#ACInverter1" data-toggle="tab" aria-expanded="false">AC Inverter Drives (115V)</a></li>
                        <li class=""><a href="#ACInverter2" data-toggle="tab" aria-expanded="true">AC Inverter Drives (230V)</a></li>
                        <li class=""><a href="#ACInverter3" data-toggle="tab" aria-expanded="false">AC Inverter Drives (400V)</a></li>
                        <li class=""><a href="#ACInverter4" data-toggle="tab" aria-expanded="true">Regen AC Drives (400V)</a></li>
                        <li class=""><a href="#ACInverter5" data-toggle="tab" aria-expanded="false">AC Motor-Mounting Inverters</a></li>
                        <li class=""><a href="#ACInverter6" data-toggle="tab" aria-expanded="true">AC Drive and Motor Kits</a></li>
                        <li class=""><a href="#ACInverter7" data-toggle="tab" aria-expanded="false">Spare Parts for AC Drives</a></li>
                        <li class=""><a href="#ACInverter8" data-toggle="tab" aria-expanded="true">Modular Inverter Drives</a></li>
                    </ul>
                </li>
            </ul>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade active in" id="ACInverter1">
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
                            <asp:Parameter DefaultValue="141" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter2">
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
                            <asp:Parameter DefaultValue="142" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter3">
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
                            <asp:Parameter DefaultValue="143" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter4">
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
                            <asp:Parameter DefaultValue="144" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter5">
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
                            <asp:Parameter DefaultValue="145" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter6">
                    <asp:DataList ID="DataList6" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource6" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
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
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="146" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter7">
                    <asp:DataList ID="DataList7" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource7" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
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
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="147" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="ACInverter8">
                    <asp:DataList ID="DataList8" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource8" Height="350px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
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
                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" SelectCommand="SELECT * FROM [Product] WHERE ([CatagoryID] = @CatagoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="148" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
