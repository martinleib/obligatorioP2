﻿using LogicaNegocio;
using System.ComponentModel.Design;

namespace InterfazUsuario
{
    internal class Program
    {
        private static Sistema sistema = new Sistema();
        static void Main(string[] args)
        {
            sistema.PrecargaAdministrador();
            sistema.PrecargaCliente();
            sistema.PrecargaArticulo();
            sistema.PrecargaVenta();
            sistema.PrecargaSubasta();
            sistema.PrecargaOferta();

            Menu();
        }

        static void Menu()
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
                Console.WriteLine("Articulo dado de alta con exito.");
            }
            else
            {
                Console.WriteLine("Ninguno de los campos puede estar vacio");
            }
        }

        static void MostrarClientes()
        {
            try
            {
                foreach (Cliente cliente in sistema.ListadoDeClientes())
                {
                    Console.WriteLine(cliente);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void MostrarArticulos()
        {
            Console.WriteLine("Ingrese la categoria de los articulos que desea ver");
            string categoria = Console.ReadLine();

            if (!string.IsNullOrEmpty(categoria))
                try
                {
                    {
                        foreach (Articulo articulo in sistema.ListadoDeArticulos(categoria))
                        {
                            Console.WriteLine(articulo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            else
            {
                Console.WriteLine("Debes escribir una categoría");
            }
        }

        static void MostrarPublicaciones()
        {
            Console.WriteLine("Ingrese la primer fecha del rango");
            string primeraFechaString = Console.ReadLine();

            Console.WriteLine("Ingrese la segunda fecha");
            string segundaFechaString = Console.ReadLine();

            if (string.IsNullOrEmpty(primeraFechaString) || string.IsNullOrEmpty(segundaFechaString))
            {
                Console.WriteLine("Las fechas no pueden estar vacías");
            }
            else
            {
                DateTime.TryParse(primeraFechaString, out DateTime primeraFechaParsed);
                DateTime.TryParse(segundaFechaString, out DateTime segundaFechaParsed);
                try
                {
                    if (primeraFechaParsed < segundaFechaParsed)
                    {
                        foreach (Publicacion publicacion in sistema.ListadoDePublicaciones(primeraFechaParsed, segundaFechaParsed))
                        {
                            Console.WriteLine(publicacion);
                        }
                    }
                    else
                    {
                        foreach (Publicacion publicacion in sistema.ListadoDePublicaciones(segundaFechaParsed, primeraFechaParsed))
                        {
                            Console.WriteLine(publicacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
