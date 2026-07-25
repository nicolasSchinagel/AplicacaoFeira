using AplicacaoFeira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AplicacaoFeira.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Geografia()
        {
            return View();
        }
        public IActionResult Economia()
        {
            return View();
        }
        public IActionResult Cultura()
        {
            return View();
        }
        public IActionResult Culinaria()
        {
            return View();
        }
        public IActionResult Celebridades()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
