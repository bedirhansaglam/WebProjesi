<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="yorum.aspx.cs" Inherits="KUCSPROJE.admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_goster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;Onaylanmayan Yorumlar</div>
        <asp:Panel ID="pnl_omayanyorum" runat="server">
            <asp:GridView ID="gw_onaysızyorumlar" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="yorumID" ForeColor="Black" GridLines="Vertical" OnRowCommand="gw_onaysızyorumlar_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="makaleBaslik" HeaderText="Makale Adı" />
                    <asp:BoundField DataField="yorumTarih" HeaderText="Tarih" />
                    <asp:BoundField DataField="yorumAdSoyad" HeaderText="Kullanıcı Adı" />
                    <asp:BoundField DataField="yorumIcerik" HeaderText="İçerik" />
                    <asp:ButtonField ButtonType="Image" CommandName="onayla" HeaderText="ONAYLA" ImageUrl="~/image/onayla.png" />
                    <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                </Columns>
                <EmptyDataTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Image ID="img_yorum" runat="server" ImageUrl='<%# Eval("yorumResim") %>'  Width="60px" Height="60px"/>
                            </td>
                            <td> 
                                <table class="auto-style1">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Font-Size="18px" ForeColor="White" Text='<%# Eval("yorumadsoyad") %>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="12px" ForeColor="White" ></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="Label"  Font-Size="12px" ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2"></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
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
