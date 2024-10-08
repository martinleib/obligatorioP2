using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta:Publicacion
    {
        // En una venta el usuario comprador y el que la finaliza es la misma persona.
        // Una subasta es adjudicada a una persona, pero solo un administrador la puede cerrar.
        private bool _relampago;

        // Es el método constructor de la clase venta que se usará para crear instancias del tipo venta.
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador,List<Articulo> articulos, bool relampago):base(nombre, estado, fechaPublicacion, comprador, finalizador, articulos)

        {
            this._relampago = relampago;
        }
    }
}
