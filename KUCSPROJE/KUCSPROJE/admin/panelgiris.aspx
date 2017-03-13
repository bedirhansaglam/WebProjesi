<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panelgiris.aspx.cs" Inherits="KUCSPROJE.admin.panelgiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>KUCS Admin Panel Giriş</title>
    <link href="../css/style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 105%;
            height: 279px;
        }
        .auto-style2 {
            width: 10px;
        }
        .auto-style3 {
            width: 117px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="login">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Kullanıcı Adı</td>
                <td class="auto-style2">:</td>
                <td> <asp:TextBox ID="tb_ka" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style3">Şifre</td>
                <td class="auto-style2">:</td>
                <td> <asp:TextBox ID="tb_sf" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td><p class="forgot-password"><a href="sifreunuttum.aspx">Şifrenimi unuttun?</a></p>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="btn_giris" runat="server" CssClass="login-button" OnClick="btn_giris_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
