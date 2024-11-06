using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UsuarioController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    /*public IActionResult Index()
    {
        return View();
    }*/

    public ActionResult Login()
    {
        return View();
    }
    [HttpPost]

    public ActionResult Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email)) 
        {
            Usuario administradorBuscado = sistema.ObtenerAdministrador(email);
            Cliente clienteBuscado = sistema.ObtenerCliente(email);
            if (clienteBuscado != null) 
            {
                sistema.MostrarAlCliente();
                // Ver todas las publicaciones
                //Comprar una publicación de tipo venta
                // Ofertar en una subasta
                //Cargar saldo en su billetera electrónica
                //Logout
            }
            else if(administradorBuscado != null)
            {
                sistema.MostrarAlAdministrador();
                //Ver todas las subastas
                //Cerrar una subasta
                //Logout
            }
            else
            {
                ViewBag.Error = "Debe registrarse antes de inciar sesion";
            }
        }
        return View();
    }
}