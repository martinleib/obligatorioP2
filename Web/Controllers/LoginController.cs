using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class LoginController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}