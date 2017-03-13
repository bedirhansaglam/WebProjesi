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
    public partial class kategoridetay : System.Web.UI.Page
    {    sqlbaglantisi baglan = new sqlbaglantisi();
         string kategori_id = "";
        protected void Page_Load(object sender, EventArgs e)
    {
             kategori_id = Request.QueryString["altkategori_id"];
            SqlCommand cmdkategori = new SqlCommand("SELECT dbo.alt_kategori.alt_kategori_resim,dbo.makale.makaleID, dbo.makale.makaleBaslik, dbo.makale.makaleOzet, dbo.makale.makaleOkunma, dbo.makale.makaleYorumSayisi, dbo.makale.makaleTarih,dbo.alt_kategori.alt_kategori_ID  FROM     dbo.alt_kategori INNER JOIN dbo.makale ON dbo.alt_kategori.alt_kategori_ID = dbo.makale.alt_kategori_ID WHERE dbo.alt_kategori.alt_kategori_ID=@1  ", baglan.baglan());
            cmdkategori.Parameters.AddWithValue("@1", int.Parse(kategori_id));
            SqlDataReader drkategori = cmdkategori.ExecuteReader();
            dl_kategori.DataSource = drkategori;
            dl_kategori.DataBind();
        }
    }
}