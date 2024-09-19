namespace LogicaNegocio
{
    public class Sistema
    {
        /// Cliente hereda de Usuario
        private List<Usuario>_usuarios = new List<Usuario>();
        
        // Subastas y ofertas heredan de Publiaciones
        private List<Publicacion>_publicaciones = new List<Publicacion>();

        private List<Articulo> _articulos = new List<Articulo>();

        public void AltaUsuarioAdministrador(string nombre, string apellido, string email, string password)
        {
            Administrador administrador = new Administrador(nombre,apellido,email,password);
            if(!_usuarios.Contains(administrador))
            {
                _usuarios.Add(administrador);
            }
        }

        /*public Usuario BuscarUsuarioAdministrador(string password)
        {
            int i = 0;
            Usuario usuarioAdmin = null;
            while (i < _usuarios.Count && usuarioAdmin == null)
            {
                if (_usuarios[i].Contraseña == password && _usuarios[i] is Administrador)
                {
                    usuarioAdmin = _usuarios[i];
                }
                i++;
            }
            return usuarioAdmin;
        }*/

        /*public Usuario BuscarUsuarioCliente(string password)
        {
            int i = 0;
            Usuario usuarioCliente = null;
            while (i < _usuarios.Count && usuarioCliente == null)
            {
                if (_usuarios[i].Contraseña == password && _usuarios[i] is Cliente)
                {
                    usuarioCliente = _usuarios[i];
                }
                i++;
            }
            return usuarioCliente;
        }*/

        
        public void AltaUsuarioCliente(string nombre, string apellido, string email, string password, double saldo)
        {
            Cliente cliente = new Cliente(nombre, apellido, email, password, saldo);
            if (!_usuarios.Contains(cliente))
            {
                _usuarios.Add(cliente);
            }
        }

        public Usuario BuscarUsuario(string password)
        {
            int i = 0;
            Usuario usuario = null;
            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i].Contraseña == password)
                {
                    usuario = _usuarios[i];
                }
                i++;
            }
            return usuario;
        }
        public void AltaPublicacionVenta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador, bool relampago)
        {
            Venta venta = new Venta(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, relampago);
            if (!_publicaciones.Contains(venta))
            {
                _publicaciones.Add(venta);
            }
        }

        public void AltaPublicacionSubasta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador, List<Oferta> ofertas)
        {
            Subasta subasta = new Subasta(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, ofertas);
            if (!_publicaciones.Contains(subasta))
            {
                _publicaciones.Add(subasta);
            }
        }

        public void AgregarArticulo(int precio, string nombre, string categoria)
        {
            Articulo articulo = new Articulo(precio, nombre, categoria);
            if (!_articulos.Contains(articulo))
            {
                _articulos.Add(articulo);
            }
        }

        public void AgregarLaOfertaALaPrecarga(string password)
        {
            Usuario usuarioBuscado = BuscarUsuario(password);
            if(usuarioBuscado != null)
            {

            }
        }

        private void PrecargarAdministrador()
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

        private void PrecargarPublicacionVenta()
        {
            AltaPublicacionVenta("Mesa de comedor", "ABIERTA", new DateTime(2023, 6, 15), new DateTime(2024, 11, 20), null, null, true);

            AltaPublicacionVenta("Sofa cama", "ABIERTA", new DateTime(2023, 7, 1), new DateTime(2024, 9, 15), null, null, false);

            AltaPublicacionVenta("Cama matrimonial", "ABIERTA", new DateTime(2023, 8, 10), new DateTime(2024, 12, 5), null, null, true);

            AltaPublicacionVenta("Televisor", "ABIERTA", new DateTime(2023, 5, 25), new DateTime(2024, 10, 1), null, null, false);

            AltaPublicacionVenta("Estantería", "ABIERTA", new DateTime(2023, 9, 12), new DateTime(2024, 11, 30), null, null, true);

            AltaPublicacionVenta("Cocina completa", "ABIERTA", new DateTime(2023, 10, 5), new DateTime(2024, 8, 18), null, null, false);

            AltaPublicacionVenta("Frigorífico", "ABIERTA", new DateTime(2023, 6, 20), new DateTime(2024, 9, 25), null, null, true);

            AltaPublicacionVenta("Silla de oficina", "ABIERTA", new DateTime(2023, 11, 1), new DateTime(2024, 12, 12), null, null, true);

            AltaPublicacionVenta("Computadora portátil", "ABIERTA", new DateTime(2023, 7, 15), new DateTime(2024, 10, 30), null, null, false);

            AltaPublicacionVenta("Mesa de noche", "ABIERTA", new DateTime(2023, 8, 25), new DateTime(2024, 11, 15), null, null, true);
        }

        private void PrecargaPublicacionSubasta()
        {
            AltaPublicacionSubasta("Pintura original", "ABIERTA", new DateTime(2023, 9, 1), new DateTime(2024, 12, 10), null, null,);

            AltaPublicacionSubasta("Colección de monedas", "ABIERTA", new DateTime(2023, 8, 15), new DateTime(2024, 11, 20), null, null,);

            AltaPublicacionSubasta("Reloj antiguo", "ABIERTA", new DateTime(2023, 10, 5), new DateTime(2024, 9, 30), null, null,);

            AltaPublicacionSubasta("Bicicleta de montaña", "ABIERTA", new DateTime(2023, 11, 1), new DateTime(2024, 10, 15), null, null,);

            AltaPublicacionSubasta("Joyería de plata", "ABIERTA", new DateTime(2023, 7, 20), new DateTime(2024, 8, 25), null, null,);

            AltaPublicacionSubasta("Cámara fotográfica", "ABIERTA", new DateTime(2023, 12, 10), new DateTime(2024, 11, 5), null, null,);

            AltaPublicacionSubasta("Juego de té", "ABIERTA", new DateTime(2023, 10, 20), new DateTime(2024, 9, 5), null, null,);

            AltaPublicacionSubasta("Sofá vintage", "ABIERTA", new DateTime(2023, 9, 30), new DateTime(2024, 12, 1), null, null,);

            AltaPublicacionSubasta("Guitarra eléctrica", "ABIERTA", new DateTime(2023, 8, 1), new DateTime(2024, 10, 25), null, null,);

            AltaPublicacionSubasta("Escultura moderna", "ABIERTA", new DateTime(2023, 11, 15), new DateTime(2024, 10, 5), null, null,);
        }

        private void PrecargaArticulo()
        {
            AgregarArticulo(100, "Silla de oficina", "Muebles");

            AgregarArticulo(250, "Mesa de café", "Muebles");

            AgregarArticulo(50, "Lámpara de mesa", "Iluminación");

            AgregarArticulo(75, "Escritorio", "Muebles");

            AgregarArticulo(200, "Cama individual", "Muebles");

            AgregarArticulo(150, "Estantería", "Muebles");

            AgregarArticulo(300, "Televisor", "Electrónica");

            AgregarArticulo(400, "Sofá", "Muebles");

            AgregarArticulo(60, "Reloj de pared", "Decoración");

            AgregarArticulo(80, "Cuadro decorativo", "Decoración");

            AgregarArticulo(20, "Maceta", "Jardinería");

            AgregarArticulo(45, "Planta artificial", "Jardinería");

            AgregarArticulo(30, "Candelabro", "Iluminación");

            AgregarArticulo(90, "Almohada", "Textiles");

            AgregarArticulo(150, "Manta", "Textiles");

            AgregarArticulo(500, "Cocina a gas", "Electrodomésticos");

            AgregarArticulo(350, "Refrigerador", "Electrodomésticos");

            AgregarArticulo(80, "Tostadora", "Electrodomésticos");

            AgregarArticulo(120, "Batidora", "Electrodomésticos");

            AgregarArticulo(100, "Horno eléctrico", "Electrodomésticos");

            AgregarArticulo(25, "Cuchillo de cocina", "Utensilios");

            AgregarArticulo(35, "Tabla de cortar", "Utensilios");

            AgregarArticulo(15, "Vaso", "Utensilios");

            AgregarArticulo(40, "Plato hondo", "Utensilios");

            AgregarArticulo(60, "Juego de cubiertos", "Utensilios");

            AgregarArticulo(110, "Cafetera", "Electrodomésticos");

            AgregarArticulo(130, "Microondas", "Electrodomésticos");

            AgregarArticulo(300, "Console de videojuegos", "Electrónica");

            AgregarArticulo(600, "Laptop", "Electrónica");

            AgregarArticulo(20, "Auriculares", "Electrónica");

            AgregarArticulo(75, "Cámara instantánea", "Electrónica");

            AgregarArticulo(250, "Proyector", "Electrónica");

            AgregarArticulo(150, "Bicicleta", "Deportes");

            AgregarArticulo(200, "Patinete", "Deportes");

            AgregarArticulo(50, "Pelota de fútbol", "Deportes");

            AgregarArticulo(80, "Raqueta de tenis", "Deportes");

            AgregarArticulo(90, "Zapatillas deportivas", "Ropa");

            AgregarArticulo(120, "Chaqueta", "Ropa");

            AgregarArticulo(100, "Pantalones", "Ropa");

            AgregarArticulo(200, "Camisa", "Ropa");

            AgregarArticulo(250, "Vestido", "Ropa");

            AgregarArticulo(180, "Bolso de mano", "Accesorios");

            AgregarArticulo(300, "Mochila", "Accesorios");

            AgregarArticulo(90, "Gafas de sol", "Accesorios");

            AgregarArticulo(75, "Cinturón", "Accesorios");

            AgregarArticulo(100, "Sombrero", "Accesorios");

            AgregarArticulo(200, "Joyería", "Accesorios");

            AgregarArticulo(250, "Espejo decorativo", "Decoración");

            AgregarArticulo(130, "Cortinas", "Textiles");

            AgregarArticulo(160, "Mueble de TV", "Muebles");
        }

        // Esto tiene que ir en Program.cs
        // Lo anoto aca para no olvidarme porque ya se que sino me voy a olvidar
        public void CrearVenta()
        {
            string nombre;
            string estado;
            string relampagoString;
            bool relampago;

            Console.WriteLine("Ingrese nombre de la publicacion");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese estado de la publicacion");
            estado = Console.ReadLine();
            Console.WriteLine("Es una venta relampago, ingrese 'si' o 'no'");
            relampagoString = Console.ReadLine();

            if (relampagoString.ToLower() == "si")
            {
                relampago = true;
            } else
            {
                relampago = false;
            }

            DateTime fechaFinalizacion = DateTime.MinValue;
            Cliente comprador = null;
            Cliente finalizador = null;

            Venta venta = new Venta(
                nombre,
                estado,
                fechaFinalizacion,
                comprador,
                finalizador,
                relampago);
        }
    }
}
