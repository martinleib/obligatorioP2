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
            if (sistema.ObtenerCliente(HttpContext.Session.GetString("logged-user-id")) != null ||
            HttpContext.Session.GetString("logged-user-type") == "Cliente")
            {
                Venta venta = sistema.ObtenerVenta(id);
                sistema.CompraVenta(HttpContext.Session.GetString("logged-user-id"), venta);
                return View(venta);
            }
            return RedirectToAction("Index", "Subasta");
        }
    }
}
