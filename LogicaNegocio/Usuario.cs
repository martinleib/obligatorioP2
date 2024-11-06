using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{

    public class Usuario:IValidate
    {
        protected string _nombre;
        protected string _apellido;
        protected string _email;
        private string _password;
        protected string _id;
        private static int s_ultimoID = 1;

        // Es el método constructor de la clase usuario que se usará para crear instancias del tipo usuario.
        public Usuario(string nombre, string apellido, string email, string password)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._email = email;
            this._password = password;
            this._id = $"USU{s_ultimoID + 1}";
            s_ultimoID++;
        }

        // Propiedad que devuelve el ID de una instancia usuario.
        public string Id
        {
            get { return _id; }
        }

        public string Email
        {
            get { return _email; }
        }

        public override bool Equals(object obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Usuario)
            {
                Usuario usuario = (Usuario)obj;
                sonIguales = _email == usuario._email;
            }
            return sonIguales;
        }
        
        public override void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }
            if (string.IsNullOrEmpty(_apellido))
            {
                throw new Exception("El apellido no puede estar vacío");
            }
            if (string.IsNullOrEmpty(_email))
            {
                throw new Exception("El email no puede estar vacío");
            }
            if (string.IsNullOrEmpty(_password))
            {
                throw new Exception("La contraseña no puede estar vacía");
            }
        }
    }
}
