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
    public partial class etkinlik : System.Web.UI.Page
    {sqlbaglantisi baglan = new sqlbaglantisi();
    string etkinlik_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            etkinlik_id = Request.QueryString["etkinlik_id"];

            SqlCommand cek=new SqlCommand("SELECT * FROM etkinlik WHERE etkinlik_id=@1",baglan.baglan());
            cek.Parameters.AddWithValue("@1", int.Parse(etkinlik_id));
            SqlDataReader dr = cek.ExecuteReader();
            dl_etkinlik.DataSource = dr;
            dl_etkinlik.DataBind();
        }
    }
}