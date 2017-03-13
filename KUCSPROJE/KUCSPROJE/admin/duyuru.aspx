<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="duyuru.aspx.cs" Inherits="KUCSPROJE.admin.WebForm4" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    .auto-style2 {
        width: 32px;
        height: 48px;
    }
    .auto-style3 {
        height: 49px;
    }
    .auto-style4 {
        width: 32px;
        height: 49px;
    }
    .auto-style5 {
        height: 49px;
        width: 103px;
    }
    .auto-style6 {
        width: 103px;
        height: 48px;
    }
    .auto-style7 {
        height: 50px;
        width: 103px;
    }
    .auto-style8 {
        width: 32px;
        height: 50px;
    }
    .auto-style9 {
        height: 50px;
    }
    .auto-style10 {
        height: 51px;
        width: 103px;
    }
    .auto-style11 {
        width: 32px;
        height: 51px;
    }
    .auto-style12 {
        height: 51px;
    }
    </style>
     <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
<script type="text/javascript">
    window.onload = function () {
        var editor = CKEDITOR.replace('<%=tb_dicerik.ClientID%>');
        CKFinder.setupCKEditor(editor, '../ckfinder/');
    };
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%">
         <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_duyurueklegoster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_duyurueklegoster_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Duyuru Ekleme Paneli"></asp:Label></div>
        

        <asp:Panel ID="pnl_duyuruEkle" runat="server">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7">Duyuru Başlık</td>
                    <td class="auto-style8">:</td>
                    <td class="auto-style9">
                    <asp:TextBox ID="tb_dbaslik" runat="server" ForeColor="Black"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style7">Duyuru İçerik</td>
                    <td class="auto-style8">:</td>
                    <td class="auto-style9"><asp:TextBox ID="tb_dicerik" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style9">
                        <asp:Button ID="btn_donizle" runat="server" Text="Ön İzleme" ForeColor="Black" Height="36px" Width="149px" /><asp:Button ID="btn_kaydet" runat="server" Text="Kaydet" ForeColor="Black" Height="36px" Width="149px" OnClick="btn_kaydet_Click" /><asp:Button ID="btn_iptal" runat="server" Text="İptal" ForeColor="Black" Height="36px" Width="149px" OnClick="btn_iptal_Click"  /></td>
                </tr>
              
            </table>
         </asp:Panel>

        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_dggoster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_dggoster_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_duzenle" runat="server" Text="Duyuru Güncelleme Paneli" ForeColor="White" Font-Size="18px"></asp:Label></div>

        <asp:Panel ID="pnl_duyuruguncelle" runat="server">
            <asp:GridView ID="gw_duyuruguncelle" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  Width="100%" AutoGenerateColumns="False" DataKeyNames="duyuru_id" OnRowCommand="gw_duyuruguncelle_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="d_tarih" HeaderText="Duyuru Tarih" />
                    <asp:BoundField DataField="d_baslik" HeaderText="Başlık" />
                    <asp:BoundField DataField="d_icerik" HeaderText="İçerik" />
                    <asp:ButtonField ButtonType="Image" HeaderText="Sil" ImageUrl="~/image/delete.png" CommandName="sil" />
                    <asp:ButtonField ButtonType="Image" HeaderText="Güncelle" ImageUrl="~/image/update.png" CommandName="guncelle" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>

         </div>

    
</asp:Content>
