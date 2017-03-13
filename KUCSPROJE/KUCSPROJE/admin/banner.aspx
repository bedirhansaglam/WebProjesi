<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="KUCSPROJE.admin.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .bir {height:50px; padding-left:20px; text-align:center;
        }
        .iki {width:1%;height:50px;
        }
        .uc {width:79%;height:50px;
        }
        .textbox {
            height:80%;
            width:25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:100%">
         <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_banner" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_banner_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Banner Güncelleme Paneli"></asp:Label></div>
        
         <asp:Panel ID="pnl_bannerekle" runat="server">
          <table class="auto-style1">
              <tr>
                  <td class="bir">SOL RESİM</td>
                  <td class="iki">:</td>
                  <td class="uc"> 
                      <asp:FileUpload ID="fu_solresim" runat="server" CssClass="textbox" /></td>
              </tr>
              <tr>
                  <td class="bir">SAĞ RESİM</td>
                  <td class="iki">:</td>
                  <td class="uc">
                      <asp:FileUpload ID="fu_sagresim" runat="server" CssClass="textbox" /></td>
              </tr>
              <tr>
                  <td class="bir">YAZI</td>
                  <td class="iki">:</td>
                  <td class="uc">
                      <asp:TextBox ID="tb_label" runat="server" CssClass="textbox" ForeColor="Black"></asp:TextBox></td>
              </tr>
              <tr>
                  <td class="bir"></td>
                  <td class="iki"></td>
                  <td class="uc" style="text-align:center">
                      <asp:ImageButton ID="ibtn_kaydet" runat="server" ImageUrl="~/image/save.png" OnClick="ibtn_kaydet_Click" />
                      </td>
              </tr>
              <tr>
                  <td class="bir">&nbsp;</td>
                  <td class="iki">&nbsp;</td>
                  <td class="uc" style="text-align:center">&nbsp;</td>
              </tr>
              <tr>
                  <td class="bir">&nbsp;</td>
                  <td class="iki">&nbsp;</td>
                  <td class="uc" style="text-align:center">&nbsp;</td>
              </tr>
              <tr>
                  <td class="bir" colspan="3">
                      <asp:GridView ID="gw_banner" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" DataKeyNames="banner_id" OnSelectedIndexChanged="gw_banner_SelectedIndexChanged">
                          <AlternatingRowStyle BackColor="#CCCCCC" />
                          <Columns>
                              <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                              <asp:ImageField DataImageUrlField="banner_resim" HeaderText="SOL RESİM">
                                  <ControlStyle Height="200px" Width="200px" />
                                  <ItemStyle Height="100px" Width="100px" />
                              </asp:ImageField>
                              <asp:BoundField DataField="banner_yazi" HeaderText="YAZI" />
                              <asp:ImageField DataImageUrlField="banner_resimiki" HeaderText="SAĞ RESİM">
                                  <ControlStyle Height="200px" Width="400px" />
                                  <ItemStyle Height="100px" Width="100px" />
                              </asp:ImageField>
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
                  </td>
              </tr>
         </table>
        </asp:Panel>

          </div>
</asp:Content>
