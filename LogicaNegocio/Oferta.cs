using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Oferta
    {
        private string _id;
        private static int s_ultimoID = 1;
        private int _monto;

        private Usuario _usuario;
        private DateTime _fecha;

        // Es el método constructor de la clase oferta que se usará para crear instancias del tipo oferta.
        public Oferta(int monto, Usuario usuario, DateTime fecha)
        {
            // El ID se veria: OF02, OF03, etc...
            this._id = $"OF{s_ultimoID + 1}";
            s_ultimoID++;
            this._monto = monto;
            this._usuario = usuario;
            this._fecha = fecha;
        }

        // Propiedad que devuelve el id de una instancia de tipo oferta.
        public string Id
        {
            get { return _id; }
        }
    }
}
