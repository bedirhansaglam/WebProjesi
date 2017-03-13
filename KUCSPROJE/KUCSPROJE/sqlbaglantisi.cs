using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace KUCSPROJE
{
    public class sqlbaglantisi
    {
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=siteDB;Integrated Security=true");
            baglanti.Open();
            //bağlantı hatalarının şişmesini engellemek için
            SqlConnection.ClearPool(baglanti);
            SqlConnection.ClearAllPools();
            return (baglanti);
        }
    }
}