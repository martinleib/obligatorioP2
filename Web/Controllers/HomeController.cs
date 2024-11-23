using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LogicaNegocio;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return RedirectPermanent("/Cliente/Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    Usuario aux = sistema.BuscarUsuario(email, password);
                    
                    if (aux != null)
                    {
                        string rol = aux.ObtenerTipo();

                        HttpContext.Session.SetString("usuario-id", aux.Id);
                        HttpContext.Session.SetString("usuario-tipo", rol);
                        
                        switch (rol)
                        {
                            case "Cliente":
                                return RedirectToAction("Index", "Cliente");
                            case "Administrador":
                                return RedirectToAction("Index", "Usuario");
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                        ViewBag.Error = "Las credenciales no son correctas, inténtelo nuevamente";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
