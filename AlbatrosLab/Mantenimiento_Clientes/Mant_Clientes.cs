using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;

namespace Mantenimiento_Clientes
{
    public class Mant_Clientes
    {
        public DataTable ObtenerClientes()
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();
            dt = Conexion.ObtenerDataTable("EXEC usp_ObtieneClientes ");
            return dt;
        }

        public DataTable GuardarClientes(string codigo_Cliente,
                                        string nombre,
                                        string rtn,
                                        string direccion)
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();

            dt = Conexion.ObtenerDataTable("EXEC usp_GuardaClientes '"
            + codigo_Cliente + "','"
            + nombre + "','"
            + rtn + "','"
            + direccion+"'");

            return dt;

        }

        public DataTable ModificaClientes(string codigo_Cliente,
                                        string nombre,
                                        string rtn,
                                        string direccion)
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();

            dt = Conexion.ObtenerDataTable("EXEC usp_ModificarClientes '"
           + codigo_Cliente + "','"
           + nombre + "','"
           + rtn + "','"
           + direccion + "'");

            return dt;

        }
        public DataTable EliminaClientes(string codigo_Cliente
                                            , string rtn)
        {
            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();

            dt = Conexion.ObtenerDataTable("EXEC usp_EliminarClientes '"
           + codigo_Cliente + "','"
           + rtn + "'");

            return dt;
        }
    }
}
