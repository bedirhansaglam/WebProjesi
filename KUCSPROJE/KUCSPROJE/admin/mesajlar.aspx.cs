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
    public partial class mesajlar : System.Web.UI.Page
    {sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_mesaj.Visible = false;
            }
            mesajcek();
        }

        void mesajcek()
        {
            SqlCommand cek = new SqlCommand("SELECT * FROM iletisim", baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            gw_gelen_mesajlar.DataSource = dr;
            gw_gelen_mesajlar.DataBind();
        }

        protected void gw_gelen_mesajlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gw_gelen_mesajlar.SelectedIndex == -1)
            {
                pnl_mesaj.Visible = false;
            }
            else if (gw_gelen_mesajlar.SelectedIndex >= 0)
            {
                pnl_mesaj.Visible = true;
                SqlCommand cek = new SqlCommand("SELECT * FROM iletisim WHERE iletisimID=@1", baglan.baglan());
                cek.Parameters.AddWithValue("@1", gw_gelen_mesajlar.SelectedValue);
                SqlDataReader dr = cek.ExecuteReader();
                dl_mesaj.DataSource = dr;
                dl_mesaj.DataBind();
            
            }
            
        }

        protected void gw_gelen_mesajlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_gelen_mesajlar.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Mesajı silmek için önce mesaj seçmelisiniz');</script>"); }
                else if (gw_gelen_mesajlar.SelectedIndex >= 0)
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM iletisim WHERE iletisimID=@1", baglan.baglan());
                    sil.Parameters.AddWithValue("@1", gw_gelen_mesajlar.SelectedValue);
                    sil.ExecuteNonQuery();
                    mesajcek();
                    gw_gelen_mesajlar.SelectedIndex = -1;
                }
            }
        }
    }
}