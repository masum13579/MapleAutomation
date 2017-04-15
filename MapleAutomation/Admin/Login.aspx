<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MapleAutomation.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        body{
  background: #00589F;
  filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#00589F', endColorstr='#0073CF', GradientType=0);
  background: -webkit-linear-gradient(to bottom, #00589F 50%, #0073CF) !important;
  background: -moz-linear-gradient(to bottom, #00589F 50%, #0073CF) !important;
  background: -ms-linear-gradient(to bottom, #00589F 50%, #0073CF) !important;
  background: -o-linear-gradient(to bottom, #00589F 50%, #0073CF) !important;
  background: linear-gradient(to bottom, #00589F 50%, #0073CF) !important;
  color:white;
}

div.well{
  height: 250px;
} 

.Absolute-Center {
  margin: auto;
  position: absolute;
  top: 0; left: 0; bottom: 0; right: 0;
}

.Absolute-Center.is-Responsive {
  width: 50%; 
  height: 50%;
  min-width: 200px;
  max-width: 400px;
  padding: 40px;
}

#logo-container{
  margin: auto;
  margin-bottom: 10px;
  width:200px;
  height:30px;
  background-image:url('http://placehold.it/200x30/000000/ffffff/&text=BRAND+LOGO');
}
        .auto-style1 {
            display: block;
            width: 100%;
            height: 46px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #3e3f3a;
            border-radius: 4px;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            left: 0px;
            top: 0px;
            border: 1px solid #dfd7ca;
            padding: 12px 16px;
            background-color: #ffffff;
            background-image: none;
        }
    </style>
</head>
<body>
    <div class="container">
  <div class="row">
    <div class="Absolute-Center is-Responsive">
      <div id="logo-container"></div>
      <div class="col-sm-12 col-md-10 col-md-offset-1">
        <form action="" id="loginForm" runat="server">
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
              <asp:TextBox ID="UserName" CssClass="auto-style1" placeholder="username" runat="server"></asp:TextBox>   
          </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserName" 
                  runat="server" ErrorMessage="User Name is Required" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator>   
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
              <asp:TextBox ID="Password" CssClass="form-control" TextMode="Password" placeholder="password" runat="server"></asp:TextBox> 
          </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Password"
                   runat="server" ErrorMessage="Password is Required" CssClass="text-danger" Font-Size="Small"></asp:RequiredFieldValidator> 
          <div class="form-group">
              <asp:Button ID="SubmitBtn" CssClass="btn btn-def btn-block" runat="server" Text="Login" OnClick="SubmitBtn_Click" />
          </div>
            <div class="form-group">
                <asp:Label ID="ErrorMassage" runat="server" CssClass="text-danger" Font-Size="Small" Text=""></asp:Label>
            </div>
        </form>        
      </div>  
    </div>    
  </div>
</div>
</body>
</html>
