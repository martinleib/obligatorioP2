using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Administrador:Usuario
    {
        public Administrador(string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {
            // Administrador hereda de usuario
        }
    }
}
