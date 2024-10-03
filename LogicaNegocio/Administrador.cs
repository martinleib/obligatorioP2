using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Administrador:Usuario
    {
        private string _id;
        private static int s_ultimoID = 1;
        public Administrador(string nombre, string apellido, string email, string password):base(nombre, apellido, email, password)
        {
            // El ID se veria: ADMIN01, ADMIN02, etc...
            // Separo IDs por Admin y Cliente para diferenciar usuarios Admin y Cliente
            this._id = $"ADMIN{s_ultimoID + 1}";
            s_ultimoID++;
        }
    }
}
