<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="reklam.aspx.cs" Inherits="KUCSPROJE.admin.reklam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 8px;
            height: 54px;
        }
        .auto-style3 {
            width: 292px;
            height: 54px;
            text-align:center;
        }
        .auto-style4 {
            height: 54px;
        }
        .textbox {
            color:#000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%">
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_goster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Reklam Ekleme Paneli"></asp:Label></div>

        <asp:Panel ID="pnl_ekle" runat="server">
             <table class="auto-style1">
        <tr>
            <td class="auto-style3">Reklam Resmi</td>
            <td class="auto-style2">:</td>
            <td class="auto-style4"><asp:FileUpload ID="fl_resim" runat="server" />
                </td>
        </tr>
                 <tr>
            <td class="auto-style3">İnternet Adresi</td>
            <td class="auto-style2">:</td>
            <td class="auto-style4"> <asp:TextBox ID="tb_url" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
                  <tr>
            <td class="auto-style3">Alternatif Text</td>
            <td class="auto-style2">:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tb_atext" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
                  <tr>
            <td class="auto-style3">Anahtar Kelime(Keyword)</td>
            <td class="auto-style2">:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tb_keyword" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
                  <tr>
            <td class="auto-style3"></td>
            <td class="auto-style2"></td>
            <td class="auto-style4">
                <asp:Button ID="btn_kaydet" runat="server" Text="Kaydet" ForeColor="Black" Height="40px" Width="200px" OnClick="btn_kaydet_Click" />
                <asp:Button ID="btn_iptal" runat="server" Text="İptal" ForeColor="Black" Height="40px" Width="200px" OnClick="btn_iptal_Click" />
                </td>
        </tr>
    </table>
        </asp:Panel>
       
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_goster1" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster1_Click"    />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="White" Font-Size="18px" Text="Reklam Düzenleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_duzenle" runat="server">
            <asp:GridView ID="gw_reklamlar" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="reklam_id" ForeColor="Black" GridLines="Vertical" OnRowCommand="gw_reklamlar_RowCommand">

                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:ImageField DataImageUrlField="resim" HeaderText="RESİM">
                        <ControlStyle Height="200px" Width="200px" />
                        <ItemStyle Height="200px" Width="200px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="link" HeaderText="URL" />
                    <asp:BoundField DataField="text" HeaderText="ALTERNATİF TEXT" />
                    <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                    <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="GÜNCELLE" ImageUrl="~/image/update.png" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />

            </asp:GridView>
        </asp:Panel>

         </div>

   
</asp:Content>
