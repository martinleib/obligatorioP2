using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ClienteController : Controller
{
    private Sistema sistema = Sistema.Instancia;
    /*public IActionResult Index()
    {
        return View();
    }*/

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]

    public IActionResult Create(string nombre, string apellido, string email, string password, double saldo)
    {
        try
        {
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && saldo > 0 && password.Length >= 8)
            {
                sistema.AltaCliente(nombre, apellido, email, password, saldo);
                ViewBag.Mensaje = "Se a registrado correctamente";
            }
        } catch (Exception ex)
        { 
            ViewBag.Error = ex.Message;
        }
        return View();
    }
}