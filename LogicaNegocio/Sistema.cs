using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LogicaNegocio
{
    public class Sistema
    {
        // Listas
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Oferta> _ofertas = new List<Oferta>();


        // METODOS USUARIO
        // Alta de Administrador
        // Es un metodo que crea una nueva instancia usuario. Verifica que no esté en la lista de usuarios de la clase sistema y luego lo agrega a dicha lista.

        public void AltaAdministrador(string nombre, string apellido, string email, string password)
        {
            Usuario administrador = new Usuario(nombre, apellido, email, password);
            if (!_usuarios.Contains(administrador))
            {
                _usuarios.Add(administrador);
            }
        }

        // Precarga administrador
        // Usa el metodo “AltaAdministrador” para crear manualmente instancias de tipo administrador.
        public void PrecargaAdministrador()
        {
            AltaAdministrador("Carlos", "Martinez", "CarlosM2001@gmail.com", "CarlosM123");
            AltaAdministrador("Sofía", "Gomez", "SofiaG2020@gmail.com", "SofiaG123");
        }



        // METODOS CLIENTE
        // Alta cliente
        // Es un metodo que crea una nueva instancia cliente. Verifica que no esté en la lista de usuarios de la clase sistema y luego lo agrega a dicha lista.
        public void AltaCliente(string nombre, string apellido, string email, string password, double saldo)
        {
            Cliente cliente = new Cliente(nombre, apellido, email, password, saldo);
            if (!_usuarios.Contains(cliente))
            {
                _usuarios.Add(cliente);
            }
        }

        // Precarga cliente
        // Usa el metodo “AltaCliente” para crear manualmente instancias de tipo cliente.
        public void PrecargaCliente()
        {
            AltaCliente("Sofía", "Gomez", "SofiaG2002@gmail.com", "SofiaG456", 1500);

            AltaCliente("Javier", "Lopez", "JavierL1995@gmail.com", "JavierL789", 3200);

            AltaCliente("Ana", "Fernandez", "AnaF1987@gmail.com", "AnaF101", 4000);

            AltaCliente("Pedro", "Ramirez", "PedroR1998@gmail.com", "PedroR202", 2700);

            AltaCliente("María", "Hernandez", "MariaH1993@gmail.com", "MariaH303", 1800);

            AltaCliente("Luis", "Morales", "LuisM2003@gmail.com", "LuisM404", 3600);

            AltaCliente("Elena", "Diaz", "ElenaD2001@gmail.com", "ElenaD505", 2200);

            AltaCliente("Fernando", "Cruz", "FernandoC1999@gmail.com", "FernandoC606", 3100);

            AltaCliente("Lucía", "Vasquez", "LuciaV1989@gmail.com", "LuciaV707", 2300);

            AltaCliente("Andrés", "Pérez", "AndresP2005@gmail.com", "AndresP808", 2900);
        }

        // Obtener cliente
        // Es un metodo que busca en la lista de clientes de la clase sistema un cliente con el id pasado por parámetros y si lo encuentra devuelve un usuario de tipo cliente, en caso de que no lo encuentra devuelve null.
        public Cliente ObtenerCliente(string id)
        {
            int i = 0;
            Cliente usuarioCliente = null;
            while (i < _usuarios.Count && usuarioCliente == null)
            {
                if (_usuarios[i] is Cliente && _usuarios[i].Id.Trim().ToUpper() == id.Trim().ToUpper())
                {
                    usuarioCliente = (Cliente)_usuarios[i];
                }
                i++;
            }
            return usuarioCliente;
        }


        // METODOS ARTICULO
        // Alta articulo
        // Es un metodo que crea una nueva instancia articulo, verifica que no esté en la lista de articulos de la clase sistema y luego lo agrega a dicha lista.
        public void AltaArticulo(int precio, string nombre, string categoria)
        {
            Articulo articulo = new Articulo(precio, nombre, categoria);
            if (!_articulos.Contains(articulo))
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
            int i = 0;
            Articulo articulo = null;
            while (i < _articulos.Count && articulo == null)
            {
                if (_articulos[i].Id == id.Trim().ToUpper())
                {
                    articulo = _articulos[i];
                }
                i++;
            }
            return articulo;
        }

        // Agrega un artículo a la lista de artículos de una publicación y devolver dicha lista en caso de haber encontrado una publicación. En caso de que no exista la publicación devuelve null. 
        public List<Articulo> AgregarArticulo(string idArticulo, string idPublicacion)
        {
            int i = 0;
            Articulo articulo = BuscarArticulo(idArticulo);
            Publicacion publicacion = null;

            while (i < _publicaciones.Count && publicacion == null && articulo != null)
            {
                if (_publicaciones[i].Id == idPublicacion.ToUpper() && _publicaciones[i].NoEstaEnLaListaElArticulo(articulo))
                {
                    _publicaciones[i].Articulo.Add(articulo);
                    publicacion = _publicaciones[i];
                }
                i++;
            }

            if (publicacion != null)
            {
                return publicacion.Articulo;
            }
            else
            {
                return null;
            }
        }

        // METODOS PUBLICACION
        // Alta publicacion *venta*
        // Es un metodo que crea una nueva instancia venta, verifica que no esté en la lista de publicaciones de la clase sistema y luego lo agrega a dicha lista.
        public void AltaPublicacionVenta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos, bool relampago)
        {
            Venta venta = new Venta(nombre, estado, fechaPublicacion, comprador, finalizador, articulos, relampago);
            if (!_publicaciones.Contains(venta))
            {
                _publicaciones.Add(venta);
            }
        }

        // Precarga venta
        // Usa el metodo “AltaPublicacionVenta” para crear manualmente instancias de tipo venta.
        public void PrecargaVenta()
        {
            AltaPublicacionVenta("Mesa de comedor", "ABIERTA", new DateTime(2023, 6, 15), null, null, AgregarArticulo("ART11", "PUB2"), true);

            AltaPublicacionVenta("Sofa cama", "ABIERTA", new DateTime(2023, 7, 1), null, null, AgregarArticulo("ART10", "PUB3"), false);

            AltaPublicacionVenta("Cama matrimonial", "ABIERTA", new DateTime(2023, 8, 10), null, null, AgregarArticulo("ART9", "PUB4"), true);

            AltaPublicacionVenta("Televisor", "ABIERTA", new DateTime(2023, 5, 25), null, null, AgregarArticulo("ART8", "PUB5"), false);

            AltaPublicacionVenta("Estantería", "ABIERTA", new DateTime(2023, 9, 12), null, null, AgregarArticulo("ART7", "PUB6"), true);

            AltaPublicacionVenta("Cocina completa", "ABIERTA", new DateTime(2023, 10, 5), null, null, AgregarArticulo("ART6", "PUB7"), false);

            AltaPublicacionVenta("Frigorífico", "ABIERTA", new DateTime(2023, 6, 20), null, null, AgregarArticulo("ART5", "PUB8"), true);

            AltaPublicacionVenta("Silla de oficina", "ABIERTA", new DateTime(2023, 11, 1), null, null, AgregarArticulo("ART4", "PUB9"), true);

            AltaPublicacionVenta("Computadora portátil", "ABIERTA", new DateTime(2023, 7, 15), null, null, AgregarArticulo("ART3", "PUB10"), false);

            AltaPublicacionVenta("Mesa de noche", "ABIERTA", new DateTime(2023, 8, 25), null, null, AgregarArticulo("ART2", "PUB11"), true);
        }

        // METODOS OFERTA
        // Alta Oferta
        // Es un metodo que crea una nueva instancia oferta, verifica que no esté en la lista de ofertas de la clase sistema y luego lo agrega a dicha lista.
        public void AltaOferta(int monto, Usuario usuario, DateTime fecha)
        {
            Oferta oferta = new Oferta(monto, usuario, fecha);
            if (!_ofertas.Contains(oferta))
            {
                _ofertas.Add(oferta);
            }
        }

        // Precarga Oferta
        // Usa el metodo “ AltaOferta” para crear manualmente instancias de tipo oferta.
        public void PrecargaOferta()
        {
            AltaOferta(510, ObtenerCliente("USU4"), new DateTime(2023, 10, 4));
            AltaOferta(450, ObtenerCliente("USU5"), new DateTime(2023, 11, 2));
        }

        // Obtener oferta
        // Es un metodo que busca en la lista de ofertas de la clase sistema una oferta con el id pasado por parámetros y si lo encuentra devuelve una oferta, en caso de que no lo encuentre devuelve null.
        public Oferta BuscarOferta(string id)
        {
            int i = 0;
            Oferta oferta = null;
            while (i < _ofertas.Count && oferta == null)
            {
                if (_ofertas[i].Id == id.Trim().ToUpper())
                {
                    oferta = _ofertas[i];
                }
                i++;
            }
            return oferta;
        }

        // Agrega una oferta a la lista de ofertas en una publicación de tipo subasta y devuelve dicha lista. En caso de no encontrar la publicación deseada devuelve null.
        public List<Oferta> AgregarOferta(string idOferta, string idPublicacion)
        {
            int i = 0;
            Oferta oferta = BuscarOferta(idOferta);
            Subasta subasta = null;

            while (i < _publicaciones.Count && subasta == null && oferta != null)
            {
                if (_publicaciones[i] is Subasta &&
                    _publicaciones[i].Id.Trim().ToUpper() == idPublicacion.Trim().ToUpper() &&
                    ((Subasta)_publicaciones[i]).EstaEnOferta(oferta) == false)
                {
                    subasta = (Subasta)_publicaciones[i];
                    subasta.Ofertas.Add(oferta);
                }
                i++;
            }

            if (subasta != null)
            {
                return subasta.Ofertas;
            }
            else
            {
                return null;
            }
        }

        // Alta publicacion *subasta*
        // Es un metodo que crea una nueva instancia subasta, verifica que no esté en la lista de publicaciones de la clase sistema y luego lo agrega a dicha lista.
        public void AltaPublicacionSubasta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos, List<Oferta> ofertas)
        {
            Subasta subasta = new Subasta(nombre, estado, fechaPublicacion, comprador, finalizador, articulos, ofertas);
            if (!_publicaciones.Contains(subasta))
            {
                _publicaciones.Add(subasta);
            }
        }

        // Precarga subasta
        // Usa el metodo “ AltaPublicacionSubasta” para crear manualmente instancias de tipo subasta.
        public void PrecargaSubasta()
        {
            AltaPublicacionSubasta("Pintura original", "ABIERTA", new DateTime(2023, 9, 1), null, null, AgregarArticulo("ART7", "PUB12"), AgregarOferta("OF2", "PUB12"));

            AltaPublicacionSubasta("Colección de monedas", "ABIERTA", new DateTime(2023, 8, 15), null, null, AgregarArticulo("ART4", "PUB13"), AgregarOferta("OF3", "PUB13"));

            AltaPublicacionSubasta("Reloj antiguo", "ABIERTA", new DateTime(2023, 10, 5), null, null, AgregarArticulo("ART3", "PUB14"), null);

            AltaPublicacionSubasta("Bicicleta de montaña", "ABIERTA", new DateTime(2023, 11, 1), null, null, AgregarArticulo("ART5", "PUB15"), null);

            AltaPublicacionSubasta("Joyería de plata", "ABIERTA", new DateTime(2023, 7, 20), null, null, AgregarArticulo("ART12", "PUB16"), null);

            AltaPublicacionSubasta("Cámara fotográfica", "ABIERTA", new DateTime(2023, 12, 10), null, null, AgregarArticulo("ART11", "PUB17"), null);

            AltaPublicacionSubasta("Juego de té", "ABIERTA", new DateTime(2023, 10, 20), null, null, AgregarArticulo("ART43", "PUB18"), null);

            AltaPublicacionSubasta("Sofá vintage", "ABIERTA", new DateTime(2023, 9, 30), null, null, AgregarArticulo("ART29", "PUB19"), null);

            AltaPublicacionSubasta("Guitarra eléctrica", "ABIERTA", new DateTime(2023, 8, 1), null, null, AgregarArticulo("ART18", "PUB20"), null);

            AltaPublicacionSubasta("Escultura moderna", "ABIERTA", new DateTime(2023, 11, 15), null, null, AgregarArticulo("ART17", "PUB21"), null);
        }

        // Retorna el listado de clientes como un string (metodo usado por Program)
        public List<Usuario> ListadoDeClientes()
        {
            List<Usuario> retornoClientes = new List<Usuario>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente)
                {
                    retornoClientes.Add(usuario);
                }
            }

            if (retornoClientes.Count == 0)
            {
                return null;
            }
            else
            {
                return retornoClientes;
            }
        }

        // Retorna el listado de publicaciones hechas entre dos fechas como un string (metodo usado por Program)
        public List<Publicacion> ListadoDePublicaciones(DateTime fechaUno, DateTime fechaDos)
        {

            List<Publicacion> retornoPublicaciones = new List<Publicacion>();

            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.FechaPublicacion >= fechaUno && publicacion.FechaPublicacion <= fechaDos)
                {
                    retornoPublicaciones.Add(publicacion);
                }
            }

            if (retornoPublicaciones.Count == 0)
            {
                return null;
            }
            else
            {
                return retornoPublicaciones;
            }
        }

        // Retorna el listado de articulos con una categoria especifica como un string (metodo usado por Program)
        public List<Articulo> ListadoDeArticulos(string categoria)
        {

            List<Articulo> retornoArticulos = new List<Articulo>();

            foreach (Articulo articulo in _articulos)
            {
                if (articulo.Categoria.Trim().ToLower() == categoria.Trim().ToLower())
                {
                    retornoArticulos.Add(articulo);
                }
            }

            if (retornoArticulos.Count == 0)
            {
                return null;
            }
            else
            {
                return retornoArticulos;
            }
        }
    }
}
