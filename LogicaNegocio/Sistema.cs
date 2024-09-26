﻿using System.Collections.Generic;

namespace LogicaNegocio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();

        public void AltaUsuarioAdministrador(string nombre, string apellido, string email, string password)
        {
            Administrador administrador = new Administrador(nombre, apellido, email, password);
            if (!_usuarios.Contains(administrador))
            {
                _usuarios.Add(administrador);
            }
        }

        public void AltaUsuarioCliente(string nombre, string apellido, string email, string password, double saldo)
        {
            Cliente cliente = new Cliente(nombre, apellido, email, password, saldo);
            if (!_usuarios.Contains(cliente))
            {
                _usuarios.Add(cliente);
            }
        }

        public Usuario BuscarUsuario(string email)
        {
            int i = 0;
            Usuario usuario = null;
            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i].Email == email)
                {
                    usuario = _usuarios[i];
                }
                i++;
            }
            return usuario;
        }
        public void AltaPublicacionVenta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos, bool relampago)
        {
            Venta venta = new Venta(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, articulos, relampago);
            if (!_publicaciones.Contains(venta))
            {
                _publicaciones.Add(venta);
            }
        }

        public void AltaPublicacionSubasta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos, List<Oferta> ofertas)
        {
            Subasta subasta = new Subasta(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, articulos, ofertas);
            if (!_publicaciones.Contains(subasta))
            {
                _publicaciones.Add(subasta);
            }
        }

        public void AltaArticulo(int precio, string nombre, string categoria)
        {
            Articulo articulo = new Articulo(precio, nombre, categoria);
            if (!_articulos.Contains(articulo))
            {
                _articulos.Add(articulo);
            }
        }

        public List<Articulo> ListaDeArticulos(string idArticulo, string idPublicacion)
        {
            int i = 0;
            bool aux = false;
            Articulo articulo = BuscarArticulo(idArticulo);
            while (i < _publicaciones.Count && aux == false && articulo != null)
            {
                if (_publicaciones[i].Id == idPublicacion.ToUpper() && _publicaciones[i].NoEstaEnLaListaElArticulo(articulo) == true)
                {
                    _publicaciones[i].Articulo.Add(articulo);
                }
                i++;
            }
            return _publicaciones[i].Articulo;
        }

        private void PrecargaAdministrador()
        {
            AltaUsuarioAdministrador("Carlos", "Martinez", "CarlosM2001@gmail.com", "CarlosM123");
            AltaUsuarioAdministrador("Sofía", "Gomez", "SofiaG2020@gmail.com", "SofiaG123");
        }

        private void PrecargaCliente()
        {
            AltaUsuarioCliente("Sofía", "Gomez", "SofiaG2002@gmail.com", "SofiaG456", 1500);

            AltaUsuarioCliente("Javier", "Lopez", "JavierL1995@gmail.com", "JavierL789", 3200);

            AltaUsuarioCliente("Ana", "Fernandez", "AnaF1987@gmail.com", "AnaF101", 4000);

            AltaUsuarioCliente("Pedro", "Ramirez", "PedroR1998@gmail.com", "PedroR202", 2700);

            AltaUsuarioCliente("María", "Hernandez", "MariaH1993@gmail.com", "MariaH303", 1800);

            AltaUsuarioCliente("Luis", "Morales", "LuisM2003@gmail.com", "LuisM404", 3600);

            AltaUsuarioCliente("Elena", "Diaz", "ElenaD2001@gmail.com", "ElenaD505", 2200);

            AltaUsuarioCliente("Fernando", "Cruz", "FernandoC1999@gmail.com", "FernandoC606", 3100);

            AltaUsuarioCliente("Lucía", "Vasquez", "LuciaV1989@gmail.com", "LuciaV707", 2300);

            AltaUsuarioCliente("Andrés", "Pérez", "AndresP2005@gmail.com", "AndresP808", 2900);
        }

        private void PrecargaArticulo()
        {
            AltaArticulo(100, "Silla de oficina", "Muebles");

            AltaArticulo(250, "Mesa de café", "Muebles");

            AltaArticulo(50, "Lámpara de mesa", "Iluminación");

            AltaArticulo(75, "Escritorio", "Muebles");

            AltaArticulo(200, "Cama individual", "Muebles");

            AltaArticulo(150, "Estantería", "Muebles");

            AltaArticulo(300, "Televisor", "Electrónica");

            AltaArticulo(400, "Sofá", "Muebles");

            AltaArticulo(60, "Reloj de pared", "Decoración");

            AltaArticulo(80, "Cuadro decorativo", "Decoración");

            AltaArticulo(20, "Maceta", "Jardinería");

            AltaArticulo(45, "Planta artificial", "Jardinería");

            AltaArticulo(30, "Candelabro", "Iluminación");

            AltaArticulo(90, "Almohada", "Textiles");

            AltaArticulo(150, "Manta", "Textiles");

            AltaArticulo(500, "Cocina a gas", "Electrodomésticos");

            AltaArticulo(350, "Refrigerador", "Electrodomésticos");

            AltaArticulo(80, "Tostadora", "Electrodomésticos");

            AltaArticulo(120, "Batidora", "Electrodomésticos");

            AltaArticulo(100, "Horno eléctrico", "Electrodomésticos");

            AltaArticulo(25, "Cuchillo de cocina", "Utensilios");

            AltaArticulo(35, "Tabla de cortar", "Utensilios");

            AltaArticulo(15, "Vaso", "Utensilios");

            AltaArticulo(40, "Plato hondo", "Utensilios");

            AltaArticulo(60, "Juego de cubiertos", "Utensilios");

            AltaArticulo(110, "Cafetera", "Electrodomésticos");

            AltaArticulo(130, "Microondas", "Electrodomésticos");

            AltaArticulo(300, "Console de videojuegos", "Electrónica");

            AltaArticulo(600, "Laptop", "Electrónica");

            AltaArticulo(20, "Auriculares", "Electrónica");

            AltaArticulo(75, "Cámara instantánea", "Electrónica");

            AltaArticulo(250, "Proyector", "Electrónica");

            AltaArticulo(150, "Bicicleta", "Deportes");

            AltaArticulo(200, "Patinete", "Deportes");

            AltaArticulo(50, "Pelota de fútbol", "Deportes");

            AltaArticulo(80, "Raqueta de tenis", "Deportes");

            AltaArticulo(90, "Zapatillas deportivas", "Ropa");

            AltaArticulo(120, "Chaqueta", "Ropa");

            AltaArticulo(100, "Pantalones", "Ropa");

            AltaArticulo(200, "Camisa", "Ropa");

            AltaArticulo(250, "Vestido", "Ropa");

            AltaArticulo(180, "Bolso de mano", "Accesorios");

            AltaArticulo(300, "Mochila", "Accesorios");

            AltaArticulo(90, "Gafas de sol", "Accesorios");

            AltaArticulo(75, "Cinturón", "Accesorios");

            AltaArticulo(100, "Sombrero", "Accesorios");

            AltaArticulo(200, "Joyería", "Accesorios");

            AltaArticulo(250, "Espejo decorativo", "Decoración");

            AltaArticulo(130, "Cortinas", "Textiles");

            AltaArticulo(160, "Mueble de TV", "Muebles");
        }
        private void PrecargaVenta()
        {
            AltaPublicacionVenta("Mesa de comedor", "ABIERTA", new DateTime(2023, 6, 15), new DateTime(2024, 11, 20), null, null, ListaDeArticulos("ART11", "PUB2"), true);

            AltaPublicacionVenta("Sofa cama", "ABIERTA", new DateTime(2023, 7, 1), new DateTime(2024, 9, 15), null, null, ListaDeArticulos("ART10", "PUB3"), false);

            AltaPublicacionVenta("Cama matrimonial", "ABIERTA", new DateTime(2023, 8, 10), new DateTime(2024, 12, 5), null, null, ListaDeArticulos("ART9", "PUB4"), true);

            AltaPublicacionVenta("Televisor", "ABIERTA", new DateTime(2023, 5, 25), new DateTime(2024, 10, 1), null, null, ListaDeArticulos("ART8", "PUB5"), false);

            AltaPublicacionVenta("Estantería", "ABIERTA", new DateTime(2023, 9, 12), new DateTime(2024, 11, 30), null, null, ListaDeArticulos("ART7", "PUB6"), true);

            AltaPublicacionVenta("Cocina completa", "ABIERTA", new DateTime(2023, 10, 5), new DateTime(2024, 8, 18), null, null, ListaDeArticulos("ART6", "PUB7"), false);

            AltaPublicacionVenta("Frigorífico", "ABIERTA", new DateTime(2023, 6, 20), new DateTime(2024, 9, 25), null, null, ListaDeArticulos("ART5", "PUB8"), true);

            AltaPublicacionVenta("Silla de oficina", "ABIERTA", new DateTime(2023, 11, 1), new DateTime(2024, 12, 12), null, null, ListaDeArticulos("ART4", "PUB9"), true);

            AltaPublicacionVenta("Computadora portátil", "ABIERTA", new DateTime(2023, 7, 15), new DateTime(2024, 10, 30), null, null, ListaDeArticulos("ART3", "PUB10"), false);

            AltaPublicacionVenta("Mesa de noche", "ABIERTA", new DateTime(2023, 8, 25), new DateTime(2024, 11, 15), null, null, ListaDeArticulos("ART2", "PUB11"), true);
        }

        private void PrecargaSubasta()
        {
            AltaPublicacionSubasta("Pintura original", "ABIERTA", new DateTime(2023, 9, 1), new DateTime(2024, 12, 10), null, null, ListaDeArticulos("ART7", "PUB12"), null);

            AltaPublicacionSubasta("Colección de monedas", "ABIERTA", new DateTime(2023, 8, 15), new DateTime(2024, 11, 20), null, null, ListaDeArticulos("ART4", "PUB13"), null);

            AltaPublicacionSubasta("Reloj antiguo", "ABIERTA", new DateTime(2023, 10, 5), new DateTime(2024, 9, 30), null, null, ListaDeArticulos("ART3", "PUB14"), null);

            AltaPublicacionSubasta("Bicicleta de montaña", "ABIERTA", new DateTime(2023, 11, 1), new DateTime(2024, 10, 15), null, null, ListaDeArticulos("ART5", "PUB15"), null);

            AltaPublicacionSubasta("Joyería de plata", "ABIERTA", new DateTime(2023, 7, 20), new DateTime(2024, 8, 25), null, null, ListaDeArticulos("ART12", "PUB16"), null);

            AltaPublicacionSubasta("Cámara fotográfica", "ABIERTA", new DateTime(2023, 12, 10), new DateTime(2024, 11, 5), null, null, ListaDeArticulos("ART11", "PUB17"), null);

            AltaPublicacionSubasta("Juego de té", "ABIERTA", new DateTime(2023, 10, 20), new DateTime(2024, 9, 5), null, null, ListaDeArticulos("ART43", "PUB18"), null);

            AltaPublicacionSubasta("Sofá vintage", "ABIERTA", new DateTime(2023, 9, 30), new DateTime(2024, 12, 1), null, null, ListaDeArticulos("ART29", "PUB19"), null);

            AltaPublicacionSubasta("Guitarra eléctrica", "ABIERTA", new DateTime(2023, 8, 1), new DateTime(2024, 10, 25), null, null, ListaDeArticulos("ART18", "PUB20"), null);

            AltaPublicacionSubasta("Escultura moderna", "ABIERTA", new DateTime(2023, 11, 15), new DateTime(2024, 10, 5), null, null, ListaDeArticulos("ART17", "PUB21"), null);
        }
        public Articulo BuscarArticulo(string id)
        {
            int i = 0;
            Articulo articulo = null;
            while (i < _articulos.Count && articulo == null)
            {
                if (_articulos[i].Id == id.ToUpper())
                {
                    articulo = _articulos[i];
                }
                i++;
            }
            return articulo;
        }


        public List<Cliente> ListadoDeClientes() 
        { 
            List<Cliente> _listaDeClientes = new List<Cliente>();
            Cliente cliente = null;

            for(int i = 0; i< _usuarios.Count; i++)
            {
                if( _usuarios[i] is Cliente)
                {
                    cliente = (Cliente) _usuarios[i];
                    _listaDeClientes.Add(cliente);
                }
            }
            return _listaDeClientes;
        }

        public List<Publicacion> ListadoDePublicaciones(DateTime fechaUno, DateTime fechaDos)
        {
            List<Publicacion> _listaDePublicaciones = new List<Publicacion>();

            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.FechaPublicacion >= fechaUno && publicacion.FechaPublicacion <= fechaDos)
                {
                    _listaDePublicaciones.Add(publicacion);
                }
            }

            return _listaDePublicaciones;
        }

        public List<Articulo> ListadoDeArticulos(string categoria)
        {
            List<Articulo> _listaDeArticulos = new List<Articulo>();

            foreach (Articulo articulo in _articulos)
            {
                if (articulo.Categoria.Trim().ToLower() == categoria.Trim().ToLower())
                {
                    _listaDeArticulos.Add(articulo);
                }
            }

            return _listaDeArticulos;
        }
    }
}
