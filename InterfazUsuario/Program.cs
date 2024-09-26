using LogicaNegocio;

namespace InterfazUsuario
{
    internal class Program
    {
        private static Sistema sistema = new Sistema();
        static void Main(string[] args)
        { }

        // ALTA ARTICULO
        static void AltaArticulo()
        {
            Console.WriteLine("Ingrese un precio");
            string precioString = Console.ReadLine();
            int.TryParse(precioString, out int precio);

            Console.WriteLine("Ingrese un nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese una categoria");
            string categoria = Console.ReadLine();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(categoria) && precio > 0)
            {
                sistema.AltaArticulo(precio, nombre, categoria);
            }
            else
            {
                Console.WriteLine("Ninguno de los campos puede estar vacio");
            }
        }

        // MOSTRAR CLIENTES
        static void MostrarClientes()
        {
            Console.WriteLine(sistema.ListadoDeClientes());
        }

        // MOSTRAR ARTICULOS
        static void MostrarArticulos()
        {
            Console.WriteLine("Ingrese la categoria de los articulos que desea ver");
            string categoria = Console.ReadLine();

            Console.WriteLine(sistema.ListadoDeArticulos(categoria));
        }

        // MOSTRAR PUBLICACIONES
        static void MostrarPublicaciones()
        {
            Console.WriteLine("Ingrese la primer fecha del rango");
            string primeraFechaString = Console.ReadLine();
            DateTime.TryParse(primeraFechaString, out DateTime primeraFechaParsed);

            Console.WriteLine("Ingrese la segunda fecha (debe ser posterior a la primera fecha)");

            string segundaFechaString = Console.ReadLine();
            DateTime.TryParse(segundaFechaString, out DateTime segundaFechaParsed);

            if (primeraFechaParsed < segundaFechaParsed)
            {
                Console.WriteLine(sistema.ListadoDePublicaciones(primeraFechaParsed, segundaFechaParsed));
            }
        }
    }
}
