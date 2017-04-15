<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PLCANDHMI.aspx.cs" Inherits="MapleAutomation.ProductPage.PLCANDHMI" %>

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
                <li class="active"><a href="#home" data-toggle="tab" aria-expanded="true">PLC & HMI</a></li>
            </ul>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade active in" id="home">
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
                            <asp:Parameter DefaultValue="110" Name="CatagoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
