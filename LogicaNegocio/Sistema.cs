namespace LogicaNegocio
{
    public class Sistema
    {
        /// Cliente hereda de Usuario
        private List<Usuario>_usuarios = new List<Usuario>();
        
        // Subastas y ofertas heredan de Publiaciones
        private List<Publicacion>_publicaciones = new List<Publicacion>();

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
