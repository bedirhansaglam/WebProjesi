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
    public partial class WebForm3 : System.Web.UI.Page
    {sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                yorumcek();
                pnl_omayanyorum.Visible = false;
            }
        }

        void yorumcek()
        {
            SqlCommand cek = new SqlCommand("SELECT yorum.*,makale.makaleBaslik FROM yorum,makale WHERE makale.makaleID=yorum.makaleID AND yorumOnay=0", baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            gw_onaysızyorumlar.DataSource = dr;
            gw_onaysızyorumlar.DataBind();
        }

        protected void gw_onaysızyorumlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_onaysızyorumlar.SelectedIndex ==-1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen silmek istediğiniz yorumu seçiniz');</script>");
                }
                else if(gw_onaysızyorumlar.SelectedIndex>=0)
                {
                   
                    SqlCommand sil = new SqlCommand("DELETE FROM yorum WHERE yorumID=" + gw_onaysızyorumlar.SelectedValue + "", baglan.baglan());
                    sil.ExecuteNonQuery();
                    yorumcek();
                }
            }
            else if (e.CommandName == "onayla")
            {
               if(gw_onaysızyorumlar.SelectedIndex==-1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('Lütfen onaylamak istediğiniz yorumu seçiniz');</script>");
                }
                else if (gw_onaysızyorumlar.SelectedIndex >= 0)
                {
                    SqlCommand onayla = new SqlCommand("UPDATE yorum SET yorumOnay=1 WHERE yorumID=" + gw_onaysızyorumlar.SelectedValue + "", baglan.baglan());
                    onayla.ExecuteNonQuery();
                    yorumcek();
                }
                
            }
        }

        protected void ibtn_goster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_goster.ImageUrl == "~/image/goster.png")
            {
                ibtn_goster.ImageUrl = "~/image/gizle.png";
                pnl_omayanyorum.Visible = true;
            }
            else if(ibtn_goster.ImageUrl == "~/image/gizle.png")
            {
                ibtn_goster.ImageUrl = "~/image/goster.png";
                pnl_omayanyorum.Visible = false;
            }
        }
    }
}