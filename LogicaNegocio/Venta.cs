using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{

 
    public class Venta:Publicacion, IValidate
    {
        // En una venta el usuario comprador y el que la finaliza es la misma persona.
        // Una subasta es adjudicada a una persona, pero solo un administrador la puede cerrar.
        private bool _relampago;

        // Es el método constructor de la clase venta que se usará para crear instancias del tipo venta.
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador, bool relampago):base(nombre, estado, fechaPublicacion, comprador, finalizador)
        {
            this._relampago = relampago;
        }

        // Método para obtener precio de la publicación
        public override double Precio()
        {
            double precioFinal = 0;
            for (int i = 0; i < Articulo.Count; i++)
            {
                precioFinal += Articulo[i].Precio;
            }

            if (_relampago == true)
            {
                double descuento = (precioFinal * 20) / 100;
                precioFinal -= descuento;
            }

            return precioFinal;
        }

        // Comprar una publicación de tipo venta
        public void CompraVenta(Cliente comprador)
        {
            try
            {
                if (_estado.Trim().ToUpper() == "ABIERTA")
                {
                    _comprador = comprador;
                    _comprador.Saldo -= Precio();
                    _estado = "CERRADA";
                    _fechaFinalizacion = DateTime.Now;
                    _comprador = comprador;
                    _finalizador = comprador;
                }
                else
                {
                    throw new Exception("La publicación no está activa");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
