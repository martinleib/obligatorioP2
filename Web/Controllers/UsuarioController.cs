using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UsuarioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult MostrarAlAdmin()
    {
        if (HttpContext.Session.GetString("logged-user-id") != null &&
            HttpContext.Session.GetString("logged-user-type") != "Administrador") {
            string idAdmin = (string)HttpContext.Session.GetString("logged-user-id");
        }
        else
            return RedirectToAction("Login", "Home");
            
        return View();
    }
}