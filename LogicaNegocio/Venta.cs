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

        private bool _relampago;

        public Venta(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador,List<Articulo> articulos, bool relampago):base(nombre, estado, fechaPublicacion, fechaFinalizacion, comprador, finalizador, articulos)
        {
            this._relampago = relampago;
            this._id = $"VEN{s_ultimoID + 1}";
        }
    }
}
