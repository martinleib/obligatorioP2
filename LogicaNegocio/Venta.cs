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
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador,List<Articulo> articulos, bool relampago):base(nombre, estado, fechaPublicacion, comprador, finalizador, articulos)
        {
            this._relampago = relampago;
        }

        public override double Precio()
        {
            double precioFinal = 0;
            double descuento = (precioFinal * 20) / 100;
            for (int i = 0; i < Articulo.Count; i++)
            {
                precioFinal += Articulo[i].Precio;

                if (_relampago == true)
                {
                    precioFinal -= descuento;
                }
            }
            return precioFinal;
            
        }

        public string Compra(Cliente cliente)
        {
            string mensaje = "";
            string estadoMay = _estado.Trim().ToUpper();
            double precio = Precio();
            if (estadoMay == "ABIERTO" && _comprador.Saldo > precio)
            {
                _comprador = cliente;
                _estado = "CERRADO";
                _finalizador = cliente;
                _fechaFinalizacion = DateTime.Now;
                _comprador.Saldo -= precio;
                mensaje = "Se realizo la compra con exito";
            }
            else
            {
                mensaje = "No se pudo realizar la compra";
            }
            return mensaje;
        }

        /*
        public void Validar()
        {
            base.Validar();

            if (_relampago == null)
            {
                throw new Exception("Oferta relampágo no puede estar vacío, debe ser si-no");
            }

        }*/
    }
}
