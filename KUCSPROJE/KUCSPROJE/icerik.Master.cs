using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KUCSPROJE
{
    public partial class icerik : System.Web.UI.MasterPage
    {    sqlbaglantisi baglan = new sqlbaglantisi();
         public StringBuilder menutut = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            }
           

            if (Session["kadi"] != null && Session["kresim"] != null)//kullanıcı giriş yapmışsa
            {
                pnl_kullanici.Visible = true;
                lbl_kadi.Text = Session["kadi"].ToString();

            }
            else//giriş yapmamışsa
            {
                pnl_kullanici.Visible = false;
            }

            //banner başlangıç
            SqlCommand bannercek = new SqlCommand("SELECT * FROM banner", baglan.baglan());
            SqlDataReader drbanner = bannercek.ExecuteReader();
            DataTable dtbanner = new DataTable("banner");
            dtbanner.Load(drbanner);
            img_logo.ImageUrl = dtbanner.Rows[0]["banner_resim"].ToString();
            img_m_kemal.ImageUrl = dtbanner.Rows[0]["banner_resimiki"].ToString();
            lbl_slogan.Text = dtbanner.Rows[0]["banner_yazi"].ToString();
            //banner son

            //menü başlangıç
            SqlCommand cmdkategoricek = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra ASC", baglan.baglan());
            SqlDataReader dr = cmdkategoricek.ExecuteReader();
            DataTable dt = new DataTable("kategori");
            dt.Load(dr);

            menutut.Append("<ul id='acilirmenu'>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                menutut.Append("<li class='altmenu'>");
                menutut.Append("<a href='makale.aspx?kategoriID=" + dt.Rows[i]["kategoriID"].ToString() + "'>" + dt.Rows[i]["kategoriAd"].ToString() + "</a>");

                SqlCommand cmdaltkategoricek = new SqlCommand("SELECT * FROM alt_kategori WHERE kategoriID=@kategoriID ORDER BY alt_kategori_sıra ASC", baglan.baglan());
                cmdaltkategoricek.Parameters.AddWithValue("@kategoriID", int.Parse(dt.Rows[i]["kategoriID"].ToString()));
                SqlDataReader dr1 = cmdaltkategoricek.ExecuteReader();
                DataTable dt1 = new DataTable("alt_kategori");
                dt1.Load(dr1);

                if (dt1.Rows.Count >= 0)
                {
                    menutut.Append("<ul class='gizli'>");
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        menutut.Append("<li><a href='kategoridetay.aspx?altkategori_id=" + dt1.Rows[j]["alt_kategori_ID"].ToString() + "'>" + dt1.Rows[j]["alt_kategori_adi"].ToString() + "(" + dt1.Rows[j]["alt_kategori_adet"].ToString() + ")" + "</a></li>");
                    }
                    menutut.Append("</ul>");
                }
                menutut.Append("</li>");

            }
            menutut.Append("</ul>");
            //menü bitiş
            

        }

        protected void ibtn_ara_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("search.aspx?ara=" + tb_ara.Text + "");
        }

        protected void iletişim_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("iletisim.aspx");
        }

        protected void ibtn_cikis_Click(object sender, ImageClickEventArgs e)
        {
            
            Session.Remove("kadi");
            Session.Remove("kresim");
            pnl_kullanici.Visible = false;

            string sayfaadı = sayfaAdiBul();
            if (sayfaadı == "uyeol.aspx")
            {
                Response.Redirect("index.aspx");
            }
            
        }

        protected void ibtn_ayar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("uyeol.aspx?uye=3");
        }

        protected string sayfaAdiBul()
        {
            string strSayfaAdi = "";
            string[] urlList = HttpContext.Current.Request.Url.Segments;
            for (int i = 0; i < urlList.Length; i++)
            {
                if (urlList[i].Contains(".aspx"))
                    strSayfaAdi = urlList[i];
            }
            return strSayfaAdi;
        }
    }
}