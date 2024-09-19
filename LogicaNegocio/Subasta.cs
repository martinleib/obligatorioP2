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
        private string _id;
        private static int s_ultimoID = 1;
        private List<Oferta>_ofertas = new List<Oferta>();

        public Subasta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador, List<Articulo> articulos, List<Oferta> ofertas) : base(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, articulos)
        {
            this._id = $"SUB{s_ultimoID + 1}";
            this._ofertas = ofertas;
        }

        public List<Oferta> AgregarOferta(Oferta oferta)
        {

            if (!_ofertas.Contains(oferta) && oferta != null)
            {
                _ofertas.Add(oferta);
            }
            return _ofertas;

        }
    }
}
