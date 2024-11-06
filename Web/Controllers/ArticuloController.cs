using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ArticuloController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]

    public IActionResult Create(int precio, string nombre, string categoria)
    {
        try
        {
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(categoria) && precio > 0)
            {
                sistema.AltaArticulo(precio, nombre, categoria);
                ViewBag.Mensaje = "Se a dado de alta correctamente el articulo";

            }
        } catch(Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View();
    }
}