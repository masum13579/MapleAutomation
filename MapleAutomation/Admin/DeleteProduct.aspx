<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="MapleAutomation.Admin.DeleteProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <script type="text/javascript">
        function deleteConfirm(pubid) {
            var result = confirm('Do you want to delete ' + pubid + ' ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <div class="container">
        <div class="row">
            <table>
                <thead>
                    <tr>
                      <th colspan="3"><h3>View Product</h3></th>
                    </tr>
                  </thead>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownList1" Width="100%" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="-1">(Select Option)</asp:ListItem>
                            <asp:ListItem>By Date</asp:ListItem>
                            <asp:ListItem Value="By Name">By Catagory</asp:ListItem>
                            <asp:ListItem>By Code</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <p class="text-left">
                            <asp:Label ID="Massage" CssClass="text-danger" runat="server" Font-Size="Small"></asp:Label>
                        </p>
                    </td>
                </tr>
            </table>
            <br/>
            <asp:Panel ID="ByDate" runat="server">
                <table class="table-striped table-hover">
                    <thead>
                        <tr>
                            <th>Start Date</th>
                            <th></th>
                            <th></th>
                            <th>End Date</th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="StartDate" CssClass="form-control input-sm" Height="25px" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="20px" Height="20px" ImageUrl="../Content/img/calendar.png" OnClick="ImageButton1_Click"/>
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td>
                                <asp:TextBox ID="EndDate" CssClass="form-control input-sm" Height="25px" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButton2" runat="server" Width="20px" Height="20px" ImageUrl="../Content/img/calendar.png" OnClick="ImageButton2_Click" />
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td>
                                <asp:Button ID="Button1" CssClass="btn btn-default btn-xs" runat="server" Text="Show" OnClick="Button1_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            </td>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
                <br/><br/>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="text-left" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ProductID" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                        <asp:BoundField DataField="InsertDate" HeaderText="Insert Date" SortExpression="InsertDate" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                        <asp:BoundField DataField="TypeOfProduct" HeaderText="Product Type" SortExpression="TypeOfProduct" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                        <asp:BoundField DataField="CatagoryID" HeaderText="Catagory ID" SortExpression="CatagoryID" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
                        </ItemTemplate>
                     </asp:TemplateField>
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
                <div class="text-center">
                    <asp:Label ID="lblmsg" CssClass="text-center" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
            <asp:Panel ID="ByName" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownListCatagory" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownListCatagory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br/>
                <br/>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="text-left" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ProductID" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                        <asp:BoundField DataField="InsertDate" HeaderText="Insert Date" SortExpression="InsertDate" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                        <asp:BoundField DataField="TypeOfProduct" HeaderText="Product Type" SortExpression="TypeOfProduct" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                        <asp:BoundField DataField="CatagoryID" HeaderText="Catagory ID" SortExpression="CatagoryID" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
                        </ItemTemplate>
                     </asp:TemplateField>
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
                <div class="text-center">
                    <asp:Label ID="Labelmassage" CssClass="text-center" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
            <asp:Panel ID="ByCode" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBoxProCode" runat="server" placeholder="Code"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonCode" CssClass="btn btn-default btn-xs" runat="server" Text="Search" OnClick="ButtonCode_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="CodeMassage" CssClass="text-danger text-left" runat="server" Text="" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br/><br/>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="text-left" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ProductID" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView3_RowDataBound" OnRowDeleting="GridView3_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                        <asp:BoundField DataField="InsertDate" HeaderText="Insert Date" SortExpression="InsertDate" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                        <asp:BoundField DataField="TypeOfProduct" HeaderText="Product Type" SortExpression="TypeOfProduct" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                        <asp:BoundField DataField="CatagoryID" HeaderText="Catagory ID" SortExpression="CatagoryID" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
                        </ItemTemplate>
                     </asp:TemplateField>
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
                <div class="text-center">
                    <asp:Label ID="LblMassage" CssClass="text-center" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
