<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="KUCSPROJE.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style15 {
            height: 60px;
        }
        .auto-style16 {
            width: 145px;
            height: 61px;
        }
        .auto-style17 {
            height: 61px;
        }
        .auto-style18 {
            width: 145px;
            height: 60px;
        }
        .auto-style20 {
            width: 8px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%">
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_goster1" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Kategori Ekleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_kategoriEkle" runat="server">
          <table class="auto-style1">
        <tr>
            <td class="auto-style18" style="text-align: center">Kategori Adı</td>
            <td class="auto-style20">:</td>
            <td class="auto-style15"><asp:TextBox ID="ktg_adi" runat="server" Height="27px" Width="320px" ForeColor="Black"></asp:TextBox></td>
        </tr>
   
        <tr>
            <td class="auto-style18" style="text-align: center">Resim</td>
            <td class="auto-style20">:</td>
            <td class="auto-style15"><asp:FileUpload ID="ktg_resim" runat="server" Height="32px" Width="326px" ForeColor="White" /></td>
        </tr>
         <tr>
            <td class="auto-style18" style="text-align: center"></td>
             <td class="auto-style20"></td>
            <td class="auto-style15">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btn_kaydet" runat="server" Text="Kaydet" Height="43px" Width="114px"  ForeColor="Black" OnClick="btn_kaydet_Click"/> <asp:Button ID="btn_iptal" runat="server" Text="İptal" Height="43px" Width="114px"  ForeColor="Black" OnClick="btn_iptal_Click" /> </td>
             
        </tr>
    </table>
            </asp:Panel>

        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_goster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="White" Font-Size="18px" Text="Kategori Düzenleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_kategoriDuzenle" runat="server">
             <table class="auto-style1">
        <tr>
            <td>
                <asp:GridView ID="gw_kategori" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="42px" Width="1292px" OnRowCommand="gw_kategori_RowCommand"  DataKeyNames="kategoriID">
                    <Columns>
                        <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                        <asp:ButtonField ButtonType="Image" CommandName="yukari" HeaderText="Yukarı" ImageUrl="~/image/up.png" />
                        <asp:ButtonField ButtonType="Image" CommandName="asagi" HeaderText="Aşağı" ImageUrl="~/image/down.png" />
                        <asp:BoundField DataField="kategoriAd" HeaderText="Kategori Adı" />
                        <asp:BoundField DataField="kategoriSıra" HeaderText="Kategori Sıra" />
                        <asp:BoundField DataField="kategoriResim" HeaderText="Kategori Resim" />
                        <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                        <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="GÜNCELLE" ImageUrl="~/image/update.png" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
    </table>
        </asp:Panel>
    </div>
  
   
  
   
  
   
  
</asp:Content>
