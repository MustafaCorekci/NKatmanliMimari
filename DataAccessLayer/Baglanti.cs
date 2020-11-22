using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class Baglanti
    {
        public static SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MN3O9G6\SQLEXPRESS;Initial Catalog=dbPersonel;User ID=sa;Password=m10zxcvb"); 
    }
}
