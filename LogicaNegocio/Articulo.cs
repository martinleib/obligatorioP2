using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class Articulo
    {
        private string _id;
        private static int s_ultimoID = 1;
        private int _precio;

        private string _nombre;
        private string _categoria;

        public Articulo(int precio, string nombre, string categoria)
        {
            this._id = $"ART { s_ultimoID + 1}";
            this._precio = precio;
            this._nombre = nombre;
            this._categoria = categoria;
        }
    }
}
