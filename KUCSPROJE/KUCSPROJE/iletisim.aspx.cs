using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace KUCSPROJE
{
    public partial class iletisim : System.Web.UI.Page
    {   sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_gonder_Click(object sender, EventArgs e)
        {
            SqlCommand mesajkaydet = new SqlCommand("INSERT INTO iletisim(iletisimAdSoyad,iletisimEmail,iletisimicerik) VALUES(@1,@2,@3)", baglan.baglan());
            mesajkaydet.Parameters.AddWithValue("@1", tb_adsoyad.Text);
            mesajkaydet.Parameters.AddWithValue("@2", tb_mail.Text);
            mesajkaydet.Parameters.AddWithValue("@3", tb_micerik.Text);
            mesajkaydet.ExecuteNonQuery();

            Response.Write("<script lang='JavaScript'>alert ('mesajınız iletildi');</script>");
            Response.Redirect("index.aspx");
        }
    }
}