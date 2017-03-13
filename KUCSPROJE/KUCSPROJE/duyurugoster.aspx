<%@ Page Title="" Language="C#" MasterPageFile="~/users/user.Master" AutoEventWireup="true" CodeBehind="duyurugoster.aspx.cs" Inherits="KUCSPROJE.duyurugoster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%; height:auto">
        <asp:DataList ID="dl_duyuru" runat="server" Width="100%">
            
            <ItemTemplate>
        <!--Başlık-->
        <div style="width:100%; height:60px; background-color:#092be9; text-align:center;">
            <asp:Label ID="lbl_baslik" runat="server" Font-Size="32px" ForeColor="White" Text='<%# Eval("d_baslik") %>'></asp:Label>
        </div>
        <!--İÇERİK-->
        <div style=" width:100%; height:auto; font-size:14px; background-image: url('tema/arkaplan.jpg'); background-repeat: repeat-y; color:#ffffff;">
            <asp:Literal ID="Literal1" runat="server"  Text='<%# Eval("d_icerik") %>'></asp:Literal>
        </div>
                <!--Tarih-->
                <div style="width:100%; height:30px; background-color:#092be9; text-align:right; color:#ffffff;">
                    <asp:Label ID="lbl_tarih" runat="server" Text='<%# Eval("d_tarih") %>'></asp:Label>
                </div>
                </ItemTemplate>
                
        </asp:DataList>
    </div>

</asp:Content>
