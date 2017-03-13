using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


namespace KUCSPROJE
{
    public partial class uyeol : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
       string uyestring = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            uyestring = Request.QueryString["uye"];
            if (!IsPostBack)
            {
                pnl_uye_ol.Visible = false;
                pnl_sifremi_unuttum.Visible = false;
                pnl_sifre_guncelle.Visible = false;
                pnl_profil_bilgileri_guncelle.Visible = false;
                pnl_profilbilgileri.Visible = false;
            }
           
            if (uyestring == "1")//KAYIT OLMA PANELİNİ AÇ
            {
                pnl_uye_ol.Visible = true;
            }
            else if (uyestring == "2")//ŞİFREMİ UNUTTUM BÖLÜMÜ
            {
                pnl_sifremi_unuttum.Visible = true;
            }
            else if (uyestring == "3")//PROFİL BÖLÜMÜ
            {
                pnl_profilbilgileri.Visible = true;
                profilbilgileri();
            }
           
            

        }
      
        void profilbilgileri()
        { 
            SqlCommand cek=new SqlCommand("SELECT * FROM uye WHERE kadi=@1 AND resim=@2",baglan.baglan());
            cek.Parameters.AddWithValue("@1", Session["kadi"].ToString());
            cek.Parameters.AddWithValue("@2", Session["kresim"].ToString());
            SqlDataReader dr=cek.ExecuteReader();
            dl_pbilgileri.DataSource = dr;
            dl_pbilgileri.DataBind();
        }

        protected void ibtn_kaydol_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand kontrol = new SqlCommand("SELECT * FROM uye WHERE kadi=@1", baglan.baglan());
            kontrol.Parameters.AddWithValue("@1", tb_kadi.Text);
            SqlDataReader dr = kontrol.ExecuteReader();
            DataTable dt = new DataTable("kadi");
            dt.Load(dr);

            if (dt.Rows.Count >0)// kullanıcı adında üye varsa
            {
                Response.Write("<script lang='JavaScript'>alert ('kullanıcı adı daha önce alınmış lütfen farklı bir kullanıcı adı girin');</script>");
            }
            else {
                if (fu_kresim.HasFile)
                {  fu_kresim.SaveAs(Server.MapPath("/profilresim/"+fu_kresim.FileName));
                    SqlCommand kaydet = new SqlCommand("INSERT INTO uye(ad,soyad,kadi,sifre,email,gsoruid,gsorucevap,resim,telefon) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9)", baglan.baglan());
                    kaydet.Parameters.AddWithValue("@1", tb_ad.Text);
                    kaydet.Parameters.AddWithValue("@2", tb_soyad.Text);
                    kaydet.Parameters.AddWithValue("@3", tb_kadi.Text);
                    kaydet.Parameters.AddWithValue("@4", tb_sf.Text);
                    kaydet.Parameters.AddWithValue("@5", tb_mail.Text);
                    kaydet.Parameters.AddWithValue("@6", ddl_gsorusu.SelectedValue);
                    kaydet.Parameters.AddWithValue("@7", tb_gsorusucevap.Text);
                    kaydet.Parameters.AddWithValue("@8", "/profilresim/"+fu_kresim.FileName);
                    kaydet.Parameters.AddWithValue("@9", tb_telefon.Text);
                    kaydet.ExecuteNonQuery();
                }
                else
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen geçerli bir resim seçelim');</script>");
                }
            }
        }

        protected void btn_gonder_Click(object sender, EventArgs e)
        {
            SqlCommand bilgicek = new SqlCommand("SELECT * FROM uye WHERE kadi=@1 AND gsoruid=@2 AND email=@3 AND gsorucevap=@4", baglan.baglan());
            bilgicek.Parameters.AddWithValue("@1",tb_suka.Text);
            bilgicek.Parameters.AddWithValue("@2",int.Parse(ddl_sugs.Text));
            bilgicek.Parameters.AddWithValue("@3",tb_sumail.Text);
            bilgicek.Parameters.AddWithValue("@4", tb_sugscevap.Text);
            SqlDataReader dr = bilgicek.ExecuteReader();
            DataTable dt = new DataTable("kbilgiler");
            dt.Load(dr);
            if (dt.Rows.Count > 0) //böyle bir üye varsa yada bütün bilgiler doğru girildiyse mail atıyoruz
            {


                MailMessage mail = new MailMessage(); //mesaj sınıfından mail nesnesi oluşturuyoruz. 

                mail.To.Add(dt.Rows[0]["email"].ToString());//gönderilecek olan mail adresi

                mail.From = new MailAddress("kucomputersociety@gmail.com");//kimden gönderilecek. 

                mail.Subject = "KASTAMONU UNIVERSITY COMPUTER SOCIETY ŞİFREMİ UNUTTUM ";//mailin konusu... 

                mail.Body = "Kullanıcı Adınız :" + dt.Rows[0]["kadi"].ToString() + " Şifreniz:" + dt.Rows[0]["sifre"].ToString(); //mailin içeriği.

                mail.IsBodyHtml = true;//html kodlarına izin verilsin. 

                NetworkCredential credentials = new NetworkCredential("kucomputersociety@gmail.com", "147258369.");//gmail kullanıcı adı ve şifre...

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);//gmail smtp adresi tanımlaması

                client.EnableSsl = true;  // Gmail için sslin aktif olması gerekiyor. 
                //Ayrıca gmail üzerinden mail gönderebilmek için gmail adresinde daha az güvenli uygulamalara izin ver seçeneğini aktif etmelisiniz
                client.Credentials = credentials;

                client.Send(mail);

                Response.Write("<script lang='JavaScript'>alert ('Mail Gönderildi Lütfen Gelen Kutunuzu Kontrol Ediniz');</script>");
                tb_suka.Text = "";
                tb_sugscevap.Text = "";
                tb_sumail.Text = "";

            }
            else {
                lbl_hatalıkullanici.Text = "Lütfen tüm alanları doğru girdiğinizden emin olun";
                tb_suka.Text = "";
                tb_sugscevap.Text = "";
                tb_sumail.Text = "";
            }
            
        }

        protected void btn_şifre_değiş_Click(object sender, EventArgs e)
        {
            pnl_profilbilgileri.Visible = false;
            pnl_sifre_guncelle.Visible = true;
        }

        protected void btn_bilgiduzenle_Click(object sender, EventArgs e)
        {
            pnl_profilbilgileri.Visible = false;
            pnl_profil_bilgileri_guncelle.Visible = true;
            SqlCommand bilgicek = new SqlCommand("SELECT * FROM uye WHERE kadi=@1 AND resim=@2", baglan.baglan());
            bilgicek.Parameters.AddWithValue("@1",Session["kadi"].ToString());
            bilgicek.Parameters.AddWithValue("@2", Session["kresim"].ToString());
            SqlDataReader dr = bilgicek.ExecuteReader();
            DataTable dt= new DataTable("a");
            dt.Load(dr);
            tb_ad_guncelle.Text = dt.Rows[0]["ad"].ToString();
            tb_soyad_guncelle.Text = dt.Rows[0]["soyad"].ToString();
            tb_e_mail_guncelle.Text = dt.Rows[0]["email"].ToString();
            tb_cevap_guncelle.Text = dt.Rows[0]["gsorucevap"].ToString();
           
            tb_telefon_guncelle.Text = dt.Rows[0]["telefon"].ToString();

            
        }

        protected void ibtn_iptal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("uyeol.aspx?uye=3");
        }

        protected void ibtn_iptal1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("uyeol.aspx?uye=3");
        }

        protected void ibtn_sifre_guncelle_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand guncelle=new SqlCommand("UPDATE uye SET sifre=@1 WHERE sifre=@2 AND kadi=@3 AND resim=@4",baglan.baglan());
            guncelle.Parameters.AddWithValue("@1",tb_yenisifre.Text);
            guncelle.Parameters.AddWithValue("@2",tb_eskisifre.Text);
            guncelle.Parameters.AddWithValue("@3",Session["kadi"].ToString());
            guncelle.Parameters.AddWithValue("@4",Session["kresim"].ToString());
            guncelle.ExecuteNonQuery();
            Response.Redirect("uyeol.aspx?uye=3");

        }

        protected void ibtn_guncelle_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("UPDATE uye SET ad=@1,soyad=@2,email=@5,telefon=@6,gsoruid=@7,gsorucevap=@8  WHERE kadi=@3 AND resim=@4", baglan.baglan());
            guncelle.Parameters.AddWithValue("@3", Session["kadi"].ToString());
            guncelle.Parameters.AddWithValue("@4", Session["kresim"].ToString());
            guncelle.Parameters.AddWithValue("@1",tb_ad_guncelle.Text);
            guncelle.Parameters.AddWithValue("@2",tb_soyad_guncelle.Text);
            guncelle.Parameters.AddWithValue("@5",tb_e_mail_guncelle.Text);
            guncelle.Parameters.AddWithValue("@6",tb_telefon_guncelle.Text);
            guncelle.Parameters.AddWithValue("@7",int.Parse(ddl_guvenlik_sorusu.Text));
            guncelle.Parameters.AddWithValue("@8", tb_cevap_guncelle.Text);
            guncelle.ExecuteNonQuery();
            Response.Redirect("uyeol.aspx?uye=3");
        }
    }
}