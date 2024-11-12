using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    public class SubastaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            return View(sistema.SubastasOrdenadas());
        }

        /*public IActionResult Edit(string IdSubasta)
        {
            Subasta subasta = sistema.ObtenerSubasta(IdSubasta);
            return View(subasta);
        }*/

        /*public IActionResult Edit(string IdSubasta, double monto)
        {
        
            Subasta subasta = sistema.ObtenerSubasta(subastaId);
            Cliente cliente = sistema.ObtenerCliente(IdUsuario);
            bool resultado = false;
            try
            {
                if (subasta != null && monto > 0 && cliente != null)
                {
                    resultado = subasta.Ofertar(cliente, monto);
                }

                if (resultado)
                {
                    TempData["Exito"] = "Oferta realizada con éxito!";
                    return RedirectToAction("Edit");
                }
                else
                {

                    TempData["Error"] = "No fue posible agregar la oferta";
                    return RedirectToAction("Edit");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No fue posible agregar la oferta";
            }
        }*/
    }
}
