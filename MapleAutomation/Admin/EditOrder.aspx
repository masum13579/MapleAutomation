<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="MapleAutomation.Admin.EditOrder" %>

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
            <h3 class="text-primary">Edit Order</h3>
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
                            <asp:ImageButton ID="ImageButton1" runat="server" Width="20px" Height="20px" ImageUrl="../Content/img/calendar.png" OnClick="ImageButton1_Click" />
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
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged" Width="200px">
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
        </div>
        <div class="row">
            <br />
            <br />
        </div>
        <div class="row">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" Width="100%" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="OrderID" 
                ForeColor="Black" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" 
                OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />
                    <asp:TemplateField HeaderText="User ID" SortExpression="UserID">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product ID" SortExpression="ProductID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxProductId" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Address" SortExpression="EmailAddress">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%# Bind("EmailAddress") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("EmailAddress") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile-No" SortExpression="MobileNo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxMobile" runat="server" Text='<%# Bind("MobileNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" SortExpression="Address">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel"  Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit"  Text="Edit"  />
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
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblmsg" CssClass="text-center" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
