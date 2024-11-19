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

        //METODO EN SISTEMA QUE DEVUELVA UNA LISTA DE CLIENTES RECORRIENDO LA LISTA DE USUARIO
        //No hay que castiarlo despues porque va a devolver una lista de clientes osea se castea directamente
        //en el metodo asi es solo poner por ejemplo
        //return View(sistema.ListaDeClientes)


        List<Cliente> aux = new List<Cliente>();

        if (HttpContext.Session.GetString("logged-user-id") != null &&
            HttpContext.Session.GetString("logged-user-type") == "Cliente")
        {
            string idCliente = (string)HttpContext.Session.GetString("logged-user-id");

            foreach (Usuario usuario in sistema.Usuarios)
            {
                if (usuario.ObtenerTipo() == "Cliente")
                {
                    aux.Add((Cliente)usuario);
                }
            }
        }
        else { 
            return RedirectToAction("Login", "Home");
        }
        return View(aux);
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

    //Hay 
    public IActionResult Edit(string Id)
    {
        Cliente cliente = sistema.ObtenerCliente(Id);
        return View(cliente);
    }
    
    [HttpPost]
    public IActionResult Edit(double Monto, string Id)
    {
        bool resultado = false;
        try
        {
            if (Monto > 0 && !string.IsNullOrEmpty(Id))
            {
                resultado = sistema.ModificarSaldo(Id, Monto);
            }

            if (resultado)
            {
                TempData["Exito"] = "La carga se ha realizado con éxito!";
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
}