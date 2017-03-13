using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace KUCSPROJE.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_kategoriEkle.Visible = false;
                pnl_kategoriDuzenle.Visible = false;
            }
            kategori_oku();

        }

     
        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text == "Kaydet")
            {
                if (ktg_resim.HasFile)
                {
                    int sıra = kategori_sıra() + 1;//kategorileri sıraya sokmak için primary keyden farklı sıra numarası tutmak için
                    ktg_resim.SaveAs(Server.MapPath("/kresim/" + ktg_resim.FileName));
                    SqlCommand cmdekle = new SqlCommand("INSERT INTO kategori(kategoriAd,kategoriResim,kategoriSıra) VALUES (@kategoriAd,@kategoriResim,@kategoriSıra)", baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@kategoriAd", ktg_adi.Text);
                    cmdekle.Parameters.AddWithValue("@kategoriResim", "/kresim/" + ktg_resim.FileName);
                    cmdekle.Parameters.AddWithValue("@kategoriSıra", sıra);
                    cmdekle.ExecuteNonQuery();
                    Response.Redirect("default.aspx");
                    kategori_oku();

                }
                else
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>");
                }
            }
            else if (btn_kaydet.Text == "Güncelle")
            {
                if (ktg_resim.HasFile)
                {
                    ktg_resim.SaveAs(Server.MapPath("/kresim/" + ktg_resim.FileName));
                    SqlCommand cmdgncl = new SqlCommand("UPDATE kategori SET kategoriAd=@kategoriAd ,kategoriResim=@kategoriResim WHERE kategoriID=@kategoriID ", baglan.baglan());
                    cmdgncl.Parameters.AddWithValue("@kategoriAd", ktg_adi.Text);
                    cmdgncl.Parameters.AddWithValue("@kategoriResim", "/kresim/" + ktg_resim.FileName);
                    cmdgncl.Parameters.AddWithValue("@kategoriID", gw_kategori.SelectedValue);
                    cmdgncl.ExecuteNonQuery();
                    Response.Redirect("default.aspx");
                    kategori_oku();

                }
               
                else
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>");
                    
                }
            }
        }

        int kategori_sıra() //var olan kategori elemanlarının en sonuncsunun sıra numarasını döndüren fonksiyon
        {
            int sıra;
            SqlCommand cmdoku = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra", baglan.baglan());
            SqlDataReader droku = cmdoku.ExecuteReader();
            DataTable dt = new DataTable("tablo");
            dt.Load(droku);
            sıra = int.Parse(dt.Rows[dt.Rows.Count-1]["kategorisıra"].ToString());
            return sıra;
        }

        void kategori_oku()
        {
            SqlCommand cmdoku = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra", baglan.baglan());
            SqlDataReader droku = cmdoku.ExecuteReader();
            gw_kategori.DataSource = droku;
            gw_kategori.DataBind();
        }

       

        protected void gw_kategori_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_kategori.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_kategori.SelectedIndex >= 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM kategori WHERE kategoriID=" + gw_kategori.SelectedValue, baglan.baglan());
                    cmd.ExecuteNonQuery();
                    kategori_oku();
                }

            }
            else if (e.CommandName == "yukari")
            {
                if (gw_kategori.SelectedIndex == -1)
                { }
                else if (gw_kategori.SelectedIndex >= 0)
                {
                    int a, b;
                    a = int.Parse(gw_kategori.SelectedIndex.ToString());
                    b = int.Parse(gw_kategori.SelectedIndex.ToString()) - 1;

                    SqlCommand kategoricek = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra", baglan.baglan());
                    SqlDataReader kategoridr = kategoricek.ExecuteReader();
                    DataTable dt = new DataTable("kategori");
                    dt.Load(kategoridr);
                    int c, d;
                    if (b ==-1)//seçilen satırdan önceki satır yoksa sona git
                    {
                        b = dt.Rows.Count-1;
                    }

                    c = int.Parse(dt.Rows[a]["kategoriSıra"].ToString());
                    d = int.Parse(dt.Rows[b]["kategoriSıra"].ToString());

                    SqlCommand birinci = new SqlCommand("UPDATE kategori SET kategoriSıra=@1 WHERE kategoriID=@2", baglan.baglan());
                    birinci.Parameters.AddWithValue("@1", d);//n+1 in kategori sırası 
                    birinci.Parameters.AddWithValue("@2", int.Parse(dt.Rows[a]["kategoriID"].ToString()));//n.satırın kategorisine
                    birinci.ExecuteNonQuery(); //aktarılıyor.

                    SqlCommand ikinci = new SqlCommand("UPDATE kategori SET kategoriSıra=@1 WHERE kategoriID=@2", baglan.baglan());
                    ikinci.Parameters.AddWithValue("@1", c);//n.ci  kategori sırası 
                    ikinci.Parameters.AddWithValue("@2", int.Parse(dt.Rows[b]["kategoriID"].ToString()));//n+1.satırın kategorisine
                    ikinci.ExecuteNonQuery(); //aktarılıyor.
                    kategori_oku();
                    gw_kategori.SelectedIndex = b;
                }

            }
            else if (e.CommandName == "asagi")
            {
                if (gw_kategori.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen satır seçiniz');</script>");
                
                }
                else if (gw_kategori.SelectedIndex >= 0)
                { 

                int a, b;
                a = int.Parse(gw_kategori.SelectedIndex.ToString()); //n.satır değeri
                b = int.Parse(gw_kategori.SelectedIndex.ToString()) + 1;//n+1 satır değeri

                SqlCommand kategoricek = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra", baglan.baglan());
                SqlDataReader kategoridr = kategoricek.ExecuteReader();
                DataTable dt = new DataTable("kategori");
                dt.Load(kategoridr);
                int c, d;
                if (b > dt.Rows.Count - 1)//seçilen satırdan sonraki satır yoksa başa git
                {
                    b = 0;
                }
                c= int.Parse(dt.Rows[a]["kategoriSıra"].ToString());//n.satır sıra değeri
                d= int.Parse(dt.Rows[b]["kategoriSıra"].ToString());//n+1. satır sıra değeri

                SqlCommand birinci = new SqlCommand("UPDATE kategori SET kategoriSıra=@1 WHERE kategoriID=@2", baglan.baglan());
                birinci.Parameters.AddWithValue("@1", d);//n+1 in kategori sırası 
                birinci.Parameters.AddWithValue("@2", int.Parse(dt.Rows[a]["kategoriID"].ToString()));//n.satırın kategorisine
                birinci.ExecuteNonQuery(); //aktarılıyor.

                SqlCommand ikinci = new SqlCommand("UPDATE kategori SET kategoriSıra=@1 WHERE kategoriID=@2", baglan.baglan());
                ikinci.Parameters.AddWithValue("@1", c);//n.ci  kategori sırası 
                ikinci.Parameters.AddWithValue("@2", int.Parse(dt.Rows[b]["kategoriID"].ToString()));//n+1.satırın kategorisine
                ikinci.ExecuteNonQuery(); //aktarılıyor.

                kategori_oku();


                gw_kategori.SelectedIndex = b;

                }
                
            
            }
            else if (e.CommandName == "guncelle")
            {
                if (gw_kategori.SelectedIndex==-1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_kategori.SelectedIndex >= 0)
                {
                    SqlCommand cmdguncelle = new SqlCommand("SELECT * FROM kategori WHERE kategoriID=@kategoriID", baglan.baglan());
                    cmdguncelle.Parameters.AddWithValue("@kategoriID", gw_kategori.SelectedValue);
                    SqlDataReader dr = cmdguncelle.ExecuteReader();

                    DataTable dt = new DataTable("tablo");
                    dt.Load(dr);

                    pnl_kategoriEkle.Visible = true;
                    lbl_ekle.Text = "Kategori Güncelle";
                    btn_iptal.Visible = true;
                    btn_kaydet.Text = "Güncelle";
                    ktg_adi.Text = dt.Rows[0]["kategoriAd"].ToString();
                    
                }
            
            }
        }

        protected void ibtn_goster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_goster.ImageUrl == "~/image/goster.png")
            {
                pnl_kategoriDuzenle.Visible = true;
                ibtn_goster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_goster.ImageUrl == "~/image/gizle.png")
            {
                pnl_kategoriDuzenle.Visible = false;
                ibtn_goster.ImageUrl = "~/image/goster.png";
                
            }
        }

        protected void ibtn_goster1_Click(object sender, ImageClickEventArgs e)
        {

            if (ibtn_goster1.ImageUrl == "~/image/goster.png")
            {
                pnl_kategoriEkle.Visible = true;
                ibtn_goster1.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_goster1.ImageUrl == "~/image/gizle.png")
            {
                pnl_kategoriEkle.Visible = false;
                ibtn_goster1.ImageUrl = "~/image/goster.png";

            }
        }

        protected void btn_iptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
       
    }
}