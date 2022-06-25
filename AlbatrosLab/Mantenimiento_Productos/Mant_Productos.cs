using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;

namespace Mantenimiento_Productos
{
    public class Mant_Productos
    {
        public DataTable ObtenerProductos()
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();
            dt = Conexion.ObtenerDataTable("EXEC usp_ObtieneProductos ");
            return dt;
        }

        public DataTable GuardarProducto(int codigo_Producto,
                                        string descripcion_producto,
                                        decimal precio,
                                        int impuesto)
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();
           
            dt = Conexion.ObtenerDataTable("EXEC usp_GuardaProductos "
            + codigo_Producto + ",'"
            + descripcion_producto + "',"
            + precio + ","
            + impuesto);

            return dt;
            
        }

        public DataTable ModificaProducto(int codigo_Producto,
                                        string descripcion_producto,
                                        decimal precio,
                                        int impuesto)
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();

            dt = Conexion.ObtenerDataTable("EXEC usp_ModificaProductos "
            + codigo_Producto + ",'"
            + descripcion_producto + "',"
            + precio + ","
            + impuesto);

            return dt;

        }
        public DataTable EliminaProducto(int codigo_Producto)
        {

            DataTable dt = new DataTable();
            InteraccionSQL Conexion = new InteraccionSQL();

            dt = Conexion.ObtenerDataTable("EXEC usp_EliminaProductos "
            + codigo_Producto);

            return dt;

        }
    }

    
}
