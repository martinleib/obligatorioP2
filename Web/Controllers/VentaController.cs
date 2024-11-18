using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VentaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        [HttpGet]
        public IActionResult Edit(string Id,bool e)
        {
            Venta venta = sistema.ObtenerVenta(Id);
            return View(venta);
        }

        [HttpPost]
        public IActionResult Edit(string IdVenta)
        {
            try
            {
                Venta venta = sistema.ObtenerVenta(IdVenta);
                Cliente cliente = sistema.ObtenerCliente("USU4");
               
                bool resultado = false;
                
                if (venta != null && cliente != null)
                {
                    resultado = venta.Compra(cliente);
                }

                if (resultado)
                {
                    TempData["Exito"] = "Compra realizada con éxito!";
                }
                else
                {

                    TempData["Error"] = "No fue posible la compra";

                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No fue posible la compra";
            }
            return RedirectToAction("Index","Publicacion");
        }
    }
}
