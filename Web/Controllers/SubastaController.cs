using LogicaNegocio;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("usuario-tipo") == "Cliente")
            {
                return RedirectToAction("Index", "Cliente");
            }
            else if(HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            {
                return View(sistema.SubastasOrdenadas());
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (HttpContext.Session.GetString("usuario-tipo") == "Cliente")
            {
                Subasta subasta = sistema.ObtenerSubasta(id);
                return View(subasta);
            }
            else if(HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            {
                return RedirectToAction("Index", "Usuario");
            }
            
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult Edit(string idsubasta, int monto)
        {
            Subasta subasta = sistema.ObtenerSubasta(idsubasta);
            string idcliente = HttpContext.Session.GetString("usuario-id");
            bool resultado = false;

            try
            {
                Cliente cliente = sistema.ObtenerCliente(idcliente);

                if (subasta != null && monto > 0 && cliente != null)
                {
                    resultado = subasta.Ofertar(cliente, monto);
                }

                if (resultado)
                {
                    TempData["Exito"] = "Oferta realizada con éxito!";
                    return RedirectToAction("Index", "Publicacion");
                }
                else
                {
                    TempData["Error"] = "No fue posible agregar la oferta";
                    return RedirectToAction("Index", "Publicacion");
                }
            }

            catch (Exception ex)
            {
                TempData["Error"] = "No fue posible agregar la oferta";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Cerrar(string id)
        {
            if (HttpContext.Session.GetString("usuario-tipo") == "Administrador")
            {
                return View(sistema.ObtenerSubasta(id));
            }
            else if(HttpContext.Session.GetString("usuario-tipo") == "Cliente")
            {
                return RedirectToAction("Index", "Cliente");
            } 
            
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult Cerrar(string idsubasta, Usuario usuario)
        {
            Subasta subasta = sistema.ObtenerSubasta(idsubasta);
            Usuario admin = sistema.ObtenerAdmin(HttpContext.Session.GetString("usuario-id"));
            bool result = sistema.CerrarSubasta(subasta, admin);

            if (!result)
            {
                TempData["Error"] = "No fue posible cerrar la subasta";
                return RedirectToAction("Index", "Subasta");
            }
            else
            {
                TempData["Exito"] = "Oferta cerrada con éxito!";
                return RedirectToAction("Index", "Subasta");
            }
        }
    }
}
