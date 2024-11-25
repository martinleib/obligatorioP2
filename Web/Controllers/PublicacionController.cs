using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            {
                return RedirectToAction("Index", "Cliente");
            }
            else if(HttpContext.Session.GetString("usuario-tipo") == "Cliente")
            {
                return View(sistema.Publicaciones);
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
