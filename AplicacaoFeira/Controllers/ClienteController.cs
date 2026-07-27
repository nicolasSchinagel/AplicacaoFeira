using Microsoft.AspNetCore.Mvc;
using AplicacaoFeira.Models;
using AplicacaoFeira.Repository;
using AplicacaoFeira.Repository.Contract;
using AplicacaoFeira.Libraries.Login;
using AplicacaoFeira.Libraries.Sessao;

namespace AplicacaoFeira.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;
        private LoginCliente _loginCliente;
        public ClienteController(IClienteRepository clienteRepository, LoginCliente loginCliente)
        {
            _clienteRepository = clienteRepository;
            _loginCliente = loginCliente;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {
            Cliente clientedb = _clienteRepository.Login(cliente.Email, cliente.Senha);
            if(clientedb.Email != null && clientedb.Senha != null)
            {
                _loginCliente.Login(clientedb);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não localizado, por favor verifique e-mail e senha digitado";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if(cliente.Senha == cliente.ConfirmacaoSenha)
                {
                    _clienteRepository.Cadastro(cliente);
                    return RedirectToAction("Login", "Cliente");
                }
                else
                {
                    return View(cliente);
                }
            }
            else
            {
                return View(cliente);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _loginCliente.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
