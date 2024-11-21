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
        string loggedUserId = HttpContext.Session.GetString("logged-user-id");
        string loggedUserType = HttpContext.Session.GetString("logged-user-type");

        if (!string.IsNullOrEmpty(loggedUserId))
        {
            if (loggedUserType == "Administrador")
            {
                return View(sistema.ListaClientes());
            }
            else if (loggedUserType == "Cliente")
            {
                Cliente cliente = sistema.ObtenerCliente(loggedUserId);
                return View(cliente);
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
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrEmpty(apellido))
                throw new ArgumentException("El apellido no puede estar vacío.");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("El email no puede estar vacío.");

            if (string.IsNullOrEmpty(password) || password.Length < 8)
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");

            if (saldo <= 0) 
                throw new ArgumentException("El saldo debe ser mayor a 0.");

            
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
        string id = HttpContext.Session.GetString("logged-user-id");
        Cliente cliente = sistema.ObtenerCliente(id);
        return View(cliente);
    }
    
    [HttpPost]
    public IActionResult Edit(double monto)
    {
        bool resultado = false;
        string id = HttpContext.Session.GetString("logged-user-id");
        
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