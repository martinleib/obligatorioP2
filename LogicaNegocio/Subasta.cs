using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    // Subasta hereda de Publicacion
    public class Subasta:Publicacion
    {
        private List<Oferta>_ofertas;

        // Propiedad que devuelve la lista de ofertas de una instancia del tipo subasta.
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }

        // Es el método constructor de la clase subasta que se usará para crear instancias del tipo subasta.
        public Subasta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos) : base(nombre, estado, fechaPublicacion, comprador, finalizador, articulos)
        {
            this._ofertas = new List<Oferta>();
        }

        public void AltaOferta(int monto, Usuario usuario, DateTime fecha)
        {
            Oferta oferta = new Oferta(monto, usuario, fecha);
            if (!_ofertas.Contains(oferta))
            {
                _ofertas.Add(oferta);
            }
        }

        public Oferta ObtenerOferta(string id)
        {
            Oferta ofertaEncontrada = null;

            foreach (Oferta oferta in _ofertas)
            {
                if (oferta.Id == id)
                {
                    ofertaEncontrada = oferta;
                }
            }

            return ofertaEncontrada;
        }
    }
}
