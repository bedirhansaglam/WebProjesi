using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace KUCSPROJE.users
{
    public partial class makale : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
    string kategoriID = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            
            kategoriID = Request.QueryString["kategoriID"];
            if (kategoriID == "6")
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                SqlCommand cmdmakale = new SqlCommand("SELECT dbo.alt_kategori.alt_kategori_resim,dbo.makale.makaleID, dbo.makale.makaleBaslik, dbo.makale.makaleOzet, dbo.makale.makaleOkunma, dbo.makale.makaleYorumSayisi, dbo.makale.makaleTarih FROM     dbo.alt_kategori INNER JOIN dbo.makale ON dbo.alt_kategori.alt_kategori_ID = dbo.makale.alt_kategori_ID WHERE dbo.makale.kategoriID=@1", baglan.baglan());
                cmdmakale.Parameters.AddWithValue("@1", int.Parse(kategoriID));
                SqlDataReader drmakale = cmdmakale.ExecuteReader();
                dl_makale.DataSource = drmakale;
                dl_makale.DataBind();
            }
        }
    }
}