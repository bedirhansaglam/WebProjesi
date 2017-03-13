<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="etkinlik.aspx.cs" Inherits="KUCSPROJE.admin.WebForm5" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 240px;
            height: 50px;
        }
        .auto-style3 {
            width: 10px;
            height: 50px;
        }
        .auto-style4 {
            height: 50px;
        }
    </style>
         <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
<script type="text/javascript">
    window.onload = function () {
        var editor = CKEDITOR.replace('<%=tb_eicerik.ClientID%>');
        CKFinder.setupCKEditor(editor, '../ckfinder/');
    };
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_egoster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_egoster_Click"   />&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_ekle" runat="server" Font-Size="18px" Text="Etkinlik Ekleme Paneli" ForeColor="White"></asp:Label></div>
        <asp:Panel ID="pnl_eekle" runat="server">
            <table class="auto-style1">
                 <tr>
                     <td class="auto-style2" style="text-align:center">Etkinlik Başlık</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="tb_ebaslik" runat="server" ForeColor="Black"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td class="auto-style2" style="text-align:center">Etkinlik İçerik</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="tb_eicerik" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td class="auto-style2"></td>
                     <td class="auto-style3"></td>
                     <td class="auto-style4">
                         <asp:Button ID="btn_eonizleme" runat="server" Text="Ön İzleme" ForeColor="Black" Height="35px" Width="150px"  />
                         <asp:Button ID="btn_ekaydet" runat="server" Text="Kaydet" ForeColor="Black" Height="35px" Width="150px" OnClick="btn_ekaydet_Click" />
                         <asp:Button ID="btn_eiptal" runat="server" Text="İptal" ForeColor="Black" Height="35px" Width="150px" OnClick="btn_eiptal_Click" />
                     </td>
                 </tr>
             </table>
        </asp:Panel>
         <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_egoster2" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_egoster2_Click"   />&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_duzenle" runat="server" Text="Etkinlik Düzenleme Paneli" Font-Size="18px" ForeColor="White"></asp:Label></div>
        <asp:Panel ID="pnl_eduzenle" runat="server">
            <asp:GridView ID="gw_eduzenle" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" AutoGenerateColumns="False" DataKeyNames="etkinlik_id" OnRowCommand="gw_eduzenle_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="e_tarih" HeaderText="Etkinlik Tarih" />
                    <asp:BoundField DataField="e_baslik" HeaderText="Başlık" />
                    <asp:BoundField DataField="e_icerik" HeaderText="İçerik" />
                    <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="Sil" ImageUrl="~/image/delete.png" />
                    <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="Güncelle" ImageUrl="~/image/update.png" />
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
