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

        public Cliente(string nombre, string apellido, string email, string password, double saldo) : base(nombre, apellido, email, password)
        {
            // Es el método constructor de la clase cliente que se usará para crear instancias del tipo cliente.
            // Al igual que en la clase Administrador se usa el constructor de la clase de la cual se está heredando (usuario) para construir la clase heredada
            // En este caso, además, se construye la instancia de Cliente con un atríbuto extra (saldo).
            this._saldo = saldo;
        }

        // Metodo que modifica el comportamiento del método ToString de la clase usuario, permitiendo imprimir los atributos nombre, apellido, email, ID y saldo.
        public override string ToString()
        {
            return $"Nombre completo: {Nombre} {Apellido}, informacion de contacto: {Email}, ID: {Id}, Saldo: {_saldo}";
        }
    }
}
