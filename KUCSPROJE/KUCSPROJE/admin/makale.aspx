<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="makale.aspx.cs" Inherits="KUCSPROJE.admin.WebForm2" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            width: 6px;
            height: 50px;
        }
        .auto-style6 {
            height: 50px;
        }
        .auto-style7 {
            width: 204px;
            height: 50px;
        }
    </style>
    <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
<script type="text/javascript">
    window.onload = function () {
        var editor = CKEDITOR.replace('<%=tb_icerik.ClientID%>');
            CKFinder.setupCKEditor(editor, '../ckfinder/');
        };
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%;width:100%">
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
           <asp:ImageButton ID="ibtn_me_goster1" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_me_goster1_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" Text="Makale Ekleme Paneli" ForeColor="White" Font-Size="18px"></asp:Label></div>

    
    <asp:Panel ID="pnl_makaleEkle" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style7" style="text-align:center">Makale Kategori</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddl_kategori" runat="server" DataTextField="alt_kategori_adi" DataValueField="alt_kategori_ID" ForeColor="Black" Height="30px" Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style7" style="text-align:center">Makale Başlık</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_baslik" runat="server" ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7" style="text-align:center">Makale Özet</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_ozet" runat="server" Height="259px" TextMode="MultiLine" Width="693px" ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7" style="text-align:center">Makale İçerik</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_icerik" runat="server" Height="566px" TextMode="MultiLine" Width="1317px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"style="text-align:center">Slider</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:FileUpload ID="m_resim" runat="server" ForeColor="White" /></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Button ID="btn_mekle" runat="server" Text="Kaydet" ForeColor="Black" Height="36px" Width="150px" OnClick="btn_mekle_Click" />
                <asp:Button ID="btn_iptal" runat="server" Text="İptal" ForeColor="Black" Height="36px" Width="150px" OnClick="btn_iptal_Click"  />
            </td>
        </tr>
    </table></asp:Panel>

         <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
           <asp:ImageButton ID="ibtn_me_goster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_me_goster_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_duzenle" runat="server" ForeColor="White" Font-Size="18px" Text="Makale Düzenleme Paneli"></asp:Label></div>

        <asp:Panel ID="pnl_mduzenle" runat="server">
       <asp:GridView ID="gw_mduzenle" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" DataKeyNames="makaleID" AutoGenerateColumns="False" OnRowCommand="gw_mduzenle_RowCommand">
           <AlternatingRowStyle BackColor="#CCCCCC" />
           <Columns>
               <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
               <asp:BoundField DataField="makaleBaslik" HeaderText="Makale Başlık" />
               <asp:BoundField DataField="makaleOzet" HeaderText="Makale Özet" />
               <asp:BoundField DataField="makaleicerik" HeaderText="Makale İçerik" />
               <asp:BoundField DataField="makaleResim" HeaderText="Makale Resim" />
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
