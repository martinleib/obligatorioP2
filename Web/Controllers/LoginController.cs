using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class LoginController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    public ActionResult Login()
    {
        return View();
    }
    [HttpPost]

    public IActionResult Login(string email)
    {
        try
        {
            if (string.IsNullOrEmpty(email))
            {
                Usuario administradorBuscado = sistema.ObtenerAdministrador(email);
                Cliente clienteBuscado = sistema.ObtenerCliente(email);
                if (clienteBuscado != null)
                {
                    //sistema.MostrarAlCliente();
                    // Ver todas las publicaciones
                    //Comprar una publicaci�n de tipo venta
                    // Ofertar en una subasta
                    //Cargar saldo en su billetera electr�nica
                    //Logout
                }
                else if (administradorBuscado != null)
                {
                    //sistema.MostrarAlAdministrador();
                    //Ver todas las subastas
                    //Cerrar una subasta
                    //Logout
                }
                else
                {
                    ViewBag.Error = "Debe registrarse antes de inciar sesion";
                }
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }
        return View();
    }
}