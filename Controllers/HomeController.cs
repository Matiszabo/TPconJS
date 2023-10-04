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


    public IActionResult VerificarContraseña(string Usuario, string Contraseña)
    {
        if (string.IsNullOrEmpty(Contraseña)  || string.IsNullOrEmpty(Usuario) )
        {
            ViewBag.Error = "Se deben completar todos los campos";
            return RedirectToAction("Account");
        }
        else
        {
            Login comparar = BD.LoginIngresado(Usuario, Contraseña);
        
            if (comparar != null)
            {
                if (Contraseña == comparar.Contraseña)
                {
                    return RedirectToAction("Bienvenida", "Home", new {id=comparar.id});
                }
            }
            else
            {
                ViewBag.Verificar = "El usuario y/o contraseña ingresada son incorrectos";
            }

            return View("Login");
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
            return RedirectToAction("Login");
        }
    }

    public IActionResult Registro()
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
