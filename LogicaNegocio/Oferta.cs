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
        private double _monto;

        private Usuario _usuario;
        private DateTime _fecha;

        // Es el método constructor de la clase oferta que se usará para crear instancias del tipo oferta.
        public Oferta(double monto, Usuario usuario, DateTime fecha)
        {
            // El ID se veria: OF02, OF03, etc...
            this._id = $"OF{s_ultimoID + 1}";
            s_ultimoID++;
            this._monto = monto;
            this._usuario = usuario;
            this._fecha = fecha;
        }

        public double Monto
        {
            get { return _monto; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
        }
    }
}
