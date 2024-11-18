using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    // Subasta hereda de Publicacion
    public class Subasta : Publicacion,IComparable<Subasta>
    {
        private List<Oferta> _ofertas;

        // Propiedad que devuelve la lista de ofertas de una instancia del tipo subasta.
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }

        // Es el método constructor de la clase subasta que se usará para crear instancias del tipo subasta.
        public Subasta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador) : base(nombre, estado, fechaPublicacion, comprador, finalizador)
        {
            this._ofertas = new List<Oferta>();
        }

        public double MaximoMonto()
        {
            double maxMonto = 0;
            for (int i = 0; i < _ofertas.Count; i++)
            {
                if (_ofertas[i].Monto > maxMonto)
                {
                    maxMonto = _ofertas[i].Monto;
                }
            }
            return maxMonto;
        }

        public override double Precio()
        {
            double precio = 0;
            for (int i = 0; i < _ofertas.Count; i++)
            {
                if (_ofertas[i].Monto > precio)
                {
                    precio = _ofertas[i].Monto;
                }
            }
            return precio;
        }

        public bool Ofertar(Cliente cliente, double monto)
        {
            bool result = false;
            if (monto > 0 && cliente != null) {

                string estado = _estado.Trim().ToUpper();
                double maxMonto = MaximoMonto();

                if (estado == "ABIERTA" && monto > maxMonto && cliente.Saldo>= monto)
                { 
                    Oferta oferta = new Oferta(monto,cliente,DateTime.Now);
                    _ofertas.Add(oferta);
                    cliente.Saldo -= monto;
                    result = true;
                }
            }
            return result;
        }

        public void AltaOferta(int monto, Usuario usuario, DateTime fecha)
        {
            Oferta oferta = new Oferta(monto, usuario, fecha);
            if (!_ofertas.Contains(oferta))
            {
                _ofertas.Add(oferta);
            }
        }

        public int CompareTo(Subasta other)
        {
            return _fechaPublicacion.CompareTo(other._fechaPublicacion);
        }
    }
}