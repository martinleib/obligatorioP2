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

        public Articulo(int precio, string nombre, string categoria)
        {
            this._id = $"ART { s_ultimoID + 1}";
            s_ultimoID++;
            this._precio = precio;
            this._nombre = nombre;
            this._categoria = categoria;
        }

        public string Id
        {
            get { return _id; }
        }

        public string Categoria
        {
            get { return _categoria; }
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}. Precio: {_precio}. Categoria: {_categoria}. ID: {_id}";
        }
    }
}
