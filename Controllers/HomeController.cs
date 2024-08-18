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
        return View("Index");
    }
    
     public IActionResult Deportes(int idDeporte)
    {
        ViewBag.ListaDeportes=BD.ListarDeportes();
        return View("Deportes");
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

    public IActionResult VerDetalleDeporte (int IdDeporte){
        ViewBag.ElDeporte=IdDeporte;
        ViewBag.Deporte=BD.VerInfoDeporte(IdDeporte);
        ViewBag.ListaDeportistasDeportes=BD.ListarDeportistasDeporte(IdDeporte);
        return View("DetalleDeporte");
    }

    public IActionResult VerDetallePais (int IdPais){
        ViewBag.Pais=BD.VerInfoPais(IdPais);
        ViewBag.ListarDeportistasPais=BD.ListarDeportistasPais(IdPais);
        return View("DetallePais");
    }

    public IActionResult VerDetalleDeportista (int idDeportista){
        ViewBag.DatosDeportista=BD.VerInfoDeportista(idDeportista);
        return View("DetalleDeportista");
    }

    [HttpPost] 
    public IActionResult GuardarDeportista(string FotoDeportista, string Apellido, string Nombre, DateTime FechaNacimiento, int IdDeporte, int IdPais){
        Deportista dep = new Deportista();
        dep.Apellido=Apellido;
        dep.Nombre=Nombre;
        dep.FechaNacimiento=FechaNacimiento;
        dep.Foto=FotoDeportista;
        dep.IdDeporte=IdDeporte;
        dep.IdPais=IdPais;
        BD.AgregarDeportista(dep);
        return View("Index");
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
        public IActionResult Historia (){
            return View("Historia");
        }
}
