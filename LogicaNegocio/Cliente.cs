using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente:Usuario
    {
        private string _id;
        private static int s_ultimoID = 1;

        // Saldo disponible
        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
        }

        public string ID
        {
            get { return _id; }
        }

        public Cliente(string nombre, string apellido, string email, string password, double saldo) : base(nombre, apellido, email, password)
        {
            this._saldo = saldo;
            this._id = $"CLI{s_ultimoID + 1}";
            s_ultimoID++;
        }

        public override string ToString()
        {
            return $"Nombre completo: {Nombre} {Apellido}, informacion de contacto: {Email}, ID: {_id}, Saldo: {_saldo}";
        }
    }
}
