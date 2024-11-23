﻿using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VentaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Edit(string id)
        {
                Venta venta = sistema.ObtenerVenta(id);
                sistema.CompraVenta(HttpContext.Session.GetString("usuario-id"), venta);
                return View(venta);
        }
    }
}
