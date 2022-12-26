using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//#2
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection 
                (@"Data Source = GROOVYPRIMAT\SQLEXPRESS; Initial Catalog = DboTicariOtomasyon; Integrated Security = True");
            baglan.Open();
            return baglan;
        }
    }
}
