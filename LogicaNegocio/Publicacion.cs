using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal abstract class Publicacion
    {
        private string _nombre;

        // Estado puede ser: ABIERTA, CANCELADA, CERRADA
        private string _estado;
        
        // Fecha de publicacion y finalizacion de la publicacion
        private DateTime _fechaPublicacion;
        private DateTime _fechaFinalizacion;

        // Lista de articulos dentro de la publicacion
        private List<Articulo> _articulos = new List<Articulo>();
        
        // Cliente que realizo la compra
        private Cliente _comprador;

        // Usuario que finaliza la compra, calculo que un administrador tiene que confirmar la compra manualmente
        // y cuando en la letra se menciona "usuario que finaliza la compra" se refiere a este usuario que se
        // guarda dentro de cada publicacion
        private Usuario _finalizador;

        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente comprador, Usuario finalizador)
        {
            this._nombre = nombre;
            this._estado = estado;
            this._fechaPublicacion = fechaPublicacion;
            this._fechaFinalizacion = fechaFinalizacion;
            this._comprador = comprador;
            this._finalizador = finalizador;
        }
    }
}
