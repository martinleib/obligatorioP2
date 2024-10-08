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
        private List<Oferta>_ofertas = new List<Oferta>();

        // Propiedad que devuelve la lista de ofertas de una instancia del tipo subasta.
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }

        // Es el método constructor de la clase subasta que se usará para crear instancias del tipo subasta.
        public Subasta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos, List<Oferta> ofertas) : base(nombre, estado, fechaPublicacion, comprador, finalizador, articulos)
        {
            this._ofertas = ofertas;
        }

        // Verifica si una oferta está en la lista de ofertas, devuelve true en caso de que este o false en caso de que no.
        public bool EstaEnOferta(Oferta oferta)
        {
            bool esta = false;
            if (_ofertas.Contains(oferta))
            {
                esta = true;
            }
            return esta;
        }
    }
}
