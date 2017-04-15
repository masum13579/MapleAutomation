<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="MapleAutomation.Admin.ViewOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <div class="container"> 
            <div class="row">
                <h3 class="text-primary">Search Order</h3>
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
                      <td><asp:TextBox ID="StartDate" CssClass="form-control input-sm" Height="25px" runat="server" ReadOnly="True"></asp:TextBox>  </td>
                      <td><asp:ImageButton ID="ImageButton1" runat="server" Width="20px" Height="20px" ImageUrl="../Content/img/calendar.png" OnClick="ImageButton1_Click" />
                      </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td><asp:TextBox ID="EndDate" CssClass="form-control input-sm" Height="25px" runat="server" ReadOnly="True"></asp:TextBox></td>
                      <td><asp:ImageButton ID="ImageButton2" runat="server" Width="20px" Height="20px" ImageUrl="../Content/img/calendar.png" OnClick="ImageButton2_Click" />
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
        <div class="row"><br/><br/></div>
        <div class="row">
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" Width="100%" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="OrderID" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                    <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID" />
                    <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile-No" SortExpression="MobileNo" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
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
    </div>
</asp:Content>
