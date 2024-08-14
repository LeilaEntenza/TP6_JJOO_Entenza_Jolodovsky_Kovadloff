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
     public IActionResult Deportes(int idDeporte)
    {
        ViewBag.ListaDeportes=BD.ListarDeportes();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Paises(){
        ViewBag.ListaPaises=BD.ListarPaises();
        return View("Paises");
    }

    public IActionResult VerDetalleDeporte (int idDeporte){
        ViewBag.ListaDeportes=BD.ListarDeportes();
        ViewBag.ListaDeportistasDeportes=BD.ListarDeportistasDeporte(idDeporte);
        return View("DetalleDeporte");
    }

    public IActionResult VerDetallePais (int idPais){
        ViewBag.ListaPaises=BD.ListarPaises();
        ViewBag.ListarDeportistasPais=BD.ListarDeportistasPais(idPais);
        return View("DetallePais");
    }

    public IActionResult VerDetalleDeportista (int idDeportista){
        ViewBag.DatosDeportista=BD.VerInfoDeportista(idDeportista);
        return View("DetalleDeportista");
    }

    public IActionResult AgregarDeportista (){
        ViewBag.ListaPaises=BD.ListarPaises();
        ViewBag.ListaDeportes=BD.ListarDeportes();
        return View("AgregarDeportista");
    }
    public IActionResult EliminarDeportista (int idCandidato){
        BD.EliminarDeportista(idCandidato);
        return View("Index");
    }

        public IActionResult Creditos (){
        return View("Creditos");
    }
}
