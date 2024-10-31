using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ArticuloController : Controller
{
    private Sistema sistema = new Sistema();
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(int precio, string nombre, string categoria)
    {
        if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(categoria) && precio > 0)
        {
            sistema.AltaArticulo(precio, nombre, categoria);
        }
        
        return View();
    }
}