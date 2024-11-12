using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VentaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Edit(string IdVenta)
        {
            Venta venta = sistema.ObtenerVenta(IdVenta);
            return View(venta);
        }

        /*public IActionResult Edit(string IdVenta)
        {
        
            Venta venta = sistema.ObtenerVenta(IdVenta);
            Cliente cliente = sistema.ObtenerCliente(IdCliente);
            bool resultado = false;
            try
            {
                if (venta != null && usuario != null)
                {
                    //resultado = venta.Ofertar(cliente);
                }

                if (resultado)
                {
                    TempData["Exito"] = "Compra realizada con éxito!";
                    return RedirectToAction("Edit");
                }
                else
                {

                    TempData["Error"] = "No fue posible la compra";
                    return RedirectToAction("Edit");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ""No fue posible la compra"";
            }
        }*/
    }
}
