using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace KUCSPROJE.admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_bannerekle.Visible = false;
                //banner başlangıç
                SqlCommand bannercek = new SqlCommand("SELECT * FROM banner", baglan.baglan());
                SqlDataReader drbanner = bannercek.ExecuteReader();
                DataTable dtbanner = new DataTable("banner");
                dtbanner.Load(drbanner);
                gw_banner.DataSource = dtbanner;
                gw_banner.DataBind();
                //banner son

                fu_sagresim.Enabled = false;
                fu_solresim.Enabled = false;
                tb_label.Enabled = false;
            }
        }

        protected void ibtn_banner_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_banner.ImageUrl == "~/image/goster.png")
            {
                pnl_bannerekle.Visible = true;
                ibtn_banner.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_banner.ImageUrl == "~/image/gizle.png")
            {
                pnl_bannerekle.Visible = false;
                ibtn_banner.ImageUrl = "~/image/goster.png";
            }
        }

        protected void gw_banner_SelectedIndexChanged(object sender, EventArgs e)
        {
            fu_sagresim.Enabled = true;
            fu_solresim.Enabled = true;
            tb_label.Enabled = true;

        }

        protected void ibtn_kaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (fu_sagresim.HasFile)
            {
                fu_sagresim.SaveAs(Server.MapPath("/banner/" + fu_sagresim.FileName));
                SqlCommand kaydet = new SqlCommand("UPDATE banner SET banner_resimiki=@1 WHERE banner_id=@2", baglan.baglan());
                kaydet.Parameters.AddWithValue("@1", "/banner/" + fu_sagresim.FileName);
                kaydet.Parameters.AddWithValue("@2", gw_banner.SelectedValue);
                kaydet.ExecuteNonQuery();
            }

            if (fu_solresim.HasFile)
            {
                fu_solresim.SaveAs(Server.MapPath("/banner/" + fu_solresim.FileName));
                SqlCommand kaydet = new SqlCommand("UPDATE banner SET banner_resim=@1 WHERE banner_id=@2", baglan.baglan());
                kaydet.Parameters.AddWithValue("@1", "/banner/" + fu_solresim.FileName);
                kaydet.Parameters.AddWithValue("@2", gw_banner.SelectedValue);
                kaydet.ExecuteNonQuery();
            }

            if (tb_label.Text != "")
            {
                SqlCommand kaydet = new SqlCommand("UPDATE banner SET banner_yazi=@1 WHERE banner_id=@2", baglan.baglan());
                kaydet.Parameters.AddWithValue("@1", tb_label.Text);
                kaydet.Parameters.AddWithValue("@2", gw_banner.SelectedValue);
                kaydet.ExecuteNonQuery();
            }

            Response.Redirect("banner.aspx");
        }
    }
}