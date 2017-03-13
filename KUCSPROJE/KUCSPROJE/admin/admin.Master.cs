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
    public partial class admin : System.Web.UI.MasterPage
    {sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["KA"] != null)
                {
                    lblkullanici.Text = Session["KA"].ToString();

                }
                else
                {
                    Response.Redirect("panelgiris.aspx");
                }
            }
            mesajcek();
        }

        void mesajcek()
        {
            SqlCommand cek = new SqlCommand("SELECT * FROM iletisim",baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            DataTable dt = new DataTable("iletisim");
            dt.Load(dr);
            lbl_mesaj_sayisi.Text = dt.Rows.Count.ToString();
        }

        protected void ibtn_cikis_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("panelgiris.aspx");
        }
    }
}