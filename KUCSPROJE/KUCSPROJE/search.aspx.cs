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
    public partial class search : System.Web.UI.Page
    {   sqlbaglantisi baglan = new sqlbaglantisi();
       string ara = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ara = Request.QueryString["ara"];
            SqlCommand cek = new SqlCommand("SELECT *,* FROM makale,alt_kategori WHERE (makale.alt_kategori_ID=alt_kategori.alt_kategori_ID AND makale.makaleBaslik LIKE '%"+ara+"%') OR (makale.makaleOzet LIKE '%"+ara+"%' AND makale.alt_kategori_ID=alt_kategori.alt_kategori_ID)", baglan.baglan());
            
            SqlDataReader dr = cek.ExecuteReader();
            DataTable dt = new DataTable("tbl");
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                dl_ara.DataSource = dt;
                dl_ara.DataBind();
            }
           
        }
    }
}