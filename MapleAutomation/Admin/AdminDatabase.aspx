<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDatabase.aspx.cs" Inherits="MapleAutomation.Admin.AdminDatabase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <div class="container">
        <div class="row">
            <div class="jumbotron">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="AdminID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="AdminID" HeaderText="Admin ID" InsertVisible="False" ReadOnly="True" SortExpression="AdminID" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                        <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" SortExpression="MobileNo" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="RegisterDate" HeaderText="Register Date" SortExpression="RegisterDate" />
                        <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLCON %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AdminData]">
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
