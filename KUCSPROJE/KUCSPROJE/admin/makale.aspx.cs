using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace KUCSPROJE.admin
{
    public partial class WebForm2 : System.Web.UI.Page
    { sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_makaleEkle.Visible = false;
                pnl_mduzenle.Visible = false;
                kategori_cek();
                makale_cek();
                btn_iptal.Visible = false;
            }
        }

        protected void ibtn_me_goster1_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_me_goster1.ImageUrl == "~/image/goster.png")
            {
                pnl_makaleEkle.Visible = true;
                ibtn_me_goster1.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_me_goster1.ImageUrl == "~/image/gizle.png")
            {
                pnl_makaleEkle.Visible = false;
                ibtn_me_goster1.ImageUrl = "~/image/goster.png";

            }
        }
        protected void ibtn_me_goster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_me_goster.ImageUrl == "~/image/goster.png")
            {
                pnl_mduzenle.Visible = true;
                ibtn_me_goster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_me_goster.ImageUrl == "~/image/gizle.png")
            {
                pnl_mduzenle.Visible = false;
                ibtn_me_goster.ImageUrl = "~/image/goster.png";

            }
        }
        void kategori_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT alt_kategori_ID,alt_kategori_adi FROM alt_kategori ORDER BY alt_kategori_sıra", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            ddl_kategori.DataSource = dr;
            ddl_kategori.DataBind();
            
        }
        void makale_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM makale ", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_mduzenle.DataSource = dr;
            gw_mduzenle.DataBind();
        
        }

        protected void btn_mekle_Click(object sender, EventArgs e)
        {
            if (btn_mekle.Text == "Kaydet")
            {
                if (m_resim.HasFile)
                {
                    SqlCommand cmdkategoricekekle = new SqlCommand("SELECT kategori.kategoriID FROM kategori,alt_kategori WHERE kategori.kategoriID=alt_kategori.kategoriID AND alt_kategori.alt_kategori_ID=@1", baglan.baglan());
                    cmdkategoricekekle.Parameters.AddWithValue("@1", int.Parse(ddl_kategori.Text));
                    SqlDataReader droku = cmdkategoricekekle.ExecuteReader();
                    DataTable dt = new DataTable("kategori");
                    dt.Load(droku);

                    m_resim.SaveAs(Server.MapPath("/slider/" + m_resim.FileName));
                    SqlCommand cmdekle = new SqlCommand("INSERT INTO makale(makaleBaslik,makaleOzet,makaleicerik,makaleResim,alt_kategori_ID,kategoriID) VALUES(@makaleBaslik,@makaleOzet,@makaleicerik,@makaleResim,@alt_kategori_ID,@1)", baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@makaleBaslik",tb_baslik.Text);
                    cmdekle.Parameters.AddWithValue("@makaleOzet",tb_ozet.Text);
                    cmdekle.Parameters.AddWithValue("@makaleicerik",tb_icerik.Text);
                    cmdekle.Parameters.AddWithValue("@makaleResim","/slider/" + m_resim.FileName);
                    cmdekle.Parameters.AddWithValue("@alt_kategori_ID",int.Parse(ddl_kategori.Text));
                    cmdekle.Parameters.AddWithValue("@1",int.Parse(dt.Rows[0]["kategoriID"].ToString()));
                    cmdekle.ExecuteNonQuery();
                    SqlCommand cmdguncelle=new SqlCommand("UPDATE alt_kategori SET alt_kategori_adet=alt_kategori_adet+1 WHERE alt_kategori_ID=@1",baglan.baglan());
                    cmdguncelle.Parameters.AddWithValue("@1",int.Parse(ddl_kategori.Text));
                    cmdguncelle.ExecuteNonQuery();
                    Response.Redirect("makale.aspx");
                        
                }
                else
                { Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>"); }
            }
            else if (btn_mekle.Text == "Güncelle")
            { 
                 if (m_resim.HasFile)
                {
                    m_resim.SaveAs(Server.MapPath("/slider/" + m_resim.FileName));
                    SqlCommand cmdguncel = new SqlCommand("UPDATE makale SET makaleBaslik=@1 , makaleOzet=@2, makaleicerik=@3, makaleResim=@4 ,alt_kategori_ID=@5 WHERE makaleID=@6", baglan.baglan());
                    cmdguncel.Parameters.AddWithValue("@1",tb_baslik.Text);
                    cmdguncel.Parameters.AddWithValue("@2",tb_ozet.Text);
                    cmdguncel.Parameters.AddWithValue("@3",tb_icerik.Text);
                    cmdguncel.Parameters.AddWithValue("@4","/slider/" + m_resim.FileName);
                    cmdguncel.Parameters.AddWithValue("@5",int.Parse(ddl_kategori.Text));
                    cmdguncel.Parameters.AddWithValue("@6",gw_mduzenle.SelectedValue);
                    cmdguncel.ExecuteNonQuery();
                    Response.Redirect("makale.aspx");


                }
                 else
                 { Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>"); }

            }
        }

        protected void gw_mduzenle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_mduzenle.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_mduzenle.SelectedIndex >= 0)
                {
                   

                    SqlCommand cek = new SqlCommand("SELECT * FROM makale WHERE makaleID=" + gw_mduzenle.SelectedValue, baglan.baglan());
                    SqlDataReader dr = cek.ExecuteReader();
                    DataTable dt = new DataTable("tbl");
                    dt.Load(dr);

                    SqlCommand cmdguncelle = new SqlCommand("UPDATE alt_kategori SET alt_kategori_adet=alt_kategori_adet-1 WHERE alt_kategori_ID=@1", baglan.baglan());
                    cmdguncelle.Parameters.AddWithValue("@1", int.Parse(dt.Rows[0]["alt_kategori_ID"].ToString()));
                    cmdguncelle.ExecuteNonQuery();

                    SqlCommand cmdsil = new SqlCommand("DELETE FROM makale WHERE makaleID=" + gw_mduzenle.SelectedValue, baglan.baglan());
                    cmdsil.ExecuteNonQuery();
                    makale_cek();
                }

            }
            else if (e.CommandName == "guncelle")
            { 
                if (gw_mduzenle.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_mduzenle.SelectedIndex >= 0)
                {
                    SqlCommand cmdguncelle = new SqlCommand("SELECT * FROM makale WHERE makaleID=" + gw_mduzenle.SelectedValue, baglan.baglan());
                    SqlDataReader dr = cmdguncelle.ExecuteReader();
                    DataTable dt = new DataTable("tablo");
                    dt.Load(dr);

                    pnl_makaleEkle.Visible = true;
                    lbl_ekle.Text = "Makale Güncelle";
                    btn_mekle.Text = "Güncelle";
                    btn_iptal.Visible = true;
                    tb_baslik.Text = dt.Rows[0]["makaleBaslik"].ToString();
                    tb_ozet.Text = dt.Rows[0]["makaleOzet"].ToString();
                    tb_icerik.Text = dt.Rows[0]["makaleicerik"].ToString();

                }
            }
        }

        protected void btn_iptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("makale.aspx");
        }
    }
}