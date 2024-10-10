using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{

    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;
        private string _id;
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

        public override bool Equals(object obj)
    {
        if (obj is Cliente otroCliente)
        {
            return string.Equals(this.Id.Trim(), otroCliente.Id.Trim());
        }
        return false;
    }

        // Propiedad que devuelve el nombre de una instancia usuario.
        public string Nombre
        {
            get { return _nombre; }
        }

        // Propiedad que devuelve el apellido de una instancia usuario.
        public string Apellido
        {
            get { return _apellido; }
        }

        // Propiedad que devuelve el correo de una instancia usuario.
        public string Email
        {
            get { return _email; }
        }
    }
}
