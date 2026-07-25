using Microsoft.AspNetCore.Mvc;

namespace AplicacaoFeira.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
