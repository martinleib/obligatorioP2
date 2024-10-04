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
        private string _id;
        private static int s_ultimoID = 1;

        public Usuario(string nombre, string apellido, string email, string password)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._email = email;
            this._password = password;
            this._id = $"USU{s_ultimoID + 1}";
            s_ultimoID++;
        }

        public string Id
        {
            get { return _id; }
        }
    }
}
