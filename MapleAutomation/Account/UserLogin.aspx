<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="MapleAutomation.Account.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row"></div>
        <div class="row">
            <div class="col-md-4"></div>

            <div class="col-md-4">
                <h2>Login.</h2>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                    <asp:TextBox ID="UserName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserName" ForeColor="red" 
                        runat="server" ErrorMessage="User Name Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Password" ForeColor="red"
                         runat="server" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="ErrorMassage" Font-Size="Small" ForeColor="Red" runat="server" Text=""></asp:Label>
                    <p>Not a member please <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Registration.aspx">Registration</asp:HyperLink></p>
                    <asp:Button ID="ButtonLogin" runat="server" CssClass="btn btn-success" Text="Login" OnClick="ButtonLogin_Click" />
                </div>
            </div>

            <div class="col-md-4"></div>
        </div>
    </div>
</asp:Content>
