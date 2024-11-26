using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace LogicaNegocio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();

        private static Sistema _instancia;

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }

                return _instancia;
            }
        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        private Sistema()
        {
            PrecargaAdministrador();
            PrecargaCliente();
            PrecargaArticulo();
            PrecargaVenta();
            PrecargaSubasta();
            PrecargaOferta();
        }

        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }

        public void AltaAdministrador(string nombre, string apellido, string email, string password)
        {
            Usuario administrador = new Usuario(nombre, apellido, email, password);
            administrador.Validar();
            if (!_usuarios.Contains(administrador))
            {
                _usuarios.Add(administrador);
            }
        }

        public Usuario BuscarUsuario(string email, string password)
        {
            int i = 0;
            Usuario usuario = null;

            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i].Email.Trim().ToUpper() == email.Trim().ToUpper() &&
                    _usuarios[i].Password == password)
                {
                    usuario = _usuarios[i];
                }

                i++;
            }

            return usuario;
        }

        public Cliente ObtenerCliente(string id)
        {
            int i = 0;
            Cliente usuarioCliente = null;

            while (i < _usuarios.Count && usuarioCliente == null && !string.IsNullOrEmpty(id))
            {
                if (_usuarios[i] is Cliente && _usuarios[i].Id.Trim().ToUpper() == id.Trim().ToUpper())
                {
                    usuarioCliente = (Cliente)_usuarios[i];
                }

                i++;
            }

            return usuarioCliente;
        }

        public Usuario ObtenerAdmin(string id)
        {
            int i = 0;
            Usuario usuarioAdmin = null;

            while (i < _usuarios.Count && usuarioAdmin == null && !string.IsNullOrEmpty(id))
            {
                if (_usuarios[i] is not Cliente && _usuarios[i].Id.Trim().ToUpper() == id.Trim().ToUpper())
                {
                    usuarioAdmin = _usuarios[i];
                }

                i++;
            }

            return usuarioAdmin;
        }

        // Precarga administrador
        // Usa el metodo “AltaAdministrador” para crear manualmente instancias de tipo administrador.
        public void PrecargaAdministrador()
        {
            AltaAdministrador("prueba", "prueba", "admin", "password");
            AltaAdministrador("Carlos", "Martinez", "CarlosM2001@gmail.com", "CarlosM123");
            AltaAdministrador("Sofía", "Gomez", "SofiaG2020@gmail.com", "SofiaG123");
        }

        // METODOS CLIENTE
        // Alta cliente
        // Es un metodo que crea una nueva instancia cliente. Verifica que no esté en la lista de usuarios de la clase sistema y luego lo agrega a dicha lista.
        public void AltaCliente(string nombre, string apellido, string email, string password, double saldo)
        {
            Cliente cliente = new Cliente(nombre, apellido, email, password, saldo);
            cliente.Validar();

            if (_usuarios.Contains(cliente))
            {
                throw new Exception("Ya existe un usuario registrado con ese correo");
            }
            
            _usuarios.Add(cliente);
        }

        // Precarga cliente
        // Usa el metodo “AltaCliente” para crear manualmente instancias de tipo cliente.
        public void PrecargaCliente()
        {
            //Comienzan desde la id : USU3 ? quien sabe
            AltaCliente("prueba", "prueba", "user", "password", 3000);

            AltaCliente("Sofía", "Gomez", "SofiaG2002@gmail.com", "SofiaG456", 1500);

            AltaCliente("Javier", "Lopez", "JavierL1995@gmail.com", "JavierL789", 3200);

            AltaCliente("Ana", "Fernandez", "AnaF1987@gmail.com", "AnaaF101", 4000);

            AltaCliente("Pedro", "Ramirez", "PedroR1998@gmail.com", "PedroR202", 2700);

            AltaCliente("María", "Hernandez", "MariaH1993@gmail.com", "MariaH303", 1800);

            AltaCliente("Luis", "Morales", "LuisM2003@gmail.com", "LuisM404", 3600);

            AltaCliente("Elena", "Diaz", "ElenaD2001@gmail.com", "ElenaD505", 2200);

            AltaCliente("Fernando", "Cruz", "FernandoC1999@gmail.com", "FernandoC606", 3100);

            AltaCliente("Lucía", "Vasquez", "LuciaV1989@gmail.com", "LuciaV707", 2300);

            AltaCliente("Andrés", "Pérez", "AndresP2005@gmail.com", "AndresP808", 2900);
        }

        public bool ModificarSaldo(string id, double monto)
        {
            bool result = false;

            Cliente clienteBuscado = ObtenerCliente(id);

            if (clienteBuscado != null && monto > 0)
            {
                clienteBuscado.Saldo += monto;
                result = true;
            }

            return result;
        }

        // METODOS ARTICULO
        // Alta articulo
        // Es un metodo que crea una nueva instancia articulo, verifica que no esté en la lista de articulos de la clase sistema y luego lo agrega a dicha lista.
        public void AltaArticulo(double precio, string nombre, string categoria)
        {
            Articulo articulo = new Articulo(precio, nombre, categoria);
            articulo.Validar();
            if (!_articulos.Contains(articulo) || true)
            {
                _articulos.Add(articulo);
            }
        }

        // Precarga articulo
        // Usa el metodo “AltaArticulo” para crear manualmente instancias de tipo articulo.
        public void PrecargaArticulo()
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

        // Obtener articulo
        // Es un metodo que busca en la lista de articulos de la clase sistema un articulo con el id pasado por parámetros y si lo encuentra devuelve un articulo, en caso de que no lo encuentra devuelve null.
        public Articulo BuscarArticulo(string id)
        {
            Articulo articulo = null;
            int i = 0;

            while (i < _articulos.Count && articulo == null)
            {
                if (_articulos[i].Id.Trim().ToUpper() == id.Trim().ToUpper())
                {
                    articulo = _articulos[i];
                }

                i++;
            }

            return articulo;
        } 
        // Agrega un artículo a la lista de artículos de una publicación y devolver dicha lista en caso de haber encontrado una publicación. En caso de que no exista la publicación devuelve null. 


        // METODOS PUBLICACION
        // Alta publicacion *venta*
        // Es un metodo que crea una nueva instancia venta, verifica que no esté en la lista de publicaciones de la clase sistema y luego lo agrega a dicha lista.
        public void AltaPublicacionVenta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador,
            Usuario finalizador, bool relampago)
        {
            Venta venta = new Venta(nombre, estado, fechaPublicacion, comprador, finalizador, relampago);
            venta.Validar();
            if (!_publicaciones.Contains(venta))
            {
                _publicaciones.Add(venta);
            }
        }

        public Publicacion ObtenerPublicacion(string id)
        {
            int i = 0;
            Publicacion publicacion = null;

            while (i < _publicaciones.Count && !string.IsNullOrEmpty(id) && publicacion == null)
            {
                if (_publicaciones[i].Id.Trim().ToUpper() == id.Trim().ToUpper())
                {
                    publicacion = _publicaciones[i];
                }

                i++;
            }

            return publicacion;
        }

        public void PrecargaArticulosEnPublicacion(string idPublicacion, string idArticulo)
        {
            Articulo articulo = BuscarArticulo(idArticulo);
            Publicacion publicacion = ObtenerPublicacion(idPublicacion);

            if (publicacion != null && articulo != null)
            {
                publicacion.AgregarArticulo(articulo);
            }
        }


        // Precarga venta
        // Usa el metodo “AltaPublicacionVenta” para crear manualmente instancias de tipo venta.
        public void PrecargaVenta()
        {
            AltaPublicacionVenta("Mesa de comedor", "ABIERTA", new DateTime(2023, 6, 15), null, null, true);
            PrecargaArticulosEnPublicacion("PUB2", "ART11");
            
            AltaPublicacionVenta("Sofa cama", "ABIERTA", new DateTime(2023, 7, 1), null, null, false);
            PrecargaArticulosEnPublicacion("PUB3", "ART10");

            AltaPublicacionVenta("Cama matrimonial", "ABIERTA", new DateTime(2023, 8, 10), null, null, true);
            PrecargaArticulosEnPublicacion("PUB4", "ART9");

            AltaPublicacionVenta("Televisor", "ABIERTA", new DateTime(2023, 5, 25), null, null, false);
            PrecargaArticulosEnPublicacion("PUB5", "ART8");

            AltaPublicacionVenta("Estantería", "ABIERTA", new DateTime(2023, 9, 12), null, null, true);
            PrecargaArticulosEnPublicacion("PUB6", "ART7");

            AltaPublicacionVenta("Cocina completa", "ABIERTA", new DateTime(2023, 10, 5), null, null, false);
            PrecargaArticulosEnPublicacion("PUB7", "ART6");

            AltaPublicacionVenta("Frigorífico", "ABIERTA", new DateTime(2023, 6, 20), null, null, true);
            PrecargaArticulosEnPublicacion("PUB8", "ART5");

            AltaPublicacionVenta("Silla de oficina", "ABIERTA", new DateTime(2023, 11, 1), null, null, true);
            PrecargaArticulosEnPublicacion("PUB9", "ART4");

            AltaPublicacionVenta("Computadora portátil", "ABIERTA", new DateTime(2023, 7, 15), null, null, false);
            PrecargaArticulosEnPublicacion("PUB10", "ART3");

            AltaPublicacionVenta("Mesa de noche", "ABIERTA", new DateTime(2023, 8, 25), null, null, true);
            PrecargaArticulosEnPublicacion("PUB11", "ART2");
        }


        // Alta publicacion *subasta*
        // Es un metodo que crea una nueva instancia subasta, verifica que no esté en la lista de publicaciones de la clase sistema y luego lo agrega a dicha lista.
        public void AltaPublicacionSubasta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador,
            Usuario finalizador)
        {
            Subasta subasta = new Subasta(nombre, estado, fechaPublicacion, comprador, finalizador);
            subasta.Validar();
            if (!_publicaciones.Contains(subasta))
            {
                _publicaciones.Add(subasta);
            }
        }

        // Precarga subasta
        // Usa el metodo “ AltaPublicacionSubasta” para crear manualmente instancias de tipo subasta.
        public void PrecargaSubasta()
        {
            AltaPublicacionSubasta("Pintura original", "ABIERTA", new DateTime(2023, 9, 1), null, null);
            PrecargaArticulosEnPublicacion("PUB12", "ART7");
            PrecargaArticulosEnPublicacion("PUB12", "ART20");

            AltaPublicacionSubasta("Colección de monedas", "ABIERTA", new DateTime(2023, 8, 15), null, null);
            PrecargaArticulosEnPublicacion("PUB13", "ART4");

            AltaPublicacionSubasta("Reloj antiguo", "ABIERTA", new DateTime(2023, 10, 5), null, null);
            PrecargaArticulosEnPublicacion("PUB14", "ART3");

            AltaPublicacionSubasta("Bicicleta de montaña", "ABIERTA", new DateTime(2023, 11, 1), null, null);
            PrecargaArticulosEnPublicacion("PUB15", "ART5");

            AltaPublicacionSubasta("Joyería de plata", "ABIERTA", new DateTime(2023, 7, 20), null, null);
            PrecargaArticulosEnPublicacion("PUB16", "ART12");

            AltaPublicacionSubasta("Cámara fotográfica", "ABIERTA", new DateTime(2023, 12, 10), null, null);
            PrecargaArticulosEnPublicacion("PUB17", "ART11");

            AltaPublicacionSubasta("Juego de té", "ABIERTA", new DateTime(2023, 10, 20), null, null);
            PrecargaArticulosEnPublicacion("PUB18", "ART43");

            AltaPublicacionSubasta("Sofá vintage", "ABIERTA", new DateTime(2023, 9, 30), null, null);
            PrecargaArticulosEnPublicacion("PUB19", "ART29");

            AltaPublicacionSubasta("Escultura moderna", "ABIERTA", new DateTime(2023, 11, 15), null, null);
            PrecargaArticulosEnPublicacion("PUB21", "ART17");
        }

        public Subasta ObtenerSubasta(string id)
        {
            Subasta subasta = null;
            Publicacion publicacion = ObtenerPublicacion(id);

            if (publicacion is Subasta)
            {
                subasta = (Subasta)publicacion;
            }

            return subasta;
        }

        public List<Subasta> SubastasOrdenadas()
        {
            List<Subasta> subastaOrdenada = new List<Subasta>();
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion != null && publicacion is Subasta)
                {
                    subastaOrdenada.Add((Subasta)publicacion);
                }
            }

            subastaOrdenada.Sort();

            return subastaOrdenada;
        }

        // Precarga Oferta
        // Usa el metodo “AltaOferta” para crear manualmente instancias de tipo oferta.
        public void PrecargaOferta()
        {
            ObtenerSubasta("PUB13").AltaOferta(700, ObtenerCliente("USU4"), new DateTime(2023, 10, 5));
            ObtenerSubasta("PUB14").AltaOferta(450, ObtenerCliente("USU5"), new DateTime(2023, 11, 2));
        }

        public Venta ObtenerVenta(string IdVenta)
        {
            int i = 0;
            Venta venta = null;

            while (i < _publicaciones.Count && !string.IsNullOrEmpty(IdVenta) && venta == null)
            {
                if (_publicaciones[i].Id.Trim().ToUpper() == IdVenta.Trim().ToUpper() && _publicaciones[i] is Venta)
                {
                    venta = (Venta)_publicaciones[i];
                }

                i++;
            }

            return venta;
        }

    }
}