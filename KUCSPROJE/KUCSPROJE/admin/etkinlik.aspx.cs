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
    public partial class WebForm5 : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_eduzenle.Visible = false;
                pnl_eekle.Visible = false;
                btn_eiptal.Visible = false;
                etkinlik_cek();
            }
        }

        protected void ibtn_egoster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_egoster.ImageUrl == "~/image/goster.png")
            {
                pnl_eekle.Visible = true;
                ibtn_egoster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_egoster.ImageUrl == "~/image/gizle.png")
            {
                pnl_eekle.Visible = false;
                ibtn_egoster.ImageUrl = "~/image/goster.png";

            }
        }
        protected void ibtn_egoster2_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_egoster2.ImageUrl == "~/image/goster.png")
            {
                pnl_eduzenle.Visible = true;
                ibtn_egoster2.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_egoster2.ImageUrl == "~/image/gizle.png")
            {
                pnl_eduzenle.Visible = false;
                ibtn_egoster2.ImageUrl = "~/image/goster.png";

            }
        }

        protected void btn_ekaydet_Click(object sender, EventArgs e)
        {
            if (btn_ekaydet.Text == "Kaydet")
            {
                SqlCommand cmdekle = new SqlCommand("INSERT INTO etkinlik(e_baslik,e_icerik) VALUES (@e_baslik,@e_icerik)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@e_baslik", tb_ebaslik.Text);
                cmdekle.Parameters.AddWithValue("@e_icerik", tb_eicerik.Text);
                cmdekle.ExecuteNonQuery();
                Response.Redirect("etkinlik.aspx");
               
            }
            else if (btn_ekaydet.Text == "Güncelle")
            {
                SqlCommand cmdgncl = new SqlCommand("UPDATE etkinlik SET e_baslik=@e_baslik , e_icerik=@e_icerik , e_tarih=@e_tarih WHERE etkinlik_id=@etkinlik_id", baglan.baglan());
                cmdgncl.Parameters.AddWithValue("@e_baslik", tb_ebaslik.Text);
                cmdgncl.Parameters.AddWithValue("@e_icerik", tb_eicerik.Text);
                cmdgncl.Parameters.AddWithValue("@e_tarih", DateTime.Now);
                cmdgncl.Parameters.AddWithValue("@etkinlik_id", gw_eduzenle.SelectedValue);
                cmdgncl.ExecuteNonQuery();
                Response.Redirect("etkinlik.aspx");
                etkinlik_cek();
               
            }
        }
        void etkinlik_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM etkinlik ORDER BY e_tarih DESC", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_eduzenle.DataSource = dr;
            gw_eduzenle.DataBind();
        
        }

        protected void gw_eduzenle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_eduzenle.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_eduzenle.SelectedIndex >= 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM etkinlik WHERE etkinlik_id=" + gw_eduzenle.SelectedValue, baglan.baglan());
                    cmd.ExecuteNonQuery();
                    Response.Redirect("duyuru.aspx");
                    etkinlik_cek();
                }

            }
            else if (e.CommandName == "guncelle")
            {
                if (gw_eduzenle.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Güncelleme yapabilmek için öncelikle satır seçmelisiniz');</script>");
                }
                else if (gw_eduzenle.SelectedIndex >= 0)
                {
                    SqlCommand cmdguncelle = new SqlCommand("SELECT * FROM etkinlik WHERE etkinlik_id=@etkinlik_id", baglan.baglan());
                    cmdguncelle.Parameters.AddWithValue("@etkinlik_id", gw_eduzenle.SelectedValue);
                    SqlDataReader dr = cmdguncelle.ExecuteReader();

                    DataTable dt = new DataTable("tablo");
                    dt.Load(dr);

                    pnl_eekle.Visible = true ;
                    lbl_ekle.Text = "Etkinlik Güncelle";
                    btn_eiptal.Visible = true;
                    btn_ekaydet.Text = "Güncelle";
                    tb_ebaslik.Text = dt.Rows[0]["e_baslik"].ToString();
                    tb_eicerik.Text = dt.Rows[0]["e_icerik"].ToString();


                }
            }
        }

        protected void btn_eiptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("etkinlik.aspx");
        }

      
    }
}