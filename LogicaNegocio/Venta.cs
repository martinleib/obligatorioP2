using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta:Publicacion
    {
        private string _id;
        private static int s_ultimoID = 1;

        // En una venta el usuario comprador y el que la finaliza es la misma persona.
        // Una subasta es adjudicada a una persona, pero solo un administrador la puede cerrar.
        private Cliente _finalizador;
        private bool _relampago;

        public Venta(string nombre, string estado, DateTime fechaFinalizacion, Cliente comprador, Cliente finalizador, bool relampago):base(nombre, estado, fechaFinalizacion, comprador, finalizador)
        {
            this._relampago = relampago;
            this._finalizador = finalizador;
            this._id = $"VEN{s_ultimoID + 1}";
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
