<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineGrocery.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Asset/Libs/Bootstrap/css/bootstrap.min.css" />
</head>
<body>
    
    <form runat="server">
    <div class="container-fluid">
        <div class="row" style="height:90px"></div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4">
                <img src="../Asset/Images/onlinegrocery.jpg" class="img-fluid"  style="height:auto;width:100%"/>
            </div>
            <div class="col-md-4">
                <h1 class="text-danger">Sign Up</h1>
                
                 <div class="form-group">
                    <label for="EmailId">Email address</label>
                    <input type="email" class="form-control" id="EmailId" runat="server" required="required">
    
                 </div>
  <div class="form-group">
    <label for="UserPasswordTb">Password</label>
    <input type="password" class="form-control" id="UserPasswordTb" placeholder="Password" runat="server" required="required">
  </div>
  <div class="form-group form-check">
    <input type="radio" id="sellerloginid" name="Role" value="Seller" runat="server">
<label for="selleridloginid">Seller</label>
<input type="radio" id="adminloginid" name="Role" value="Admin" checked="true" runat="server">
<label for="adminloginid">Admin</label>
</div>

  <div class="mb-3 mt-3 d-grid">
      <label id="InfoMsg" runat="server" class="text-danger"></label>
    <asp:Button text="    Login    " class="btn btn-success btn-block" runat="server" OnClick="Unnamed1_Click" />
  </div>
        </div>
        </div>
                
    </div>
        </form>
</body>
</html>
