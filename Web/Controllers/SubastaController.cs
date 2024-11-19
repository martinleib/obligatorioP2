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

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Subasta subasta = sistema.ObtenerSubasta(id);
            return View(subasta);
        }
        
        [HttpPost]
        public IActionResult Edit(string Id, int Monto)
        {

        Subasta subasta = sistema.ObtenerSubasta(Id);
        bool resultado = false;
        try
        {
            Cliente cliente = sistema.ObtenerCliente("USU10");

            if (subasta != null && Monto > 0 && cliente != null)
            {
                resultado = subasta.Ofertar(cliente, Monto);
            }

            if (resultado)
            {
                TempData["Exito"] = "Oferta realizada con éxito!";
                return RedirectToAction("Index","Publicacion");
            }
            else
            {

                TempData["Error"] = "No fue posible agregar la oferta";
                return RedirectToAction("Index","Publicacion");
            }
        }
        
        catch (Exception ex)
        {
            TempData["Error"] = "No fue posible agregar la oferta";
        }
        return View();

        }
    }
}
