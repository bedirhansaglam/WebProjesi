<%@ Page Title="" Language="C#" MasterPageFile="~/icerik.Master" AutoEventWireup="true" CodeBehind="icerikgoster.aspx.cs" Inherits="KUCSPROJE.icerikgoster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 10%;
            height: 100px;
        }
        .auto-style3 {
            width:90%;
            height: 100px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   

    <div style="width:100%; height:auto;background-image: url('tema/arkaplan.jpg'); background-repeat: repeat-y;">
        <asp:DataList ID="dl_makaleicerik" runat="server" Width="100%">
            
            <ItemTemplate>
        <!--Başlık-->
        <div style="width:100%; height:150px; background-color:#031269;">

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("alt_kategori_resim") %>' Width="100px" Height="100px" />
                    </td>
                    <td class="auto-style3" style="font-size:28px; text-align:left; color:white;">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("makaleBaslik") %>'></asp:Label>
                    </td>
                </tr>
            </table>

           
        </div>
        <!--İÇERİK-->
        <div style=" width:100%; min-height:950px; height:auto; font-size:14px;  color:#ffffff; font-size:14px;margin-top:10px; ">
            <asp:Literal ID="Literal1" runat="server"  Text='<%# Eval("makaleicerik") %>'></asp:Literal>
        </div>
                </ItemTemplate>
                
        </asp:DataList>
    </div>
    <div style="height:30px; width:100%">
    </div>
     
     <div style="background-color:#031269; color:white; height:30px;width:100%; padding-left:20px; font-size:24px; font-weight:bold;"> YORUMLAR</div>
    <div>
        <asp:DataList ID="dl_yorumlar" runat="server" Width="100%">
            <ItemTemplate>
                 <div style="width:100%;height:10px;"></div>
                <div style="width:100%;vertical-align:top;">
                    <div style="width:60px;float:left;border: medium groove #000080;height:60px; text-align: right;">
                        <asp:Image ID="Image2" runat="server" Height="60px" ImageUrl='<%# Eval("yorumResim") %>' Width="60px" /></div>

                    <div style="width:45%;float:left;background-color:#031269;height:60px; text-align: left; color: #FFFFFF; font-family: 'Comic Sans MS'">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("yorumAdSoyad") %>' Font-Size="24px"></asp:Label>
                    </div>
                    <div style="width:45%;float:left;height:60px;text-align: right; color: #FFFFFF; background-color:#031269; padding-right: 10px;">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("yorumTarih") %>' Font-Size="14px"></asp:Label>
                    </div>
                    <div style="width:90%;text-align: center; border: thin dotted #0000FF;margin-left:6%; float:left;min-height:80px;">
                         <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("yorumIcerik") %>'></asp:Literal>
                    </div>
                </div>
                <div style="width:100%;height:10px;"></div>
                </ItemTemplate>
            </asp:DataList>
    </div>


     <div style="height:30px; width:100%">
    </div>
     <div style="background-color:#031269; color:white; height:30px;width:100%; padding-left:20px; font-size:24px; font-weight:bold;"> <asp:Button ID="btn_yorumpaneli" runat="server" ToolTip="Göster" Text="YORUM YAP" Width="100%" Height="100%" BackColor="Transparent" ForeColor="White " OnClick="btn_yorumpaneli_Click"/></div>
    
    <asp:Panel ID="pnl_yorum_yap" runat="server">
    <table class="auto-style1">
        <tr>
            <td style="width:10%"></td>
            <td style="width:90%;height:auto; min-height:400px;">
                <asp:TextBox ID="tb_yorum_icerik" runat="server" TextMode="MultiLine" Width="100%" Height="200px" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width:10%"></td>
            <td style="width:90%; text-align:right;height:60px">
                <asp:Button ID="btn_yorumyap" runat="server" Text="YORUM YAP" Width="200px" Height="80%"  ForeColor="White" BackColor="#031269" OnClick="btn_yorumyap_Click"/>
                </td>
        </tr>
    </table>
   </asp:Panel>
</asp:Content>
