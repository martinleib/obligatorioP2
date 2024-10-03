using LogicaNegocio;

namespace InterfazUsuario
{
    internal class Program
    {
        private static Sistema sistema = new Sistema();
        static void Main(string[] args)
        {
            bool ingresoCero = false;
            while (!ingresoCero)
            {
                Console.WriteLine("Ingrese 1 para dar de alta un articulo");
                Console.WriteLine("Ingrese 2 para mostrar los clientes");
                Console.WriteLine("Ingrese 3 para mostrar los articulos");
                Console.WriteLine("Ingrese 4 para mostrar las publicaciones");
                Console.WriteLine("Ingrese 0 para salir");

                string opcionString = Console.ReadLine();
                int.TryParse(opcionString, out int opcionParsed);

                switch (opcionParsed)
                {
                    case 1:
                        AltaArticulo();
                        break;
                    case 2:
                        MostrarClientes();
                        break;
                    case 3:
                        MostrarArticulos();
                        break;
                    case 4:
                        MostrarPublicaciones();
                        break;
                    case 0:
                        ingresoCero = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            }
        }

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

        static void MostrarClientes()
        {
            Console.WriteLine(sistema.ListadoDeClientes());
        }

        static void MostrarArticulos()
        {
            Console.WriteLine("Ingrese la categoria de los articulos que desea ver");
            string categoria = Console.ReadLine();

            Console.WriteLine(sistema.ListadoDeArticulos(categoria));
        }

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
