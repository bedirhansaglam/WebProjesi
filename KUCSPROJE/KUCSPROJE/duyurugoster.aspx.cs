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
    public partial class duyurugoster : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
       string duyuru_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            duyuru_id = Request.QueryString["duyuru_id"];
            
                SqlCommand duyurucek = new SqlCommand("SELECT * FROM duyuru WHERE duyuru_id=@1", baglan.baglan());
                duyurucek.Parameters.AddWithValue("@1", int.Parse(duyuru_id));
                SqlDataReader drduyuru = duyurucek.ExecuteReader();
                dl_duyuru.DataSource = drduyuru;
                dl_duyuru.DataBind();
            
        }
    }
}