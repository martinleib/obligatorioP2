using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SubastaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Ofertar()
        {
            return View();
        }

        public IActionResult Ofertar(string subastaId, double monto)
        {
            Subasta subasta = sistema.ObtenerSubasta(subastaId);
            bool resultado = false;
            try
            {
                if (subasta != null && subasta != null && monto > 0)
                {
                    //resultado = subasta.Ofertar(cliente, monto);
                }

                if (resultado)
                {
                    TempData["Exito"] = "Oferta realizada con éxito!";
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["Error"] = "No fue la oferta mas alta hasta el momento";
                    return RedirectToAction("Edit");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
        }
    }
}
