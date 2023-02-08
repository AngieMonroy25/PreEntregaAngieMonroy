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
    internal class ManejadorProducto
    {
        public static string cadenaConexion = "Data Source=DESKTOP-AUBNOJA\\MSSQLSERVER01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Clases.Producto obtenerProducto(long idUsuario)
        {
            Clases.Producto producto = new Clases.Producto();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", conn);
                conn.Open();

                SqlParameter prodParam = new SqlParameter();
                prodParam.Value = idUsuario;
                prodParam.SqlDbType = SqlDbType.VarChar;
                prodParam.ParameterName = "IdUsuario";

                comando.Parameters.Add(prodParam);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine("Id = " + Convert.ToInt64(reader["Id"]));
                        Console.WriteLine("Descripciones = " + reader["Descripciones"].ToString());
                        Console.WriteLine("Costo = " + reader.GetDecimal(2));
                        Console.WriteLine("Precio Venta = " + Convert.ToDecimal(reader["PrecioVenta"]));
                        Console.WriteLine("Stock = " + Convert.ToInt32(reader["Stock"]));
                        Console.WriteLine("Id Usuario = " + Convert.ToInt64(reader["IdUsuario"]));


                    }


                }
                return producto;
            }

        }
    }
}
