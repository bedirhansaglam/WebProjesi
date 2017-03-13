using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace KUCSPROJE.admin
{
    public partial class reklam : System.Web.UI.Page
    {
        
        sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_ekle.Visible = false;
                pnl_duzenle.Visible = false;
                reklam_cek();
            }
          
           
           
        }
        void reklam_ekle()
        {
            SqlCommand reklam_cek = new SqlCommand("SELECT * FROM reklam ", baglan.baglan());
            SqlDataReader dr = reklam_cek.ExecuteReader();
            DataTable dt = new DataTable("tbl");
            dt.Load(dr);
            
            //daha önceden eklenmiş aynı adda xml dosyası varsa siler
            XmlTextWriter yaz = new XmlTextWriter(Server.MapPath("reklam.xml"), System.Text.UTF8Encoding.UTF8);
          
                yaz.WriteStartDocument(); 
                //Xml dökümanına ait declaration satırını oluşturur. Kısaca yazmaya başlar.
                yaz.WriteStartElement("Advertisements");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    yaz.WriteStartElement("Ad");
                    //Advertisements ve Ad etiketleri oluşturuldu.

                    yaz.WriteElementString("ImageUrl","~"+ dt.Rows[i]["resim"].ToString());
                    yaz.WriteElementString("NavigateUrl", "https://" + dt.Rows[i]["link"].ToString());
                    yaz.WriteElementString("TargetUrl", "_blank");
                    yaz.WriteElementString("AlternateText", dt.Rows[i]["text"].ToString());
                    yaz.WriteElementString("Keyword", dt.Rows[i]["anahtarkelimeler"].ToString());
                    yaz.WriteElementString("Impressions", dt.Rows[i]["sıklık"].ToString());
                    //İçerik isim-değer çiftleri şeklinde Ad etiketinin içerisine element türünde eklendi.
                    yaz.WriteEndElement();
                }
                yaz.WriteEndElement();
                //Advertisements ve Ad etiketleri sonlandırıldı.
                yaz.Close();
                //XML akışı sonlandırıldı.
               
           
        }

        protected void ibtn_goster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_goster.ImageUrl == "~/image/goster.png")
            {
                pnl_ekle.Visible = true;
                ibtn_goster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_goster.ImageUrl == "~/image/gizle.png")
            {
                pnl_ekle.Visible = false;
                ibtn_goster.ImageUrl = "~/image/goster.png";

            }
        }

        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text == "Kaydet")
            {
                fl_resim.SaveAs(Server.MapPath("/reklam/" + fl_resim.FileName));
                if (fl_resim.HasFile)
                {
                    SqlCommand cmdekle = new SqlCommand("INSERT INTO reklam(resim,link,text,anahtarkelimeler,sıklık) VALUES(@1,@2,@3,@4,@5)", baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@1", "~/reklam/" + fl_resim.FileName);
                    cmdekle.Parameters.AddWithValue("@2", tb_url.Text);
                    cmdekle.Parameters.AddWithValue("@3", tb_atext.Text);
                    cmdekle.Parameters.AddWithValue("@4", tb_keyword.Text);
                    cmdekle.Parameters.AddWithValue("@5", 1);
                    cmdekle.ExecuteNonQuery();
                    reklam_ekle();
                    Response.Redirect("reklam.aspx");

                }
                else {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>");
                
                }
            }
            else if (btn_kaydet.Text == "Güncelle")
            { 
                fl_resim.SaveAs(Server.MapPath("/reklam/" + fl_resim.FileName));
                if (fl_resim.HasFile)
                { SqlCommand cmdekle=new SqlCommand("UPDATE reklam SET resim=@1,link=@2,text=@3,anahtarkelimeler=@4",baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1", "~/reklam/" + fl_resim.FileName);
                    cmdekle.Parameters.AddWithValue("@2",tb_url.Text);
                    cmdekle.Parameters.AddWithValue("@3",tb_atext.Text);
                    cmdekle.Parameters.AddWithValue("@4", tb_keyword.Text);
                    cmdekle.ExecuteNonQuery();
                    reklam_ekle();
                    Response.Redirect("reklam.aspx");
                }
                else
                { Response.Write("<script lang='JavaScript'>alert ('Lütfen Resim Seçiniz');</script>"); }
            }
        }

        protected void btn_iptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("reklam.aspx");
        }

        protected void ibtn_goster1_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_goster1.ImageUrl == "~/image/goster.png")
            {
                pnl_duzenle.Visible = true;
                ibtn_goster1.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_goster1.ImageUrl == "~/image/gizle.png")
            {
                pnl_duzenle.Visible = false;
                ibtn_goster1.ImageUrl = "~/image/goster.png";

            }
        }
        void reklam_cek()
        {
            SqlCommand sec = new SqlCommand("SELECT * FROM reklam ", baglan.baglan());
            SqlDataReader dr = sec.ExecuteReader();
            gw_reklamlar.DataSource = dr;
            gw_reklamlar.DataBind();
        }
        protected void gw_reklamlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_reklamlar.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen işlem yapmak için bir satır seçiniz');</script>");
                }
                else if (gw_reklamlar.SelectedIndex >= 0)
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM reklam WHERE reklam_id=@1", baglan.baglan());
                    sil.Parameters.AddWithValue("@1", gw_reklamlar.SelectedValue);
                    sil.ExecuteNonQuery();
                    reklam_ekle();
                    reklam_cek();
                    gw_reklamlar.SelectedIndex = -1;
                }
            }
            else if (e.CommandName == "guncelle")
            {
                if (gw_reklamlar.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen işlem yapmak için bir satır seçiniz');</script>");
                }
                else if (gw_reklamlar.SelectedIndex >= 0)
                {
                    SqlCommand sec = new SqlCommand("SELECT * FROM reklam WHERE reklam_id=@1", baglan.baglan());
                    sec.Parameters.AddWithValue("@1", gw_reklamlar.SelectedValue);
                    SqlDataReader dr = sec.ExecuteReader();
                    DataTable dt = new DataTable("a");
                    dt.Load(dr);


                    pnl_ekle.Visible = true;
                    btn_kaydet.Text = "Güncelle";
                    tb_url.Text = dt.Rows[0]["link"].ToString();
                    tb_keyword.Text = dt.Rows[0]["anahtarkelimeler"].ToString();
                    tb_atext.Text = dt.Rows[0]["text"].ToString();
                   
                }
            }
        }
    }
}