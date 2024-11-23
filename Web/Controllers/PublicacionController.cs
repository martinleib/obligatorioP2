﻿using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("logged-user-type") != "Cliente")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(sistema.ListaVentas());
            }
        }
    }
}