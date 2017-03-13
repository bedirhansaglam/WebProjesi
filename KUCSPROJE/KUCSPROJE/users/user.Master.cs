using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace KUCSPROJE.users
{
    public partial class user : System.Web.UI.MasterPage
    {
        sqlbaglantisi baglan = new sqlbaglantisi();
        public StringBuilder menutut = new StringBuilder();

        HttpCookie kullaniciCookie = new HttpCookie("uyebilgileri");
        HttpCookie kullanicicookie2 = new HttpCookie("uyesifre");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["uyebilgileri"] != null) // cookie varsa doldur
                {
                    string kadi, sf;
                    kadi = Request.Cookies["uyebilgileri"]["kadi"].ToString();
                    sf = Request.Cookies["uyesifre"]["sf"].ToString(); //şifre kısmında textmode passwordde sıkıntı var doldurmuyor.
                    tb_kadi.Text = kadi;
                    tb_sifre.Text = sf;

                }
                else
                {

                }
            }
            

            
            if (Session["kadi"] != null && Session["kresim"] != null)
            {


                lbl_kadi.Text = Session["kadi"].ToString();
                img_profil.ImageUrl = Session["kresim"].ToString();
                pnl_kullanicigiris.Visible = false;

            }
            else
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


                //slider başlangıç
                SqlCommand cmdslider = new SqlCommand("SELECT * FROM makale", baglan.baglan());
                SqlDataReader drslider = cmdslider.ExecuteReader();
                dl_slider.DataSource = drslider;
                dl_slider.DataBind();
                //slider bitiş

                //duyurular
                SqlCommand cmdduyuru = new SqlCommand("SELECT * FROM duyuru", baglan.baglan());
                SqlDataReader drduyuru = cmdduyuru.ExecuteReader();
                dl_duyuru.DataSource = drduyuru;
                dl_duyuru.DataBind();

                //etkinlikler
                SqlCommand cmdetkinlik = new SqlCommand("SELECT * FROM etkinlik", baglan.baglan());
                SqlDataReader dretkinlik = cmdetkinlik.ExecuteReader();
                r_etkinlikler.DataSource = dretkinlik;
                r_etkinlikler.DataBind();

                //kullanıcı sayacı başlangıç
                lbl_online.Text = Application["onlineziyaretci"].ToString();
                SqlCommand cmdsayac = new SqlCommand("SELECT * FROM sayac", baglan.baglan());
                SqlDataReader drsayac = cmdsayac.ExecuteReader();
                dl_sayac.DataSource = drsayac;
                dl_sayac.DataBind();
            
        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            SqlCommand giris = new SqlCommand("SELECT * FROM uye WHERE kadi=@1 AND sifre=@2", baglan.baglan());
            giris.Parameters.AddWithValue("@1", tb_kadi.Text);
            giris.Parameters.AddWithValue("@2", tb_sifre.Text);
            SqlDataReader dr = giris.ExecuteReader();
            DataTable dt = new DataTable("kadi");
            dt.Load(dr);

            if (dt.Rows.Count > 0) //böyle bir kullanıcı varsa
            {
                if (cb_benihatirla.Checked == true)
                {
                    kullaniciCookie.Values.Add("kadi", tb_kadi.Text);
                    kullaniciCookie.Expires = DateTime.Now.AddDays(+1);
                    Response.Cookies.Add(kullaniciCookie);

                    kullanicicookie2.Values.Add("sf", tb_sifre.Text);
                    kullanicicookie2.Expires = DateTime.Now.AddDays(+1);
                    Response.Cookies.Add(kullanicicookie2);

                }
                else
                {
                    if (kullaniciCookie != null  )
                    {
                        kullaniciCookie.Expires = DateTime.Now.AddDays(-1);
                        kullanicicookie2.Expires = DateTime.Now.AddDays(-1);
                        
                    }
                }

                SqlDataReader var = giris.ExecuteReader();
                pnl_kullanici.Visible = true;
                pnl_kullanicigiris.Visible = false;
                lbl_kadi.Text = dt.Rows[0]["kadi"].ToString();
                img_profil.ImageUrl = dt.Rows[0]["resim"].ToString();
                Session["kadi"] = dt.Rows[0]["kadi"].ToString();
                Session["kresim"] = dt.Rows[0]["resim"].ToString();

            }
            else {
                Response.Write("<script lang='JavaScript'>alert ('Hatalı kullanıcı adı');</script>");
                
            }
        }

        protected void ibtn_cikis_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("kadi");
            Session.Remove("kresim");
            pnl_kullanici.Visible = false;
            pnl_kullanicigiris.Visible = true;
        }

        protected void ibtn_ara_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("search.aspx?ara="+tb_ara.Text+"");
        }

        protected void iletişim_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("iletisim.aspx");
        }

        protected void ibtn_ayarlar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("uyeol.aspx?uye=3");
        }
    }
}