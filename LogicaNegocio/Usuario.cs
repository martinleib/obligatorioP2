using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{

    public abstract class Usuario:IEquatable<Usuario>

    {
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;
        public string Email
        {
            get { return _email; }
        }


        public Usuario(string nombre, string apellido, string email, string password)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._email = email;
            this._password = password;
        }
        public bool Equals(Usuario? other)
        {
            return _email.Equals(other._email);
        }

        public override string ToString()
        {
            return "Nombre completo: " + _nombre + " " + _apellido + ", " + "informacion de contacto:" + " " + _email + ", " + "contraseña:" + " " + _password;
        }
    }
}
