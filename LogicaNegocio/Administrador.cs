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
            // Es el método constructor de la clase administrador que se usará para crear instancias del tipo administrador.
            // En este caso está usando el método constructor de la clase de la que está heredando (usuario).
        }
    }
}
