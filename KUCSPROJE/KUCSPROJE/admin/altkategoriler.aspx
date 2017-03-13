<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="altkategoriler.aspx.cs" Inherits="KUCSPROJE.admin.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 266px;
            height: 24px;
        }
        .auto-style5 {
            width: 11px;
            height: 24px;
        }
        .auto-style6 {
            height: 24px;
        }
        .auto-style7 {
            width: 266px;
            height: 50px;
        }
        .auto-style8 {
            width: 11px;
            height: 50px;
        }
        .auto-style9 {
            height: 50px;
        }
        .auto-style10 {
            width: 266px;
            height: 49px;
        }
        .auto-style11 {
            width: 11px;
            height: 49px;
        }
        .auto-style12 {
            height: 49px;
        }
        
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%">
         <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_akgoster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_akgoster_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Alt Kategori Ekleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_akekle" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4" style="text-align:center;">Kategori Adı</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddl_kadi" runat="server" Height="32px" Width="333px" ForeColor="Black" DataTextField="kategoriAd" DataValueField="kategoriID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style7" style="text-align:center;">Alt Kategori Adı</td>
            <td class="auto-style8">:</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_akadi" runat="server" Width="315px" ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7" style="text-align:center;">Resim</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                <asp:FileUpload ID="ak_resim" runat="server" Width="318px" ForeColor="White"/> 
            </td>
        </tr>
         <tr>
            <td class="auto-style10" style="text-align:center;"></td>
            <td class="auto-style11"></td>
            <td class="auto-style12">
                <asp:Button ID="btn_akkaydet" runat="server" ForeColor="Black" Text="Kaydet" OnClick="btn_akkaydet_Click" />
                <asp:Button ID="btn_iptal" runat="server" ForeColor="Black" Text="İptal" OnClick="btn_iptal_Click"  />
                
            </td>
        </tr>
       
    </table>
            </asp:Panel>
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_akgoster1" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_akgoster1_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_duzenle" runat="server" ForeColor="White" Font-Size="18px" Text="Alt Kategori Düzenleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_akguncelle" runat="server">
            <asp:GridView ID="gw_alt_kategori" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  Width="100%" AutoGenerateColumns="False" DataKeyNames="alt_kategori_ID" OnRowCommand="gw_alt_kategori_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="kategoriAd" HeaderText="Kategori Adı" />
                    <asp:BoundField DataField="alt_kategori_adi" HeaderText="Alt Kategori Adı" />
                    <asp:BoundField DataField="alt_kategori_resim" HeaderText="Alt Kategori Resmi" />
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
