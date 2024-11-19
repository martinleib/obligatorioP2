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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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
                if (string.IsNullOrEmpty(email))
                {
                    Usuario administradorBuscado = sistema.ObtenerAdministrador(email);
                    Cliente clienteBuscado = sistema.ObtenerCliente(email);
                    if (clienteBuscado != null)
                    {
                        //sistema.MostrarAlCliente();
                        // Ver todas las publicaciones
                        //Comprar una publicaci�n de tipo venta
                        // Ofertar en una subasta
                        //Cargar saldo en su billetera electr�nica
                        //Logout
                    }
                    else if (administradorBuscado != null)
                    {
                        //sistema.MostrarAlAdministrador();
                        //Ver todas las subastas
                        //Cerrar una subasta
                        //Logout
                    }
                    else
                    {
                        ViewBag.Error = "Debe registrarse antes de inciar sesion";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}
