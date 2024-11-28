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

        // Devuelve el máximo que se haya ofertado hasta el momento en una Subasta
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
        
        // Devuelve el precio de la subasta
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

        // Crea una oferta y la agrega a la lista de ofertas de la subasta
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
                    result = true;
                }
            }
            return result;
        }

        // Checkea que una oferta no exista
        public bool ExisteOferta(Oferta oferta)
        {
            bool result = false;
            int i = 0;
            while (i< _ofertas.Count && result == false)
            {
                if (_ofertas[i] == oferta)
                {
                    result = true;
                }
                i++;
            }
            return result;
        }
        
        // Agrega una oferta a la lista de ofertas de la subasta
        public void AltaOferta(int monto, Cliente cliente, DateTime fecha)
        {
            Oferta oferta = new Oferta(monto, cliente, fecha);
            if (ExisteOferta(oferta) == false)
            {
                _ofertas.Add(oferta);
            }
        }

        // Cerrar subasta
        public bool CerrarSubasta(Usuario admin)
        {
            bool result = false;
            try
            {
                int i = _ofertas.Count - 1;

                while (i >= 0 && result == false)
                {
                    if (_ofertas[i].Cliente.Saldo >= _ofertas[i].Monto)
                    {
                        this._estado = "CERRADA";
                        this._fechaFinalizacion = DateTime.Now;
                        this._comprador = _ofertas[i].Cliente;
                        this._comprador.Saldo -= _ofertas[i].Monto;
                        this._finalizador = admin;
                        result = true;
                    }
                    i--;
                }

                if (!result)
                {
                    throw new Exception("No se encontró un comprador con saldo suficiente para cerrar la subasta");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public int CompareTo(Subasta other)
        {
            return _fechaPublicacion.CompareTo(other._fechaPublicacion);
        }
    }
}