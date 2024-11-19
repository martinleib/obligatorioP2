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
       return View(sistema.Usuarios);
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
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && saldo > 0 && password.Length >= 8)
            {
                sistema.AltaCliente(nombre, apellido, email, password, saldo);
                ViewBag.Mensaje = "Se ha registrado correctamente";
            }
        } catch (Exception ex)
        { 
            ViewBag.Error = ex.Message;
        }
        return View();
    }

    [HttpGet]
    public IActionResult Edit(string email)
    {
        Cliente cliente = sistema.ObtenerCliente(email);
        return View(cliente);
    }
    
    
    [HttpPost]
    public IActionResult Edit(double Monto, string Email)
    {
        bool resultado = false;
        try { 
            if (Monto > 0 && !string.IsNullOrEmpty(Email))
            {
                resultado = sistema.ModificarSaldo(Email,Monto);
            }
            if (resultado)
            {
                TempData["Exito"] = "La carga se a realizado con �xito!";
                return RedirectToAction("Edit");
            }
            else
            {

                TempData["Error"] = "No se logro cargar la billetera electronica";
                return RedirectToAction("Edit");
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Edit");
        }
    }
    
    public IActionResult MostrarAlAdmin()
    {
        if (HttpContext.Session.GetString("logged-user-id") != null &&
            HttpContext.Session.GetString("logged-user-type") != "Cliente") {
            string idCliente = (string)HttpContext.Session.GetString("logged-user-id");
        }
        else
            return RedirectToAction("Login", "Home");
            
        return View();
    }

}