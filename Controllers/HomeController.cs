using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerTPconJS.Models;
using log.Models;
using PrimerProyecto.Models;
namespace PrimerTPconJS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Bienvenida(int id)
    {
        Login Model=BD.ListarPorId(id);
        ViewBag.Usuario=Model.Usuario;
        ViewBag.Nombre=Model.Nombre;
        ViewBag.Email=Model.Email;
        ViewBag.Telefono=Model.Telefono;
        return View();
    }
    
    public IActionResult CerrarSesion()
    {
        return RedirectToAction("Index");
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
