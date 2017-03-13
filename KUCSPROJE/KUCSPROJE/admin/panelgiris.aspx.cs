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
    public partial class panelgiris : System.Web.UI.Page
    {
        sqlbaglantisi baglan = new sqlbaglantisi();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Abandon();
        }
        protected void btn_giris_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT yoneticiAd+' '+yoneticiSoyad AS adsoyad FROM yonetici WHERE yoneticiKA='" + tb_ka.Text + "' AND yoneticiSF='" + tb_sf.Text + "'", baglan.baglan());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("dt");
            dt.Load(dr);

            if (dt.Rows.Count>0)
            {
                Session["KA"] = dt.Rows[0]["adsoyad"].ToString();
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert ('Hatalı Giriş Denemesi');</script>");
            }
        }
    }
}