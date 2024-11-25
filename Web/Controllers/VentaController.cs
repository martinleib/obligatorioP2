using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VentaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (HttpContext.Session.GetString("usuario-tipo") == "Cliente")
            {
                Venta venta = sistema.ObtenerVenta(id);
                sistema.CompraVenta(HttpContext.Session.GetString("usuario-id"), venta);
                return View(venta);
                
            }
            else if(HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            {
                return RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
