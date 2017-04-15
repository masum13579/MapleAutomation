<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MapleAutomation.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #googleMap {
            width: 100%;
            height: 400px;
            -webkit-filter: grayscale(100%);
            filter: grayscale(100%);
        }
    </style>
    <div class="container">
        <div class="row">
            <h3 class="text-center">Contact</h3>
            <p class="text-center"><em>We love our clint!</em></p>
            <div class="row test">
                <div class="col-md-4">
                    <p>Clint? Drop a note.</p>
                    <p><span class="glyphicon glyphicon-map-marker"></span>Dhaka, Bangladesh</p>
                    <p><span class="glyphicon glyphicon-phone"></span>Phone: +880 1726808356</p>
                    <p><span class="glyphicon glyphicon-envelope"></span>Email: mail@mail.com</p>
                </div>
                <div class="col-md-8">
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="Name" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required" ControlToValidate="Name" CssClass="text-danger" Font-Size="Smaller"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="Email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is Required" ControlToValidate="Email" CssClass="text-danger" Font-Size="Smaller" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" CssClass="text-danger" Display="Dynamic" ErrorMessage="email format invalid" Font-Size="Smaller" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="Mobile" CssClass="form-control" placeholder="Phone-No" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Phone-No is Required" ControlToValidate="Mobile" CssClass="text-danger" Font-Size="Smaller"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:TextBox ID="Subject" CssClass="form-control" placeholder="Subject" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Subject is Required" ControlToValidate="Subject" CssClass="text-danger" Font-Size="Smaller"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:TextBox ID="Comment" CssClass="form-control" placeholder="Comment" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Comment is Required" ControlToValidate="Comment" CssClass="text-danger" Font-Size="Smaller"></asp:RequiredFieldValidator>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Label ID="Massage" CssClass="pull-right text-success" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-12 form-group">
                            <asp:Button ID="Submit" CssClass="btn pull-right" runat="server" Text="Send" OnClick="Submit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="googleMap"></div>

            <!-- Add Google Maps -->
            <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDTH-7zLhtkqxbTlhiLXWxxdujaLSgrOgs"></script>
            <script>
                var myCenter = new google.maps.LatLng(23.7807603, 90.3548649);

                function initialize() {
                    var mapProp = {
                        center: myCenter,
                        zoom: 12,
                        scrollwheel: false,
                        draggable: true,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };

                    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

                    var marker = new google.maps.Marker({
                        position: myCenter,
                    });

                    marker.setMap(map);
                }

                google.maps.event.addDomListener(window, 'load', initialize);
            </script>
        </div>
    </div>
</asp:Content>
