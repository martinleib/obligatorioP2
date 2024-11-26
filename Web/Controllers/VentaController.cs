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
                try
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        Venta venta = sistema.ObtenerVenta(id);
                        Cliente comprador = sistema.ObtenerCliente(HttpContext.Session.GetString("usuario-id"));
                        venta.CompraVenta(comprador);
                        return View(venta);
                    }
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = ex.Message;
                    return RedirectToAction("Index", "Publicacion");
                }

            }
            else if(HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            {
                return RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
