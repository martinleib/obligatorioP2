using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Web.Controllers;

public class ClienteController : Controller
{
    private Sistema sistema = Sistema.Instancia;
    
    [HttpGet]
    public IActionResult Index()
    {
        string loggedUserId = HttpContext.Session.GetString("usuario-id");
        string loggedUserType = HttpContext.Session.GetString("usuario-tipo");

        if (!string.IsNullOrEmpty(loggedUserId))
        {
            if (loggedUserType == "Administrador")
            {
                ViewBag.ListaCliente = sistema.ListaClientes();
                return View();
            }
            else if (loggedUserType == "Cliente")
            {
                ViewBag.Cliente = sistema.ObtenerCliente(loggedUserId);
                return View();
            }
        }
        
        return RedirectToAction("Login", "Home");
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string nombre, string apellido, string email, string password, double saldo)
    {
        try
        {
            sistema.AltaCliente(nombre, apellido, email, password, saldo);
            ViewBag.Mensaje = "Se ha registrado correctamente";
        }
        catch (Exception ex)
        {
            ViewBag.Mensaje = ex.Message;
        }

        return View();
    }

    [HttpGet]
    public IActionResult Edit()
    {
        
        if(HttpContext.Session.GetString("usuario-tipo") == "Cliente"){
        string id = HttpContext.Session.GetString("usuario-id");
        Cliente cliente = sistema.ObtenerCliente(id);
        return View(cliente);
        }else if(HttpContext.Session.GetString("usuario-tipo") == "Administrador")
        return RedirectToAction("Index", "Cliente");
        }
        return RedirectToAction("Login", "Home");
    }
    
    [HttpPost]
    public IActionResult Edit(double monto)
    {
        bool resultado = false;
        string id = HttpContext.Session.GetString("usuario-id");
        
        try
        {
            if (monto > 0 && !string.IsNullOrEmpty(id))
            {
                resultado = sistema.ModificarSaldo(id, monto);
            }
    
            if (resultado)
            {
                TempData["Exito"] = $"La carga de {monto} USD se realizó con éxito. \n Tu nuevo saldo es de {sistema.ObtenerCliente(id).Saldo} USD.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Hubo un error a la hora de cargar saldo. Intente nuevamente.";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            TempData["Mensaje"] = ex.Message;
            return RedirectToAction("Index");
        }
    }
}
