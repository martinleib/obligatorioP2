using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Publicacion
    {
        private string _id;
        private static int s_ultimoID = 1;

        private string _nombre;

        // Estado puede ser: ABIERTA, CANCELADA, CERRADA
        private string _estado;

        // Fecha de publicacion y finalizacion de la publicacion
        private DateTime _fechaPublicacion;
        private DateTime _fechaFinalizacion;

        // Lista de articulos dentro de la publicacion
        private List<Articulo> _articulos = new List<Articulo>();

        // Cliente que realizo la compra
        private Cliente _comprador = null;

        // En el caso de una subasta el finalizador es un usuario de tipo Administrador
        // mientras que en el caso de una compra el finalizador es un usuario de tipo Cliente
        private Usuario _finalizador = null;

        // Es el método constructor de la clase publicacion que se usará para crear instancias del tipo publicacion.
        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos)
        {
            this._id = $"PUB{s_ultimoID + 1}";
            s_ultimoID++;
            this._nombre = nombre;
            this._estado = estado;
            this._fechaPublicacion = fechaPublicacion;
            this._comprador = comprador;
            this._finalizador = finalizador;
            this._articulos = articulos;
        }

        // Propiedad que devuelve la lista de articulos de una instancia de tipo publicacion.
        public List<Articulo> Articulo
        {
            get
            {
                return _articulos;
            }
        }

        // Propiedad que devuelve el ID de una instancia de tipo publicacion.
        public string Id
        {
            get { return _id; }
        }

        public override bool Equals(object obj)
    {
        if (obj is Publicacion otraPublicacion)
        {
            // Compara los IDs ignorando mayúsculas y espacios
            return string.Equals(this.Id.Trim().ToUpper(), otraPublicacion.Id.Trim().ToUpper());
        }
        return false;
    }

        // Propiedad que devuelve la fecha de publicacion de una instancia de tipo publicacion.
        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
        }

        // Precondición: el articulo pasado por parámetro no puede ser null.
        // Es un metodo que devuelve false en caso de que el articulo pasado como parametro esté en la lista de articulos, en caso de que no esté devuelve true.
        public bool NoEstaEnLaListaElArticulo(Articulo articulo)
        {
            bool noEstaEnLaLista = false;
            if (!_articulos.Contains(articulo))
            {
              noEstaEnLaLista = true;
            }
            return noEstaEnLaLista;
        }

        // Metodo que modifica el comportamiento del método ToString de la clase publicación, permitiendo imprimir los atributos nombre, estado, fecha de publicación e ID.
        public override string ToString()
        {
            return $"Nombre: {_nombre}. Estado: {_estado}. Fecha de publicacion: {_fechaPublicacion}. ID: {_id}";
        }
    }
}
