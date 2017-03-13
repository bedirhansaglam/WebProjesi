using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace KUCSPROJE
{
    public partial class icerikgoster : System.Web.UI.Page
    {   sqlbaglantisi baglan = new sqlbaglantisi();
    string makale_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_yorum_yap.Visible = false;
                
                //makale içerik çek
                makale_id = Request.QueryString["makaleid"];
                SqlCommand cek = new SqlCommand("SELECT makale.*,alt_kategori.alt_kategori_resim FROM alt_kategori,makale WHERE makale.alt_kategori_ID=alt_kategori.alt_kategori_ID AND makaleID=@1", baglan.baglan());
                cek.Parameters.AddWithValue("@1", int.Parse(makale_id));
                SqlDataReader dr = cek.ExecuteReader();
                dl_makaleicerik.DataSource = dr;
                dl_makaleicerik.DataBind();

                //makale görüntülenme arttır
                SqlCommand mgoruntulemeartır = new SqlCommand("UPDATE makale SET makaleOkunma=makaleOkunma+1 WHERE makaleID=@1", baglan.baglan());
                mgoruntulemeartır.Parameters.AddWithValue("@1", int.Parse(makale_id));
                mgoruntulemeartır.ExecuteNonQuery();

                //makale yorum çek
                yorum_cek();

            }
        }
        void yorum_cek()
        {
            SqlCommand yorumcek = new SqlCommand("SELECT * FROM yorum WHERE makaleID=@1 AND yorumOnay=1", baglan.baglan());
            yorumcek.Parameters.AddWithValue("@1", int.Parse(makale_id));
            SqlDataReader dryorum = yorumcek.ExecuteReader();
            DataTable dtyorum = new DataTable("yorum");
            dtyorum.Load(dryorum);
            if (dtyorum.Rows.Count > 0) //yorum varsa
            {
                dl_yorumlar.DataSource = dtyorum;//yorumları göster
                dl_yorumlar.DataBind();
            }
        }

        protected void btn_yorumpaneli_Click(object sender, EventArgs e)
        {
            if (Session["kadi"] != null && Session["kresim"] != null)
            {

                if (btn_yorumpaneli.ToolTip == "Göster")
                {
                    tb_yorum_icerik.Focus();
                    btn_yorumpaneli.ToolTip = "Gizle";
                    pnl_yorum_yap.Visible = true;
                }
                else if (btn_yorumpaneli.ToolTip == "Gizle")
                {
                    btn_yorumpaneli.ToolTip = "Göster";
                    pnl_yorum_yap.Visible = false;
                }

             
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert ('YORUM YAPABİLMEK İÇİN ÖNCELİKLE ÜYE OLMALISINIZ');</script>");
            }

        }

        protected void btn_yorumyap_Click(object sender, EventArgs e)
        {
            string kadi;
            string resim;
            makale_id = Request.QueryString["makaleid"];
            kadi = Session["kadi"].ToString();
            resim = Session["kresim"].ToString();
            SqlCommand yorumekle = new SqlCommand("INSERT INTO yorum(yorumAdSoyad,yorumIcerik,yorumResim,makaleID) VALUES (@1,@2,@3,@makaleID)", baglan.baglan());
            yorumekle.Parameters.AddWithValue("@1", kadi);
            yorumekle.Parameters.AddWithValue("@3", resim);
            yorumekle.Parameters.AddWithValue("@2", tb_yorum_icerik.Text);
            yorumekle.Parameters.AddWithValue("@makaleID",int.Parse( makale_id));
            yorumekle.ExecuteNonQuery();
            SqlCommand yorumartir = new SqlCommand("UPDATE makale SET makaleYorumSayisi=makaleYorumSayisi+1 WHERE makaleID=@1", baglan.baglan());
            yorumartir.Parameters.AddWithValue("@1",int.Parse(makale_id));
            yorumartir.ExecuteNonQuery();
            yorum_cek();

            pnl_yorum_yap.Visible = false;
            tb_yorum_icerik.Text = "";
        }
    }
}