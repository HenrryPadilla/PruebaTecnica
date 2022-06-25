using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSQL
{
    public class InteraccionSQL
    {
        public DataTable ObtenerDataTable(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Cnx_DB_AlbatrosLab)) {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandTimeout = Properties.Settings.Default.TimeOutSQL;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }         
            return dt;
        }
    }
}
