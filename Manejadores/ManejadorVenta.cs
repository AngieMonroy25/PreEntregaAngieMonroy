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
    internal class ManejadorVenta
    {
        public static string cadenaConexion = "Data Source=DESKTOP-AUBNOJA\\MSSQLSERVER01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Clases.Venta obtenerVentas(long idUsuario)
        {
            Clases.Venta venta = new Clases.Venta();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario=@idUsuario", conn);
                SqlParameter idParam = new SqlParameter();
                idParam.Value = idUsuario;
                idParam.SqlDbType = SqlDbType.VarChar;
                idParam.ParameterName = "idUsuario";

                comando.Parameters.Add(idParam);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        venta.Id = reader.GetInt64(0);
                        venta.Comentarios = reader.GetString(1);
                        venta.IdUsuario = reader.GetInt64(0);

                        Console.WriteLine("Id = " + venta.Id);
                        Console.WriteLine("Comentarios = " + venta.Comentarios);
                        Console.WriteLine("IdUsuario = " + venta.IdUsuario);

                    }
                }



            }
            return venta;



        }
    }
}