<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="mesajlar.aspx.cs" Inherits="KUCSPROJE.admin.mesajlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 215px;
            height: 60px;
        }
        .auto-style3 {
            width: 10px;
            height: 60px;
        }
        .auto-style4 {
            height: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000; padding-left:20px; font-size:30px;" >
        <asp:Label ID="lbl_gelen" runat="server" Text="GELEN KUTUSU"></asp:Label>
    </div>
    <div style="width:100%; height:200px; overflow:scroll;">
    <asp:GridView ID="gw_gelen_mesajlar" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="iletisimID" ForeColor="Black" GridLines="Vertical" OnRowCommand="gw_gelen_mesajlar_RowCommand" OnSelectedIndexChanged="gw_gelen_mesajlar_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="iletisimTarih" HeaderText="TARİH" />
            <asp:BoundField DataField="iletisimAdSoyad" HeaderText="AD SOYAD" />
            <asp:BoundField DataField="iletisimEmail" HeaderText="E - MAİL" />
            <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView></div>
    <asp:Panel ID="pnl_mesaj" runat="server">
    <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000; padding-left:20px; font-size:30px;" >
        <asp:Label ID="lbl" runat="server" Text="MESAJ"></asp:Label>
    </div>
    <asp:DataList ID="dl_mesaj" runat="server" Width="100%">
        <ItemTemplate>
            <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="AD SOYAD"></asp:Label></td>
            <td class="auto-style3">:</td>
            <td class="auto-style4">
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("iletisimAdSoyad") %>'></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="E-MAİL"></asp:Label></td>
            <td class="auto-style3">:</td>
            <td class="auto-style4">
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("iletisimEmail") %>'></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="MESAJ"></asp:Label></td>
            <td class="auto-style3">:</td>
            <td class="auto-style4"><asp:Literal ID="Literal1" runat="server" Text='<%# Eval("iletisimicerik") %>'></asp:Literal>
                </td>
        </tr>
     
    </table>

        </ItemTemplate>
    </asp:DataList>
    </asp:Panel>
</asp:Content>
