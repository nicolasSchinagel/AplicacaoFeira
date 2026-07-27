using AplicacaoFeira.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AplicacaoFeira.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //serializar
            string clienteJSONString = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastro(Key, clienteJSONString);
        }

        public Cliente GetCliente()
        {
            //deserializar
            if (_sessao.Existe(Key))
            {
                string clienteJSONString = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
