using AplicacaoFeira.Models;

namespace AplicacaoFeira.Repository.Contract
{
    public interface IClienteRepository
    {
        Cliente Login(string Email, string Senha);
        void Cadastro(Cliente cliente);
    }
}
