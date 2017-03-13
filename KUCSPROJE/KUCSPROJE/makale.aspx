<%@ Page Title="" Language="C#" MasterPageFile="~/users/user.Master" AutoEventWireup="true" CodeBehind="makale.aspx.cs" Inherits="KUCSPROJE.users.makale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%; height:100px"></div>

    <div style="width:100%; height:auto;">
        <asp:DataList ID="dl_makale" runat="server">
            <ItemTemplate>
                <div style="width:90% ;margin:0 auto; height:auto;">

                     <!-- baslik-->
                <div style="border: thick ridge #000000; width:90%; height:40px; float:left; background-color:#071fa8">
                <div style="width:40px; height:40px; float:left;">
                    <asp:Image ID="img_kategori" runat="server" Height="40px" Width="40px" ImageUrl='<%# Eval("alt_kategori_resim") %>'   />
                </div>
                <div style="width:80%; height:40px; float:left;">
                    <asp:Label ID="lbl_baslik" runat="server" Font-Size="36px" ForeColor="White" Text='<%# Eval("makaleBaslik") %>'></asp:Label>
                </div>
                </div>
                <!-- ozet-->
                <div style="border-style: none outset none outset; border-width: thick; border-color: #000000; float:left; height:auto; width:90%; background-color:#ffffff; padding-bottom:10px;">
                    <asp:Label ID="lbl_ozet" runat="server" Text='<%# Eval("makaleOzet") %>'></asp:Label><a href='<%#Eval("makaleID","/icerikgoster.aspx?makaleid={0}") %>'> devamını gör</a>

                </div>
                <!-- tarih-->
                <div style="border-style: none outset outset outset; border-width: thick; border-color: #000000; width:90%; height:20px; line-height:20px; font-size:12px; float:left; background-color:#fdfcba">
                    <div style="width:auto; height:20px;float:left; margin-right:15px;">
                        <asp:Image ID="img_tarih" runat="server" ImageUrl="~/image/saat.png" Width="12px" Height="12px" /><asp:Label ID="lbl_tarih" runat="server" Text='<%# Eval("makaleTarih") %>'></asp:Label>
                    </div>
                    <div style="width:auto; height:20px;float:left;margin-right:15px;">
                        <asp:Image ID="img_okunma" runat="server" ImageUrl="~/image/goruntulenme.png" Width="12px" Height="12px" /> <asp:Label ID="lbl_okunma" runat="server" Text='<%# Eval("makaleOkunma") %>'></asp:Label>
                    </div>
                    <div style="width:auto; height:20px;float:left;margin-right:15px;">
                        <asp:Image ID="img_yorum" runat="server" ImageUrl="~/image/yorum.png" Width="12px" Height="12px"/>  <asp:Label ID="lbl_yorum" runat="server" Text='<%# Eval("makaleYorumSayisi") %>'></asp:Label>
                    </div>
                </div>
                    <div style="width:100%; height:40px; float:left;">

                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
       
       
    </div>
</asp:Content>
