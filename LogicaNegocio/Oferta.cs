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

        private Cliente _cliente;
        private DateTime _fecha;

        // Es el método constructor de la clase oferta que se usará para crear instancias del tipo oferta.
        public Oferta(double monto, Cliente cliente, DateTime fecha)
        {
            // El ID se veria: OF02, OF03, etc...
            this._id = $"OF{s_ultimoID + 1}";
            s_ultimoID++;
            this._monto = monto;
            this._cliente = cliente;
            this._fecha = fecha;
        }

        public double Monto
        {
            get { return _monto; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
        }
    }
}
