<%@ Page Title="" Language="C#" MasterPageFile="~/icerik.Master" AutoEventWireup="true" CodeBehind="uyeol.aspx.cs" Inherits="KUCSPROJE.uyeol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .birinci {
            width:20%;
            height:60px;
            padding-left:20px;
        }
        .ikinci {
             width:1%;
            height:60px;
        }
        .ucuncu {
            width:79%;
            height:60px;
        }
        .textbox {
            height:60%;
            width:35%;
           
        }
    </style>
    <script>
     $(document).ready(function (){
    $("input").focusout(function () {
                $(this).css("background-color", "#ffffff");
            });
            $("input").focusin(function () {
                $(this).css("background-color", "#8e9dfa");
            });
     })</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%; min-height:950px; max-height:950px; ">
         <asp:Panel ID="pnl_profilbilgileri" runat="server">
        <div style="width:100%; height:50px; background-color:#031269; color:white; padding-left:20px;">
            <asp:Label ID="Label16" runat="server" Text="PROFİL" Font-Size="32px" ></asp:Label>
        </div>
        <div style="width:100%; height:auto;margin-top:30px; color:#031269;">


            <asp:DataList ID="dl_pbilgileri" runat="server" Width="100%">
                <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label17" runat="server" Text="RESİM"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu" style="height:150px;">
                        <asp:Image ID="img_profilresmi" runat="server" Width="80px" Height="80px" ImageUrl='<%# Eval("resim") %>' /> </td>
                </tr>

                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label18" runat="server" Text="KULLANICI ADI"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:Label ID="lbl_27" runat="server" Text='<%# Eval("kadi") %>'></asp:Label></td>
                </tr>
               
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label21" runat="server" Text="AD"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:Label ID="Label19" runat="server" Text='<%# Eval("ad") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label22" runat="server" Text="SOYAD"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:Label ID="Label20" runat="server" Text='<%# Eval("soyad") %>'></asp:Label></td>
                </tr>
                   <tr>
                    <td class="birinci">
                        <asp:Label ID="Label23" runat="server" Text="E-MAİL"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:Label ID="Label27" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                       </td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label26" runat="server" Text="TELEFON"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:Label ID="Label24" runat="server" Text='<%# Eval("telefon") %>'></asp:Label></td>
                </tr>
            </table>
            </ItemTemplate>
            </asp:DataList>
            <table class="auto-style1">
                <tr>
                    <td class="birinci">
                        &nbsp;</td>
                    <td class="ikinci">&nbsp;</td>
                    <td class="ucuncu" style="text-align:center;">
                        <asp:Button ID="btn_şifre_değiş" runat="server" Text="ŞİFRE DEĞİŞTİR" OnClick="btn_şifre_değiş_Click" />&nbsp&nbsp<asp:Button ID="btn_bilgiduzenle" runat="server" Text="PROFİL BİLGİLERİNİ DÜZENLE" OnClick="btn_bilgiduzenle_Click" />
                    </td>
                </tr>
            </table>
        </div>
            </asp:Panel>

        <asp:Panel ID="pnl_uye_ol" runat="server">
        <div style="width:100%; height:50px; background-color:#031269; color:white; padding-left:20px;">
            <asp:Label ID="Label1" runat="server" Text="KAYIT FORMU" Font-Size="32px" ></asp:Label>
        </div>
        <div style="width:100%; height:auto;margin-top:30px; color:#031269;">



            <table class="auto-style1">
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_resim" runat="server" Text="RESİM"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:FileUpload ID="fu_kresim" runat="server" CssClass="textbox" /></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_kadi" runat="server" Text="KULLANICI ADI"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_kadi" runat="server" CssClass="textbox" MaxLength="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_sf" runat="server" Text="ŞİFRE"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_sf" runat="server" CssClass="textbox" TextMode="Password" MaxLength="8"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tb_sf" ControlToValidate="tb_sftekrar" ErrorMessage="Şifreler aynı değil"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_sftekrar" runat="server" Text="ŞİFRE(TEKRAR)"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_sftekrar" runat="server" CssClass="textbox" TextMode="Password" MaxLength="8"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_ad" runat="server" Text="AD"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_ad" CssClass="textbox" runat="server" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_soyad" runat="server" Text="SOYAD"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_soyad" runat="server" CssClass="textbox" MaxLength="30" ></asp:TextBox></td>
                </tr>
                   <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_mail" runat="server" Text="E-MAİL"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" MaxLength="70" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_mail" ErrorMessage="Lütfen geçerli bir mail adresi giriniz." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                       </td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_gsoru" runat="server" Text="GÜVENLİK SORUSU"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:DropDownList ID="ddl_gsorusu" runat="server" CssClass="textbox">
                            <asp:ListItem Value="1">En Sevdiğiniz Evcil Hayvan</asp:ListItem>
                            <asp:ListItem Value="2">En Yakın Arkadaşınızın İsmi</asp:ListItem>
                            <asp:ListItem Value="3">En Sevdiğiniz Müzik Türü</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_gsorusucevap" runat="server" Text="CEVAP" ></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_gsorusucevap" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="lbl_telefon" runat="server" Text="TELEFON"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_telefon" runat="server" CssClass="textbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        &nbsp;</td>
                    <td class="ikinci">&nbsp;</td>
                    <td class="ucuncu" style="text-align:center;">
                        <asp:ImageButton ID="ibtn_kaydol" runat="server" ImageUrl="~/image/save.png" ToolTip="KAYIT OL" AlternateText="KAYIT OL" OnClick="ibtn_kaydol_Click" /></td>
                </tr>
            </table>
        </div>
            </asp:Panel>
        <asp:Panel ID="pnl_sifremi_unuttum" runat="server">
         <div style="width:100%; height:50px; background-color:#031269; color:white; padding-left:20px;">
            <asp:Label ID="lbl_sifre" runat="server" Text="Şifremi Unuttum" Font-Size="32px" ></asp:Label>
        </div>
        <div style="width:100%; height:auto;margin-top:30px; color:#031269;">
            <table class="auto-style1">
                 <tr>
                    <td class="birinci">
                        <asp:Label ID="label" runat="server" Text="KULLANICI ADI"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_suka" runat="server" CssClass="textbox" MaxLength="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label5" runat="server" Text="E-MAİL"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_sumail" runat="server" CssClass="textbox" MaxLength="70" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_mail" ErrorMessage="Lütfen geçerli bir mail adresi giriniz." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                       </td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label3" runat="server" Text="GÜVENLİK SORUSU"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:DropDownList ID="ddl_sugs" runat="server" CssClass="textbox">
                            <asp:ListItem Value="1">En Sevdiğiniz Evcil Hayvan</asp:ListItem>
                            <asp:ListItem Value="2">En Yakın Arkadaşınızın İsmi</asp:ListItem>
                            <asp:ListItem Value="3">En Sevdiğiniz Müzik Türü</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                 <tr>
                    <td class="birinci">
                        <asp:Label ID="Label4" runat="server" Text="CEVAP" ></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_sugscevap" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox></td>
                </tr>
                
                 <tr>
                     <td class="birinci"></td>
                     <td class="ikinci"></td>
                     <td class="ucuncu" style="text-align:center">
                         <asp:Button ID="btn_gonder" runat="server" Text="GÖNDER" ForeColor="White" BackColor="#031269" Width="200px" Height="70%" OnClick="btn_gonder_Click"/>
                     </td>
                 </tr>
                 <tr>
                     <td class="birinci"></td>
                     <td class="ikinci"></td>
                     <td class="ucuncu" style="text-align:center">
                         <asp:Label ID="lbl_hatalıkullanici" runat="server" Text=""></asp:Label>
                     </td>
                 </tr>
            </table>
        </div>
        </asp:Panel>
       
       
        <asp:Panel ID="pnl_profil_bilgileri_guncelle" runat="server" Width="100%">
            <div style="width:100%; height:50px; background-color:#031269; color:white; padding-left:20px;">
            <asp:Label ID="Label2" runat="server" Text="PROFİL DÜZENLE" Font-Size="32px" ></asp:Label>
        </div>
        <div style="width:100%; height:auto;margin-top:30px; color:#031269;">
            <table class="auto-style1">
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label10" runat="server" Text="AD"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_ad_guncelle" CssClass="textbox" runat="server" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label11" runat="server" Text="SOYAD"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_soyad_guncelle" runat="server" CssClass="textbox" MaxLength="30" ></asp:TextBox></td>
                </tr>
                   <tr>
                    <td class="birinci">
                        <asp:Label ID="Label12" runat="server" Text="E-MAİL"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_e_mail_guncelle" runat="server" CssClass="textbox" MaxLength="70" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tb_e_mail_guncelle" ErrorMessage="Lütfen geçerli bir mail adresi giriniz." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                       </td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label13" runat="server" Text="GÜVENLİK SORUSU"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:DropDownList ID="ddl_guvenlik_sorusu" runat="server" CssClass="textbox">
                            <asp:ListItem Value="1">En Sevdiğiniz Evcil Hayvan</asp:ListItem>
                            <asp:ListItem Value="2">En Yakın Arkadaşınızın İsmi</asp:ListItem>
                            <asp:ListItem Value="3">En Sevdiğiniz Müzik Türü</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label14" runat="server" Text="CEVAP" ></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_cevap_guncelle" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label15" runat="server" Text="TELEFON"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_telefon_guncelle" runat="server" CssClass="textbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        &nbsp;</td>
                    <td class="ikinci">&nbsp;</td>
                    <td class="ucuncu" style="text-align:center;">
                        <asp:ImageButton ID="ibtn_guncelle" runat="server" ImageUrl="~/image/update.png" ToolTip="Güncelle" AlternateText="Güncelle" OnClick="ibtn_guncelle_Click"  />
                        &nbsp&nbsp<asp:ImageButton ID="ibtn_iptal1" runat="server" ImageUrl="~/image/iptal.png" ToolTip="İPTAL" AlternateText="İPTAL" OnClick="ibtn_iptal1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>
        <asp:Panel ID="pnl_sifre_guncelle" runat="server">
            <div style="width:100%; height:50px; background-color:#031269; color:white; padding-left:20px;">
            <asp:Label ID="Label6" runat="server" Text="ŞİFRE DEĞİŞTİR" Font-Size="32px" ></asp:Label>
        </div>
            <div style="width:100%; height:auto;margin-top:30px; color:#031269;">
            <table class="auto-style1">
                 <tr>
                    <td class="birinci">
                        <asp:Label ID="Label7" runat="server" Text="ESKİ ŞİFRE"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_eskisifre" runat="server" CssClass="textbox" MaxLength="8" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label8" runat="server" Text="ŞİFRE"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_yenisifre" runat="server" CssClass="textbox" TextMode="Password" MaxLength="8"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tb_yenisifre" ControlToValidate="tb_yenisifretekrar" ErrorMessage="Şifreler aynı değil"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="birinci">
                        <asp:Label ID="Label9" runat="server" Text="ŞİFRE(TEKRAR)"></asp:Label></td>
                    <td class="ikinci">:</td>
                    <td class="ucuncu">
                        <asp:TextBox ID="tb_yenisifretekrar" runat="server" CssClass="textbox" TextMode="Password" MaxLength="8"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td class="birinci">
                        &nbsp;</td>
                    <td class="ikinci">&nbsp;</td>
                    <td class="ucuncu" style="text-align:center;">
                        <asp:ImageButton ID="ibtn_sifre_guncelle" runat="server" ImageUrl="~/image/update.png" ToolTip="Güncelle" AlternateText="Güncelle" OnClick="ibtn_sifre_guncelle_Click"  />&nbsp&nbsp&nbsp
                        <asp:ImageButton ID="ibtn_iptal" runat="server" ImageUrl="~/image/iptal.png" ToolTip="İPTAL" AlternateText="İPTAL" OnClick="ibtn_iptal_Click" />
                    </td>
                </tr>
            </table>
                </div>
        </asp:Panel>

    </div>
</asp:Content>
