using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;

namespace KUCSPROJE
{
    public class Global : System.Web.HttpApplication
    {
            sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["onlineziyaretci"] = 0;
            Application["ip"] = "";
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Application["ip"] == "")
            { Application["onlineziyaretci"] = ((int)Application["onlineziyaretci"]) + 1; }

            Application["ip"] = Request.ServerVariables["Remote_Addr"].ToString();
            
            SqlCommand vericek = new SqlCommand("SELECT * FROM sayac", baglan.baglan());
            SqlDataReader dr = vericek.ExecuteReader();
            DataTable tablo = new DataTable();
            tablo.Load(dr);
            string komut = "";
            if (((DateTime)tablo.Rows[0]["tarih"]).Day == DateTime.Now.Day)
            {
                //Gün değişmemiş. Tüm değerleri artırıyoruz.
                //Gün içinde bu komut çalışır.
                komut = "update sayac set gunluk=gunluk+1, aylik=aylik+1, yillik=yillik+1, toplam=toplam+1";
            }
            else
            {
                //Gün değişmiş ise kontrollerimizi yapıyoruz.
                if (((DateTime)tablo.Rows[0]["tarih"]).Month == DateTime.Now.Month)
                {
                    //Gün değişmiş, Ay değişmemiş ise.
                    //Hergün bir defa bu komut çalışır.
                    komut = "update sayac set tarih='" + DateTime.Now.ToString("yyyy.MM.dd") + "', gunluk=1, aylik=aylik+1, yillik=yillik+1, toplam=toplam+1";
                }
                else
                {
                    //Gün, Ay değişmiş ise.
                    if (((DateTime)tablo.Rows[0]["tarih"]).Year == DateTime.Now.Year)
                    {
                        //Gün, Ay değişmiş, ama Yıl aynı ise.
                        //Ayda bir defa bu komut çalışır.
                        komut = "update sayac set tarih='" + DateTime.Now.ToString("yyyy.MM.dd") + "', gunluk=1, aylik=1, yillik=yillik+1, toplam=toplam+1";
                    }
                    else
                    {
                        //Gün, Ay, Yıl değişmiş ise tüm değerleri sıfırlıyoruz.
                        //Yılda bir defa bu komut çalışır.
                        komut = "update sayac set tarih='" + DateTime.Now.ToString("yyyy.MM.dd") + "', gunluk=1, aylik=1, yillik=1, toplam=toplam+1";
                    }
                }
            }
             SqlCommand guncelle = new SqlCommand(komut, baglan.baglan());
             guncelle.ExecuteNonQuery();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["onlineziyaretci"] = ((int)Application["onlineziyaretci"]) - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
            Session.Abandon();
        }
    }
}