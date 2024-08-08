using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6_JJOO_Entenza_Jolodovsky_Kovadloff.Models;

namespace TP6_JJOO_Entenza_Jolodovsky_Kovadloff.Controllers;

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
     public IActionResult Deportes()
    {
        /*ViewBag.ListaDeportes=Models.Deporte.'funcion'*/
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Paises(){
      
        return View("Paises");
    }
}
