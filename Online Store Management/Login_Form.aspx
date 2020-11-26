<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_Form.aspx.cs" Inherits="Login_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form | Online Store Management</title>
    <link rel="icon" type="image/png" sizes="16x16" href="Images/Online_Store.png">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
    <style type="text/css">
        body
        {
            /*background-color: #06213F !important;*/
        }

        .login-form
        {
            margin-top: 80px;
            border: 1px solid gray;
            border-radius: 3px;
            background: white;
        }

        .title
        {
            background: #17A2B8;
            text-align: center;
            color: #fff;
            border-radius: 0px 0px 8px 8px;
            padding-bottom:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-form col-md-4 offset-md-4">
                <h1 class="title">Login Here</h1>
                <div class="form-group">
                    <asp:Label ID="lblUser" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-success" OnClick="btnInsert_Click" />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info" OnClick="btnLogin_Click" />
       
                </div>
                <div class="form-group">
                    <asp:Button ID="linkforpass" runat="server" Text="Forgot password?" CssClass="btn btn-link" />
                    <%--<asp:Button ID="createlink" runat="server" Text="Create new account?" CssClass="btn btn-link" />--%>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>
</body>
</html>
