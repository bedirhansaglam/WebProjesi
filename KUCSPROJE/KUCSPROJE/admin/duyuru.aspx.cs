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
    public partial class WebForm4 : System.Web.UI.Page
    {
        sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { pnl_duyuruEkle.Visible = false;
            pnl_duyuruguncelle.Visible = false;
            btn_iptal.Visible = false;
            duyuru_cek();
            }
           
        }

        protected void ibtn_duyurueklegoster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_duyurueklegoster.ImageUrl == "~/image/goster.png")
            {
                pnl_duyuruEkle.Visible = true;
                ibtn_duyurueklegoster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_duyurueklegoster.ImageUrl == "~/image/gizle.png")
            {
                pnl_duyuruEkle.Visible = false;
                ibtn_duyurueklegoster.ImageUrl = "~/image/goster.png";

            }

        }

        protected void ibtn_dggoster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_dggoster.ImageUrl == "~/image/goster.png")
            {
                pnl_duyuruguncelle.Visible = true;
                ibtn_dggoster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_dggoster.ImageUrl == "~/image/gizle.png")
            {
                pnl_duyuruguncelle.Visible = false;
                ibtn_dggoster.ImageUrl = "~/image/goster.png";

            }
        }

        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text == "Kaydet")
            {
                SqlCommand cmdekle = new SqlCommand("INSERT INTO duyuru(d_baslik,d_icerik) VALUES (@d_baslik,@d_icerik)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@d_baslik", tb_dbaslik.Text);
                cmdekle.Parameters.AddWithValue("@d_icerik", tb_dicerik.Text);
                cmdekle.ExecuteNonQuery();
                Response.Redirect("duyuru.aspx");
                duyuru_cek();
            }
            else if (btn_kaydet.Text == "Güncelle")
            { 
                SqlCommand cmdgncl=new SqlCommand("UPDATE duyuru SET d_baslik=@d_baslik , d_icerik=@d_icerik , d_tarih=@d_tarih WHERE duyuru_id=@duyuru_id",baglan.baglan());
                cmdgncl.Parameters.AddWithValue("@d_baslik", tb_dbaslik.Text);
                cmdgncl.Parameters.AddWithValue("@d_icerik", tb_dicerik.Text);
                cmdgncl.Parameters.AddWithValue("@d_tarih", DateTime.Now);
                cmdgncl.Parameters.AddWithValue("@duyuru_id", gw_duyuruguncelle.SelectedValue);
                cmdgncl.ExecuteNonQuery();
                Response.Redirect("duyuru.aspx");
                duyuru_cek();
            }
        }

        void duyuru_cek()
        { 
            SqlCommand cmdoku=new SqlCommand("SELECT * FROM duyuru ORDER BY d_tarih DESC",baglan.baglan());
            SqlDataReader dr = cmdoku.ExecuteReader();
            gw_duyuruguncelle.DataSource = dr;
            gw_duyuruguncelle.DataBind();
         }

        protected void gw_duyuruguncelle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_duyuruguncelle.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_duyuruguncelle.SelectedIndex >= 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM duyuru WHERE duyuru_id=" + gw_duyuruguncelle.SelectedValue, baglan.baglan());
                    cmd.ExecuteNonQuery();
                    Response.Redirect("duyuru.aspx");
                    duyuru_cek();
                }
            
            }
            else if (e.CommandName == "guncelle")
            {
                if (gw_duyuruguncelle.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_duyuruguncelle.SelectedIndex >= 0)
                {
                    SqlCommand cmdguncelle = new SqlCommand("SELECT * FROM duyuru WHERE duyuru_id=@duyuruid", baglan.baglan());
                    cmdguncelle.Parameters.AddWithValue("@duyuruid", gw_duyuruguncelle.SelectedValue);
                    SqlDataReader dr = cmdguncelle.ExecuteReader();

                    DataTable dt = new DataTable("tablo");
                    dt.Load(dr);

                    pnl_duyuruEkle.Visible = true;
                    lbl_ekle.Text = "Duyuru Güncelle";
                    btn_iptal.Visible = true;
                    btn_kaydet.Text = "Güncelle";
                    tb_dbaslik.Text = dt.Rows[0]["d_baslik"].ToString();
                    tb_dicerik.Text = dt.Rows[0]["d_icerik"].ToString();
                 

                }
            }
        }

        protected void btn_iptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("duyuru.aspx");
        }
    }
}