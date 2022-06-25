using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;

namespace Mantenimiento_Impuestos
{
    public class Mant_Impuestos
    {
        public DataTable ObtenerImpuestos() {
            
            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();
            dt=Conexion.ObtenerDataTable("EXEC usp_ObtieneImpuestos");
            return dt;
        }
    }
}
