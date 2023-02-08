namespace PreEntregaAngieMonroy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manejadores.ManejadorUsuario.devolverUsuario(1);
            Manejadores.ManejadorProducto.obtenerProducto(1);
            Manejadores.ManejadorProductoVendido.obtenerProductosVendidos(1);
            Manejadores.ManejadorVenta.obtenerVentas(1);
            Manejadores.ManejadorLogin.InicioSesion("tobiascasazza@gmail.com", "SoyTobiasCasazza");

        }
    }
}