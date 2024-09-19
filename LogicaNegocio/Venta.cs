using LogicaNegocio.Interfaces;
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
        private Cliente _finalizador;
        private bool _relampago;

        public Venta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador,List<Articulo> articulos, bool relampago):base(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, articulos)

        {
            this._relampago = relampago;
        }

        public bool Relampago
        {
            set
            {
                this._relampago = value;
            }
        }

        public Cliente Finalizador
        {
            set
            {
                this._finalizador = value;
            }
        }
    }
}
