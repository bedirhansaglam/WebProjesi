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
    public partial class WebForm7 : System.Web.UI.Page
    {
        sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)//sayfa ilk defa yüklendiyse
            { 
            pnl_akekle.Visible = false;
            pnl_akguncelle.Visible = false;
            btn_iptal.Visible = false;
            kategori_cek();
            alt_kategori_oku();
            }
        }

        protected void ibtn_akgoster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_akgoster.ImageUrl == "~/image/goster.png")
            {
                pnl_akekle.Visible = true;
                ibtn_akgoster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_akgoster.ImageUrl == "~/image/gizle.png")
            {
                pnl_akekle.Visible = false;
                ibtn_akgoster.ImageUrl = "~/image/goster.png";

            }
        }
        protected void ibtn_akgoster1_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_akgoster1.ImageUrl == "~/image/goster.png")
            {
                pnl_akguncelle.Visible = true;
                ibtn_akgoster1.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_akgoster1.ImageUrl == "~/image/gizle.png")
            {
                pnl_akguncelle.Visible = false;
                ibtn_akgoster1.ImageUrl = "~/image/goster.png";

            }
        }
        void kategori_cek()
        {
            SqlCommand cmdoku = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra", baglan.baglan());
            SqlDataReader droku = cmdoku.ExecuteReader();
            ddl_kadi.DataSource = droku;
            ddl_kadi.DataBind();
            
        }
        void alt_kategori_oku()
        {
            SqlCommand cmdoku = new SqlCommand("SELECT ak.alt_kategori_ID,ak.alt_kategori_adi,ak.alt_kategori_resim,k.kategoriAd FROM alt_kategori ak , kategori k WHERE ak.kategoriID=k.kategoriID ", baglan.baglan());
            SqlDataReader dr = cmdoku.ExecuteReader();
            gw_alt_kategori.DataSource = dr;
            gw_alt_kategori.DataBind();
        }

        protected void btn_akkaydet_Click(object sender, EventArgs e)
        {
            if (btn_akkaydet.Text == "Kaydet")
            {
                if(ak_resim.HasFile){
                    ak_resim.SaveAs(Server.MapPath("/kresim/" + ak_resim.FileName));
                SqlCommand cmdekle = new SqlCommand("INSERT INTO alt_kategori(kategoriID,alt_kategori_adi,alt_kategori_resim,alt_kategori_sıra) VALUES(@kategoriID,@alt_kategori_adi,@alt_kategori_resim,@alt_kategori_sıra)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@kategoriID", int.Parse(ddl_kadi.Text));
                cmdekle.Parameters.AddWithValue("@alt_kategori_adi", tb_akadi.Text);
                cmdekle.Parameters.AddWithValue("@alt_kategori_resim", "/kresim/" + ak_resim.FileName);
                cmdekle.Parameters.AddWithValue("@alt_kategori_sıra", 1);
                cmdekle.ExecuteNonQuery();
                Response.Redirect("altkategoriler.aspx");
                alt_kategori_oku();
                    

                }
                else
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>");
                    
                    }

            }
            else if (btn_akkaydet.Text == "Güncelle")
            { 
                 if(ak_resim.HasFile){
                     ak_resim.SaveAs(Server.MapPath("/kresim/" + ak_resim.FileName));
                     SqlCommand cmdgncl = new SqlCommand("UPDATE alt_kategori SET alt_kategori_adi=@1,alt_kategori_resim=@2,kategoriID=@3  WHERE alt_kategori_ID=@4", baglan.baglan());
                     cmdgncl.Parameters.AddWithValue("@1", tb_akadi.Text);
                     cmdgncl.Parameters.AddWithValue("@2", "/kresim/" + ak_resim.FileName);
                     cmdgncl.Parameters.AddWithValue("@3", int.Parse(ddl_kadi.Text));
                     cmdgncl.Parameters.AddWithValue("@4", gw_alt_kategori.SelectedValue);
                     cmdgncl.ExecuteNonQuery();
                     Response.Redirect("altkategoriler.aspx");
                 }
                 else
                 {
                     Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>");

                 }
            
            }
        }

        protected void gw_alt_kategori_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_alt_kategori.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_alt_kategori.SelectedIndex >= 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM alt_kategori WHERE alt_kategori_ID=" + gw_alt_kategori.SelectedValue, baglan.baglan());
                    cmd.ExecuteNonQuery();
                    alt_kategori_oku();
                 
                    
                }
            }
            else if (e.CommandName == "guncelle") 
            {
                if (gw_alt_kategori.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>");
                }
                else if (gw_alt_kategori.SelectedIndex >= 0)
                {
                    SqlCommand cmdguncelle = new SqlCommand("SELECT * FROM alt_kategori WHERE alt_kategori_ID=@alt_kategori_ID", baglan.baglan());
                    cmdguncelle.Parameters.AddWithValue("@alt_kategori_ID", gw_alt_kategori.SelectedValue);
                    SqlDataReader dr = cmdguncelle.ExecuteReader();

                    DataTable dt = new DataTable("tablo");
                    dt.Load(dr);

                    pnl_akekle.Visible = true;
                    lbl_ekle.Text = "Alt Kategori Güncelle";
                    btn_iptal.Visible = true;
                    btn_akkaydet.Text = "Güncelle";
                    tb_akadi.Text = dt.Rows[0]["alt_kategori_adi"].ToString();
                
                }
            
            }
        }

        protected void btn_iptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("altkategoriler.aspx");
        }
    }
}