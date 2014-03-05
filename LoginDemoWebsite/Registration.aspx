<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="containerRegistration">
            <div class="login">
                <h1>
                    Registration for New users</h1>
                <p>
                    <asp:Label ID="lblMsgtext" runat="server" Text="" Font-Bold="true"></asp:Label>
                </p>
                <p>
                    <div class="leftBlock">
                        First Name <span style="color: Red; font-weight: bold">* </span>
                    </div>
                    <div class="rightBlock">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="280px" MaxLength="100" CssClass="textboxLogin"></asp:TextBox></div>
                </p>
                <p>
                    <div class="leftBlock">
                        Last Name
                    </div>
                    <div class="rightBlock">
                        <asp:TextBox ID="txtLastName" runat="server" Width="280px" MaxLength="100" CssClass="textboxLogin"></asp:TextBox></div>
                </p>
                <p>
                    <div class="leftBlock">
                        Email Id  <span style="color: Red; font-weight: bold">* </span>
                    </div>
                    <div class="rightBlock">
                        <asp:TextBox ID="txtEmailId" runat="server" Width="280px" MaxLength="100" CssClass="textboxLogin"></asp:TextBox></div>
                </p>
                <p>
                    <div class="leftBlock">
                        Password  <span style="color: Red; font-weight: bold">* </span>
                    </div>
                    <div class="rightBlock">
                        <asp:TextBox ID="txtPassword" runat="server" Width="280px" MaxLength="100" CssClass="textboxLogin"
                            TextMode="Password"></asp:TextBox></div>
                </p>
                <p>
                    <div class="leftBlock">
                        Confirm Password  <span style="color: Red; font-weight: bold">* </span>
                    </div>
                    <div class="rightBlock">
                        <asp:TextBox ID="txtConfimPassword" runat="server" Width="280px" MaxLength="100"
                            TextMode="Password" CssClass="textboxLogin"></asp:TextBox></div>
                </p>
                <p>
                    <div class="leftBlock">
                        Phone number
                    </div>
                    <div class="rightBlock">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" Width="280px" MaxLength="100" CssClass="textboxLogin"></asp:TextBox></div>
                </p>
                <%--<p>
                    <asp:TextBox ID="txtPassword" runat="server" Width="280px" MaxLength="50" CssClass="textboxLogin"
                        placeholder="Password"></asp:TextBox></p>--%>
                <%--<p class="remember_me">
                    <label>
                        <asp:CheckBox ID="chkRememberMe" runat="server" />
                        Remember me on this computer
                    </label>
                </p>--%>
                <p>
                    &nbsp;</p>
                <p style="text-align: center;">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="submit" Style=""
                        OnClick="btnRegister_Click" OnClientClick="return validateForm();" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="submit" Style=""
                        OnClick="btnCancel_Click" />
                </p>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function validateForm() {


            var firstname = document.getElementById('<%=txtFirstName.ClientID   %>').value;
            var email = document.getElementById('<%=txtEmailId.ClientID   %>').value;
            var pwd = document.getElementById('<%=txtPassword.ClientID   %>').value;
            var confirmpwd = document.getElementById('<%=txtConfimPassword.ClientID   %>').value;

            if (firstname == '') {
                alert("Please enter First Name");
                return false;
            }

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
            if (confirmpwd == '') {
                alert("Please enter confirm password");
                return false;
            }

            if (pwd != confirmpwd) {
                alert("Password and confirm password are not matched.");
                return false;
            }

            if (pwd.length < 6) {
                alert("Password should not be less than 6 characters.");
                return false;
            }

            return true;
        }
    </script>
    </form>
</body>
</html>
