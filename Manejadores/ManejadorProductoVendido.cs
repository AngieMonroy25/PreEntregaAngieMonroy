using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaAngieMonroy.Manejadores
{
    internal class ManejadorProductoVendido
    {
        public static string cadenaConexion = "Data Source=DESKTOP-AUBNOJA\\MSSQLSERVER01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Clases.Producto> obtenerProductosVendidos(long idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                List<long> idProductos = new List<long>();
                SqlCommand comando = new SqlCommand($"SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = {idUsuario}", conn);
                List<Clases.Producto> productoVendido = new List<Clases.Producto>();
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));

                    }
                }

                List<Clases.Producto> productos = new List<Clases.Producto>();
                foreach (var item in idProductos)
                {
                    Clases.Producto prodTemp = ManejadorProducto.obtenerProducto(item);
                    productos.Add(prodTemp);
                }
                return productos;

            }

        }
    }
}
