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

    public IActionResult Login()
    {
        return View();
    }
       public IActionResult VerificarContraseña(Login us)
        {
            if (string.IsNullOrEmpty(us.Contraseña))
            {
                ViewBag.Error = "Se deben completar todos los campos";
                return RedirectToAction("Account");
            }
            else
            {
                Login comparar = BD.LoginIngresado(us.id);
// Console.WriteLine(us.Contraseña);
Console.WriteLine(comparar.Contraseña);

if (comparar != null)
{
    if (us.Contraseña == comparar.Contraseña)
    {
        return RedirectToAction("Bienvenida");
    }
    else
    {
        ViewBag.Verificar = "La contraseña ingresada es incorrecta";
        return RedirectToAction("index");
    }
}
else
{
    // Handle the case where no matching record was found
    ViewBag.Verificar = "No se encontró un usuario con ese ID";
}

return RedirectToAction("index");
            }
}
   public IActionResult GuardarUsuario(Login nuevoUser)
        {
            if (string.IsNullOrEmpty(nuevoUser.Usuario) || string.IsNullOrEmpty(nuevoUser.Contraseña) || string.IsNullOrEmpty(nuevoUser.Nombre) || string.IsNullOrEmpty(nuevoUser.Email) ||string.IsNullOrEmpty(nuevoUser.Telefono) )
            {
                ViewBag.Error = "Se deben completar todos los campos";
                return RedirectToAction("Registro");
            }
            else
            {
                BD.InsertUser(nuevoUser);
                return RedirectToAction("index");
            }
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
