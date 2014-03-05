<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="login">
            <h1>
                Login to Web App</h1>
            <p>
                <asp:Label ID="lblMsgtext" runat="server" Text="" Font-Bold="true"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="txtEmailId" runat="server" Width="280px" MaxLength="100" CssClass="textboxLogin"
                    placeholder="Email"></asp:TextBox></p>
            <p>
                <asp:TextBox ID="txtPassword" runat="server" Width="280px" MaxLength="50" CssClass="textboxLogin"
                    TextMode="Password" placeholder="Password"></asp:TextBox></p>
            <p class="remember_me">
                <label>
                    <asp:CheckBox ID="chkRememberMe" runat="server" />
                    Remember me on this computer
                </label>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Log In" CssClass="submit" OnClick="btnSubmit_Click"
                    OnClientClick="return validateForm();" />
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="submit" Style="float: right;"
                    OnClick="btnRegister_Click" /></p>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function validateForm() {
            var email = document.getElementById('<%=txtEmailId.ClientID   %>').value;
            var pwd = document.getElementById('<%=txtPassword.ClientID   %>').value;
            if (email == '') {
                alert("Please enter email id");
                return false;
            }

            var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
            if (reg.test(email)) {
            }
            else {
                alert("Please enter valid email id");
                return false;
            }

            if (pwd == '') {
                alert("Please enter password");
                return false;
            }
            return true;
        }
    </script>
    </form>
</body>
</html>
