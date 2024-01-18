<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logon.aspx.vb" Inherits="SGM_WEB.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SGM - (Sistema de Gerenciamento de Manufatura)</title>

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />

</head>

<body>
    <script>
        var imageList = ['image1.jpg', 'image2.jpg', 'image3.jpg', 'image4.jpg', 'image5.jpg'];
        var randomIndex = Math.floor(Math.random() * imageList.length);
        var randomImage = imageList[randomIndex];
        document.body.style.backgroundImage = "url('images/backgroud/" + randomImage + "')";
    </script>
    <form id="form1" runat="server">
        <div class="background">
            <div class="card">
                <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    <Scripts>
                        <%--Framework scripts--%>
                        <asp:ScriptReference Name="jquery" />
                        <asp:ScriptReference Name="jquery.ui.combined" />
                        <%--Site scripts--%>
                    </Scripts>
                </ajaxToolkit:ToolkitScriptManager>
                <asp:Label ID="Label1" runat="server" Text="<span>•</span> SGM WEB <span>•</span>" ForeColor="White" Font-Bold="true" Font-Size="60px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Bem-vindo!" ForeColor="White" Font-Bold="false" Font-Size="20px"></asp:Label><br />
                <asp:Label ID="Erro1" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label><br />
                <div class="inputGroup">
                    <input type="text" name="username" class="username" id="txtUserName" required="" autocomplete="off" runat="server" />
                    <label for="txtUserName">Registro</label>
                </div>
                <br />
                <div class="inputGroup">
                    <input type="password" name="password" class="password" id="txtUserPass" required="" autocomplete="off" runat="server" />
                    <label for="name">Senha</label>
                </div>
                <asp:RequiredFieldValidator ControlToValidate="txtUserPass" Display="Static" ErrorMessage="*" runat="server" ID="vUserPass" />
                <br />
                <asp:Button Text="Entrar" runat="server" ID="cmdLogin1" CssClass="button-login" Font-Bold="true" />
                <br />
                <br />
                <asp:Label ID="Erro" runat="server" ForeColor="Red" Font-Size="Small" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
