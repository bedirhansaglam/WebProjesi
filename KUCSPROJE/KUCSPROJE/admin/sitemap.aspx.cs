using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Data.SqlClient;

namespace KUCSPROJE.admin
{
    public partial class sitemap : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_sitemap_Click(object sender, EventArgs e)
        {
            SqlCommand cmdkategoricek = new SqlCommand("SELECT * FROM kategori ORDER BY kategoriSıra ASC", baglan.baglan());//kategoriler çekiliyor
            SqlDataReader dr = cmdkategoricek.ExecuteReader();
            DataTable dt = new DataTable("kategori");
            dt.Load(dr);

            //daha önceden eklenmiş aynı adda xml dosyası varsa siler
            XmlTextWriter yaz = new XmlTextWriter(Server.MapPath("~/Web.sitemap"), System.Text.UTF8Encoding.UTF8);

            yaz.WriteStartDocument();  //Xml dökümanına ait declaration satırını oluşturur. Kısaca yazmaya başlar.
           
            yaz.WriteStartElement("siteMap");//sitemap adında element oluşturuldu
            yaz.WriteAttributeString("xmlns","http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");//xmlns attribute eklendi
            yaz.WriteStartElement("siteMapNode");//sitemap doğası gereği bir tane boş istiyor yada ana bi tane istiyorda olabilir..
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yaz.WriteStartElement("siteMapNode");
                yaz.WriteAttributeString("url",("makale.aspx?kategoriID="+int.Parse(dt.Rows[i]["kategoriID"].ToString())));
                yaz.WriteAttributeString("title",dt.Rows[i]["kategoriAd"].ToString());
                yaz.WriteAttributeString("description","");

                SqlCommand cmdaltkategoricek = new SqlCommand("SELECT * FROM alt_kategori WHERE kategoriID=@kategoriID ORDER BY alt_kategori_sıra ASC", baglan.baglan());
                cmdaltkategoricek.Parameters.AddWithValue("@kategoriID", int.Parse(dt.Rows[i]["kategoriID"].ToString()));
                SqlDataReader dr1 = cmdaltkategoricek.ExecuteReader();
                DataTable dt1 = new DataTable("alt_kategori");
                dt1.Load(dr1);

                if (dt1.Rows.Count >= 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        yaz.WriteStartElement("siteMapNode");
                        yaz.WriteAttributeString("url", ("kategoridetay.aspx?altkategori_id=" + int.Parse(dt1.Rows[j]["alt_kategori_ID"].ToString())));
                        yaz.WriteAttributeString("title", dt1.Rows[j]["alt_kategori_adi"].ToString());
                        yaz.WriteAttributeString("description", "");
                        yaz.WriteEndElement();
                    }
                    
                }
                yaz.WriteEndElement();
                 
            }
            yaz.WriteEndElement();
            yaz.WriteEndElement();
           
            yaz.Close();
            //XML akışı sonlandırıldı.

            Response.Write("<script lang='JavaScript'>alert ('SİTEMAP OLUŞTURULDU');</script>");
        }
    }
}