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
        private int _monto;

        private Usuario _usuario;
        private DateTime _fecha;

        public Oferta(int monto, Usuario usuario, DateTime fecha)
        {
            // El ID se veria: OF01, OF02, etc...
            this._id = $"OF{s_ultimoID + 1}";
            this._monto = monto;
            this._usuario = usuario;
            this._fecha = fecha;
        }
    }
}
