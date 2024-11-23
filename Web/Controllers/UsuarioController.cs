using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UsuarioController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    [HttpGet]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("usuario-id") == null ||
            HttpContext.Session.GetString("usuario-tipo") != "Administrador") {
            return RedirectToAction("Login", "Home");
        }else
            return View(sistema.ObtenerAdmin(HttpContext.Session.GetString("usuario-id")));
    }
}