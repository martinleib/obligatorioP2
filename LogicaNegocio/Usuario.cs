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

        public Usuario()
        {
            this._id = $"USU{s_ultimoID + 1}";
            s_ultimoID++;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
        }
        
        public bool Equals(object obj)
        {
            // nota: los correos no son case-sensitive
            // por eso el trimmeo y la conversión a mayúsculas
            if (obj is Usuario usuario)
            {
                return _email.Trim().ToUpper() == usuario._email.Trim().ToUpper();
            }
            
            return false;
        }

        
        public void Validar()
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
            if (string.IsNullOrEmpty(_password) || _password.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres");
            }
        }

        public virtual string ObtenerTipo()
        {
            return "Administrador";
        }
    }
}
