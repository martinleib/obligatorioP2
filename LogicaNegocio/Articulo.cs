using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Articulo
    {
        private string _id;
        private static int s_ultimoID = 1;
        private int _precio;

        private string _nombre;
        private string _categoria;

        // Es el método constructor de la clase articulo que se usará para crear instancias del tipo articulo.
        public Articulo(int precio, string nombre, string categoria)
        {
            this._id = $"ART { s_ultimoID + 1}";
            s_ultimoID++;
            this._precio = precio;
            this._nombre = nombre;
            this._categoria = categoria;
        }
        
        // Propiedad que devuelve el ID de una instancia articulo.
        public string Id
        {
            get { return _id; }
        }

        public override bool Equals(object obj)
    {
        if (obj is Articulo otroArticulo)
        {
            return string.Equals(this.Id.Trim().ToUpper(), otroArticulo.Id.Trim().ToUpper());
        }
        return false;
    }

        // Propiedad que devuelve la categoría de una instancia articulo.
        public string Categoria
        {
            get { return _categoria; }
        }

        // Metodo que modifica el comportamiento del método ToString de la clase artículo, permitiendo imprimir los atributos nombre, precio, categoría e ID.
        public override string ToString()
        {
            return $"Nombre: {_nombre}. Precio: {_precio}. Categoria: {_categoria}. ID: {_id}";
        }
    }
}
