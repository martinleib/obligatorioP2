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
        if (HttpContext.Session.GetString("idAdmin") != null) {
            string idAdmin = (string)HttpContext.Session.GetString("idAdmin");
        }
        else
            return RedirectToAction("Login", "Home");
            
        return View();
    }
}