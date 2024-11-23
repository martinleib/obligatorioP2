// using LogicaNegocio;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Web.Controllers
// {
//     public class PublicacionController : Controller
//     {
//         private Sistema sistema = Sistema.Instancia;
//
//         public IActionResult Index()
//         {
//             if (HttpContext.Session.GetString("usuario-tipo") != "Cliente")
//             {
//                 return RedirectToAction("Index", "Home");
//             }
//             else
//             {
//                 return View(sistema.ListaVentas());
//             }
//         }
//     }
// }