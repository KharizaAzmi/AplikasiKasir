using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiKasir
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source=LAPTOP-TECKEQ2M;initial catalog=DB_KasirApp;integrated security=true";
            return Conn;
        }

    }
}
