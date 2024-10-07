using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente:Usuario
    {
        // Cliente hereda de usuario

        // Saldo disponible
        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
        }

        public Cliente(string nombre, string apellido, string email, string password, double saldo) : base(nombre, apellido, email, password)
        {
            this._saldo = saldo;
        }

        public override string ToString()
        {
            return $"Nombre completo: {Nombre} {Apellido}, informacion de contacto: {Email}, ID: {Id}, Saldo: {_saldo}";
        }
    }
}
