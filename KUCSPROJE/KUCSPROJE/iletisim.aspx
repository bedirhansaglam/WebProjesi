<%@ Page Title="" Language="C#" MasterPageFile="~/users/user.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="KUCSPROJE.iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style13 {
            width: 124px;
        }
        .auto-style14 {
            width: 124px;
            height: 46px;
        }
        .auto-style15 {
            height: 46px;
        }
        .auto-style16 {
            width: 124px;
            height: 44px;
        }
        .auto-style17 {
            height: 44px;
        }
        .auto-style18 {
            height: 46px;
            width: 8px;
        }
        .auto-style19 {
            height: 44px;
            width: 8px;
        }
        .auto-style20 {
            width: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>


        <div style="width:100%; height:40px; background-color:#031269;padding-left:20px; color:white;">
            <asp:Label ID="Label1" runat="server" Text="İLETİŞİM" Font-Size="32px"></asp:Label> </div>
        <div style="width:100%;height:20px;"></div>
        <table class="auto-style11">
            <tr>
                <td class="auto-style14" style="padding-left:20px"><asp:Label ID="lbl_Ad" runat="server" Text="AD SOYAD"></asp:Label></td>
                <td class="auto-style18">:</td>
                <td class="auto-style15"><asp:TextBox ID="tb_adsoyad" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style16"  style="padding-left:20px"> <asp:Label ID="Label4" runat="server" Text="E-MAİL" ></asp:Label></td>
                <td class="auto-style19">:</td>
                <td class="auto-style17"><asp:TextBox ID="tb_mail" runat="server" TextMode="Email" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_mail" ErrorMessage="Geçerli bir e-mail giriniz" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13"  style="padding-left:20px"><asp:Label ID="lbl_mesaj" runat="server" Text="MESAJ :"></asp:Label></td>
                <td class="auto-style20"></td>
                <td> </td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td style="max-height:300px; height:300px"><asp:TextBox ID="tb_micerik" runat="server" TextMode="MultiLine" Height="300px" Width="97%"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td style="max-height:50px; height:50px; text-align:right;padding-right:20px"> <asp:Button ID="btn_gonder" runat="server" Text="MESAJ GÖNDER" ForeColor="White" BackColor="#031269" Width="200px" Height="80%" OnClick="btn_gonder_Click" /></td>
            </tr>
        </table>
            
    </div>
</asp:Content>
