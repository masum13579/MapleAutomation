﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MapleAutomation.Account.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">&nbsp; &nbsp;</div>
        <div class="row">
                    <h2>Registration</h2>
                    <div class="form-group">
                        <label>First Name</label>
                            <asp:TextBox ID="FirstName" CssClass="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Last Name</label>
                            <asp:TextBox ID="LastName" CssClass="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>User Name</label>
                            <asp:TextBox ID="UserName" CssClass="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserName" ForeColor="red"
                                 runat="server" ErrorMessage="User Name is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Password</label>
                            <asp:TextBox ID="TextBoxPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxPassword" ForeColor="red"
                                 runat="server" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Confirm Password</label>
                            <asp:TextBox ID="TextBoxConfirmPassword" CssClass="form-control" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="TextBoxConfirmPassword" ControlToCompare="TextBoxPassword" Type="String"
                                 ForeColor="red" Operator="Equal" runat="server" ErrorMessage="Password Not Match"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                            <asp:TextBox ID="Email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Email" ForeColor="red"
                                 runat="server" ErrorMessage="Email is Required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" 
                            ControlToValidate="Email" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label>Phone-No</label>
                            <asp:TextBox ID="TextBoxPhone" CssClass="form-control" placeholder="Phone-No" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TextBoxPhone" ForeColor="red"
                                 runat="server" ErrorMessage="Phone-No is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Address</label>
                            <asp:TextBox ID="textArea" CssClass="form-control" Rows="3" placeholder="Address" runat="server" TextMode="MultiLine" Width="280px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="ErrorMassage" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    <p>Already a member please <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/UserLogin.aspx">Login</asp:HyperLink></p>
                    </div>
                    <div class="form-group">
                            <asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="Submit_Click" />
                    </div>
        </div>
    </div>
</asp:Content>
