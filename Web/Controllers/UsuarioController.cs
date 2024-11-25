using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UsuarioController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    [HttpGet]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("usuario-tipo") == "Cliente") {
            return RedirectToAction("Index", "Publicacion");
        }else if(HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            return View(sistema.ObtenerAdmin(HttpContext.Session.GetString("usuario-id")));
        }
        return RedirectToAction("Login", "Home");
    }
}
