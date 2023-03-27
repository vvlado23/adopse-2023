<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="Style1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="Title">Login</div>
        <div class="User">Username:</div>
        <div class="Pass">Password:</div>
        <asp:Image ID="Image3" class="Logo" runat="server" />

        <div>
            <asp:TextBox class="UT" ID="Username" placeholder="Type your username" runat="server"/>
            <asp:Image ID="Image1"  class="img1" runat="server" />
        </div>

        <div>
            <asp:TextBox class="PT" ID="Password" placeholder="Type your password" runat="server"/>
            <asp:Image ID="Image2" class="img2" runat="server" />   

        </div> 
        
            <asp:Button ID="Button1" class="Log"  runat="server" Text="Login" />
            <asp:Button ID="Button2" class="Reg"  runat="server" Text="Register" />
        
    </form>
</body>
</html>
