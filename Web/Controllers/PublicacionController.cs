using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View(sistema.ListaVentas());
        }
    }
}
